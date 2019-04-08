<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PruebasAutomaticas.aspx.cs" Inherits="OpenGL.pages.PruebasAutomaticas" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>

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
    <link href="../css/modalLogin.css" rel="stylesheet" />
</head>


<body class="animsition">
  
     <div class="page-wrapper">
        <!-- MENU SIDEBAR-->
        <aside class="menu-sidebar2">
            <div class="logo">
                <a href="#">
                    <img src="../images/icon/logo-white.png" alt="Cool Admin" />
                </a>
            </div>
            <div class="menu-sidebar2__content js-scrollbar1">
                <div class="account2">
                    <div class="image img-cir img-120">
                        <img src="../img/perfilSinFoto.jpg" />
                    </div>
                    <h4 class="name">Diego Torres</h4>
                    <a href="#">Sign out</a>
                </div>
                <nav class="navbar-sidebar2">
                    <ul class="list-unstyled navbar__list">              
                         <li>
                            <a href="#">
                                <i class="fas fa-tachometer-alt"></i>Dashboard</a>
                        </li>
                        <li>
                            <a href="#">
                                <i class="fas fa-shopping-basket"></i>Carga tu archivo</a>
                        </li>
                        <li class="has-sub">
                            <a class="js-arrow" href="#">
                                <i class="fas fa-trophy"></i>Cuentas
                                <span class="arrow">
                                    <i class="fas fa-angle-down"></i>
                                </span>
                            </a>
                            <ul class="list-unstyled navbar__sub-list js-sub-list">
                                <li>
                                    <a href="form.html">
                                        <i class="far fa-check-square"></i>Agregar cuenta</a>
                                </li>
                                <li>
                                    <a href="#">
                                        <i class="fas fa-calendar-alt"></i>Quitar cuenta</a>
                                </li>
                                <li>
                                    <a href="map.html">
                                        <i class="fas fa-map-marker-alt"></i>Buscar Cuenta</a>
                                </li>
                            </ul>
                        </li>
                        <li class="has-sub">
                            <a class="js-arrow" href="#">
                                <i class="fas fa-copy"></i>Usuarios
                                <span class="arrow">
                                    <i class="fas fa-angle-down"></i>
                                </span>
                            </a>
                            <ul class="list-unstyled navbar__sub-list js-sub-list">
                                <li>
                                    <a href="login.html">
                                        <i class="fas fa-sign-in-alt"></i>Alta de usuario</a>
                                </li>
                                <li>
                                    <a href="register.html">
                                        <i class="fas fa-user"></i>Baja de usuario</a>
                                </li>
                                <li>
                                    <a href="forget-pass.html">
                                        <i class="fas fa-unlock-alt"></i>Buscar Usuario</a>
                                </li>
                            </ul>
                        </li>

                        <li>
                            <a href="#">
                                <i class="fas fa-shopping-basket"></i>Pruebas Automaticas</a>
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
                                    <img src="../images/icon/logo-white.png" alt="CoolAdmin" />
                                </a>
                            </div>
                            <div class="header-button2">
                                <div class="header-button-item js-item-menu">
                                    <i class="zmdi zmdi-search"></i>
                                    <div class="search-dropdown js-dropdown">
                                        <form action="">
                                            <input class="au-input au-input--full au-input--h65" type="text" placeholder="Search for datas &amp; reports..." />
                                            <span class="search-dropdown__icon">
                                                <i class="zmdi zmdi-search"></i>
                                            </span>
                                        </form>
                                    </div>
                                </div>
                                <div class="header-button-item has-noti js-item-menu">
                                    <i class="zmdi zmdi-notifications"></i>
                                    <div class="notifi-dropdown js-dropdown">
                                        <div class="notifi__title">
                                            <p>You have 3 Notifications</p>
                                        </div>
                                        <div class="notifi__item">
                                            <div class="bg-c1 img-cir img-40">
                                                <i class="zmdi zmdi-email-open"></i>
                                            </div>
                                            <div class="content">
                                                <p>You got a email notification</p>
                                                <span class="date">April 12, 2018 06:50</span>
                                            </div>
                                        </div>
                                        <div class="notifi__item">
                                            <div class="bg-c2 img-cir img-40">
                                                <i class="zmdi zmdi-account-box"></i>
                                            </div>
                                            <div class="content">
                                                <p>Your account has been blocked</p>
                                                <span class="date">April 12, 2018 06:50</span>
                                            </div>
                                        </div>
                                        <div class="notifi__item">
                                            <div class="bg-c3 img-cir img-40">
                                                <i class="zmdi zmdi-file-text"></i>
                                            </div>
                                            <div class="content">
                                                <p>You got a new file</p>
                                                <span class="date">April 12, 2018 06:50</span>
                                            </div>
                                        </div>
                                        <div class="notifi__footer">
                                            <a href="#">All notifications</a>
                                        </div>
                                    </div>
                                </div>
                                <div class="header-button-item mr-0 js-sidebar-btn">
                                    <i class="zmdi zmdi-menu"></i>
                                </div>
                                <div class="setting-menu js-right-sidebar d-none d-lg-block">
                                    <div class="account-dropdown__body">
                                        <div class="account-dropdown__item">
                                            <a href="#">
                                                <i class="zmdi zmdi-account"></i>Account</a>
                                        </div>
                                        <div class="account-dropdown__item">
                                            <a href="#">
                                                <i class="zmdi zmdi-settings"></i>Setting</a>
                                        </div>
                                        <div class="account-dropdown__item">
                                            <a href="#">
                                                <i class="zmdi zmdi-money-box"></i>Billing</a>
                                        </div>
                                    </div>
                                    <div class="account-dropdown__body">
                                        <div class="account-dropdown__item">
                                            <a href="#">
                                                <i class="zmdi zmdi-globe"></i>Language</a>
                                        </div>
                                        <div class="account-dropdown__item">
                                            <a href="#">
                                                <i class="zmdi zmdi-pin"></i>Location</a>
                                        </div>
                                        <div class="account-dropdown__item">
                                            <a href="#">
                                                <i class="zmdi zmdi-email"></i>Email</a>
                                        </div>
                                        <div class="account-dropdown__item">
                                            <a href="#">
                                                <i class="zmdi zmdi-notifications"></i>Notifications</a>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </header>
            <aside class="menu-sidebar2 js-right-sidebar d-block d-lg-none">
                <div class="logo">
                    <a href="#">
                        <img src="images/icon/logo-white.png" alt="Cool Admin" />
                    </a>
                </div>
                <div class="menu-sidebar2__content js-scrollbar2">
                    <div class="account2">
                        <div class="image img-cir img-120">
                            <img src="images/icon/avatar-big-01.jpg" alt="John Doe" />
                        </div>
                        <h4 class="name">john doe</h4>
                        <a href="#">Sign out</a>
                    </div>
                    <nav class="navbar-sidebar2">
                        <ul class="list-unstyled navbar__list">
                            <li class="active has-sub">
                                <a class="js-arrow" href="#">
                                    <i class="fas fa-tachometer-alt"></i>Dashboard
                                    <span class="arrow">
                                        <i class="fas fa-angle-down"></i>
                                    </span>
                                </a>
                                <ul class="list-unstyled navbar__sub-list js-sub-list">
                                    <li>
                                        <a href="index.html">
                                            <i class="fas fa-tachometer-alt"></i>Dashboard 1</a>
                                    </li>
                                    <li>
                                        <a href="index2.html">
                                            <i class="fas fa-tachometer-alt"></i>Dashboard 2</a>
                                    </li>
                                    <li>
                                        <a href="index3.html">
                                            <i class="fas fa-tachometer-alt"></i>Dashboard 3</a>
                                    </li>
                                    <li>
                                        <a href="index4.html">
                                            <i class="fas fa-tachometer-alt"></i>Dashboard 4</a>
                                    </li>
                                </ul>
                            </li>
                            <li>
                                <a href="inbox.html">
                                    <i class="fas fa-chart-bar"></i>Inbox</a>
                                <span class="inbox-num">3</span>
                            </li>
                            <li>
                                <a href="#">
                                    <i class="fas fa-shopping-basket"></i>eCommerce</a>
                            </li>
                            <li class="has-sub">
                                <a class="js-arrow" href="#">
                                    <i class="fas fa-trophy"></i>Features
                                    <span class="arrow">
                                        <i class="fas fa-angle-down"></i>
                                    </span>
                                </a>
                                <ul class="list-unstyled navbar__sub-list js-sub-list">
                                    <li>
                                        <a href="table.html">
                                            <i class="fas fa-table"></i>Tables</a>
                                    </li>
                                    <li>
                                        <a href="form.html">
                                            <i class="far fa-check-square"></i>Forms</a>
                                    </li>
                                    <li>
                                        <a href="#">
                                            <i class="fas fa-calendar-alt"></i>Calendar</a>
                                    </li>
                                    <li>
                                        <a href="map.html">
                                            <i class="fas fa-map-marker-alt"></i>Maps</a>
                                    </li>
                                </ul>
                            </li>
                            <li class="has-sub">
                                <a class="js-arrow" href="#">
                                    <i class="fas fa-copy"></i>Pages
                                    <span class="arrow">
                                        <i class="fas fa-angle-down"></i>
                                    </span>
                                </a>
                                <ul class="list-unstyled navbar__sub-list js-sub-list">
                                    <li>
                                        <a href="login.html">
                                            <i class="fas fa-sign-in-alt"></i>Login</a>
                                    </li>
                                    <li>
                                        <a href="register.html">
                                            <i class="fas fa-user"></i>Register</a>
                                    </li>
                                    <li>
                                        <a href="forget-pass.html">
                                            <i class="fas fa-unlock-alt"></i>Forget Password</a>
                                    </li>
                                </ul>
                            </li>
                            <li class="has-sub">
                                <a class="js-arrow" href="#">
                                    <i class="fas fa-desktop"></i>UI Elements
                                    <span class="arrow">
                                        <i class="fas fa-angle-down"></i>
                                    </span>
                                </a>
                                <ul class="list-unstyled navbar__sub-list js-sub-list">
                                    <li>
                                        <a href="button.html">
                                            <i class="fab fa-flickr"></i>Button</a>
                                    </li>
                                    <li>
                                        <a href="badge.html">
                                            <i class="fas fa-comment-alt"></i>Badges</a>
                                    </li>
                                    <li>
                                        <a href="tab.html">
                                            <i class="far fa-window-maximize"></i>Tabs</a>
                                    </li>
                                    <li>
                                        <a href="card.html">
                                            <i class="far fa-id-card"></i>Cards</a>
                                    </li>
                                    <li>
                                        <a href="alert.html">
                                            <i class="far fa-bell"></i>Alerts</a>
                                    </li>
                                    <li>
                                        <a href="progress-bar.html">
                                            <i class="fas fa-tasks"></i>Progress Bars</a>
                                    </li>
                                    <li>
                                        <a href="modal.html">
                                            <i class="far fa-window-restore"></i>Modals</a>
                                    </li>
                                    <li>
                                        <a href="switch.html">
                                            <i class="fas fa-toggle-on"></i>Switchs</a>
                                    </li>
                                    <li>
                                        <a href="grid.html">
                                            <i class="fas fa-th-large"></i>Grids</a>
                                    </li>
                                    <li>
                                        <a href="fontawesome.html">
                                            <i class="fab fa-font-awesome"></i>FontAwesome</a>
                                    </li>
                                    <li>
                                        <a href="typo.html">
                                            <i class="fas fa-font"></i>Typography</a>
                                    </li>
                                </ul>
                            </li>
                        </ul>
                    </nav>
                </div>
            </aside>

            <!-- END HEADER DESKTOP-->




   <div class="main-content">
   <div class="container">
  <button type="button" class="btn btn-info btn-round" data-toggle="modal" data-target="#loginModal">
    Opciones de filtrado
  </button>  
