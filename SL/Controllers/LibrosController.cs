using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.Serialization;
using System.Web.Http;

namespace SL.Controllers
{
    [KnownType(typeof(ML.Localizacion))]
    [RoutePrefix("api/Libros")]
    public class LibrosController : ApiController
    {
        [Route("")]
        [HttpGet]
        public IHttpActionResult GetAll() 
        {
            ML.Result result= BL.Librerias.GetAll();
            if (result.Correct)
            {
                return Content(HttpStatusCode.OK, result);
            }
            else
            {
                return Content(HttpStatusCode.BadRequest, result);
            }
        }
        [Route("{IdLibro}")]
        [HttpGet]
        public IHttpActionResult GetById(int IdLibro) 
        {
            ML.Result result = BL.Librerias.GetById(IdLibro);
            if(result.Correct)
            {
                return Content(HttpStatusCode.OK, result);
            }else 
            { 
                return Content(HttpStatusCode.BadRequest, result);
            }
        }
        [Route("")]
        [HttpPost]
        public IHttpActionResult Add(ML.Localizacion localizacion)
        {
            ML.Result result = BL.Librerias.Add(localizacion);
            if (result.Correct)
            {
                return Content(HttpStatusCode.OK, result);
            }
            else
            {
                return Content(HttpStatusCode.BadRequest, result);
            }
        }
        [Route("{IdLibro}")]
        [HttpDelete]
        public IHttpActionResult Delete(int IdLibro) 
        {
            ML.Result result = BL.Librerias.Delete(IdLibro);
            if (result.Correct)
            {
                return Content(HttpStatusCode.OK, result);
            }
            else
            {
                return Content(HttpStatusCode.BadRequest, result);
            }
        }
        [Route("{IdLibro}")]
        [HttpPut]
        public IHttpActionResult Update(int IdLibro, [FromBody] ML.Localizacion localizacion)
        {
            localizacion.Libros.IdLibros = IdLibro;
            ML.Result result = BL.Librerias.Upadate(localizacion);
            if (result.Correct)
            {
                return Content(HttpStatusCode.OK, result);
            }
            else
            {
                return Content(HttpStatusCode.BadRequest, result);
            }
        }
        
    }
}
