import { Component, EventEmitter, Input, Output, SimpleChanges, inject } from '@angular/core';
import { Conversa } from '../models/conversa';
import { ConversasService } from '../services/conversas.service';
import { MensagensService } from '../services/mensagens.service';
import { FormControl, FormGroup } from '@angular/forms';

@Component({
	selector: 'app-conversa',
	templateUrl: './conversa.component.html',
	styleUrl: './conversa.component.css'
})
export class ConversaComponent {
	@Input({ alias: 'conversa-id', required: true })
	conversaId!: string | undefined;

	@Output()
	onClose = new EventEmitter();

	conversas = inject(ConversasService);
	mensagens = inject(MensagensService);
	usuarioId = 'e149ef1e-c7dc-4696-90f0-43c7e44f0cea';
	model: Conversa | undefined;
	carregando = true;
	form = new FormGroup({
		mensagem: new FormControl("")
	})

	constructor() { }

	async ngOnChanges(changes: SimpleChanges) {
		this.model = undefined;
		if (changes['conversaId'].currentValue !== undefined) {
			try {
				this.model = await this.conversas.getConversa(this.conversaId!);
				this.model.mensagens = await this.mensagens.getMensagensByConversaId(this.conversaId!);
			} finally {
				this.carregando = false;
			}
		}
	}

	onSubmit() {
		if (this.form.controls.mensagem.value === "") {
			return;
		}
		
		//this.mensagens.enviarMensagem(this.conversaId!, this.usuarioId, this.form.controls.mensagem.value);
		this.form.controls.mensagem.setValue("");
	}

	close() {
		this.onClose.emit();
	}

}
