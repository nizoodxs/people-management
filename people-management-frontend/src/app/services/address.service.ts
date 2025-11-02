import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { Address } from "../models/address";

@Injectable({
    providedIn: "root"
})
export class AddressService {
    private apiURL = 'https://localhost:7038/api/address';

    constructor(private http: HttpClient) { }

    getForPerson(personId:string): Observable<Address[]> {
        return this.http.get<Address[]>(`${this.apiURL}/for-person/${personId}`);
    }

    getById(id: string): Observable<Address> {
        return this.http.get<Address>(`${this.apiURL}/${id}`);
    }

    create(personId:string, address:Address): Observable<void> {
        return this.http.post<void>(this.apiURL,{personId, address});
    }

    update(id: string, address: Address): Observable<void> {
        return this.http.put<void>(`${this.apiURL}/${id}`, address);
    }

    delete(id: string): Observable<void> {
        return this.http.delete<void>(`${this.apiURL}/${id}`);
    }
}