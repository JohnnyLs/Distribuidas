import { NgModule } from '@angular/core';
import { BrowserModule, provideClientHydration } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { UsuariosComponent } from './components/usuarios/usuarios.component';
import { CursosComponent } from './components/cursos/cursos.component';
import { InscripcionComponent } from './components/inscripcion/inscripcion.component';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { CursoService } from './service/curso.service';
import { UsuarioService } from './service/usuario.service';
import { InscripcionService } from './service/inscripcion.service';

@NgModule({
  declarations: [
    AppComponent,
    CursosComponent,
    InscripcionComponent,
    UsuariosComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    HttpClientModule,
  ],
  providers: [
    provideClientHydration(),
    CursoService,
    UsuarioService,
    InscripcionService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
