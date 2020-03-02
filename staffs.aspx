
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="staffs.aspx.cs" EnableEventValidation="false" Inherits="umisportal.staffs" %>
okm<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
   <head runat="server">
      <meta charset="utf-8"/>
      <title>Students - Umis Portal</title>
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
      <link rel="stylesheet" type="text/css" href="assets/css/style.css"/>
      <style>
         div.cen {
         text-align: center;
         }
      </style>
   </head>
   <body style="background-color:gray">
      <form id="form1" runat="server">
         <div class="container">
            <header id="header" class="bg-secondary">
               <div class="container" style="margin-bottom:65px">
                  <div id="logo" class="pull-left">
                     <!-- Uncomment below if you prefer to use a text logo -->
                     <h1><a href="#main">P<span>ort</span>al</a></h1>
                     <%--<a href="#intro" class="scrollto"><img src="img/logo.png" alt="" title=""></a>--%>
                  </div>
                  <nav id="nav-menu-container">
                     <ul class="nav-menu">
                        <li><a href="index.aspx">Home</a></li>
                        <li><a href="students.aspx">Students</a></li>
                        <li class="menu-active"><a href="#">Staffs</a></li>
                        <li><a href="information.aspx">General Information</a></li>
                     </ul>
                  </nav>
               </div>
            </header>
            <section id="schedule" class="section-with-bg fadeInLeft">
               <div class="container wow fadeInUp">
                  <div class="section-header">
                     <h2>Welcome to Portal</h2>
                  </div>
                  <div class="tab-content row">
                     <div class="col-lg-6 col-md-7 log-det login-box">
                        <div class="cen justify-content-center">
                           <h2>Sign in</h2>
                           <div class="text-box-cont">
                              <div class="input-group mb-3">
                                 <div class="input-group-prepend">
                                    <span class="input-group-text" id="basic-addon1"><i class="fas fa-user"></i></span>
                                 </div>
                                 <input type="text" class="form-control" placeholder="Username" aria-label="Username" id="userno" runat="server" aria-describedby="userno"/>
                              </div>
                              <div class="input-group mb-3">
                                 <div class="input-group-prepend">
                                    <span class="input-group-text" id="basic-addon2"><i class="fas fa-lock"></i></span>
                                 </div>
                                 <input type="password" class="form-control" placeholder="Password" aria-label="password" runat="server" aria-describedby="pass" id="pass"/>
                              </div>
                              <div class="row">
                                 <p class="forget-p">Forgot Password ?</p>
                              </div>
                              <div class="cen">
                                 <asp:Button ID="Button1" runat="server" Text="SIGN IN" Width="100px" OnClick="Button1_Click" CssClass="btn btn-secondary"/>
                              </div>
                           </div>
                        </div>
                     </div>
                  </div>
               </div>
            </section>
         </div>
      </form>
      <div class="container">
         <footer id="footer" style="height:40px">
            <div class="footer-top">
            </div>
         </footer>
      </div>
      <a href="#" class="back-to-top"><i class="fa fa-angle-up"></i></a>
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

