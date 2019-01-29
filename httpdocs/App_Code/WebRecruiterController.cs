using System;
using System.Data;
using System.Data.Common;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Collections.Generic;
using System.Collections;
using System.Timers;
using System.Threading;
using Newtonsoft.Json;
using System.Xml;

/// <summary>
/// Summary description for WebRecruiterController
/// </summary>
public partial class WebRecruiterController
{

    private SqlCommand cmd;
    private SqlConnection conn;
    private SqlDataReader reader;
    private SqlDataAdapter adapter;
    private int userId;
    private int accessRights;
    private string username;
    private string pwd;
    private string connString;
    private bool isSuccessful;
    private SqlParameter outputMsgParam;

	public WebRecruiterController()
	{
        connString = ConfigurationManager.ConnectionStrings["WebRecruiterDBConnectionString"].ConnectionString;
        outputMsgParam = new SqlParameter("@x_output_msg", SqlDbType.VarChar, 50, ParameterDirection.Output, true, 0, 0, "", DataRowVersion.Default, "");
	}

    public string webLogon(string usr, string pwd, out int x_user_id, out int x_cust_id, out int x_user_type, out string x_outputMsg)
    {

        string OUTPUTRESPONSE = "";
        x_cust_id = 0;
        x_user_id = 0;
        x_user_type = 0;
        x_outputMsg = "";

        try
        {


            conn = new SqlConnection(connString);
            cmd = conn.CreateCommand();
            cmd.CommandText = "web_login";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@p_email", usr));
            cmd.Parameters.Add(new SqlParameter("@p_password", pwd));


            SqlParameter outputCustIDParam = new SqlParameter();
            outputCustIDParam.DbType = DbType.Int32;
            outputCustIDParam.Direction = ParameterDirection.Output;
            outputCustIDParam.ParameterName = "@x_cust_id";

            SqlParameter outputUserIDParam = new SqlParameter();
            outputUserIDParam.DbType = DbType.Int32;
            outputUserIDParam.Direction = ParameterDirection.Output;
            outputUserIDParam.ParameterName = "@x_user_id";

            SqlParameter outputUserTypeParam = new SqlParameter();
            outputUserTypeParam.DbType = DbType.Int32;
            outputUserTypeParam.Direction = ParameterDirection.Output;
            outputUserTypeParam.ParameterName = "@x_user_type";

            cmd.Parameters.Add(outputUserIDParam);
            cmd.Parameters.Add(outputCustIDParam);
            cmd.Parameters.Add(outputUserTypeParam);
            cmd.Parameters.Add(outputMsgParam);


            conn.Open();
            cmd.ExecuteNonQuery();

            try
            {
                OUTPUTRESPONSE = cmd.Parameters["@x_output_msg"].Value.ToString();
            }
            catch (Exception ex)
            {


            }


            if (OUTPUTRESPONSE.Contains("ok"))
            {




                bool userIDWasParsed;
                try
                {
                    userIDWasParsed = Int32.TryParse(cmd.Parameters["@x_user_id"].Value.ToString(), out x_user_id);

                }
                catch (Exception ex)
                {
                    x_outputMsg = "Problem parsing userID(INT); " + ex.Message.ToString();
                }


                bool custIDWasParsed;
                try
                {
                    custIDWasParsed = Int32.TryParse(cmd.Parameters["@x_cust_id"].Value.ToString(), out x_cust_id);

                }
                catch (Exception ex)
                {
                    x_outputMsg = "Problem parsing custID(INT); " + ex.Message.ToString();
                }


                bool userTypeWasParsed;
                try
                {
                    userTypeWasParsed = Int32.TryParse(cmd.Parameters["@x_user_type"].Value.ToString(), out x_user_type);

                }
                catch (Exception ex)
                {
                    x_outputMsg = "Problem parsing UserType(INT); " + ex.Message.ToString();
                }

            }
            else
            {
                x_cust_id = 0;
                x_user_id = 0;
                x_user_type = 0;
            }

            try
            {
                x_outputMsg = cmd.Parameters["@x_output_msg"].Value.ToString();
            }
            catch (Exception ex)
            {


            }

            HttpCookie myCookie = new HttpCookie("UserSettings");
            string Cdata = String.Concat(x_user_id.ToString(), "|", x_user_type.ToString(), "|", pwd);
            byte[] byt = System.Text.Encoding.UTF8.GetBytes(Cdata);
            string encodedData = Convert.ToBase64String(byt);
            myCookie.Value = Arakkis.EnCryptDecrypt.CryptorEngine.Encrypt(encodedData, true); ;
            myCookie.Expires = DateTime.Now.AddDays(1d);
            HttpContext.Current.Response.Cookies.Add(myCookie);

            return OUTPUTRESPONSE;
        }
        catch (Exception ex)
        {
            x_outputMsg = ex.Message;
            isSuccessful = false;
            return x_outputMsg;
        }
        finally
        {
            conn.Close();
        }

    }

