<%@ Page Language="C#" AutoEventWireup="true" CodeFile="jobseeker.aspx.cs" Inherits="jobseeker" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
<title>Job Seeker</title>
<link href="css/bootstrap.min.css" rel="stylesheet" id="bootstrap-css">
<link href="css/dataTables.jqueryui.min.css" rel="stylesheet" id="Link1">
<script src="js/jquery-1.9.1.min.js"></script>
<script src="js/jquery.json-2.5.1.js"></script>
<script src="js/bootstrap.min.js"></script>
<script src="js/jquery.dataTables.min.js"></script>
<script src="js/webrecruiter-jDAL.js"></script>
<script src="js/webrecruiter-forms.js"></script>
<style>
/* IMAGE STYLES */
[type=radio] + img {
  cursor: pointer;
}
/* CHECKED STYLES */
[type=radio]:checked + img {
  outline: 3px solid #00f;
}
</style>
<script>
$(document).ready(function () {
                            try {
                               GETJOBSEEKER();                              
                            }
                            catch (err) {
                                alert(err);
                            }
                        }
                    );
</script>
</head>
<body>
    <form id="form1" runat="server"></form>
    <div class="container">
	<div class="row">
		<h1 class="text-center"><img class="img-circle" id="img_logo" src="img/logo.png"></h1>
        <p class="text-center"><a href="javascript:LOGMEOFF();" class="btn btn-primary btn-lg" role="button" >LogOFF</a></p>
	</div>
	<div class="row">
	      <form id="job-seeker-form" >
            		        <div class="modal-body">
		    				<div id="div-job-seeker-msg">
		    				<div id="Div1" class="glyphicon glyphicon-chevron-right"></div>
                            <span id="Span1">Current Posted Jobs</span>
                            </div>
                             <div style="padding:7px;">
                                 <table id="table-column-toggle" cellspacing="10" class="table table-striped table-hover" style="width:100%">
                                        <thead>
                                            <tr>                                               
                                                <th>Employer</th>
                                                <th>Title</th>
                                                <th>Description</th>
                                                <th></th>                                               
                                            </tr>
                                        </thead>
                                        <tfoot>
                                            <tr>
                                                <th colspan="4"></th>     
                                            </tr>
                                        </tfoot>
                                    </table>
                             </div>
                             </div>
                            <div class="modal-footer">
                            <div>
                                <button id="Button2" type="button" class="btn btn-link">Need Help?</button>
                            </div>
		    		        </div>
		    		    </form>
	</div>
</div>
</body>
</html>
