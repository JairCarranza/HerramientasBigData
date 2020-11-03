using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;

namespace NoSQL.DataModel
{
    public class Orders
    {
        [BsonId(IdGenerator = typeof(ObjectIdGenerator))]
        public ObjectId _id { get; set; }
        public string ClientId { get; set; }
        public string Ciudad { get; set; }
        public string localidad { get; set; }
        public string Direccion { get; set; }

    }
}
