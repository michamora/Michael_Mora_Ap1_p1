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
                    case 0: // Descripcion
                    listado = ProductosBLL.GetList( l => l.Descripcion.Contains(CriterioTextBox.Text));
                    break;

                    case 1: // Esistencia
                    listado = ProductosBLL.GetList( l => l.Existencia.Contains(CriterioTextBox.Text));
                    break;

                    case 2: // Costo
                    listado = ProductosBLL.GetList( l => l.Costo.Contains(CriterioTextBox.Text));
                    break;

                    case 3: // Valor Inventario
                    listado = ProductosBLL.GetList( l => l.ValorInventario.Contains(CriterioTextBox.Text));
                    break;
                }
            }

           ProductosDataGrid.ItemsSource = null;
           ProductosDataGrid.ItemsSource = listado;

           
              }
               
          }

        }

    
