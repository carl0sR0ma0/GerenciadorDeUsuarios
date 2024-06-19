import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { AutenticarService } from '../../services/autenticar.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {
  public nome: string = '';
  public senha: string = '';
  loginError: boolean = false;

  constructor(private autenticarService: AutenticarService, private router: Router) { }

  login(): void {
    this.autenticarService.login(this.nome, this.senha).subscribe(
      () => {
        this.router.navigate(['/usuarios']);
      },
      error => {
        console.error('Erro durante o login:', error);
        this.loginError = true;
      }
    );
  }
}
