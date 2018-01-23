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
    //CUSTOMER DATABASE CLASS (C# code) (not being used)
    //Dean Jones
    //Jan.17, 2017
    //*************************************

    [DataObject(true)]
    public static class CustomerDB
    {
        [DataObjectMethod(DataObjectMethodType.Select)]
        // retrieves customer with given ID
        public static Customer GetCustomer(int custID)
        {
            Customer cust = null; // found customer

            // define connection
            SqlConnection connection = TechSupportDB.GetConnection();

            // define the select query command
            //SELECT * FROM Customers
            //WHERE CustomerID = 1002;
            string selectQuery = "SELECT CustomerID, Name, Address, City, State, ZipCode, Phone, Email " +
                                    "FROM Customers " +
                                    "WHERE CustomerID = @CustomerID";
            SqlCommand selectCommand = new SqlCommand(selectQuery, connection);
            selectCommand.Parameters.AddWithValue("@CustomerID", custID);
            try
            {
                // open the connection
                connection.Open();

                // execute the query
                SqlDataReader reader = selectCommand.ExecuteReader(CommandBehavior.SingleRow);

                // process the result if any
                if (reader.Read()) // if there is technician
                {
                    cust = new Customer();
                    cust.CustomerID = (int)(reader["CustomerID"]);
                    cust.Name = reader["Name"].ToString();
                    cust.Address = reader["Address"].ToString();
                    cust.City = reader["City"].ToString();
                    cust.State = reader["State"].ToString();
                    cust.ZipCode = reader["ZipCode"].ToString();
                    cust.Phone = reader["Phone"].ToString();
                    cust.Email = reader["Email"].ToString();
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

            return cust;
        }
    }
}