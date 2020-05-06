<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Sharefy_MDA.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

     <h2 class="text-center">Iniciar sesión</h2>

    <hr />

    <div id="failText" class="alert alert-danger" role="alert" runat="server">

    </div> 

    <div id="successText" class="alert alert-danger" role="alert" runat="server">

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
                <div class="col-auto">
                    <asp:Button CssClass="btn btn-primary" type="button" ID="Button2" Text="Iniciar sesión" runat="server" OnClick="login"/>
                </div>
            </div>
        </div>
    </div>

</asp:Content>
