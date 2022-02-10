using System.Windows;
using Parcial1.Entidades;
using Parcial1.BLL;
using System.Linq;
using System.Collections.Generic;

namespace Parcial1.UI.Consultas
{
    public partial class cProductos : Window
    {

        public cProductos()
        {
            InitializeComponent();
        }

        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            var listado = new List<Productos>();

            if ( string.IsNullOrWhiteSpace(CriterioTextBox.Text))
            listado = ProductosBLL.GetList(l => true);

            else 
            {

                switch (FiltroComboBox.SelectedIndex)
                {
                    case 0: 
                    int id = int.TryParse(CriterioTextBox.Text, out id) ? id : 0;
                    if (id <= 0)
                    {
                        MessageBox.Show("ID no valido");
                        break;
                    }
                    listado = ProductosBLL.GetList(p => p.ProductoId == id);
                    
                    break;

                    case 1: // Descripcion
                    listado = ProductosBLL.GetList( l => l.Descripcion.Contains(CriterioTextBox.Text));
                    break;

            }

           ProductosDataGrid.ItemsSource = null;
           ProductosDataGrid.ItemsSource = listado;

           
              }
               
          }

        }
}

    
