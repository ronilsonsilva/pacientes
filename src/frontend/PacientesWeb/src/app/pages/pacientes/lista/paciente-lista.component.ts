import { AfterViewInit, Component, OnInit, ViewChild } from "@angular/core";
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { PacienteService } from '../../../services/paciente.services';
import { Router } from '@angular/router';
import { PacienteViewModel } from '../../../models/paciente.model';
import { PacienteRequest } from 'src/app/models/request/paciente.request';
import { FormControl, FormGroup } from '@angular/forms';
import { MatSnackBar } from '@angular/material/snack-bar';


@Component({
  selector: 'app-pacientes-lista',
  templateUrl: './paciente-lista.component.html',
  styleUrls: ['./paciente-lista.component.scss']
})
export class PacienteListaComponent implements OnInit, AfterViewInit {

  displayedColumns: string[] = ['nome', 'cpf', 'rg', 'cidade', 'action'];
  public dataSource: MatTableDataSource<PacienteViewModel>;
  public form: FormGroup;

  @ViewChild(MatSort) sort: MatSort;

  constructor(
    private _pacienteService: PacienteService,
    private _router: Router,
    private _snackBar: MatSnackBar,
  ){

  }
  ngAfterViewInit(): void {
    this.dataSource.sort = this.sort;
  }

  ngOnInit(): void {
    this.criarFormulario(new PacienteRequest());
    this.carregarPacientes();
  }

  private criarFormulario(model: PacienteRequest) {
    if (this.form) {
      this.form = undefined;
    }

    this.form = new FormGroup({
      cpf: new FormControl(model.cpf),
      nome: new FormControl(model.nome),
    });
  }

  public clickNovoPaciente(){
    this._router.navigate(['/novo']);
  }

  public carregarPacientes(){
    let request: PacienteRequest = this.form.value;
    this._pacienteService.listar(request).subscribe((dados: PacienteViewModel[]) => {
      this.dataSource = new MatTableDataSource(dados);
    }, error => {
      console.log(error);
    });
  }

  public onClickEditar(element: PacienteViewModel){
    this._router.navigate(['/', element.id]);
  }

  public onClickDelete(element: PacienteViewModel){
    this._pacienteService.excluir(element.id).subscribe(retorno => {
      if (retorno.ok) {
        this._snackBar.open('Paciente excluído!', '', {
          duration: 3000,
        });
        this.carregarPacientes();
      } else {
        this._snackBar.open(retorno.allErros, '', {
          duration: 3000,
        });
      }
    }, error => {
      console.log(error);
      this._snackBar.open('Erro ao excluir paciente!', '', {
        duration: 3000,
      });
    })
  }

}

