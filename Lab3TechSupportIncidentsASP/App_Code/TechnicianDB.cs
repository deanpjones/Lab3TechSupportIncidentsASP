using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Lab3TechSupportIncidentsASP.App_Code
{
    //*************************************
    //SPORTS PRO INC. (Lab3)(ASP.NET)
    //TECHNICIAN DATABASE CLASS (C# code)
    //Dean Jones
    //Jan.17, 2017
    //*************************************

    [DataObject(true)]
    public static class TechnicianDB
    {
        [DataObjectMethod(DataObjectMethodType.Select)]
        // retrieves technician with given ID
        public static Technician GetTechnician(int techID)
        {
            Technician tech = null; // found technician

            // define connection
            SqlConnection connection = TechSupportDB.GetConnection(); 

            // define the select query command
            string selectQuery = "SELECT TechID, Name, Email, Phone " +
                                    "FROM Technicians " +
                                    "WHERE TechID = @TechID";
            SqlCommand selectCommand = new SqlCommand(selectQuery, connection);
            selectCommand.Parameters.AddWithValue("@TechID", techID);
            try
            {
                // open the connection
                connection.Open();

                // execute the query
                SqlDataReader reader = selectCommand.ExecuteReader(CommandBehavior.SingleRow);

                // process the result if any
                if (reader.Read()) // if there is technician
                {
                tech = new Technician();
                tech.TechID = (int)reader["TechID"];
                tech.Name = reader["Name"].ToString();
                tech.Email = reader["Email"].ToString();
                tech.Phone = reader["Phone"].ToString();
                }
            }
            catch (Exception ex)
            {
                throw ex; // let the form handle it
            }
            finally
            {
                connection.Close(); // close connecto no matter what
            }

            return tech;
        }


        [DataObjectMethod(DataObjectMethodType.Select)]
        //METHOD Lists all Technicians
        public static List<Technician> GetAllTechnicians()
        {
            List<Technician> techList = new List<Technician>(); // empty list
                                    // define connection
            SqlConnection connection = TechSupportDB.GetConnection(); //TechSupportDB.GetConnection();

            // define the select query command
            string selectQuery = "SELECT TechID, Name, Email, Phone " +
                                    "FROM Technicians " +
                                    "ORDER BY Name ASC;";
            SqlCommand selectCommand = new SqlCommand(selectQuery, connection);
            //selectCommand.Parameters.AddWithValue("@TechID", techID);
            try
            {
                // open the connection
                connection.Open();

                // execute the query (ALL COLUMN ENTRIES)
                SqlDataReader reader = selectCommand.ExecuteReader();

                // process the result if any
                while (reader.Read()) // if there is technician
                {
                    Technician tech = new Technician();
                    tech = new Technician();
                    tech.TechID = (int)reader["TechID"];
                    tech.Name = reader["Name"].ToString();
                    tech.Email = reader["Email"].ToString();
                    tech.Phone = reader["Phone"].ToString();

                    //add to list
                    techList.Add(tech);
                }
            }
            catch (Exception ex)
            {
                throw ex; // let the form handle it
            }
            finally
            {
                connection.Close(); // close connecto no matter what
            }

            return techList;
        }
    }
}