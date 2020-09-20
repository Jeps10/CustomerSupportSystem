import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root',
})
export class TicketService {

    private _baseUrl: string = "https://localhost:5001/api";

    constructor(private http: HttpClient) { }

    getAll() {
        return this.http.get(this._baseUrl + "/tickets");
    }

    get(id: number) {
        return this.http.get(this._baseUrl + "/tickets/" + id);
    }

    create(request: any) {
        return this.http.post(this._baseUrl + "/tickets", request);
    }

    update(request: any) {
        return this.http.put(this._baseUrl + "/tickets/", request);
    }

    delete(id: number) {
        return this.http.delete(this._baseUrl + "/tickets/" + id);
    }

}