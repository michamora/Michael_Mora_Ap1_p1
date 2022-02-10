using System.ComponentModel.DataAnnotations;

namespace Parcial1.Entidades
{
   public class Productos

   {
       [Key]

       public int ProductoId {get; set;}
        
      
       public string Descripcion { get; set;}

       
       public float Existencia{ get; set;}
       
        
       public float Costo{ get; set;}

          
       public float ValorInventario{ get; set;}

   }
   
}