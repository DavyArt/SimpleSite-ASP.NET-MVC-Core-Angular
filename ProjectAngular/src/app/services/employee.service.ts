import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Employee } from '../models/employee.model';

@Injectable({
  providedIn: 'root'
})
export class EmployeeService {
  private url = "http://localhost:61236/api/employee";

  constructor(private http: HttpClient) { }

  getItems() : Observable<any> {
      return this.http.get(this.url);
  }

  createItem(item: Employee) : Observable<Employee> {
      return this.http.post<Employee>(this.url, item);
  }

  updateItem(item: Employee) : Observable<Employee> {

      return this.http.put<Employee>(this.url, item);
  }

  deleteItem(item: Employee) : Observable<Employee> {
      return this.http.delete<Employee>(this.url + '/' + item.id);
  }
}
