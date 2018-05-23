using Microsoft.Win32;
using ProyectoFinal.BIZ;
using ProyectoFinal.COMMON.Entidades;
using ProyectoFinal.COMMON.Interfaz;
using ProyectoFinal.DAL;
using System;
using System.Collections.Generic;
using System.IO;
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
using System.Windows.Shapes;

namespace ProyectoFinalAdministrador
{
    /// <summary>
    /// Interaction logic for Admin.xaml
    /// </summary>
    public partial class Admin : Window
    {
        enum accion
        {
            Nuevo,
            Editar
        }
        List<Venta> venta;
        IManejadorArticulo ManejadorArticulo;
        IManejadorCliente ManejadorCliente;
        IManejadorTicket ManejadorTicket;

        accion accionArticulo;
        accion accionCliente;
        public Admin()
        {
            InitializeComponent();
            ManejadorArticulo = new ManejadorArticulo(new RepositorioArticulo());
            ManejadorCliente = new ManejadorCliente(new RepositorioCliente());
            ManejadorTicket = new ManejadorTicket(new RepositorioTicket());
            venta = new List<Venta>();

            BotonesArticulosEdicion(false);
            LimpiarCamposArticulos();
            ActualizarTablaArticulos();

            BotonesClienteEdicion(false);
            LimpiarCamposCliente();
            ActualizarTablaCliente();

            BotonesVentaEdicion(false);
            LimpiarCamposVenta();
            ActualizarTablas();

            TablaReportes();
            LimpiarReportes();
            CamposReportes(false);
        }
        private void LimpiarReportes()
        {
            dtgTablaObservar.ItemsSource = null;
            txtTotalAlmacen.Clear();
            txtClienteAlmacen.Clear();
            txtFechaAlmacen.Clear();
            TablaReportes();
            txtFolioAlmacen.Clear();
        }

        private void CamposReportes(bool value)
        {
            dtgTablaObservar.IsEnabled = value;
            txtTotalAlmacen.IsEnabled = value;
            txtClienteAlmacen.IsEnabled = value;
            txtFechaAlmacen.IsEnabled = value;
            txtFolioAlmacen.IsEnabled = value;
            TablaReportes();
        }

        private void TablaReportes()
        {
            dtgAlmacen.ItemsSource = null;
            dtgAlmacen.ItemsSource = ManejadorTicket.Listar;
        }

        private void LimpiarCamposVenta()
        {
            dtgVenta.ItemsSource = null;
            venta = new List<Venta>();
            ActualizarTablas();
            txtCantidad.Clear();
            cmbClienteVenta.Text = "";
            txtFolioVenta.Clear();
        }

        private void ActualizarTablas()
        {
            txtFechaVenta.Text = DateTime.Now.ToString();
            dtgVentaAlmacen.ItemsSource = null;
            dtgVentaAlmacen.ItemsSource = ManejadorArticulo.Listar;
            cmbClienteVenta.ItemsSource = null;
            cmbClienteVenta.ItemsSource = ManejadorCliente.Listar;
            dtgVenta.ItemsSource = null;
            dtgVenta.ItemsSource = venta;
        }

        private void BotonesVentaEdicion(bool value)
        {
            btnAgregarVenta.IsEnabled = value;
            btnEliminarVenta.IsEnabled = value;
            btnCancelarVenta.IsEnabled = value;
            btnVEntaVenta.IsEnabled = value;
            btnNuevaVenta.IsEnabled = !value;
            txtCantidad.IsEnabled = value;
            cmbClienteVenta.IsEnabled = value;
            txtFolioVenta.IsEnabled = value;
        }

        private void ActualizarTablaCliente()
        {
            dtgCliente.ItemsSource = null;
            dtgCliente.ItemsSource = ManejadorCliente.Listar;
        }

        private void LimpiarCamposCliente()
        {
            txbNombreCliente.Clear();
            txbClienteApellidos.Clear();
            txbClienteDireccion.Clear();
            txbClienteTelefono.Clear();
            txbClienteCorreo.Clear();
            txbClienteId.Text = "";
        }

