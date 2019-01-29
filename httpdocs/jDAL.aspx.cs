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

[ScriptService]
public partial class jDAL : System.Web.UI.Page
{

   

    public class jUser : Models.jUser
    {

    }
    public class jUserAuthentication : Models.jUserAuthentication
    {

    }
    public class jUserAuthenticated : Models.jUserAuthenticated
    {

    }
    public class jUserRegistration : Models.jUserRegistration
    {

    }
    public class jUserRegistered : Models.jUserRegistered
    {

    }
    public class jJob : Models.jJob
    {

    }
    public class jJobPost : Models.jJobPost
    {

    }
    public class jJobPosted : Models.jJobPosted
    {

    }
    public class jJobGet : Models.jJobGet
    {

    }
    public class jJobApply : Models.jJobApply
    {

    }
    public class jJobApplied : Models.jJobApplied
    {

    }
    public class jJobApplyGet : Models.jJobApplyGet
    {
    }
    

    

    



    protected void Page_Load(object sender, EventArgs e)
    {
        HttpContext.Current.Session["SessionInfo"] = "Found Customer Session Data.";
        CheckSessionData();
    }

    public void CheckSessionData()
    {

        try
        {
            Int16 x_cust_id = Int16.Parse(HttpContext.Current.Session["x_cust_id"].ToString());
            HttpContext.Current.Session["SessionInfo"] = "Found Customer Session Data.";

        }
        catch (Exception ex)
        {
            HttpContext.Current.Session["SessionInfo"] = "; Has no Customer Session Data." + ex.Message.ToString();
            LOGOFF();
            HttpContext.Current.Response.Redirect("default.aspx", true);

        }
    }

    [WebMethod]
    public static string helloWorld(object jsonParam)
    {
        return "Hello.";
    }

