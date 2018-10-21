using CashFlow.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CashFlow.API
{
    public class CategoriesDataStore
    {
        public static CategoriesDataStore Current { get; } = new CategoriesDataStore();
        public List<CategoryDto> Categories { get; set; }

        public CategoriesDataStore()
        {
            Categories = new List<CategoryDto>()
            {
                new CategoryDto()
                {
                     Id = 1,
                     Name = "Bills",
                     Items = new List<ItemDto>()
                     {
                         new ItemDto()
                         {
                             Id = 1,
                             Name = "Rent",
                         },
                         new ItemDto()
                         {
                             Id = 2,
                             Name = "Internet",
                         },
                     }
                },
                new CategoryDto()
                {
                     Id = 2,
                     Name = "Food",
                     Items = new List<ItemDto>()
                     {
                         new ItemDto()
                         {
                             Id = 11,
                             Name = "Supermarket",
                         },
                         new ItemDto()
                         {
                             Id = 12,
                             Name = "Restaurant",
                         },
                     }
                },
                new CategoryDto()
                {
                     Id = 3,
                     Name = "Sport",
                     Items = new List<ItemDto>()
                     {
                         new ItemDto()
                         {
                             Id = 21,
                             Name = "Multisport",
                         },
                         new ItemDto()
                         {
                             Id = 31,
                             Name = "Tennis",
                         },
                     }
                }
            };
        }
    }
}
