import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root',
})
export class PriorityService {

    private _baseUrl: string = "https://localhost:5001/api";

    constructor(private http: HttpClient) { }

    getAll() {
        return this.http.get(this._baseUrl + "/priorities");
    }

}