// ======================================
// Author: Monty Edwards
// Email:  montyedwards@southfloridacoder.com
// Copyright (c) 2017 www.southfloridacoder.com
// 
// ==> Gun4Hire: montyedwards@southfloridacoder.com
// ======================================

import { User } from './user.model';


export class UserEdit extends User {
    constructor(currentPassword?: string, newPassword?: string, confirmPassword?: string) {
        super();

        this.currentPassword = currentPassword;
        this.newPassword = newPassword;
        this.confirmPassword = confirmPassword
    }

    public currentPassword: string;
    public newPassword: string;
    public confirmPassword: string;

}