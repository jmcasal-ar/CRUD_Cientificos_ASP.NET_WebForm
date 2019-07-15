<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebFormCientificos.aspx.cs" Inherits="IntentoResolucion.WebFormCientificos" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            &nbsp;
            <asp:LinkButton ID="LinkButtonGuardar" runat="server" OnClick="LinkButtonGuardar_Click">Guardar</asp:LinkButton>
            &nbsp;
            <asp:LinkButton ID="LinkButtonCargarFicha" runat="server" OnClick="LinkButtonCargarFicha_Click">Cargar Ficha por Id</asp:LinkButton>
            &nbsp;
            <asp:LinkButton ID="LinkButtonEliminar" runat="server" OnClick="LinkButtonEliminar_Click">Eliminar por Id</asp:LinkButton>
            &nbsp;
            <asp:LinkButton ID="LinkButtonBuscarporApellido" runat="server" OnClick="LinkButtonBuscarporApellido_Click">Buscar por Apellido</asp:LinkButton>
            &nbsp;
            <asp:LinkButton ID="LinkButtonInicializarConSad" runat="server" OnClick="LinkButtonInicializarConSad_Click">Inicializar con (Sadosky, Balseiro)</asp:LinkButton>
            &nbsp;
            <asp:LinkButton ID="LinkButtonRenumerarId" runat="server" OnClick="LinkButtonRenumerarId_Click">Renumerar por Id</asp:LinkButton>
            &nbsp;
            <asp:LinkButton ID="LinkButtonDepurarApellido" runat="server" OnClick="LinkButtonDepurarApellido_Click">Depurar por Apellido</asp:LinkButton>
            &nbsp;
            <asp:LinkButton ID="LinkButtonOrdenarApellido" runat="server" OnClick="LinkButtonOrdenarApellido_Click">Ordenar por Apellido</asp:LinkButton>
            <br />
            
            <br />

            <table>
                <tr>
                    <td>
                        Id:
                    </td>
                    <td>
                        <asp:TextBox ID="TextBoxId" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        Apellido:
                    </td>
                    <td>
                        <asp:TextBox ID="TextBoxApellido" runat="server"></asp:TextBox>
                    </td>
                </tr>
            </table>
            <asp:GridView ID="GridViewListado" runat="server"></asp:GridView>

            <h1>Casal,Juan Manuel</h1>
        </div>
    </form>
</body>
</html>
