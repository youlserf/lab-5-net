using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;
using Entidad;

namespace Negocio
{
    public class BProduct
    {
        DProduct datos = new DProduct();

        public List<Product> Listar(string name)
        {

            
            var products = datos.Listar(name);
            /*
            var result = Productes.Where(x => x.Description == description
            || string.IsNullOrEmpty(description)
            ).ToList();
            */
            return products;

        }

        
        public void Insertar(Product Product)
        {
            try
            {
                //var Productes=datos.Listar();                
                //var max= Productes.Select(x=>x.IdProduct).Max();
                //Product.IdProduct = max+1;

                datos.Insertar(Product);
            }
            catch (Exception ex)
            {

                throw ex;
            }
            
        }
        
    }
}
