package com.espe.msvc_cursos.controllers;

import com.espe.msvc_cursos.models.entity.Curso;
import com.espe.msvc_cursos.models.entity.Usuario;
import com.espe.msvc_cursos.services.CursoService;
import feign.FeignException;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;

import java.util.Collections;
import java.util.List;
import java.util.Optional;

@RestController
@RequestMapping("/api/v1.0/private/cursos")
@CrossOrigin(origins = "http://localhost:4200")
public class CursoController {
    @Autowired
    private CursoService service;

   @GetMapping("/")
   public ResponseEntity<List<Curso>> listar() {
       return ResponseEntity.ok(service.listar());
   }

    @GetMapping("/{id}")
    public ResponseEntity<?> detalle(@PathVariable Long id) {
        Optional<Curso> cursoOptional = service.porId(id);
        if (cursoOptional.isPresent()) {
            return ResponseEntity.ok().body(cursoOptional.get());
        }
        return ResponseEntity.notFound().build();
    }
    @PostMapping("/create")
    public ResponseEntity<?> crear(@RequestBody Curso curso){
        return ResponseEntity.status(HttpStatus.CREATED).body(service.guardar(curso));
    }

    @PutMapping("/update/{id}")
    public ResponseEntity<?> editar(@RequestBody Curso curso, @PathVariable Long id){
        Optional<Curso> cursoOptional = service.porId(id);
        if(cursoOptional.isPresent()){
            Curso cursoDB = cursoOptional.get();
            cursoDB.setNombre(curso.getNombre());
            return ResponseEntity.status(HttpStatus.CREATED).body(service.guardar(cursoDB));

        }
        return ResponseEntity.notFound().build();
    }

    @DeleteMapping("/delete/{id}")
    public ResponseEntity<?> eliminar(@PathVariable Long id){
        Optional<Curso> optionalCurso = service.porId(id);
        if(optionalCurso.isPresent()){
            service.eliminar(id);
            return ResponseEntity.noContent().build();

        }
        return ResponseEntity.notFound().build();
    }

    @DeleteMapping("/{cursoId}/usuarios/{usuarioId}")
    public ResponseEntity<?> eliminarUsuarioCurso(@PathVariable Long cursoId, @PathVariable Long usuarioId) {
        Optional<Usuario> usuarioEliminado = service.eliminarUsuarioCurso(usuarioId, cursoId);
        if (usuarioEliminado.isPresent()) {
            return ResponseEntity.ok().body(usuarioEliminado.get());
        }
        return ResponseEntity.notFound().build();
    }
    @PutMapping("/asignar-usuario/{idCurso}")
    public ResponseEntity<?> asignarUsuario(@RequestBody Usuario usuario, @PathVariable Long idCurso) {
        try {
            Optional<Usuario> usuarioAsignado = service.agregarUsuario(usuario, idCurso);
            if (usuarioAsignado.isPresent()) {
                return ResponseEntity.status(HttpStatus.CREATED).body(usuarioAsignado.get());
            } else {
                return ResponseEntity.status(HttpStatus.CONFLICT)
                        .body(Collections.singletonMap("error", "El usuario ya está asignado a un curso."));
            }
        } catch (FeignException e) {
            return ResponseEntity.status(HttpStatus.INTERNAL_SERVER_ERROR)
                    .body(Collections.singletonMap("error", "Error al procesar la solicitud: " + e.getMessage()));
        }
    }
}
