<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MessageDetail.aspx.cs" Inherits="Sharefy_MDA.MessageDetail" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="justify-content-md-center">
        <div class="form-group row justify-content-md-center">
            <label for="nameInput" class="col-sm-2 col-form-label">Remitente:</label>
            <div class="col-sm-4">
                <input type="text" readonly class="form-control-plaintext" id="remitenteInput" runat="server"/>
            </div>
        </div>

        <div class="form-group row justify-content-md-center">
            <label for="nameInput" class="col-sm-2 col-form-label">Fecha de envío:</label>
            <div class="col-sm-4">
                <input type="text" readonly class="form-control-plaintext" id="fechaInput" runat="server"/>
            </div>
        </div>

        <div class="form-group row justify-content-md-center">
            <label for="nameInput" class="col-sm-2 col-form-label">Título:</label>
            <div class="col-sm-4">
                <input type="text" readonly class="form-control-plaintext" id="tituloInput" runat="server"/>
            </div>
        </div>

        <br />

        <div class="row justify-content-md-center h-100">
            <pre id="contenidoInput" runat="server"></pre>
        </div>

        <div class="row justify-content-md-center mb-2">
            <asp:Button CssClass="btn btn-primary" type="button" OnClick="showDialog" ID="contactButton" Text='Responder' runat="server"/>
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

    </div>
</asp:Content>
