using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _1275_MIRKAM_CUSTOMER_API.Models
{
    public class Response
    {
     
        public static JObject GetCustomerResponse(bool issuccess, Customer customer, string errorMessage)
        {
            JObject json = new JObject(
                     new JProperty("RequestID", customer.RequestID),
                     new JProperty("CustomerNumber", customer.CustomerNumber),
                     new JProperty("isSuccess", issuccess),
                     new JProperty("Errors",new JArray(new JObject(new JProperty("error", errorMessage))))
                     );
            return json;
        }

        public static JObject GetSubCustomerResponse(bool issuccess, SubCustomer subCustomer, string errorMessage)
        {
            JObject json = new JObject(
                     new JProperty("RequestID", subCustomer.RequestID),
                     new JProperty("CustomerNumber", subCustomer.CustomerNumber),
                     new JProperty("SubCustomerNumber", subCustomer.SubCustomerNumber),
                     new JProperty("isSuccess", issuccess),
                     new JProperty("Errors", new JArray(new JObject(new JProperty("error", errorMessage))))
                     );
            return json;
        }
    }
}