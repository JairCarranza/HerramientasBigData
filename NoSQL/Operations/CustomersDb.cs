using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;
using NoSQL.Access;
using NoSQL.DataModel;

namespace NoSQL.Operations
{
    public class CustomersDb
    {
        private readonly MongoClient _client;
        private readonly string collectionName = "Clients";
        private readonly string databaseName = "BigDataDb";

        public CustomersDb()
        {
            _client = ClientDb.AccessDb();
        }

        /// <summary>
        ///     Metodo que devuelve todos los registros guardados en la colección
        /// </summary>
        /// <returns></returns>
        public async Task<List<Customers>> GetAll()
        {
            IMongoDatabase db = _client.GetDatabase(databaseName);
            IMongoCollection<Customers> obj = db.GetCollection<Customers>(collectionName);

            List<Customers> lst = await obj.Find(_ => true).ToListAsync();

            return lst;
        }

        /// <summary>
        ///     Metodo que devuelve un registro a partir de su ID en la base de Mongo
        /// </summary>
        /// <param name="id">Id a buscar</param>
        /// <returns></returns>
        public async Task<Customers> GetById(string id)
        {
            IMongoDatabase db = _client.GetDatabase(databaseName);
            IMongoCollection<Customers> obj = db.GetCollection<Customers>(collectionName);

            FilterDefinitionBuilder<Customers> builder = Builders<Customers>.Filter;
            FilterDefinition<Customers> query = builder.Eq("_id", ObjectId.Parse(id));

            return await obj.Find(query).FirstOrDefaultAsync();
        }


        /// <summary>
        ///     Metodo para insertar o actualizar un registro
        /// </summary>
        /// <param name="data">Campos a insertar/actualizar</param>
        /// <param name="id">ID del campo a actualizar</param>
        /// <returns></returns>
        public Customers InsertOrUpdate(Customers data, string id = null)
        {
            IMongoDatabase db = _client.GetDatabase(databaseName);
            IMongoCollection<Customers> obj = db.GetCollection<Customers>(collectionName);

            if (id == null)
            {
                obj.InsertOneAsync(data);

                return data;
            }

            FindOneAndReplaceOptions<Customers> options = new FindOneAndReplaceOptions<Customers>
            {
                ReturnDocument = ReturnDocument.After
            };

            data._id = ObjectId.Parse(id);

            return obj.FindOneAndReplace<Customers>(u => u._id == data._id, data, options);
        }

        /// <summary>
        ///     Metodo para eliminar un registro
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<bool> DeleteOne(string id)
        {
            ObjectId _id = ObjectId.Parse(id);
            bool response = false;

            try
            {
                IMongoDatabase db = _client.GetDatabase(databaseName);
                IMongoCollection<Customers> obj = db.GetCollection<Customers>(collectionName);

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
