internal class Program
{
    static void Main(string[] args)
    {
        var gestorProductos = new GestorProductos();
        var gestorClientes = new GestorClientes();
        var gestorVentas = new GestorVentas(gestorProductos, gestorClientes);

        bool salir = false;
        while (!salir)
        {
            Console.Clear();
            Console.WriteLine("=== SISTEMA DE GESTIÓN DE VENTAS ===");
            Console.WriteLine("1. Gestión de Productos");
            Console.WriteLine("2. Gestión de Clientes");
            Console.WriteLine("3. Gestión de Ventas");
            Console.WriteLine("4. Reportes");
            Console.WriteLine("0. Salir");
            Console.Write("Seleccione una opción: ");

            string opcion = Console.ReadLine();
            switch (opcion)
            {
                case "1": 
                    MenuProductos(gestorProductos); 
                    break;
                case "2": 
                    MenuClientes(gestorClientes); 
                    break;
                case "3": 
                    MenuVentas(gestorVentas, gestorClientes, gestorProductos); 
                    break;
                case "4": 
                    MenuReportes(gestorVentas, gestorClientes, gestorProductos); 
                    break;
                case "0": 
                    salir = true; 
                    break;
                default: 
                    Console.WriteLine("Opción inválida."); Esperar(); 
                    break;
            }
        }
    }

    static void MenuProductos(GestorProductos gp)
    {
        bool salir = false;
        while (!salir)
        {
            Console.Clear();
            Console.WriteLine("=== PRODUCTOS ===");
            Console.WriteLine("1. Agregar");
            Console.WriteLine("2. Listar");
            Console.WriteLine("3. Actualizar");
            Console.WriteLine("4. Eliminar");
            Console.WriteLine("0. Volver");
            Console.Write("Opción: ");
            string opcion = Convert.ToString(Console.ReadLine());
            try
            {
                switch (opcion)
                {
                    case "1":
                        Console.Write("Nombre: "); 
                        string nombre = Convert.ToString(Console.ReadLine());

                        Console.Write("Precio: ");
                        decimal precio = Convert.ToDecimal(Console.ReadLine());

                        Console.Write("Stock: ");
                        int stock = Convert.ToInt32(Console.ReadLine());

                        gp.AgregarProducto(nombre, precio, stock);
                        Console.WriteLine("Producto agregado.");

                        break;
                    case "2":
                        var prods = gp.ListarProductos();

                        if (prods.Count == 0) Console.WriteLine("No hay productos.");
                        else
                            prods.ForEach(pr => Console.WriteLine($"ID: {pr.Id}, Nombre: {pr.Nombre}, Precio: {pr.Precio:C}, Stock: {pr.Stock}"));

                        break;
                    case "3":
                        Console.Write("ID del producto a actualizar: ");
                        if (!int.TryParse(Console.ReadLine(), out int id))
                        {
                            Console.WriteLine("ID inválido.");
                            break;
                        }

                        var productoExistente = gp.ListarProductos().FirstOrDefault(p => p.Id == id);
                        if (productoExistente == null)
                        {
                            Console.WriteLine("Producto no encontrado.");
                            break;
                        }

                        string nuevoNombre = productoExistente.Nombre;
                        decimal nuevoPrecio = productoExistente.Precio;
                        int nuevoStock = productoExistente.Stock;
                        decimal precioIngresado;
                        int stockIngresado;

                     
                        if (QuiereModificar("Nombre", productoExistente.Nombre))
                        {
                            string nombreNuevo;
                            do
                            {
                                Console.Write("Nuevo nombre: ");
                                nombreNuevo = Console.ReadLine();
                                if (!EsTextoValido(nombreNuevo))
                                {
                                    Console.WriteLine("El nombre no puede estar vacío ni contener números. Intente nuevamente.");
                                }
                            } while (!EsTextoValido(nombreNuevo));
                            nuevoNombre = nombreNuevo;
                        }

                       
                        if (QuiereModificar("Precio", productoExistente.Precio.ToString("C")))
                        {
                            Console.Write("Nuevo precio: ");
                            while (!decimal.TryParse(Console.ReadLine(), out precioIngresado) || precioIngresado < 0)
                            {
                                Console.WriteLine("Precio inválido. Ingrese un número decimal positivo.");
                                Console.Write("Nuevo precio: ");
                            }
                            nuevoPrecio = precioIngresado;
                        }

                        
                        if (QuiereModificar("Stock", productoExistente.Stock.ToString()))
                        {
                            Console.Write("Nuevo stock: ");
                            while (!int.TryParse(Console.ReadLine(), out stockIngresado) || stockIngresado < 0)
                            {
                                Console.WriteLine("Stock inválido. Ingrese un número entero no negativo.");
                                Console.Write("Nuevo stock: ");
                            }
                            nuevoStock = stockIngresado;
                        }

                        gp.ActualizarProducto(id, nuevoNombre, nuevoPrecio, nuevoStock);
                        Console.WriteLine("Producto actualizado correctamente.");
                        break;
                    case "4":
                        Console.Write("ID: "); 
                        id = Convert.ToInt32(Console.ReadLine());

                        gp.EliminarProducto(id);
                        Console.WriteLine("Producto eliminado.");

                        break;
                    case "0": 
                        salir = true; 
                        break;
                    default: 
                        Console.WriteLine("Opción inválida."); 
                        break;
                }
            }
            catch (Exception ex) { Console.WriteLine($"Error: {ex.Message}"); }
            if (opcion != "0") Esperar();
        }
    }

