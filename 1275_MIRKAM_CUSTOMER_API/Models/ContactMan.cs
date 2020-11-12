using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _1275_MIRKAM_CUSTOMER_API.Models
{
    public class ContactMan
    {
        public  int Id_Num { get; set; }
        public  int ContactManID {get; set;}
        public  string ContactManName { get; set; }
        public  string ContactManFamilyName { get; set; }
        public  string ContactManPosition { get; set; }
        public  string ContactManPhone { get; set; }
        public  string ContactManPhone2 { get; set; }
        public  string ContactManMobilePhone { get; set; }
        public  string ContactManFax { get; set; }
        public  string ContactManEmail { get; set; }
        public  string ContactManComment { get; set; }
    }
}