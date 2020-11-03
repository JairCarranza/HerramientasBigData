using HerramientasBigData.Components;
using HerramientasBigData.Models;
using NoSQL.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace HerramientasBigData.Controllers
{
    [RoutePrefix("Order")]
    public class OrderController : ApiController
    {
        [HttpGet]
        [Route("GetOrders")]
        public async Task<List<Orders>> GetOrders()
        {
            return await new OrderComponent().GetOrders();
        }


    }


    
}