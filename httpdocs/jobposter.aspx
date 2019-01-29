<%@ Page Language="C#" AutoEventWireup="true" CodeFile="jobposter.aspx.cs" Inherits="jobposter" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
<title>Job Poster</title>
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
                               GETJOBPOSTER();                               
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
        <p class="text-center"><a href="#" class="btn btn-primary btn-lg" role="button" data-toggle="modal" data-target="#jobposter-modal">Post Job</a>&nbsp;&nbsp;<a href="javascript:LOGMEOFF();" class="btn btn-primary btn-lg" role="button" >LogOFF</a></p>      
	</div>
	<div class="row">
	      <form id="job-posts-form"   >
            		        <div class="modal-body">
		    				<div id="div-job-seeker-msg">
		    				<div id="Div1" class="glyphicon glyphicon-chevron-right"></div>
                            <span id="Span1">Current Posted Jobs</span>
                            </div>
                             <div style="padding:7px;">                                                
                                    <table id="table-column-toggle" class="table table-striped table-hover" style="width:100%">
                                        <thead>
                                            <tr>
                                                <th></th>
                                                <th>Employer</th>
                                                <th>Title</th>
                                                <th>Description</th> 
                                            </tr>
                                        </thead>
                                        <tbody></tbody>
                                        <tfoot>
                                            <tr>
                                                <th colspan="3"></th>                                               
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

<!-- BEGIN # MODAL JOBPOSTER -->
<div class="modal fade" id="jobposter-modal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true" style="display: none;">
    	<div class="modal-dialog">
			<div class="modal-content">
				<div class="modal-header" align="center">
					<img class="img-circle" id="img_logo" src="img/logo.png">
					<button type="button" class="close" data-dismiss="modal" aria-label="Close">
						<span class="glyphicon glyphicon-remove" aria-hidden="true"></span>
					</button>
				</div>
                
                <!-- Begin # DIV Form -->
                <div id="div-forms">
               
                <!-- Begin | PostJob Form -->
                    <form id="job-post-form"   >
            		    <div class="modal-body">
		    				<div id="div-job-post-msg">
                                <div id="icon-job-post-msg" class="glyphicon glyphicon-chevron-right"></div>
                                <span id="text-job-post-msg">Post New Job</span>
                            </div>
                           
		    				<input id="job-post-employer" class="form-control" type="text" placeholder="Employer" required autocomplete="off">
                            <input id="job-post-title" class="form-control" type="text" placeholder="Job Title" required autocomplete="off">
                            <input id="job-post-description" class="form-control" type="text" placeholder="Job Description" required autocomplete="off">
            			</div>
		    		    <div class="modal-footer">
                            <div>
                                <button type="submit" class="btn btn-primary btn-lg btn-block">Post Job</button>
                            </div>
                            
		    		    </div>
                    </form>
                    <!-- End | Register Form -->
                 
                </div>
                <!-- End # DIV Form -->
                
			</div>
		</div>
	</div>
    <!-- END # MODAL JOB POSTER -->
</body>
</html>
