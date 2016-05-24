using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using gestorPlaces.Nucleo.Persistencia;
using NHibernate;
using NHibernate.Criterion;

namespace gestorPlaces.Nucleo.Entidades
{
    public class Empresa:Persistent
    {
        /// <summary>
        /// un entero llamado id
        /// </summary>
        public override int Id { get; set; }
        /// <summary>
        /// un string llamado nombre
        /// </summary>
        public string Nombre { get; set; }
        /// <summary>
        /// un string llamado telefono
        /// </summary>
        public string Telefono { get; set; }
        /// <summary>
        /// un entero llamado rating
        /// </summary>
        public int Rating { get; set; }
        /// <summary>
        /// un string llamado direccion
        /// </summary>
        public string Direccion { get; set; }
        /// <summary>
        /// un string llamado descripcion
        /// </summary>
        public string Descripcion { get; set; }
        /// <summary>
        /// un cliente de tipo cliente
        /// </summary>

        public Cliente cliente { get; set; }
        /// <summary>
        /// una categoria de tipo categoria
        /// </summary>
        public Categoria categoria { get; set; }

        /// <summary>
        /// obtiene todas las empresas registradas.
        /// </summary>
        /// <returns>una lista de empresas</returns>
        public static IList<Empresa> ObteneTodos()
        {
            IList<Empresa> empresas = new List<Empresa>();
            try
            {
                using (ISession session = Persistent.SessionFactory.OpenSession())
                {
                    ICriteria crit = session.CreateCriteria(new Empresa().GetType());
                    empresas = crit.List<Empresa>();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return empresas;
        }
        /// <summary>
        /// obtiene una empresa con un mismo id
        /// </summary>
        /// <param name="ID">es el parametro de busqueda</param>
        /// <returns>una empresa</returns>
        public static Empresa ObtenerPorID(int ID)
        {
            Empresa empresa = new Empresa();
            try
            {
                using (ISession session = Persistent.SessionFactory.OpenSession())
                {
                    ICriteria criteria = session.CreateCriteria(new Empresa().GetType());
                    criteria.Add(
                    Expression.Eq("id", ID));
                    empresa = criteria.UniqueResult<Empresa>();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return empresa;
        }
        /// <summary>
        /// obtiene las empresas con un mismo cliente
        /// </summary>
        /// <param name="idCliente">parametro de busqueda</param>
        /// <returns>lista de empresas con un mismo cliente</returns>
        public static IList<Empresa> ObtenerPorIdCliente(int idCliente)
        {
            IList<Empresa> empresas = new List<Empresa>();
            try
            {
                using (ISession session = Persistent.SessionFactory.OpenSession())
                {
                    ICriteria criteria = session.CreateCriteria(new Empresa().GetType());
                    criteria.CreateAlias("cliente", "c");
                    criteria.Add(
                    Expression.Eq("c.Id", idCliente));
                    empresas = criteria.List<Empresa>();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return empresas;
        }
        /// <summary>
        /// obtiene una empresa con un mismo cliente
        /// </summary>
        /// <param name="id">identificador de la empresa</param>
        /// <param name="idCliente">identificador de la empresa</param>
        /// <returns>lista de empresas con un mismo cliente</returns>
        public static Empresa ObtenerPorIdClienteYId(int id, int idCliente)
        {
            Empresa empresas = new Empresa();
            try
            {
                using (ISession session = Persistent.SessionFactory.OpenSession())
                {
                    ICriteria criteria = session.CreateCriteria(new Empresa().GetType());
                    criteria.CreateAlias("cliente", "c");
                    criteria.Add(
                    Expression.Eq("Id", id) &&
                    Expression.Eq("c.Id", idCliente));
                    empresas = criteria.UniqueResult<Empresa>();


                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return empresas;
        }

    }
}
