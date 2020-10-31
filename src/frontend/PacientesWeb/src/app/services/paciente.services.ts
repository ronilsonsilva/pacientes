import { Injectable } from "@angular/core";
import { PacienteViewModel } from "../models/paciente.model";
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { BaseService } from './base.service';
import { PacienteRequest } from "../models/request/paciente.request";
import { map } from 'rxjs/operators';
import { Observable } from "rxjs";

@Injectable({ providedIn: 'root' })
export class PacienteService extends BaseService {
  constructor(private http: HttpClient) {
    super();
  }

  public listar(request: PacienteRequest): Observable<PacienteViewModel[]> {
    return this.http.post<PacienteViewModel[]>(`${this.apiUrl()}/Pacientes/Listar`, request).pipe(
      map(funcoes => {
        if (funcoes == null) {
          funcoes = [];
        }
        return funcoes;
      })
    );
  }

  public consultar(id: number): Observable<PacienteViewModel> {
    return this.http.get<PacienteViewModel>(`${this.apiUrl()}/Pacientes/${id}`).pipe(
      map(resultado => {
        return resultado;
      })
    );
  }


  public excluir(id: number): Observable<any> {
    return this.http.delete<any>(`${this.apiUrl()}/Pacientes/${id}`).pipe(
      map(resultado => {
        return resultado;
      })
    );
  }


  public salvar(paciente: PacienteViewModel): Observable<any> {
    if (paciente.id === undefined || paciente.id === null) {
      return this.http.post<any>(`${this.apiUrl()}/Pacientes`, paciente).pipe(
        map(resultado => {
          return resultado;
        })
      );
    } else {
      return this.http.put<any>(`${this.apiUrl()}/Pacientes`, paciente).pipe(
        map(resultado => {
          return resultado;
        })
      );
    }
  }
}
