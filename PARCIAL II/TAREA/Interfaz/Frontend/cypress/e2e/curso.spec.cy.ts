describe('CursosComponent', () => {
  let initialLength;

  beforeEach(() => {
    cy.visit('http://localhost:4200/cursos');
    cy.get('table.usuarios-table tbody tr').then(rows => {
      initialLength = rows.length;
    });
  });

  it('should create', () => {
    cy.get('app-cursos').should('exist');
  });

  it('should list courses', () => {
    cy.get('table.usuarios-table tbody tr').should('have.length.greaterThan', 0);
  });

  it('should open modal to add course', () => {
    cy.get('button.btn-agregar').click();
    cy.get('.modal').should('be.visible');
  });

  it('should add a new course', () => {
    cy.get('button.btn-agregar').click();
    cy.get('input#nombre').type('Nuevo Curso');
    cy.get('form').submit();
    cy.get('.modal').should('not.exist');
    cy.get('table.usuarios-table tbody tr').should('contain', 'Nuevo Curso');
  });

  it('should edit a course', () => {
    cy.get('table.usuarios-table tbody tr').first().within(() => {
      cy.get('button.btn-warning').click();
    });
    cy.get('input#nombre').clear().type('Curso Editado');
    cy.get('form').submit();
    cy.get('.modal').should('not.exist');
    cy.get('table.usuarios-table tbody tr').first().should('contain', 'Curso Editado');
  });

  it('should delete a course', () => {
    cy.get('table.usuarios-table tbody tr').first().within(() => {
      cy.get('button.btn-danger').click();
    });
    cy.get('table.usuarios-table tbody tr').should('have.length', initialLength - 1);
  });
});
