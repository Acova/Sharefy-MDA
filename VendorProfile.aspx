<%@ Page Title="Perfil" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="VendorProfile.aspx.cs" Inherits="Sharefy_MDA.VendorProfile" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="justify-content-md-center mb-2 border rounded">
        <p style="margin: 5px">Nombre: <%= Session["profileName"] %> <br/></p>
        <p style="margin: 5px">Teléfono: <%= Session["profileTel"] %> <br/> </p>
        <p style="margin: 5px">Email: <%= Session["profileEmail"] %> <br/></p>       
    </div>

    <div class="row justify-content-md-center mb-2">
        <asp:Button CssClass="btn btn-primary" type="button" OnClick="showDialog" ID="contactButton" Text='Contactar con el vendedor' runat="server"/>
    </div>

    <div class="row justify-content-md-center mb-2">
        <h5 id="messageTitleLabel" runat="server" visible="false">Título del mensaje</h5>
        <input 
            id="messageTitleInput"
            type="text"
            class="form-control mx-2"
            placeholder="Título"
            runat="server"
            visible="false"
            required />
    </div>

    <div class="row justify-content-md-center mb-2">
        <h5 id="messageBodyLabel" runat="server" visible="false">Contenido del mensaje</h5>
    </div>

    <div class="row justify-content-md-center mb-2">
        <textarea style="max-width: none" rows="10" cols="60" id="messageBodyInput" runat="server" visible="false" required />
    </div>

    <div class="row justify-content-md-center mb-2">
        <asp:Button CssClass="btn btn-info" type="button" OnClick="sendMessage" ID="messageSubmitButton" Text='Enviar' runat="server" Visible="false" />
    </div>
    
    <div>
        <div class="text-center">
            Lista de anuncios
            <div ID="carsList" runat="server" class="row"></div>
        </div>
    </div>

</asp:Content>

