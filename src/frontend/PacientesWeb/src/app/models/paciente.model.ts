import { ViewModelBase } from "./base.model";
import { Sexo } from "./sexo.enum";
import { TelefoneViewModel } from "./telefone.model";

export class PacienteViewModel extends ViewModelBase {
  public nome: string;
  public cpf: number;
  public rg: number;
  public cns: number;
  public dataNascimento: Date;
  public sexo: Sexo;
  public nomeMae: string;
  public endereco: string;
  public bairro: string;
  public cep: number;
  public estado: string;
  public cidade: string;

  public telefones: TelefoneViewModel[];
}
