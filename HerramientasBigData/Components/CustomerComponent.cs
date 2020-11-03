using HerramientasBigData.Models;
using NoSQL.DataModel;
using NoSQL.Operations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace HerramientasBigData.Components
{
    
    public class CustomerComponent
    {
        private readonly CustomersDb _NosqlConnect;

        public async Task<List<Customers>> GetCustomers()
        {
            List<Customers> customersMongo = await _NosqlConnect.GetAll();

            return customersMongo;
        }
    }
}