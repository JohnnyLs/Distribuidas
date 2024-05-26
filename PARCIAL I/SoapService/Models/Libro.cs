
using System.Runtime.Serialization;

namespace SoapService.Models
{
    [DataContract]
    public class Libro
    {
        [DataMember]
        public int id { get; set; }

        [DataMember]
        public string nombre { get; set; }

        [DataMember]
        public string descripcion { get; set; }

        [DataMember]
        public DateTime fecha { get; set; }

        [DataMember]
        public decimal precio { get; set; }

        [DataMember]
        public int numero_paginas { get; set; }


    }
}