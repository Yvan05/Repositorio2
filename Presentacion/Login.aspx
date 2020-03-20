
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Presentacion.Login" %>



<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />

    <meta name="viewport" content="width=device-width, user-scalable=no, initial-scale=1.0, maximum-scale=1.0, minimum-scale=1.0" />

    <title>Acesso Al Sistema</title>
    <link rel="stylesheet" href="csslogin/css/main.css" />
    <link href="//maxcdn.bootstrapcdn.com/bootstrap/3.2.0/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="//cdnjs.cloudflare.com/ajax/libs/css/font-awesome/4.1.0/css/font-awesome.min.css" rel="stylesheet" type="text/css" />
    <link href="css/AdminLTE.css" rel="stylesheet" type="text/css" />

</head>
<body class="cover" style="background-image: url('http://localhost:2220/LoginImagen/LoginP.jpg'); width: 100%; height: 100%; position: absolute;">
    <div class="form-box" id="login-box">
        <form id="form1" runat="server">
            <div class="header bg-success bg-green-gradient">
                <asp:Label ID="Label1" runat="server" CssClass="text-lg-center" Text="LOGIN"></asp:Label>
            </div>
            <div class="body bg-gray">
                <div class="form-group">
                    <div class="input-group glyph-group">
                        <span class="input-group-addon">
                            <i class="glyphicon  glyphicon-user"></i>
                        </span>
                        <asp:TextBox runat="server" ID="txtUsuario" CssClass="form-control" placeholder="Ingrese Usuario" MaxLength="50" />

                    </div>
                    <asp:RequiredFieldValidator ID="rfvtxtUsuario" runat="server" ErrorMessage="*Campo Obligatorio" ForeColor="Red" ControlToValidate="txtUsuario"></asp:RequiredFieldValidator>
                </div>

                <div class="form-group">
                    <div class="input-group glyph-group">
                        <span class="input-group-addon">
                            <i class="glyphicon  glyphicon-lock"></i></span>
                        <asp:TextBox ID="txtClave" runat="server" CssClass="form-control" placeholder="Ingrese Clave" TextMode="Password"></asp:TextBox>
                    </div>
                    <asp:RequiredFieldValidator ID="rvftxtClave" runat="server" ErrorMessage="*Campo Obligatorio" ForeColor="Red" ControlToValidate="txtClave"></asp:RequiredFieldValidator>
                </div>

                <div class="form-group">
                    <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" CssClass="dropdown-toggle" Height="40px" Width="319px">
                        <asp:ListItem Value="alum">Alumno</asp:ListItem>
                        <asp:ListItem Value="docent">Docente</asp:ListItem>
                    </asp:DropDownList>

                </div>

            </div>
            <div class="footer bg-gray">
                <asp:Button ID="btnIngresar" runat="server" Text="Iniciar Session" CssClass="btn btn-success btn-block" OnClick="btnIngresar_Click1" />

            </div>
        </form>
    </div>
    <script src="//ajax.gooleapis.com/ajax/libs/jquery/2.1.1/jquery.min.js"></script>
    <script src="//maxcdn.bootstrapcdn.com/ajax/libs/bootstrap/3.2.0/bootstrap.min.js"></script>

</body>
</html>
