import { Routes } from '@angular/router';
import { PeopleListComponent } from './pages/people-list/people-list.component';
import { PeopleFormComponent } from './pages/people-form/people-form.component';

export const routes: Routes = [
    { path: '', redirectTo: 'people', pathMatch: 'full' },
    { path: 'people', component: PeopleListComponent },
    { path: 'people/add', component: PeopleFormComponent },
    { path: 'people/edit/:id', component: PeopleFormComponent }
];
