<%@ Page Language="C#" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="welcomeburser.aspx.cs" Inherits="umisportal.welcomeburser" %>
<!DOCTYPE html>
<html lang="en">
<head runat="server">
	<meta charset="utf-8">
	<meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">
	<meta name="description" content="">
	<meta name="author" content="">
	<link rel="icon" href="images/favicon.ico">
	<title>Bursary Portal</title>

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
					<li class="nav-item"><a class="nav-link" href="staffboard.aspx"><em class="fa fa-dashboard"></em> Dashboard <span class="sr-only">(current)</span></a></li>
                    <li class="nav-item"><a class="nav-link active" href="welcomebursar.aspx">Bursary</a></li>
                    <li class="nav-item"><a class="nav-link" href="coursefees.aspx">Update Course Fees</a></li>
                    <li class="nav-item"><a class="nav-link" href="bursary100.aspx">100 Level</a></li>
					<li class="nav-item"><a class="nav-link" href="bursary200.aspx">200 Level</a></li>
                    <li class="nav-item"><a class="nav-link" href="bursary100.aspx">300 Level</a></li>
					<li class="nav-item"><a class="nav-link" href="bursary200.aspx">400 Level</a></li>
                    <li class="nav-item"><a class="nav-link" href="bursary100.aspx">500 Level</a></li>
					<li class="nav-item"><a class="nav-link" href="bursary200.aspx">Extra year</a></li>
                    <li class="nav-item"><a class="nav-link" href="changepass.aspx">Change your Password</a></li>
				</ul>
				<a href="logout.aspx" class="logout-button"><em class="fa fa-power-off"></em> Signout</a>
			</nav>
			<main class="col-xs-12 col-sm-8 col-lg-9 col-xl-10 pt-3 pl-4 ml-auto">
				<header class="page-header row justify-center">
					<div class="col-md-6 col-lg-8" >
						<h1 class="float-left text-center text-md-left text-secondary">Bursary</h1>
					</div>
					<div class="dropdown user-dropdown col-md-6 col-lg-4 text-center text-md-right"><a class="btn btn-stripped dropdown-toggle" href="#" id="dropdownMenuLink" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
						<img src="logged/studentlogo.png" alt="profile photo" class="circle float-left profile-photo" width="50" height="auto"><asp:Label ID="joinlabel" runat="server" Text=""></asp:Label>
						<div class="username mt-1">
							<h4 class="mb-1"> <asp:Label ID="usernamelabel" runat="server" Text=""></asp:label></h4>
							<h6 class="text-muted"><asp:Label ID="modlabel" runat="server" Text="MODERATOR"></asp:Label></h6>
						</div>
						</a>
						<div class="dropdown-menu dropdown-menu-right" style="margin-right: 1.5rem;" aria-labelledby="dropdownMenuLink"><a class="dropdown-item" href="#"><em class="fa fa-user-circle mr-1"></em> View Profile</a>
						     <a class="dropdown-item" href="#"><em class="fa fa-sliders mr-1"></em> Preferences</a>
						     <a class="dropdown-item" href="logout.aspx"><em class="fa fa-power-off mr-1"></em> Logout</a></div>
					</div>
					<%--<div class="clear"></div>--%>
				</header><div class="container-fluid fadeInLeft" style="background-color:#f6f7fd">
					<div class="row">
						<div class="col-lg-7 col-sm-6 col-md-6 text-left float-left"><br /><br /><br /><br /><h5 class="text-secondary text-center">Filter : <asp:DropDownList runat="server" ID="DropDownList1" CssClass="text" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" AutoPostBack="true" /></h5>
			<h5 class="text-secondary text-center">Search :  <input type="text" placeholder="Matric Number" id="searchid" runat="server" /> <asp:Button ID="Button5" runat="server" Text="Search" CssClass="bg-secondary text-white" OnClick="Button5_Click" /> </h5>
                 <p class="text-center text-danger"><asp:Label ID="searchlabel" runat="server" Text="Please input a Matric Number"></asp:Label></p>
                 <p class="text-center text-danger"><asp:Label ID="notfoundlabel" runat="server" Text="Student not found!!!"></asp:Label></p>
			 </div><div class="col-lg-5"> <br /><br /> <table class="table table-bordered">  <thead>
        <tr>
        <th></th>
        <th>100</th>
        <th>200</th>
        <th>300</th>
        <th>400</th>

      </tr>
    </thead>
    <tbody>
      <tr>
        <td style="width:200px">Approved</td>
        <td>0</td>
        <td>0</td>
        <td>0</td>
        <td>0</td>
  
      </tr>
      <tr>
        <td>Unapproved</td>
        <td>0</td>
        <td>0</td>
        <td>0</td>
        <td>0</td>
      </tr>
      <tr>
        <td>Pending</td>
        <td>0</td>
        <td>0</td>
        <td>0</td>
        <td>0</td>

      </tr>
    </tbody>
  </table></div></div>
                               
                    <div class="jumbotron" style="background-color:#f6f7fd">
                    <asp:GridView ID="GridView1" HeaderStyle-BackColor="#172a57" HeaderStyle-ForeColor="White" PagerStyle-CssClass="text-secondary" PagerSettings-CssClass="text-secondary" runat="server" AutoGenerateColumns="false" AllowCustomPaging="False" AllowPaging="true" OnPageIndexChanging="OnPaging" PageSize="10" PagerSettings-PageButtonCount="10" PagerSettings-Mode="NextPreviousFirstLast" PagerSettings-FirstPageText="First" PagerSettings-LastPageText="Last" PagerSettings-NextPageText="Next" PagerSettings-PreviousPageText="Previous" OnRowCommand="GridView1_RowCommand" CssClass="table-bordered">
             <Columns>
             <asp:BoundField DataField="UserId" HeaderText="ID" ItemStyle-Width="30" />
             <asp:BoundField DataField="Username" HeaderText="Username" ItemStyle-Width="150" />
            <asp:BoundField DataField="Firstname" HeaderText="Firstname" ItemStyle-Width="150" />
            <asp:BoundField DataField="Lastname" HeaderText="Lastname" ItemStyle-Width="150" />
            <asp:BoundField DataField="Financialstatus" HeaderText="Status" ItemStyle-Width="200" />
            <asp:BoundField DataField="Course" HeaderText="Course" ItemStyle-Width="200" />
            <asp:BoundField DataField="Level" HeaderText="Level" ItemStyle-Width="200" />
            <asp:BoundField DataField="Amountpaid" HeaderText="Amount Paid" ItemStyle-Width="200" />
            <asp:BoundField DataField="Amountleft" HeaderText="Amount Left" ItemStyle-Width="200" />
            <asp:BoundField DataField="Totalfees" HeaderText="Total Fees" ItemStyle-Width="300" />
        
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:Button ID="Button1" runat="server" Text="Paid" CommandName="paid" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" CssClass="bg-light text-secondary" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:Button ID="Button2" runat="server" class="btn bg-light" Text="NP" CommandName="notpaid" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" CssClass="bg-light text-secondary" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:Button ID="Button3" runat="server" class="btn bg-light" Text="Pending" CommandName="pending" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" CssClass="bg-light text-secondary" />
                </ItemTemplate>
            </asp:TemplateField>
             <asp:TemplateField HeaderText="Amount Paid">
   <ItemTemplate>
    <asp:TextBox ID="TextBox1" style="width:100px" runat="server" ></asp:TextBox>
   </ItemTemplate>
        </asp:TemplateField>
               <asp:TemplateField HeaderText="">
   <ItemTemplate>
   <asp:Button ID="Button4" runat="server" class="btn btn-light" Text="Update" CommandName="textbox" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" CssClass="bg-secondary text-white" />
   </ItemTemplate>
        </asp:TemplateField>
        </Columns>
    </asp:GridView>   
                <asp:GridView ID="GridView2" HeaderStyle-BackColor="#172a57" HeaderStyle-ForeColor="White" PagerStyle-CssClass="text-secondary" PagerSettings-CssClass="text-secondary" runat="server" AutoGenerateColumns="false" AllowCustomPaging="False" AllowPaging="true" OnPageIndexChanging="OnPaging" PageSize="10" PagerSettings-PageButtonCount="10" PagerSettings-Mode="NextPreviousFirstLast" PagerSettings-FirstPageText="First" PagerSettings-LastPageText="Last" PagerSettings-NextPageText="Next" PagerSettings-PreviousPageText="Previous" OnRowCommand="GridView2_RowCommand">
         <Columns>
            <asp:BoundField DataField="UserId" HeaderText="ID" ItemStyle-Width="30" />
             <asp:BoundField DataField="Username" HeaderText="Username" ItemStyle-Width="150" />
            <asp:BoundField DataField="Firstname" HeaderText="Firstname" ItemStyle-Width="150" />
            <asp:BoundField DataField="Lastname" HeaderText="Lastname" ItemStyle-Width="150" />
            <asp:BoundField DataField="Financialstatus" HeaderText="Status" ItemStyle-Width="200" />
            <asp:BoundField DataField="Course" HeaderText="Course" ItemStyle-Width="200" />
            <asp:BoundField DataField="Level" HeaderText="Level" ItemStyle-Width="200" />
            <asp:BoundField DataField="Amountpaid" HeaderText="Amount Paid" ItemStyle-Width="200" />
            <asp:BoundField DataField="Amountleft" HeaderText="Amount Left" ItemStyle-Width="200" />
            <asp:BoundField DataField="Totalfees" HeaderText="Total Fees" ItemStyle-Width="300" />
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:Button ID="Button1" runat="server" class="btn btn-light" Text="Paid" CommandName="paid" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" CssClass="bg-secondary text-white" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:Button ID="Button2" runat="server" class="btn btn-light" Text="NP" CommandName="notpaid" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" CssClass="bg-secondary text-white" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:Button ID="Button3" runat="server" class="btn btn-light" Text="Pending" CommandName="pending" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" CssClass="bg-secondary text-white" />
                </ItemTemplate>
            </asp:TemplateField>
              <asp:TemplateField HeaderText="Amount Paid">
   <ItemTemplate>
    <asp:TextBox ID="TextBox1" style="width:100px" runat="server" ></asp:TextBox>
   </ItemTemplate>
        </asp:TemplateField>
               <asp:TemplateField HeaderText="">
   <ItemTemplate>
   <asp:Button ID="Button4" runat="server" class="btn btn-light" Text="Update" CommandName="textbox" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" CssClass="bg-secondary text-white" />
   </ItemTemplate>
        </asp:TemplateField>
        </Columns>
    </asp:GridView>   
          <asp:GridView ID="GridView3" HeaderStyle-BackColor="#172a57" HeaderStyle-ForeColor="White" PagerStyle-CssClass="text-secondary" PagerSettings-CssClass="text-secondary" runat="server" AutoGenerateColumns="false" AllowCustomPaging="False" AllowPaging="true" OnPageIndexChanging="OnPaging" PageSize="10" PagerSettings-PageButtonCount="10" PagerSettings-Mode="NextPreviousFirstLast" PagerSettings-FirstPageText="First" PagerSettings-LastPageText="Last" PagerSettings-NextPageText="Next" PagerSettings-PreviousPageText="Previous" OnRowCommand="GridView3_RowCommand">
         <Columns>
            <asp:BoundField DataField="UserId" HeaderText="ID" ItemStyle-Width="30" />
             <asp:BoundField DataField="Username" HeaderText="Username" ItemStyle-Width="150" />
            <asp:BoundField DataField="Firstname" HeaderText="Firstname" ItemStyle-Width="150" />
            <asp:BoundField DataField="Lastname" HeaderText="Lastname" ItemStyle-Width="150" />
            <asp:BoundField DataField="Financialstatus" HeaderText="Status" ItemStyle-Width="200" />
            <asp:BoundField DataField="Course" HeaderText="Course" ItemStyle-Width="200" />
            <asp:BoundField DataField="Level" HeaderText="Level" ItemStyle-Width="200" />
            <asp:BoundField DataField="Amountpaid" HeaderText="Amount Paid" ItemStyle-Width="200" />
            <asp:BoundField DataField="Amountleft" HeaderText="Amount Left" ItemStyle-Width="200" />
            <asp:BoundField DataField="Totalfees" HeaderText="Total Fees" ItemStyle-Width="300" />
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:Button ID="Button1" runat="server" class="btn btn-light" Text="Paid" CommandName="paid" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" CssClass="bg-secondary text-white" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:Button ID="Button2" runat="server" class="btn btn-light" Text="NP" CommandName="notpaid" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" CssClass="bg-secondary text-white" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:Button ID="Button3" runat="server" class="btn btn-light" Text="Pending" CommandName="pending" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" CssClass="bg-secondary text-white" />
                </ItemTemplate>
            </asp:TemplateField>
              <asp:TemplateField HeaderText="Amount Paid">
   <ItemTemplate>
    <asp:TextBox ID="TextBox1" style="width:100px" runat="server" ></asp:TextBox>
   </ItemTemplate>
        </asp:TemplateField>
               <asp:TemplateField HeaderText="">
   <ItemTemplate>
   <asp:Button ID="Button4" runat="server" class="btn btn-light" Text="Update" CommandName="textbox" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" CssClass="bg-secondary text-white" />
   </ItemTemplate>
        </asp:TemplateField>
        </Columns>
    </asp:GridView>  
            <asp:GridView ID="GridView4" HeaderStyle-BackColor="#172a57" HeaderStyle-ForeColor="White" PagerStyle-CssClass="text-secondary" PagerSettings-CssClass="text-secondary" runat="server" AutoGenerateColumns="false" AllowCustomPaging="False" AllowPaging="true" OnPageIndexChanging="OnPaging" PageSize="10" PagerSettings-PageButtonCount="10" PagerSettings-Mode="NextPreviousFirstLast" PagerSettings-FirstPageText="First" PagerSettings-LastPageText="Last" PagerSettings-NextPageText="Next" PagerSettings-PreviousPageText="Previous" OnRowCommand="GridView3_RowCommand">
         <Columns>
            <asp:BoundField DataField="UserId" HeaderText="ID" ItemStyle-Width="30" />
             <asp:BoundField DataField="Username" HeaderText="Username" ItemStyle-Width="150" />
            <asp:BoundField DataField="Firstname" HeaderText="Firstname" ItemStyle-Width="150" />
            <asp:BoundField DataField="Lastname" HeaderText="Lastname" ItemStyle-Width="150" />
            <asp:BoundField DataField="Financialstatus" HeaderText="Status" ItemStyle-Width="200" />
            <asp:BoundField DataField="Course" HeaderText="Course" ItemStyle-Width="200" />
            <asp:BoundField DataField="Level" HeaderText="Level" ItemStyle-Width="200" />
            <asp:BoundField DataField="Amountpaid" HeaderText="Amount Paid" ItemStyle-Width="200" />
            <asp:BoundField DataField="Amountleft" HeaderText="Amount Left" ItemStyle-Width="200" />
            <asp:BoundField DataField="Totalfees" HeaderText="Total Fees" ItemStyle-Width="300" />
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:Button ID="Button1" runat="server" class="btn bg-light" Text="Paid" CommandName="paid" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" CssClass="bg-secondary text-white" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:Button ID="Button2" runat="server" class="btn btn-light" Text="NP" CommandName="notpaid" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" CssClass="bg-secondary text-white" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:Button ID="Button3" runat="server" class="btn btn-light" Text="Pending" CommandName="pending" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" CssClass="bg-secondary text-white" />
                </ItemTemplate>
            </asp:TemplateField>
              <asp:TemplateField HeaderText="Amount Paid">
   <ItemTemplate>
    <asp:TextBox ID="TextBox1" style="width:100px" runat="server" ></asp:TextBox>
   </ItemTemplate>
        </asp:TemplateField>
               <asp:TemplateField HeaderText="">
   <ItemTemplate>
   <asp:Button ID="Button4" runat="server" class="btn btn-light" Text="Update" CommandName="textbox" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" CssClass="bg-secondary text-white" />
   </ItemTemplate>
        </asp:TemplateField>
        </Columns>
    </asp:GridView>  <br /><br /><br /><br /><br/><br /><br /><br /><br />
     </div></div></main>
			</div>	</div> </form>
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

