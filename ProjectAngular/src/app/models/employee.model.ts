import { IModel } from "./interfaces/IModel"
import { Company } from "./company.model"

export class Employee implements IModel {
    id: number = 0
    company: Company = new Company()
    companyId: number = 0
    position: string = ""
    f: string = ""
    i: string = ""
    o: string = ""
    employmentDate: Date = new Date()
}
