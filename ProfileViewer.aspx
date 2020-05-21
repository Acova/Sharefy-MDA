<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ProfileViewer.aspx.cs" Inherits="Sharefy_MDA.ProfileViewer" %>


<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h2 class="display-3 text-center"> Datos de perfil</h2>

    <div class="createMenu">
        <div class="border rounded">
            <div class="mb-4"></div>
            <div class="row justify-content-md-center mb-2">
                <div class="col col-lg-2">Nombre</div>
                <div class="col col-lg-2">
                    <input id="nameInput" readonly type="text" class="form-control" placeholder="Nombre"
                           aria-describedby="Button1" runat="server" style="min-width: 100px;"/>
                </div>
            </div>
            <div class="row justify-content-md-center mb-2">
                <div class="col col-lg-2">DNI</div>
                <div class="col col-lg-2">
                    <input id="dniInput" readonly type="text" class="form-control" placeholder="DNI"
                           aria-describedby="Button1" runat="server" style="min-width: 100px;" pattern="^[0-9]{8,8}[A-Za-z]$" title="Debe ser un DNI válido"/>
                </div>
            </div>
            <div class="row justify-content-md-center mb-2">
                <div class="col col-lg-2">Nº de teléfono</div>
                <div class="col col-lg-2">
                    <input id="phoneInput" readonly type="text" class="form-control" placeholder="Teléfono"
                           aria-describedby="Button1" runat="server" style="min-width: 100px;"
                           pattern="^(\+34|0034|34)?[6|7|8|9][0-9]{8}$"
                           title="Debe ser un número de teléfono válido"/>
                </div>
            </div>
            <div class="row justify-content-md-center mb-2">
                <div class="col col-lg-2">Correo electrónico</div>
                <div class="col col-lg-2">
                    <input id="mailInput" readonly type="text" class="form-control" placeholder="Email"
                           aria-describedby="Button1" runat="server" style="min-width: 100px;"
                           pattern="^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?(?:\.[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?)*$"
                           title="Debe ser un email válido"/>
                </div>
            </div>
            <div class="row justify-content-md-center mb-2">
                <div class="col col-lg-2">Contraseña</div>
                <div class="col col-lg-2">
                    <input id="passwordInput" readonly type="text" class="form-control" placeholder="Contraseña*"
                           aria-describedby="Button1" runat="server" style="min-width: 100px;"/>
                </div> 
            </div>
            <div class="row justify-content-md-center mb-2">
                <div class="col-auto">
                    <asp:Button CssClass="btn btn-primary searchButton" type="button" ID="Button3" Text="Atrás" runat="server" OnClick="cancel"/>
                </div>
            </div>
            <div class="mb-4"></div>
        </div>
    </div>
</asp:Content>
