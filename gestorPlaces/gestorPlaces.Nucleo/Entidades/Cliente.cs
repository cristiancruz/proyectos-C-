using gestorPlaces.Nucleo.Persistencia;
using NHibernate;
using NHibernate.Criterion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gestorPlaces.Nucleo.Entidades
{
    public class Cliente:Persistent

    {
        /// <summary>
        /// un entero nombrado id
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
        /// un boleano tarifa
        /// </summary>
        public double Tarifa { get; set; }
        /// <summary>
        /// un string llamado pago
        /// </summary>
        public string Pago { get; set; }
        /// <summary>
        /// un string llamado fecha de pago
        /// </summary>
        public string FechaDePago { get; set; }

        /// <summary>
        /// obtiene todos los clientes registrados
        /// </summary>
        /// <returns>una lista de clientes</returns>
        public static IList<Cliente> ObteneTodos()
        {
            IList<Cliente> clientes = new List<Cliente>();
            try
            {
                using (ISession session = Persistent.SessionFactory.OpenSession())
                {
                    ICriteria crit = session.CreateCriteria(new Cliente().GetType());
                    clientes = crit.List<Cliente>();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return clientes;
        }

        /// <summary>
        /// obtiene un cliente
        /// </summary>
        /// <param name="ID">es el identificador a buscar</param>
        /// <returns>un cliente</returns>
        public static Cliente ObtenerPorID(int ID)
        {
            Cliente cliente = new Cliente();
            try
            {
                using (ISession session = Persistent.SessionFactory.OpenSession())
                {
                    ICriteria criteria = session.CreateCriteria(new Cliente().GetType());
                    criteria.Add(
                    Expression.Eq("id", ID));
                    cliente = criteria.UniqueResult<Cliente>();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return cliente;
        }
        /// <summary>
        /// obtiene los clientes que coincidan con un mismo nombre
        /// </summary>
        /// <param name="nombre">es el identificador de busqueda</param>
        /// <returns>una lista de clientes con el mismo nombre</returns>
        public static IList<Cliente> ObtenerPorNombre(String nombre)
        {
            IList<Cliente> listaClientes = new List<Cliente>();

            try
            {
                using (ISession session = Persistent.SessionFactory.OpenSession())
                {
                    ICriteria criteria = session.CreateCriteria<Cliente>();
                    criteria.Add(
                    Expression.Like("Nombre", nombre, MatchMode.Anywhere));
                    listaClientes = criteria.List<Cliente>();

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return listaClientes;
        }
    }
}
