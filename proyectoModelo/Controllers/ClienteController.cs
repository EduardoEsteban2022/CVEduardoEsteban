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
        // Listado de clientes
        // GET: Cliente
        public ActionResult Index()
        {
            ClienteUtility CliRepo = new ClienteUtility();
            ModelState.Clear();
            return View(CliRepo.obtenerCLientes());
        }
      
        //Funciones para agregar clientes        
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


        //Funciones para Editar clientes

        public ActionResult EditarCliente(int id)
        {
            ViewBag.msg = TempData["msg"] as String;

            ClienteUtility cli = new ClienteUtility();

            return View(cli.obtenerCLientes().Find(x => x.id == id));
        }

        [HttpPost]
        public ActionResult EditarCliente(int id, ClienteModelo cli)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    ClienteUtility cliF = new ClienteUtility();

                    cliF.EditarCliente(cli);
                    
                    // ViewBag.Message = "Cliente Editado con Exito!";

                    TempData["msg"]="Cliente Editado con Exito";
                                    
                }

                return RedirectToAction("EditarCliente");
            }
            catch
            {
                return View();

            }

        }


        //funcion para eliminar clientes
        public ActionResult EliminarCliente(int id)
        {

            try { 

                 ClienteUtility cli = new ClienteUtility();

                if (cli.EliminarCliente(id))
                {
                    ViewBag.AlertMsg = "Datos del cliente eliminados";

                }
                return RedirectToAction("Index");

            }
            catch
            {
                return View();
            }
        }


    }

    }
