using Livraria.Shared.Commands;

namespace Livraria.Domain.Commands.Input
{
    public class RegisterBookCommnad : ICommand
    {
        public string Title { get; set; }
        public string PublishingCompany { get; set; }
        public string Author { get; set; }
        public int Page { get; set; }
        public decimal Value { get; set; }
        public int QuantityOnHand { get; set; }
    }
}