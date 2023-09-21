import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatTableDataSource } from '@angular/material/table';
import { Shippers } from 'src/app/models/shippersInterface';
import { ShipperService } from 'src/app/service/shipper.service';
import { swalWithBootstrapButtons } from 'src/assets/swalMixin';

import Swal from 'sweetalert2';

@Component({
  selector: 'app-shippers-table',
  templateUrl: './shippers-table.component.html',
  styleUrls: ['./shippers-table.component.css'],
})
export class ShippersTableComponent implements OnInit {
  formShipper: FormGroup;
  isFormMode: boolean = true;
  listShippers: Shippers[] = [];
  displayedColumns: string[] = ['id', 'companyName', 'phone', 'action'];
  dataSource = new MatTableDataSource(this.listShippers);

  constructor(
    private _shipperService: ShipperService,
    private fb: FormBuilder
  ) {
    this.formShipper = this.fb.group({
      Id: [{ value: '', disabled: true }],
      companyName: ['', Validators.required],
      phone: [''],
    });
  }

  ngOnInit(): void {
    this.getAllShippers();
  }

  onSubmitShipper() {
    this.isFormMode ? this.insertShipper() : this.editShipper();
  }

  insertShipper() {
    let shipperInsert: Shippers = {
      CompanyName: this.formShipper.get('companyName')?.value,
      Phone: this.formShipper.get('phone')?.value,
    };

    this._shipperService.insertShipper(shipperInsert).subscribe({
      next: () => {
        this.getAllShippers();
        this.formShipper.reset();
      },
      error: (e) => {
        {
          Swal.fire({
            icon: 'error',
            title: 'Oops...',
            text: 'Error en el servidor!',
          });
          this.formShipper.reset();
        }
      },
      complete: () => {
        Swal.fire({
          icon: 'success',
          title: 'Operación exitosa',
          text:
            'La compania ' +
            shipperInsert.CompanyName +
            ' ha sido agregada exitosamente!!',
        });
        this.formShipper.reset();
      },
    });
  }

  modalEditShipper(shipperElement: Shippers) {
    this.isFormMode = false;
    this.formShipper.patchValue({
      Id: shipperElement.ShipperID,
      companyName: shipperElement.CompanyName,
      phone: shipperElement.Phone,
    });
  }

  editShipper() {
    let shipperEdit: Shippers = {
      ShipperID: this.formShipper.get('Id')?.value,
      CompanyName: this.formShipper.get('companyName')?.value,
      Phone: this.formShipper.get('phone')?.value,
    };
    this._shipperService.editShipper(shipperEdit).subscribe({
      next: () => {
        this.formShipper.reset();
        this.getAllShippers();
      },
      error: () => {
        {
          Swal.fire({
            icon: 'error',
            title: 'Oops...',
            text: 'Error en el servidor!',
          });
          this.formShipper.reset();
        }
      },
      complete: () => {
        Swal.fire({
          icon: 'success',
          title: 'Operación exitosa',
          text: `El registro de ID ${shipperEdit.ShipperID} ha sido modificado exitosamente!!`,
        });
        this.formShipper.reset();
      },
    });
  }

  deleteShipper(id: number) {
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
          this._shipperService.deleteShipper(id).subscribe({
            next: () => {
              this.getAllShippers();
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

  getAllShippers() {
    this._shipperService.getAll().subscribe({
      next: (result) => {
        this.dataSource.data = result as Shippers[];
      },
      error: (e) => {
        Swal.fire({
          icon: 'error',
          title: 'Oops...',
          text: 'Error en el servidor!',
        });
      },
    });
  }
}