    static void MenuClientes(GestorClientes gestionarCliente)
    {
        bool salir = false;
        while (!salir)
        {
            Console.Clear();
            Console.WriteLine("=== CLIENTES ===");
            Console.WriteLine("1. Agregar");
            Console.WriteLine("2. Listar");
            Console.WriteLine("3. Actualizar");
            Console.WriteLine("4. Eliminar");
            Console.WriteLine("0. Volver");
            Console.Write("Opción: ");
            string opcion = Convert.ToString(Console.ReadLine());
            try
            {
                switch (opcion)
                {
                    case "1":
                        string nombre;
                        do
                        {
                            Console.Write("Nombre: ");
                            nombre = Console.ReadLine();
                            if (!EsTextoValido(nombre))
                            {
                                Console.WriteLine("El nombre no puede estar vacío ni contener números. Intente nuevamente.");
                            }
                        } while (!EsTextoValido(nombre));

                        Console.Write("Email: "); 
                        string email = Convert.ToString(Console.ReadLine());

                        gestionarCliente.AgregarCliente(nombre, email);
                        Console.WriteLine("Cliente agregado.");

                        break;
                    case "2":
                        var clientes = gestionarCliente.ListarClientes();

                        if (clientes.Count == 0) Console.WriteLine("No hay clientes.");
                        else
                            clientes.ForEach(c => Console.WriteLine($"ID: {c.Id}, Nombre: {c.Nombre}, Email: {c.Email}"));

                        break;
                    case "3":
                        Console.Write("ID del cliente a actualizar: ");
                        if (!int.TryParse(Console.ReadLine(), out int id))
                        {
                            Console.WriteLine("ID inválido.");
                            break;
                        }

                        var clienteExistente = gestionarCliente.ListarClientes().FirstOrDefault(c => c.Id == id);
                        if (clienteExistente == null)
                        {
                            Console.WriteLine("Cliente no encontrado.");
                            break;
                        }

                        string nuevoNombre = clienteExistente.Nombre;
                        string nuevoEmail = clienteExistente.Email;

                        
                        if (QuiereModificar("Nombre", clienteExistente.Nombre))
                        {
                            string nombreNuevo;
                            do
                            {
                                Console.Write("Nuevo nombre: ");
                                nombreNuevo = Console.ReadLine();
                                if (!EsTextoValido(nombreNuevo))
                                {
                                    Console.WriteLine("El nombre no puede estar vacío ni contener números. Intente nuevamente.");
                                }
                            } while (!EsTextoValido(nombreNuevo));
                            nuevoNombre = nombreNuevo;
                        }

                        
                        if (QuiereModificar("Email", clienteExistente.Email))
                        {
                            string emailNuevo;
                            do
                            {
                                Console.Write("Nuevo email: ");
                                emailNuevo = Console.ReadLine();
                                if (string.IsNullOrWhiteSpace(emailNuevo))
                                {
                                    Console.WriteLine("El email no puede estar vacío.");
                                }
                            } while (string.IsNullOrWhiteSpace(emailNuevo));
                            nuevoEmail = emailNuevo;
                        }

                        gestionarCliente.ActualizarCliente(id, nuevoNombre, nuevoEmail);
                        Console.WriteLine("Cliente actualizado correctamente.");
                        break;
                    case "4":
                        Console.Write("ID: "); 
                        id = Convert.ToInt32(Console.ReadLine());

                        gestionarCliente.EliminarCliente(id);
                        Console.WriteLine("Cliente eliminado.");

                        break;
                    case "0": 
                        salir = true; 
                        break;

                    default: 
                        Console.WriteLine("Opción inválida."); 
                        break;
                }
            }
            catch (Exception ex) { Console.WriteLine($"Error: {ex.Message}"); }
            if (opcion != "0") Esperar();
        }
    }

