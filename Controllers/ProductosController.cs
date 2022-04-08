using Microsoft.AspNetCore.Mvc;
using System.Linq;
using WebApplicationNetCore.Models;

namespace WebApplicationNetCore.Controllers
{
    public class ProductosController : Controller
    {
        public IActionResult Index()
        {
            var producto = Datos.GetInstance().Productos;
            return View(producto);
        }
    
        public IActionResult AgregarProducto()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AgregarProducto(Producto producto)
        {
            Datos.GetInstance().Productos.Add(producto);

            return View("RegistroExitoso" , producto);
        }
        public IActionResult EditarProducto(string IDprod)
        {
            Producto miProducto = new Producto();
            foreach (Producto producto in Datos.GetInstance().Productos)
            {
                if (producto.IDproducto == IDprod)
                {
                    miProducto = producto;
                    break;
                }
            }

            return View(miProducto);
        }

        [HttpPost]
        public IActionResult EditarProducto(Producto productoEditado)
        {
            // aqui escribimos codigo para editar
            foreach (Producto p in Datos.GetInstance().Productos)
            {
                if (p.IDproducto == productoEditado.IDproducto)
                {
                    p.Descripcion = productoEditado.Descripcion;
                    p.Precio = productoEditado.Precio;
                    break;
                }
            }

            return RedirectToAction("Index");
        }

        public IActionResult EliminarProducto(string idprod)
        {
            Producto miProducto = Datos.GetInstance().Productos.Where(p => p.IDproducto == idprod).FirstOrDefault();

            return View(miProducto);
        }

        [HttpPost]
        public IActionResult EliminarProducto(Producto delProducto)
        {
            Datos.GetInstance().Productos.RemoveAll(pld => pld.IDproducto == delProducto.IDproducto);
            return RedirectToAction("Index");
        }

       
    }
}