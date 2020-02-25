<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="accessdenied.aspx.cs" Inherits="umisportal.accessdenied" %>
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
    </style>
    <script>
        function errorchange() {
            alert("Incorrect Password");
        }
        function success() {
            alert("successfully changed");
        }
    </script>
</head>
<body style="background-color:lightgray">
    <form id="form1" runat="server">
        <div class="container" id="wrapper">
		<div class="row">
			<nav class="sidebar col-xs-12 col-sm-4 col-lg-3 col-xl-2">
				<h1 class="site-title"><a href="index.aspx"><em class="fa fa-rocket"></em>PORTAL</a></h1>
													
				<a href="#menu-toggle" class="btn btn-default" id="menu-toggle"><em class="fa fa-bars"></em></a>
				<ul class="nav nav-pills flex-column sidebar-nav">
					<li class="nav-item"><a class="nav-link active" href="dashboard.aspx"><em class="fa fa-dashboard"></em> Dashboard <span class="sr-only">(current)</span></a></li>
				</ul>
				<a href="logout.aspx" class="logout-button"><em class="fa fa-power-off"></em>Signout</a>
			</nav>
			<main class="col-xs-12 col-sm-8 col-lg-9 col-xl-10 pt-3 pl-4 ml-auto">
				<header class="page-header row justify-center" style="margin-bottom:70px">
					<div class="col-md-6 col-lg-8" >
						<h1 class="float-left text-center text-md-left text-secondary">Portal</h1>
					</div>
					<div class="dropdown user-dropdown col-md-6 col-lg-4 text-center text-md-right"><a class="btn btn-stripped dropdown-toggle" href="#" id="dropdownMenuLink" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
						<img src="logged/studentlogo.png" alt="profile photo" class="circle float-left profile-photo" width="50" height="auto"><asp:Label ID="joinlabel" runat="server" Text=""></asp:Label>
						<div class="username mt-1">
							<h4 class="mb-1"> <asp:Label ID="usernamelabel" runat="server" Text=""></asp:Label></h4>
						</div>
						</a>
						<div class="dropdown-menu dropdown-menu-right" style="margin-right: 1.5rem;" aria-labelledby="dropdownMenuLink"><a class="dropdown-item" href="#"><em class="fa fa-user-circle mr-1"></em> View Profile</a>
						     <a class="dropdown-item" href="#"><em class="fa fa-sliders mr-1"></em> Preferences</a>
						     <a class="dropdown-item" href="#"><em class="fa fa-power-off mr-1"></em> Logout</a></div>
					</div>
					<%--<div class="clear"></div>--%>
				</header>
					<section class="row">
                        <br /><br /><br /><br />
							<div class="col-md-12 col-lg-8">
								 <div class="card mb-4">
							     <div class="card-block"style="height:200px;background-color:lightgray">
                                        
										<h3 class="text-secondary">Access Denied</h3>
										 <p>Sorry <asp:Label ID="namelabel" runat="server" Text=""></asp:Label>, you do not have access to this page</p><br /><h4 class="text-danger"><a href="staffboard.aspx">Go Back</a></h4>
									</div>
								</div>
								</div></section>
					
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

