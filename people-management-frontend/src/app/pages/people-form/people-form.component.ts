import { Component, OnInit } from "@angular/core";
import { Person } from "../../models/person";
import { PeopleService } from "../../services/people.service";
import { ActivatedRoute, Router } from "@angular/router";
import { FormsModule } from "@angular/forms";
import { Address } from "../../models/address";
import { AddressService } from "../../services/address.service";

@Component({
    selector: 'app-people-form',
    templateUrl: './people-form.component.html',
    imports: [FormsModule]
})
export class PeopleFormComponent implements OnInit {
    person: Person = {
        name: '',
        dateOfBirth: new Date(),
        addresses: []
    };
    isEdit = false;

    //for new address
    newAddress: Address = {
        addressLine1: '',
        addressLine2: '',
        town: '',
        postCode: '',
        country: ''
    };

    constructor(
        private peopleService: PeopleService,
        private addressService: AddressService,
        private route: ActivatedRoute,
        private router: Router
    ) { }

    ngOnInit(): void {
        const personId = this.route.snapshot.paramMap.get('id');

        if (personId) {
            this.isEdit = true;
            this.peopleService.getById(personId).subscribe(result => {
                this.person = result;

                this.addressService.getForPerson(personId).subscribe(result => this.person.addresses = result);
            });
        }
    }

    save() {
        if (this.isEdit) {
            this.peopleService.update(this.person.personId!, this.person).subscribe(() => this.router.navigate(['/people']));
        } else {
            this.peopleService.create(this.person).subscribe(() => this.router.navigate(['/people']));
        }
    }
    cancel() {
        this.router.navigate(['/people']);
    }

    addAddress() {
        if (!this.person.personId) return;

        const addressCopy = structuredClone(this.newAddress);
        this.addressService.create(this.person.personId, this.newAddress).subscribe(address => this.person.addresses?.push(addressCopy));

        this.newAddress = {
            addressLine1: '',
            addressLine2: '',
            town: '',
            postCode: '',
            country: ''
        };
    }

    deleteAddress(addressId: string) {
        this.addressService.delete(addressId).subscribe(() => {
            this.person.addresses = this.person.addresses?.filter(a => a.addressId !== addressId);
        });
    }

    editAddress(addressId: string) {

    }
    updateAddress(addressId: string) {
        this.addressService.update(addressId, this.newAddress).subscribe(result => {
            this.person.addresses = this.person.addresses?.map(a =>
                a.addressId === addressId ? this.newAddress : a
            );
        });
    }
}