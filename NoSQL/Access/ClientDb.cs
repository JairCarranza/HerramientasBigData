using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoSQL.Access
{
    class ClientDb
    {
        public static MongoClient AccessDb()
        {
            string connectionString = Constants.MINOS_MONGO_DB;

            MongoClientSettings settings = MongoClientSettings.FromUrl(
                new MongoUrl(connectionString)
            );
            settings.SslSettings =
                new SslSettings { EnabledSslProtocols = SslProtocols.Tls12 };

            MongoClient client = new MongoClient(settings);

            return client;
        }
    }
}
