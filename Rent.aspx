<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Rent.aspx.cs" Inherits="Sharefy_MDA.Rent" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <span id="priceToPay" runat="server">
    </span>
    <div class="row">
        <div class="col-sm-2">
            <asp:Button CssClass="btn btn-primary searchButton" type="button" ID="payButton" Text="Confirmar Pago" runat="server" OnClick="confirmPayment"/>
        </div>
        <div class="col-sm-2">
            <asp:Button CssClass="btn btn-primary searchButton" type="button" ID="cancel" Text="Cancelar" runat="server" OnClick="cancelPayment"/>
        </div>
    </div>

</asp:Content>
