import { Component, signal } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { Header } from "./shared/header/header";

@Component({
  selector: 'app-root',
  imports: [RouterOutlet, Header],
  template: `
    <app-header></app-header>
    <router-outlet />
  `,
  styles: [],
})
export class App {
  protected readonly title = signal('people-management-frontend');
}
