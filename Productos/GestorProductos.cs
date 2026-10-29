using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


    public class GestorProductos
    {
        private List<Producto> catalogo = new List<Producto>();
        private int ultimoID = 0;

        public void AgregarProducto(string nombre, decimal precio, int stock)
        {
            var nuevo = new Producto(++ultimoID, nombre, precio, stock);
            catalogo.Add(nuevo);
        }

        public Producto ObtenerProducto(int id)
        {
            var producto = catalogo.FirstOrDefault(p => p.Id == id);
            if (producto == null) throw new KeyNotFoundException($"Producto con ID {id} no encontrado.");
            return producto;
        }

        public void ActualizarProducto(int id, string nombre, decimal precio, int stock)
        {
            var producto = ObtenerProducto(id);
            if (precio < 0) throw new ArgumentException("Precio no puede ser negativo.");
            if (stock < 0) throw new ArgumentException("Stock no puede ser negativo.");

            producto.Nombre = nombre ?? throw new ArgumentNullException(nameof(nombre));
            producto.Precio = precio;
            producto.Stock = stock;
        }

        public void EliminarProducto(int id)
        {
            var producto = ObtenerProducto(id);
            catalogo.Remove(producto);
        }

        public List<Producto> ListarProductos() => new List<Producto>(catalogo);

        public bool HayStock(int id, int cantidad)
        {
            var producto = ObtenerProducto(id);
            return producto.Stock >= cantidad;
        }

        public void ReducirStock(int id, int cantidad)
        {
            var producto = ObtenerProducto(id);
            if (producto.Stock < cantidad)
                throw new InvalidOperationException("Stock insuficiente.");
            producto.Stock -= cantidad;
        }
    }

