using DAL;
using Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BLL
{
    public class InventarioBLL
    {
        public static bool Guardar(Inventarios i)
        {
            bool paso = false;
            Contexto db = new Contexto();
            try
            {

                RepositorioBase<Productos> prod = new RepositorioBase<Productos>();


                if (db.Inventarios.Add(i) != null)
                {
                    var producto = prod.Buscar(i.ProductoId);
                    producto.Cantidad = producto.Cantidad + i.Cantidad;
                    prod.Modificar(producto);

                    paso = db.SaveChanges() > 0;

                }

            }
            catch (Exception)
            {
                throw;
            }

            return paso;
        }

        public static bool Modificar(Inventarios entrada)
        {
            bool paso = false;
            Contexto db = new Contexto();
            RepositorioBase<Productos> prod = new RepositorioBase<Productos>();
            RepositorioBase<Inventarios> entr = new RepositorioBase<Inventarios>();

            try
            {

                var anterior = entr.Buscar(entrada.InventarioId);
                var producto = prod.Buscar(entrada.ProductoId);

                producto.Cantidad = producto.Cantidad + (entrada.Cantidad - anterior.Cantidad);
                prod.Modificar(producto);


                db.Entry(entrada).State = EntityState.Modified;

                paso = db.SaveChanges() > 0;


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
            RepositorioBase<Inventarios> entr = new RepositorioBase<Inventarios>();



            try
            {

                var entrada = entr.Buscar(id);
                var producto = prod.Buscar(entrada.ProductoId);

                producto.Cantidad = producto.Cantidad - entrada.Cantidad;
                prod.Modificar(producto);

                db.Entry(entrada).State = EntityState.Deleted;
                paso = (db.SaveChanges() > 0);
            }
            catch (Exception)
            {
                MessageBox.Show("No existe");
            }
            finally
            {
                db.Dispose();
            }
            return paso;
        }
    }
}
