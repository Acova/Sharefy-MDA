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
                <asp:Button CssClass="btn btn-primary" type="button" ID="editButton" Text="Editar perfil" runat="server" OnClick="editUser" />
            </div>
        </div>     
    </div>
    <div class="row justify-content-md-center mb-2">
        <div class="col-auto">
            <a href="/ListCar" class="btn btn-primary searchButton"> Añadir anuncio</a>
        </div>
    </div>
    <h2 class="text-center">Lista de anuncios</h2>
    <div class="row grid" id="anuncios" runat="server">
        <asp:GridView 
            CssClass="table" 
            ID="AdGridViewData" 
            runat="server" 
            AutoGenerateColumns="false" 
            DataKeyNames="id" 
            OnRowCommand="AdGridViewData_RowCommand">
            <Columns>
                <asp:BoundField DataField="ID" HeaderText="ID" Visible="false" />
                <asp:BoundField DataField="Marca" HeaderText="Marca" />
                <asp:BoundField DataField="Matricula" HeaderText="Matricula" />
                <asp:BoundField DataField="Datos" HeaderText="Datos" />
                <asp:BoundField DataField="Inicio" HeaderText="Inicio" />
                <asp:BoundField DataField="Fin" HeaderText="Fin" />
                <asp:TemplateField HeaderText="Eliminar" SortExpression="">
                    <ItemTemplate>
                        <asp:LinkButton
                            CssClass="btn btn-danger"
                            ID="LinkButtonDeleteAdd"
                            runat="server"
                            CommandName="DeleteUser"
                            CommandArgument='<%#Eval("ID") %>'
                            OnClientClick="return confirm('¿Desea eliminar este anuncio?')">
                            Eliminar
                        </asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>

    <h2 class="text-center">Coches alquilados</h2>
    <div class="row justify-content-md-center mt-2 mb-2" id="alquileres" runat="server">
        <asp:GridView 
            CssClass="table" 
            ID="RentGridViewData" 
            runat="server" 
            AutoGenerateColumns="false" 
            DataKeyNames="id" 
            OnRowCommand="RentGridViewData_RowCommand">
            <Columns>
                <asp:BoundField DataField="ID" HeaderText="Código de alquiler" />
                <asp:BoundField DataField="Marca" HeaderText="Marca" />
                <asp:BoundField DataField="IDCoche" HeaderText="ID del coche" Visible="false"/>
                <asp:BoundField DataField="Inicio" HeaderText="Fecha de Inicio" />
                <asp:BoundField DataField="Fin" HeaderText="Fecha de fin" />
                <asp:TemplateField HeaderText="Cancelar" SortExpression="">
                    <ItemTemplate>
                        <asp:LinkButton
                            CssClass="btn btn-danger"
                            ID="LinkButtonDelete"
                            runat="server"
                            CommandName="DeleteUser"
                            CommandArgument='<%#Eval("ID") %>'
                            OnClientClick="return confirm('¿Desea cancelar este alquiler?')">
                            Cancelar
                        </asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
