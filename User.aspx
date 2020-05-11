<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="User.aspx.cs" Inherits="Sharefy_MDA.User" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2 class="text-center">Perfil de <%= Session["userName"] %></h2>

    <div class="justify-content-md-center">
        <div class="form-group row justify-content-md-center">
            <label for="nameInput" class="col-sm-2 col-form-label">Nombre de usuario:</label>
            <div class="col-sm-4">
                <input type="text" readonly class="form-control-plaintext" id="nameInput" runat="server"/>
            </div>
        </div>

        <div class="form-group row justify-content-md-center">
            <label for="realNameInput" class="col-sm-2 col-form-label">Nombre completo:</label>
            <div class="col-sm-4">
                <input type="text" readonly class="form-control-plaintext" id="realNameInput" runat="server"/>
            </div>
        </div>

        <div class="form-group row justify-content-md-center">
            <label for="dniInput" class="col-sm-2 col-form-label">DNI:</label>
            <div class="col-sm-4">
                <input type="text" readonly class="form-control-plaintext" id="dniInput" runat="server"/>
            </div>
        </div>

        <div class="form-group row justify-content-md-center">
            <label for="telInput" class="col-sm-2 col-form-label">Teléfono:</label>
            <div class="col-sm-4">
                <input type="text" readonly class="form-control-plaintext" id="telInput" runat="server"/>
            </div>
        </div>

        <div class="form-group row justify-content-md-center">
            <label for="emailInput" class="col-sm-2 col-form-label">Email:</label>
            <div class="col-sm-4">
                <input type="text" readonly class="form-control-plaintext" id="emailInput" runat="server"/>
            </div>
        </div>

        <div class="row justify-content-md-center mb-2">
                <div class="col-auto">
                    <asp:Button CssClass="btn btn-primary" type="button" ID="editButton" Text="Editar perfil" runat="server" OnClick="editUser"/>
                </div>
            </div>
    </div>
</asp:Content>
