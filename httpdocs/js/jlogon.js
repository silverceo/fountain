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



    //$(document).ready(
                       // function LOGMEIN() {
                            //try {

                            //    $('#btnLogon').click
                            //    (
                                    function LOGMEIN(theUserName, thePassword) {
                                    
                                        var jsEmp = new jUser(theUserName, "defaultemail", thePassword, "xxx.xxx.xxx.xxx", "420", "0");
                                        var jsonText = $.toJSON(jsEmp);
                                        //alert('2');
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
                                                            //alert(obj);
                                                            if (obj.ID > 0) {

                                                                //$('#myDiv3').html("Logon was sucessful");
                                                                // msgChange($('#div-login-msg'), $('#icon-login-msg'), $('#text-login-msg'), "success", "glyphicon-ok", "Login OK");
                                                                $('#text-login-msg').text('Login Ok');       
                                                                $('#text-login-msg').css('color', '#19c419');
                                                                //drawJobSeekerTable(msg);                  
                                                                if(obj.UserType == 1){
                                                                $(location).attr('href', 'jobseeker.aspx');
                                                                    //alert('hh');
                                                                    //GETJOBS(obj.ID, obj.UserType);
                                                                }
                                                                else
                                                                {
                                                                $(location).attr('href', 'jobposter.aspx');
                                                                    
                                                                }
                                                                
                                                              //  $(location).attr('href', 'index.index.html');
                                                            }
                                                            else {

                                                                //$('#myDiv3').html("Logon was unsucessful");
                                                               // msgChange($('#div-login-msg'), $('#icon-login-msg'), $('#text-login-msg'), "fail", "glyphicon-ok", "Login Failed");
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
                              //  );

                                    function GETJOBSEEKER(theUserName, theType) {
                                    
                                        var jsTmp = new jJob(theUserName, "cool", "d", "d", 1, "d");
                                        var jsonText2 = $.toJSON(jsTmp);
                                      // alert('theEmail');
                                      // alert(theEmail);
                                      //  alert('5');
                                        $.ajax(
                                                    {
                                                        type: "POST",
                                                        url: "jDAL.aspx/webJobGet",
                                                        //data: "{'jsonParam' : " + jsonText2 + "}",
                                                        contentType: "application/json; charset=utf-8",
                                                        dataType: "json",
                                                        async: false,
                                                        cache: false,
                                                        success: function (msg) {
                                                           // alert('6');
                                                            //var obj = $.parseJSON(msg.d);
                                                           // alert('7');
                                                           // alert(obj.ID);
                                                            if (1 > 0) {
                                                           // alert('7');
                                                           
                                                                drawJobSeekerTable(msg);
                                                                //$('#myDiv3').html("Logon was sucessful");
                                                                // msgChange($('#div-login-msg'), $('#icon-login-msg'), $('#text-login-msg'), "success", "glyphicon-ok", "Login OK");
                                                                //$('#text-register-msg').text('Registered Ok');    
                                                                //$('#text-register-msg').css('color', '#19c419');              
 
                                                            }
                                                            else {
                                                                 //alert('7');
                                                                //$('#myDiv3').html("Logon was unsucessful");
                                                               // msgChange($('#div-login-msg'), $('#icon-login-msg'), $('#text-login-msg'), "fail", "glyphicon-ok", "Login Failed");
                                                                // $('#text-register-msg').text(obj.OutputMsg);   
                                                               //  $('#text-register-msg').css('color', '#f00');
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
                         //alert(data);
                           // alert(data.length);
                            // $("#table-column-toggle").trigger("remove");
                           // $("#table-column-toggle body").empty();
                            //rows().remove()
                            x = $('#table-column-toggle').DataTable();
                              x.clear();
                              
//                            var rows = x
//                            .rows( '.selected' )
//                            .remove()
//                            .draw();
    
    
                         
                            
                            for (var i = 0; i < data.length; i++) {
                                drawJobSeekerRow(data[i]);
                            }
                            //$("#table-column-toggle").trigger("create");
                          //  $("#table-column-toggle").table("refresh");
                           
                            
                        }

                        function drawJobSeekerRow(rowData) {
//                            var row = $("<tr style='padding:7px;' />")
//                            $("#table-column-toggle").append(row); //this will append tr element to table... keep its reference for a while since we will add cels into it
//                            // row.append($("<td><a href='room.aspx?r=" + rowData.name + "' data-rel='external' data-ajax='true'>" + rowData.name + "</a></td>"));
//                            //row.append($("<td><a href='javascript:GotoRoom(" + rowData.ID + ");' data-rel='external' data-ajax='true'>" + rowData.Title + "</a></td>"));
//                            row.append($("<td>" + rowData.Employer + "</td>"));  
//                            row.append($("<td>" + rowData.Title + "</td>"));  
//                            row.append($("<td>" + rowData.Description + "</td>"));           
//                             row.append($("<td><button class='btn btn-primary btn-lg' onclick='job_apply(" + rowData.ID + ", " + rowData.Data + ");' " + rowData.CanApply + ">APPLY</button></td>"));                 
//                            row.append($("<td>" + rowData.gps + "</td>"));

                             
                             
                            
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
                                      // alert('theEmail');
                                      // alert(theEmail);
                                      //  alert('5');
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
                                                           // alert('6');
                                                            //var obj = $.parseJSON(msg.d);
                                                           // alert('7');
                                                           // alert(obj.ID);
                                                            if (1 > 0) {
                                                                alert('You Have Applied');
                                                                
                                                               //  var w = $('#table-column-toggle').DataTable();
                                                                 
                                                                 //var thePage = w.page();
                                                                    
                                                                //    w.draw( 'page' );
                                                                
                                                           //     var currPage = 0;
                                                           //      currPage = w.page();
                                                                //alert(w.page());
                                                                
                                                                
                                                                GETJOBSEEKER();
                                                               
                                                               
                                                               //w.fnPageChange(2, true);
                                                               
                                                               //$('#table-column-toggle').DataTable().fnPageChange(2, true);
                                                               //w.draw();
                                                                
//                                                                 var z = $('#table-column-toggle').DataTable();
                                                             //   var z = $('#table-column-toggle').DataTable();  
                                                              //      z.fnPageChange(2, true);
//                                                                    x.page(2).draw(2);
//                                                                    
//                                                                    alert('hi');
                                                                    
                                                                    //alert(w.page());
                                                                    //w.draw(thePage);
                                                                    
                                                                    //w.page(thePage);
                                                                 
                                                                //GETJOBSEEKER();
                                                               // drawJobSeekerTable(msg);
                                                                //$('#myDiv3').html("Logon was sucessful");
                                                                // msgChange($('#div-login-msg'), $('#icon-login-msg'), $('#text-login-msg'), "success", "glyphicon-ok", "Login OK");
                                                                //$('#text-register-msg').text('Registered Ok');    
                                                                //$('#text-register-msg').css('color', '#19c419');              
 
                                                            }
                                                            else {
                                                                 //alert('7');
                                                                //$('#myDiv3').html("Logon was unsucessful");
                                                               // msgChange($('#div-login-msg'), $('#icon-login-msg'), $('#text-login-msg'), "fail", "glyphicon-ok", "Login Failed");
                                                                // $('#text-register-msg').text(obj.OutputMsg);   
                                                               //  $('#text-register-msg').css('color', '#f00');
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
                                      // alert('theEmail');
                                      // alert(theEmail);
                                      //  alert('5');
                                        $.ajax(
                                                    {
                                                        type: "POST",
                                                        url: "jDAL.aspx/webJobGet",
                                                        //data: "{'jsonParam' : " + jsonText2 + "}",
                                                        contentType: "application/json; charset=utf-8",
                                                        dataType: "json",
                                                        async: true,
                                                        cache: false,
                                                        success: function (msg) {
                                                           // alert('6');
                                                            //var obj = $.parseJSON(msg.d);
                                                           // alert('7');
                                                           // alert(obj.ID);
                                                            if (1 > 0) {
                                                           // alert('7');
                                                           
                                                                drawJobPosterTable(msg);
                                                                //$('#myDiv3').html("Logon was sucessful");
                                                                // msgChange($('#div-login-msg'), $('#icon-login-msg'), $('#text-login-msg'), "success", "glyphicon-ok", "Login OK");
                                                                //$('#text-register-msg').text('Registered Ok');    
                                                                //$('#text-register-msg').css('color', '#19c419');              
 
                                                            }
                                                            else {
                                                                 //alert('7');
                                                                //$('#myDiv3').html("Logon was unsucessful");
                                                               // msgChange($('#div-login-msg'), $('#icon-login-msg'), $('#text-login-msg'), "fail", "glyphicon-ok", "Login Failed");
                                                                // $('#text-register-msg').text(obj.OutputMsg);   
                                                               //  $('#text-register-msg').css('color', '#f00');
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
                         //alert(data);
                           // alert(data.length);
                             t = null;
                             t = $('#table-column-toggle').DataTable();
                             
                            for (var i = 0; i < data.length; i++) {
                                drawJobPosterRow(data[i]);
                            }
                            $("#table-column-toggle").trigger("create");
                          //  $("#table-column-toggle").table("refresh");
                          
                           $('#table-column-toggle tr').click( function () {                                 
                              // alert('99');     
                               
                                var tr = $(this).closest('tr');
                                var row = t.row( tr );
                         
                                //alert(row.data());
                                
                                if ( row.child.isShown() ) {
                                    // This row is already open - close it
                                    row.child.hide();
                                    tr.removeClass('shown');
                                    
                                     var g = row.data();
                                     row_id = g[4];
                                     
                                    $('#job' + row_id).removeClass('glyphicon-minus-sign').addClass('glyphicon-plus-sign');
                                }
                                else {
                                    // Open this row
                                    row.child( format(row.data()) ).show();
                                    
                                    tr.addClass('shown');
                                       
                                    var f = row.data();
                                    
                                    row_id = f[4];
                                    //var tr = $(this).removeClass('left').addClass('right');
                                    $('#job' + row_id).removeClass('glyphicon-plus-sign').addClass('glyphicon-minus-sign');
                                }
                               
                               });  
                          
                          
                            
                        }

                        function drawJobPosterRow(rowData) {
                            //var row = $("<tr style='padding:7px;' />")
                            //$("#table-column-toggle").append(row); //this will append tr element to table... keep its reference for a while since we will add cels into it
                            // row.append($("<td><a href='room.aspx?r=" + rowData.name + "' data-rel='external' data-ajax='true'>" + rowData.name + "</a></td>"));
                            //row.append($("<td><a href='javascript:GotoRoom(" + rowData.ID + ");' data-rel='external' data-ajax='true'>" + rowData.Title + "</a></td>"));
                            //row.append($("<td>" + rowData.Employer + "</td>"));  
                            //row.append($("<td>" + rowData.Title + "</td>"));  
                            //row.append($("<td>" + rowData.Description + "</td>"));           
                            // row.append($("<td><button class='btn btn-primary btn-lg'>APPLY</button></td>"));                 
//                            row.append($("<td>" + rowData.gps + "</td>"));
                
                           
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
                        
                            //alert(d[3]);
                           //  var obj = []; 
                           //var obj = ['']; 
                            joy = [''];  
                            
                            if(d[4] != null){
                                job_applys_get(d[4], joy);
                             }
//                              //alert(OBJJ);
                             return joy;
//                             return obj;
                        
                            
                            // `d` is the original data object for the row
//                            return '<table cellpadding="5" cellspacing="0" border="0" style="padding-left:50px;">'+
//                                '<tr>'+
//                                    '<td>Applicant:</td>'+
//                                    '<td>' + d + '</td>'+
//                                '</tr>'+
//                                '<tr>'+
//                                    '<td>Extension number:</td>'+
//                                    '<td></td>'+
//                                '</tr>'+
//                                '<tr>'+
//                                    '<td>Extra info:</td>'+
//                                    '<td>And any further details here (images etc)...</td>'+
//                                '</tr>'+
//                            '</table>';
                        }






                           function job_applys_get(theJobID, joy) {
                                    
                                        var jsTmp = new jJob(theJobID, "XX", "XX", "X", "XX", "XX");
                                        var jsonText7 = $.toJSON(jsTmp);
                                      // alert('theEmail');
                                      // alert(theEmail);
                                      //  alert('5');
                                      //var OBJJ;
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
                                                           // alert('6');
                                                            //var obj = $.parseJSON(msg.d);
                                                           // alert('7');
                                                           // alert(obj.ID);
                                                            if (1 > 0) {
                                                            //alert(drawJobApplyTable(msg));
                                                           
                                                              joy.push(drawJobApplyTable(msg));
                                                              //OJU = OBJJ;
                                                             // alert(OBJJ);
                                                                //$('#myDiv3').html("Logon was sucessful");
                                                                // msgChange($('#div-login-msg'), $('#icon-login-msg'), $('#text-login-msg'), "success", "glyphicon-ok", "Login OK");
                                                                //$('#text-register-msg').text('Registered Ok');    
                                                                //$('#text-register-msg').css('color', '#19c419');              
 
                                                            }
                                                            else {
                                                                 //alert('7');
                                                                //$('#myDiv3').html("Logon was unsucessful");
                                                               // msgChange($('#div-login-msg'), $('#icon-login-msg'), $('#text-login-msg'), "fail", "glyphicon-ok", "Login Failed");
                                                                // $('#text-register-msg').text(obj.OutputMsg);   
                                                               //  $('#text-register-msg').css('color', '#f00');
                                                            }

                                                           
                                                        },
                                                        error: function (x, e) {
                                                            alert("The call to the server side failed. " + x.responseText);
                                                        }
                                                    }
                                                );
                                               //s alert(OBJJ);
                                       // return OJU;
                                    }





                        function drawJobApplyTable(data) {
                        // alert('10');
                           // alert(data.length);
                             //t = $('#table-column-toggle').DataTable();
                             
                            var tblJobApplys = '<table cellpadding="5" cellspacing="0" border="0" style="padding-left:50px;">';
                             
                            for (var i = 0; i < data.length; i++) {
                                tblJobApplys += drawJobApplyRow(data[i]);
                            }
                            
                          tblJobApplys += '</table>';
                          
                         // alert(tblJobApplys);
                            return tblJobApplys;
                        }

                        function drawJobApplyRow(rowData) {
                            row = "<tr style='padding:7px; background-color:#EEE;'>"
                            //$("#table-column-toggle").append(row); //this will append tr element to table... keep its reference for a while since we will add cels into it
                            // row.append($("<td><a href='room.aspx?r=" + rowData.name + "' data-rel='external' data-ajax='true'>" + rowData.name + "</a></td>"));
                            //row.append($("<td><a href='javascript:GotoRoom(" + rowData.ID + ");' data-rel='external' data-ajax='true'>" + rowData.Title + "</a></td>"));
                            row += "<td>" + rowData.Username + "</td>";  
                            row += "<td style='padding:7px;'>" + rowData.Email + "</td>";  
                            row += "<td>" + rowData.ApplyDate + "</td>";           
                            // row.append($("<td><button class='btn btn-primary btn-lg'>APPLY</button></td>"));                 
                            //row.append($("<td>" + rowData.gps + "</td>"));
                            row +=  "</tr>";
                            
                            return row;
                           
//                             var counter = 1;
//                            t.row.add( [
//                                        rowData.Employer,
//                                        rowData.Title,
//                                        rowData.Description,
//                                        rowData.ID
//                                        
//                                    ] ).draw( true );
                                                                   
                                    
                                    
                        }















                            //    $('#btnLogoff').click
                           //     (
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
                           //     );
                           //        
                           //  }
                           // catch (err) {
                           //     alert(err);
                           // }
                //        }
               //     );
               
               
               function REGISTERME(theUserName, theEmail, thePassword, theType) {
                                    
                                        var jsTmp = new jUser(theUserName, theEmail, thePassword, "xxx.xxx.xxx.xxx", "420", theType);
                                        var jsonText2 = $.toJSON(jsTmp);
                                      // alert('theEmail');
                                      // alert(theEmail);
                                      //  alert('5');
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
                                                           // alert('6');
                                                            var obj = $.parseJSON(msg);
                                                           // alert('7');
                                                           // alert(obj.ID);
                                                            if (obj.ID > 0) {

                                                                //$('#myDiv3').html("Logon was sucessful");
                                                                // msgChange($('#div-login-msg'), $('#icon-login-msg'), $('#text-login-msg'), "success", "glyphicon-ok", "Login OK");
                                                                $('#text-register-msg').text('Registered Ok');    
                                                                $('#text-register-msg').css('color', '#19c419');              
 
                                                            }
                                                            else {
                                                                 //alert('7');
                                                                //$('#myDiv3').html("Logon was unsucessful");
                                                               // msgChange($('#div-login-msg'), $('#icon-login-msg'), $('#text-login-msg'), "fail", "glyphicon-ok", "Login Failed");
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
                                      // alert('theEmail');
                                      // alert(theEmail);
                                      //  alert('5');
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
                                                           // alert('6');
                                                            var obj = $.parseJSON(msg);
                                                           // alert('7');
                                                           // alert(obj.ID);
                                                            if (obj.ID > 0) {

                                                                //$('#myDiv3').html("Logon was sucessful");
                                                                // msgChange($('#div-login-msg'), $('#icon-login-msg'), $('#text-login-msg'), "success", "glyphicon-ok", "Login OK");
                                                                $('#text-job-post-msg').text('Posted Ok');    
                                                                $('#text-job-post-msg').css('color', '#19c419');              
 
                                                            }
                                                            else {
                                                                 //alert('7');
                                                                //$('#myDiv3').html("Logon was unsucessful");
                                                               // msgChange($('#div-login-msg'), $('#icon-login-msg'), $('#text-login-msg'), "fail", "glyphicon-ok", "Login Failed");
                                                                 $('#text-job-post-msg').text(obj.OutputMsg);   
                                                                 $('#text-job-post-msg').css('color', '#f00');
                                                            }

                                                           
                                                        },
                                                        error: function (x, e) {
                                                            //alert("The call to the server side failed. " + x.responseText);
                                                            alert("Session Expired Please log back in. " + x.responseText);
                                                           // $(location).attr('href', 'default.aspx');
                                                            
                                                        }
                                                    }
                                                );
                                        return false;
                                    }
                                    
                                    
  
                                

