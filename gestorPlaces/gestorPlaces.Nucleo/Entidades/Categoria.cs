using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using gestorPlaces.Nucleo.Persistencia;
using NHibernate.Criterion;

namespace gestorPlaces.Nucleo.Entidades
{
    public class Categoria:Persistent
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
        /// obtiene todas las categorias existentes.
        /// </summary>
        /// <returns>una lista de categorias</returns>
        public static IList<Categoria> ObteneTodos()
        {
            IList<Categoria> categorias = new List<Categoria>();
            try
            {
                using (ISession session = Persistent.SessionFactory.OpenSession())
                {
                    ICriteria crit = session.CreateCriteria(new Categoria().GetType());
                    categorias = crit.List<Categoria>();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return categorias;
        }
        /// <summary>
        /// obtiene las categorias por un tipo de filtro
        /// </summary>
        /// <param name="ID"> es el identificador de cada categoria</param>
        /// <returns>una lista de categorias</returns>
        public static Categoria ObtenerPorID(int ID)
        {
            Categoria categoria = new Categoria();
            try
            {
                using (ISession session = Persistent.SessionFactory.OpenSession())
                {
                    ICriteria criteria = session.CreateCriteria(new Categoria().GetType());
                    criteria.Add(
                    Expression.Eq("id", ID));
                    categoria = criteria.UniqueResult<Categoria>();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return categoria;
        }
    }
}
