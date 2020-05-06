<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UserRegister.aspx.cs" Inherits="Sharefy_MDA.UserRegister" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">


    <h2 class="text-center">Registro de usuario</h2>

    <hr />

    <div id="failText" class="alert alert-danger" role="alert" runat="server">

    </div>

    <div class="menu">
        <div>
            <div class="row justify-content-md-center mb-2">
                <div class="col-lg-2">Nombre de usuario</div>
                <div class="col-lg-2">
                    <input
                        id="userNameInput"
                        type="text"
                        class="form-control"
                        placeholder="Usuario*"
                        aria-describedby="Button1"
                        runat="server"
                        style="min-width: 100px;" />
                </div>
            </div>
            <div class="row justify-content-md-center mb-2">
                <div class="col col-lg-2">Contraseña</div>
                <div class="col col-lg-2">
                    <input
                        id="passwordInput"
                        type="password"
                        class="form-control"
                        placeholder="Contraseña*"
                        aria-describedby="Button1"
                        runat="server"
                        style="min-width: 100px;" />
                </div>
            </div>
            <div class="row justify-content-md-center mb-2">
                <div class="col-lg-2">Nombre completo</div>
                <div class="col-lg-2">
                    <input
                        id="realNameInput"
                        type="text"
                        class="form-control"
                        placeholder="Nombre completo"
                        aria-describedby="Button1"
                        runat="server"
                        style="min-width: 100px;" />
                </div>
            </div>
            <div class="row justify-content-md-center mb-2">
                <div class="col col-lg-2">DNI</div>
                <div class="col col-lg-2">
                    <input
                        id="dniInput"
                        type="text"
                        class="form-control"
                        placeholder="DNI"
                        aria-describedby="Button1"
                        runat="server"
                        style="min-width: 100px;"
                        pattern="^[0-9]{8,8}[A-Za-z]$"
                        title="Debe ser un DNI válido" />
                </div>
            </div>
            <div class="row justify-content-md-center mb-2">
                <div class="col col-lg-2">Nº de teléfono</div>
                <div class="col col-lg-2">
                    <input
                        id="phoneNumberInput"
                        type="text"
                        class="form-control"
                        placeholder="Teléfono"
                        aria-describedby="Button1"
                        runat="server"
                        style="min-width: 100px;"
                        pattern="^(\+34|0034|34)?[6|7|8|9][0-9]{8}$"
                        title="Debe ser un número de teléfono válido" />
                </div>
            </div>
            <div class="row justify-content-md-center mb-2">
                <div class="col col-lg-2">Correo electrónico</div>
                <div class="col col-lg-2">
                    <input
                        id="mailInput"
                        type="text"
                        class="form-control"
                        placeholder="Email"
                        aria-describedby="Button1"
                        runat="server"
                        style="min-width: 100px;"
                        pattern="^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?(?:\.[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?)*$"
                        title="Debe ser un email válido" />
                </div>
            </div>
            <div class="row justify-content-md-center mb-2">
                <div class="col-auto">
                    <asp:Button CssClass="btn btn-primary" type="button" ID="Button2" Text="Crear usuario" runat="server" OnClick="create"/>
                </div>
            </div>
        </div>
    </div>
</asp:Content>