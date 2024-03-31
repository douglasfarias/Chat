import { Injectable, inject } from '@angular/core';
import { environment } from '../environments/environment';
import { Conversa } from '../models/conversa';
import { AuthService } from './auth.service';

@Injectable({
	providedIn: 'root'
})
export class ConversasService {

	url = environment.apiUrl + '/api/conversas';

	authService = inject(AuthService);

	async getConversas(): Promise<Conversa[]> {
		const data = await fetch(this.url, {
			headers: {
				'Authorization': this.authService.getToken()
			}
		});

		return (await data.json()) ?? [];
	}

	async getConversa(id: string): Promise<Conversa> {
		const data = await fetch(this.url + `/${id}`, {
			headers: {
				'Authorization': this.authService.getToken()
			}
		});

		return (await data.json());
	}

}
