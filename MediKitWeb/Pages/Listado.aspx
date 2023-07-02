<%@ Page Title="MediKit" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Listado.aspx.cs" Inherits="MediKitWeb.Pages.Listado" %>
<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    MediKit
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="body" runat="server">
    <form runat="server">
        <br />
        <div class="mx-auto" style="width:300px">
            <h2>Listado de Equipos</h2>
        </div>
        <br />
        <div class="container">
            <div class="row">
                <div class="col align-self-end">
                    <br />
                    <asp:DropDownList ID="cboMarca" runat="server" AutoPostBack="True">
                    </asp:DropDownList>
                    <asp:Button runat="server" ID="BtnFiltrar" Text="Filter" OnClick="BtnFiltrar_Click"/>
                    <asp:Button runat="server" ID="BtnRefrescar" Text="Refresh" OnClick="BtnRefrescar_Click"/>
                    <br />
                    <div class="container row">
                        <div class="table small">
                            <asp:GridView runat="server" ID="gdEquipos" class="table table-borderles table-hover">
                                <Columns>
                                    <asp:TemplateField HeaderText="Options">
                                        <ItemTemplate>
                                            <asp:Button runat="server" Text="Update" CssClass="btn form-control btn-info small" ID="btnUpdate" OnClick="btnUpdate_Click"/>
                                            <asp:Button runat="server" Text="Delete" CssClass="btn form-control btn-danger small" ID="btnDelete" OnClick="btnDelete_Click"/>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>
</asp:Content>
