using System;
using Parcial1.Entidades;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Parcial1.DAL;
using Parcial1.Entidades;

namespace Parcial1.BLL
{
    
    public class ProductosBLL
    {
       public static bool Existe(int productoId)
       {
           Contexto contexto = new Contexto();
           bool encontrado = false;

           try
           {
               encontrado = contexto.Productos.Any(l => l.ProductoId == productoId);
               
           }
           catch (Exception)
           {
             throw;
           }
           finally
           {
               contexto.Dispose();
           }
           return encontrado;
       }

          public static bool Guardar(Productos productos)
          {
              if (!Existe(productos.ProductoId))
                  return Insertar (productos);

              else
                  return Modificar(productos);

          }

          public static bool Insertar (Productos producto)
          {
              Contexto contexto = new Contexto();
              bool paso = false;
              try
              {
                  contexto.Productos.Add(producto);
                  paso = contexto.SaveChanges() >0;
              }
              catch (Exception)
              {
                  throw;
              }
              finally
              {
                contexto.Dispose();
              }
              return paso;
        
          }

          public static bool Modificar(Productos producto)
          {
              Contexto contexto = new Contexto();
              bool paso = false;
              try 
              {
                  contexto.Entry(producto).State = EntityState.Modified;
                  paso = contexto.SaveChanges() > 0;

              }
              catch (Exception)
              {
                  throw;
              }
              finally
              {
                  contexto.Dispose();
              }
              return paso;
          }

          public static bool Eliminar (int productoId)
          {
              Contexto contexto = new Contexto();
              bool paso = false;
              try
              {
                  var producto = contexto.Productos.Find(productoId);
                  if (producto != null)

                  {
                      contexto.Productos.Remove(producto);
                      paso = contexto.SaveChanges() > 0;

                  }
              }
              catch (Exception)
              {
                  throw;
              }
              finally
              {
                  contexto.Dispose();
              }
              return paso;
          }

          public static Productos? Buscar(int productoId)
          {
              Contexto contexto = new Contexto();
              Productos? producto;
              try 
              {
                 producto = contexto.Productos.Find(productoId);
              }

              catch (Exception)
              {
                  throw;
              }
              finally
              {
                  contexto.Dispose();
              }
              return producto;
          }

          public static List<Productos> GetList (Expression<Func<Productos, bool>> criterio)
          {
              Contexto contexto = new Contexto();
              List<Productos> lista = new List<Productos>();

              try
              {
                  lista = contexto.Productos.Where(criterio).ToList();
              }
              catch (Exception)
              {
                  throw;
              }
              finally
              {
                  contexto.Dispose();
              }
              return lista;
          }
 
    }
    
}