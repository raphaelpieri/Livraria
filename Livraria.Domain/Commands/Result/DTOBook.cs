using System;
using Livraria.Domain.ValueObjects;

namespace Livraria.Domain.Commands.Result
{
    public class DTOBook
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string PublishingCompany { get; set; }
        public string Author { get; set; }
        public int Page { get; set; }
        public decimal Value { get; set; }
        public int QuantityOnHand { get; set; }
    }
}