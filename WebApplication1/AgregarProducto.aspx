<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AgregarProducto.aspx.cs" Inherits="WebApplication1.AgregarProducto" %>

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
        <span class="navbar-brand mb-0 h1">Agregar Producto</span>
      </div>
    </nav>


    <div class="row mt-4 container" >
        <div class="col-md-12" >

            
            <form id="form1" runat="server">
                <div class="form-group" >

                    <label>Nombre Producto</label>
                    <asp:TextBox ID="nombre" CssClass="form-control" runat="server"></asp:TextBox>

                </div>
                <div class="form-group" >

                    <label>Disponibles</label>
                    <asp:TextBox ID="stock" CssClass="form-control" TextMode="Number" runat="server"></asp:TextBox>

                </div>
                <div class="form-group" >

                    <label>Precio</label>
                    <asp:TextBox ID="precio" CssClass="form-control" runat="server"></asp:TextBox>

                </div>
                <div class="form-group" >

                    <label>Descripción</label>
                    <asp:TextBox ID="desc" CssClass="form-control" TextMode="MultiLine" runat="server"></asp:TextBox>

                </div>
                
                <asp:Button ID="Guardar" CssClass="btn btn-primary form-control mt-3" runat="server" Text="Guardar" OnClick="Guardar_Click" />
                <a href="Aministrador.aspx" class="btn btn-danger form-control mt-3">Cancelar</a>

            </form>
        </div>
    </div>

    <div class="row mt-3" >
        <div class="col-md-6" >
        </div>
        <div class="col-md-6" >
        </div>
    </div>



    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.0.0-beta3/dist/js/bootstrap.bundle.min.js" integrity="sha384-JEW9xMcG8R+pH31jmWH6WWP0WintQrMb4s7ZOdauHnUtxwoG2vI5DkLtS3qm9Ekf" crossorigin="anonymous"></script>
	<script src="https://cdn.jsdelivr.net/npm/@popperjs/core@2.9.1/dist/umd/popper.min.js" integrity="sha384-SR1sx49pcuLnqZUnnPwx6FCym0wLsk5JZuNx2bPPENzswTNFaQU1RDvt3wT4gWFG" crossorigin="anonymous"></script>
	<script src="https://cdn.jsdelivr.net/npm/bootstrap@5.0.0-beta3/dist/js/bootstrap.min.js" integrity="sha384-j0CNLUeiqtyaRmlzUHCPZ+Gy5fQu0dQ6eZ/xAww941Ai1SxSY+0EQqNXNE6DZiVc" crossorigin="anonymous"></script>
</body>
</html>