    public string webRegister(string usr, string eml, string pwd, string typ, out int x_user_id, out int x_cust_id, out int x_user_type, out string x_outputMsg)
    {

        string OUTPUTRESPONSE = "";
        x_cust_id = 0;
        x_user_id = 0;
        x_user_type = 0;
        x_outputMsg = "";

        try
        {


            conn = new SqlConnection(connString);
            cmd = conn.CreateCommand();
            cmd.CommandText = "web_register";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@p_username", usr));
            cmd.Parameters.Add(new SqlParameter("@p_email", eml));
            cmd.Parameters.Add(new SqlParameter("@p_password", pwd));
            cmd.Parameters.Add(new SqlParameter("@p_user_type", typ));

            SqlParameter outputUserIDParam = new SqlParameter();
            outputUserIDParam.DbType = DbType.Int32;
            outputUserIDParam.Direction = ParameterDirection.Output;
            outputUserIDParam.ParameterName = "@x_user_id";

            SqlParameter outputUserTypeParam = new SqlParameter();
            outputUserTypeParam.DbType = DbType.Int32;
            outputUserTypeParam.Direction = ParameterDirection.Output;
            outputUserTypeParam.ParameterName = "@x_user_type";

            cmd.Parameters.Add(outputUserIDParam);
            cmd.Parameters.Add(outputUserTypeParam);
            cmd.Parameters.Add(outputMsgParam);


            conn.Open();
            cmd.ExecuteNonQuery();

            try
            {
                OUTPUTRESPONSE = cmd.Parameters["@x_output_msg"].Value.ToString();
            }
            catch (Exception ex)
            {


            }


            if (OUTPUTRESPONSE.Contains("ok"))
            {




                bool userIDWasParsed;
                try
                {
                    userIDWasParsed = Int32.TryParse(cmd.Parameters["@x_user_id"].Value.ToString(), out x_user_id);

                }
                catch (Exception ex)
                {
                    x_outputMsg = "Problem parsing userID(INT); " + ex.Message.ToString();
                }

                bool userTypeWasParsed;
                try
                {
                    userTypeWasParsed = Int32.TryParse(cmd.Parameters["@x_user_type"].Value.ToString(), out x_user_type);

                }
                catch (Exception ex)
                {
                    x_outputMsg = "Problem parsing user_type(INT); " + ex.Message.ToString();
                }

            }
            else
            {
                x_user_id = 0;
                x_user_type = 0;
            }

            try
            {
                x_outputMsg = cmd.Parameters["@x_output_msg"].Value.ToString();
            }
            catch (Exception ex)
            {


            }

            return OUTPUTRESPONSE;
        }
        catch (Exception ex)
        {
            x_outputMsg = ex.Message;
            isSuccessful = false;
            return x_outputMsg;
        }
        finally
        {
            conn.Close();
        }


    }

