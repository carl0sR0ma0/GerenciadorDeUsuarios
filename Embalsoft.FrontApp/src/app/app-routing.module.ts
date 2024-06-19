import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ListagemUsuarioComponent } from './components/listagem-usuario/listagem-usuario.component';
import { CriarUsuarioComponent } from './components/criar-usuario/criar-usuario.component';
import { ListagemGrupoComponent } from './components/listagem-grupo/listagem-grupo.component';
import { SalvarGrupoComponent } from './components/salvar-grupo/salvar-grupo.component';
import { AuthGuard } from './services/auth.guard';
import { LoginComponent } from './components/login/login.component';

const routes: Routes = [
  { path: '', redirectTo: '/usuarios', pathMatch: 'full' },
  { path: 'login', component: LoginComponent },
  { path: 'usuarios', component: ListagemUsuarioComponent, canActivate: [AuthGuard] },
  { path: 'usuarios/novo', component: CriarUsuarioComponent, canActivate: [AuthGuard], data: { roles: ['admin'] } },
  { path: 'usuarios/editar/:id', component: CriarUsuarioComponent, canActivate: [AuthGuard], data: { roles: ['admin'] } },
  { path: 'grupos', component: ListagemGrupoComponent, canActivate: [AuthGuard] },
  { path: 'grupos/novo', component: SalvarGrupoComponent, canActivate: [AuthGuard], data: { roles: ['admin'] } },
  { path: 'grupos/editar/:id', component: SalvarGrupoComponent, canActivate: [AuthGuard], data: { roles: ['admin'] } },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
