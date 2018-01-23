using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab3TechSupportIncidentsASP.App_Code
{
    //*************************************
    //SPORTS PRO INC. (Lab3)(ASP.NET)
    //CUSTOMER CLASS (C# code) (not being used)
    //Dean Jones
    //Jan.17, 2017
    //*************************************

    public class Customer
    {
        //CONSTRUCTOR
        public Customer() { }

        //GETTERS AND SETTERS
        public int CustomerID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }

    }
}