    public string webJobPost(string usr, string emp, string tit, string des, out int x_job_id, out string x_outputMsg)
    {

        string OUTPUTRESPONSE = "";
        x_job_id = 0;
        x_outputMsg = "";

        try
        {

            conn = new SqlConnection(connString);
            cmd = conn.CreateCommand();
            cmd.CommandText = "web_post_job";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@p_user_id", usr));
            cmd.Parameters.Add(new SqlParameter("@p_employer", emp));
            cmd.Parameters.Add(new SqlParameter("@p_title", tit));
            cmd.Parameters.Add(new SqlParameter("@p_description", des));


            SqlParameter outputJobIDParam = new SqlParameter();
            outputJobIDParam.DbType = DbType.Int32;
            outputJobIDParam.Direction = ParameterDirection.Output;
            outputJobIDParam.ParameterName = "@x_job_id";

            cmd.Parameters.Add(outputJobIDParam);
            cmd.Parameters.Add(outputMsgParam);


            conn.Open();
            cmd.ExecuteNonQuery();

            try
            {
                OUTPUTRESPONSE = cmd.Parameters["@x_output_msg"].Value.ToString();
            }
            catch (Exception ex)
            {
            }


            if (OUTPUTRESPONSE.Contains("ok"))
            {

                bool jobIDWasParsed;
                try
                {
                    jobIDWasParsed = Int32.TryParse(cmd.Parameters["@x_job_id"].Value.ToString(), out x_job_id);
                }
                catch (Exception ex)
                {
                    x_outputMsg = "Problem parsing jobID(INT); " + ex.Message.ToString();
                }

            }
            else
            {
                x_job_id = 0;
            }

            try
            {
                x_outputMsg = cmd.Parameters["@x_output_msg"].Value.ToString();
            }
            catch (Exception ex)
            {
            }

            return OUTPUTRESPONSE;
        }
        catch (Exception ex)
        {
            x_outputMsg = ex.Message;
            isSuccessful = false;
            return x_outputMsg;
        }
        finally
        {
            conn.Close();
        }


    }

    public string webJobsGet(string usr, int records, out string Data, out string x_outputMsg)
    {

        string OUTPUTRESPONSE = "";

        Data = "";
        x_outputMsg = "";

        DataSet ds1 = new DataSet();
        DataTable dt = new DataTable();

        List<Models.Job> JobCollection = new List<Models.Job>();
        try
        {


            conn = new SqlConnection(connString);
            cmd = conn.CreateCommand();
            cmd.CommandText = "web_get_jobs";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@p_user_id", usr));
           
            cmd.Parameters.Add(outputMsgParam);


            SqlDataAdapter SqlDa = new SqlDataAdapter();

            SqlDa.SelectCommand = cmd;

            // SqlDa.SelectCommand.CommandType = CommandType.StoredProcedure;
            SqlDa.Fill(dt);

            try
            {
                OUTPUTRESPONSE = cmd.Parameters["@x_output_msg"].Value.ToString();
            }
            catch (Exception ex)
            {
            }


            if (OUTPUTRESPONSE.Contains("ok"))
            {

                try
                {
                    HttpContext.Current.Session["Start"] = "Starting";
                    HttpContext.Current.Session["ROWSEVENT"] = dt;

                    foreach (DataRow row in dt.Rows)
                    {
                        Models.Job theJob = new Models.Job();
                        
                        theJob.Employer = row[0].ToString();
                        theJob.Title = row[1].ToString();
                        theJob.Description = row[2].ToString();
                        theJob.ID = row[3].ToString();
                        theJob.PosterID = row[4].ToString();
                        theJob.Data = row[5].ToString();

                        if (row[6].ToString() == "False")
                        {
                            theJob.CanApply = "disabled";
                        }
                        else
                        {
                            theJob.CanApply = "";
                        }

                        JobCollection.Add(theJob);

                    }

                    Data = JsonConvert.SerializeObject(JobCollection);
                    HttpContext.Current.Session["JSONSTRING11"] = Data;

                }
                catch (Exception ex)
                {
                    x_outputMsg += "Problem parsing Data; " + ex.Message.ToString();
                }
                
            }
            else
            {
                Data = "";
                x_outputMsg = "";
            }


            try
            {
                x_outputMsg += Convert.ToString(outputMsgParam.Value);
            }
            catch (Exception ex)
            {
            }

           return OUTPUTRESPONSE;
        }
        catch (Exception ex)
        {
            x_outputMsg = ex.Message;
            isSuccessful = false;
            return x_outputMsg;
        }
        finally
        {
            conn.Close();
        }


    }

