// ======================================
// Author: Monty Edwards
// Email:  montyedwards@southfloridacoder.com
// Copyright (c) 2017 www.southfloridacoder.com
// 
// ==> Gun4Hire: montyedwards@southfloridacoder.com
// ======================================

export class Customer {
    // Note: Using only optional constructor properties without backing store disables typescript's type checking for the type
    constructor(id?: number, name?: string, businessName?: string, email?: string, customerType?: string, phone?: string, description?:string) {

        this.id = id;
        this.name = name;
        this.businessName = businessName;
        this.email = email;
        this.customerType = customerType;
        this.phone = phone;
        this.description = description;
        
    }


    get friendlyName(): string {
        let name = this.businessName || this.name;

        if (this.customerType)
            name = this.customerType + " " + name;

        return name;
    }


    public id: number;
    public name: string;
    public businessName: string;
    public email: string;
    public customerType: string;
    public phone: string;
    public description: string;
    
    
}