import { NgModule } from '@angular/core';
import { PacienteFormComponent } from './pacientes/form/paciente-form.component';
import { PacienteListaComponent } from './pacientes/lista/paciente-lista.component';
import { PagesRoutingModule } from './pages-routing.module';
import { MaterialModule } from '../material-modules';
import { ReactiveFormsModule } from '@angular/forms';
import { TelefoneComponent } from './pacientes/telefone/telefone.component';
import { CommonModule } from '@angular/common';


const COMPONENTS = [
  PacienteFormComponent,
  PacienteListaComponent,
  TelefoneComponent
];
const COMPONENTS_DYNAMIC = [];

const EXPORT_MODULES = [
  PacienteFormComponent,
  PacienteListaComponent
];

@NgModule({
  imports: [
    PagesRoutingModule,
    MaterialModule,
    ReactiveFormsModule,
    CommonModule
  ],
  declarations: [...COMPONENTS, ...COMPONENTS_DYNAMIC],
  entryComponents: COMPONENTS_DYNAMIC,
  exports: [EXPORT_MODULES]
})
export class PagesModule { }
