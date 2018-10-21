using System;

namespace CashFlow.API.Models
{
    public class TransactionDto
    {
        public int Id { get; set; }
        public decimal Value { get; set; }
        public ItemDto SourceItem { get; set; }
        public ItemDto TargetItem { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
        public bool IsPending { get; set; }
    }
}
