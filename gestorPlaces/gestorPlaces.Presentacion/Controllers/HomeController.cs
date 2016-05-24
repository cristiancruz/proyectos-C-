using gestorPlaces.Nucleo.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace gestorPlaces.Presentacion.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        /// <summary>
        /// Hace referencia a la Primer vista, en este caso el login que se va a ejecutar al iniciar el sistema.
        /// </summary>
        /// <returns>La vista Index </returns>
        public ActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// Hace referencia a la vista Clientes que se va a ejecutar al ser llamada.
        /// </summary>
        /// <returns>La vista Clientes</returns>
        public ActionResult Clientes()
        {
            return View();
        }
        /// <summary>
        ///  Hace referencia a la vista Estadisticas que se va a ejecutar al ser llamada.
        /// </summary>
        /// <returns>La vista Estadisticas</returns>
        public ActionResult Estadisticas()
        {
            return View();
        }
        /// <summary>
        ///  Hace referencia a la vista Empresa que se va a ejecutar al ser llamada.
        /// </summary>
        /// <returns>La vista empresas</returns>
        public ActionResult Empresas()
        {

            @ViewBag.resetEmpresa = false;
            @ViewBag.mostrarEmpresa = false;
           return View();
        }
        /// <summary>
        ///  Hace referencia a la vista Reportes que se va a ejecutar al ser llamada.
        /// </summary>
        /// <returns>la vista Reportes</returns>
        public ActionResult Reportes()
        {
            return View();
        }

        /// <summary>
        /// Permite dar de alta un registro  con la informacion relacionada con el cliente como nombre,telefono,tarifa,pago y fecha de pago.
        /// </summary>
        /// <param name="cliente">Representa el objeto cliente con su informacion.</param>
        /// <param name="pago">rRepresenta si se pago o no se pago el derecho a permanecer dado de alta.</param>
        /// <returns>true o false hacia la vista Clientes</returns>
        public ActionResult Guardar(Cliente cliente, string pago)
        {
            cliente.Pago = pago;
            cliente.Save();
            return View("clientes");
        }
        /// <summary>
        /// Permite eliminar algun registro de la base de datos de tipo cliente.
        /// </summary>
        /// <param name="id">Es el parametro por el cual se identifica el registro a eliminar</param>
        /// <returns>true o false hacia la vista Clientes</returns>
        public ActionResult Eliminar(int id)
        {
            Cliente cliente = new Cliente();
            cliente = Cliente.ObtenerPorID(id);
            cliente.Delete();
            return View("clientes");
        }
        /// <summary>
        /// Permite editar algun registro de la base de datos de tipo cliente.
        /// </summary>
        /// <param name="id">Es el parametro por el cual se identifica el registro a editar</param>
        /// <returns> la vista clientes con objetos de tipo clientes</returns>
        public ActionResult Editar(int id)
        {
            Cliente cliente = new Cliente();
            @ViewBag.editar = true;
            cliente = Cliente.ObtenerPorID(id);
            return View("clientes", cliente);
        }
        /// <summary>
        /// Permite gestionar cambios en la informacion del cliente.
        /// </summary>
        /// <param name="cliente">representa el objeto con la informacion del cliente</param>
        /// <returns>true o false hacia la vista clientes</returns>
        public ActionResult GuardarCambios(Cliente cliente)
        {
            cliente.Update();
            return View("clientes");
        }
        /// <summary>
        /// Permite dar de alta una empresa en la base de datos.
        /// </summary>
        /// <param name="empresa">representa el objeto empresa con su informacion de nombre, direccion,descripcion y telefono</param>
        /// <param name="idCliente">hace referencia a un cliente previamente registrado</param>
        /// <param name="idCategoria">hace referencia a una categoria previamente registrada</param>
        /// <returns> true o false hacia la vista empresas.</returns>
        public ActionResult GuardarEmpresa(Empresa empresa, int idCliente, int idCategoria)
        {

            empresa.categoria = Categoria.ObtenerPorID(idCategoria);
            empresa.cliente = Cliente.ObtenerPorID(idCliente);
            empresa.Save();
            return View("empresas");
        }
        /// <summary>
        /// Permite obtener las empresas con su informacion.
        /// </summary>
        /// <param name="Id">representa el identificador de cada objeto empresa.</param>
        /// <returns>la vista empresa con objetos de tipo empresa.</returns>
        public ActionResult MostrarEmpresa(int Id) {
            Empresa empresa = new Empresa();
            @ViewBag.mostrarEmpresa = true;
            empresa = Empresa.ObtenerPorID(Id);
            return View("empresas",empresa);

        }
        /// <summary>
        /// Permite editar la informacion de alguna empresa seleccionada.
        /// </summary>
        /// <param name="empresa">representa el objeto empresa con su informacion como nombre, telefono, etc</param>
        /// <param name="idCliente">hace referencia a un cliente previamente registrado</param>
        /// <param name="idCategoria">hace referencia a una categoria previamente registrada</param>
        /// <returns>la vista empresas</returns>
        public ActionResult EditarEmpresa(Empresa empresa, int idCliente, int idCategoria)
        {

            empresa.categoria = Categoria.ObtenerPorID(idCategoria);
            empresa.cliente = Cliente.ObtenerPorID(idCliente);
            empresa.Update();
            return View("empresas");
        }
        /// <summary>
        /// Permite eliminar una empresa seleccionada.
        /// </summary>
        /// <param name="id">Es el parametro por el cual se identifica el registro a eliminar</param>
        /// <returns>vista empresas</returns>
        public ActionResult EliminarEmpresa(int id)
        {
            Empresa empresa = new Empresa();
            empresa = Empresa.ObtenerPorID(id);
            empresa.Delete();
            return View("empresas");
        }
        /// <summary>
        /// Permite vaciar los formularios  de empresa despues de haber sido llenados
        /// </summary>
        /// <returns>vista empresa con objetos de tipo empresa</returns>
        public ActionResult ResetEmpresa() {
            Empresa empresa = new Empresa();
            @ViewBag.resetEmpresa = true;
            return View("empresas", empresa);
        
        }
        /// <summary>
        /// Permite vaciar los formularios de clientes despues de haber sido llenados
        /// </summary>
        /// <returns>la vista clientes con objetos de tipo cliente</returns>
        public ActionResult ResetCliente()
        {
            Cliente cliente = new Cliente();
            @ViewBag.resetCliente = true;
            return View("clientes", cliente);

        }
        /// <summary>
        /// Permite buscar todas las empresas que estan registradas y ordenarlas.
        /// </summary>
        /// <param name="id">Es el identificador de la empresa</param>
        /// <param name="radios">Representa si fue seleccionado un elemento tipo radiobutons para especificar un tipo de busqueda</param>
        /// <returns> los clientes encontrados</returns>
        public JsonResult buscarEmpresas(int id, bool radios)
        {
            List<Empresa> listaEmpresa = Empresa.ObtenerPorIdCliente(id).ToList();
            List<Empresa> listaOrdenada;
            if (radios)
            {
                listaOrdenada = listaEmpresa.OrderBy(o => o.Nombre).ToList();

            }
            else
            {
                listaOrdenada = listaEmpresa.OrderByDescending(o => o.Nombre).ToList();
            }

            //int X = 0;
            return Json(listaOrdenada, JsonRequestBehavior.AllowGet);

            }
        /// <summary>
        /// Permite buscar todos los clientes que estan registrados.
        /// </summary>
        /// <param name="id">Es el identificador de cada empresa con un mismo cliente.</param>
        /// <param name="idCliente">Es el identificador de cada cliente</param>
        /// <returns>todos los clientes que pertenecen a una misma empresa</returns>
            public JsonResult buscarClientes(int id, int idCliente)
            {
                Empresa empresa = Empresa.ObtenerPorIdClienteYId(id, idCliente);
                Cliente cliente = empresa.cliente;

                return Json(cliente, JsonRequestBehavior.AllowGet);

            }
        /// <summary>
            /// Permite buscar todos los clientes que estan registrados.
        /// </summary>
        /// <param name="nombre"> es el nombre del cliente</param>
        /// <returns>todos los clientes encontrados</returns>
            public JsonResult buscarCliente(String nombre)
            {
                List<Cliente> listaEmpresa = Cliente.ObtenerPorNombre(nombre).ToList();

                return Json(listaEmpresa, JsonRequestBehavior.AllowGet);

            }
        


    }

}