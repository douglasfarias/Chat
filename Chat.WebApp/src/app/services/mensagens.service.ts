import { Injectable, inject } from '@angular/core';
import { environment } from '../environments/environment';
import { AuthService } from './auth.service';
import { Mensagem } from '../models/mensagem';

@Injectable({
  providedIn: 'root'
})
export class MensagensService {

	constructor() { }

	url = environment.apiUrl + '/api/mensagens';

	authService = inject(AuthService);

	async getMensagensByConversaId(id: string): Promise<Mensagem[]> {
		const data = await fetch(this.url + `/conversa/${id}`, {
			headers: {
				'Authorization': this.authService.getToken()
			}
		});

		return (await data.json()) ?? [];
	}

}
