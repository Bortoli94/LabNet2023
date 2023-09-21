import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatTableDataSource } from '@angular/material/table';
import { Categories } from 'src/app/models/categoriesInterface';
import { CategoryService } from 'src/app/service/category.service';
import { swalWithBootstrapButtons } from 'src/assets/swalMixin';

import Swal from 'sweetalert2';

@Component({
  selector: 'app-categories-table',
  templateUrl: './categories-table.component.html',
  styleUrls: ['./categories-table.component.css'],
})
export class CategoriesTableComponent implements OnInit {
  formCategory: FormGroup;
  isFormMode: boolean = true;
  listCategories: Categories[] = [];
  displayedColumns: string[] = ['id', 'name', 'description', 'action'];
  dataSource = new MatTableDataSource(this.listCategories);

  constructor(
    private _categoryService: CategoryService,
    private fb: FormBuilder
  ) {
    this.formCategory = this.fb.group({
      Id: [{ value: '', disabled: true }],
      categoryName: ['', [Validators.required, Validators.maxLength(15)] ],
      description: [''],
    });
  }

  ngOnInit(): void {
    this.getAllCategories();
  }

  onSubmitCategory() {
    this.isFormMode ? this.insertCategory() : this.editCategory();
  }

  insertCategory() {
    let categoryInsert: Categories = {
      CategoryName: this.formCategory.get('categoryName')?.value,
      Description: this.formCategory.get('description')?.value,
    };

    this._categoryService.insertCategory(categoryInsert).subscribe({
      next: () => {
        this.getAllCategories();
        this.formCategory.reset();
      },
      error: () => {
        {
          Swal.fire({
            icon: 'error',
            title: 'Oops...',
            text: 'Error en el servidor!',
          });
          this.formCategory.reset();
        }
      },
      complete: () => {
        Swal.fire({
          icon: 'success',
          title: 'Operación exitosa',
          text:
            'La compania ' +
            categoryInsert.CategoryName +
            ' ha sido agregada exitosamente!!',
        });
        this.formCategory.reset();
      },
    });
  }

  editCategory() {
    let categoryEdit: Categories = {
      CategoryID: this.formCategory.get('Id')?.value,
      CategoryName: this.formCategory.get('categoryName')?.value,
      Description: this.formCategory.get('description')?.value,
    };
    this._categoryService.editCategory(categoryEdit).subscribe({
      next: () => {
        this.formCategory.reset();
        this.getAllCategories();
      },
      error: () => {
        {
          Swal.fire({
            icon: 'error',
            title: 'Oops...',
            text: 'Error en el servidor!',
          });
          this.formCategory.reset();
        }
      },
      complete: () => {
        Swal.fire({
          icon: 'success',
          title: 'Operación exitosa',
          text: `El registro de ID ${categoryEdit.CategoryID} ha sido modificado exitosamente!!`,
        });
        this.formCategory.reset();
      },
    });
  }

  getAllCategories() {
    this._categoryService.getAll().subscribe({
      next: (result) => {
        this.dataSource.data = result as Categories[];
      },
      error: () => {
        Swal.fire({
          icon: 'error',
          title: 'Oops...',
          text: 'Error en el servidor!',
        });
      },
    });
  }

  modalEditCategory(categoryElement: Categories) {
    this.isFormMode = false;
    this.formCategory.patchValue({
      Id: categoryElement.CategoryID,
      categoryName: categoryElement.CategoryName,
      description: categoryElement.Description,
    });
  }

  deleteCategory(id: number) {
    swalWithBootstrapButtons
      .fire({
        title: 'Estas seguro?',
        text: `Estas a punto de eliminar el registro con ID ${id}, esta accion no se puede revertir`,
        icon: 'warning',
        showCancelButton: true,
        confirmButtonText: 'Si, borrar',
        cancelButtonText: 'No, cancelar',
        reverseButtons: true,
      })
      .then((result) => {
        if (result.isConfirmed) {
          this._categoryService.deleteCategory(id).subscribe({
            next: () => {
              this.getAllCategories();
              swalWithBootstrapButtons.fire(
                'Borrado!',
                `El registro con el ID ${id} ha sido eliminado`,
                'success'
              );
            },
            error: () => {
              Swal.fire({
                icon: 'error',
                title: 'Oops...',
                text: 'Error en el servidor!',
              });
            },
          });
        } else if (result.dismiss === Swal.DismissReason.cancel) {
          swalWithBootstrapButtons.fire(
            'Cancelado',
            'La operacion ha sido cancelada!!',
            'error'
          );
        }
      });
  }
}
