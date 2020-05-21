<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AdProfile.aspx.cs" Inherits="Sharefy_MDA.AdProfile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div id="reportDone" class="alert alert-danger" role="alert" runat="server">
        Se ha reportado este anucio
    </div>
    <div id="needMoreData" class="alert alert-danger" role="alert" runat="server">
        No se han rellenado los campos necesarios para alquilar
    </div>

    <div class="row" ID="Car_data" runat="server"></div>

    <hr/>

    <div class="row justify-content-md-center mb-2">
        <div class="col-md-auto">
        </div>

    </div>

    <div class="row justify-content-md-center mb-2">

        <div class="col-md-3" id="userDateFrom">
            <p>Fecha Inicial: </p>
            <input class="form-control" id="dateF" pattern="[0-9]{2}/[0-9]{2}/[0-9]{4}" runat="server" style="margin: 2px"
                   title="La fecha tiene que tener el formato MM-dd-yyyy" type="date"/>
        </div>
    </div>

    <div class="row justify-content-md-center mb-2">
        <div class="col-md-3" id="userDateTo">
            <p>Fecha Final:</p>
            <input class="form-control" id="dateT" pattern="[0-9]{2}/[0-9]{2}/[0-9]{4}" runat="server" style="margin: 2px"
                   title="La fecha tiene que tener el formato MM-dd-yyyy" type="date"/>
        </div>
    </div>


    <div class="row justify-content-md-center mb-2">
        <div class="col-md-3" id="place-wrap">
            <p>Lugar de recogida:</p>
            <input class="form-control" id="place" required runat="server" style="margin: 2px"
                   title="Indique lugar de recogida" type="text"/>
        </div>
    </div>


    <div class="row justify-content-md-center mb-2">
        <div id="confirmRent" style="margin: 5px">
            <asp:Button CssClass="btn btn-primary searchButton" type="button" ID="rentButton" Text="Confirmar Alquiler" runat="server" OnClick="confirmRent"/>
        </div>
        <div style="margin: 5px">
            <asp:Button CssClass="btn btn-primary searchButton" type="button" ID="cancel" Text="Cancelar" runat="server" OnClick="cancelRent"/>
        </div>
        <div style="margin: 5px">
            <asp:Button CssClass="btn btn-secondary searchButton" type="button" ID="reportButton" Text="Reportar Anuncio" runat="server" OnClick="reportAd" OnClientClick="return confirm('¿Desea reportar este anuncio?')"/>
        </div>
        <div style="margin: 5px">
                    <asp:Button CssClass="btn btn-primary searchButton" type="button" ID="favButton" Text="Añadir a favoritos" runat="server" OnClick="addToFav"/>
            </div>
    </div>

</asp:Content>
