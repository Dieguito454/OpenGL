<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LogOut.aspx.cs" Inherits="OpenGL.pages.LogOut" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Open GL</title>

      <!-- Fontfaces CSS-->
    <link href="../css/font-face.css" rel="stylesheet" media="all">
    <link href="../vendor/font-awesome-4.7/css/font-awesome.min.css" rel="stylesheet" media="all">
    <link href="../vendor/font-awesome-5/css/fontawesome-all.min.css" rel="stylesheet" media="all">
    <link href="../vendor/mdi-font/css/material-design-iconic-font.min.css" rel="stylesheet" media="all">

    <!-- Bootstrap CSS-->
    <link href="../vendor/bootstrap-4.1/bootstrap.min.css" rel="stylesheet" media="all">

    <!-- Vendor CSS-->
    <link href="../vendor/animsition/animsition.min.css" rel="stylesheet" media="all">
    <link href="../vendor/bootstrap-progressbar/bootstrap-progressbar-3.3.4.min.css" rel="stylesheet" media="all">
    <link href="../vendor/wow/animate.css" rel="stylesheet" media="all">
    <link href="../vendor/css-hamburgers/hamburgers.min.css" rel="stylesheet" media="all">
    <link href="../vendor/slick/slick.css" rel="stylesheet" media="all">
    <link href="../vendor/select2/select2.min.css" rel="stylesheet" media="all">
    <link href="../vendor/perfect-scrollbar/perfect-scrollbar.css" rel="stylesheet" media="all">
    <link href="../vendor/vector-map/jqvmap.min.css" rel="stylesheet" media="all">

    <!-- Main CSS-->
    <link href="../css/theme.css" rel="stylesheet" media="all">
