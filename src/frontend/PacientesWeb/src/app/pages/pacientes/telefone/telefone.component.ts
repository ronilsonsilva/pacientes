import { AfterViewInit, Component, Input, OnInit, ViewChild } from '@angular/core';
import { TelefoneViewModel } from '../../../models/telefone.model';
import { MatTableDataSource } from '@angular/material/table';
import { TelefoneService } from '../../../services/telefone.service';
import { MatSort } from '@angular/material/sort';
import { TelefoneRequest } from '../../../models/request/telefone.request';
import { FormControl, FormGroup } from '@angular/forms';
import { MatSnackBar } from '@angular/material/snack-bar';

@Component({
  selector: 'app-telefone',
  templateUrl: './telefone.component.html',
  styleUrls: ['./telefone.component.scss']
})
export class TelefoneComponent implements OnInit, AfterViewInit {
  @Input() pacienteId?: number;
  displayedColumns: string[] = ['ddd', 'numero', 'tipoDescricao', 'action'];
  public dataSource: MatTableDataSource<TelefoneViewModel>;

  @ViewChild(MatSort) sort: MatSort;
  public form: FormGroup;
  public submittted = false;

  constructor(
    private _telefoneService: TelefoneService,
    private _snackBar: MatSnackBar,
  ) {

  }
  ngAfterViewInit(): void {
    this.dataSource.sort = this.sort;
  }

  ngOnInit(): void {
    this.criarFormulario(new TelefoneViewModel());
    this.carregarTelefones();
  }

  private criarFormulario(model: TelefoneViewModel) {
    if (this.form) {
      this.form = undefined;
    }

    this.form = new FormGroup({
      id: new FormControl(model.id),
      ddd: new FormControl(model.ddd),
      numero: new FormControl(model.numero),
      tipo: new FormControl(model.tipo),
    });
  }

  private carregarTelefones() {
    let request = new TelefoneRequest(this.pacienteId);
    this._telefoneService.listar(request).subscribe((dados: TelefoneViewModel[]) => {
      this.dataSource = new MatTableDataSource(dados);
    }, error => {
      console.log(error);
    });
  }

  public salvarTelefone() {
    let telefone = this.form.value;
    telefone.tipo = parseInt(telefone.tipo);
    telefone.pacienteId = this.pacienteId;
    this._telefoneService.salvar(telefone).subscribe(retorno => {
      if (retorno.ok) {
        this._snackBar.open('Telefone salvo com sucesso!', '', {
          duration: 3000,
        });
        this.carregarTelefones();
        this.criarFormulario(new TelefoneViewModel());
      } else {
        this._snackBar.open(retorno.allErros, '', {
          duration: 3000,
        });
      }
    }, error => {
      console.log(error);
      this._snackBar.open('Erro ao salvar telefone!', '', {
        duration: 3000,
      });
    });
  }

  public onClickEditar(element: TelefoneViewModel){
    this.criarFormulario(element);
  }

  public onClickDelete(element: TelefoneViewModel){
    this._telefoneService.excluir(element.id).subscribe(retorno => {
      if (retorno.ok) {
        this._snackBar.open('Telefone excluído!', '', {
          duration: 3000,
        });
        this.carregarTelefones();
      } else {
        this._snackBar.open(retorno.allErros, '', {
          duration: 3000,
        });
      }
    }, error => {
      console.log(error);
      this._snackBar.open('Erro ao excluir telefone!', '', {
        duration: 3000,
      });
    })
  }

}

