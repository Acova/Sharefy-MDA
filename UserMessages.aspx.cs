﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Sharefy_MDA
{
    public partial class UserMessages : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Session["id"] == null)
            {
                Response.Redirect("~/Default.aspx");
            }
            fetchData();
        }

        protected void loadMessage(object sender, GridViewCommandEventArgs e)
        {

        }

        protected void fetchData()
        {
            var route = HttpContext.Current.Server.MapPath(@"\BDCoches.db");
            var connectionString = "data source=" + route;

            using(var db = new SQLiteConnection(connectionString))
            {
                db.Open();
                DataTable sentMessageDataTable = new DataTable();
                var cmd = new SQLiteCommand(
                    "SELECT Mensajes_Usuario.ID, Mensajes_Usuario.IDEmisor, Mensajes_Usuario.Titulo, Mensajes_Usuario.Cuerpo, Mensajes_Usuario.Fecha_envio, Mensajes_Usuario.Estado, Usuarios.Cuenta " +
                    "FROM Mensajes_Usuario " +
                    "INNER JOIN Usuarios ON Mensajes_Usuario.IDEmisor=Usuarios.ID " +
                    "WHERE Mensajes_Usuario.IDEmisor=" + Session["id"], db);
                cmd.CommandType = CommandType.Text;
                SQLiteDataAdapter sentMessageDataAdapter = new SQLiteDataAdapter(cmd);
                sentMessageDataAdapter.Fill(sentMessageDataTable);
                SentMessagesGridView.DataSource = sentMessageDataTable;
                SentMessagesGridView.DataBind();

                DataTable receivedMessageDataTable = new DataTable();
                cmd = new SQLiteCommand(
                    "SELECT Mensajes_Usuario.ID, Mensajes_Usuario.IDEmisor, Mensajes_Usuario.Titulo, Mensajes_Usuario.Cuerpo, Mensajes_Usuario.Fecha_envio, Mensajes_Usuario.Estado, Usuarios.Cuenta " +
                    "FROM Mensajes_Usuario " +
                    "INNER JOIN Usuarios ON Mensajes_Usuario.IDEmisor=Usuarios.ID " +
                    "WHERE Mensajes_Usuario.IDReceptor=" + Session["id"], db);
                cmd.CommandType = CommandType.Text;
                SQLiteDataAdapter receivedMessageDataAdapter = new SQLiteDataAdapter(cmd);
                receivedMessageDataAdapter.Fill(receivedMessageDataTable);
                ReceivedMessagesGridView.DataSource = receivedMessageDataTable;
                ReceivedMessagesGridView.DataBind();

                db.Close();
            }
        }
    }
}