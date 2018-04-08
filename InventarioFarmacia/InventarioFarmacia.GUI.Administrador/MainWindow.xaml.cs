using InventarioFarmacia.BIZ;
using InventarioFarmacia.COMMON.Entidades;
using InventarioFarmacia.COMMON.Interfaces;
using InventarioFarmacia.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace InventarioFarmacia.GUI.Administrador
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        enum accion
        {
            Nuevo,
            Editar
        }
        List<Venta> venta;
        IManejadorEmpleado ManejadorEmpleados;
        IManejadorProducto ManejadorProductos;
        IManejadorCliente ManejadorClientes;
        IManejadorTick manejadorTick;

        accion accionEmpleados;
        accion accionProductos;
        accion accionClientes;

        public MainWindow()
        {
            InitializeComponent();
            ManejadorEmpleados = new ManejadorEmpleado(new RepositorioEmpleado());
            ManejadorProductos = new ManejadorProducto(new RepositorioProducto());
            ManejadorClientes = new ManejadorCliente(new RepositorioCliente());
            manejadorTick = new ManejadorTicket(new RepositorioTick());

            venta = new List<Venta>();
            BotonesEmpleadoEdicion(false);
            LimpiarCamposEmpleados();
            ActualizarTablaEmpleados();

            BotonesProductoEdicion(false);
            LimpiarCamposProducto();
            ActualizarTablaProductos();

            BotonesClientesEdicion(false);
            LimpiarCamposClientes();
            ActualizarTablaClientes();

            BotonesVentasEdicion(false);
            CargarTablas();

            HabilitarCamposDeVenta(false);

            TablaEnInventario();
            HabilitarCamposAlmacen(false);
        }

        private void TablaEnInventario()
        {
           dtgAlmacen.ItemsSource = null;
           dtgAlmacen.ItemsSource = manejadorTick.Listar;
        }

        private void HabilitarCamposDeVenta(bool v)
        {
            txtCantidad.IsEnabled = v;
            cmbClienteVenta.IsEnabled = v;
            cmbEmpleadoVenta.IsEnabled = v;
            txtFolioVenta.IsEnabled = v;
        }

        private void BotonesVentasEdicion(bool value)
        {
            btnAgregarVenta.IsEnabled = value;
            btnEliminarVenta.IsEnabled = value;
            btnCancelarVenta.IsEnabled = value;
            btnVEntaVenta.IsEnabled = value;
            btnNuevaVenta.IsEnabled = !value;
        }

        private void ActualizarTablaClientes()
        {
            dtgClientes.ItemsSource = null;
            dtgClientes.ItemsSource = ManejadorClientes.Listar;
        }

        private void LimpiarCamposClientes()
        {
            txbClienteNombre.Clear();
            txbClienteApellidos.Clear();
            txbClienteDireccion.Clear();
            txbClienteRFC.Clear();
            txbClienteTelefono.Clear();
            txbClienteCorreo.Clear();
            txbClienteId.Text = "";
        }

        private void BotonesClientesEdicion(bool value)
        {
            btnClienteCancelar.IsEnabled = value;
            btnClienteEditar.IsEnabled = !value;
            btnClienteEliminar.IsEnabled = !value;
            btnClienteGuardar.IsEnabled = value;
            btnClienteNuevo.IsEnabled = !value;
        }

        private void ActualizarTablaProductos()
        {
            dtgProductos.ItemsSource = null;
            dtgProductos.ItemsSource = ManejadorProductos.Listar;
        }

        private void LimpiarCamposProducto()
        {
            txbProductoNombre.Clear();
            txbProductoCategoria.Clear();
            txbProductoDescripcion.Clear();
            txbProductoCompra.Clear();
            txbProductoVenta.Clear();
            txbProductoCantidad.Clear();
            txbProductoId.Text = "";
        }

        private void BotonesProductoEdicion(bool value)
        {
            btnProductoCancelar.IsEnabled = value;
            btnProductoEditar.IsEnabled = !value;
            btnProductoEliminar.IsEnabled = !value;
            btnProductoGuardar.IsEnabled = value;
            btnProductoNuevo.IsEnabled = !value;
        }

        private void ActualizarTablaEmpleados()
        {
            dtgEmpleados.ItemsSource = null;
            dtgEmpleados.ItemsSource = ManejadorEmpleados.Listar;
        }

        private void LimpiarCamposEmpleados()
        {
            txbEmpleadoApellidos.Clear();
            txbEmpleadoId.Text = "";
            txbEmpleadoNombre.Clear();
        }

        private void BotonesEmpleadoEdicion(bool value)
        {
            btnEmpleadoCancelar.IsEnabled = value;
            btnEmpleadoEditar.IsEnabled = !value;
            btnEmpleadoEliminar.IsEnabled = !value;
            btnEmpleadoGuardar.IsEnabled = value;
            btnEmpleadoNuevo.IsEnabled = !value;
        }

        private void btnEmpleadoNuevo_Click(object sender, RoutedEventArgs e)
        {
            LimpiarCamposEmpleados();
            BotonesEmpleadoEdicion(true);
            accionEmpleados = accion.Nuevo;
        }

        private void btnEmpleadoEditar_Click(object sender, RoutedEventArgs e)
        {
            Empleado emp = dtgEmpleados.SelectedItem as Empleado;
            if (emp !=null)
            {
                txbEmpleadoId.Text = emp.Id;
                txbEmpleadoApellidos.Text = emp.ApellidosEmpleado;
                txbEmpleadoNombre.Text = emp.NombreEmpleado;
                accionEmpleados = accion.Editar;
                BotonesEmpleadoEdicion(true);
            }
        }

        private void btnEmpleadoGuardar_Click(object sender, RoutedEventArgs e)
        {
            if (accionEmpleados == accion.Nuevo)
            {
                Empleado emp = new Empleado()
                {
                    NombreEmpleado = txbEmpleadoNombre.Text,
                    ApellidosEmpleado = txbEmpleadoApellidos.Text
                };
                if (ManejadorEmpleados.Agregar(emp))
                {
                    MessageBox.Show("Empleado agregado correctamente", "inventarios", MessageBoxButton.OK, MessageBoxImage.Information);
                    LimpiarCamposEmpleados();
                    ActualizarTablaEmpleados();
                    BotonesEmpleadoEdicion(false);
                }
                else
                {
                    MessageBox.Show("El empleado no pudo ser agregado", "inventarios", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                Empleado emp = dtgEmpleados.SelectedItem as Empleado;
                emp.ApellidosEmpleado = txbEmpleadoApellidos.Text;
                emp.NombreEmpleado = txbEmpleadoNombre.Text;
                if (ManejadorEmpleados.Modificar(emp))
                {
                    MessageBox.Show("Empleado modificado correctamente", "inventarios", MessageBoxButton.OK, MessageBoxImage.Information);
                    LimpiarCamposEmpleados();
                    ActualizarTablaEmpleados();
                    BotonesEmpleadoEdicion(false);
                }
                else
                {
                    MessageBox.Show("El empleado no pudo ser actualizado", "inventarios", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void btnEmpleadoCancelar_Click(object sender, RoutedEventArgs e)
        {
            LimpiarCamposEmpleados();
            BotonesEmpleadoEdicion(false);
        }

        private void btnEmpleadoEliminar_Click(object sender, RoutedEventArgs e)
        {
            Empleado emp = dtgEmpleados.SelectedItem as Empleado;
            if (emp!=null)
            {
                if(MessageBox.Show("Realmente desea eliminar este empleado?", "Inventarios", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    if (ManejadorEmpleados.Eliminar(emp.Id))
                    {
                        MessageBox.Show("Empleado eliminado", "Inventarios", MessageBoxButton.OK, MessageBoxImage.Information);
                        ActualizarTablaEmpleados();
                    }
                    else
                    {
                        MessageBox.Show("No se pudo eliminar el empleado", "Inventarios", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                }
            }
        }

        private void btnProductoNuevo_Click(object sender, RoutedEventArgs e)
        {
            LimpiarCamposProducto();
            BotonesProductoEdicion(true);
            accionProductos = accion.Nuevo;
        }

        private void btnProductoEditar_Click(object sender, RoutedEventArgs e)
        {
            LimpiarCamposProducto();
            accionProductos = accion.Editar;
            BotonesProductoEdicion(true);
            Producto prod = dtgProductos.SelectedItem as Producto;
            if (prod!=null)
            {
                txbProductoCantidad.Text = prod.Cantidad;
                txbProductoCategoria.Text = prod.Categoria;
                txbProductoCompra.Text = prod.PrecioCompra;
                txbProductoDescripcion.Text = prod.Descripcion;
                txbProductoNombre.Text = prod.NombreProducto;
                txbProductoVenta.Text = prod.PrecioVenta;
                txbProductoId.Text = prod.Id;
            }
        }

        private void btnProductoGuardar_Click(object sender, RoutedEventArgs e)
        {
            if (accionProductos == accion.Nuevo)
            {
                Producto prod = new Producto()
                {
                    Categoria = txbProductoCategoria.Text,
                    NombreProducto = txbProductoNombre.Text,
                    Descripcion = txbProductoDescripcion.Text,
                    Cantidad = txbProductoCantidad.Text,
                    PrecioCompra = txbProductoCompra.Text,
                    PrecioVenta = txbProductoVenta.Text
                };
                if (ManejadorProductos.Agregar(prod))
                {
                    MessageBox.Show("Producto agregado correctamente", "Inventarios", MessageBoxButton.OK, MessageBoxImage.Information);
                    LimpiarCamposProducto();
                    ActualizarTablaProductos();
                    BotonesProductoEdicion(false);
                    CargarTablas();
                }
                else
                {
                    MessageBox.Show("El Producto no pudo ser agregado", "inventarios", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                Producto prod = dtgProductos.SelectedItem as Producto;
                prod.Categoria = txbProductoCategoria.Text;
                prod.Descripcion = txbProductoDescripcion.Text;
                prod.NombreProducto = txbProductoNombre.Text;
                prod.PrecioCompra = txbProductoCompra.Text;
                prod.PrecioVenta = txbProductoVenta.Text;
                prod.Cantidad = txbProductoCantidad.Text;
                if (ManejadorProductos.Modificar(prod))
                {
                    MessageBox.Show("Producto modificado correctamente", "Inventarios", MessageBoxButton.OK, MessageBoxImage.Information);
                    LimpiarCamposProducto();
                    ActualizarTablaProductos();
                    BotonesProductoEdicion(false);
                    CargarTablas();
                }
                else
                {
                    MessageBox.Show("El Producto no pudo ser actualizado", "inventarios", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void btnProductoCancelar_Click(object sender, RoutedEventArgs e)
        {
            LimpiarCamposProducto();
            BotonesProductoEdicion(false);
        }

        private void btnProductoEliminar_Click(object sender, RoutedEventArgs e)
        {
            Producto prod = dtgProductos.SelectedItem as Producto;
            if (prod!=null)
            {
                if(MessageBox.Show("Realmente desea eliminar este Producto?", "Inventarios", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    if (ManejadorProductos.Eliminar(prod.Id))
                    {
                        MessageBox.Show("Producto eliminado correctamente", "Inventarios", MessageBoxButton.OK, MessageBoxImage.Information);
                        ActualizarTablaProductos();
                        CargarTablas();
                    }
                    else
                    {
                        MessageBox.Show("Error al eliminar producto", "Inventarios", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
        }

        private void btnClienteNuevo_Click(object sender, RoutedEventArgs e)
        {
            LimpiarCamposClientes();
            BotonesClientesEdicion(true);
            accionClientes = accion.Nuevo;
        }

        private void btnClienteEditar_Click(object sender, RoutedEventArgs e)
        {
            Cliente cli = dtgClientes.SelectedItem as Cliente;
            if (cli != null)
            {
                txbClienteId.Text = cli.Id;
                txbClienteApellidos.Text = cli.ApellidosCliente;
                txbClienteNombre.Text = cli.NombreCliente;
                accionClientes = accion.Editar;
                BotonesClientesEdicion(true);
            }
        }

        private void btnClienteGuardar_Click(object sender, RoutedEventArgs e)
        {
            if (accionClientes == accion.Nuevo)
            {
                Cliente cli = new Cliente()
                {
                    NombreCliente = txbClienteNombre.Text,
                    ApellidosCliente = txbClienteApellidos.Text,
                    Direccion = txbClienteDireccion.Text,
                    RFC = txbClienteRFC.Text,
                    Telefono = txbClienteTelefono.Text,
                    Correo = txbClienteCorreo.Text
                };
                if (ManejadorClientes.Agregar(cli))
                {
                    MessageBox.Show("Cliente agregado correctamente", "Inventarios", MessageBoxButton.OK, MessageBoxImage.Information);
                    LimpiarCamposClientes();
                    ActualizarTablaClientes();
                    BotonesClientesEdicion(false);
                }
                else
                {
                    MessageBox.Show("El Cliente no pudo ser agregado", "inventarios", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                Cliente cli = dtgClientes.SelectedItem as Cliente;
                cli.NombreCliente = txbClienteNombre.Text;
                cli.ApellidosCliente = txbClienteApellidos.Text;
                cli.Direccion = txbClienteDireccion.Text;
                cli.RFC = txbClienteRFC.Text;
                cli.Telefono = txbClienteTelefono.Text;
                cli.Correo = txbClienteCorreo.Text;
                if (ManejadorClientes.Modificar(cli))
                {
                    MessageBox.Show("Cliente modificado correctamente", "Inventarios", MessageBoxButton.OK, MessageBoxImage.Information);
                    LimpiarCamposClientes();
                    ActualizarTablaClientes();
                    BotonesClientesEdicion(false);
                }
                else
                {
                    MessageBox.Show("El Cliente no pudo ser actualizado", "inventarios", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void btnClienteCancelar_Click(object sender, RoutedEventArgs e)
        {
            LimpiarCamposClientes();
            BotonesClientesEdicion(false);
        }

        private void btnClienteEliminar_Click(object sender, RoutedEventArgs e)
        {
            Cliente cli = dtgClientes.SelectedItem as Cliente;
            if (cli != null)
            {
                if (MessageBox.Show("Realmente desea eliminar este cliente?", "Inventarios", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    if (ManejadorClientes.Eliminar(cli.Id))
                    {
                        MessageBox.Show("Cliente eliminado", "Inventarios", MessageBoxButton.OK, MessageBoxImage.Information);
                        ActualizarTablaClientes();
                    }
                    else
                    {
                        MessageBox.Show("No se pudo eliminar el Cliente", "Inventarios", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                }
            }
        }

        private void CargarTablas()
        {
            txtFecha.Text = DateTime.Now.ToString();
            dtgVentaAlmacen.ItemsSource = null;
            dtgVentaAlmacen.ItemsSource = ManejadorProductos.Listar;
            cmbClienteVenta.ItemsSource = null;
            cmbClienteVenta.ItemsSource = ManejadorClientes.Listar;
            cmbEmpleadoVenta.ItemsSource = null;
            cmbEmpleadoVenta.ItemsSource = ManejadorEmpleados.Listar;
            dtgVentas.ItemsSource = null;
            dtgVentas.ItemsSource = venta;
        }

        private void btnAgregarVenta_Click(object sender, RoutedEventArgs e)
        {
            Producto c = dtgVentaAlmacen.SelectedItem as Producto;
            Venta a = new Venta();
            if (c != null)
            {
                if (string.IsNullOrEmpty(txtCantidad.Text)) {
                    MessageBox.Show("No ha llenado el Campo de cantidad", "Farmacia", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                foreach (var item in txtCantidad.Text)
                {
                    if (!(char.IsNumber(item)))
                    {
                        MessageBox.Show("Valor invalido, intente de nuevo (Solo números)", "Ventas", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }
                }
                a.CantidadVenta = int.Parse(txtCantidad.Text);
                a.CategoriaVenta = c.Categoria;
                a.DescripcionVenta = c.Descripcion;
                a.PrecioVenta = float.Parse(c.PrecioVenta);
                a.ProductoVenta = c.NombreProducto;
                a.TotalVenta = a.CantidadVenta * a.PrecioVenta;
                venta.Add(a);
                dtgVentas.ItemsSource = null;
                dtgVentas.ItemsSource = venta;
                txtCantidad.Clear();
            }
            else {
                MessageBox.Show("No selecciono nada en la tabla", "Farmacia", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
        }

        private void btnEliminarVenta_Click(object sender, RoutedEventArgs e)
        {
            Venta c = dtgVentas.SelectedItem as Venta;
            if (c != null)
            {
                venta.Remove(c);
                CargarTablas();
            }
            else
            {
                MessageBox.Show("No selecciono nada en la tabla en Venta", "Farmacia", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
        }

        private void btnVEntaVenta_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(cmbClienteVenta.Text) || string.IsNullOrEmpty(cmbEmpleadoVenta.Text) )
            {
                MessageBox.Show("No ha llenado los datos del Empleado o Cliente ");
                return;
            }
            BotonesVentasEdicion(false);
            if (venta.Count<=0) {
                MessageBox.Show("No cuenta con ningun producto en venta", "Farmacia", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
        
            float Totalito = 0;
            foreach (Venta item in venta)
            {
                Totalito+= item.TotalVenta;
            }
            float IVa = 0.16f;
            float IvaIncluido= IVa * Totalito;
            float TotalVenta = IvaIncluido + Totalito;

            Ticket reporte = new Ticket(txtFolioVenta.Text + ".but");
            string datos = "", elementos = "", informacion="";
            datos = string.Format("Farmacia La Cabaña \nFolio {0}\nFecha: {1}\nEmpleado: {2}\nCliente: {3}\n\nProducto   Precio Cantidad Total\n-------------------------------------\n", txtFolioVenta.Text, txtFecha.Text, cmbEmpleadoVenta.Text.ToUpper(), cmbClienteVenta.Text.ToUpper());
            foreach (Venta item in venta)
            {
                elementos += string.Format("{0}      {1}     {2}     {3}\n", item.ProductoVenta, item.PrecioVenta, item.CantidadVenta, item.TotalVenta);
            }
            informacion = string.Format("\nSubtotal: ${0}\nIva: ${1}\nTotal: ${2}\n\n   ¡¡¡Vuelva pronto!!!", Totalito.ToString(), IvaIncluido.ToString(), TotalVenta.ToString());
            reporte.Guardar(datos + elementos + informacion);
            MessageBox.Show("Subtotal: " + Totalito.ToString() + " \nIva " + (IvaIncluido).ToString() + " \nTotal " + TotalVenta.ToString()+ "\nReporte Guardado con Exito: " + txtFolioVenta.Text + ".poo", "Total de la Venta", MessageBoxButton.OK, MessageBoxImage.Information);
        try
            {
                InventarioVentas Ventas = new InventarioVentas()
                {
                    Nombre_Cliente = cmbClienteVenta.Text,
                    Folio = txtFolioVenta.Text,
                    Fecha = txtFecha.Text,
                    Iva_Pago = float.Parse(IvaIncluido.ToString()),
                    Nombre_Empleado = cmbEmpleadoVenta.Text,
                    Subtotal_Pago = float.Parse(Totalito.ToString()),
                    Total_Pago = TotalVenta,
                    Producto_Venta = venta,
                    
                };
                manejadorTick.Agregar(Ventas);
                TablaEnInventario();
            }
            catch (Exception)
            {
                MessageBox.Show("No se pudo generar la lista de Inventario de Ventas", "Ventas", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            HabilitarCamposDeVenta(false);
            LimpiarCamposVenta();
        }

        private void LimpiarCamposVenta()
        {
            dtgVentas.ItemsSource = null;
            venta= new List<Venta>();
            CargarTablas();
            txtCantidad.Clear();
            cmbClienteVenta.Text = " ";
            cmbEmpleadoVenta.Text = " ";
            txtFolioVenta.Clear();
        }

        private void btnCancelarVenta_Click(object sender, RoutedEventArgs e)
        {
           if( MessageBox.Show("Realmente esta seguro de cancelar la venta", "Farmacia", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes){
                BotonesVentasEdicion(false);
                HabilitarCamposDeVenta(false);
                dtgVentas.ItemsSource = null;
                venta = new List<Venta>();
                txtFolioVenta.Clear();
            }
        }

        private void btnNuevaVenta_Click(object sender, RoutedEventArgs e)
        {
            BotonesVentasEdicion(true);
            LimpiarCamposVenta();
            HabilitarCamposDeVenta(true);
            Random a = new Random();
            int folio = a.Next(200000, 99999999);
            txtFolioVenta.Text = folio.ToString();
        }

        private void dtgAlmacen_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            InventarioVentas a = dtgAlmacen.SelectedItem as InventarioVentas;
                if (a != null)
                {
                    HabilitarCamposAlmacen(true);
                    txtEmpleadoAlmacen.Text = a.Nombre_Empleado;
                    txtClienteAlmacen.Text = a.Nombre_Cliente;
                    txtFechaAlmacen.Text = a.Fecha;
                    dtgTablaObservar.ItemsSource = null;
                    dtgTablaObservar.ItemsSource = a.Producto_Venta;
                    txtTotalAlmacen.Text = a.Total_Pago.ToString();
                    txtFolioAlmacen.Text = a.Folio;
                }
                else {
                    MessageBox.Show("No se pudo seleccionar la fila, intente de nuevo", "Farmacia", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
        }

        private void HabilitarCamposAlmacen(bool v)
        {
            dtgTablaObservar.IsEnabled = v;
            txtTotalAlmacen.IsEnabled =  v;
            txtClienteAlmacen.IsEnabled = v;
            txtEmpleadoAlmacen.IsEnabled = v;
            txtFechaAlmacen.IsEnabled= v;
            txtFolioAlmacen.IsEnabled = v;
            TablaEnInventario();
        }

        private void LimpiarAlmacen()
        {

            dtgTablaObservar.ItemsSource = null;
            txtTotalAlmacen.Clear();
            txtClienteAlmacen.Clear();
            txtEmpleadoAlmacen.Clear();
            txtFechaAlmacen.Clear();
            TablaEnInventario();
            txtFolioAlmacen.Clear();
        }

        private void btnLimpiarAlmacen_Click(object sender, RoutedEventArgs e)
        {
            LimpiarAlmacen();
        }

        private void btnEliminarAlmacen_Click(object sender, RoutedEventArgs e)
        {
            InventarioVentas a = dtgAlmacen.SelectedItem as InventarioVentas;
            if (a != null)
            {
                if (MessageBox.Show("Realmente desea eliminar el campo", "Farmacia", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    manejadorTick.Eliminar(a.Id);
                    TablaEnInventario();
                    LimpiarAlmacen();
                }
            }
            else
            {
                MessageBox.Show("No se pudo seleccionar la fila, intente de nuevo", "Farmacia", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
        }
    }
}
