import { Component, OnInit } from '@angular/core';
import { UsuarioService } from '../../services/usuario.service';
import { Usuario } from '../../models/usuario.model';
import { AutenticarService } from "../../services/autenticar.service";

@Component({
  selector: 'app-listagem-usuario',
  templateUrl: './listagem-usuario.component.html',
  styleUrls: ['./listagem-usuario.component.css']
})
export class ListagemUsuarioComponent implements OnInit {
  usuarios: Usuario[] = [];

  constructor(private usuarioService: UsuarioService, public autenticarService: AutenticarService) { }

  ngOnInit() {
    this.usuarioService.obterUsuarios().subscribe(data => {
      this.usuarios = data;
    });
  }

  deletarUsuario(id: number): void {
    this.usuarioService.deletarUsuario(id).subscribe(() => {
      this.usuarios = this.usuarios.filter(usuario => usuario.id !== id);
    });
  }

}
