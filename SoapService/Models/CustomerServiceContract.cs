
using System.ServiceModel;

namespace SoapService.Models
{
    [ServiceContract]
    public interface CustomerServiceContract
    {
        [OperationContract]
        List<Libro> GetLibros();

        [OperationContract]
        void AgregarLibro(Libro libro);

        [OperationContract]
        void ActualizarLibro(Libro libro);

        [OperationContract]
        void EliminarLibro(int id);
    }
}
