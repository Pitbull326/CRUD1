<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Registro.aspx.cs" Inherits="CRUD1.Source.Pages.Registro" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <meta name="viewport" content="width=device-width, initial-scale=1.0"/>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-QWTKZyjpPEjISv5WaRU9OFeRpok6YctnYmDr5pNlyT2bRjXh0JMhjY6hW+ALEwIH" crossorigin="anonymous" />
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/js/bootstrap.bundle.min.js" integrity="sha384-YvpcrYf0tY3lHB60NNkmXc5s9fDVZLESaAA55NDzOxhy9GkcIdslK1eN7N6jIeHz" crossorigin="anonymous"></script>
    <script src="../JavaScript/JavaScript.js"></script>
    <title>Registro de Usuarios</title>
</head>
<body>
    <form id="Registro" runat="server">
        <div class="container d-flex justify-content-center">
            <div class=" col-8">
                <div class="form-control card card-body">
                    <div class=" row justify-content-center">
                        <asp:Label runat="server" CssClass="row justify-content-center h3">Registro de usuarios</asp:Label>
                    </div>
                    <fieldset>
                        <legend class=" row justify-content-center">Datos personales</legend>
                        <div class=" input-group">
                            <asp:Label ID="Label1" CssClass="form-control" runat="server" Text="Nombres:"></asp:Label>
                            <asp:TextBox ID="tbNombre" CssClass="form-control" runat="server" placeholder="Escribe tu nombre"></asp:TextBox>
                        </div>
                        <br />
                        <div class=" input-group">
                            <asp:Label ID="Label2" CssClass="form-control" runat="server" Text="Apellidos:"></asp:Label>
                            <asp:TextBox ID="tbApellido" CssClass="form-control" runat="server" placeholder="Escribe tu apellido"></asp:TextBox>
                        </div>
                        <br />
                        <div class=" input-group">
                            <asp:Label ID="Label3" CssClass="form-control" runat="server" Text="Fecha de nacimiento:"></asp:Label>
                            <asp:TextBox ID="tbFecha" CssClass="form-control" runat="server" textmode="Date"></asp:TextBox>
                        </div>
                    </fieldset>
                    <br />
                    <fieldset>
                        <legend class="row justify-content-center">Datos de inicio de sesion</legend>
                        <div class=" input-group">
                            <asp:Label ID="Label4" CssClass="form-control" runat="server" Text="Usuario:"></asp:Label>
                            <asp:TextBox ID="tbUsuario" CssClass="form-control" runat="server" placeholder="Escribe el usuario"></asp:TextBox>
                        </div>
                        <br />
                        <div class=" input-group">
                            <asp:Label ID="Label5" CssClass="form-control" runat="server" Text="Clave:"></asp:Label>
                            <asp:TextBox ID="tbClave" CssClass="form-control" runat="server"  TextMode="Password" placeholder="Password"></asp:TextBox>
                        </div>
                        <br />
                        <div class=" input-group">
                            <asp:Label ID="Label6" CssClass="form-control" runat="server" Text="Repetir clave:"></asp:Label>
                            <asp:TextBox ID="tbClave2" CssClass="form-control" runat="server" placeholder="Password Again" TextMode="Password"></asp:TextBox>
                        </div>
                        <br />
                        <div>
                            <asp:Image runat="server" CssClass="img-thumbnail" Width="150" Height="150" ImageUrl="~/Sources/Images/usuario.jpg" />
                        </div>
                        <div class="row justify-content-center">
                            <asp:FileUpload runat="server" CssClass="small form-control" ID="FUImage" onchange="mostrarimagen(this)" />
                        </div>
                    </fieldset>
                    <br />
                    <asp:Label runat="server" CssClass="alert-danger" ID="lblError"></asp:Label> 
                    <br />
                    <div class="row">
                        <asp:Button runat="server" CssClass="form-control btn btn-success" text="Completar registro" OnClick="Registrar" />
                        <hr />
                        <asp:Button runat="server" CssClass="form-control btn btn-warning" Text="Cancelar" OnClick="Cancelar" />

                    </div>
                </div>

            </div>
        </div>
    </form>
</body>
</html>
