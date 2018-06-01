using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CF.DataLayer
{
    public class CategoryDefinition
    {
        public int Id { get; set; }
        public Category Category { get; set; }
        public List<Item> Items { get; set; }
    }
}
