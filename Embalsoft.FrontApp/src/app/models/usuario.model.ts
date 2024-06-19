import { Grupo } from "./grupo.model";

export interface Usuario {
  id: number;
  nome: string;
  senha: string;
  cpf: string;
  grupo: Grupo;
  dataCadastro: Date;
  dataAlterado: Date;
}
