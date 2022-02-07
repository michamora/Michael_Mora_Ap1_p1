using System.ComponentModel.DataAnnotations;

namespace Parcial1.Entidades
{
   public class Productos

   {
       [Key]

       public int ProductoId {get; set;}

       public string Descripcion{ get; set;}

       public string Existencia{ get; set;}

       public string Costo{ get; set;}

       public string ValorInventario{ get; set;}

   }
}