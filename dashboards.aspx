<%@ Page Title="Home Page" Language="C#" AutoEventWireup="true" CodeBehind="dashboards.aspx.cs" Inherits="umisportal._Default" %>
<!DOCTYPE html>
<html lang="en">
<head runat="server">
	<meta charset="utf-8">
	<meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">
	<meta name="description" content="">
	<meta name="author" content="">
	<link rel="icon" href="images/favicon.ico">
	<title>Portal</title>

    <!-- Bootstrap core CSS -->
    <link href="logged/dist/css/bootstrap.min.css" rel="stylesheet">
    
    <!-- Icons -->
    <link href="logged/css/font-awesome.css" rel="stylesheet">
    
    <!-- Custom styles for this template -->
    <link href="logged/css/style.css" rel="stylesheet">
    <style>
        .image { 
   position: relative; 
   width: 100%; /* for IE 6 */
}

    .hide{
        display:none;
    }

    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container-fluid" id="wrapper">
		<div class="row">
			<nav class="sidebar col-xs-12 col-sm-4 col-lg-3 col-xl-2">
				<h1 class="site-title"><a href="index.aspx"><em class="fa fa-rocket"></em>PORTAL</a></h1>
													
				<a href="#menu-toggle" class="btn btn-default" id="menu-toggle"><em class="fa fa-bars"></em></a>
				<ul class="nav nav-pills flex-column sidebar-nav">
					<li class="nav-item"><a class="nav-link active" href="index.aspx"><em class="fa fa-dashboard"></em> Dashboard <span class="sr-only">(current)</span></a></li>
					<li class="nav-item"><a class="nav-link" href="register.aspx">Register for semester</a></li>
					<li class="nav-item"><a class="nav-link" href="fees.aspx">Fees to pay</a></li>
					<li class="nav-item"><a class="nav-link" href="buttons.html">Vote</a></li>
					<li class="nav-item"><a class="nav-link" href="forms.html">View Results</a></li>
				    <li class="nav-item"><a class="nav-link" href="forms.html">Book an Appointment</a></li>
					<li class="nav-item"><a class="nav-link" href="changepass.aspx">Change your Password</a></li>
				</ul>
				<a href="logout.aspx" class="logout-button"><em class="fa fa-power-off"></em> Signout</a>
			</nav>
			<main class="col-xs-12 col-sm-8 col-lg-9 col-xl-10 pt-3 pl-4 ml-auto">
				<header class="page-header row justify-center">
					<div class="col-md-6 col-lg-8" >
						<h1 class="float-left text-center text-md-left text-secondary">Dashboard</h1>
					</div>
					<div class="dropdown user-dropdown col-md-6 col-lg-4 text-center text-md-right"><a class="btn btn-stripped dropdown-toggle" href="#" id="dropdownMenuLink" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
						<img src="logged/studentlogo.png" alt="profile photo" class="circle float-left profile-photo" width="50" height="auto"><asp:Label ID="joinlabel" runat="server" Text=""></asp:Label>
						<div class="username mt-1">
							<h4 class="mb-1"> <asp:Label ID="usernamelabel" runat="server" Text=""></asp:Label></h4>
							<h6 class="text-muted"><asp:Label ID="studentlabel" runat="server" Text="STUDENT"></asp:Label></h6>
						</div>
						</a>
						<div class="dropdown-menu dropdown-menu-right" style="margin-right: 1.5rem;" aria-labelledby="dropdownMenuLink"><a class="dropdown-item" href="#"><em class="fa fa-user-circle mr-1"></em> View Profile</a>
						     <a class="dropdown-item" href="#"><em class="fa fa-sliders mr-1"></em> Preferences</a>
						     <a class="dropdown-item" href="logout.aspx"><em class="fa fa-power-off mr-1"></em> Logout</a></div>
					</div>
					<%--<div class="clear"></div>--%>
				   </header>
					<section class="row">
							<div class="col-md-12 col-lg-8">
								<div class="jumbotron" style="background-color:#f6f7fd">
									<h3 class="mb-4">Details</h3>
									<p>Name : <asp:Label ID="namelabel" runat="server" Text=""></asp:Label>  </p>
                                    <p>Firstname : <asp:Label ID="firstnamelabel" runat="server" Text=""></asp:Label></p>
                                    <p>Lastname : <asp:Label ID="lastnamelabel" runat="server" Text=""></asp:Label> </p>
                                    <p>Phone : <asp:Label ID="phonelabel" runat="server" Text=""></asp:Label> &nbsp; &nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp; &nbsp; &nbsp;&nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp;&nbsp; &nbsp;&nbsp;<asp:TextBox ID="TextBox1" runat="server"></asp:TextBox></p>
                                    <p>Gender : <asp:Label ID="genderlabel" runat="server" Text=""></asp:Label> </p>
                                    <p>Email : <asp:Label ID="emaillabel" runat="server" Text=""></asp:Label> &nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp; <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox></p>
                                    <p>Financial Status : <asp:Label ID="financelabel" runat="server" Text=""></asp:Label> </p>
                                    <p>Course : <asp:Label ID="courselabel" runat="server" Text=""></asp:Label> </p>
                                    <p>Department : <asp:Label ID="departmentlabel" runat="server" Text=""></asp:Label></p>
                                    
									 <asp:Button ID="Button2" runat="server" class="btn btn-secondary" Text="Edit Profile" OnClick="Button2_Click"/>
                                   <div style="text-align:center"><asp:Button ID="Button3" runat="server" class="btn btn-secondary" Text="Update Profile" OnClick="Button3_Click"/>
                                    </div></div>	  
								</div>
							<div class="col-md-12 col-lg-4">
								<div class="card mb-4">
									<div class="card-block">
										<h3 class="card-title text-secondary">Timeline</h3>
										<h6 class="card-subtitle mb-2 text-muted text-secondary">What's coming up</h6>
                                        
										<ul class="timeline">
											<li>
												<div class="timeline-badge"><em class="fa fa-inbox"></em></div>
												<div class="timeline-panel" id="theading" runat="server">
													<div class="timeline-heading">
														<h5 class="timeline-title mt-2"><b><asp:Label ID="timelinetitle" runat="server" Text=""></asp:Label></b></h5>
													</div>
													<div class="timeline-body">
                                                   <p><asp:Label ID="timelinebody" runat="server" Text=""></asp:Label></p>
													</div>
												</div>
											</li>
											
										</ul>
									</div>
								</div>
								<div class="card mb-4">
									<div class="card-block">
										<h3 class="card-title">Todo List</h3>
										<div class="dropdown card-title-btn-container">
											<button class="btn btn-sm btn-subtle dropdown-toggle" type="button" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false"><em class="fa fa-cog"></em></button>
											<div class="dropdown-menu dropdown-menu-right" aria-labelledby="dropdownMenuButton"><a class="dropdown-item" href="#"><em class="fa fa-search mr-1"></em> More info</a>
												<a class="dropdown-item" href="#"><em class="fa fa-thumb-tack mr-1"></em> Pin Window</a>
											<a class="dropdown-item" href="#"><em class="fa fa-remove mr-1"></em> Close Window</a></div>
										</div>
										<h6 class="card-subtitle mb-2 text-muted">A simple checklist</h6>
				<asp:GridView ID="GridView1"  PagerStyle-CssClass="text-secondary"  PagerSettings-CssClass="text-secondary" style="border:0px;"  runat="server" AutoGenerateColumns="false" AllowCustomPaging="False" AllowPaging="true" OnPageIndexChanging="OnPaging" PageSize="4" PagerSettings-PageButtonCount="5" PagerSettings-Mode="NextPreviousFirstLast" PagerSettings-FirstPageText="First" PagerSettings-LastPageText="Last" PagerSettings-NextPageText="Next" PagerSettings-PreviousPageText="Previous" OnRowDeleting="GridView1_RowDeleting" >
                 <Columns>    
                 <asp:BoundField DataField="Id" HeaderText="SN" ItemStyle-Width="30" ControlStyle-CssClass="hide" ItemStyle-CssClass="hide"/> 
                 <asp:BoundField DataField="SN" HeaderText="Message" ItemStyle-Width="30"/> 
                 <asp:BoundField DataField="Text" ItemStyle-Width="350"/>  
                 <asp:TemplateField>
                 <ItemTemplate>
                     <asp:Button ID="Button1" runat="server" Text="Clear" CommandName="Delete"  CssClass="bg-secondary text-white"/>
                 </ItemTemplate>
            </asp:TemplateField>
            
             </Columns>    
            </asp:GridView>    	
                                        <div class="card-footer todo-list-footer">
											<div class="input-group">
												<input id="textinput" type="text" runat="server" class="form-control input-md" placeholder="Add new task" /><span class="input-group-btn">
												   <asp:Button ID="Button1" runat="server" Text="Add" Width="100px" OnClick="Button1_Click" CssClass="btn btn-secondary btn-md"/>
											</span></div>
										</div>
									</div>
								</div>
							</div>
						</section>
						
					
			</main>
		</div>
	</div>
        </form>
    <!-- Bootstrap core JavaScript
    ================================================== -->
    <!-- Placed at the end of the document so the pages load faster -->
    <script src="https://code.jquery.com/jquery-3.2.1.slim.min.js" integrity="sha384-KJ3o2DKtIkvYIK3UENzmM7KCkRr/rE9/Qpg6aAZGJwFDMVNA/GpGFF93hXpG5KkN" crossorigin="anonymous"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.11.0/umd/popper.min.js" integrity="sha384-b/U6ypiBEHpOf/4+1nzFpr53nxSS+GLCkfwBdFNTxtclqqenISfwAzpKaMNFNmj4" crossorigin="anonymous"></script>
    <script src="logged/dist/js/bootstrap.min.js"></script>
    
    <script src="logged/js/chart.min.js"></script>
    <script src="logged/js/chart-data.js"></script>
    <script src="logged/js/easypiechart.js"></script>
    <script src="logged/js/easypiechart-data.js"></script>
    <script src="logged/js/bootstrap-datepicker.js"></script>
    <script src="logged/js/custom.js"></script>
    <script>
	    var startCharts = function () {
	                var chart1 = document.getElementById("line-chart").getContext("2d");
	                window.myLine = new Chart(chart1).Line(lineChartData, {
	                responsive: true,
	                scaleLineColor: "rgba(0,0,0,.2)",
	                scaleGridLineColor: "rgba(0,0,0,.05)",
	                scaleFontColor: "#c5c7cc "
	                });
	            }; 
	        window.setTimeout(startCharts(), 1000);
	</script>
    
    <script src="https://cdnjs.cloudflare.com/ajax/libs/tether/1.4.0/js/tether.min.js" integrity="sha384-DztdAPBWPRXSA/3eYEEUWrWCy7G5KFbe8fFjk5JAIxUYHKkDx6Qin1DkWx51bBrb" crossorigin="anonymous"></script>
    
	</body>
</html>
