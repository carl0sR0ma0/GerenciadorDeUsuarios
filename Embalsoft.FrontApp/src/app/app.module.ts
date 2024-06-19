import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HTTP_INTERCEPTORS, HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';

import { HeaderComponent } from './components/header/header.component'

import { LoginComponent } from './components/login/login.component'

import { ListagemUsuarioComponent } from './components/listagem-usuario/listagem-usuario.component';
import { CriarUsuarioComponent } from './components/criar-usuario/criar-usuario.component';
import { ListagemGrupoComponent } from './components/listagem-grupo/listagem-grupo.component';
import { SalvarGrupoComponent } from './components/salvar-grupo/salvar-grupo.component';

import { AutenticarService } from "./services/autenticar.service";
import { AuthInterceptor } from './services/http-interceptor.service';

@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
    LoginComponent,
    ListagemUsuarioComponent,
    CriarUsuarioComponent,
    ListagemGrupoComponent,
    SalvarGrupoComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule
  ],
  providers: [
    AutenticarService,
    { provide: HTTP_INTERCEPTORS, useClass: AuthInterceptor, multi: true }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
