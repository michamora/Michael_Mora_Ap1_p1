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
using Parcial1.UI.Registros;
using Parcial1.UI.Consultas;

namespace Parcial1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
   
        private void RegistroMenuItem_Click(object sender, RoutedEventArgs e)
        {

            var rName = new rName();
            rName.Show();
            
        }


        private void ConsultaMenuItem_Click(object sender, RoutedEventArgs e)
        {
            
             var cName= new cName();
            cName.Show();
             
        }


    }
}