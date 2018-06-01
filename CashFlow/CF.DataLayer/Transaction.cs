using System;

namespace CF.DataLayer
{
    public class Transaction
    {
        public int Id { get; set; }
        public decimal Value { get; set; }
        public Item SourceItem { get; set; }
        public Item TargetItem { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
    }
}
