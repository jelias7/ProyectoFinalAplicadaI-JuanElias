using DAL;
using Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class VentaBLL
    {
        public static bool Guardar(Ventas venta)
        {
            bool paso = false;
            RepositorioBase<Productos> prod = new RepositorioBase<Productos>();
            Contexto db = new Contexto();
            try
            {
                if (db.Ventas.Add(venta) != null)
                {
                    foreach (var item in venta.Detalle)
                    {
                        var producto = prod.Buscar(item.ProductoId);
                        producto.Cantidad -= item.Cantidad;
                        prod.Modificar(producto);
                    }
                    paso = db.SaveChanges() > 0;
                }

            }
            catch (Exception)
            {
                throw;
            }
            return paso;
        }
        public static bool Eliminar(int id)
        {
            bool paso = false;
            Contexto db = new Contexto();
            RepositorioBase<Productos> prod = new RepositorioBase<Productos>();
            try
            {
                var venta = db.Ventas.Find(id);
                foreach (var item in venta.Detalle)
                {
                    var producto = prod.Buscar(item.ProductoId);
                    producto.Cantidad += item.Cantidad;
                    prod.Modificar(producto);
                }
                db.Entry(venta).State = EntityState.Deleted;
                paso = (db.SaveChanges() > 0);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }
            return paso;
        }

 
    }
}
