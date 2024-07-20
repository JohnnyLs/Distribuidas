package com.espe.msvc_cursos.services;

import com.espe.msvc_cursos.models.entity.Curso;
import com.espe.msvc_cursos.models.entity.Usuario;

import java.util.List;
import java.util.Optional;

public interface CursoService {
    List<Curso> listar();
    Optional<Curso> porId (long id);

    Curso guardar(Curso usuario);

    void eliminar(Long id);

    Optional<Usuario> agregarUsuario(Usuario usuario, Long idCurso);
    Optional<Usuario> crearUsuario(Usuario usuario, Long idCurso);
    Optional<Usuario> eliminarUsuario(Usuario usuario, Long idCurso);
    Optional<Usuario> eliminarUsuarioCurso(Long usuarioId, Long cursoId);

}
