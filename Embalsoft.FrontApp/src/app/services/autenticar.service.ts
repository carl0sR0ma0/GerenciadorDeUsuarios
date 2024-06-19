import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { jwtDecode } from 'jwt-decode';
import { tap } from 'rxjs';
import { environment } from 'src/environment/environment';

@Injectable({
  providedIn: 'root'
})
export class AutenticarService {
  private isAdmin = false;
  private apiUrl = `${environment.mainUrlAPI}Usuario`
  private tokenKey = 'auth_token';

  constructor(
    private http: HttpClient
  ) { }

  login(Nome: string, Senha: string) {
    return this.http.post<any>(`${this.apiUrl}/login`, { Nome, Senha })
      .pipe(
        tap(response => {
          if (response && response.token) {
            this.storeToken(response.token);
          }
        })
      );
  }

  private storeToken(token: string) {
    localStorage.setItem(this.tokenKey, token);
  }

  getToken(): string | null {
    return localStorage.getItem(this.tokenKey);
  }

  logout() {
    localStorage.removeItem(this.tokenKey);
  }

  isLoggedIn(): boolean {
    return !!this.getToken();
  }

  isAdministrator(): boolean {
    const decodedToken = this.getDecodedToken();
    return decodedToken["role"] === "Administrador";
  }

  getDecodedToken(): any {
    const token = this.getToken();
    if (token) {
      try {
        return jwtDecode(token);
      } catch (Error) {
        console.error('Erro ao decodificar o token JWT:', Error);
        return null;
      }
    }
    return null;
  }
}
