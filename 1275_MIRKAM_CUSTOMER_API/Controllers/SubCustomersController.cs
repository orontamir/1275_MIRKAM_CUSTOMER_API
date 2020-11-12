using _1275_MIRKAM_CUSTOMER_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace _1275_MIRKAM_CUSTOMER_API.Controllers
{
    public class SubCustomersController : ApiController
    {


        // POST: api/SubCustomers
        /// <summary>
        /// Insert a new Sub Customer in the Data Base
        /// </summary>
        /// <param name="value">SubCustomer details</param>
        /// <returns>OK is succeeded</returns>
        /// <returns>Error code 403 , forbidden if not succeeded </returns>
        [Obsolete("Message")]
        public HttpResponseMessage Post([FromBody]SubCustomer value)
        {
            string errorMessage = "";
            try
            {

                if (DataBase.DBParser.Instance().InsertSubCustomer(value, out errorMessage))
                {
                    return Request.CreateResponse(HttpStatusCode.OK, Response.GetSubCustomerResponse(true, value, ""));
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.Forbidden, Response.GetSubCustomerResponse(false, value, errorMessage));
                }
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.Forbidden, Response.GetSubCustomerResponse(false, value, errorMessage));
            }
        }

        // PUT: api/SubCustomers/5
        /// <summary>
        /// Update Sub customer with request id 
        /// </summary>
        /// <param name="id">Requst id</param>
        /// <param name="value">Sub customer details</param>
        /// <returns>OK is succeeded</returns>
        /// <returns>Error code 403 , forbidden if not succeeded </returns>
        [Obsolete("Message")]
        public HttpResponseMessage Put(string id, [FromBody]SubCustomer value)
        {
            string errorMessage = "";
            try
            {

                if (DataBase.DBParser.Instance().UpdateSubCustomer(value, id, out errorMessage))
                {
                    return Request.CreateResponse(HttpStatusCode.OK, Response.GetSubCustomerResponse(true, value, ""));
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.Forbidden, Response.GetSubCustomerResponse(false, value, errorMessage));
                }
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.Forbidden, Response.GetSubCustomerResponse(false, value, errorMessage));
            }
        }

       
    }
}
