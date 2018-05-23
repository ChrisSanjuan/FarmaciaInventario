using ProyectoFinal.BIZ;
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
    /// Interaction logic for Invitado.xaml
    /// </summary>
    public partial class Invitado : Window
    {
        IManejadorArticulo ManejadorArticulo;
        IManejadorEmpleado ManejadorEmpleado;
        public Invitado()
        {
            InitializeComponent();
            ManejadorArticulo = new ManejadorArticulo(new RepositorioArticulo());
            ManejadorEmpleado = new ManejadorEmpleado(new RepositorioEmpleado());
        }

        private void btnVerProducto_Click(object sender, RoutedEventArgs e)
        {
            dtgInvitado.ItemsSource = null;
            dtgInvitado.ItemsSource = ManejadorArticulo.Listar;
        }

        private void btnLimpiarProducto_Click(object sender, RoutedEventArgs e)
        {
            dtgInvitado.ItemsSource = null;
        }

        private void btnVerEmpleado_Click(object sender, RoutedEventArgs e)
        {
            dtgVerEmpleados.ItemsSource = null;
            dtgVerEmpleados.ItemsSource = ManejadorEmpleado.Listar;
        }

        private void btnLimpiarEmpleados_Click(object sender, RoutedEventArgs e)
        {
            dtgVerEmpleados.ItemsSource = null;
        }
    }
}
