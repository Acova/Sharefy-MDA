<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UserMessages.aspx.cs" Inherits="Sharefy_MDA.UserMessages" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2 class="text-center mb-2">Listado de mensajes enviados por <%= Session["userName"] %></h2>
    <div class="row grid justify-content-md-center" id="sentMessages" runat="server">
        <asp:GridView
            CssClass="table"
            ID="SentMessagesGridView"
            runat="server"
            AutoGenerateColumns="false"
            DataKeyNames="id"
            OnRowCommand="loadMessage"
            >
            <Columns>
                <asp:BoundField DataField="ID" HeaderText="ID" Visible="false" />
                <asp:BoundField DataField="Cuenta" HeaderText="Emisor" />
                <asp:BoundField DataField="Titulo" HeaderText="Título" />
                <asp:BoundField DataField="Fecha_envio" HeaderText="Fecha de envío" />
                <asp:BoundField DataField="Estado" HeaderText="Estado" />
                <asp:TemplateField HeaderText="Ver Mensaje" SortExpression="">
                    <ItemTemplate> 
                        <asp:LinkButton
                            CssClass="btn btn-primary"
                            ID="LinkButtonSeeSentMessage"
                            runat="server"
                            CommandName="SeeSentMessage"
                            CommandArgument='<%#Eval("ID") %>'
                            >Ver mensaje 
                        </asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>

    <h2 class="text-center mb-2">Listado de mensajes recibidos por <%= Session["userName"] %></h2>
    <div class="row grid justify-content-md-center" id="receivedMessages" runat="server">
        <asp:GridView
            CssClass="table"
            ID="ReceivedMessagesGridView"
            runat="server"
            AutoGenerateColumns="false"
            DataKeyNames="id"
            OnRowCommand="loadMessage"
            >
            <Columns>
                <asp:BoundField DataField="ID" HeaderText="ID" Visible="false" />
                <asp:BoundField DataField="Cuenta" HeaderText="Emisor" />
                <asp:BoundField DataField="Titulo" HeaderText="Título" />
                <asp:BoundField DataField="Fecha_envio" HeaderText="Fecha de envío" />
                <asp:BoundField DataField="Estado" HeaderText="Estado" />
                <asp:TemplateField HeaderText="Ver Mensaje" SortExpression="">
                    <ItemTemplate>
                        <asp:LinkButton
                            CssClass="btn btn-primary"
                            ID="LinkButtonSeeMessage"
                            runat="server"
                            CommandName="SeeReceivedMessage"
                            CommandArgument='<%#Eval("ID") %>'
                            >Ver mensaje 
                        </asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>