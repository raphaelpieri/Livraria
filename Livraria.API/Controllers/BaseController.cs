using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Livraria.Infra.Transactions;
using Microsoft.AspNetCore.Mvc;
using FluentValidator;


namespace Livraria.API.Controllers
{
    public class BaseController : Controller
    {
        private readonly IUow _uow;

        public BaseController(IUow uow)
        {
            _uow = uow;
        }

        public async Task<IActionResult> Response(object result, IEnumerable<Notification> notifications)
        {
            if (!notifications.Any())
            {
                try
                {
                    _uow.Commit();
                    return Ok(new
                    {
                        success = true,
                        data = result
                    });
                }
                catch (Exception e)
                {
                    //Elmah
                    return BadRequest(new
                    {
                        success = false,
                        errors = new[] { "Ocorreu uma falha interna no servidor" }
                    });
                }
            }
            else
            {
                return BadRequest(new
                {
                    success = false,
                    errors = notifications
                });
            }
        }
    }
}