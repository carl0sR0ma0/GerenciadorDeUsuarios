import { Injectable } from '@angular/core';
import { CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot, UrlTree, Router } from '@angular/router';
import { Observable } from 'rxjs';
import { AutenticarService } from './autenticar.service';

@Injectable({
  providedIn: 'root'
})
export class AuthGuard implements CanActivate {

  constructor(private autenticarService: AutenticarService, private router: Router) { }

  canActivate(
    route: ActivatedRouteSnapshot,
    state: RouterStateSnapshot): boolean {
    if (this.autenticarService.isLoggedIn()) {
      if (route.data['roles'] && route.data['roles'].indexOf('admin') !== -1) {
        return this.autenticarService.isAdministrator();
      }
      return true;
    }
    this.router.navigate(['/login']);
    return false;
  }
}
