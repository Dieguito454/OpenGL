<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AltaUsuario.aspx.cs" Inherits="OpenGL.pages.AltaUsuario" %>

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
        <div>
            <div class="container">
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
                                    <label>Nombre de usuario</label>
                                     <asp:TextBox ID="txtUsername" runat="server" CssClass="au-input au-input--full"></asp:TextBox>                                    
                                </div>
                                <div class="form-group">
                                    <label>Password</label>                                    
                                    <asp:TextBox ID="txtContraseña" runat="server" type="password"  CssClass="form-control"></asp:TextBox>                     
                                </div>
                                <div class="form-group">
                                    <label>Nombre y apellido</label>                                    
                                    <asp:TextBox ID="txtNombreApellido" runat="server" CssClass="form-control"></asp:TextBox>                     
                                </div>
                                 <div class="form-group">
                                    <label>Email</label>                                    
                                    <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control"></asp:TextBox>                     
                                </div>
                                <div class="form-group">
                                    <label>Cargo</label>                                    
                                    <asp:TextBox ID="txtCargo" runat="server" CssClass="form-control"></asp:TextBox>                     
                                </div>
                                <div class="form-group">
                                    <label>Es Administrador: </label>                                    
                                     <asp:DropDownList ID="cboAdministrador" runat="server">
                                           <asp:ListItem Value="0">No</asp:ListItem>
                                            <asp:ListItem Value="1">Si</asp:ListItem>
                                    </asp:DropDownList> 
                                </div>
                                <asp:Label ID="lblMensaje" runat="server" Text="Ingresar datos faltantes" ForeColor="Red"></asp:Label>
                                <asp:Button ID="btnCargarUsuario" CssClass="au-btn au-btn--block au-btn--green m-b-20" runat="server" Text="Registrar" OnClick="btnCargarUsuario_Click"  />                        
                            </form>
                            <div>
                                
                            </div>                   
                        </div>
                    </div>
                </div>
            </div>
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

    <!-- Main JS-->
    <script src="../js/main.js"></script>
   
</body>
</html>
