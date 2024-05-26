using System.Runtime.Serialization;

namespace SoapService.Models
{
    [DataContract]
    public class CustomerDataContract
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string FirstName { get; set; }

        [DataMember]
        public string LastName { get; set; }

        [DataMember]
        public string EmailAddress { get; set; }
    }
}
