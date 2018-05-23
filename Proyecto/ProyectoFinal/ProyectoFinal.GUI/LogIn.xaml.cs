using ProyectoFinal.BIZ;
using ProyectoFinal.COMMON.Interfaz;
using ProyectoFinal.DAL;
using ProyectoFinalAdministrador;
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
    /// Interaction logic for LogIn.xaml
    /// </summary>
    public partial class LogIn : Window
    {
        IManejadorUsuario manejadorUsuario;
        public LogIn()
        {
            InitializeComponent();
            manejadorUsuario = new ManejadorUsuario(new RepositorioUsuario());
            cmbUsuarioLog.ItemsSource = null;
            cmbUsuarioLog.ItemsSource = manejadorUsuario.Listar;
        }

        private void btnLogIn_Click(object sender, RoutedEventArgs e)
        {
            if (cmbUsuarioLog.Text != null)
            {
                foreach (var item in manejadorUsuario.Listar)
                {
                    if (item.NombreUsuario == cmbUsuarioLog.Text)
                    {
                        if (item.Contrasenia == txbContraseniaLog.Password)
                        {
                            if (item.UsuarioTipo =="Administrador")
                            {
                                Admin a = new Admin();
                                a.Show();
                                this.Close();
                            }
                            if (item.UsuarioTipo == "Control de Datos")
                            {
                                UsuariosLista a = new UsuariosLista();
                                a.Show();
                                this.Close();
                            }
                            if (item.UsuarioTipo == "Master")
                            {
                                MenuPrincipal a = new MenuPrincipal();
                                a.Show();
                                this.Close();
                            }
                            if (item.UsuarioTipo == "Temporal")
                            {
                                Invitado a = new Invitado();
                                a.Show();
                                this.Close();
                            }
                        }
                        else
                        {
                            MessageBox.Show("Contraseña incorrecta", "Login", MessageBoxButton.OK, MessageBoxImage.Error);
                            txbContraseniaLog.Clear();
                            return;
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("No ha seleccionado ningun Usuario ", "Usuarios", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
        }
    }
}
