package com.espe.msvc_cursos.services;

import com.espe.msvc_cursos.clients.UsuarioClientRest;
import com.espe.msvc_cursos.models.entity.Curso;
import com.espe.msvc_cursos.models.entity.CursoUsuario;
import com.espe.msvc_cursos.models.entity.Usuario;
import com.espe.msvc_cursos.repositories.CursoRepository;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import java.util.List;
import java.util.Optional;
import java.util.stream.Collectors;

@Service
public class CursoServiceImpl implements CursoService{
    @Autowired
    private CursoRepository repository;

    @Autowired
    UsuarioClientRest usuarioClientRest;

    @Override
    @Transactional(readOnly = true)
    public List<Curso> listar() {
        List<Curso> cursos = (List<Curso>) repository.findAll();
        cursos.forEach(this::cargarUsuarios);
        return cursos;
    }

    @Override
    @Transactional(readOnly = true)
    public Optional<Curso> porId(long id) {
        Optional<Curso> o = repository.findById(id);
        if (o.isPresent()) {
            Curso curso = o.get();
            cargarUsuarios(curso);
            return Optional.of(curso);
        }
        return Optional.empty();
    }

    private void cargarUsuarios(Curso curso) {
        if (!curso.getCursoUsuarios().isEmpty()) {
            List<Long> ids = curso.getCursoUsuarios().stream().map(CursoUsuario::getUsuarioId).collect(Collectors.toList());
            List<Usuario> usuarios = ids.stream().map(id -> {
                try {
                    return usuarioClientRest.detalle(id);
                } catch (Exception e) {
                    System.err.println("Error fetching user with id " + id + ": " + e.getMessage());
                    return null;
                }
            }).filter(u -> u != null).collect(Collectors.toList());
            curso.setUsuarios(usuarios);
        }
    }


    @Override
    @Transactional
    public Curso guardar(Curso curso){
        return repository.save(curso);
    }

    @Override
    @Transactional
    public void eliminar(Long id){
        repository.deleteById(id);
    }

    @Override
    public Optional<Usuario> agregarUsuario(Usuario usuario, Long idCurso) {
        Optional<Curso> o = repository.findById(idCurso);
        if (o.isPresent()) {
            Usuario usuarioMicro = usuarioClientRest.detalle(usuario.getId());
            Curso curso = o.get();
            boolean usuarioYaAsignado = curso.getCursoUsuarios().stream()
                    .anyMatch(cu -> cu.getUsuarioId().equals(usuarioMicro.getId()));

            if (usuarioYaAsignado) {
                return Optional.empty();
            }

            CursoUsuario cursoUsuario = new CursoUsuario();
            cursoUsuario.setUsuarioId(usuarioMicro.getId());
            curso.addCursoUsuario(cursoUsuario);
            repository.save(curso);
            return Optional.of(usuarioMicro);
        }
        return Optional.empty();
    }

    @Override
    public Optional<Usuario> crearUsuario(Usuario usuario, Long idCurso){
        Optional<Curso> o = repository.findById(idCurso);
        if(o.isPresent()){
            Usuario usuarioMicro = usuarioClientRest.crear(usuario);
            Curso curso = o.get();
            CursoUsuario cursoUsuario = new CursoUsuario();
            cursoUsuario.setUsuarioId(usuarioMicro.getId());
            curso.addCursoUsuario(cursoUsuario);
            repository.save(curso);
        }
        return Optional.empty();
    }


    @Override
    public Optional<Usuario> eliminarUsuario(Usuario usuario, Long idCurso){
        Optional<Curso> o = repository.findById(idCurso);
        if(o.isPresent()){
            Usuario usuarioMicro = usuarioClientRest.detalle(usuario.getId());
            Curso curso = o.get();
            CursoUsuario cursoUsuario = new CursoUsuario();
            cursoUsuario.setUsuarioId(usuarioMicro.getId());
            curso.removeCursoUsuario(cursoUsuario);
            repository.save(curso);
        }
        return Optional.empty();
    }

    @Override
    @Transactional
    public Optional<Usuario> eliminarUsuarioCurso(Long usuarioId, Long cursoId) {
        Optional<Curso> cursoOpt = repository.findById(cursoId);
        if (cursoOpt.isPresent()) {
            Curso curso = cursoOpt.get();
            boolean removed = curso.getCursoUsuarios().removeIf(cu -> cu.getUsuarioId().equals(usuarioId));
            if (removed) {
                repository.save(curso);
                return Optional.of(usuarioClientRest.detalle(usuarioId));
            }
        }
        return Optional.empty();
    }
}
