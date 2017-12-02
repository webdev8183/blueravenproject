// ======================================
// Author: Monty Edwards
// Email:  montyedwards@southfloridacoder.com
// Copyright (c) 2017 www.southfloridacoder.com
// 
// ==> Gun4Hire: montyedwards@southfloridacoder.com
// ======================================

import { Utilities } from "../services/utilities";


export class Notification {

    public static Create(data: {}) {
        let n = new Notification();
        Object.assign(n, data);

        if (n.date)
            n.date = Utilities.parseDate(n.date);

        return n;
    }


    public id: number;
    public header: string;
    public body: string;
    public isRead: boolean;
    public isPinned: boolean;
    public date: Date;
}