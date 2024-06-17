import { Acervo } from "../acervo";
import { Usuario } from "../usuario";

export interface Comentario {
  id: number;
  acervoId: number;
  userName: string;
  comentarioTxt: string;
  avaliacao: number;
  acervo: Acervo;
  usuario: Usuario;
  userId: number;
  usuarioId:number;
}
