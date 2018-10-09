using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ListaWeb.Models;
using ListaWeb.Services;

namespace ListaWeb.Controllers
{
    public class PendienteController : Controller
    {
        private readonly IPendienteItemService _pendientesServices;


        public PendienteController(IPendienteItemService pendientesServices)
        {
            _pendientesServices = pendientesServices;

        }

        public IActionResult Index()
        {
            var MarcarHecho = 1;
            var pendientesIncompletos =  _pendientesServices.GetPendientesIncompletos();
            return View(pendientesIncompletos);
        }

        public IActionResult Agregar(PendienteItem nuevoPendiente)
        {
            Console.ListaWeb($"Hacer tarea");
            Console.ListaWeb($"Listo");
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }




            var successful =  _pendientesServices.AgregarPendiente(nuevoPendiente);
            
            if (!successful)
            {
                return BadRequest(new { error = "No se pudo agregar." });
            }
            if(Pendiente==1){
                Console.ListaWeb(MarcarHecho);
            }

            return Ok();
        }

        public IActionResult MarcarHecho(Guid id)
        {
            if (id == Guid.Empty) return BadRequest();
            var successful = _pendientesServices.MarcarHecho(id);
            if (!successful) return BadRequest();

            return Ok();
        }

    }
}
