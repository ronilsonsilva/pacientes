import { PacienteListaComponent } from './pacientes/lista/paciente-lista.component';
import { PacienteFormComponent } from './pacientes/form/paciente-form.component';
import { RouterModule, Routes } from '@angular/router';
import { NgModule } from '@angular/core';


const routes: Routes = [
  { path: '', component: PacienteListaComponent, data: { title: 'Pacientes' } },
  { path: 'novo', component: PacienteFormComponent, data: { title: 'Novo' } },
  { path: ':id', component: PacienteFormComponent, data: { title: 'Editar' } },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class PagesRoutingModule {}
