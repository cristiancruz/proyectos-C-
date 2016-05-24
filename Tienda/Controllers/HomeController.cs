using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tienda.Models;


namespace Tienda.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {

            return View();
        }

        public ActionResult Compra()
        {
            Mascota mascota = new Mascota();
            mascota.Nombre = "Lucho";
            mascota.Raza = "husky";
            mascota.Descripcion = "Es muy jugueton";
            mascota.Edad = "4 años";
            mascota.Precio = "$2000";


            Vacunas vac1 = new Vacunas();
            Vacunas vac2 = new Vacunas();
            Vacunas vac3 = new Vacunas();

            vac1.NVacuna = "Para rabia";
            vac2.NVacuna = "Para gripe";
            vac3.NVacuna = "Para moquillo";
            List<Vacunas> vacunas = new List<Vacunas>();

            vacunas.Add(vac1);
            vacunas.Add(vac2);
            vacunas.Add(vac3);
            mascota.vacuna = vacunas;

            mascota.VacunasEX = "Ninguna";

            mascota.Nombrep = "Ninguno";
            mascota.Apellidop = "Ninguno";
            mascota.Direccionp = "Ninguna";
            mascota.Telefonop = "Ninguno";

            return View(mascota);
        }

        public ActionResult Tiket() {
            return View();
        }
        public ActionResult Registro()
        {
            return View();
        }
        public ActionResult Guardar(Mascota m)
        {
            if (m.Nombre != null && m.Raza != null && m.Descripcion != null && m.Edad != null && m.Precio != null
                && m.Nombrep != null && m.Apellidop != null && m.Direccionp != null && m.Telefonop != null && m.VacunasEX != null)
            {
                
                return View("Tiket", m);
            }
            else
            {
                ViewBag.Message = "Llene todos los campos ";
                return View("Registro");
            }

        }
    }
}