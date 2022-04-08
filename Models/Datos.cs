using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplicationNetCore.Models
{
    public sealed class Datos
    {
        // The Singleton's instance is stored in a static field. There there are
        // multiple ways to initialize this field, all of them have various pros
        // and cons. In this example we'll show the simplest of these ways,
        // which, however, doesn't work really well in multithreaded program.
        private static Datos _instance;

     
        public List<Producto> Productos;

        // The Singleton's constructor should always be private to prevent
        // direct construction calls with the `new` operator.
        private Datos()
        {
            Productos = new List<Producto>();
            Producto producto1 = new Producto
            {
                IDproducto = "12345",
                Descripcion = "Manzana",
                Precio = "12"
            };
            Productos.Add(producto1);

            Producto producto2 = new Producto
            {
                IDproducto = "12346",
                Descripcion = "Sandia",
                Precio = "30"
            };
            Productos.Add(producto2);

            Producto producto3 = new Producto
            {
                IDproducto = "12347",
                Descripcion = "Uva",
                Precio = "14"
            };
            Productos.Add(producto3);


        }

        // This is the static method that controls the access to the singleton
        // instance. On the first run, it creates a singleton object and places
        // it into the static field. On subsequent runs, it returns the client
        // existing object stored in the static field.
        public static Datos GetInstance()
        {
            if (_instance == null)
            {
                _instance = new Datos();
            }
            return _instance;
        }

        // Finally, any singleton should define some business logic, which can
        // be executed on its instance.
        public static void someBusinessLogic()
        {
            // ...
        }


    }
}

