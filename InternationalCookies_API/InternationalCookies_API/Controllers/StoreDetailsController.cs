using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using InternationalCookies_DAL;
using InternationalCookies_DAL.Interfaces;
using System.Web.Http.Cors;

namespace InternationalCookies_API.Controllers
{
    [EnableCors(origins: "http://localhost:4200", headers:"*", methods:"*")]
    public class StoreDetailsController : ApiController
    {
        private readonly IStoreDetails _storeDetails;
        public StoreDetailsController(IStoreDetails storeDetails)
        {
            this._storeDetails = storeDetails;
        }
        // GET: api/StoreDetails
        [HttpGet]
        public IHttpActionResult Get()
        {
            List<StoreDetail> storeDetails = _storeDetails.GetStoreDetails();
            if (storeDetails != null && storeDetails.Count() > 0)
                return Ok(storeDetails);
            else
                return NotFound();             
        }

        // GET: api/StoreDetails/5
        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            StoreDetail storeDetail = _storeDetails.GetStoreDetail(id);
            if (storeDetail != null)
                return Ok(storeDetail);
            else
                return NotFound();
        }

        // POST: api/StoreDetails
        [HttpPost]
        public void Post([FromBody]StoreDetail storeDetails)
        {
            try
            {
                if (storeDetails != null)
                    _storeDetails.AddStoreDetails(storeDetails);
                else
                    throw new Exception();
            }
            catch (Exception ex)
            {
                var message = new HttpResponseMessage(HttpStatusCode.BadRequest)
                {
                    Content = new StringContent("Exception occured while saving value to DB. May be check the Store Details")
                };
                throw new HttpResponseException(message);
            }
        }

        // PUT: api/StoreDetails/5
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        // DELETE: api/StoreDetails/5
        //public void Delete(int id)
        //{
        //}
    }
}
