import { Component, OnInit } from '@angular/core';
import { MatTableDataSource } from '@angular/material/table';
import { Categories } from 'src/app/models/categoriesInterface';
import { CategoryService } from 'src/app/service/category.service';

@Component({
  selector: 'app-categories-table',
  templateUrl: './categories-table.component.html',
  styleUrls: ['./categories-table.component.css'],
})
export class CategoriesTableComponent implements OnInit {
  constructor(private _categoryService: CategoryService) {}

  listCategories: Categories[] = [];
  dataSource = new MatTableDataSource(this.listCategories);
  displayedColumns: string[] = ['id', 'name', 'description'];

  ngOnInit(): void {
    this.getAllCategories();
  }

  getAllCategories() {
    this._categoryService.getAll().subscribe({
      next: (result) => {
        this.dataSource.data = result as Categories[];
      },
      error: (e) => {
        console.log(e);
      },
    });
  }
}
