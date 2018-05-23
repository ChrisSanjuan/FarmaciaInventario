using ProyectoFinal.BIZ;
using ProyectoFinal.COMMON.Entidades;
using ProyectoFinal.COMMON.Interfaz;
using ProyectoFinal.DAL;
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
using System.Windows.Shapes;

namespace ProyectoFinal.GUI
{
    /// <summary>
    /// Interaction logic for UsuariosLista.xaml
    /// </summary>
    public partial class UsuariosLista : Window
    {
        enum accion
        {
            Nuevo,
            Editar
        }
        IManejadorUsuario ManejadorUsuario;
        IManejadorEmpleado ManejadorEmpleado;
        IManejadorPaquete ManejadorPaquete;
        IManejadorArticulo ManejadorArticulo;

        accion accionUsuario;
        accion accionEmpleado;
        accion accionPaquete;

        public UsuariosLista()
        {
            InitializeComponent();
            ManejadorUsuario = new ManejadorUsuario(new RepositorioUsuario());
            ManejadorEmpleado = new ManejadorEmpleado(new RepositorioEmpleado());
            ManejadorPaquete = new ManejadorPaquete(new RepositorioPaquete());
            ManejadorArticulo = new ManejadorArticulo(new RepositorioArticulo());

            BotonesUsuarioEdicion(false);
            LimpiarCamposUsuario();
            ActualizarTablaUsuario();

            BotonesEmpleadoEdicion(false);
            LimpiarCamposEmpleado();
            ActualizarTablaEmpleado();

            BotonesPaqueteEdicion(false);
            LimpiarCamposPaquete();
            ActualizarTablaPaquete();
        }

        private void ActualizarTablaPaquete()
        {
            cmbEmpleadoPaquete.ItemsSource = null;
            cmbEmpleadoPaquete.ItemsSource = ManejadorEmpleado.Listar;
            cmbProductoPaquete.ItemsSource = null;
            cmbProductoPaquete.ItemsSource = ManejadorArticulo.Listar;
            dtgPaquetes.ItemsSource = null;
            dtgPaquetes.ItemsSource = ManejadorPaquete.Listar;
        }

        private void LimpiarCamposPaquete()
        {
            txbPaqueteId.Text = "";
            cmbEmpleadoPaquete.Text = "";
            cmbProductoPaquete.Text = "";
            dpEntrega.Text = "";
            txbCantidadPaquete.Clear();
            txbFirmaSolicitante.Clear();
            txbFirmaEncargado.Clear();
        }

        private void BotonesPaqueteEdicion(bool value)
        {
            btnPaqueteCancelar.IsEnabled = value;
            btnPaqueteEditar.IsEnabled = !value;
            btnPaqueteEliminar.IsEnabled = !value;
            btnPaqueteGuardar.IsEnabled = value;
            btnPaqueteNuevo.IsEnabled = !value;
            cmbEmpleadoPaquete.IsEnabled = value;
            cmbProductoPaquete.IsEnabled = value;
            dpEntrega.IsEnabled = value;
            txbCantidadPaquete.IsEnabled = value;
            txbFirmaSolicitante.IsEnabled = value;
            txbFirmaEncargado.IsEnabled = value;
        }

        private void ActualizarTablaEmpleado()
        {
            dtgEmpleados.ItemsSource = null;
            dtgEmpleados.ItemsSource = ManejadorEmpleado.Listar;
        }

        private void LimpiarCamposEmpleado()
        {
            txbEmpleadoNombre.Clear();
            txbEmpleadoApellidos.Clear();
            txbEmpleadoCargo.Clear();
            txbEmpleadoDireccion.Clear();
            txbEmpleadoTelefono.Clear();
            txbEmpleadoCorreo.Clear();
            txbEmpleadoId.Text = "";
        }

        private void BotonesEmpleadoEdicion(bool value)
        {
            btnEmpleadoCancelar.IsEnabled = value;
            btnEmpleadoEditar.IsEnabled = !value;
            btnEmpleadoEliminar.IsEnabled = !value;
            btnEmpleadoGuardar.IsEnabled = value;
            btnEmpleadoNuevo.IsEnabled = !value;
            txbEmpleadoNombre.IsEnabled = value;
            txbEmpleadoApellidos.IsEnabled = value;
            txbEmpleadoCargo.IsEnabled = value;
            txbEmpleadoDireccion.IsEnabled = value;
            txbEmpleadoTelefono.IsEnabled = value;
            txbEmpleadoCorreo.IsEnabled = value;
        }

        private void ActualizarTablaUsuario()
        {
            dtgUsuarios.ItemsSource = null;
            dtgUsuarios.ItemsSource = ManejadorUsuario.Listar;
        }

