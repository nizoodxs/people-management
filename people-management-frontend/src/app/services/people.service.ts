import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { Person } from "../models/person";

@Injectable({
    providedIn: "root"
})
export class PeopleService {
    private apiURL = 'https://localhost:7038/api/person';

    constructor(private http: HttpClient) { }

    getAll(): Observable<Person[]> {
        return this.http.get<Person[]>(this.apiURL);
    }

    getById(id: string): Observable<Person> {
        return this.http.get<Person>(`${this.apiURL}/${id}`);
    }

    create(person: Person): Observable<void> {
        return this.http.post<void>(this.apiURL, person);
    }

    update(id: string, person: Person): Observable<void> {
        return this.http.put<void>(`${this.apiURL}/${id}`, person);
    }

    delete(id: string): Observable<void> {
        return this.http.delete<void>(`${this.apiURL}/${id}`);
    }
}