// cypress/integration/usuarios.spec.js

describe('UsuariosComponent e2e tests', () => {
  beforeEach(() => {
    cy.visit('/'); 
  });

  it('should create', () => {
    cy.get('app-usuarios').should('exist');
  });

  it('should list usuarios on init', () => {
    
    cy.get('.usuario-list').should('contain', 'Usuario 1');
    cy.get('.usuario-list').should('contain', 'Usuario 2');
  });

  it('should open modal for creating a new usuario', () => {
    cy.get('button#open-create-modal').click();
    cy.get('.modal').should('be.visible');
    cy.get('input[name="nombre"]').should('exist');
    cy.get('input[name="email"]').should('exist');
    cy.get('input[name="password"]').should('exist');
  });

  it('should open modal for editing an existing usuario', () => {
    cy.get('.edit-button').first().click(); 
    cy.get('.modal').should('be.visible');
    cy.get('input[name="nombre"]').should('have.value', 'Usuario 1'); 
  });

  it('should close modal', () => {
    cy.get('button#close-modal').click();
    cy.get('.modal').should('not.exist');
  });

  it('should create a new usuario', () => {
    cy.get('button#open-create-modal').click();
    cy.get('input[name="nombre"]').type('Nuevo Usuario');
    cy.get('input[name="email"]').type('newuser@example.com');
    cy.get('input[name="password"]').type('password');
    cy.get('button#save').click();
    
    
    cy.get('.usuario-list').should('contain', 'Nuevo Usuario');
  });

  it('should update an existing usuario', () => {
    cy.get('.edit-button').first().click(); 
    cy.get('input[name="nombre"]').clear().type('Usuario Actualizado');
    cy.get('button#save').click();
    
    
    cy.get('.usuario-list').should('contain', 'Usuario Actualizado');
  });

  it('should delete a usuario', () => {
    cy.get('.delete-button').first().click(); // Asume que el botón de eliminar es el primero en la lista
    cy.get('button#confirm-delete').click(); // Confirma la eliminación
    
    // Verifica que el usuario haya sido eliminado
    cy.get('.usuario-list').should('not.contain', 'Usuario 1'); // Ajusta el nombre según el usuario eliminado
  });

  it('should reset the form', () => {
    cy.get('button#open-create-modal').click();
    cy.get('input[name="nombre"]').type('Temp Usuario');
    cy.get('button#reset-form').click();
    
    // Verifica que el formulario se haya restablecido
    cy.get('input[name="nombre"]').should('be.empty');
    cy.get('input[name="email"]').should('be.empty');
    cy.get('input[name="password"]').should('be.empty');
  });

  it('should validate nombre with only letters', () => {
    cy.get('input[name="nombre"]').type('Nombre Valido');
    cy.get('input[name="nombre"]').should('have.value', 'Nombre Valido');
    
    // Intentar ingresar caracteres no válidos
    cy.get('input[name="nombre"]').type('123').should('have.value', 'Nombre Valido'); // Asegúrate de que los caracteres no válidos no se acepten
  });

  it('should prevent non-letter characters in nombre input', () => {
    // No se puede hacer exactamente lo mismo en Cypress como en pruebas unitarias, pero puedes verificar restricciones de entrada si están implementadas
    cy.get('input[name="nombre"]').type('123').should('not.have.value', '123');
  });
});
