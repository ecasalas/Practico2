using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using System.Web.Http.Cors;



namespace WebAPI.Controllers
{
    [EnableCors(origins: "http://localhost/api/Test", headers: "", methods: "")]
    public class TestController : ApiController
    {
        // GET: api/Test
        public HttpResponseMessage Get()
        {
            return new HttpResponseMessage()
            {
                Content = new StringContent("Get : Testeandooooo")
            };
        }


        // POST: api/Test
        public HttpResponseMessage  Post()
        {
            return new HttpResponseMessage()
            {
                Content = new StringContent("post : Testeandooooo ")
            };
        }

        // PUT: api/Test/5
        public HttpResponseMessage Put()
        {
            return new HttpResponseMessage()
            {
                Content = new StringContent("PUT : Testeandooooo ")
            };
        }

     
    }
}
