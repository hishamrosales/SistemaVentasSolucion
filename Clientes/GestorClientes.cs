using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

    public class GestorClientes
    {
        private List<Cliente> clientes = new List<Cliente>();
        private int ultimoID = 0;

        public void AgregarCliente(string nombre, string email)
        {
            clientes.Add(new Cliente(++ultimoID, nombre, email));
        }

        public Cliente ObtenerCliente(int id)
        {
            var cliente = clientes.FirstOrDefault(c => c.Id == id);
            if (cliente == null) throw new KeyNotFoundException($"Cliente con ID {id} no existe.");
            return cliente;
        }

        public void ActualizarCliente(int id, string nombre, string email)
        {
            var cliente = ObtenerCliente(id);
            cliente.Nombre = nombre ?? throw new ArgumentNullException(nameof(nombre));
            cliente.Email = email ?? throw new ArgumentNullException(nameof(email));
        }

        public void EliminarCliente(int id)
        {
            var cliente = ObtenerCliente(id);
            clientes.Remove(cliente);
        }

        public List<Cliente> ListarClientes() => new List<Cliente>(clientes);
    }

