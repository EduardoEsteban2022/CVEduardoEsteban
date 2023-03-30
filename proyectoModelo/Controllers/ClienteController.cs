using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using proyectoModelo.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
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
            ViewBag.msg = TempData["msg"] as String;
            ViewBag.tip = TempData["tip"] as String;

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

                    bool resp = cliU.AgregarCliente(Cli);

                    if (resp == true)
                    {
                        TempData["msg"] = "Cliente Creado con Exito";
                        TempData["tip"] = "success";

                        return RedirectToAction("AgregarCliente");
                    }

                    else
                    {
                        TempData["msg"] = "Error al crear Cliente";
                        TempData["tip"] = "error";

                        return RedirectToAction("AgregarCliente");
                    }
                }

                TempData["msg"] = "Error al crear Cliente";
                TempData["tip"] = "error";
                return RedirectToAction("AgregarCliente");
              

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
            ViewBag.tip = TempData["tip"] as String;

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

                    bool resp = cliF.EditarCliente(cli);

                    if (resp == true)
                    {

                        TempData["msg"] = "Cliente Editado con Exito";
                        TempData["tip"] = "success";

                        return RedirectToAction("EditarCliente");

                    }


                    else
                    {
                        TempData["msg"] = "Error al Editar Cliente";
                        TempData["tip"] = "error";

                        return RedirectToAction("EditarCliente");

                    }

                }

                TempData["msg"] = "Error al Editar Cliente";
                TempData["tip"] = "error";

                return RedirectToAction("EditarCliente");

            }
            catch
            {
                return View();

            }

        }


        public ActionResult EliminarCliente(int id)
        {

            ViewBag.msg = TempData["msg"] as String;
            ViewBag.tip = TempData["tip"] as String;

            ClienteUtility cli = new ClienteUtility();

            return View(cli.obtenerCLientes().Find(x => x.id == id));
        }




       /// funcion para eliminar clientes
        [HttpPost, ActionName("EliminarCliente") ]
        public ActionResult ConfirmarEliminarCliente(int id)
        {

            try
            {

                ClienteUtility cli = new ClienteUtility();

                if (cli.EliminarCliente(id))
                {
                    TempData["msg"] = "Datos del cliente eliminados";
                    TempData["tip"] = "success";
                    return RedirectToAction("EliminarCliente");
                }


                else
                {
                    TempData["msg"] = "Error al eliminar Cliente";
                    TempData["tip"] = "error";
                    return RedirectToAction("EliminarCliente");
                }
            }
            catch
            {
                return View();
            }
        }




        public ActionResult GenerarPdf()
        {
            List<ClienteModelo> dt = new List<ClienteModelo>();
            ClienteUtility f = new ClienteUtility();

            dt = f.obtenerCLientes();


            ReportDocument report = new ReportDocument();
            report.Load(Server.MapPath("~/Rpt/Clientes.rpt"));
            report.SetDataSource(dt);

            Response.Buffer = false;
            Response.ClearContent();
            Response.ClearHeaders();

            // Pasar los parámetros necesarios al procedimiento almacenado
            //report.SetParameterValue("myParameter", "myValue");

            // Ejecutar el procedimiento almacenado y obtener los datos resultantes


            Stream stream = report.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);

            stream.Seek(0, SeekOrigin.Begin);

            return File(stream, "application/pdf", "CustomerList.pdf");

        }




        }

    }