    public string webJobApply(string usr,  string jid, out int x_job_id, out string x_outputMsg)
    {

        string OUTPUTRESPONSE = "";
        x_job_id = 0;
        x_outputMsg = "";

        try
        {


            conn = new SqlConnection(connString);
            cmd = conn.CreateCommand();
            cmd.CommandText = "web_apply_job";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@p_user_id", usr));
            cmd.Parameters.Add(new SqlParameter("@p_job_id", jid));

            SqlParameter outputJobIDParam = new SqlParameter();
            outputJobIDParam.DbType = DbType.Int32;
            outputJobIDParam.Direction = ParameterDirection.Output;
            outputJobIDParam.ParameterName = "@x_job_id";

            cmd.Parameters.Add(outputJobIDParam);
            cmd.Parameters.Add(outputMsgParam);

            conn.Open();
            cmd.ExecuteNonQuery();

            try
            {
                OUTPUTRESPONSE = cmd.Parameters["@x_output_msg"].Value.ToString();
            }
            catch (Exception ex)
            {
            }


            if (OUTPUTRESPONSE.Contains("ok"))
            {

                bool jobIDWasParsed;
                try
                {
                    jobIDWasParsed = Int32.TryParse(cmd.Parameters["@x_job_id"].Value.ToString(), out x_job_id);

                }
                catch (Exception ex)
                {
                    x_outputMsg = "Problem parsing jobID(INT); " + ex.Message.ToString();
                }

            }
            else
            {
                x_job_id = 0;
            }

            try
            {
                x_outputMsg = cmd.Parameters["@x_output_msg"].Value.ToString();
            }
            catch (Exception ex)
            {


            }

            return OUTPUTRESPONSE;
        }
        catch (Exception ex)
        {
            x_outputMsg = ex.Message;
            isSuccessful = false;
            return x_outputMsg;
        }
        finally
        {
            conn.Close();
        }

    }

    public string webJobApplyGet(string jib, int records, out string Data, out string x_outputMsg)
    {

        string OUTPUTRESPONSE = "";

        Data = "";
        x_outputMsg = "";
        DataSet ds1 = new DataSet();
        DataTable dt = new DataTable();

        List<Models.JobApply> JobApplyCollection = new List<Models.JobApply>();
        try
        {


            conn = new SqlConnection(connString);
            cmd = conn.CreateCommand();
            cmd.CommandText = "web_get_job_applys";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@p_job_id", jib));

            cmd.Parameters.Add(outputMsgParam);

            SqlDataAdapter SqlDa = new SqlDataAdapter();

            SqlDa.SelectCommand = cmd;

            // SqlDa.SelectCommand.CommandType = CommandType.StoredProcedure;
            SqlDa.Fill(dt);

            try
            {
                OUTPUTRESPONSE = cmd.Parameters["@x_output_msg"].Value.ToString();
            }
            catch (Exception ex)
            {
            }

            if (OUTPUTRESPONSE.Contains("ok"))
            {

                try
                {
                    HttpContext.Current.Session["Start"] = "Starting";
                    HttpContext.Current.Session["ROWSEVENT"] = dt;

                    foreach (DataRow row in dt.Rows)
                    {
                        Models.JobApply theJobApply = new Models.JobApply();

                        theJobApply.Username = row[0].ToString();
                        theJobApply.Email = row[1].ToString();
                        theJobApply.ApplyDate = row[2].ToString();
                        theJobApply.JobID = row[3].ToString();

                        JobApplyCollection.Add(theJobApply);

                    }

                    Data = JsonConvert.SerializeObject(JobApplyCollection);
                    HttpContext.Current.Session["JSONSTRING11"] = Data;

                }
                catch (Exception ex)
                {
                    x_outputMsg += "Problem parsing Data; " + ex.Message.ToString();
                }

            }
            else
            {
                Data = "";
                x_outputMsg = "";
            }

            try
            {
                x_outputMsg += Convert.ToString(outputMsgParam.Value);
            }
            catch (Exception ex)
            {
            }

            return OUTPUTRESPONSE;
        }
        catch (Exception ex)
        {
            x_outputMsg = ex.Message;
            isSuccessful = false;
            return x_outputMsg;
        }
        finally
        {
            conn.Close();
        }


    }


}