</div>

<div class="modal fade" id="loginModal" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
    <div class="modal-dialog modal-lg">  
    <div class="modal-content">
      <div class="modal-header border-bottom-0">
        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
          <span aria-hidden="true">&times;</span>
        </button>
      </div>
      <div class="modal-body">
        <div class="form-title text-center">
          <h4>Opciones de filtrado</h4>
        </div>
        <div class="d-flex flex-column text-center">
          <form runat="server">
            <div class="form-group">              
                <asp:Label ID="lblFechaDesde" runat="server" Text="Indicar la fecha desde : "></asp:Label>
                <asp:TextBox ID="txtFechaDesde" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
            <div class="form-group">              
                <asp:Label ID="Label1" runat="server" Text="Indicar la fecha desde : "></asp:Label>
                <asp:TextBox ID="txtFechaHasta" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
              <div class="form-group">
                <asp:Label ID="lblComprobante" runat="server" Text="Selecciona el tipo de comprobante"></asp:Label>
                <asp:DropDownList ID="cboComprobantes" runat="server" CssClass="btn btn-info btn-block btn-round dropdown-toggle"></asp:DropDownList>                  
            </div>

              <div class="form-group">
                 <div style="OVERFLOW-Y:scroll; WIDTH:380px; HEIGHT:250px">
                     <div style="text-align:left">
                <asp:CheckBoxList ID="chkCuentas" runat="server"></asp:CheckBoxList>
                      </div>
                  </div>
              </div>

              <asp:Button ID="btnFiltrar" runat="server" Text="Filtrar" OnClick="btnFiltrar_Click" CssClass="btn btn-info btn-block btn-round"/>                    

          </form>

        </div>
      </div>
    </div>    
  </div>
