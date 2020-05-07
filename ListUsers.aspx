<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ListUsers.aspx.cs" Inherits="Sharefy_MDA.ListUsers" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="input-group row mx-0 align-items-center justify-content-center my-5">
        <input class="form-control border-secondary py-2" type="search" id="searchWord" placeholder="Buscar" runat="server"/>
        <select class="form-control border-secondary py-2" id="CategorySelectInput" runat="server">
            <option>ID</option>
            <option>Cuenta</option>
            <option>NombreCompleto</option>
            <option>DNI</option>
            <option>Tel</option>
            <option>Email</option>
            <option>Rol</option>
        </select>
        <div class="input-group-append">
            <asp:Button ID="searchButton" class="UserManagerbtn mx-3 btn" Text="Buscar" runat="server" OnClick="search"/>
            <asp:Button ID="reset" class="UserManagerbtn btn" Text="Resetear" runat="server" OnClick="resetSearch"/>
        </div>
    </div>
    <div class="row mx-0 justify-content-center">
        <asp:GridView CssClass="table thead-light table-hover my-2" ID="GridViewData" runat="server" AutoGenerateColumns="False" DataKeyNames="id" OnRowCommand="GridViewData_RowCommand">
            <Columns>
                <asp:BoundField DataField="ID" HeaderText="ID" />
                <asp:BoundField DataField="Cuenta" HeaderText="Cuenta" />
                <asp:BoundField DataField="Clave" HeaderText="Clave" />
                <asp:BoundField DataField="NombreCompleto" HeaderText="Nombre" />
                <asp:BoundField DataField="DNI" HeaderText="DNI" />
                <asp:BoundField DataField="Tel" HeaderText="Teléfono" />
                <asp:BoundField DataField="Email" HeaderText="Email" />
                <asp:BoundField DataField="Rol" HeaderText="Rol" />
                <asp:TemplateField HeaderText="Editar" SortExpression="">
                    <ItemTemplate>
                        <asp:LinkButton CssClass="btn UserManagerbtn" ID="LinkButtonEdit" runat="server" CommandName="EditUser" CommandArgument='<%#Eval("ID") %>'>Edit</asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Eliminar" SortExpression="">
                    <ItemTemplate>
                        <asp:LinkButton CssClass="btn btn-danger" ID="LinkButtonDelete" runat="server" CommandName="DeleteUser" CommandArgument='<%#Eval("ID") %>' OnClientClick="return confirm('¿Desea eliminar este usuario?')">X</asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>