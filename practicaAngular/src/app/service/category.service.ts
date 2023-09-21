import { Injectable } from '@angular/core';
import { environment } from '../environments/environment';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Categories } from '../models/categoriesInterface';

@Injectable({
  providedIn: 'root'
})
export class CategoryService {

  apiUrl: string = environment.api + 'Categories';

  constructor(private hhtp: HttpClient) { }

  getAll():Observable<Categories[]>{
    return this.hhtp.get<Categories[]>(this.apiUrl);
  }

  insertCategory(categoryRequest: Categories) : Observable<any>{
    return this.hhtp.post(this.apiUrl, categoryRequest);
  }
  
  deleteCategory(id: number): Observable<any>{
    let url = `${this.apiUrl}/${id}`
    return this.hhtp.delete(url);
  }

  editCategory(categoryRequest: Categories): Observable<any>{
    return this.hhtp.put(this.apiUrl, categoryRequest);
  }
}