        private void BotonesClienteEdicion(bool value)
        {
            btnClienteCancelar.IsEnabled = value;
            btnClienteEditar.IsEnabled = !value;
            btnClienteEliminar.IsEnabled = !value;
            btnClienteGuardar.IsEnabled = value;
            btnClienteNuevo.IsEnabled = !value;
            txbNombreCliente.IsEnabled = value;
            txbClienteApellidos.IsEnabled = value;
            txbClienteDireccion.IsEnabled = value;
            txbClienteTelefono.IsEnabled = value;
            txbClienteCorreo.IsEnabled = value;
        }

        private void ActualizarTablaArticulos()
        {
            dtgArticulo.ItemsSource = null;
            dtgArticulo.ItemsSource = ManejadorArticulo.Listar;
        }

        private void LimpiarCamposArticulos()
        {
            txbNombreArticulo.Clear();
            txbArticuloCategoria.Clear();
            txbArticuloDescripcion.Clear();
            txbArticuloPrecio.Clear();
            txbArticuloId.Text = "";
        }

        private void BotonesArticulosEdicion(bool value)
        {
            btnArticuloCancelar.IsEnabled = value;
            btnArticuloEditar.IsEnabled = !value;
            btnArticuloEliminar.IsEnabled = !value;
            btnArticuloGuardar.IsEnabled = value;
            btnArticuloNuevo.IsEnabled = !value;
            btnImg.IsEnabled = value;
            txbNombreArticulo.IsEnabled = value;
            txbArticuloCategoria.IsEnabled = value;
            txbArticuloDescripcion.IsEnabled = value;
            txbArticuloPrecio.IsEnabled = value;
        }

        private void btnArticuloNuevo_Click(object sender, RoutedEventArgs e)
        {
            LimpiarCamposArticulos();
            BotonesArticulosEdicion(true);
            accionArticulo = accion.Nuevo;
        }

        public byte[] ImageToByte(ImageSource image)
        {
            if (image != null)
            {
                MemoryStream memStream = new MemoryStream();
                JpegBitmapEncoder encoder = new JpegBitmapEncoder();
                encoder.Frames.Add(BitmapFrame.Create(image as BitmapSource));
                encoder.Save(memStream);
                return memStream.ToArray();
            }
            else
            {
                return null;
            }
        }

        public ImageSource ByteToImage(byte[] imageData)
        {
            if (imageData == null)
            {
                return null;
            }
            else
            {
                BitmapImage biImg = new BitmapImage();
                MemoryStream ms = new MemoryStream(imageData);
                biImg.BeginInit();
                biImg.StreamSource = ms;
                biImg.EndInit();
                ImageSource imgSrc = biImg as ImageSource;
                return imgSrc;
            }
        }

