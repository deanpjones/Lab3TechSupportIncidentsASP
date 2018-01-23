using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Lab3TechSupportIncidentsASP.App_Code
{
    //*************************************
    //SPORTS PRO INC. (Lab3)(ASP.NET)
    //INCIDENT DATABASE CLASS (C# code)
    //Dean Jones
    //Jan.17, 2017
    //*************************************

    [DataObject(true)]
    public class IncidentDB
    {

        [DataObjectMethod(DataObjectMethodType.Select)]
        // METHOD GET ALL INCIDENTS (per Technician)
        public static List<Incident> GetOpenTechIncidents(int techID)
        {
            List<Incident> incList = new List<Incident>(); // blank list

            // define connection
            SqlConnection connection = TechSupportDB.GetConnection();

            //SELECT IncidentID, CustomerID, ProductCode, TechID, DateOpened, DateClosed, Title, [Description] 
            //FROM Incidents WHERE TechID = 11 AND DateClosed IS NULL
            //ORDER BY DateOpened ASC;
            //
            //SELECT IncidentID, i.CustomerID, c.Name, ProductCode, TechID, DateOpened, DateClosed, Title, [Description]
            //FROM Incidents i
            //INNER JOIN Customers c ON c.CustomerID = i.CustomerID
            //WHERE TechID = 11 AND DateClosed IS NULL
            //ORDER BY DateOpened ASC;
            //
            //(OMIT THE CustomerID below...)
            // define the select query command
            string selectQuery = "SELECT IncidentID, c.Name, ProductCode, TechID, DateOpened, DateClosed, Title, Description " +
                                    "FROM Incidents i " +
                                    "INNER JOIN Customers c ON c.CustomerID = i.CustomerID " +
                                    "WHERE TechID = @TechID " +
                                    "AND DateClosed IS NULL " +
                                    "ORDER BY DateOpened ASC;";
            SqlCommand selectCommand = new SqlCommand(selectQuery, connection);
            selectCommand.Parameters.AddWithValue("@TechID", techID);
            try
            {
                // open the connection
                connection.Open();

                // execute the query (MULTIPLE ROWS)
                SqlDataReader reader = selectCommand.ExecuteReader();

                // process the result if any
                while (reader.Read()) // if there is incident
                {
                    Incident inc = new Incident(); // new object                   
                    inc.IncidentID = (int)reader["IncidentID"];
                    //inc.CustomerID = (int)reader["CustomerID"];       //omit customer id
                    inc.Name = reader[1].ToString();
                    inc.ProductCode = reader["ProductCode"].ToString();
                    inc.TechID = (int)reader["TechID"];
                    inc.DateOpened = (DateTime)reader["DateOpened"];
                    inc.Title = reader["Title"].ToString();
                    inc.Description = reader["Description"].ToString();

                    //handle NULL DateTime
                    if(reader.IsDBNull(reader.GetOrdinal("DateClosed")))    //if SQL NULL
                    {
                        inc.DateClosed = null;                              //then return ASP.NET null
                    }
                    else
                    {
                        inc.DateClosed = (DateTime)reader["DateClosed"];    //else return value
                    }                   

                    //add to list
                    incList.Add(inc);
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

            return incList;
        }
    }
}