<%@ Page Title="MediKit" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Gestion.aspx.cs" Inherits="MediKitWeb.Pages.Mantenedor" %>
<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    MediKit
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="body" runat="server">
    <br />
    <div class="mx-auto" style="width:250px">
        <asp:Label runat="server" CssClass="h2" ID="lblTitulo">Gestión Equipos</asp:Label>
    </div>
    <form runat="server" class="h-100 d-flex align-items-center justify-content-center">
        <div>
            <div class="mb-3">
            <label class="form-label">Producto</label>
            <asp:TextBox runat="server" CssClass="form-control" ID="txtProducto"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvProducto" runat="server" ErrorMessage="Requerido" ControlToValidate="txtProducto" ForeColor="Red"></asp:RequiredFieldValidator>
        </div>
        <div class="mb-3">
            <label class="form-label">Marca</label>
            <asp:DropDownList runat="server" CssClass="form-control" ID="cboMarca"></asp:DropDownList>
            <br />
        </div>
        <div class="mb-3">
            <label class="form-label">Precio</label>
            <asp:TextBox runat="server" CssClass="form-control" ID="txtPrecio"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvPrecio" runat="server" ErrorMessage="Requerido" ControlToValidate="txtPrecio" ForeColor="Red"></asp:RequiredFieldValidator>
            <br />
        </div><div class="mb-3">
            <label class="form-label">Cantidad</label>
            <asp:TextBox runat="server" CssClass="form-control" ID="txtCantidad"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvCantidad" runat="server" ErrorMessage="Requerido" ForeColor="Red" ControlToValidate="txtCantidad"></asp:RequiredFieldValidator>
        </div><div class="mb-3">
            <label class="form-label">Lote</label>
            <asp:TextBox runat="server" CssClass="form-control" ID="txtLote"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvLote" runat="server" ErrorMessage="Requerido" ForeColor="Red" ControlToValidate="txtLote"></asp:RequiredFieldValidator>
        </div>
        <asp:Button runat="server" CssClass="btn btn-primary" ID="btnCreate" Text="Create" Visible="True" Onclick="btnCreate_Click"/>
        <asp:Label ID="lblMsg" runat="server"></asp:Label>
        </div>
    </form>
</asp:Content>
