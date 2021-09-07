import { Component, OnInit } from '@angular/core';
import { Action } from '../models/action.model';
import { Company } from '../models/company.model';
import { Employee } from '../models/employee.model';
import { CompanyService } from '../services/company.service';
import { EmployeeService } from '../services/employee.service';

@Component({
  selector: 'app-employee-list',
  templateUrl: './employee-list.component.html',
  styles: [
  ]
})
export class EmployeeListComponent implements OnInit {
  companies: Company[] = []
  employees: Employee[] = []
  employee: Employee = new Employee()
  action: Action
  
  constructor(private companyService: CompanyService, private employeeService: EmployeeService) { }

  ngOnInit(): void {
    this.loadEmployees();
  }

  loadEmployees() {
    this.employeeService.getItems().subscribe((data: Employee[]) => this.employees = data);
  }

  getCompanies() {
    this.companyService.getItems().subscribe((data: Company[]) => this.companies = data);
  }

  addEmployee() {
    this.employee = new Employee();
    this.action = Action.Add;
    this.getCompanies();
  }

  editEmployee(employee: Employee) {
    this.employee = employee;
    this.action = Action.Edit;
    this.getCompanies();
  }

  deleteEmployee(employee: Employee) {
    this.employeeService.deleteItem(employee).subscribe(() => this.loadEmployees());
  }

  save() {
    this.employee.companyId = this.employee.company.id;
    
    if (this.action == Action.Add) {
      this.employeeService.createItem(this.employee).subscribe(() => this.loadEmployees());
    }
    else if (this.action == Action.Edit) {
      this.employeeService.updateItem(this.employee).subscribe(() => this.loadEmployees());
    }
  }
}
