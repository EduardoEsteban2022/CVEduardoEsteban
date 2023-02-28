using proyectoModelo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace proyectoModelo.Controllers
{
    public class ClienteController : Controller
    {
        // GET: Cliente
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AgregarCliente()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AgregarCliente(ClienteModelo Cli)
        {
            try
            {
                if (ModelState.IsValid)
                {
                   ClienteUtility cliU = new ClienteUtility();

                    if (cliU.AgregarCliente(Cli))
                    {
                        ViewBag.Message = "Empleado Agregado con Exito!";
                    }

                    else
                    {
                        ViewBag.Message = "Error al agregar empleado!";
                    }
                }

                return View();
            }
            catch
            {
                return View();
            }

        }


    }
}