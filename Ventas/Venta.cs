using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

    public class Venta
    {
        public int Id { get; set; }
        public int ClienteId { get; set; }
        public int ProductoId { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }

        public Venta(int id, int clienteId, int productoId, int cantidad, decimal precioUnitario)
        {
            Id = id;
            ClienteId = clienteId;
            ProductoId = productoId;
            Cantidad = cantidad;
            PrecioUnitario = precioUnitario;
        }

        public decimal Total => Cantidad * PrecioUnitario;
    }
