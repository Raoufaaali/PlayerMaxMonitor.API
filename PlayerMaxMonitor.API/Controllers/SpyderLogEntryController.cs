using PlayerMaxMonitor.API.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PlayerMaxMonitor.API.Controllers
{
    public class SpyderLogEntryController : ApiController
    {
        // GET: api/SpyderLogEntry
        public void Get()
        {

        }

        // GET: api/SpyderLogEntry/5
        public IHttpActionResult Get(int id)
        {
            SpyderLogEntry entry = new SpyderLogEntry();
            bool isResultFound = false;

            try
            {
                SqlDataReader reader = null;
                SqlConnection myConnection = new SqlConnection();
                myConnection.ConnectionString = ConfigurationManager.ConnectionStrings["PlayerMaxMonitorDB"].ConnectionString;

                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.CommandType = CommandType.Text;
                sqlCmd.CommandText = "SELECT * FROM Log_SpyderRequests WHERE ID = " + id;
                sqlCmd.Connection = myConnection;
                myConnection.Open();
                reader = sqlCmd.ExecuteReader();
               
                while (reader.Read())
                {
                    
                    isResultFound = true;
                    entry.Id = Convert.ToInt32(reader.GetValue(0));
                    entry.Call = reader.GetValue(1).ToString();
                    entry.isSuccess = Convert.ToBoolean(reader.GetValue(2));
                    entry.ResponseCode = Convert.ToInt32(reader.GetValue(3));
                    entry.Timestamp = reader.GetDateTime(4);
                    entry.ElapsedMS = Convert.ToInt32(reader.GetValue(5));
                    entry.LatencyMS = Convert.ToInt32(reader.GetValue(6));
                    entry.URL = reader.GetValue(7).ToString();
                    entry.ResosnseMessage = reader.GetValue(8).ToString();
                    
                }

                myConnection.Close();                
            }

            catch (Exception e)
            {
                //TODO Log the exception somewhere
                return InternalServerError();
            }

            if (isResultFound)
            {
                return Ok(entry);
            }
            else
            {
                return NotFound();
            }

            
        }

        // POST: api/SpyderLogEntry
        [HttpPost]
        public IHttpActionResult AddSpyderLogEntry([FromBody]SpyderLogEntry spyderLogEntry)
        {


            try {
                SqlConnection myConnection = new SqlConnection();
                myConnection.ConnectionString = ConfigurationManager.ConnectionStrings["PlayerMaxMonitorDB"].ConnectionString;
                //SqlCommand sqlCmd = new SqlCommand("INSERT INTO tblEmployee (EmployeeId,Name,ManagerId) Values (@EmployeeId,@Name,@ManagerId)", myConnection);  
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.CommandType = CommandType.Text;
                sqlCmd.CommandText = "INSERT INTO Log_SpyderRequests (Call, isSuccess,ResponseCode,Timestamp,Elapsed_Ms, Latency_Ms, URL,ResponseMessage  ) " +
                    "Values ( @Call, @isSuccess, @ResponseCode, @Timestamp, @Elapsed_Ms, @Latency_Ms, @URL,@ResponseMessage)";
                sqlCmd.Connection = myConnection;

                sqlCmd.Parameters.AddWithValue("@Call", spyderLogEntry.Call);
                sqlCmd.Parameters.AddWithValue("@isSuccess", spyderLogEntry.isSuccess);
                sqlCmd.Parameters.AddWithValue("@ResponseCode", spyderLogEntry.ResponseCode);      
                sqlCmd.Parameters.AddWithValue("@Timestamp", spyderLogEntry.Timestamp);
                sqlCmd.Parameters.AddWithValue("@Elapsed_Ms", spyderLogEntry.ElapsedMS);
                sqlCmd.Parameters.AddWithValue("@Latency_Ms", spyderLogEntry.LatencyMS);
                sqlCmd.Parameters.AddWithValue("@URL", spyderLogEntry.URL);
                sqlCmd.Parameters.AddWithValue("@ResponseMessage", spyderLogEntry.ResosnseMessage);

                myConnection.Open();
                int rowInserted = sqlCmd.ExecuteNonQuery();
                myConnection.Close();               
            }
            catch (Exception e)
            {
                //TODO Log the exception somewhere
                return InternalServerError();
            }

            return Ok("Inserted Successfully");
           
        }

        // PUT: api/SpyderLogEntry/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/SpyderLogEntry/5
        public void Delete(int id)
        {
        }

    }
}
