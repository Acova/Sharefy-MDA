<%@ Page Title="Contact" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="Sharefy_MDA.Contact" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
        <div id="success" class="alert alert-success" role="alert" runat="server">
        </div>

    
        <div id="fail" class="alert alert-danger" role="alert" runat="server">
        </div>
        <div class="createMenu">
        <div class="border rounded">
            <div class="mb-4"></div>
            <div class="row mx-0 justify-content-md-center align-items-center mb-2">
                <label class="col-lg-3">Cuenta</label>
                <div class="col-lg-4">
                    <input id="accountInput" type="text" class="form-control row mx-0" placeholder="Indique su cuenta"
                           aria-describedby="Button1" runat="server"/>
                </div>
            </div>
            <div class="row mx-0 justify-content-md-center mb-2">
                <div class="col-lg-7">
                    <div class="row mx-0">
                        <textarea class="form-control col-12" id="textArea"  runat="server" rows="3"></textarea>
                    </div>
                </div>  
            </div>
            <div class="row mx-0 justify-content-start">
                <div class="col-lg-12 text-center">
                    <asp:Button CssClass="btn btn-primary searchButton" type="button" ID="Button3" Text="Enviar Mensaje" runat="server" OnClick="send"/>
                </div>
            </div>
        </div> 
    </div>
</asp:Content>
