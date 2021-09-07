import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { Observable } from 'rxjs';
import { Company } from '../models/company.model';
import { IModel } from '../models/interfaces/IModel';

@Injectable({
  providedIn: 'root'
})
export class CompanyService {
  private url = "http://localhost:61236/api/company";

  constructor(private http: HttpClient) { }

  getItems() : Observable<any> {
      return this.http.get(this.url);
  }

  createItem(item: Company) : Observable<Company> {
      return this.http.post<Company>(this.url, item);
  }
  
  updateItem(item: Company) : Observable<Company> {

      return this.http.put<Company>(this.url, item);
  }

  deleteItem(item: Company) : Observable<Company> {
      return this.http.delete<Company>(this.url + '/' + item.id);
  }
}
