using System;
using Livraria.Shared.Commands;

namespace Livraria.Domain.Commands.Input
{
    public class DeleteBookCommnad : ICommand
    {
        public Guid Id { get; set; }
    }
}