import { Component, OnInit } from '@angular/core';
import { Action } from '../models/action.model';
import { Company } from '../models/company.model';
import { CompanyService } from '../services/company.service';

@Component({
  selector: 'app-company-list',
  templateUrl: './company-list.component.html',
  styles: [
  ]
})
export class CompanyListComponent implements OnInit {
  companies: Company[] = []
  company: Company = new Company()
  action: Action

  constructor(private dataService: CompanyService) { }

  ngOnInit(): void {
    this.loadCompanies();
  }

  loadCompanies() {
    this.dataService.getItems().subscribe((data: Company[]) => this.companies = data);
  }

  addCompany() {
    this.company = new Company();
    this.action = Action.Add;
  }

  editCompany(company: Company) {
    this.company = company;
    this.action = Action.Edit;
  }

  deleteCompany(company: Company) {
    this.dataService.deleteItem(company).subscribe(() => this.loadCompanies());
  }

  save() {
    if (this.action == Action.Add) {
      this.dataService.createItem(this.company).subscribe(() => this.loadCompanies());
    }
    else if (this.action == Action.Edit) {
      this.dataService.updateItem(this.company).subscribe(() => this.loadCompanies());
    }
  }
}
