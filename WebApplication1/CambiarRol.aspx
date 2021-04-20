<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CambiarRol.aspx.cs" Inherits="WebApplication1.CambiarRol" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
     <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.0.0-beta3/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-eOJMYsd53ii+scO/bJGFsiCZc+5NDVN2yr8+0RDqr0Ql0h+rP48ckxlpbzKgwra6" crossorigin="anonymous"/>
</head>
<body>
    
    <nav class="navbar navbar-dark bg-dark style="background-color: #e3f2fd;"">
      <div class="container-fluid">
        <span class="navbar-brand mb-0 h1">Cambiar Rol</span>
      </div>
    </nav>

    <form id="form1" runat="server">
        <div class=" container mt-3">
            <h1 > Cambiar el rol a <asp:Label ID="user" runat="server" Text="Label"></asp:Label></h1>
            <asp:TextBox ID="rol" CssClass="form-control" placeholder="ADMIN O USER" runat="server"></asp:TextBox>
            
            <div class="row mt-2" >
                <div class="col-md-2" >
                     <asp:Button ID="Cambiar" OnClientClick="false" CssClass="btn btn-primary " runat="server" Text="Cambiar Rol" OnClick="Cambiar_Click" />
                    
                </div>
                <div class="col-md-2" >
                
                     <asp:Button ID="regresar" CssClass="btn btn-danger " runat="server" Text="Cancelar" OnClick="regresar_Click" />
                </div>
            </div>
        
        </div>

    </form>


    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.0.0-beta3/dist/js/bootstrap.bundle.min.js" integrity="sha384-JEW9xMcG8R+pH31jmWH6WWP0WintQrMb4s7ZOdauHnUtxwoG2vI5DkLtS3qm9Ekf" crossorigin="anonymous"></script>
	<script src="https://cdn.jsdelivr.net/npm/@popperjs/core@2.9.1/dist/umd/popper.min.js" integrity="sha384-SR1sx49pcuLnqZUnnPwx6FCym0wLsk5JZuNx2bPPENzswTNFaQU1RDvt3wT4gWFG" crossorigin="anonymous"></script>
	<script src="https://cdn.jsdelivr.net/npm/bootstrap@5.0.0-beta3/dist/js/bootstrap.min.js" integrity="sha384-j0CNLUeiqtyaRmlzUHCPZ+Gy5fQu0dQ6eZ/xAww941Ai1SxSY+0EQqNXNE6DZiVc" crossorigin="anonymous"></script>
</body>
</html>
