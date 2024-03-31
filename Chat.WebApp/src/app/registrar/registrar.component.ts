import { Component, inject } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from '../services/auth.service';
import { FormControl, FormGroup } from '@angular/forms';

@Component({
  selector: 'app-registrar',
  templateUrl: './registrar.component.html',
  styleUrl: './registrar.component.css'
})
export class RegistrarComponent {

	router = inject(Router);
	auth = inject(AuthService);

	erro = "";
	mensagem = "";
	carregando = false;
	form = new FormGroup({
		email: new FormControl(""),
		password: new FormControl(""),
		confirmPassword: new FormControl("")
	})

	constructor() { }

	async onSubmit() {

		if (this.form.controls.email.value === "" || this.form.controls.password.value === "" || this.form.controls.confirmPassword.value === "") {
			this.erro = "Preencha todos os campos";
			return;
		}

		if (this.form.controls.password.value === "" || this.form.controls.confirmPassword.value === "") {
			this.erro = "As senhas são diferentes";
			return;
		}

		this.carregando = true;
		try {
			await this.auth.registrar(this.form.controls.email.value!, this.form.controls.password.value!)

			this.mensagem = "Usuário registrado com sucesso";
		} catch (e) {
			this.erro = (e as Error).message;
		} finally {
			this.carregando = false;
		}
	}
}
