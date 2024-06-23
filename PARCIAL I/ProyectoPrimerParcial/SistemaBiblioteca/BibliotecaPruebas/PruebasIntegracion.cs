using Xunit;
using BibliotecaData.Configuracion;
using BibliotecaEntidades;
using BibliotecaNegocios.Implementacion;
using BibliotecaData.Contrato;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System.Threading.Tasks;

namespace BibliotecaPruebas
{
    public class PruebasIntegracion : IDisposable
    {
        private readonly ICategoriaRepositorio _categoriaRepositorio;
        private readonly IEstudianteRepositorio _estudianteRepositorio;
        private readonly ILibroRepositorio _libroRepositorio;
        private readonly IPrestamoRepositorio _prestamoRepositorio;

        public PruebasIntegracion()
        {
            var services = new ServiceCollection();

            // Configure ConnectionStrings
            services.Configure<ConnectionStrings>(options =>
            {
                options.CadenaSQL = "Server=MSI\\SQLEXPRESS;Database=DBBiblioteca;Integrated Security=True;";
            });

            // Register Repositories
            services.AddScoped<ICategoriaRepositorio, CategoriaRepositorio>();
            services.AddScoped<IEstudianteRepositorio, EstudianteRepositorio>();
            services.AddScoped<ILibroRepositorio, LibroRepositorio>();
            services.AddScoped<IPrestamoRepositorio, PrestamoRepositorio>();

            var serviceProvider = services.BuildServiceProvider();

            _categoriaRepositorio = serviceProvider.GetRequiredService<ICategoriaRepositorio>();
            _estudianteRepositorio = serviceProvider.GetRequiredService<IEstudianteRepositorio>();
            _libroRepositorio = serviceProvider.GetRequiredService<ILibroRepositorio>();
            _prestamoRepositorio = serviceProvider.GetRequiredService<IPrestamoRepositorio>();
        }

        [Fact]
        public async Task PruebaRegistrarEstudianteYLibroYPrestar()
        {
            // Crear un nuevo estudiante
            var estudiante = new Estudiante
            {
                Nombres = "Juan",
                Apellidos = "Pérez"
            };
            await _estudianteRepositorio.Guardar(estudiante);

            // Crear una nueva categoría
            var categoria = new Categoria { Nombre = "Novela" };
            await _categoriaRepositorio.Guardar(categoria);

            // Crear un nuevo libro
            var libro = new Libro
            {
                Titulo = "Cien Años de Soledad",
                Autor = "Gabriel García Márquez",
                oCategoria = categoria,
                Codigo = "CAOS-020",
                FechaPublicacion = "2024-06-23",
                Cantidad = 5
            };
            await _libroRepositorio.Guardar(libro);

            // Realizar un préstamo
            var prestamo = new Prestamo
            {
                oEstudiante = estudiante,
                oLibro = libro
                
            };
            var resultado = await _prestamoRepositorio.Guardar(prestamo);

            
        }

        public void Dispose()
        {
           
        }
    }
}
