import { HttpClient} from '@angular/common/http'
import { Injectable } from '@angular/core';
import { environment } from '../environments/environment';
import { Shippers } from '../models/shippersInterface';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ShipperService {

  apiUrl: string = environment.api + 'Shippers';

  constructor(private http: HttpClient) { }

  getAll():Observable<Shippers[]>{
    return this.http.get<Shippers[]>(this.apiUrl);
  }

  insertShipper(shipperRequest: Shippers) : Observable<any>{
    return this.http.post(this.apiUrl, shipperRequest);
  }
  
  deleteShipper(id: number): Observable<any>{
    let url = `${this.apiUrl}/${id}`
    return this.http.delete(url)
  }

  editShipper(shipperRequest: Shippers): Observable<any>{
    return this.http.put(this.apiUrl, shipperRequest);
  }

}
