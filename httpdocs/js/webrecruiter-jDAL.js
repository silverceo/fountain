// JScript File

var jUserAuthenticated = function (uID, uCust_id, uUserType, uOutputMsg) {
    this.ID = uID;
    this.CustID = uCustID;
    this.UserType = uUserType;
    this.OutputMsg = uOutputMsg;
}
var jUser = function (uName, uEmail, uPassword, uIP, uData, uType) {
    this.Username = uName;
    this.Email = uEmail;
    this.Password = uPassword;
    this.IP = uIP;
    this.Data = uData;
    this.Type = uType;
}
var jUserRegistered = function (uID, uType, uOutputMsg) {
    this.ID = uID;
   // this.CustID = uCustID;
    this.Type = Type;
    this.OutputMsg = uOutputMsg;
}

var jJobPost = function (uID, uEmployer, uTitle, uDescription, uPosterID, uData) {
    this.ID = uID;
    this.Employer = uEmployer;
    this.Title = uTitle;
    this.Description = uDescription;
    this.PosterID = uPosterID
    this.Data = uData;
}

var jJob =  function (uID, uEmployer, uTitle, uDescription, uPosterID, uData) {
    this.ID = uID;
    this.Employer = uEmployer;
    this.Title = uTitle;
    this.Description = uDescription;
    this.PosterID = uPosterID
    this.Data = uData
}



function LOGMEIN(theUserName, thePassword) {

    var jsEmp = new jUser(theUserName, "defaultemail", thePassword, "xxx.xxx.xxx.xxx", "420", "0");
    var jsonText = $.toJSON(jsEmp);
    $.ajax(
                {
                    type: "POST",
                    url: "jDAL.aspx/webLogin",
                    data: "{'jsonParam' : " + jsonText + "}",
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    async: true,
                    cache: false,
                    success: function (msg) {

                        var obj = $.parseJSON(msg);
                        if (obj.ID > 0) {
                            $('#text-login-msg').text('Login Ok');       
                            $('#text-login-msg').css('color', '#19c419');
                            if(obj.UserType == 1){
                            $(location).attr('href', 'jobseeker.aspx');
                            }
                            else
                            {
                            $(location).attr('href', 'jobposter.aspx');
                            }
                        }
                        else {
                             $('#text-login-msg').text('Login Failed');   
                             $('#text-login-msg').css('color', '#f00');
                        }
                    },
                    error: function (x, e) {
                        alert("The call to the server side failed. " + x.responseText);
                    }
                }
            );
    return false;
}


function GETJOBSEEKER(theUserName, theType) {

    var jsTmp = new jJob(theUserName, "cool", "d", "d", 1, "d");
    var jsonText2 = $.toJSON(jsTmp);
    $.ajax(
                {
                    type: "POST",
                    url: "jDAL.aspx/webJobGet",
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    async: false,
                    cache: false,
                    success: function (msg) {
                        if (1 > 0) {
                            drawJobSeekerTable(msg); 
                        }
                        else {
                        }
                       
                    },
                    error: function (x, e) {
                        alert("The call to the server side failed. " + x.responseText);
                    }
                }
            );
    return false;
}

var x;
function drawJobSeekerTable(data) {
    x = $('#table-column-toggle').DataTable();
    x.clear();
    
    for (var i = 0; i < data.length; i++) {
        drawJobSeekerRow(data[i]);
    }
}

function drawJobSeekerRow(rowData) {
    var counter = 1;
    x.row.add( [rowData.Employer,
                rowData.Title,
                rowData.Description,
                "<button class='btn btn-primary btn-lg' onclick='job_apply(" + rowData.ID + ", " + rowData.Data + ");' " + rowData.CanApply + ">APPLY</button>"
                
            ] ).draw( true );
}
                                               
                        
function job_apply(theJobID, theUserName) {
    var jsTmp = new jJob(theJobID, "XX", "XX", "XX", "XX", theUserName);
    var jsonTexT6 = $.toJSON(jsTmp);
    $.ajax(
                {
                    type: "POST",
                    url: "jDAL.aspx/webJobApply",
                    data: "{'jsonParam' : " + jsonTexT6 + "}",
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    async: true,
                    cache: false,
                    success: function (msg) {
                        if (1 > 0) {
                            alert('You Have Applied');
                            
                            GETJOBSEEKER();

                        }
                        else {
                        }
                       
                    },
                    error: function (x, e) {
                        alert("The call to the server side failed. " + x.responseText);
                    }
                }
            );
    return false;
}

function GETJOBPOSTER(theUserName, theType) {
    var jsTmp = new jJob(theUserName, "cool", "d", "d", 1, "d");
    var jsonText2 = $.toJSON(jsTmp);
    $.ajax(
                {
                    type: "POST",
                    url: "jDAL.aspx/webJobGet",
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    async: true,
                    cache: false,
                    success: function (msg) {
                        if (1 > 0) {
                            drawJobPosterTable(msg);
                        }
                        else {
                        }
                    },
                    error: function (x, e) {
                        alert("The call to the server side failed. " + x.responseText);
                    }
                }
            );
    return false;
}


var t;