    [WebMethod(EnableSession = true)]
    public static string webLogin(object jsonParam)
    {
        jUser objUser = GetUser(jsonParam);


        jUserAuthentication jUserAuth = new jUserAuthentication();
        jUserAuth.jUser = objUser;


        jUserAuth.validate();

        if (jUserAuth.Authencated)
        {
            FormsAuthenticationTicket authTicket = new FormsAuthenticationTicket(jUserAuth.jUser.Username, true, 12 * 60);
            string encryptedTicket = FormsAuthentication.Encrypt(authTicket);
            HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);
            cookie.Expires = authTicket.Expiration;
            HttpContext.Current.Response.Cookies.Set(cookie);


            jUserAuthenticated objUserAuthed = JsonConvert.DeserializeObject<jUserAuthenticated>(jUserAuth.jUser.Data);
            return JsonConvert.SerializeObject(objUserAuthed);

        }
        else
        {
            jUserAuthenticated objUserAuthed = JsonConvert.DeserializeObject<jUserAuthenticated>(jUserAuth.jUser.Data);
            return JsonConvert.SerializeObject(objUserAuthed);
            // return "Logon attempt unsuccessful. Please try again.";
        }
    }
    public static jUser GetUser(object user)
    {
        jUser objUser = new jUser();
        Dictionary<string, object> tmp = (Dictionary<string, object>)user;

        object objUsername = null;
        object objEmail = null;
        object objPassword = null;
        object objIP = null;
        object objData = null;
        object objType = null;

        tmp.TryGetValue("Username", out objUsername);
        tmp.TryGetValue("Email", out objEmail);
        tmp.TryGetValue("Password", out objPassword);
        tmp.TryGetValue("IP", out objIP);
        tmp.TryGetValue("Data", out objData);
        tmp.TryGetValue("Type", out objType);

        objUser.Username = objUsername.ToString();
        objUser.Email = objEmail.ToString();
        objUser.Password = objPassword.ToString();
        objUser.IP = objIP.ToString();
        objUser.Data = objData.ToString();
        objUser.Type = objType.ToString();

        return objUser;
    }
    public static jUserAuthenticated GetUserAuthenticated(object jUserAuthed)
    {
        jUserAuthenticated objUserAuthed = new jUserAuthenticated();
        Dictionary<string, object> tmp = (Dictionary<string, object>)jUserAuthed;

        object objID = null;
        object objCustID = null;
        object objUserType = null;
        object objOutputMsg = null;

        tmp.TryGetValue("ID", out objID);
        tmp.TryGetValue("CustID", out objCustID);
        tmp.TryGetValue("UserType", out objUserType);
        tmp.TryGetValue("OutputMsg", out objOutputMsg);

        objUserAuthed.ID = objID.ToString();
        objUserAuthed.CustID = objCustID.ToString();
        objUserAuthed.UserType = objUserType.ToString();
        objUserAuthed.OutputMsg = objOutputMsg.ToString();

        return objUserAuthed;
    }


    [WebMethod(EnableSession = true)]
    public static string LOGOFF()
    {


        try
        {
            HttpCookie myCookie = HttpContext.Current.Request.Cookies["UserSettings"];
            myCookie.Expires = DateTime.Now.AddDays(-1d);
            HttpContext.Current.Response.Cookies.Add(myCookie);

        }
        catch
        { }

        try
        {
            HttpContext.Current.Session.Remove("x_cust_id");
            HttpContext.Current.Session.Remove("x_clearance");
            HttpContext.Current.Session.Remove("x_output_msg");

            HttpContext.Current.Session["Loggoff Method"] = "Logged Off";
        }
        catch
        { }

        FormsAuthentication.SignOut();



        return "Logged Off.";
    }


    [WebMethod(EnableSession = true)]
    public static string webRegister(object jsonParam)
    {
        jUser objUser = GetUser(jsonParam);


        jUserRegistration jUserReg = new jUserRegistration();
        jUserReg.jUser = objUser;


        jUserReg.register();

        if (jUserReg.Registered)
        {
            //FormsAuthenticationTicket authTicket = new FormsAuthenticationTicket(jUserAuth.jUser.Username, true, 12 * 60);
            //string encryptedTicket = FormsAuthentication.Encrypt(authTicket);
            //HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);
            //cookie.Expires = authTicket.Expiration;
            //HttpContext.Current.Response.Cookies.Set(cookie);


            //jUserAuthenticated objUserAuthed = JsonConvert.DeserializeObject<jUserAuthenticated>(jUserAuth.jUser.Data);
            //return JsonConvert.SerializeObject(objUserAuthed);

            jUserRegistered jUserReged = JsonConvert.DeserializeObject<jUserRegistered>(jUserReg.jUser.Data);
            return JsonConvert.SerializeObject(jUserReged);


        }
        else
        {
            //jUserAuthenticated objUserAuthed = JsonConvert.DeserializeObject<jUserAuthenticated>(jUserAuth.jUser.Data);
            //return JsonConvert.SerializeObject(objUserAuthed);
            //// return "Logon attempt unsuccessful. Please try again.";


            jUserRegistered jUserReged = JsonConvert.DeserializeObject<jUserRegistered>(jUserReg.jUser.Data);
            return JsonConvert.SerializeObject(jUserReged);

        }
    }


    [WebMethod(EnableSession = true)]
    public static string webJobPost(object jsonParam)
    {
        jJob objJob = GetJob(jsonParam);


        jJobPost jJobPoster = new jJobPost();
        jJobPoster.jJob = objJob;
        jJobPoster.jJob.PosterID = HttpContext.Current.Session["x_user_id"].ToString();

        try
        {
            jJobPoster.jJob.PosterID = HttpContext.Current.Session["x_user_id"].ToString();
        }
        catch (Exception ex)
        {

        }

        jJobPoster.postjob();

        if (jJobPoster.Posted)
        {
            //FormsAuthenticationTicket authTicket = new FormsAuthenticationTicket(jUserAuth.jUser.Username, true, 12 * 60);
            //string encryptedTicket = FormsAuthentication.Encrypt(authTicket);
            //HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);
            //cookie.Expires = authTicket.Expiration;
            //HttpContext.Current.Response.Cookies.Set(cookie);


            //jUserAuthenticated objUserAuthed = JsonConvert.DeserializeObject<jUserAuthenticated>(jUserAuth.jUser.Data);
            //return JsonConvert.SerializeObject(objUserAuthed);

            jJobPosted jJobPostComplete = JsonConvert.DeserializeObject<jJobPosted>(jJobPoster.jJob.Data);
            return JsonConvert.SerializeObject(jJobPostComplete);


        }
        else
        {
            //jUserAuthenticated objUserAuthed = JsonConvert.DeserializeObject<jUserAuthenticated>(jUserAuth.jUser.Data);
            //return JsonConvert.SerializeObject(objUserAuthed);
            //// return "Logon attempt unsuccessful. Please try again.";


            jJobPosted jJobPostComplete = JsonConvert.DeserializeObject<jJobPosted>(jJobPoster.jJob.Data);
            return JsonConvert.SerializeObject(jJobPostComplete);

        }
    }

    public static jJob GetJob(object job)
    {
        jJob objJob = new jJob();
        Dictionary<string, object> tmp = (Dictionary<string, object>)job;

        object objID = null;
        object objEmployer = null;
        object objTitle = null;
        object objDescription = null;
        object objPosterID = null;
        object objData = null;
       

        tmp.TryGetValue("ID", out objID);
        tmp.TryGetValue("Employer", out objEmployer);
        tmp.TryGetValue("Title", out objTitle);
        tmp.TryGetValue("Description", out objDescription);
        tmp.TryGetValue("PosterID", out objPosterID);
        tmp.TryGetValue("Data", out objData);

        objJob.ID = objID.ToString();
        objJob.Employer = objEmployer.ToString();
        objJob.Title = objTitle.ToString();
        objJob.Description = objDescription.ToString();
        objJob.PosterID = objPosterID.ToString();
        objJob.Data = objData.ToString();

        return objJob;
    }


    [WebMethod(EnableSession = true)]
    public static List<Models.Job> webJobGet(object jsonParam)
    {
        jJob objJob = GetJob(jsonParam);

        


        jJobGet jJobGeter = new jJobGet();
        jJobGeter.jJob = objJob;
        jJobGeter.jJob.PosterID = HttpContext.Current.Session["x_user_id"].ToString();

        //try
        //{
        //    jJobGeter.jJob.PosterID = HttpContext.Current.Session["x_user_id"].ToString();
        //}
        //catch (Exception ex)
        //{

        //}

        jJobGeter.populate();

        //if (jJobPoster.Posted)
        //{
           

        //    jJobPosted jJobPostComplete = JsonConvert.DeserializeObject<jJobPosted>(jJobPoster.jJob.Data);
        //    return JsonConvert.SerializeObject(jJobPostComplete);


        //}
        //else
        //{
            
        //    jJobPosted jJobPostComplete = JsonConvert.DeserializeObject<jJobPosted>(jJobPoster.jJob.Data);
        //    return JsonConvert.SerializeObject(jJobPostComplete);

        //}

        string jsonResponse = jJobGeter.jJob.Data;


        List<Models.Job> Jobs = JsonConvert.DeserializeObject<List<Models.Job>>(jsonResponse);

        return Jobs;
    }

    [WebMethod(EnableSession = true)]
    public static List<Models.Job> webJobGet()
    {
     //   jJob objJob = GetJob(jsonParam);


        jJob objJob = new jJob();

        jJobGet jJobGeter = new jJobGet();
        jJobGeter.jJob = objJob;
        jJobGeter.jJob.PosterID = HttpContext.Current.Session["x_user_id"].ToString();

        //try
        //{
        //    jJobGeter.jJob.PosterID = HttpContext.Current.Session["x_user_id"].ToString();
        //}
        //catch (Exception ex)
        //{

        //}

        jJobGeter.populate();

        //if (jJobPoster.Posted)
        //{


        //    jJobPosted jJobPostComplete = JsonConvert.DeserializeObject<jJobPosted>(jJobPoster.jJob.Data);
        //    return JsonConvert.SerializeObject(jJobPostComplete);


        //}
        //else
        //{

        //    jJobPosted jJobPostComplete = JsonConvert.DeserializeObject<jJobPosted>(jJobPoster.jJob.Data);
        //    return JsonConvert.SerializeObject(jJobPostComplete);

        //}

        string jsonResponse = jJobGeter.jJob.Data;


        List<Models.Job> Jobs = JsonConvert.DeserializeObject<List<Models.Job>>(jsonResponse);

        return Jobs;
    }


    [WebMethod(EnableSession = true)]
    public static string webJobApply(object jsonParam)
    {
        jJob objJob = GetJob(jsonParam);




        jJobApply jJobApplyer = new jJobApply();
        jJobApplyer.jJob = objJob;
        //jJobGeter.jJob.PosterID = HttpContext.Current.Session["x_user_id"].ToString();

        //try
        //{
        //    jJobGeter.jJob.PosterID = HttpContext.Current.Session["x_user_id"].ToString();
        //}
        //catch (Exception ex)
        //{

        //}

        jJobApplyer.applyjob();

        //if (jJobPoster.Posted)
        //{


        //    jJobPosted jJobPostComplete = JsonConvert.DeserializeObject<jJobPosted>(jJobPoster.jJob.Data);
        //    return JsonConvert.SerializeObject(jJobPostComplete);


        //}
        //else
        //{

        //    jJobPosted jJobPostComplete = JsonConvert.DeserializeObject<jJobPosted>(jJobPoster.jJob.Data);
        //    return JsonConvert.SerializeObject(jJobPostComplete);

        //}

       // string jsonResponse = jJobApplyer.jJob.Data;


        //List<Models.Job> Jobs = JsonConvert.DeserializeObject<List<Models.Job>>(jsonResponse);

        //return Jobs;


        jJobApplied jJobPostComplete = JsonConvert.DeserializeObject<jJobApplied>(jJobApplyer.jJob.Data);
        return JsonConvert.SerializeObject(jJobPostComplete);
    }


    [WebMethod(EnableSession = true)]
    public static List<Models.JobApply> webJobApplysGet(object jsonParam)
    {
        jJob objJob = GetJob(jsonParam);




        jJobApplyGet jJobApplyGeter = new jJobApplyGet();
        jJobApplyGeter.jJob = objJob;
       // jJobApplyGeter.jJob.PosterID = HttpContext.Current.Session["x_user_id"].ToString();

        //try
        //{
        //    jJobGeter.jJob.PosterID = HttpContext.Current.Session["x_user_id"].ToString();
        //}
        //catch (Exception ex)
        //{

        //}

        jJobApplyGeter.populate();

        //if (jJobPoster.Posted)
        //{


        //    jJobPosted jJobPostComplete = JsonConvert.DeserializeObject<jJobPosted>(jJobPoster.jJob.Data);
        //    return JsonConvert.SerializeObject(jJobPostComplete);


        //}
        //else
        //{

        //    jJobPosted jJobPostComplete = JsonConvert.DeserializeObject<jJobPosted>(jJobPoster.jJob.Data);
        //    return JsonConvert.SerializeObject(jJobPostComplete);

        //}

        string jsonResponse = jJobApplyGeter.jJob.Data;


        List<Models.JobApply> JobApplys = JsonConvert.DeserializeObject<List<Models.JobApply>>(jsonResponse);

        return JobApplys;
    }

}
