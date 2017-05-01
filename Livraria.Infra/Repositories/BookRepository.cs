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

        public Book Get(Guid id)
        {
            return _context.Books.FirstOrDefault(x => x.Id == id);
        }

        public IList<GridBook> Get(int paginaAtual)
        {
            var resultado = (from b in _context.Books
                select new GridBook()
                {
                    Title = b.Title.CompleteName,
                    Author = b.Author.CompleteName,
                    PublishingCompany = b.PublishingCompany.CompleteName,
                    Value =  b.Value
                });

            return resultado.OrderBy(x => x.Title).Skip((paginaAtual - 1) * 30).Take(30).ToList();
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