import { Injectable } from "@angular/core";
import { HttpClient } from '@angular/common/http';
import { BaseService } from './base.service';
import { map } from 'rxjs/operators';
import { Observable } from "rxjs";
import { TelefoneViewModel } from "../models/telefone.model";
import { TelefoneRequest } from "../models/request/telefone.request";

@Injectable({ providedIn: 'root' })
export class TelefoneService extends BaseService {
  constructor(private http: HttpClient) {
    super();
  }

  public listar(request: TelefoneRequest): Observable<TelefoneViewModel[]> {
    return this.http.post<TelefoneViewModel[]>(`${this.apiUrl()}/Telefone/Listar`, request).pipe(
      map(funcoes => {
        if (funcoes == null) {
          funcoes = [];
        }
        return funcoes;
      })
    );
  }

  public consultar(id: number): Observable<TelefoneViewModel> {
    return this.http.get<TelefoneViewModel>(`${this.apiUrl()}/Telefone/${id}`).pipe(
      map(resultado => {
        return resultado;
      })
    );
  }


  public excluir(id: number): Observable<any> {
    return this.http.delete<any>(`${this.apiUrl()}/Telefone/${id}`).pipe(
      map(resultado => {
        return resultado;
      })
    );
  }


  public salvar(telefone: TelefoneViewModel): Observable<any> {
    if (telefone.id === undefined || telefone.id === null) {
      return this.http.post<any>(`${this.apiUrl()}/Telefone`, telefone).pipe(
        map(resultado => {
          return resultado;
        })
      );
    } else {
      return this.http.put<any>(`${this.apiUrl()}/Telefone`, telefone).pipe(
        map(resultado => {
          return resultado;
        })
      );
    }
  }
}