    static void MenuVentas(GestorVentas gestionarVentas, GestorClientes gestionarClientes, GestorProductos gestionarProductos)
    {
        bool salir = false;
        while (!salir)
        {
            Console.Clear();
            Console.WriteLine("=== VENTAS ===");
            Console.WriteLine("1. Registrar venta");
            Console.WriteLine("2. Ver ventas por cliente");
            Console.WriteLine("3. Ver todas las ventas");
            Console.WriteLine("0. Volver");
            Console.Write("Opción: ");
            string opcion = Convert.ToString(Console.ReadLine());
            try
            {
                switch (opcion)
                {
                    case "1":
                        Console.Write("ID Cliente: "); 
                        int clienteId = Convert.ToInt32(Console.ReadLine());

                        Console.Write("ID Producto: "); 
                        int productoId = Convert.ToInt32(Console.ReadLine());

                        Console.Write("Cantidad: "); 
                        int cantidad = Convert.ToInt32(Console.ReadLine());

                        gestionarVentas.RegistrarVenta(clienteId, productoId, cantidad);
                        Console.WriteLine("Venta registrada exitosamente.");

                        break;
                    case "2":
                        Console.Write("ID Cliente: "); 
                        clienteId = Convert.ToInt32(Console.ReadLine());

                        var ventas = gestionarVentas.ObtenerVentasPorCliente(clienteId);

                        if (ventas.Count == 0) Console.WriteLine("Sin ventas para este cliente.");
                        else
                            ventas.ForEach(v => Console.WriteLine($"Venta {v.Id}: {v.Cantidad} uds x {v.PrecioUnitario:C} = {v.Total:C}"));

                        break;
                    case "3":
                        var todas = gestionarVentas.ObtenerTodasLasVentas();

                        if (todas.Count == 0) Console.WriteLine("No hay ventas.");
                        else
                            todas.ForEach(v => Console.WriteLine($"Venta {v.Id} | Cliente {v.ClienteId} | Producto {v.ProductoId} | Total: {v.Total:C}"));

                        break;
                    case "0": salir = true; break;
                    default: 
                        Console.WriteLine("Opción inválida."); 
                        break;
                }
            }
            catch (Exception ex) { Console.WriteLine($"Error: {ex.Message}"); }
            if (opcion != "0") Esperar();
        }
    }

    static void MenuReportes(GestorVentas gv, GestorClientes gc, GestorProductos gp)
    {
        Console.Clear();
        Console.WriteLine("=== REPORTES ===");
        try
        {
            Console.WriteLine($"Total de ventas: {gv.CalcularTotalVentas():C}\n");

            
            var todasLasVentas = gv.ObtenerTodasLasVentas();

            
            var resumenPorProducto = todasLasVentas
                .GroupBy(v => v.ProductoId)
                .Select(g => new
                {
                    ProductoId = g.Key,
                    CantidadVendida = g.Sum(v => v.Cantidad),
                    PrecioUnitario = g.First().PrecioUnitario
                })
                .ToList();

            if (resumenPorProducto.Count == 0)
            {
                Console.WriteLine("No se han registrado ventas aún.");
            }
            else
            {
                Console.WriteLine("Ventas por producto:");
                Console.WriteLine("ID  | Cantidad Vendida | Precio Unitario");
                Console.WriteLine("----------------------------------------");
                foreach (var item in resumenPorProducto)
                {
                    Console.WriteLine($"{item.ProductoId,-3} | {item.CantidadVendida,-16} | {item.PrecioUnitario:C}");
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error en reporte: {ex.Message}");
        }
        Esperar();
    }

    static void Esperar()
    {
        Console.WriteLine("\nPresione cualquier tecla para continuar...");
        Console.ReadKey();
    }

    static bool EsTextoValido(string texto)
    { 
        if(string.IsNullOrWhiteSpace(texto)) 
            return false;

        foreach (char n in texto)
        {
            if (char.IsDigit(n))
                return false;
        }

        return true;
    }

    static bool QuiereModificar(string campoNombre, string valorActual)
    {
        Console.WriteLine($"{campoNombre} actual: {valorActual}");
        Console.Write($"¿Desea modificarlo? (s/n): ");
        string respuesta = Console.ReadLine()?.Trim().ToLower();
        return respuesta == "s" || respuesta == "si" || respuesta == "sí";
    }
}