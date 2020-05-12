<%@ Page Title="Contact" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="Sharefy_MDA.Contact" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
        <div class="createMenu">
        <div class="border rounded">
            <div class="mb-4"></div>
            <div class="row justify-content-md-center mb-2">
                <div class="col-lg-3">Nombre</div>
                <div class="col-lg-4">
                    <input id="nameInput" type="text" class="form-control row mx-0" placeholder="Nombre"
                           aria-describedby="Button1" runat="server"/>
                </div>
            </div>
            <div class="row justify-content-md-center mb-2">
                <div class="col-lg-3">Correo electrónico</div>
                <div class="col-lg-4">
                    <input id="mailInput" type="text" class="form-control row mx-0" placeholder="Email"
                           aria-describedby="Button1" runat="server" 
                           pattern="^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?(?:\.[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?)*$"
                           title="Debe ser un email válido"/>
                </div>
            </div>
            <div class="row justify-content-md-center mb-2">
                <div class="col-lg-7">
                    <div class="row mx-0">
                        <textarea class="form-control col-12" id="textArea"  runat="server" rows="3"></textarea>
                    </div>
                </div>  
            </div>
            <div class="row justify-content-md-center">
                <div class="col-auto">
                    <asp:Button CssClass="btn btn-primary searchButton" type="button" ID="Button3" Text="Enviar Mensaje" runat="server" OnClick="send"/>
                </div>
            </div>
        </div> 
    </div>
</asp:Content>
