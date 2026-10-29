using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

    public class GestorVentas
    {
        private Dictionary<int, List<Venta>> ventasPorcliente = new Dictionary<int, List<Venta>>();
        private int ultimoID = 0;
        private readonly GestorProductos gestorProductos;
        private readonly GestorClientes gestorClientes;

        public GestorVentas(GestorProductos gestorProductos, GestorClientes gestorClientes)
        {
            this.gestorProductos = gestorProductos ?? throw new ArgumentNullException(nameof(gestorProductos));
            this.gestorClientes = gestorClientes ?? throw new ArgumentNullException(nameof(gestorClientes));
        }

        public void RegistrarVenta(int clienteId, int productoId, int cantidad)
        {

            gestorClientes.ObtenerCliente(clienteId);

            if (!gestorProductos.HayStock(productoId, cantidad))
                throw new InvalidOperationException("Stock insuficiente para realizar la venta.");

            var producto = gestorProductos.ObtenerProducto(productoId);
            var venta = new Venta(++ultimoID, clienteId, productoId, cantidad, producto.Precio);

            if (!ventasPorcliente.ContainsKey(clienteId))
                ventasPorcliente[clienteId] = new List<Venta>();
            ventasPorcliente[clienteId].Add(venta);

            gestorProductos.ReducirStock(productoId, cantidad);
        }

        public List<Venta> ObtenerVentasPorCliente(int clienteId)
        {
            if (!ventasPorcliente.ContainsKey(clienteId))
                return new List<Venta>();
            return new List<Venta>(ventasPorcliente[clienteId]);
        }

        public List<Venta> ObtenerTodasLasVentas() =>
            ventasPorcliente.Values.SelectMany(v => v).ToList();

        public decimal CalcularTotalVentas() =>
            ObtenerTodasLasVentas().Sum(v => v.Total);
    }
