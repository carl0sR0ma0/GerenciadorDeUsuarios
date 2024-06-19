import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { GrupoService } from '../../services/grupo.service';
import { Grupo } from '../../models/grupo.model';

@Component({
  selector: 'app-salvar-grupo',
  templateUrl: './salvar-grupo.component.html',
  styleUrls: ['./salvar-grupo.component.css']
})
export class SalvarGrupoComponent implements OnInit {
  grupo: Grupo = {} as Grupo;
  estaModoEdicao: boolean = false;

  constructor(
    private grupoService: GrupoService,
    private route: ActivatedRoute,
    private router: Router
  ) { }

  ngOnInit() {
    const id = this.route.snapshot.paramMap.get('id');
    if (id) {
      this.estaModoEdicao = true;
      this.grupoService.obterGrupo(+id).subscribe(data => {
        this.grupo = data;
      });
    }
  }

  salvarGrupo(): void {
    if (this.estaModoEdicao) {
      this.grupoService.alterarGrupo(this.grupo).subscribe(() => {
        this.router.navigate(['/grupos']);
      });
    } else {
      this.grupoService.criarGrupo(this.grupo).subscribe(() => {
        this.router.navigate(['/grupos']);
      });
    }
  }
}