</head>
<body class="animsition">

     <div class="page-wrapper">
        <!-- MENU SIDEBAR-->
        <aside class="menu-sidebar2">
            <div class="logo">
                <a href="Principal.aspx">
                    <img src="../img/logoHeader.png"/>
                </a>
            </div>
            <div class="menu-sidebar2__content js-scrollbar1">
                <div class="account2">
                    <div class="image img-cir img-120">
                        <img src="../img/perfilSinFoto.jpg" />
                    </div>
                    <h4 class="name">Diego Torres</h4>
                    <a href="LogOut.aspx">Sign out</a>
                </div>
                <nav class="navbar-sidebar2">
                    <ul class="list-unstyled navbar__list">              
                         <li>
                            <a href="Principal.aspx">
                                <i class="fa fa-newspaper-o"></i>Dashboard</a>
                        </li>
                        <li>
                            <a href="SubaDeArchivo.aspx">
                                <i class="fa fa-file-excel-o"></i>Carga tu archivo</a>
                        </li>
                        <li class="has-sub">
                            <a class="js-arrow" href="#">
                                <i class="fa fa-th-list"></i>Cuentas
                                <span class="arrow">
                                    <i class="fas fa-angle-down"></i>
                                </span>
                            </a>
                            <ul class="list-unstyled navbar__sub-list js-sub-list">
                                <li>
                                    <a href="form.html">
                                       Agregar cuenta</a>
                                </li>
                                <li>
                                    <a href="#">
                                        Quitar cuenta</a>
                                </li>
                                <li>
                                    <a href="map.html">
                                        Buscar Cuenta</a>
                                </li>
                            </ul>
                        </li>
                        <li class="has-sub">
                            <a class="js-arrow" href="#">
                                <i class="fas fa-user"></i>Usuarios
                                <span class="arrow">
                                    <i class="fas fa-angle-down"></i>
                                </span>
                            </a>
                            <ul class="list-unstyled navbar__sub-list js-sub-list">
                                <li>
                                    <a href="AltaUsuario.aspx">
                                        Alta de usuario</a>
                                </li>
                                <li>
                                    <a href="register.html">
                                        Baja de usuario</a>                                        
                                </li>
                                <li>
                                    <a href="forget-pass.html">
                                        Buscar Usuario</a>
                                </li>
                            </ul>
                        </li>

                        <li>
                            <a href="PruebasAutomaticas.aspx">
                                <i class="fa fa-hourglass-half"></i>Pruebas Automaticas</a>
                        </li>
                    </ul>
                </nav>
            </div>
        </aside>
        <!-- END MENU SIDEBAR-->




        <!-- PAGE CONTAINER-->
        <div class="page-container2">
            <!-- HEADER DESKTOP-->
            <header class="header-desktop2">
                <div class="section__content section__content--p30">
                    <div class="container-fluid">
                        <div class="header-wrap2">
                            <div class="logo d-block d-lg-none">
                                <a href="#">
                                    <img src="../img/logoHeader.png"/>
                                </a>
                            </div>
                            
                                <div class="header-button-item mr-0 js-sidebar-btn">
                                    <i class="zmdi zmdi-menu"></i>
                                </div>
                                <div class="setting-menu js-right-sidebar d-none d-lg-block">
                                    <div class="account-dropdown__body">
                                        <div class="account-dropdown__item">
                                            <a href="#">
                                                <i class="zmdi zmdi-account"></i>Mi Perfil</a>
                                        </div>                                                                  
                                    </div>
                                    <div class="account-dropdown__body">                                     
                                         <div class="account-dropdown__item">
                                            <a href="LogOut.aspx">
                                                <i class="zmdi zmdi-power"></i>Log Out</a>
                                        </div>  
                                    </div>

                                </div>
                            </div>
                        </div>
                    </div>
                    </header>
                
            

            <!-- MAIN CONTENT-->
            <div class="main-content">
                <div class="section__content section__content--p30">
                    <div class="container-fluid">
                        

                            <div class="login-wrap">
                    <div class="login-content">
                        <div class="login-logo">
                            <a href="#">
                                <img src="../img/login.jpg" >
                            </a>
                        </div>
                        <div class="login-form">
                            <form runat="server">
                                <div class="form-group">
                                    <label>Esta seguro que desea salir?</label>                                     
                                </div>                                                             
                                <asp:Button ID="btnSalir" CssClass="au-btn au-btn--block au-btn--green m-b-20" runat="server" OnClick="btnSalir_Click" Text="Salir" />                        
                            </form>
                            <div>
                                
                            </div>                   
                        </div>
                    </div>
                </div>


                 
                    </div>
                </div>
            </div>
            <!-- END MAIN CONTENT-->

         

            <section>
                <div class="container-fluid">
                    <div class="row">
                        <div class="col-md-12">
                            <div class="copyright">
                                <p>Copyright © 2019 Crowe Howarth.</p>
                            </div>
                        </div>
                    </div>
                </div>
            </section>
            <!-- END PAGE CONTAINER-->

            </div>
         </div>
         
    

    <!-- Jquery JS-->
    <script src="../vendor/jquery-3.2.1.min.js"></script>
    <!-- Bootstrap JS-->
    <script src="../vendor/bootstrap-4.1/popper.min.js"></script>
    <script src="../vendor/bootstrap-4.1/bootstrap.min.js"></script>
    <!-- Vendor JS       -->
    <script src="../vendor/slick/slick.min.js">
    </script>
    <script src="../vendor/wow/wow.min.js"></script>
    <script src="../vendor/animsition/animsition.min.js"></script>
    <script src="../vendor/bootstrap-progressbar/bootstrap-progressbar.min.js">
    </script>
    <script src="../vendor/counter-up/jquery.waypoints.min.js"></script>
    <script src="../vendor/counter-up/jquery.counterup.min.js">
    </script>
    <script src="../vendor/circle-progress/circle-progress.min.js"></script>
    <script src="../vendor/perfect-scrollbar/perfect-scrollbar.js"></script>
    <script src="../vendor/chartjs/Chart.bundle.min.js"></script>
    <script src="../vendor/select2/select2.min.js">
    </script>
    <script src="../vendor/vector-map/jquery.vmap.js"></script>
    <script src="../vendor/vector-map/jquery.vmap.min.js"></script>
    <script src="../vendor/vector-map/jquery.vmap.sampledata.js"></script>
    <script src="../vendor/vector-map/jquery.vmap.world.js"></script>

    <!-- Main JS-->
    <script src="../js/main.js"></script> 

</body>
</html>
