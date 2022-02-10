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
using Parcial1;
using Parcial1.Entidades;
using Parcial1.BLL;

namespace Parcial1.UI.Registros
{
    public partial class rProductos : Window
    {
       
        private Productos Producto = new Productos();
        public rProductos()
        {
            InitializeComponent();
            

            this.DataContext = Producto;

            
        }

        private void Cargar()
        {
            this.DataContext = null;
            this.DataContext = this.Producto;
            
        }

        private void Limpiar()
        {
            this.Producto = new Productos();
            this.DataContext = Producto;
            
        }

       

        private bool Validar()
        {
            bool esValido = true;

            if (string.IsNullOrWhiteSpace(Producto.Descripcion))
            {
                esValido = false;
                DescripcionTextBox.Focus();
                MessageBox.Show("Debe ingresar una descripcion", "Validacion", MessageBoxButton.OK, MessageBoxImage.Error);
            }
           else  if (Producto.Existencia < 0)
           {

                esValido = false;
                ExistenciaTextBox.Focus();
                MessageBox.Show("Debe ingresar la existencia", "Validacion", MessageBoxButton.OK, MessageBoxImage.Error);

           }
           else  if (Producto.Costo < 0)
           {

                esValido = false;
                CostoTextBox.Focus();
                MessageBox.Show("Debe ingresar el costo", "Validacion", MessageBoxButton.OK, MessageBoxImage.Error);

           }
            
            return esValido;
        }
        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            var encontrado = ProductosBLL.Buscar(this.Producto.ProductoId);

            if ( encontrado != null)

            {
               this.Producto = encontrado;
               Cargar();
            }
            else 
            {
                Limpiar();
                MessageBox.Show("No se encontro el producto", "Fallo", MessageBoxButton.OK, MessageBoxImage.Error);
            }
           
        
        }

 
        private void NuevoButton_Click(object sender, RoutedEventArgs e)
        {
            Limpiar();
        }


        private void GuardarButton_Click(object sender, RoutedEventArgs e)
        {
           bool paso = false;

           if (!Validar())
           return;

           paso = ProductosBLL.Guardar(Producto);

           if (paso)
           MessageBox.Show("Producto guardado con exito", "Exito", MessageBoxButton.OK, MessageBoxImage.Error);
           else
           MessageBox.Show("No se pudo guardar el producto", "Fallo", MessageBoxButton.OK, MessageBoxImage.Error);     

        }

        private void EliminarButton_Click(object sender, RoutedEventArgs e)
        {
            if (ProductosBLL.Eliminar(Producto.ProductoId))
            {
                Limpiar();
                 MessageBox.Show("Producto eliminado con exito", "Exito", MessageBoxButton.OK, MessageBoxImage.Error);
               
            }
            else
             MessageBox.Show("No se pudo eliminar el producto", "Fallo", MessageBoxButton.OK, MessageBoxImage.Error);
           

        }

         /*void calcularInventario(float Existencia, float Costo){

             Existencia = float.Parse(ExistenciaTextBox.Text);
             Costo = float.Parse(CostoTextBox.Text);

             float ValorInventario = Existencia * Costo;
             ValorInventarioTextBox.Text = Convert.ToString(ValorInventario);
             Producto.ValorInventario = ValorInventario;
        }*/
    }
}
    
    
