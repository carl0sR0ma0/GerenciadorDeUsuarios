import { Component } from '@angular/core';
import { AutenticarService } from '../../services/autenticar.service';

import { Router } from '@angular/router';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent {

  constructor(public autenticar: AutenticarService, private router: Router) { }

  logout(): void {
    this.autenticar.logout();
  }
}
