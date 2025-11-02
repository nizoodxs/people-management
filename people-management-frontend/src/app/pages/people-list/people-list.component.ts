import { Component, OnInit } from "@angular/core";
import { Person } from "../../models/person";
import { PeopleService } from "../../services/people.service";
import { Router } from "@angular/router";
import { DatePipe } from "@angular/common";

@Component({
    selector: 'app-people-list',
    templateUrl: './people-list.component.html',
    imports: [DatePipe]
})
export class PeopleListComponent implements OnInit {
    people: Person[] = [];
    selectedPerson?: Person;

    constructor(private peopleService: PeopleService, private router: Router) {
    }

    ngOnInit(): void {
        this.loadPeople();
    }

    loadPeople() {
        this.peopleService.getAll().subscribe(result => this.people = result);
    }

    addPerson() { this.router.navigate(['/people/add']); }
    editPerson(id: string) { 
        this.router.navigate([`/people/edit/${id}`],);
     }
    confirmDelete(person: Person) { this.selectedPerson = person; }
    deletePerson() {
        if (!this.selectedPerson) return;
        this.peopleService.delete(this.selectedPerson.personId!).subscribe(() => this.loadPeople());
    }

}