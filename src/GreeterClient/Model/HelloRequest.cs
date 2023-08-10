using System.Runtime.Serialization;

namespace Greeter
{
    [DataContract]
    public class HelloRequest
    {
        [DataMember(Order = 1)]
        public string Name { get; set; }

    }
}
