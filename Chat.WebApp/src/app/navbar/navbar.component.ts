import { Component, inject } from '@angular/core';
import { AuthService } from '../services/auth.service';
import { Router } from '@angular/router';

@Component({
	selector: 'app-navbar',
	templateUrl: './navbar.component.html',
	styleUrl: './navbar.component.css'
})
export class NavbarComponent {

	router = inject(Router);
	auth = inject(AuthService);

	constructor() { }

	logout() {
		this.auth.logout();
		this.router.navigateByUrl("login");
	}
}
