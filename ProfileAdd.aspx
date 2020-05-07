<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ProfileAdd.aspx.cs" Inherits="Sharefy_MDA.ProfileAdd" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div id="success" class="alert alert-success" role="alert" runat="server">
    </div>

    <div id="fail" class="alert alert-danger" role="alert" runat="server">
    </div>


    <h2 class="display-3 text-center"> Crear perfil</h2>

    <div class="createMenu">
        <div class="border rounded">
            <div class="mb-4"></div>
            <div class="row justify-content-md-center mb-2">
                <div class="col col-lg-2">Nombre</div>
                <div class="col col-lg-2">
                    <input id="nameInput" type="text" class="form-control" placeholder="Nombre"
                           aria-describedby="Button1" runat="server" style="min-width: 100px;"/>
                </div>
            </div>

            <div class="row justify-content-md-center mb-2">
                <div class="col col-lg-2">Nombre de cuenta</div>
                <div class="col col-lg-2">
                    <input id="accountNameInput" type="text" class="form-control" placeholder="Nombre de cuenta"
                           aria-describedby="Button1" runat="server" style="min-width: 100px;"/>
                </div>
            </div>

            <div class="row justify-content-md-center mb-2">
                <div class="col col-lg-2">DNI</div>
                <div class="col col-lg-2">
                    <input id="dniInput" type="text" class="form-control" placeholder="DNI"
                           aria-describedby="Button1" runat="server" style="min-width: 100px;" pattern="^[0-9]{8,8}[A-Za-z]$" title="Debe ser un DNI válido"/>
                </div>
            </div>
            <div class="row justify-content-md-center mb-2">
                <div class="col col-lg-2">Nº de teléfono</div>
                <div class="col col-lg-2">
                    <input id="phoneInput" type="text" class="form-control" placeholder="Teléfono"
                           aria-describedby="Button1" runat="server" style="min-width: 100px;"
                           pattern="^(\+34|0034|34)?[6|7|8|9][0-9]{8}$"
                           title="Debe ser un número de teléfono válido"/>
                </div>
            </div>
            <div class="row justify-content-md-center mb-2">
                <div class="col col-lg-2">Correo electrónico</div>
                <div class="col col-lg-2">
                    <input id="mailInput" type="text" class="form-control" placeholder="Email"
                           aria-describedby="Button1" runat="server" style="min-width: 100px;"
                           pattern="^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?(?:\.[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?)*$"
                           title="Debe ser un email válido"/>
                </div>
            </div>
            <div class="row justify-content-md-center mb-2">
                <div class="col col-lg-2">Contraseña</div>
                <div class="col col-lg-2">
                    <input id="passwordInput" type="text" class="form-control" placeholder="Contraseña*"
                           aria-describedby="Button1" runat="server" style="min-width: 100px;"/>
                </div> 
            </div>
            <div class="form-check row mx-0 pb-3">
                  <asp:CheckBox ID="adminCheck" runat="server" Checked="false" class="form-check-input"/>
                  <label class="form-check-label" for="adminCheck">Solicitud de administrador</label>
            </div>

            <div class="row justify-content-md-center mb-2">
                <div class="col-auto">
                    <asp:Button CssClass="btn btn-primary searchButton" type="button" ID="Button2" Text="Confirmar" runat="server" OnClick="modify"/>
                </div>
            </div>
            <div class="row justify-content-md-center mb-2">
                <div class="col-auto">
                    <asp:Button CssClass="btn btn-primary searchButton" type="button" ID="Button3" Text="Cancelar" runat="server" OnClick="cancel"/>
                </div>
            </div>
            <div class="mb-4"></div>
        </div>
    </div>
</asp:Content>
