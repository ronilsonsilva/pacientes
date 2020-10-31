import { ViewModelBase } from "./base.model";
import { TipoTelefone } from "./tipo-telefone.enum";

export class TelefoneViewModel extends ViewModelBase {
  public tipo: TipoTelefone;
  public ddd: number;
  public numero: number;
  public pacienteId: number;
  public tipoDescricao: string;
}
