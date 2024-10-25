<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="CRUD1.Sources.Pages.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <meta name="viewport" content="width=device-width, initial-scale=1.0"/>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-QWTKZyjpPEjISv5WaRU9OFeRpok6YctnYmDr5pNlyT2bRjXh0JMhjY6hW+ALEwIH" crossorigin="anonymous" />
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/js/bootstrap.bundle.min.js" integrity="sha384-YvpcrYf0tY3lHB60NNkmXc5s9fDVZLESaAA55NDzOxhy9GkcIdslK1eN7N6jIeHz" crossorigin="anonymous"></script>
    <title>Inicio de sesion </title>
</head>
<body>
    <br />
    <br />
    <br />
    <br />
    <form id="Login" runat="server" class="container d-flex justify-content-center align-items-center">
        <div class="col-5">
            <div class="form-control card card-body align-items-center">
                <div class="modal-title align-content-center h3">
                     <asp:Label runat="server" Text="Inicio de sesion" Font-Size="Large"></asp:Label>
                </div>
                            <br />
            <div class="input-group">
                <asp:TextBox runat="server" CssClass="form-control" placeholder="User" ID="tbUsuario"></asp:TextBox>
            </div>
            <br />
            <div class="input-group">
                <asp:TextBox runat="server" CssClass="form-control" placeholder="Password" TextMode="Password" ID="tbClave"></asp:TextBox>
            </div>
            <br />
            <div class="input-group">
                <asp:Button runat="server" CssClass="form-control btn btn-dark" Text="Login" OnClick="Iniciar"></asp:Button>
            </div>
            <br />
            <br />
            <div>
                <asp:Label runat="server" ID="lblError" class="alert-danger"></asp:Label>
                <br />
                <asp:Label runat="server" Text="No tienes cuenta!!! realiza tu registro"></asp:Label>
                <asp:LinkButton runat="server" Text="aqui" OnClick="Registrarse"></asp:LinkButton>
            </div>
        </div>
            </div>
    </form>
</body>
</html>

