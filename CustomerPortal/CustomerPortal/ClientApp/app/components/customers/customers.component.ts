// ======================================
// Author: Monty Edwards
// Email:  montyedwards@southfloridacoder.com
// Copyright (c) 2017 www.southfloridacoder.com
// 
// ==> Gun4Hire: montyedwards@southfloridacoder.com
// ======================================

import { Component, OnInit, OnDestroy, ViewChild } from '@angular/core';
import { CustomerService } from '../../services/customer-service';
import { fadeInOut } from '../../services/animations';
//import { ICustomer } from '../customers/customer';
//import { CustomerEditorComponent } from '../controls/customer-editor.component';




@Component({
    selector: 'customers',
    templateUrl: './customers.component.html',
    styleUrls: ['./customers.component.css'],
    animations: [fadeInOut]
})
export class CustomersComponent implements OnInit, OnDestroy {
    //name: (any)
    errorMessage: string;
   // pageTitle: string = "Customer List";
    //constructor(private _customerService: CustomerService) { }
    //customers:any
    ngOnInit() {
        //this.customers()
        //.subscribe(customers => this.customers = customers,
        //    error => this.errorMessage = <any>error);
        
    }
    ngOnDestroy() {
      
    }
}

