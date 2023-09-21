import { Injectable } from '@angular/core';
import { environment } from '../environments/environment';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Categories } from '../models/categoriesInterface';

@Injectable({
  providedIn: 'root'
})
export class CategoryService {
  apiUrl: string = environment.api;

  constructor(private hhtp: HttpClient) { }

  getAll():Observable<Categories[]>{
    let url = `${this.apiUrl}Categories`;
    return this.hhtp.get<Categories[]>(url)
  }
}
