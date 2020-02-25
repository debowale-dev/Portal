<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="addcourse.aspx.cs" EnableEventValidation="false" Inherits="umisportal.addcourse" %>
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
    <script>
        function erroruser() {
            alert("Username exists");
        }
        function errord() {
            alert("Please fill all fields");
        }
        function successadd() {
            alert("Successfully added");
        }
        function errord() {
            alert("Fill in all Fields");
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
		<li class="nav-item"><a class="nav-link" href="staffboard.aspx"><em class="fa fa-dashboard"></em> Dashboard <span class="sr-only">(current)</span></a></li>
         <li class="nav-item"><a class="nav-link active" href="coursefees.aspx">ADD/ MODIFY COURSES</a></li>
				</ul>
				<a href="logout.aspx" class="logout-button"><em class="fa fa-power-off"></em>Signout</a>
			</nav>
			<main class="col-xs-12 col-sm-8 col-lg-9 col-xl-10 pt-3 pl-4 ml-auto">
				<header class="page-header row justify-center" style="margin-bottom:0px">
					<div class="col-md-6 col-lg-8" >
						<h1 class="float-left text-center text-md-left text-secondary">Modify Courses</h1>
					</div>
					<div class="dropdown user-dropdown col-md-6 col-lg-4 text-center text-md-right"><a class="btn btn-stripped dropdown-toggle" href="#" id="dropdownMenuLink" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
					<img src="logged/studentlogo.png" alt="profile photo" class="circle float-left profile-photo" width="50" height="auto"><asp:Label ID="joinlabel" runat="server" Text=""></asp:Label>
					<div class="username mt-1">
							<h4 class="mb-1"> <asp:Label ID="usernamelabel" runat="server" Text=""></asp:Label></h4>
							<h6 class="text-muted"><asp:Label ID="stafflabel" runat="server" Text="MODERATOR"></asp:Label></h6>
						</div>
						</a>
					<div class="dropdown-menu dropdown-menu-right" style="margin-right: 1.5rem;" aria-labelledby="dropdownMenuLink"><a class="dropdown-item" href="#"><em class="fa fa-user-circle mr-1"></em> View Profile</a>
				    <a class="dropdown-item" href="#"><em class="fa fa-sliders mr-1"></em> Preferences</a>
					<a class="dropdown-item" href="#"><em class="fa fa-power-off mr-1"></em> Logout</a></div>
					</div>
					<%--<div class="clear"></div>--%>
			    	</header>
					<div class="card" style="background-color:#f6f7fd">
                    <div class="card-body"><br /><br />
                     <asp:GridView ID="GridView1" HeaderStyle-BackColor="#172a57" HeaderStyle-ForeColor="White" PagerStyle-CssClass="text-secondary" PagerSettings-CssClass="text-secondary" runat="server" AutoGenerateColumns="false" AllowCustomPaging="False" AllowPaging="true" OnPageIndexChanging="OnPaging" PageSize="10" PagerSettings-PageButtonCount="10" PagerSettings-Mode="NextPreviousFirstLast" PagerSettings-FirstPageText="First" PagerSettings-LastPageText="Last" PagerSettings-NextPageText="Next" PagerSettings-PreviousPageText="Previous" OnRowDataBound="GridView1_RowDataBound" OnRowCommand="GridView1_RowCommand">
            <Columns>
            <asp:BoundField DataField="CourseId" HeaderText="Course ID" ItemStyle-Width="10" />
            <asp:BoundField DataField="Course" HeaderText="Course" ItemStyle-Width="150" />
            <asp:BoundField DataField="Lecturer" HeaderText="Lecturer" ItemStyle-Width="150" />
            <asp:BoundField DataField="Level" HeaderText="Level" ItemStyle-Width="150" />         
             <asp:TemplateField HeaderText="Modify Lecturer">
       <ItemTemplate >
       <asp:DropDownList runat="server" ID="ddlitem" style="width:150px"  OnSelectedIndexChanged="ddlist_SelectedIndexChanged" DataTextField="Text" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>"/>
       </ItemTemplate>
                 </asp:TemplateField>
  <asp:TemplateField>
                <ItemTemplate>
                    <asp:Button ID="Button1" runat="server" class="btn btn-light" Text="Update" CommandName="modify"  CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" CssClass="bg-secondary text-white" />
                </ItemTemplate>
            </asp:TemplateField>
            

        </Columns>
    </asp:GridView>  <br /><br /><br /><br /> </div></div><br /><br />
                <%--<h1 class="float-left text-center text-md-left text-secondary">Add a course</h1><br />--%>
         <div class="card" style="background-color:#f6f7fd">
         <div class="card-body">
           <table class="table table-bordered">
    <thead class="bg-secondary text-white">
      <tr>
        <th>Course</th>
        <th>Lecturer</th>
        <th>Level</th>
        <th>Add Course</th>
      </tr>
    </thead>

    <tbody style="background-color:#f6f7fd">
      <tr style="margin-bottom:50px">
        <td><input type="text" id="TextBo1" runat="server" style="width:150px" /></td>
        <td> <asp:DropDownList ID="DropDownList1" runat="server" Width="150px" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged"></asp:DropDownList> </td>
        <td><input type="text" id="TextBo2" runat="server" style="width:150px" /></td>
        <td><asp:Button ID="Button2" runat="server" Text="Add"  CssClass="bg-secondary text-white" OnClick="Button1_Click"/></td>
      </tr>
    </tbody>
  </table></div></div>
			</main></div><br /></div></form>
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

