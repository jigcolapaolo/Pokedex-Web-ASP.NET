using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Negocio
{
    public class ElementoNegocio
    {
        public List<Elementos> listar()
        {
			List<Elementos> lista = new List<Elementos>();
			AccesoDatos datos = new AccesoDatos();
			try
			{
				datos.setearConsulta("SELECT Id, Descripcion FROM ELEMENTOS");
				datos.ejecutarLectura();

				while (datos.Lector.Read())
				{
					Elementos aux = new Elementos();
					aux.Id = (int)datos.Lector["Id"];
					aux.Descripcion = (string)datos.Lector["Descripcion"];

					lista.Add(aux);
				}

				return lista;
			}
			catch (Exception e)
			{

				throw e;
			}
			finally
			{
				datos.cerrarConexion();
			}
        }
    }
}
