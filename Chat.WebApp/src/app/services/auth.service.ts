import { Injectable } from '@angular/core';
import { environment } from '../environments/environment';
import { AuthToken } from '../models/auth-token';
import { getCookie } from '../helpers/cookie-helper';

@Injectable({
	providedIn: 'root'
})
export class AuthService {

	url = environment.apiUrl;

	isAuthenticaded(): boolean {
		return getCookie('token') !== "";
	}

	getToken(): string {
		return getCookie('token');
	}

	logout() {
		document.cookie = "token=";
	}

	async login(email: string, password: string): Promise<AuthToken> {
		const data = await fetch(this.url + '/login', {
			method: 'POST',
			headers: {
				'Content-Type': 'application/json'
			},
			body: JSON.stringify({ email, password })
		});

		if (data.status !== 200) {
			throw new Error(data.statusText)
		}

		return (await data.json());
	}

	async registrar(email: string, password: string): Promise<void> {
		const data = await fetch(this.url + '/register', {
			method: 'POST',
			headers: {
				'Content-Type': 'application/json'
			},
			body: JSON.stringify({ email, password })
		});

		if (data.status !== 200) {
			throw new Error(data.statusText)
		}
	}
}
