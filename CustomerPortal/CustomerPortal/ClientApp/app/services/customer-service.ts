import { Injectable } from '@angular/core';
import { Response } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/map';

import { AuthService } from './auth.service';
import { CustomerEndpoint } from './customer-endpoint.service';
import { Customer } from '../models/customer.model';



@Injectable()
export class CustomerService {

    constructor(private customerEndpoint: CustomerEndpoint, private authService: AuthService) {

    }


    getCustomer(customerId: number) {

        return this.customerEndpoint.getCustomerEndpoint(customerId)
            .map((response: Response) => <Customer>response.json());
    }

    getCustomers(page?: number, pageSize?: number) {

        return this.customerEndpoint.getcustomersEndpoint(page, pageSize)
            .map((response: Response) => <Customer[]>response.json());
    }


    newCustomer(customer: Customer) {
        return this.customerEndpoint.getNewCustomerEndpoint(customer)
            .map((response: Response) => <Customer>response.json());
    }

    updateCustomer(customer: Customer) {
        return this.customerEndpoint.getUpdateCustomerEndpoint(customer, customer.id);
    }



    deleteCustomer(customerId: number | Customer): Observable<Customer> {

        if (typeof customerId === 'number' || customerId instanceof Number) { //Todo: Test me if its check is valid
            return this.customerEndpoint.getDeleteCustomerEndpoint(<number>customerId)
                .map((response: Response) => <Customer>response.json());
        }
        else {
            return this.deleteCustomer(customerId.id);
        }
    }



    get currentUser() {
        return this.authService.currentUser;
    }
}