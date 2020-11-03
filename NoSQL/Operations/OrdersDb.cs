using MongoDB.Bson;
using MongoDB.Driver;
using NoSQL.Access;
using NoSQL.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoSQL.Operations
{
    public class OrdersDb
    {
        private readonly MongoClient _client;
        private readonly string collectionName = "Orders";
        private readonly string databaseName = "BigDataDb";

        public OrdersDb()
        {
            _client = ClientDb.AccessDb();
        }

        /// <summary>
        ///     Metodo que devuelve todos los registros guardados en la colección
        /// </summary>
        /// <returns></returns>
        public async Task<List<Orders>> GetAll()
        {
            IMongoDatabase db = _client.GetDatabase(databaseName);
            IMongoCollection<Orders> obj = db.GetCollection<Orders>(collectionName);

            List<Orders> lst = await obj.Find(_ => true).ToListAsync();

            return lst;
        }

        /// <summary>
        ///     Metodo que devuelve un registro a partir de su ID en la base de Mongo
        /// </summary>
        /// <param name="id">Id a buscar</param>
        /// <returns></returns>
        public async Task<Orders> GetById(string id)
        {
            IMongoDatabase db = _client.GetDatabase(databaseName);
            IMongoCollection<Orders> obj = db.GetCollection<Orders>(collectionName);

            FilterDefinitionBuilder<Orders> builder = Builders<Orders>.Filter;
            FilterDefinition<Orders> query = builder.Eq("_id", ObjectId.Parse(id));

            return await obj.Find(query).FirstOrDefaultAsync();
        }

        /// <summary>
        ///     Metodo para insertar o actualizar un registro
        /// </summary>
        /// <param name="data">Campos a insertar/actualizar</param>
        /// <param name="id">ID del campo a actualizar</param>
        /// <returns></returns>
        public Orders InsertOrUpdate(Orders data, string id = null)
        {
            IMongoDatabase db = _client.GetDatabase(databaseName);
            IMongoCollection<Orders> obj = db.GetCollection<Orders>(collectionName);

            if (id == null)
            {
                obj.InsertOneAsync(data);

                return data;
            }

            FindOneAndReplaceOptions<Orders> options = new FindOneAndReplaceOptions<Orders>
            {
                ReturnDocument = ReturnDocument.After
            };

            data._id = ObjectId.Parse(id);

            return obj.FindOneAndReplace<Orders>(u => u._id == data._id, data, options);
        }

        public async Task<bool> DeleteOne(string id)
        {
            ObjectId _id = ObjectId.Parse(id);
            bool response = false;

            try
            {
                IMongoDatabase db = _client.GetDatabase(databaseName);
                IMongoCollection<Orders> obj = db.GetCollection<Orders>(collectionName);

                DeleteResult result = await obj.DeleteOneAsync(m => m._id == _id);

                if (result.DeletedCount > 0)
                {
                    response = true;
                }
            }
            catch (Exception)
            {
                response = false;
            }

            return response;
        }
    }
}
