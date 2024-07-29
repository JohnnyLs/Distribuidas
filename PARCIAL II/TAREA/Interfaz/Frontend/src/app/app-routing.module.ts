import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CursosComponent } from './components/cursos/cursos.component';
import { InscripcionComponent } from './components/inscripcion/inscripcion.component';
import { UsuariosComponent } from './components/usuarios/usuarios.component';

const routes: Routes = [
  { path: 'cursos', component: CursosComponent },
  { path: 'inscripcion', component: InscripcionComponent },
  { path: 'usuarios', component: UsuariosComponent },
  { path: '', redirectTo: '/cursos', pathMatch: 'full' }, // Optional default route
  { path: '**', redirectTo: '/cursos' } // Optional fallback route
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
