using System;
using System.Collections.Generic;
using System.Data;
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

namespace Semana03_WPF_ejemplo1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ClsDatos obj = new ClsDatos();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnConsultar_Click(object sender, RoutedEventArgs e)
        {
            dataGridPedido.ItemsSource = obj
                .getListOrderDate(Convert.ToDateTime(txtFechaInicio.Text), Convert.ToDateTime(txtFechaFin.Text))
                .DefaultView;


        }

        private void DataGridPedido_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int idPedido;
            var item = dataGridPedido.SelectedItem as DataRowView;
            if (item == null) return;
            idPedido = Convert.ToInt32(item.Row["IdPedido"]);
            dataGridDetallePedido.ItemsSource = obj.getDetailsList(idPedido).DefaultView;
            txtTotal.Text = Convert.ToString(obj.totalOrder(idPedido));
        }
    }
}
