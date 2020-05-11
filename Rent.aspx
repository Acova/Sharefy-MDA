<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Rent.aspx.cs" Inherits="Sharefy_MDA.Rent" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <span id="priceToPay" runat="server">
    </span>
    <div class="row">
        <div class="col-sm-2">Modo de Pago</div>
        <div class="col-zm-2">
            <select id="payModeSelect" runat="server" onserverchange="showForm">
                <option value="paypal">Paypal</option>
                <option value="bankcard">Tarjeta Bancaria</option>
            </select>
        </div>
    </div>
    <p/>
    <div id="paypal" runat="server">
        <div class="row">
            <div class="col-sm-2">Email: </div>
            <div class="col-ms-2">
                <input id="emailField" type="text" class="form-control" runat="server"/>
            </div>
            <div class="col-sm-2">Contraseña: </div>
            <div class="col-ms-2">
                <input id="pass" type="password" class="form-control" runat="server"/>
            </div>
        </div>
    </div>
    <p/>
    <div id="creditCard" runat="server">
        <div class="row">
            <div class="col-sm-2">Número de Tarjeta: </div>
            <div class="col-sm-2">
                <input id="Number1" type="text" maxlength="4" minlength="4" class="form-control" runat="server"/>
            </div>
            <div class="col-sm-2">
                <input id="Number2" type="text" maxlength="4" minlength="4" class="form-control" runat="server"/>
            </div>
            <div class="col-sm-2">
                <input id="Number3" type="text" maxlength="4" minlength="4" class="form-control" runat="server"/>
            </div>
            <div class="col-sm-2">
                <input id="Number4" type="text" maxlength="4" minlength="4" class="form-control" runat="server"/>
            </div>
        </div>
        <div class="row">
            <div class="col-sm-2">CVC: </div>
            <div class="col-sm-2">
                <input id="cvc" type="text" class="form-control" maxlength="3" runat="server"/>
            </div>
            <div class="col-sm-2">Fecha Cad. Tarjeta: </div>
            <div class="col-sm-2">
                <input id="expDate" type="text" class="form-control" runat="server" placeholder="mm/yyyy"/>
            </div>
        </div>
    </div>
    <div class="row">
        <div class="col-sm-2">
            <asp:Button CssClass="btn btn-primary searchButton" type="button" ID="payButton" Text="Confirmar Pago" runat="server" OnClick="confirmPayment"/>
        </div>
        <div class="col-sm-2">
            <asp:Button CssClass="btn btn-primary searchButton" type="button" ID="cancel" Text="Cancelar" runat="server" OnClick="cancelPayment"/>
        </div>
    </div>
    <div id="fail" class="alert alert-danger" role="alert" runat="server">
        No ha completado todos los campos.
    </div>

</asp:Content>
