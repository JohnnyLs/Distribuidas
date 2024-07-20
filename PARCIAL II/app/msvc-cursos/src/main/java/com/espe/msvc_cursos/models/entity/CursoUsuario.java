package com.espe.msvc_cursos.models.entity;
import jakarta.persistence.*;

@Entity
@Table(name="curso-usuario")
public class CursoUsuario {

    @Id
    @GeneratedValue(strategy = GenerationType.SEQUENCE, generator = "curso_g")
    @SequenceGenerator(name = "curso_g", sequenceName = "curso_sec", allocationSize = 1)
    private Long id;


    @Column(name="usuario_id", unique = true)
    private Long usuarioId;

    public Long getId() {
        return id;
    }

    public void setId(Long id) {
        this.id = id;
    }

    public Long getUsuarioId() {
        return usuarioId;
    }

    public void setUsuarioId(Long usuarioId) {
        this.usuarioId = usuarioId;
    }
}
