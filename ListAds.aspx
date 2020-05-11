<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ListAds.aspx.cs" Inherits="Sharefy_MDA.ListAds" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="searchMenu">
        <div class="row justify-content-md-center">
            <div class="col-sm-6 offset-sm-3 text-center">
                <input id="carSearchInput" type="text" class="form-control" placeholder="Busca tu coche"
                       aria-describedby="Button1" runat="server" style="max-width: 500px;"/>
            </div>
            <div class="col-sm">
                <asp:Button CssClass="btn btn-primary searchButton" type="button" ID="Button1" Text="Buscar" runat="server" OnClick="search"/>
            </div>
        </div>
    </div>
    <div ID="cards" runat="server" class="grid row ">
        
    </div>
</asp:Content>
