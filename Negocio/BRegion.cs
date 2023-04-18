using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;
using Entidad;

namespace Negocio
{
    public class BRegion
    {
        DRegion datos = new DRegion();

        public List<Region> Listar(string description)
        {

            
            var regiones = datos.Listar();
            var result = regiones.Where(x => x.Description == description
            || string.IsNullOrEmpty(description)
            ).ToList();
            return result;

        }


        public void Insertar(Region region)
        {
            try
            {
                var regiones=datos.Listar();                
                var max= regiones.Select(x=>x.IdRegion).Max();
                region.IdRegion = max+1;

                datos.Insertar(region);
            }
            catch (Exception ex)
            {

                throw ex;
            }
            
        }
    }
}
