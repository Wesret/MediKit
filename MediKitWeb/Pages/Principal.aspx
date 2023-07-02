<%@ Page Title="MediKit" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Principal.aspx.cs" Inherits="MediKitWeb.Pages.Principal" %>
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
                    <div class="container row">
                        <div class="table small">
                            <asp:GridView runat="server" ID="gdEquipos" class="table table-borderles table-hover">
                            </asp:GridView>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>
</asp:Content>
