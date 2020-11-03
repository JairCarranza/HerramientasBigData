using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;

namespace NoSQL.DataModel
{
    public class Customers
    {
        [BsonId(IdGenerator = typeof(ObjectIdGenerator))]
        public ObjectId _id { get; set; }
        public int Identificacion { get; set; }
        public string Nombre { get; set; }
        public string Ciudad { get; set; }
        public string Localidad { get; set; }
        public string Direccion { get; set; }
    }
}
