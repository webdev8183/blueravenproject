// ======================================
// Author: Monty Edwards
// Email:  montyedwards@southfloridacoder.com
// Copyright (c) 2017 www.southfloridacoder.com
 
// ==> Gun4Hire: montyedwards@southfloridacoder.com
// ======================================

import { Component,OnInit } from '@angular/core';
import { fadeInOut } from '../../services/animations';
import { Product } from '../products/Product';
import { ActivatedRoute } from '@angular/router';
@Component({
    selector: 'products',
    templateUrl: './products.component.html',
    styleUrls: ['./products.component.css'],
    animations: [fadeInOut]
})
export class ProductsComponent implements OnInit {
    products: Product[] = [];
    constructor(private _route: ActivatedRoute) { }
    ngOnInit(): void {
        
        

    }
}