import { HttpClient } from '@angular/common/http';
import { Injectable, inject } from '@angular/core';
import { environment } from '../../../assets/environments';
import { Observable, take } from 'rxjs';
import { Comentario } from '../../shared/models/interfaces/comentario';

@Injectable({
  providedIn: 'root',
})
export class ComentarioService {
  #http = inject(HttpClient);

  baseURL = `${environment.apiURL}Comentarios/`;

  public getComentariosByAcervoId(acervoId: number): Observable<Comentario[]> {
    return this.#http
      .get<Comentario[]>(`${this.baseURL}${acervoId}/todoscomentarios`)
      .pipe(take(3));
  }

  public getComentariosById(comentarioId: number): Observable<Comentario> {
    return this.#http
      .get<Comentario>(`${this.baseURL}/${comentarioId}`)
      .pipe(take(3));
  }

  public createComentario(comentario: Comentario): Observable<Comentario> {
    return this.#http.post<Comentario>(this.baseURL, comentario).pipe(take(3));
  }
}
