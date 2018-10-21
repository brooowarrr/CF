using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CashFlow.API.Controllers
{
    [Route("api/items")]
    public class ItemsController : Controller
    {
        [HttpGet()]
        public JsonResult GetItems()
        { 
            return new JsonResult(new List<object>()
            {
                new {id=1, Name="Food"},
                new {id=2, Name="Rent"},
                new {id=3, Name="Petrol"},
            });
        }
    }
}
