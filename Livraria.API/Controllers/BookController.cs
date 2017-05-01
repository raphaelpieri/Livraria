using System;
using System.Threading.Tasks;
using Livraria.Domain.Commands.Handlers;
using Livraria.Domain.Commands.Input;
using Livraria.Domain.Repositories;
using Livraria.Infra.Transactions;
using Microsoft.AspNetCore.Mvc;

namespace Livraria.API.Controllers
{
    public class BookController : BaseController
    {
        private readonly IBookRepository _repository;
        private readonly BookCommandHandler _handler;
        public BookController(IUow uow, BookCommandHandler handler, IBookRepository repository) : base(uow)
        {
            _handler = handler;
            _repository = repository;
        }

        [HttpGet]
        [Route("book")]
        public IActionResult Get()
        {
            return Ok(_repository.Get());
        }

        [HttpGet]
        [Route("book/{id}")]
        public IActionResult Get(Guid id)
        {
            return Ok(_repository.Get(id));
        }

        [HttpPost]
        [Route("book")]
        public async Task<IActionResult> Post([FromBody] RegisterBookCommnad command)
        {
            var result = _handler.Handle(command);
            return await Response(result, _handler.Notifications);
        }

        [HttpPut]
        [Route("book")]
        public async Task<IActionResult> Put([FromBody] UpdateBookCommnad command)
        {
            var result = _handler.Handle(command);
            return await Response(result, _handler.Notifications);
        }

        [HttpPost]
        [Route("bookRemove/{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var deleteBookCommnad = new DeleteBookCommnad();
            deleteBookCommnad.Id = id;
            var result = _handler.Handle(deleteBookCommnad);
            return await Response(result, _handler.Notifications);
        }

    }
}