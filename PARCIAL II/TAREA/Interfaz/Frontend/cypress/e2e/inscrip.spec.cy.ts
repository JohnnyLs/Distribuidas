describe('InscripcionComponent e2e tests', () => {
  let initialLength;

  beforeEach(() => {
    cy.visit('http://localhost:4200/inscripcion');
    cy.get('table.usuarios-table tbody tr').then(rows => {
      initialLength = rows.length;
    });
  });

  it('should create', () => {
    cy.get('app-inscripcion').should('exist');
  });

  it('should list courses and users', () => {
    cy.get('select#usuarioId').children().should('have.length.greaterThan', 1);
    cy.get('select#cursoId').children().should('have.length.greaterThan', 1);
  });

  it('should inscribe a user to a course', () => {
    cy.get('select#usuarioId').select(1); // Selecciona el primer usuario
    cy.get('select#cursoId').select(1); // Selecciona el primer curso
    cy.get('button.btn-primary').contains('Inscribir').click();

    // Espera a que la inscripción se procese
    cy.wait(1000);

    // Vuelve a cargar la tabla para verificar el cambio
    cy.get('table.usuarios-table tbody tr').then(rows => {
      expect(rows.length).to.equal(initialLength);
    });
  });

  it('should desinscribe a user from a course', () => {
    // Asegúrate de inscribir primero a un usuario para tener algo que desinscribir
    cy.get('select#usuarioId').select(1);
    cy.get('select#cursoId').select(1);
    cy.get('button.btn-primary').contains('Inscribir').click();

    // Espera a que la inscripción se procese
    cy.wait(1000);

    // Luego desinscribe al usuario
    cy.get('button.btn-secondary').contains('Desinscribir').click();

    // Espera a que la desinscripción se procese
    cy.wait(1000);

    // Vuelve a cargar la tabla para verificar el cambio
    cy.get('table.usuarios-table tbody tr').then(rows => {
      expect(rows.length).to.equal(initialLength);
    });
  });

  it('should delete a course', () => {
    // Asegúrate de que hay un curso para eliminar
    cy.get('table.usuarios-table tbody tr').first().within(() => {
      cy.get('button.btn-danger').contains('Eliminar').click();
    });

    // Confirma la eliminación
    cy.on('window:confirm', () => true);

    // Espera a que la eliminación se procese
    cy.wait(1000);

    // Vuelve a cargar la tabla para verificar el cambio
    cy.get('table.usuarios-table tbody tr').then(rows => {
      expect(rows.length).to.be.lessThan(initialLength);
    });
  });
});
