using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab3TechSupportIncidentsASP.App_Code
{
    //*************************************
    //SPORTS PRO INC. (Lab3)(ASP.NET)
    //INCIDENT CLASS (C# code)
    //Dean Jones
    //Jan.17, 2017
    //*************************************

    public class Incident
    {
        //CONSTRUCTOR
        public Incident() { }

        //GETTERS AND SETTERS
        public int IncidentID { get; set; }
        public int CustomerID { get; set; }
        public string ProductCode { get; set; }
        public int? TechID { get; set; }
        public DateTime DateOpened { get; set; }
        public DateTime? DateClosed { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        //add customer name (Customers table)
        public string Name { get; set; }


    }
}