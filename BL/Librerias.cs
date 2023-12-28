using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;  
using System.Threading.Tasks;

namespace BL
{
    public class Librerias
    {
        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();
            try
            {
                using(DL.ExamenBBabelEntities context = new DL.ExamenBBabelEntities())
                {
                    var query = context.GetAll().ToList();
                    if (query.Count > 0)
                    {
                        result.Objects = new List<object>();
                        foreach (var item in query)
                        {
                            ML.Localizacion localizacion = new ML.Localizacion();
                            localizacion.Libros = new ML.Libros();
                            localizacion.Libros.IdLibros = (int)item.IdLibro;
                            localizacion.Libros.NumeroVolumne = (int)item.NumeroVolumen;
                            localizacion.Libros.Titulo = item.Titulo;
                            localizacion.Estante = item.Estante;
                            localizacion.Sala = item.Sala;
                            localizacion.Librero = item.Librero;
                            localizacion.Posicion = item.posicion;

                            result.Objects.Add(localizacion);
                        }
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                    }
                }
            }catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;  
            }
            return result;
        }
        public static ML.Result GetById(int IdLibro)
        {
            ML.Result result = new ML.Result();
            try
            {
                using(DL.ExamenBBabelEntities context = new DL.ExamenBBabelEntities())
                {
                    var query = context.GetById(IdLibro).FirstOrDefault();
                    result.Object = new List<object>();
                    if (query != null)
                    {
                        ML.Localizacion localizacion = new ML.Localizacion();
                        localizacion.Libros = new ML.Libros();
                        localizacion.Libros.IdLibros = (int)query.IdLibro;
                        localizacion.Libros.NumeroVolumne = (int)query.NumeroVolumen;
                        localizacion.Libros.Titulo = query.Titulo;
                        localizacion.Estante = query.Estante;
                        localizacion.Sala = query.Sala;
                        localizacion.Librero = query.Librero;
                        localizacion.Posicion = query.posicion;

                        result.Object = localizacion;
                        result.Correct = true;

                    }
                    else
                    {
                        result.Correct= false;
                    }
                }

            }catch(Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }
        public static ML.Result Add(ML.Localizacion localizacion)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.ExamenBBabelEntities context = new DL.ExamenBBabelEntities())
                {
                    var query = context.Agregar(localizacion.Libros.NumeroVolumne, localizacion.Libros.Titulo, localizacion.Estante, localizacion.Sala, localizacion.Librero, localizacion.Posicion);
                    if(query > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct= false;
                    }
                }

            }catch(Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }
            return result;
                
        }
        public static ML.Result Upadate(ML.Localizacion localizacion)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.ExamenBBabelEntities context = new DL.ExamenBBabelEntities())
                {
                    var query = context.Actualizar(localizacion.Libros.NumeroVolumne, localizacion.Libros.IdLibros, localizacion.Libros.Titulo, localizacion.Estante, localizacion.Sala, localizacion.Librero,localizacion.Posicion);
                    if(query > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct= false;
                    }
                }

            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }
        public static ML.Result Delete(int IdLibro)
        {
            ML.Result result = new ML.Result();
            try
            {
                using(DL.ExamenBBabelEntities context = new DL.ExamenBBabelEntities())
                {
                    var query = context.Eliminar(IdLibro);
                    if(query > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct= false;
                    }
                }

            }catch(Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }
    }
}
