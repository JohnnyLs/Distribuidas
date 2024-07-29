describe('UsuariosComponent e2e tests', () => {
  let initialLength;

  beforeEach(() => {
    cy.visit('http://localhost:4200/usuarios');
    cy.get('table.usuarios-table tbody tr').then(rows => {
      initialLength = rows.length;
    });
  });

  it('should create', () => {
    cy.get('app-usuarios').should('exist');
  });

  it('should list users', () => {
    cy.get('table.usuarios-table tbody tr').should('have.length.greaterThan', 0);
  });

  it('should open modal to add user', () => {
    cy.get('button.btn-agregar').click();
    cy.get('.modal').should('be.visible');
  });

  it('should add a new user', () => {
    cy.get('button.btn-agregar').click();
    cy.get('input#nombre').type('Nuevo Usuario');
    cy.get('input#email').type('nuevo@usuario.com');
    cy.get('input#password').type('password');
    cy.get('form').submit();
    cy.get('.modal').should('not.exist');
    cy.get('table.usuarios-table tbody tr').should('contain', 'Nuevo Usuario');
    cy.get('table.usuarios-table tbody tr').should('have.length', initialLength + 1);
  });

  it('should edit a user', () => {
    cy.get('table.usuarios-table tbody tr').first().within(() => {
      cy.get('button').contains('Editar').click();
    });
    cy.get('input#nombre').clear().type('Usuario Editado');
    cy.get('form').submit();
    cy.get('.modal').should('not.exist');
    cy.get('table.usuarios-table tbody tr').first().should('contain', 'Usuario Editado');
  });

  it('should delete a user', () => {
    cy.get('table.usuarios-table tbody tr').first().within(() => {
      cy.get('button').contains('Eliminar').click();
    });
    cy.get('table.usuarios-table tbody tr').should('have.length', initialLength - 1);
  });
});
