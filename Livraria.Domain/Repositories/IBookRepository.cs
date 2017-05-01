using System;
using System.Collections;
using System.Collections.Generic;
using Livraria.Domain.Commands.Result;
using Livraria.Domain.Entities;

namespace Livraria.Domain.Repositories
{
    public interface IBookRepository
    {
        Book Get(Guid id);
        IList<GridBook> Get(int paginaAtual);
        void Save(Book book);
        void Update(Book book);
        void Remove(Book book);
    }
}