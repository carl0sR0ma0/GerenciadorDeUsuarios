import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { UsuarioService } from '../../services/usuario.service';
import { Usuario } from '../../models/usuario.model';
import { CriarUsuario } from '../../models/criar.usuario.model';
import { EditarUsuario } from '../../models/editar.usuario.model';
import { GrupoService } from '../../services/grupo.service';
import { Grupo } from '../../models/grupo.model';

@Component({
  selector: 'app-criar-usuario',
  templateUrl: './criar-usuario.component.html',
  styleUrls: ['./criar-usuario.component.css']
})
export class CriarUsuarioComponent implements OnInit {
  usuario: CriarUsuario = {} as CriarUsuario;
  editarUsuario: EditarUsuario = {} as EditarUsuario;
  usuarioRes: Usuario = {} as Usuario;
  grupos: Grupo[] = [];
  estaModoEdicao: boolean = false;

  constructor(
    private usuarioService: UsuarioService,
    private grupoService: GrupoService,
    private route: ActivatedRoute,
    private router: Router
  ) { }

  ngOnInit() {
    this.grupoService.obterGrupos().subscribe(data => {
      this.grupos = data;
    });

    const id = this.route.snapshot.paramMap.get('id');
    if (id) {
      this.estaModoEdicao = true;
      this.usuarioService.obterUsuario(+id).subscribe(data => {
        this.usuarioRes = data;
        this.usuario.nome = this.usuarioRes.nome
        this.usuario.cpf = this.usuarioRes.cpf
        this.usuario.grupoId = this.usuarioRes.grupo.id
        this.usuario.senha = this.usuarioRes.senha
      });
    }
  }

  salvarUsuario(): void {
    if (this.estaModoEdicao) {
      this.editarUsuario.id = this.usuarioRes.id;
      this.editarUsuario.nome = this.usuario.nome
      this.editarUsuario.cpf = this.usuario.cpf
      this.editarUsuario.grupoId = this.usuario.grupoId
      this.editarUsuario.senha = this.usuario.senha

      this.usuarioService.alterarUsuario(this.editarUsuario).subscribe(() => {
        this.router.navigate(['/usuarios']);
      });
    } else {
      this.usuarioService.criarUsuario(this.usuario).subscribe(() => {
        this.router.navigate(['/usuarios']);
      });
    }
  }
}