function drawJobPosterTable(data) {
    t = null;
    t = $('#table-column-toggle').DataTable();
     
    for (var i = 0; i < data.length; i++) {
        drawJobPosterRow(data[i]);
    }
    $("#table-column-toggle").trigger("create");
  
    $('#table-column-toggle tr').click( function () {                                 
        var tr = $(this).closest('tr');
        var row = t.row( tr );
        if ( row.child.isShown() ) {
            row.child.hide();
            tr.removeClass('shown');
            var g = row.data();
            row_id = g[4];
            $('#job' + row_id).removeClass('glyphicon-minus-sign').addClass('glyphicon-plus-sign');
        }
        else {
            row.child( format(row.data()) ).show();
            tr.addClass('shown');
            var f = row.data();
            row_id = f[4];
            $('#job' + row_id).removeClass('glyphicon-plus-sign').addClass('glyphicon-minus-sign');
        }
       });  
    
}

function drawJobPosterRow(rowData) {                           
    var counter = 1;
    t.row.add( ['<div id="job' +  rowData.ID + '" class="glyphicon glyphicon-plus-sign"></div>',
                rowData.Employer,
                rowData.Title,
                rowData.Description,
                rowData.ID
                
            ] ).draw( true );
                                           
}

var joy = [''];   

function format ( d ) {
    joy = [''];  

    if(d[4] != null){
    job_applys_get(d[4], joy);
    }
return joy;

}

function job_applys_get(theJobID, joy) {
    var jsTmp = new jJob(theJobID, "XX", "XX", "X", "XX", "XX");
    var jsonText7 = $.toJSON(jsTmp);
    $.ajax(
                {
                    type: "POST",
                    url: "jDAL.aspx/webJobApplysGet",
                    data: "{'jsonParam' : " + jsonText7 + "}",
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    async: false,
                    cache: false,
                    success: function (msg) {
                       
                       
                          joy.push(drawJobApplyTable(msg));

                    },
                    error: function (x, e) {
                        alert("The call to the server side failed. " + x.responseText);
                    }
                }
            );
}

function drawJobApplyTable(data) {                             
    var tblJobApplys = '<table cellpadding="5" cellspacing="0" border="0" style="padding-left:50px;">';
    for (var i = 0; i < data.length; i++) {
        tblJobApplys += drawJobApplyRow(data[i]);
    }
    tblJobApplys += '</table>';
  
    return tblJobApplys;
}

function drawJobApplyRow(rowData) {
    row = "<tr style='padding:7px; background-color:#EEE;'>"
    row += "<td>" + rowData.Username + "</td>";  
    row += "<td style='padding:7px;'>" + rowData.Email + "</td>";  
    row += "<td>" + rowData.ApplyDate + "</td>";           
    row +=  "</tr>";
    
    return row;
                                                                      
}

function LOGMEOFF() {
    $.ajax(
                {
                    type: "POST",
                    url: "jDAL.aspx/LOGOFF",
                    data: "{}",
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    async: true,
                    cache: false,
                    success: function (msg) {
                        $(location).attr('href', 'splash.aspx');
                    },
                    error: function (x, e) {
                        alert("The call to the server side failed. " + x.responseText);
                    }
                }
            );
    return false;
}
                   
               
function REGISTERME(theUserName, theEmail, thePassword, theType) {
    var jsTmp = new jUser(theUserName, theEmail, thePassword, "xxx.xxx.xxx.xxx", "420", theType);
    var jsonText2 = $.toJSON(jsTmp);
    $.ajax(
                {
                    type: "POST",
                    url: "jDAL.aspx/webRegister",
                    data: "{'jsonParam' : " + jsonText2 + "}",
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    async: true,
                    cache: false,
                    success: function (msg) {
                        var obj = $.parseJSON(msg);
                        if (obj.ID > 0) {
                            $('#text-register-msg').text('Registered Ok');    
                            $('#text-register-msg').css('color', '#19c419');              
                        }
                        else {
                             $('#text-register-msg').text(obj.OutputMsg);   
                             $('#text-register-msg').css('color', '#f00');
                        }
                    },
                    error: function (x, e) {
                        alert("The call to the server side failed. " + x.responseText);
                    }
                }
            );
    return false;
}
                                    
                        
function POSTJOB(theEmployer, theTitle, theDescription) {
    var jsTmp3 = new jJobPost(0 , theEmployer, theTitle, theDescription, 0, 0);
    var jsonText3 = $.toJSON(jsTmp3);
    $.ajax(
                {
                    type: "POST",
                    url: "jDAL.aspx/webJobPost",
                    data: "{'jsonParam' : " + jsonText3 + "}",
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    async: true,
                    cache: false,
                    success: function (msg) {
                        var obj = $.parseJSON(msg);
                        if (obj.ID > 0) {
                            $('#text-job-post-msg').text('Posted Ok');    
                            $('#text-job-post-msg').css('color', '#19c419');              
                        }
                        else {
                             $('#text-job-post-msg').text(obj.OutputMsg);   
                             $('#text-job-post-msg').css('color', '#f00');
                        }
                    },
                    error: function (x, e) {
                        alert("Session Expired Please log back in. " + x.responseText);                                                            
                    }
                }
            );
    return false;
}
                                    
                                    
  
                                

