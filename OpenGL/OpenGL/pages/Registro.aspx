<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Registro.aspx.cs" Inherits="OpenGL.pages.Registro" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>

     <link href="../css/registro.css" rel="stylesheet" />
</head>
<body>
   
     <div class="sidenav">
         <div class="login-main-text">
            <h2>Crowe Howarth</h2>
            <p>Registrese aqui</p>
         </div>
      </div>
      <div class="main">
         <div class="col-md-6 col-sm-12">
            <div class="login-form">
               <form runat="server">

                  <div class="form-group">
                     <label> Ingrese nombre de usuario</label>
                    <asp:TextBox ID="txtUsername" runat="server" CssClass="form-control" placeholder="Nombre Usuario"></asp:TextBox>                     
                  </div>

                  <div class="form-group">
                     <label>Ingrese su Password</label>
                      <asp:TextBox ID="txtContraseña" runat="server" CssClass="form-control" placeholder="Contraseña"></asp:TextBox>                     
                  </div>       
                   
                    <div class="form-group">
                     <label>Ingrese su nombre y apellido</label>
                    <asp:TextBox ID="txtNombreApellido" runat="server" CssClass="form-control" placeholder="Nombre y apellido"></asp:TextBox>                     
                  </div>

                    <div class="form-group">
                     <label>Ingrese su email</label>
                    <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" placeholder="Email"></asp:TextBox>                     
                  </div>

                    <div class="form-group">
                     <label>Ingrese su cargo</label>
                    <asp:TextBox ID="txtCargo" runat="server" CssClass="form-control" placeholder="Cargo"></asp:TextBox>                     
                  </div>                 

                    <div class="form-group">
                     <label>Eliga si desea ser administrador</label>
                    <asp:DropDownList ID="cboAdministrador" runat="server">
                       <asp:ListItem Value="0">No</asp:ListItem>
                        <asp:ListItem Value="1">Si</asp:ListItem>
                    </asp:DropDownList>   
                  </div>



                    <asp:Button ID="btnRegistrar" class="btn" runat="server" Text="Register" BackColor="Yellow" OnClick="btnRegistrar_Click"/>                 
                   <asp:Button ID="btnAtras" class="btn btn-black" runat="server" Text="Atras" OnClick="btnAtras_Click"/>                 
               </form>
            </div>
         </div>
      </div>

    <asp:Label ID="lblMensaje" runat="server" Text=""></asp:Label>
   
<link href="//maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css" rel="stylesheet" id="bootstrap-css">
<script src="//maxcdn.bootstrapcdn.com/bootstrap/4.0.0/js/bootstrap.min.js"></script>
<script src="//code.jquery.com/jquery-1.11.1.min.js"></script>

</body>
</html>
