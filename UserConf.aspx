<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UserConf.aspx.cs" Inherits="Sharefy_MDA.UserConf" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2 class="text-center">Configuración del perfil</h2>

    <div id="failText" class="alert alert-danger" role="alert" runat="server">

    </div> 

    <div class="justify-content-md-center">
        <div class="form-group row justify-content-md-center">
            <label for="nameInput" class="col-sm-2 col-form-label">Nombre de usuario:</label>
            <div class="col-sm-4">
                <input type="text" class="form-control" id="nameInput" runat="server"/>
            </div>
        </div>

        <div class="form-group row justify-content-md-center">
            <label for="passwordInput" class="col-sm-2 col-form-label">Nueva contraseña:</label>
            <div class="col-sm-4">
                <input type="password" class="form-control" id="passwordInput" runat="server"/>
            </div>
        </div>

        <div class="form-group row justify-content-md-center">
            <label for="realNameInput" class="col-sm-2 col-form-label">Nombre completo:</label>
            <div class="col-sm-4">
                <input type="text" class="form-control" id="realNameInput" runat="server"/>
            </div>
        </div>

        <div class="form-group row justify-content-md-center">
            <label for="dniInput" class="col-sm-2 col-form-label">DNI:</label>
            <div class="col-sm-4">
                <input type="text" class="form-control" id="dniInput" runat="server"/>
            </div>
        </div>

        <div class="form-group row justify-content-md-center">
            <label for="telInput" class="col-sm-2 col-form-label">Teléfono:</label>
            <div class="col-sm-4">
                <input type="text" class="form-control" id="telInput" runat="server"/>
            </div>
        </div>

        <div class="form-group row justify-content-md-center">
            <label for="emailInput" class="col-sm-2 col-form-label">Email:</label>
            <div class="col-sm-4">
                <input type="text" class="form-control" id="emailInput" runat="server"/>
            </div>
        </div>

        <div class="row justify-content-md-center mb-2">
            <div class="col-auto">
                <asp:Button CssClass="btn btn-primary" type="button" ID="confirmButton" Text="Guardar" runat="server" OnClick="saveChanges" />
            </div>
            <div class="col-auto">
                <asp:Button CssClass="btn btn-danger" type="button" ID="cancelButton" Text="Cancelar" runat="server" OnClick="cancel" />
            </div>
        </div>
    </div>
</asp:Content>
