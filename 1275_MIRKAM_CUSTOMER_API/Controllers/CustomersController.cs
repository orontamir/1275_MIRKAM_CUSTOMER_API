using _1275_MIRKAM_CUSTOMER_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace _1275_MIRKAM_CUSTOMER_API.Controllers
{
    public class CustomersController : ApiController
    {
        // POST: api/Customers
        /// <summary>
        /// Insert a new Customer in the Data Base
        /// </summary>
        /// <param name="value">New Customer insert to Mirkam Data Base</param>
        /// <returns>OK is succeeded</returns>
        /// <returns>Error code 403 , forbidden if not succeeded </returns>
        [Obsolete("Message")]
        public HttpResponseMessage Post([FromBody]Customer value)
        {
            string errorMessage = "";
            try
            {
              
                if (DataBase.DBParser.Instance().InsertCustomer(value, out errorMessage))
                {
                    return Request.CreateResponse(HttpStatusCode.OK, Response.GetCustomerResponse(true, value, ""));
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.Forbidden, Response.GetCustomerResponse(false, value, errorMessage));
                }
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.Forbidden, Response.GetCustomerResponse(false, value, errorMessage));
            }
        }

        // PUT: api/Customers/5
        /// <summary>
        /// Update customer with request id 
        /// </summary>
        /// <param name="id">Requst Id</param>
        /// <param name="value">Customer details</param>
        /// <returns>OK is succeeded</returns>
        /// <returns>Error code 403 , forbidden if not succeeded </returns>
        [Obsolete("Message")]
        public HttpResponseMessage Put(string id, [FromBody]Customer value)
        {

            string errorMessage = "";
            try
            {

                if (DataBase.DBParser.Instance().UpdateCustomer(value, id, ErrorMessage: out errorMessage))
                {

                    return Request.CreateResponse(HttpStatusCode.OK, Response.GetCustomerResponse(true,value,""));
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.Forbidden, Response.GetCustomerResponse(false, value, errorMessage));
                }
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.Forbidden, Response.GetCustomerResponse(false, value, errorMessage));
            }
        }
    }
}
