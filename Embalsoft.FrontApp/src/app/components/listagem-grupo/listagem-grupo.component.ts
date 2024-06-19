import { Component, OnInit } from '@angular/core';
import { GrupoService } from '../../services/grupo.service';
import { Grupo } from '../../models/grupo.model';
import { AutenticarService } from "../../services/autenticar.service";

@Component({
  selector: 'app-listagem-grupo',
  templateUrl: './listagem-grupo.component.html',
  styleUrls: ['./listagem-grupo.component.css']
})
export class ListagemGrupoComponent implements OnInit {
  grupos: Grupo[] = [];

  constructor(private grupoService: GrupoService, public autenticarService: AutenticarService) { }

  ngOnInit() {
    this.grupoService.obterGrupos().subscribe(data => {
      this.grupos = data;
    });
  }

  deletarGrupo(id: number): void {
    this.grupoService.deletarGrupo(id).subscribe(() => {
      this.grupos = this.grupos.filter(grupo => grupo.id !== id);
    });
  }
}