</div>


     </div>





               




         <%--   <section>
            
            <div class="list-group">
                
       <!-- #region Lista de cuentas predeterminadas -->

  <a class="list-group-item list-group-item-action flex-column align-items-start active" data-toggle="modal" data-target="#ModalCuentasPredeterminadas">       
    <div class="d-flex w-100 justify-content-between">
      <h5 class="mb-1">Pruebas con cuentas</h5>
      <small>Open GL</small>
    </div>
    <p class="mb-1">Transacciones que afecten a una lista de cuentas determinadas</p>    
  </a>


  <div class="modal fade" id="ModalCuentasPredeterminadas" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
  <div class="modal-dialog" role="form">
      <form runat="server">
    <div class="modal-content">
      <div class="modal-header">
        <h5 class="modal-title" id="ModalCuentasPredeterminadasLabel">Opciones de filtrado</h5>
        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
          <span aria-hidden="true">&times;</span>
        </button>
      </div>
      <div class="modal-body">
          <table align="center">
       <tr>
            <td>
                <asp:Label ID="lblFechaDesde" runat="server" Text="Indicar la fecha desde : "></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtFechaDesde" runat="server"></asp:TextBox>
            </td>
        </tr>
    </table>

    <br />
    <br />

    <table align="center">
         <tr>
            <td>
                <asp:Label ID="lblFechaHasta" runat="server" Text="Indicar la fecha hasta : "></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtFechaHasta" runat="server"></asp:TextBox>
            </td>
        </tr>
    </table>

    <br />
    <br />

    <table align="center">        

        <tr>
            <td>
                <asp:Label ID="lblComprobante" runat="server" Text="Selecciona el tipo de comprobante"></asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="cboComprobantes" runat="server" CssClass="btn btn-primary btn-lg dropdown-toggle"></asp:DropDownList>
            </td>
        </tr>
    </table>

    <br />
    <br />

    <table align="center">
        <tr>
            <td>
                <asp:Label ID="lblCuentas" runat="server" Text="Seleccione los codigo de las cuentas deseados: "></asp:Label>
            </td>
            <td>
                <DIV style="OVERFLOW-Y:scroll; WIDTH:280px; HEIGHT:250px">
                <asp:CheckBoxList ID="chkCuentas" runat="server" TextAlign="Right"></asp:CheckBoxList>
                </DIV>                
            </td>       

            <td>
                <asp:Button ID="btnDesmarcar" runat="server" Text="Desmarcar todos" OnClick="btnDesmarcar_Click" CssClass="btn btn-primary btn-lg" />
            </td>
        </tr>
        
    </table>
    
      </div>
      <div class="modal-footer">
        <button type="button" class="btn btn-secondary" data-dismiss="modal">Atras</button>
          <asp:Button ID="btnFiltrar" runat="server" Text="Filtrar" OnClick="btnFiltrar_Click" CssClass="btn btn-primary btn-lg"/>        
      </div>
    </div>
      </form>
  </div>
</div>

       <!-- #endregion -->

            </div> <%--div del list group--%>


<%--</section>--%>

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
