import { Component, inject } from '@angular/core';
import { ConversasService } from '../services/conversas.service';
import { Conversa } from '../models/conversa';

@Component({
	selector: 'app-conversas',
	templateUrl: './conversas.component.html',
	styleUrl: './conversas.component.css'
})
export class ConversasComponent {

	conversas = inject(ConversasService);

	selecionado: string | undefined;
	model: Conversa[] | undefined;
	carregando = true;

	constructor() { }

	async ngOnInit() {
		try {
			this.model = await this.conversas.getConversas();
		} finally {
			this.carregando = false;
		}
	}
}
