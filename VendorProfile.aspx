<%@ Page Title="Perfil" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="VendorProfile.aspx.cs" Inherits="Sharefy_MDA.VendorProfile" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="justify-content-md-center mb-2 border rounded">
        <p style="margin: 5px">Nombre: <%= Session["profileName"] %> <br/></p>
        <p style="margin: 5px">Teléfono: <%= Session["profileTel"] %> <br/> </p>
        <p style="margin: 5px">Email: <%= Session["profileEmail"] %> <br/></p>
        
    </div>
    <div>
        <div class="text-center">
            Lista de anuncios
            <div ID="carsList" runat="server" class="row"></div>
        </div>
    </div>

</asp:Content>

