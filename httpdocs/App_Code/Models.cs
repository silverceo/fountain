using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Web.Services;
using System.Collections.Generic;
using System.Web.Script.Services;
using Newtonsoft.Json;


/// <summary>
/// Summary description for Models
/// </summary>
/// 
namespace Models
{
       
    public class Job
    {
        private string _id;
        private string _employer;
        private string _title;
        private string _description;
        private string _poster_id;
        private string _data;
        private string _canApply;



        public string ID
        {
            get { return _id; }
            set { _id = value; }
        }
        public string Employer
        {
            get { return _employer; }
            set { _employer = value; }
        }
        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }
        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }
        public string PosterID
        {
            get { return _poster_id; }
            set { _poster_id = value; }
        }
        public string Data
        {
            get { return _data; }
            set { _data = value; }
        }
        public string CanApply
        {
            get { return _canApply; }
            set { _canApply = value; }
        }
    }

    public class JobApply
    {
        private string _username;
        private string _email;
        private string _applydate;
        private string _jobid;

        public string Username
        {
            get { return _username; }
            set { _username = value; }
        }
        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }
        public string ApplyDate
        {
            get { return _applydate; }
            set { _applydate = value; }
        }
        public string JobID
        {
            get { return _jobid; }
            set { _jobid = value; }
        }
    }

    public class jUser
    {
        private string _username;
        private string _email;
        private string _password;
        private string _ip;
        private string _data;
        private string _type;

        public string Username
        {
            get { return _username; }
            set { _username = value; }
        }
        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }
        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }
        public string IP
        {
            get { return _ip; }
            set { _ip = value; }
        }
        public string Data
        {
            get { return _data; }
            set { _data = value; }
        }
        public string Type
        {
            get { return _type; }
            set { _type = value; }
        }


    }

    public class jUserAuthentication
    {
        private jUser _juser;
        private bool _authencated;

        public jUser jUser
        {
            get { return _juser; }
            set { _juser = value; }
        }
        public bool Authencated
        {
            get { return _authencated; }
            set { _authencated = value; }
        }


        public void validate()
        {
            this.Authencated = false;
            WebRecruiterController webCtrl = new WebRecruiterController();


            string OUTPUTRESPONSE;

            Int32 x_user_id;
            Int32 x_cust_id;
            Int32 x_user_type;
            String x_outputMsg;


            OUTPUTRESPONSE = webCtrl.webLogon(jUser.Username, jUser.Password, out x_user_id, out x_cust_id, out x_user_type, out x_outputMsg);



            if (OUTPUTRESPONSE.Contains("ok"))
            {
                HttpContext.Current.Session["x_user_id"] = x_user_id;
                HttpContext.Current.Session["x_cust_id"] = x_cust_id;
                HttpContext.Current.Session["x_user_type"] = x_user_type;
                HttpContext.Current.Session["x_output_msg"] = x_outputMsg;

                this.Authencated = true;
            }

            jUserAuthenticated jUserAuthed = new jUserAuthenticated();

            jUserAuthed.CustID = x_cust_id.ToString();
            jUserAuthed.ID = x_user_id.ToString();
            jUserAuthed.UserType = x_user_type.ToString();
            jUserAuthed.OutputMsg = x_outputMsg;

            jUser.Data = JsonConvert.SerializeObject(jUserAuthed);

        }
    }

    public class jUserAuthenticated
    {
        private string _id;
        private string _custid;
        private string _x_user_type;
        private string _outputmsg;

        public string ID
        {
            get { return _id; }
            set { _id = value; }
        }
        public string CustID
        {
            get { return _custid; }
            set { _custid = value; }
        }
        public string UserType
        {
            get { return _x_user_type; }
            set { _x_user_type = value; }
        }
        public string OutputMsg
        {
            get { return _outputmsg; }
            set { _outputmsg = value; }
        }
    }

    public class jUserRegistration
    {
        private jUser _juser;
        private bool _registered;
        private string _outputmsg;



        public jUser jUser
        {
            get { return _juser; }
            set { _juser = value; }
        }
        public bool Registered
        {
            get { return _registered; }
            set { _registered = value; }
        }
        public string OutputMsg
        {
            get { return _outputmsg; }
            set { _outputmsg = value; }
        }

        public void register()
        {
            this.Registered = false;
            WebRecruiterController webCtrl = new WebRecruiterController();


            string OUTPUTRESPONSE;

            Int32 x_user_id;
            Int32 x_cust_id;
            Int32 x_user_type;
            String x_outputMsg;

            // Int32 UserType;


            //bool userTypeWasParsed;
            //try
            //{
            //    userTypeWasParsed = Int32.TryParse(jUser.Type, out UserType);

            //}
            //catch (Exception ex)
            //{
            //    x_outputMsg = "Problem parsing userTYPE(INT); " + ex.Message.ToString();
            //}


            OUTPUTRESPONSE = webCtrl.webRegister(jUser.Username, jUser.Email, jUser.Password, jUser.Type, out x_user_id, out x_cust_id, out x_user_type, out x_outputMsg);



            if (OUTPUTRESPONSE.Contains("ok"))
            {
                HttpContext.Current.Session["x_user_id"] = x_user_id;
                //HttpContext.Current.Session["x_cust_id"] = x_cust_id;
                HttpContext.Current.Session["x_user_type"] = x_user_type;
                HttpContext.Current.Session["x_output_msg"] = x_outputMsg;

                this.Registered = true;
            }

            jUserRegistered jUserReged = new jUserRegistered();

            //jUserAuthed.CustID = x_cust_id.ToString();
            jUserReged.ID = x_user_id.ToString();
            jUserReged.UserType = x_user_type.ToString();
            jUserReged.OutputMsg = x_outputMsg;

            jUser.Data = JsonConvert.SerializeObject(jUserReged);

        }

    }

    public class jUserRegistered
    {
        private string _id;
        //private string _custid;
        private string _user_type;
        private string _outputmsg;

        public string ID
        {
            get { return _id; }
            set { _id = value; }
        }
        //public string CustID
        //{
        //    get { return _custid; }
        //    set { _custid = value; }
        //}
        public string UserType
        {
            get { return _user_type; }
            set { _user_type = value; }
        }
        public string OutputMsg
        {
            get { return _outputmsg; }
            set { _outputmsg = value; }
        }
    }

    public class jJob
    {
        private string _id;
        private string _employer;
        private string _title;
        private string _description;
        private string _poster_id;
        private string _data;
        private string _canApply;


        public string ID
        {
            get { return _id; }
            set { _id = value; }
        }
        public string Employer
        {
            get { return _employer; }
            set { _employer = value; }
        }
        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }
        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }
        public string PosterID
        {
            get { return _poster_id; }
            set { _poster_id = value; }
        }
        public string Data
        {
            get { return _data; }
            set { _data = value; }
        }
        public string CanApply
        {
            get { return _canApply; }
            set { _canApply = value; }
        }



    }

    public class jJobPost
    {
        private jJob _jjob;
        private bool _posted;
        private string _outputmsg;



        public jJob jJob
        {
            get { return _jjob; }
            set { _jjob = value; }
        }
        public bool Posted
        {
            get { return _posted; }
            set { _posted = value; }
        }
        public string OutputMsg
        {
            get { return _outputmsg; }
            set { _outputmsg = value; }
        }

        public void postjob()
        {
            this.Posted = false;
            WebRecruiterController webCtrl = new WebRecruiterController();


            string OUTPUTRESPONSE;

            //  Int32 x_user_id;
            Int32 x_job_id;
            //  Int32 x_user_type;
            String x_outputMsg;

            // Int32 UserType;


            //bool userTypeWasParsed;
            //try
            //{
            //    userTypeWasParsed = Int32.TryParse(jUser.Type, out UserType);

            //}
            //catch (Exception ex)
            //{
            //    x_outputMsg = "Problem parsing userTYPE(INT); " + ex.Message.ToString();
            //}


            OUTPUTRESPONSE = webCtrl.webJobPost(jJob.PosterID, jJob.Employer, jJob.Title, jJob.Description, out x_job_id, out x_outputMsg);



            if (OUTPUTRESPONSE.Contains("ok"))
            {
                HttpContext.Current.Session["x_job_id"] = x_job_id;
                //HttpContext.Current.Session["x_cust_id"] = x_cust_id;
                //HttpContext.Current.Session["x_user_type"] = x_user_type;
                HttpContext.Current.Session["x_output_msg"] = x_outputMsg;

                this.Posted = true;
            }

            jJobPosted jJobPostComplete = new jJobPosted();

            //jUserAuthed.CustID = x_cust_id.ToString();
            jJobPostComplete.ID = x_job_id.ToString();
            //jJobPostComplete.UserType = x_user_type.ToString();
            jJobPostComplete.OutputMsg = x_outputMsg;

            jJob.Data = JsonConvert.SerializeObject(jJobPostComplete);

        }

    }

    public class jJobPosted
    {
        private string _id;
        //private string _custid;
        // private string _user_type;
        private string _outputmsg;

        public string ID
        {
            get { return _id; }
            set { _id = value; }
        }
        //public string CustID
        //{
        //    get { return _custid; }
        //    set { _custid = value; }
        //}
        //public string UserType
        //{
        //    get { return _user_type; }
        //    set { _user_type = value; }
        //}
        public string OutputMsg
        {
            get { return _outputmsg; }
            set { _outputmsg = value; }
        }
    }

    public class jJobGet
    {
        private jJob _jjob;
        private bool _retrieved;
        private string _outputmsg;




        public jJob jJob
        {
            get { return _jjob; }
            set { _jjob = value; }
        }
        public bool Retrieved
        {
            get { return _retrieved; }
            set { _retrieved = value; }
        }
        public string OutputMsg
        {
            get { return _outputmsg; }
            set { _outputmsg = value; }
        }

        public void populate()
        {
            this.Retrieved = false;
            WebRecruiterController webCtrl = new WebRecruiterController();


            string OUTPUTRESPONSE;

            //Int32 x_user_id;
            //Int32 x_job_id;
            //  Int32 x_user_type;
            string x_outputMsg;


            int records = 7;


            string x_Data;

            //bool userTypeWasParsed;
            //try
            //{
            //    userTypeWasParsed = Int32.TryParse(jUser.Type, out UserType);

            //}
            //catch (Exception ex)
            //{
            //    x_outputMsg = "Problem parsing userTYPE(INT); " + ex.Message.ToString();
            //}


            OUTPUTRESPONSE = webCtrl.webJobsGet(jJob.PosterID, records, out x_Data, out x_outputMsg);



            if (OUTPUTRESPONSE.Contains("ok"))
            {
                // HttpContext.Current.Session["x_job_id"] = x_job_id;
                //HttpContext.Current.Session["x_cust_id"] = x_cust_id;
                //HttpContext.Current.Session["x_user_type"] = x_user_type;
                HttpContext.Current.Session["x_output_msg"] = x_outputMsg;

                this.Retrieved = true;
            }

            // jJobPosted jJobPostComplete = new jJobPosted();

            //jUserAuthed.CustID = x_cust_id.ToString();
            //jJobPostComplete.ID = x_job_id.ToString();
            //jJobPostComplete.UserType = x_user_type.ToString();
            // jJobPostComplete.OutputMsg = x_outputMsg;

            jJob.Data = x_Data;

        }

    }

    public class jJobApply
    {
        private jJob _jjob;
        private bool _applied;
        private string _outputmsg;



        public jJob jJob
        {
            get { return _jjob; }
            set { _jjob = value; }
        }
        public bool Applied
        {
            get { return _applied; }
            set { _applied = value; }
        }
        public string OutputMsg
        {
            get { return _outputmsg; }
            set { _outputmsg = value; }
        }

        public void applyjob()
        {
            this.Applied = false;
            WebRecruiterController webCtrl = new WebRecruiterController();


            string OUTPUTRESPONSE;

            // Int32 x_user_id;
            Int32 x_job_id;
            //  Int32 x_user_type;
            String x_outputMsg;

            // Int32 UserType;


            //bool userTypeWasParsed;
            //try
            //{
            //    userTypeWasParsed = Int32.TryParse(jUser.Type, out UserType);

            //}
            //catch (Exception ex)
            //{
            //    x_outputMsg = "Problem parsing userTYPE(INT); " + ex.Message.ToString();
            //}


            OUTPUTRESPONSE = webCtrl.webJobApply(jJob.Data, jJob.ID, out x_job_id, out x_outputMsg);



            if (OUTPUTRESPONSE.Contains("ok"))
            {
                HttpContext.Current.Session["x_job_id"] = x_job_id;
                //HttpContext.Current.Session["x_cust_id"] = x_cust_id;
                //HttpContext.Current.Session["x_user_type"] = x_user_type;
                HttpContext.Current.Session["x_output_msg"] = x_outputMsg;

                this.Applied = true;
            }

            jJobApplied jJobApplyComplete = new jJobApplied();


            jJobApplyComplete.ID = x_job_id.ToString();
            jJobApplyComplete.OutputMsg = x_outputMsg;

            jJob.Data = JsonConvert.SerializeObject(jJobApplyComplete);

        }

    }

    public class jJobApplied
    {
        private string _id;
        //private string _custid;
        // private string _user_type;
        private string _outputmsg;

        public string ID
        {
            get { return _id; }
            set { _id = value; }
        }
        //public string CustID
        //{
        //    get { return _custid; }
        //    set { _custid = value; }
        //}
        //public string UserType
        //{
        //    get { return _user_type; }
        //    set { _user_type = value; }
        //}
        public string OutputMsg
        {
            get { return _outputmsg; }
            set { _outputmsg = value; }
        }
    }

    public class jJobApplyGet
    {
        private jJob _jjob;
        private bool _retrieved;
        private string _outputmsg;




        public jJob jJob
        {
            get { return _jjob; }
            set { _jjob = value; }
        }
        public bool Retrieved
        {
            get { return _retrieved; }
            set { _retrieved = value; }
        }
        public string OutputMsg
        {
            get { return _outputmsg; }
            set { _outputmsg = value; }
        }

        public void populate()
        {
            this.Retrieved = false;
            WebRecruiterController webCtrl = new WebRecruiterController();


            string OUTPUTRESPONSE;

            //Int32 x_user_id;
            //Int32 x_job_id;
            //  Int32 x_user_type;
            string x_outputMsg;


            int records = 7;


            string x_Data;

            //bool userTypeWasParsed;
            //try
            //{
            //    userTypeWasParsed = Int32.TryParse(jUser.Type, out UserType);

            //}
            //catch (Exception ex)
            //{
            //    x_outputMsg = "Problem parsing userTYPE(INT); " + ex.Message.ToString();
            //}


            OUTPUTRESPONSE = webCtrl.webJobApplyGet(jJob.ID, records, out x_Data, out x_outputMsg);



            if (OUTPUTRESPONSE.Contains("ok"))
            {
                // HttpContext.Current.Session["x_job_id"] = x_job_id;
                //HttpContext.Current.Session["x_cust_id"] = x_cust_id;
                //HttpContext.Current.Session["x_user_type"] = x_user_type;
                HttpContext.Current.Session["x_output_msg"] = x_outputMsg;

                this.Retrieved = true;
            }

            // jJobPosted jJobPostComplete = new jJobPosted();

            //jUserAuthed.CustID = x_cust_id.ToString();
            //jJobPostComplete.ID = x_job_id.ToString();
            //jJobPostComplete.UserType = x_user_type.ToString();
            // jJobPostComplete.OutputMsg = x_outputMsg;

            jJob.Data = x_Data;

        }

    }
}