        private void LimpiarCamposUsuario()
        {
            txbNombreUsuario.Clear();
            txbContraseniaUsuario.Clear();
            txbUsuarioTipo.Clear();
            txbUsuarioId.Text = "";
        }

        private void BotonesUsuarioEdicion(bool value)
        {
            btnUsuarioCancelar.IsEnabled = value;
            btnUsuarioEditar.IsEnabled = !value;
            btnUsuarioEliminar.IsEnabled = !value;
            btnUsuarioGuardar.IsEnabled = value;
            btnUsuarioNuevo.IsEnabled = !value;
            txbNombreUsuario.IsEnabled = value;
            txbContraseniaUsuario.IsEnabled = value;
            txbUsuarioTipo.IsEnabled = value;
        }

        private void btnUsuarioNuevo_Click(object sender, RoutedEventArgs e)
        {
            LimpiarCamposUsuario();
            BotonesUsuarioEdicion(true);
            accionUsuario = accion.Nuevo;
        }

        private void btnUsuarioEditar_Click(object sender, RoutedEventArgs e)
        {
            Usuario usu = dtgUsuarios.SelectedItem as Usuario;
            if (usu != null)
            {
                txbUsuarioId.Text = usu.Id;
                txbNombreUsuario.Text = usu.NombreUsuario;
                txbContraseniaUsuario.Text = usu.Contrasenia;
                txbUsuarioTipo.Text = usu.UsuarioTipo;
                accionUsuario = accion.Editar;
                BotonesUsuarioEdicion(true);
            }
            else
            {
                MessageBox.Show("No ha seleccionado nada", "Inventarios", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
        }

        private void btnUsuarioGuardar_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(txbNombreUsuario.Text) || string.IsNullOrEmpty(txbContraseniaUsuario.Text))
            {
                MessageBox.Show("Faltan datos", "Error", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                return;
            }

            if (accionUsuario == accion.Nuevo)
            {
                Usuario usu = new Usuario()
                {
                    NombreUsuario = txbNombreUsuario.Text,
                    UsuarioTipo=txbUsuarioTipo.Text,
                    Contrasenia = txbContraseniaUsuario.Text
                };
                if (ManejadorUsuario.Agregar(usu))
                {
                    MessageBox.Show("Usuario agregado correctamente", "inventarios", MessageBoxButton.OK, MessageBoxImage.Information);
                    LimpiarCamposUsuario();
                    ActualizarTablaUsuario();
                    BotonesUsuarioEdicion(false);
                }
                else
                {
                    MessageBox.Show("El Usuario no pudo ser agregado", "inventarios", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                Usuario usu = dtgUsuarios.SelectedItem as Usuario;
                usu.NombreUsuario = txbNombreUsuario.Text;
                usu.UsuarioTipo = txbUsuarioTipo.Text;
                usu.Contrasenia = txbContraseniaUsuario.Text;
                if (ManejadorUsuario.Modificar(usu))
                {
                    MessageBox.Show("Usuario modificado correctamente", "inventarios", MessageBoxButton.OK, MessageBoxImage.Information);
                    LimpiarCamposUsuario();
                    ActualizarTablaUsuario();
                    BotonesUsuarioEdicion(false);
                }
                else
                {
                    MessageBox.Show("El Usuario no pudo ser actualizado", "inventarios", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void btnUsuarioCancelar_Click(object sender, RoutedEventArgs e)
        {
            LimpiarCamposUsuario();
            BotonesUsuarioEdicion(false);
        }

        private void btnUsuarioEliminar_Click(object sender, RoutedEventArgs e)
        {
            Usuario usu = dtgUsuarios.SelectedItem as Usuario;
            if (usu != null)
            {
                if (MessageBox.Show("Realmente desea eliminar este Usuario?", "Inventarios", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    if (ManejadorUsuario.Eliminar(usu.Id))
                    {
                        MessageBox.Show("Usuario eliminado", "Inventarios", MessageBoxButton.OK, MessageBoxImage.Information);
                        ActualizarTablaUsuario();
                    }
                    else
                    {
                        MessageBox.Show("No se pudo eliminar el Usuario", "Inventarios", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                }
            }
            else
            {
                MessageBox.Show("No ha seleccionado nada", "Inventarios", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
        }

        private void btnUsuarioVolver_Click(object sender, RoutedEventArgs e)
        {
            LogIn abrir = new LogIn();
            abrir.Show();
            this.Close();
        }

        private void btnEmpleadoNuevo_Click(object sender, RoutedEventArgs e)
        {
            LimpiarCamposEmpleado();
            BotonesEmpleadoEdicion(true);
            accionEmpleado = accion.Nuevo;
        }

        private void btnEmpleadoEditar_Click(object sender, RoutedEventArgs e)
        {
            Empleado emp = dtgEmpleados.SelectedItem as Empleado;
            if (emp != null)
            {
                txbUsuarioId.Text = emp.Id;
                txbEmpleadoNombre.Text = emp.NombreEmpleado;
                txbEmpleadoApellidos.Text = emp.ApellidosEmpleado;
                txbEmpleadoCargo.Text = emp.Cargo;
                txbEmpleadoCorreo.Text = emp.CorreoEmpleado;
                txbEmpleadoDireccion.Text = emp.DireccionEmpleado;
                txbEmpleadoTelefono.Text = emp.TelefonoEmpleado;
                accionEmpleado = accion.Editar;
                BotonesEmpleadoEdicion(true);
            }
            else
            {
                MessageBox.Show("No ha seleccionado nada", "Inventarios", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
        }

        private void btnEmpleadoGuardar_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(txbEmpleadoNombre.Text) || string.IsNullOrEmpty(txbEmpleadoApellidos.Text) || string.IsNullOrEmpty(txbEmpleadoTelefono.Text))
            {
                MessageBox.Show("Faltan datos", "Error", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                return;
            }
            foreach (var item in txbEmpleadoTelefono.Text)
            {
                if (!(char.IsNumber(item)))
                {
                    MessageBox.Show("Error en el telefono, solo ingrese numeros", "Inventarios", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
            }

            if (accionEmpleado == accion.Nuevo)
            {
                Empleado emp = new Empleado()
                {
                    NombreEmpleado = txbEmpleadoNombre.Text,
                    ApellidosEmpleado = txbEmpleadoApellidos.Text,
                    Cargo = txbEmpleadoCargo.Text,
                    DireccionEmpleado = txbEmpleadoDireccion.Text,
                    TelefonoEmpleado = txbEmpleadoTelefono.Text,
                    CorreoEmpleado = txbEmpleadoCorreo.Text
                };
                if (ManejadorEmpleado.Agregar(emp))
                {
                    MessageBox.Show("Empleado agregado correctamente", "inventarios", MessageBoxButton.OK, MessageBoxImage.Information);
                    LimpiarCamposEmpleado();
                    ActualizarTablaEmpleado();
                    BotonesEmpleadoEdicion(false);
                }
                else
                {
                    MessageBox.Show("El Empleado no pudo ser agregado", "inventarios", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                Empleado emp = dtgEmpleados.SelectedItem as Empleado;
                emp.NombreEmpleado = txbEmpleadoNombre.Text;
                emp.ApellidosEmpleado = txbEmpleadoApellidos.Text;
                emp.Cargo = txbEmpleadoCargo.Text;
                emp.DireccionEmpleado = txbEmpleadoDireccion.Text;
                emp.CorreoEmpleado = txbEmpleadoCorreo.Text;
                emp.TelefonoEmpleado = txbEmpleadoTelefono.Text;
                if (ManejadorEmpleado.Modificar(emp))
                {
                    MessageBox.Show("Empleado modificado correctamente", "inventarios", MessageBoxButton.OK, MessageBoxImage.Information);
                    LimpiarCamposEmpleado();
                    ActualizarTablaEmpleado();
                    BotonesEmpleadoEdicion(false);
                }
                else
                {
                    MessageBox.Show("El Empleado no pudo ser actualizado", "inventarios", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void btnEmpleadoCancelar_Click(object sender, RoutedEventArgs e)
        {
            LimpiarCamposEmpleado();
            BotonesEmpleadoEdicion(false);
        }

        private void btnEmpleadoEliminar_Click(object sender, RoutedEventArgs e)
        {
            Empleado emp = dtgEmpleados.SelectedItem as Empleado;
            if (emp != null)
            {
                if (MessageBox.Show("Realmente desea eliminar este Empleado?", "Inventarios", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    if (ManejadorEmpleado.Eliminar(emp.Id))
                    {
                        MessageBox.Show("Empleado eliminado", "Inventarios", MessageBoxButton.OK, MessageBoxImage.Information);
                        ActualizarTablaEmpleado();
                    }
                    else
                    {
                        MessageBox.Show("No se pudo eliminar el Empleado", "Inventarios", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                }
            }
            else
            {
                MessageBox.Show("No ha seleccionado nada", "Inventarios", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
        }

        private void btnPaqueteNuevo_Click(object sender, RoutedEventArgs e)
        {
            LimpiarCamposPaquete();
            BotonesPaqueteEdicion(true);
            accionPaquete = accion.Nuevo;
        }

        private void btnPaqueteEditar_Click(object sender, RoutedEventArgs e)
        {
            Paquete paq = dtgPaquetes.SelectedItem as Paquete;
            if (paq != null)
            {
                txbPaqueteId.Text = paq.Id;
                cmbEmpleadoPaquete.Text = paq.EmpleadoSolicitante;
                cmbProductoPaquete.Text = paq.ProductoSolicitado;
                dpPrestamo.Text = paq.FechaPrestamo.ToString();
                dpEntrega.Text = paq.FechaEntrega.ToString();
                txbCantidadPaquete.Text = paq.CantidadSolicitado;
                txbFirmaSolicitante.Text = paq.FirmaSolicitante;
                txbFirmaEncargado.Text = paq.FirmaEncargado;
                accionPaquete = accion.Editar;
                BotonesPaqueteEdicion(true);
            }
            else
            {
                MessageBox.Show("No ha seleccionado nada", "Inventarios", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
        }

        private void btnPaqueteGuardar_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(cmbEmpleadoPaquete.Text) || string.IsNullOrEmpty(cmbProductoPaquete.Text) || string.IsNullOrEmpty(txbCantidadPaquete.Text)||string.IsNullOrEmpty(txbFirmaSolicitante.Text)||string.IsNullOrEmpty(txbFirmaEncargado.Text))
            {
                MessageBox.Show("Faltan datos", "Error", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                return;
            }
            foreach (var item in txbCantidadPaquete.Text)
            {
                if (!(char.IsNumber(item)))
                {
                    MessageBox.Show("Valor invalido, intente de nuevo (Solo números)", "Inventarios", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
            }

            if (accionPaquete == accion.Nuevo)
            {
                Paquete paq = new Paquete()
                {
                    EmpleadoSolicitante = cmbEmpleadoPaquete.Text,
                    ProductoSolicitado = cmbProductoPaquete.Text,
                    CantidadSolicitado = txbCantidadPaquete.Text,
                    FechaPrestamo = DateTime.Now,
                    FechaEntrega = DateTime.Parse(dpEntrega.ToString()),
                    FirmaSolicitante = txbFirmaSolicitante.Text,
                    FirmaEncargado = txbFirmaEncargado.Text
                };
                if (ManejadorPaquete.Agregar(paq))
                {
                    MessageBox.Show("Paquete agregado correctamente", "inventarios", MessageBoxButton.OK, MessageBoxImage.Information);
                    LimpiarCamposPaquete();
                    ActualizarTablaPaquete();
                    BotonesPaqueteEdicion(false);
                }
                else
                {
                    MessageBox.Show("El Paquete no pudo ser agregado", "inventarios", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                Paquete paq = dtgPaquetes.SelectedItem as Paquete;
                paq.EmpleadoSolicitante = cmbEmpleadoPaquete.Text;
                paq.ProductoSolicitado = cmbProductoPaquete.Text;
                paq.FechaPrestamo = DateTime.Now;
                paq.FechaEntrega = DateTime.Parse(dpEntrega.ToString());
                paq.CantidadSolicitado = txbCantidadPaquete.Text;
                paq.FirmaSolicitante = txbFirmaSolicitante.Text;
                paq.FirmaEncargado = txbFirmaEncargado.Text;
                if (ManejadorPaquete.Modificar(paq))
                {
                    MessageBox.Show("Paquete modificado correctamente", "inventarios", MessageBoxButton.OK, MessageBoxImage.Information);
                    LimpiarCamposPaquete();
                    ActualizarTablaPaquete();
                    BotonesEmpleadoEdicion(false);
                }
                else
                {
                    MessageBox.Show("El Paquete no pudo ser actualizado", "inventarios", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void btnPaqueteCancelar_Click(object sender, RoutedEventArgs e)
        {
            LimpiarCamposPaquete();
            BotonesPaqueteEdicion(false);
        }

        private void btnPaqueteEliminar_Click(object sender, RoutedEventArgs e)
        {
            Paquete paq = dtgPaquetes.SelectedItem as Paquete;
            if (paq != null)
            {
                if (MessageBox.Show("Realmente desea eliminar este Paquete?", "Inventarios", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    if (ManejadorPaquete.Eliminar(paq.Id))
                    {
                        MessageBox.Show("Paquete eliminado", "Inventarios", MessageBoxButton.OK, MessageBoxImage.Information);
                        ActualizarTablaPaquete();
                    }
                    else
                    {
                        MessageBox.Show("No se pudo eliminar el Paquete", "Inventarios", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                }
            }
            else
            {
                MessageBox.Show("No ha seleccionado nada", "Inventarios", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
        }
    }
}
