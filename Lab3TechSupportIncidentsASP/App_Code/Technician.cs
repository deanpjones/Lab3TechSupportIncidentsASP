using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab3TechSupportIncidentsASP.App_Code
{
    //*************************************
    //SPORTS PRO INC. (Lab3)(ASP.NET)
    //TECHNICIAN CLASS (C# code)
    //Dean Jones
    //Jan.17, 2017
    //*************************************

    public class Technician
    {

        //CONSTRUCTOR
        public Technician() { }

        //GETTERS AND SETTERS
        public int TechID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
    }
}