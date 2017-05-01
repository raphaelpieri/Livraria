using System;
using Livraria.Shared.Commands;

namespace Livraria.Domain.Commands.Result
{
    public class BookResult : ICommandResult
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
    }
}