        private void btnArticuloEditar_Click(object sender, RoutedEventArgs e)
        {
            Articulo art = dtgArticulo.SelectedItem as Articulo;
            if (art != null)
            {
                txbArticuloId.Text = art.Id;
                txbNombreArticulo.Text = art.NombreArticulo;
                txbArticuloCategoria.Text = art.Categoria;
                txbArticuloDescripcion.Text = art.Descripcion;
                txbArticuloPrecio.Text = art.PrecioArticulo;
                imgArticulo.Source = ByteToImage(art.ImagenArticulo);
                accionArticulo = accion.Editar;
                BotonesArticulosEdicion(true);
            }
            else
            {
                MessageBox.Show("No ha seleccionado nada", "Inventarios", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
        }

        private void btnArticuloGuardar_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(txbNombreArticulo.Text) || string.IsNullOrEmpty(txbArticuloCategoria.Text) || string.IsNullOrEmpty(txbArticuloPrecio.Text))
            {
                MessageBox.Show("Faltan datos", "Error", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                return;
            }
            foreach (var item in txbArticuloPrecio.Text)
            {
                if (!(char.IsNumber(item)))
                {
                    MessageBox.Show("Error en el precio, solo ingrese numeros", "Inventarios", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
            }

            if (accionArticulo == accion.Nuevo)
            {
                Articulo art = new Articulo()
                {
                    NombreArticulo = txbNombreArticulo.Text,
                    Categoria = txbArticuloCategoria.Text,
                    Descripcion = txbArticuloDescripcion.Text,
                    PrecioArticulo = txbArticuloPrecio.Text,
                    ImagenArticulo = ImageToByte(imgArticulo.Source)
                };
                if (ManejadorArticulo.Agregar(art))
                {
                    MessageBox.Show("Articulo agregado correctamente", "inventarios", MessageBoxButton.OK, MessageBoxImage.Information);
                    LimpiarCamposArticulos();
                    ActualizarTablaArticulos();
                    BotonesArticulosEdicion(false);
                    ActualizarTablas();
                }
                else
                {
                    MessageBox.Show("El Articulo no pudo ser agregado", "inventarios", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                Articulo art = dtgArticulo.SelectedItem as Articulo;
                art.NombreArticulo = txbNombreArticulo.Text;
                art.Categoria = txbArticuloCategoria.Text;
                art.Descripcion = txbArticuloDescripcion.Text;
                art.PrecioArticulo = txbArticuloPrecio.Text;
                art.ImagenArticulo = ImageToByte(imgArticulo.Source);
                if (ManejadorArticulo.Modificar(art))
                {
                    MessageBox.Show("Articulo modificado correctamente", "inventarios", MessageBoxButton.OK, MessageBoxImage.Information);
                    LimpiarCamposArticulos();
                    ActualizarTablaArticulos();
                    BotonesArticulosEdicion(false);
                    ActualizarTablas();
                }
                else
                {
                    MessageBox.Show("El Articulo no pudo ser actualizado", "inventarios", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void btnArticuloCancelar_Click(object sender, RoutedEventArgs e)
        {
            LimpiarCamposArticulos();
            BotonesArticulosEdicion(false);
        }

        private void btnArticuloEliminar_Click(object sender, RoutedEventArgs e)
        {
            Articulo art = dtgArticulo.SelectedItem as Articulo;
            if (art != null)
            {
                if (MessageBox.Show("Realmente desea eliminar este Articulo?", "Inventarios", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    if (ManejadorArticulo.Eliminar(art.Id))
                    {
                        MessageBox.Show("Articulo eliminado", "Inventarios", MessageBoxButton.OK, MessageBoxImage.Information);
                        ActualizarTablaArticulos();
                        ActualizarTablas();
                    }
                    else
                    {
                        MessageBox.Show("No se pudo eliminar el Articulo", "Inventarios", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                }
            }
            else
            {
                MessageBox.Show("No ha seleccionado nada", "Inventarios", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
        }

        private void btnClienteNuevo_Click(object sender, RoutedEventArgs e)
        {
            LimpiarCamposCliente();
            BotonesClienteEdicion(true);
            accionCliente = accion.Nuevo;
        }

        private void btnClienteEditar_Click(object sender, RoutedEventArgs e)
        {
            Cliente cli = dtgCliente.SelectedItem as Cliente;
            if (cli != null)
            {
                txbClienteId.Text = cli.Id;
                txbNombreCliente.Text = cli.NombreCliente;
                txbClienteApellidos.Text = cli.ApellidosCliente;
                txbClienteDireccion.Text = cli.Direccion;
                txbClienteTelefono.Text = cli.Telefono;
                txbClienteCorreo.Text = cli.Correo;
                accionCliente = accion.Editar;
                BotonesClienteEdicion(true);
            }
            else
            {
                MessageBox.Show("No ha seleccionado nada", "Inventarios", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
        }

        private void btnClienteGuardar_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(txbNombreCliente.Text) || string.IsNullOrEmpty(txbClienteApellidos.Text) || string.IsNullOrEmpty(txbClienteTelefono.Text))
            {
                MessageBox.Show("Faltan datos", "Error", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                return;
            }
            foreach (var item in txbClienteTelefono.Text)
            {
                if (!(char.IsNumber(item)))
                {
                    MessageBox.Show("Error en el telefono, solo ingrese numeros", "Inventarios", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
            }

            if (accionCliente == accion.Nuevo)
            {
                Cliente cli = new Cliente()
                {
                    NombreCliente = txbNombreCliente.Text,
                    ApellidosCliente = txbClienteApellidos.Text,
                    Direccion = txbClienteDireccion.Text,
                    Telefono = txbClienteTelefono.Text,
                    Correo = txbClienteCorreo.Text
                };
                if (ManejadorCliente.Agregar(cli))
                {
                    MessageBox.Show("Cliente agregado correctamente", "inventarios", MessageBoxButton.OK, MessageBoxImage.Information);
                    LimpiarCamposCliente();
                    ActualizarTablaCliente();
                    BotonesClienteEdicion(false);
                }
                else
                {
                    MessageBox.Show("El Cliente no pudo ser agregado", "inventarios", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                Cliente cli = dtgCliente.SelectedItem as Cliente;
                cli.NombreCliente = txbNombreCliente.Text;
                cli.ApellidosCliente = txbClienteApellidos.Text;
                cli.Direccion = txbClienteDireccion.Text;
                cli.Telefono = txbClienteTelefono.Text;
                cli.Correo = txbClienteCorreo.Text;
                if (ManejadorCliente.Modificar(cli))
                {
                    MessageBox.Show("Cliente modificado correctamente", "inventarios", MessageBoxButton.OK, MessageBoxImage.Information);
                    LimpiarCamposCliente();
                    ActualizarTablaCliente();
                    BotonesClienteEdicion(false);
                }
                else
                {
                    MessageBox.Show("El Cliente no pudo ser actualizado", "inventarios", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void btnClienteCancelar_Click(object sender, RoutedEventArgs e)
        {
            LimpiarCamposCliente();
            BotonesClienteEdicion(false);
        }

        private void btnClienteEliminar_Click(object sender, RoutedEventArgs e)
        {
            Cliente cli = dtgCliente.SelectedItem as Cliente;
            if (cli != null)
            {
                if (MessageBox.Show("Realmente desea eliminar este Cliente?", "Inventarios", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    if (ManejadorCliente.Eliminar(cli.Id))
                    {
                        MessageBox.Show("Cliente eliminado", "Inventarios", MessageBoxButton.OK, MessageBoxImage.Information);
                        ActualizarTablaCliente();
                    }
                    else
                    {
                        MessageBox.Show("No se pudo eliminar el Cliente", "Inventarios", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                }
            }
            else
            {
                MessageBox.Show("No ha seleccionado nada", "Inventarios", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
        }

        private void btnAgregarVenta_Click(object sender, RoutedEventArgs e)
        {
            Articulo c = dtgVentaAlmacen.SelectedItem as Articulo;
            Venta a = new Venta();
            if (c != null)
            {
                if (string.IsNullOrEmpty(txtCantidad.Text))
                {
                    MessageBox.Show("No ha llenado el Campo de cantidad", "Inventarios", MessageBoxButton.OK, MessageBoxImage.Error);
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
                a.PrecioVenta = float.Parse(c.PrecioArticulo);
                a.ProductoVenta = c.NombreArticulo;
                a.TotalVenta = a.CantidadVenta * a.PrecioVenta;
                venta.Add(a);
                dtgVenta.ItemsSource = null;
                dtgVenta.ItemsSource = venta;
                txtCantidad.Clear();
            }
            else
            {
                MessageBox.Show("No selecciono nada en la tabla", "Inventarios", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
        }

        private void btnEliminarVenta_Click(object sender, RoutedEventArgs e)
        {
            Venta c = dtgVenta.SelectedItem as Venta;
            if (c != null)
            {
                venta.Remove(c);
                ActualizarTablas();
            }
            else
            {
                MessageBox.Show("No selecciono nada en la tabla en Venta", "Inventarios", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
        }

        private void btnCancelarVenta_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Realmente esta seguro de cancelar la venta", "Inventarios", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                BotonesVentaEdicion(false);
                dtgVenta.ItemsSource = null;
                venta = new List<Venta>();
                txtFolioVenta.Clear();
            }
        }

        private void btnVEntaVenta_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(cmbClienteVenta.Text))
            {
                MessageBox.Show("No ha llenado todos los datos", "Inventarios",MessageBoxButton.OK,MessageBoxImage.Error);
                return;
            }
            BotonesVentaEdicion(false);
            if (venta.Count <= 0)
            {
                MessageBox.Show("No a seleccionado un producto", "Inventarios", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            float Totalito = 0;
            foreach (Venta item in venta)
            {
                Totalito += item.TotalVenta;
            }
            float IVa = 0.16f;
            float IvaIncluido = IVa * Totalito;
            float TotalVenta = IvaIncluido + Totalito;

            Ticket reporte = new Ticket(txtFolioVenta.Text + ".but");
            string datos = "", elementos = "", informacion = "";
            datos = string.Format("Tienda de Articulos\n \nFolio {0}\n \nFecha: {1}\n \nCliente: {2}\n \nProducto\n   \nPrecio\n \nCantidad\n \nTotal\n-----------------\n", txtFolioVenta.Text, txtFechaVenta.Text, cmbClienteVenta.Text.ToUpper());
            foreach (Venta item in venta)
            {
                elementos += string.Format("\n{0}      {1}     {2}     {3}\n", item.ProductoVenta, item.PrecioVenta, item.CantidadVenta, item.TotalVenta);
            }
            informacion = string.Format("\nSubtotal: ${0}\nIva: ${1}\n Total: ${2}\n\n   ¡¡¡Vuelva pronto!!!", Totalito.ToString(), IvaIncluido.ToString(), TotalVenta.ToString());
            reporte.Guardar(datos + elementos + informacion);
            MessageBox.Show("Subtotal: " + Totalito.ToString() + " \nIva " + (IvaIncluido).ToString() + " \nTotal " + TotalVenta.ToString() + "\nReporte Guardado con Exito: " + txtFolioVenta.Text + ".poo", "Total de la Venta", MessageBoxButton.OK, MessageBoxImage.Information);
            try
            {
                InventarioVenta Ventas = new InventarioVenta()
                {
                    Nombre_Cliente = cmbClienteVenta.Text,
                    Folio = txtFolioVenta.Text,
                    Fecha = txtFechaVenta.Text,
                    Iva_Pago = float.Parse(IvaIncluido.ToString()),
                    Subtotal_Pago = float.Parse(Totalito.ToString()),
                    Total_Pago = TotalVenta,
                    Producto_Venta = venta,

                };
                ManejadorTicket.Agregar(Ventas);
                TablaReportes();
            }
            catch (Exception)
            {
                MessageBox.Show("No se pudo generar la lista de Inventario de Ventas", "Ventas", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            BotonesVentaEdicion(false);
            LimpiarCamposVenta();
        }

        private void btnNuevaVenta_Click(object sender, RoutedEventArgs e)
        {
            BotonesVentaEdicion(true);
            LimpiarCamposVenta();
            Random a = new Random();
            int folio = a.Next(200000, 99999999);
            txtFolioVenta.Text = folio.ToString();
        }

        private void dtgAlmacen_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            InventarioVenta a = dtgAlmacen.SelectedItem as InventarioVenta;
            if (a != null)
            {
                CamposReportes(true);
                txtClienteAlmacen.Text = a.Nombre_Cliente;
                txtFechaAlmacen.Text = a.Fecha;
                dtgTablaObservar.ItemsSource = null;
                dtgTablaObservar.ItemsSource = a.Producto_Venta;
                txtTotalAlmacen.Text = a.Total_Pago.ToString();
                txtFolioAlmacen.Text = a.Folio;
            }
            else
            {
                MessageBox.Show("No se pudo seleccionar la opcion, intente de nuevo", "Inventarios", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
        }

        private void btnLimpiarReportes_Click(object sender, RoutedEventArgs e)
        {
            LimpiarReportes();
        }

        private void btnEliminarReporte_Click(object sender, RoutedEventArgs e)
        {
            InventarioVenta a = dtgAlmacen.SelectedItem as InventarioVenta;
            if (a != null)
            {
                if (MessageBox.Show("Realmente desea eliminar el campo", "Inventarios", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    ManejadorTicket.Eliminar(a.Id);
                    TablaReportes();
                    LimpiarReportes();
                }
            }
            else
            {
                MessageBox.Show("No se pudo seleccionar la Opcion, intente de nuevo", "Inventarios", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
        }

        private void btnImg_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dialogo = new OpenFileDialog();
            dialogo.Title = "seleccione una imagen";
            dialogo.Filter = "Archivos de Imagen|*.jpg; *.jpeg; *.png";
            if (dialogo.ShowDialog().Value)
            {
                imgArticulo.Source = new BitmapImage(new Uri(dialogo.FileName));
            }
        }
    }
}
