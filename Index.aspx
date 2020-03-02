<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="umisportal.Index" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
   <head runat="server">
      <meta charset="utf-8"/>
      <title>School - Umis Portal</title>
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
      <link href="lib/owlcarousel/assets/owl.carousel.min.css" rel="stylesheet"/>
      <!-- Main Stylesheet File -->
      <link href="css/style.css" rel="stylesheet"/>
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
                        <li class="menu-active"><a href="#intro">Home</a></li>
                        <li><a href="students.aspx">Students</a></li>
                        <li><a href="staffs.aspx">Staffs</a></li>
                        <li><a href="information.aspx">General Information</a></li>
                     </ul>
                  </nav>
               </div>
            </header>
            <section id="schedule" class="section-with-bg fadeInLeft">
               <div class="container wow fadeInUp">
                  <div class="section-header">
                     <h2>Welcome to Portal</h2>
                     <h5 style="font-size:17px; color:gray"> Easy access for our lecturers, students and employers to access information as accurately as possible. Students can register for classes, access grades and use many other features.</h5>
                  </div>
                  <ul class="nav nav-tabs" role="tablist">
                     <li class="nav-item">
                        <a class="nav-link active" href="#row-1" role="tab" data-toggle="tab">Features</a>
                     </li>
                     <li class="nav-item">
                        <a class="nav-link" href="#row-2" role="tab" data-toggle="tab">Procedures</a>
                     </li>
                     <li class="nav-item">
                        <a class="nav-link" href="#row-3" role="tab" data-toggle="tab">Admission</a>
                     </li>
                  </ul>
                  <div class="tab-content row justify-content-center">
                     <!-- Schdule Day 1 -->
                     <div role="tabpanel" class="col-lg-9 tab-pane fade show active" id="row-1">
                        <h4>What you can do ?</h4>
                        <hr />
                        <ul>
                           <li class="text-secondary">
                              <h5 style="font-size:17px; color:gray">Register for class</h5>
                           </li>
                           <li class="text-secondary">
                              <h5 style="font-size:17px; color:gray">View your personal details</h5>
                           </li>
                           <li class="text-secondary">
                              <h5 style="font-size:17px; color:gray">View your GPA reports</h5>
                           </li>
                           <li class="text-secondary">
                              <h5 style="font-size:17px; color:gray">View your student account</h5>
                           </li>
                           <li class="text-secondary">
                              <h5 style="font-size:17px; color:gray">Vote during school election</h5>
                           </li>
                        </ul>
                     </div>
                     <!-- End Row 1 -->
                     <!-- Schdule Day 2 -->
                     <div role="tabpanel" class="col-lg-9  tab-pane fade" id="row-2">
                        <h2>Login</h2>
                        <hr />
                        <ul>
                           <li class="text-secondary">
                              <h5 style="font-size:17px; color:gray">Click on the Student Menu</h5>
                           </li>
                           <li class="text-secondary">
                              <h5 style="font-size:17px; color:gray">Login with your username and password obtained from your email used in Registration</h5>
                           </li>
                           <li class="text-secondary">
                              <h5 style="font-size:17px; color:gray">Once you login kindly change your password by clicking on the Change Password link at the top right hand of your page</h5>
                           </li>
                        </ul>
                        <h3>Course Registration</h3>
                        <hr />
                        <ul>
                           <li class="text-secondary">
                              <h5 style="font-size:17px; color:gray">You must be approved financially before you can register your courses (Fees must be Cleared)</h5>
                           </li>
                        </ul>
                     </div>
                     <!-- End Row 2 -->
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
   </body>
</html>

