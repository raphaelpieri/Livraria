using System;
using FluentValidator;
using Livraria.Domain.Commands.Input;
using Livraria.Domain.Commands.Result;
using Livraria.Domain.Entities;
using Livraria.Domain.Repositories;
using Livraria.Domain.ValueObjects;
using Livraria.Shared.Commands;

namespace Livraria.Domain.Commands.Handlers
{
    public class BookCommandHandler : Notifiable, ICommandHandler<RegisterBookCommnad>, ICommandHandler<UpdateBookCommnad>, ICommandHandler<DeleteBookCommnad>
    {
        private readonly IBookRepository _bookRepository;

        public BookCommandHandler(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public ICommandResult Handle(RegisterBookCommnad command)
        {
            var title = new Name(command.Title);
            var publishingCompany = new Name(command.PublishingCompany);
            var author = new Name(command.Author);

            var book = new Book(title, publishingCompany, author, command.Page, command.Value, command.QuantityOnHand);

            AddNotifications(title.Notifications);
            AddNotifications(publishingCompany.Notifications);
            AddNotifications(author.Notifications);

            if (!IsValid())
                return null;

            _bookRepository.Save(book);

            return new BookResult()
            {
                Id = book.Id,
                Title = book.Title.ToString()
            };

        }

        public ICommandResult Handle(UpdateBookCommnad command)
        {
            var book = _bookRepository.Get(command.Id);
            if (book == null)
            {
                AddNotification("Book","Livro não encontrado");
                return null;
            }

            var title = new Name(command.Title);
            var publishingCompany = new Name(command.PublishingCompany);
            var author = new Name(command.Author);

            book.NewValues(title, publishingCompany, author, command.Page, command.Value, command.QuantityOnHand);
            AddNotifications(book.Notifications);

            if(IsValid())
                _bookRepository.Update(book);

            return new BookResult()
            {
                Id = book.Id,
                Title = book.Title.ToString()
            };

        }

        public ICommandResult Handle(DeleteBookCommnad command)
        {
            var book = _bookRepository.Get(command.Id);
            if (book == null)
            {
                AddNotification("Book", "Livro não encontrado");
                return null;
            }

            _bookRepository.Remove(book);
            return null;
        }
    }
}