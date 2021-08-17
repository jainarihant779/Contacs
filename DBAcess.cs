using Contacs.Models;
using Contacs.Services;


using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Contacs
{
    public class DBAcess:IDbAccess
    {
        public IConfiguration Configuration { get; }
        string connectionString = string.Empty;
        public DBAcess (IConfiguration configuration)
        {

            Configuration = configuration;
            connectionString = Configuration["ConnectionStrings:DefaultConnection"];
        }
  

        public IEnumerable<Details> GetAllDetails()
        {
            List<Details> lstContacts= new List<Details>();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("Select * from tbl_Contacts", con);
                cmd.CommandType = CommandType.Text ;
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    Details objDetails = new Details();
                    objDetails.ID  = Convert.ToInt32(rdr["Id"]);
                    objDetails.FName  = rdr["FirstName"].ToString();
                    objDetails.LName  = rdr["LastName"].ToString();
                    objDetails.Email = rdr["Email"].ToString();
                    objDetails.PNumber  = rdr["PhoneNumber"].ToString();
                    objDetails.Status  =  Convert.ToBoolean( rdr["status"]);

                    lstContacts.Add(objDetails);
                }
                con.Close();
            }
            return lstContacts;
        }
        public void AddContact(Details objdetails)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO tbl_Contacts VALUES(@FName, @LName,@Email,@PNumber,@Status)", con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@FName", objdetails.FName);
                cmd.Parameters.AddWithValue("@LName", objdetails.LName);
                cmd.Parameters.AddWithValue("@Email", objdetails.Email);
                cmd.Parameters.AddWithValue("@PNumber", objdetails.PNumber);
                cmd.Parameters.AddWithValue("@Status", objdetails.Status);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public void UpdateDetails(Details objdetails)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("update tbl_Contacts set FirstName= '" + objdetails .FName+ "', LastName= '" + objdetails.LName + "' , EMAIL=' " + objdetails.Email + "',PhoneNumber = '"+ objdetails .PNumber + "',status = '" + objdetails.Status + "' where id =   '" + objdetails.ID+"' ", con);
                cmd.CommandType = CommandType.Text;
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public void DeleteContact(int? id)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("delete from tbl_Contacts where id = " + id + " ", con);
                cmd.CommandType = CommandType.Text;
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
    }
    
}
