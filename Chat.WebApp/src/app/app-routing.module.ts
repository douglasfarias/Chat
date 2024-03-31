import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './login/login.component';
import { ConversasComponent } from './conversas/conversas.component';
import { canActivate } from './app-guard.guard';
import { RegistrarComponent } from './registrar/registrar.component';

const routes: Routes = [
	{ path: "", component: ConversasComponent, canActivate: [canActivate] },
	{ path: "login", component: LoginComponent, },
	{ path: "registrar", component: RegistrarComponent, },
];

@NgModule({
	imports: [RouterModule.forRoot(routes)],
	exports: [RouterModule]
})
export class AppRoutingModule { }
