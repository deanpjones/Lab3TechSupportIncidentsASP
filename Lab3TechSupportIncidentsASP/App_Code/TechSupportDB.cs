using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Lab3TechSupportIncidentsASP.App_Code
{
    //*************************************
    //SPORTS PRO INC. (Lab3)(ASP.NET)
    //SQL DATABASE CONNECTION (TechSupport database) (C# code)
    //Dean Jones
    //Jan.17, 2017
    //*************************************

    public static class TechSupportDB
    {
        /// <summary>
        /// SQL CONNECTION 
        /// </summary>
        public static SqlConnection GetConnection()
        {
            //string connString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\TechSupport.mdf;Integrated Security=True;Connect Timeout=30";   

            //PULLS CONNECTION STRING OUT OF (WEB.CONFIG) FILE
            string connString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

            SqlConnection conn = new SqlConnection(connString);
            return conn;
        }
    }
}