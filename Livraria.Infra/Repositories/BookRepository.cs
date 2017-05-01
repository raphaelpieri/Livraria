using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Livraria.Domain.Commands.Result;
using Livraria.Domain.Entities;
using Livraria.Domain.Repositories;
using Livraria.Infra.Contexts;

namespace Livraria.Infra.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly LivrariaContext _context;

        public BookRepository(LivrariaContext context)
        {
            _context = context;
        }

        public Book GetBook(Guid id)
        {
            return _context.Books.FirstOrDefault(x => x.Id == id);
        }
        public DTOBook Get(Guid id)
        {
            return _context.Books.Select(x => new DTOBook()
            {
                Id = x.Id,
                Title =  x.Title.CompleteName,
                Author = x.Author.CompleteName,
                PublishingCompany = x.PublishingCompany.CompleteName,
                Value =  x.Value,
                QuantityOnHand = x.QuantityOnHand,
                Page = x.Page
            }).FirstOrDefault(x => x.Id == id);
        }

        public IList<GridBook> Get()
        {
            var resultado = (from b in _context.Books
                             orderby b.Title.CompleteName descending
                             select new GridBook()
                             {
                                 Id = b.Id,
                                 Title = b.Title.CompleteName,
                                 Author = b.Author.CompleteName,
                                 PublishingCompany = b.PublishingCompany.CompleteName,
                                 Value = b.Value
                             });

            return resultado.ToList();
        }

        public void Save(Book book)
        {
            _context.Books.Add(book);
        }

        public void Update(Book book)
        {
            _context.Entry(book).State = EntityState.Modified;
        }

        public void Remove(Book book)
        {
            _context.Books.Remove(book);
        }
    }
}