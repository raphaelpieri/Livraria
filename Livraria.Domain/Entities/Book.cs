using Livraria.Domain.Commands.Input;
using Livraria.Domain.ValueObjects;
using Livraria.Shared.Entities;

namespace Livraria.Domain.Entities
{
    public class Book : Entity
    {
        protected Book()
        {
        }

        public Book(Name title, Name publishingCompany, Name author, int page, decimal value, int quantityOnHand)
        {
            this.NewValues(title, publishingCompany, author, page, value, quantityOnHand);
        }

        public Name Title { get; private set; }
        public Name PublishingCompany { get; private set; }
        public Name Author { get; private set; }
        public int Page { get; private set; }
        public decimal Value { get; private set; }
        public int QuantityOnHand { get; private set; }

        public void NewValues(Name title, Name publishingCompany, Name author, int page, decimal value, int quantityOnHand)
        {
            Title = title;
            PublishingCompany = publishingCompany;
            Author = author;
            Page = page;
            Value = value;
            QuantityOnHand = quantityOnHand;

            AddNotifications(title.Notifications);
            AddNotifications(publishingCompany.Notifications);
            AddNotifications(author.Notifications);
        }
    }
}