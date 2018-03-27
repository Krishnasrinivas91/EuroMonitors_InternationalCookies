using InternationalCookies_DAL;
using InternationalCookies_DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace InternationalCookies_API.Controllers
{
    [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
    [RoutePrefix("CookieOrders")]
    public class CookieOrderController : ApiController
    {
        private readonly ICookieOrders _cookieOrders;
        public CookieOrderController(ICookieOrders cookieOrders)
        {
            _cookieOrders = cookieOrders;
        }
        
        // GET: api/CookieOrder/5
        [HttpGet]
        [Route("Get/{id:int}")]
        public IHttpActionResult Get([FromUri]int id)
        {
            List<CookieOrder> cookieOrders = _cookieOrders.GetCookieOrderOfStore(id);
            if (cookieOrders != null && cookieOrders.Count() > 0)
                return Ok(cookieOrders);
            else
                return NotFound();
        }

        // POST: api/CookieOrder
        public void Post([FromBody]CookieOrder cookieOrder)
        {
            try
            {
                _cookieOrders.AddCookieOrder(cookieOrder);
            }
            catch(Exception ex)
            {
                var message = new HttpResponseMessage(HttpStatusCode.BadRequest)
                {
                    Content = new StringContent("Exception occured while saving value to DB")
                };
                throw new HttpResponseException(message);
            }
        }
        
    }
}
