using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CashFlow.API.Controllers
{
    [Route("api/categories")]
    public class CategoriesController
    {
        [HttpGet]
        public JsonResult GetCategories()
        {
            return new JsonResult(CategoriesDataStore.Current.Categories);
        }

        [HttpGet("{id}")]
        public JsonResult GetCategory(int id)
        {
            return new JsonResult(CategoriesDataStore.Current.Categories.FirstOrDefault(x=>x.Id == id));
        }
    }
}
