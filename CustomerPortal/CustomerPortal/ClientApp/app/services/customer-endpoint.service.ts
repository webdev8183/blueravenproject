import { Injectable, Injector } from '@angular/core';
import { Http, Response } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/map';

import { EndpointFactory } from './endpoint-factory.service';
import { ConfigurationService } from './configuration.service';


@Injectable()
export class CustomerEndpoint extends EndpointFactory {

    private readonly _customersUrl: string = "/api/customers/list";

    get customersUrl() { return  this._customersUrl; }



    constructor(http: Http, configurations: ConfigurationService, injector: Injector) {

        super(http, configurations, injector);
    }



    getCustomerEndpoint(customerId: number): Observable<Response> {
        let endpointUrl = `${this.customersUrl}/${customerId}`;

        return this.http.get(endpointUrl, this.getAuthHeader())
            .map((response: Response) => {
                return response;
            })
            .catch(error => {
                return this.handleError(error, () => this.getCustomerEndpoint(customerId));
            });
    }



    getcustomersEndpoint(page?: number, pageSize?: number): Observable<Response> {
        let endpointUrl = page && pageSize ? `${this.customersUrl}/${page}/${pageSize}` : this.customersUrl;

        return this.http.get(endpointUrl, this.getAuthHeader())
            .map((response: Response) => {
                return response;
            })
            .catch(error => {
                return this.handleError(error, () => this.getcustomersEndpoint(page, pageSize));
            });
    }



    getNewCustomerEndpoint(customerObject: any): Observable<Response> {

        return this.http.post(this.customersUrl, JSON.stringify(customerObject), this.getAuthHeader(true))
            .map((response: Response) => {
                return response;
            })
            .catch(error => {
                return this.handleError(error, () => this.getNewCustomerEndpoint(customerObject));
            });
    }


    getUpdateCustomerEndpoint(customerObject: any, customerId: number): Observable<Response> {
        let endpointUrl = `${this.customersUrl}/${customerId}`;

        return this.http.put(endpointUrl, JSON.stringify(customerObject), this.getAuthHeader(true))
            .map((response: Response) => {
                return response;
            })
            .catch(error => {
                return this.handleError(error, () => this.getUpdateCustomerEndpoint(customerObject, customerId));
            });
    }



    getDeleteCustomerEndpoint(customerId: number): Observable<Response> {
        let endpointUrl = `${this.customersUrl}/${customerId}`;

        return this.http.delete(endpointUrl, this.getAuthHeader(true))
            .map((response: Response) => {
                return response;
            })
            .catch(error => {
                return this.handleError(error, () => this.getDeleteCustomerEndpoint(customerId));
            });
    }

}