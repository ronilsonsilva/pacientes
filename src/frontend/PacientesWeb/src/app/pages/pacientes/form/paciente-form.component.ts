import { AfterViewInit, Component, OnInit } from "@angular/core";
import { FormControl, FormGroup } from '@angular/forms';
import { PacienteService } from "../../../services/paciente.services";
import { PacienteViewModel } from '../../../models/paciente.model';
import { MatSnackBar } from '@angular/material/snack-bar';
import { ActivatedRoute, Route, Router } from '@angular/router';

@Component({
  selector: 'app-pacientes-form',
  templateUrl: './paciente-form.component.html',
  styleUrls: ['./paciente-form.component.scss']
})
export class PacienteFormComponent implements OnInit, AfterViewInit {
  public titulo = 'Novo Paciente';
  public form: FormGroup;
  public submittted = false;
  public id: number;

  constructor(
    private _pacienteService: PacienteService,
    private _snackBar: MatSnackBar,
    private _activedRoute: ActivatedRoute,
    private _route: Router
  ) {

  }
  ngAfterViewInit(): void {

  }
  ngOnInit(): void {
    this.criarFormulario(new PacienteViewModel());
    let id = this._activedRoute.snapshot.paramMap.get('id');
    if (id !== 'novo' && id !== null && id !== undefined) {
      this.id = parseInt(id);
      this.carregarPaciente(this.id);
      this.titulo = 'Editar Paciente';
    }
  }

  private criarFormulario(model: PacienteViewModel) {
    if (this.form) {
      this.form = undefined;
    }

    this.form = new FormGroup({
      id: new FormControl(model.id),
      bairro: new FormControl(model.bairro),
      cep: new FormControl(model.cep),
      cidade: new FormControl(model.cidade),
      cns: new FormControl(model.cns),
      cpf: new FormControl(model.cpf),
      dataNascimento: new FormControl(model.dataNascimento),
      endereco: new FormControl(model.endereco),
      estado: new FormControl(model.estado),
      nome: new FormControl(model.nome),
      nomeMae: new FormControl(model.nomeMae),
      rg: new FormControl(model.rg),
      sexo: new FormControl(model.sexo),
    });
  }

  public salvar(){
    let paciente = this.form.value;
    paciente.sexo = parseInt(paciente.sexo);
    this._pacienteService.salvar(paciente).subscribe(retorno => {
      if(retorno.ok){
        this._snackBar.open('Paciente Salvo!', '', {
          duration: 3000,
        });
        this._route.navigate(['/', retorno.entity.id]);
      }else{
        this._snackBar.open('Erro ao salvar paciente!', '', {
          duration: 3000,
        });
      }
    }, error => {
      console.log(error);
      this._snackBar.open('Erro ao salvar paciente!', '', {
        duration: 3000,
      });
    });
  }

  public carregarPaciente(id: number){
    this._pacienteService.consultar(id).subscribe(paciente => {
      this.criarFormulario(paciente);
    }, error => {
      console.log(error);
      this._snackBar.open('Erro ao carregar dados do paciente!', '', {
        duration: 3000,
      });
    });
  }


  public onClickRetornar(){
    this._route.navigate(['']);
  }

}
