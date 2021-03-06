﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="fees.aspx.cs" Inherits="umisportal.fees" %>
<!DOCTYPE html>
<html lang="en">
<head runat="server">
 <meta charset="utf-8"/>
  <title>BURSARY</title>
  <meta content="width=device-width, initial-scale=1.0" name="viewport"/>
  <meta content="" name="keywords"/>
  <meta content="" name="description"/>
     
  <!-- Favicons -->
  <link href="img/favicon.png" rel="icon"/>
  <link href="img/apple-touch-icon.png" rel="apple-touch-icon"/>

  <!-- Google Fonts -->
  <link href="https://fonts.googleapis.com/css?family=Open+Sans:300,300i,400,400i,700,700i|Raleway:300,400,500,700,800" rel="stylesheet"/>

  <!-- Bootstrap CSS File -->
  <link href="lib/bootstrap/css/bootstrap.min.css" rel="stylesheet"/>

  <!-- Libraries CSS Files -->
  <link href="lib/font-awesome/css/font-awesome.min.css" rel="stylesheet"/>
  <link href="lib/animate/animate.min.css" rel="stylesheet"/>
  <link href="lib/venobox/venobox.css" rel="stylesheet"/>
  <link rel="stylesheet" href="assets/css/fontawsom-all.min.css"/>
  <link href="lib/owlcarousel/assets/owl.carousel.min.css" rel="stylesheet"/>

  <!-- Main Stylesheet File -->
  <link href="css/style.css" rel="stylesheet"/>
    <link href="css/magic-check.css" rel="stylesheet">
    <link rel="stylesheet" type="text/css" href="assets/css/style.css"/>
    <!-- Bootstrap core CSS -->
    <link href="logged/dist/css/bootstrap.min.css" rel="stylesheet"/>
    
    <!-- Icons -->
    <link href="logged/css/font-awesome.css" rel="stylesheet"/>
    
    <!-- Custom styles for this template -->
    <link href="logged/css/style.css" rel="stylesheet"/>
    <style type="text/css">
        
       
           .image { 
   position: relative; 
   width: 100%; /* for IE 6 */
    }

    .hide{
        display:none;
    }
         div.cen {
  text-align: center;
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
					<li class="nav-item"><a class="nav-link" href="dashboardS.aspx"><em class="fa fa-dashboard"></em> Dashboard <span class="sr-only">(current)</span></a></li>
                    <li class="nav-item" runat="server"><a class="nav-link active disabled" href="fees.aspx">Fees</a></li>				
                </ul>
				<a href="logout.aspx" class="logout-button"><em class="fa fa-power-off"></em> Signout</a>
			</nav>
			<main class="col-xs-12 col-sm-8 col-lg-9 col-xl-10 pt-3 pl-4 ml-auto">
				<header class="page-header row justify-center">
					<div class="col-md-6 col-lg-8" >
						<h1 class="float-left text-center text-md-left text-secondary">Fees</h1>
					</div>
					<div class="dropdown user-dropdown col-md-6 col-lg-4 text-center text-md-right"><a class="btn btn-stripped dropdown-toggle" href="#" id="dropdownMenuLink" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
						<img src="logged/studentlogo.png" alt="profile photo" class="circle float-left profile-photo" width="50" height="auto"><asp:Label ID="joinlabel" runat="server" Text=""></asp:Label>
						<div class="username mt-1">
							<h4 class="mb-1"> <asp:Label ID="usernamelabel" runat="server" Text=""></asp:Label></h4>
							<h6 class="text-muted"><asp:Label ID="stafflabel" runat="server" Text="STUDENT"></asp:Label></h6>
						</div>
						</a>
						<div class="dropdown-menu dropdown-menu-right" style="margin-right: 1.5rem;" aria-labelledby="dropdownMenuLink"><a class="dropdown-item" href="#"><em class="fa fa-user-circle mr-1"></em> View Profile</a>
						     <a class="dropdown-item" href="#"><em class="fa fa-sliders mr-1"></em> Preferences</a>
						     <a class="dropdown-item" href="logout.aspx"><em class="fa fa-power-off mr-1"></em> Logout</a></div>
					</div>
					<%--<div class="clear"></div>--%>
				</header>
                    <div class="container-fluid">
					<section class="row">
							<div class="col-12">
								<div class="jumbotron wow fadeInUp" style="background-color:#f6f7fd"><br /><br /> <div id="show4" runat="server"><div class="tab-content row" style="margin-top:0px">
                            <div class=" log-det login-box" style="width:800px;margin-top:0px"><div class="cen justify-content-center">
                            <h3>Fees to Pay</h3><hr class="text-secondary" style="width:400px"/></div>
                            <div class="text-box-cont text-secondary  text-left" style="font-size:20px">
                         
                            <b>Name :</b>&nbsp; &nbsp;<asp:Label ID="namelabel" runat="server" Text=""></asp:Label><br />
                           <b>Course :</b>&nbsp; &nbsp;<asp:Label ID="courselabel" runat="server" Text=""></asp:Label><br />
                            <b>Level :</b>&nbsp; &nbsp;<asp:Label ID="levellabel" runat="server" Text=""></asp:Label><br />
                            <b>Fees to Pay:</b> &nbsp; &nbsp; <asp:Label ID="subtotallabel" runat="server" Text=""></asp:Label><br />
                            <b>Amount Paid :</b>&nbsp; &nbsp;<asp:Label ID="amountpaidlabel" runat="server" Text=""></asp:Label><br />
                            <b>Amount Left :</b>&nbsp; &nbsp;<asp:Label ID="amountleftlabel" runat="server" Text=""></asp:Label><br />
                            <b>Financial Status :</b>&nbsp; &nbsp;<asp:Label ID="financialstatuslabel" runat="server" Text=""></asp:Label>
                               </div>
                       </div> </div></div>
                 <br /><br /><br /><br /><br /><div id="show1" runat="server"><div class="tab-content row">
                 <div class="col-lg-6 col-md-7 log-det login-box"><div class="cen justify-content-center">
                            <h3>Fees Registration</h3><hr class="text-secondary" style="width:400px"/>
                            <div class="text-box-cont text-secondary" style="font-size:20px"><b>
                                     Tuition Fee :  <asp:Label ID="Tuitionfee" runat="server" Text=""></asp:Label><br />
                                    <%-- Course : <asp:Label ID="courselabel" runat="server" Text="Label"></asp:Label><br />--%></b><br />
                                   <asp:Button ID="Button1" runat="server" Text="CONTINUE" Width="130px" OnClick="Button1_Click" CssClass="btn btn-secondary"/>
                               </div>
                              
                            </div></div>
                            </div></div><div id="show2" runat="server"><div class="tab-content row">
                            <div class="col-lg-6 col-md-7 log-det login-box"><div class="cen justify-content-center">
                            <h3>Fees Registration</h3><hr class="text-secondary" style="width:400px"/>
                            <div class="text-box-cont text-secondary" style="font-size:20px">
                            <asp:CheckBoxList runat="server" ID="CheckBoxList1" OnSelectedIndexChanged="CheckBoxList1_SelectedIndexChanged">
                            <asp:ListItem Text="Off  &nbsp; &nbsp; Campus" />
                            <asp:ListItem Text="Main Campus" />
                            </asp:CheckBoxList>
                            </div>
                            <asp:Button ID="Button2" runat="server" Text="CONTINUE" Width="130px" OnClick="Button2_Click" CssClass="btn btn-secondary"/>
                            </div></div></div>
                            </div><div id="show3" runat="server"><div class="tab-content row">
                            <div class="col-lg-6 col-md-7 log-det login-box"><div class="cen justify-content-center">
                            <h3>Fees Registration</h3><hr class="text-secondary" style="width:400px"/>
                            <div class="text-box-cont text-secondary" style="font-size:20px">
                            <asp:DropDownList ID="DropDownList1" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" runat="server"></asp:DropDownList><br /><br />
                            </div>
                            <asp:Button ID="Button3" runat="server" Text="CONTINUE" Width="130px" OnClick="Button3_Click" CssClass="btn btn-secondary"/>
                            </div></div></div>
                            </div><br /><br /><br /><br /><br /><br /><br /><br /><br />
                          </div></div></section><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /></div><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /></main></div></div>
    <a href="#" class="back-to-top"><i class="fa fa-angle-up"></i></a></form>
  <!-- JavaScript Libraries -->
  <script src="lib/jquery/jquery.min.js"></script>
  <script src="lib/jquery/jquery-migrate.min.js"></script>
  <script src="lib/bootstrap/js/bootstrap.bundle.min.js"></script>
  <script src="lib/easing/easing.min.js"></script>
  <script src="lib/superfish/hoverIntent.js"></script>
  <script src="lib/superfish/superfish.min.js"></script>
  <script src="lib/wow/wow.min.js"></script>
  <script src="lib/venobox/venobox.min.js"></script>
  <script src="lib/owlcarousel/owl.carousel.min.js"></script>

  <!-- Contact Form JavaScript File -->
  <script src="contactform/contactform.js"></script>

  <!-- Template Main Javascript File -->
 <script src="js/main.js"></script>
<script src="assets/js/jquery-3.2.1.min.js"></script>
<script src="assets/js/popper.min.js"></script>
<script src="assets/js/bootstrap.min.js"></script>
<script src="assets/js/script.js"></script>
      
</body>
</html>