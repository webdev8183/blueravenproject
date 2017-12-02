// ======================================
// Author: Monty Edwards
// Email:  montyedwards@southfloridacoder.com
// Copyright (c) 2017 www.southfloridacoder.com
// 
// ==> Gun4Hire: montyedwards@southfloridacoder.com
// ======================================

import { Customer } from './customer.model';


export class UserEdit extends Customer {
    constructor(currentName?: string, newBusinessName?: string, confirmBusiness?: string, currentDescription?:string) {
        super();

        this.currentName = currentName;
        this.newBusinessName = newBusinessName;
        this.confirmBusiness = confirmBusiness;
        this.currentDescription = currentDescription;
    }

    public currentName: string;
    public newBusinessName: string;
    public confirmBusiness: string;
    public currentDescription: string;

}