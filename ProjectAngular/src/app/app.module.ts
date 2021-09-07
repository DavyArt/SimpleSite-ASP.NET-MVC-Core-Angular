import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';
import { RouterModule, Routes } from '@angular/router';
import { HttpClientModule } from '@angular/common/http';

import { AppComponent } from './app.component';
import { CompanyListComponent } from './company-list/company-list.component';
import { EmployeeListComponent } from './employee-list/employee-list.component';
import { CompanyService } from './services/company.service';
import { EmployeeService } from './services/employee.service';

const appRoutes: Routes = [
  { path: 'employee', component: EmployeeListComponent },
  { path: 'company', component: CompanyListComponent },
  { path: '*', redirectTo: 'employee', pathMatch: 'full' },
  { path: '', redirectTo: 'employee', pathMatch: 'full' }
]
@NgModule({
  declarations: [
    AppComponent,
    EmployeeListComponent,
    CompanyListComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpClientModule,
    RouterModule.forRoot(appRoutes)
  ],
  providers: [
    CompanyService,
    EmployeeService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
