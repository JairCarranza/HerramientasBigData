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
    public class OrderComponent
    {
        private readonly OrdersDb _NosqlConnect;
        
        public async Task<List<Orders>> GetOrders()
        {
            List<Orders> ordersMongo = await _NosqlConnect.GetAll();

            return ordersMongo;
        }

    }
}