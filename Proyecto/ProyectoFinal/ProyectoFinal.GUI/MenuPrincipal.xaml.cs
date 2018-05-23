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
    /// Interaction logic for MenuPrincipal.xaml
    /// </summary>
    public partial class MenuPrincipal : Window
    {
        public MenuPrincipal()
        {
            InitializeComponent();
        }

        private void btnAdmin_Click(object sender, RoutedEventArgs e)
        {
            Admin abrir = new Admin();
            abrir.Show();
            this.Close();
        }

        private void btnControl_Click(object sender, RoutedEventArgs e)
        {
            UsuariosLista abrir = new UsuariosLista();
            abrir.Show();
            this.Close();
        }

        private void btnInvitado_Click(object sender, RoutedEventArgs e)
        {
            Invitado abrir = new Invitado();
            abrir.Show();
            this.Close();
        }

        private void btnSalir_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
