<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ListAds.aspx.cs" Inherits="Sharefy_MDA.ListAds" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        .filterDiv {
            display: none;
        }

        .show {
            display: block;
        }
    </style>
    
    <script lang="javascript" type="text/javascript">
        function filterSelection() {
            var fDoors = document.getElementById("filterDoors");
            var fBrand = document.getElementById("filterBrand");
            var fType = document.getElementById("filterType");

            var doorOption = fDoors.options[fDoors.selectedIndex].value;
            var brandOption = fBrand.options[fBrand.selectedIndex].text;
            var typeOption = fType.options[fType.selectedIndex].text;

            var divList;
            divList = document.getElementsByClassName("filterDiv");
            if (doorOption == "Todo") doorOption = "";
            if (brandOption == "Todo") brandOption = "";
            if (typeOption == "Todo") typeOption = "";


            for (i = 0; i < divList.length; i++) {
                removeShowClass(divList[i], "show");
                if (divList[i].className.indexOf(doorOption) > -1 && divList[i].className.indexOf(brandOption) > -1 && divList[i].className.indexOf(typeOption) > -1) addShowClass(divList[i], "show");
            }

            return false;
        }

        function addShowClass(element, name) {
            var i, arr1, arr2;
            arr1 = element.className.split(" ");
            arr2 = name.split(" ");
            for (i = 0; i < arr2.length; i++) {
                if (arr1.indexOf(arr2[i]) == -1) { element.className += " " + arr2[i]; }
            }
        }

        function removeShowClass(element, name) {
            var i, arr1, arr2;
            arr1 = element.className.split(" ");
            arr2 = name.split(" ");
            for (i = 0; i < arr2.length; i++) {
                while (arr1.indexOf(arr2[i]) > -1) {
                    arr1.splice(arr1.indexOf(arr2[i]), 1);
                }
            }
            element.className = arr1.join(" ");
        }
    </script>

    <div class="input-group row mx-0 align-items-center justify-content-center my-5">
        <input class="form-control border-secondary py-2" type="search" id="searchWord" placeholder="Buscar" runat="server"/>
        <select class="form-control border-secondary py-2" id="CategorySelectInput" runat="server">
            <option>Marca</option>
            <option>Modelo</option>
            <option>Potencia</option>
            <option>Ciudad</option>
            <option>Tipo</option>
        </select>
        <div class="input-group-append">
            <asp:Button ID="searchButton" CssClass="btn btn-primary searchButton" Text="Buscar" runat="server" OnClick="search"/>
            <asp:Button ID="reset" CssClass="btn btn-primary searchButton" Text="Resetear" runat="server" OnClick="resetSearch"/>
        </div>
    </div>
    <div class="input-group row mx-0 align-items-center justify-content-center my-5">
        <p class="form-control border-secondary py-2">Puertas:</p>
        <select class="form-control border-secondary py-2" id="filterDoors">
            <option value="Todo">Todo</option>
            <option value="2puertas">2</option>
            <option value="3puertas">3</option>
            <option value="4puertas">4</option>
        </select>

        <p class="form-control border-secondary py-2">Marca:</p>
        <select class="form-control border-secondary py-2" id="filterBrand">
            <option>Todo</option>
            <option>Nissan</option>
            <option>Ranault</option>
            <option>Ford</option>
            <option>BMW</option>
            <option>Mercedes-AMG</option>
            <option>Mercedes-Benz</option>
            <option>VolksWagen</option>
            <option>Citroen</option>
        </select>

        <p class="form-control border-secondary py-2">Tipo:</p>
        <select class="form-control border-secondary py-2" id="filterType">
            <option>Todo</option>
            <option>Compacto</option>
            <option>Coupe</option>
            <option>Berlina</option>
            <option>Todoterreno</option>
            <option>Monovolumen</option>
            <option>Furgoneta</option>
        </select>
        <div class="input-group-append">
            <asp:Button ID="filterButton" CssClass="btn btn-primary searchButton" Text="Filtrar" runat="server" OnClientClick="return filterSelection();"/>
        </div>
    </div>
    
    <div ID="cards" runat="server" class="grid row ">
        
    </div>
</asp:Content>
