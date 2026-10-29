using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

    public class Producto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public decimal Precio { get; set; }
        public int Stock { get; set; }

        public Producto(int id, string nombre, decimal precio, int stock)
        {
            if (precio < 0) throw new ArgumentException("El precio no puede ser negativo.");
            if (stock < 0) throw new ArgumentException("El stock no puede ser negativo.");

            Id = id;
            Nombre = nombre ?? throw new ArgumentNullException(nameof(nombre));
            Precio = precio;
            Stock = stock;
        }
    }

