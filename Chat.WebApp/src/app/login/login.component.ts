import { Component, inject } from '@angular/core';
import { AuthService } from '../services/auth.service';
import { FormControl, FormGroup } from '@angular/forms';
import { Router } from '@angular/router';

@Component({
	selector: 'app-login',
	templateUrl: './login.component.html',
	styleUrl: './login.component.css'
})

export class LoginComponent {

	router = inject(Router);
	auth = inject(AuthService);

	erro = "";
	carregando = false;
	form = new FormGroup({
		email: new FormControl(""),
		password: new FormControl("")
	})

	constructor() { }

	async onSubmit() {

		if (this.form.controls.email.value === "" || this.form.controls.password.value === "") {
			this.erro = "Preencha todos os campos";
			return;
		}

		this.carregando = true;
		try {
			const token = await this.auth.login(this.form.controls.email.value!, this.form.controls.password.value!)

			document.cookie = `token=${token.tokenType} ${token.accessToken}`;

			this.router.navigateByUrl("");
		} catch (e) {
			this.erro = (e as Error).message;
		} finally {
			this.carregando = false;
		}
	}
}
