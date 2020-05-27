﻿using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Web;
using System.Web.Services.Description;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Sharefy_MDA
{
    public partial class MessageDetail : System.Web.UI.Page
    {
        string messageID;
        int id;
        protected void Page_Load(object sender, EventArgs e)
        {
            messageID = Request.QueryString["message_id"];
            if(Session["id"] == null || messageID == null || !checkMessageUser())
            {
                Response.Redirect("/Default.aspx");
            }
            fetchMessageData();
        }

        protected void fetchMessageData()
        {
            var route = HttpContext.Current.Server.MapPath(@"\BDCoches.db");
            var connstring = "data source=" + route;

            using(var db = new SQLiteConnection(connstring))
            {
                db.Open();
                var cmd = new SQLiteCommand(
                    "SELECT Mensajes_Usuario.ID, Mensajes_Usuario.IDEmisor, Mensajes_Usuario.Titulo, Mensajes_Usuario.Cuerpo, Mensajes_Usuario.Fecha_envio, Mensajes_Usuario.Estado, Usuarios.Cuenta " +
                    "FROM Mensajes_Usuario " +
                    "INNER JOIN Usuarios ON Mensajes_Usuario.IDEmisor=Usuarios.ID " +
                    "WHERE Mensajes_Usuario.ID=" + messageID, db);
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    for(var i = 0; i < reader.FieldCount; i++)
                    {
                        if (!reader.IsDBNull(i))
                        {
                            if (reader.GetName(i).Equals("Cuenta"))
                            {
                                remitenteInput.Value = reader.GetString(i);
                            }
                            if (reader.GetName(i).Equals("Fecha_envio"))
                            {
                                fechaInput.Value = reader.GetString(i);
                            }
                            if (reader.GetName(i).Equals("Titulo"))
                            {
                                tituloInput.Value = reader.GetString(i);
                            }
                            if (reader.GetName(i).Equals("Cuerpo"))
                            {
                                contenidoInput.InnerText = reader.GetString(i);
                            }
                            if (reader.GetName(i).Equals("IDEmisor"))
                            {
                                id = reader.GetInt32(i);
                            }
                        }
                    }
                }
                db.Close();
            }
        }

        protected bool checkMessageUser()
        {
            var route = HttpContext.Current.Server.MapPath(@"\BDCoches.db");
            var connstring = "data source=" + route;

            using(var db = new SQLiteConnection(connstring))
            {
                db.Open();
                var cmd = new SQLiteCommand("SELECT IDEmisor, IDReceptor FROM Mensajes_Usuario WHERE ID=" + messageID, db);
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    for(var i = 0; i < reader.FieldCount; i++)
                    {
                        if (!reader.IsDBNull(i))
                        {
                            if(reader.GetInt32(i) == Int32.Parse(Session["id"].ToString()))
                            {
                                db.Close();
                                return true;
                            }
                        }
                    }
                }
                db.Close();
            }
            return false;
        }

        protected void showDialog(object sender, EventArgs e)
        {
            messageTitleLabel.Visible = true;
            messageTitleInput.Visible = true;
            messageBodyLabel.Visible = true;
            messageBodyInput.Visible = true;
            messageSubmitButton.Visible = true;
        }

        protected void sendMessage(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine(buildQuery());

            var route = HttpContext.Current.Server.MapPath(@"\BDcoches.db");
            var connstring = "data source=" + route;
            using (var db = new SQLiteConnection(connstring))
            {
                db.Open();
                var cmd = new SQLiteCommand(buildQuery(), db);
                cmd.ExecuteNonQuery();
                db.Close();
            }

            Response.Redirect("/UserMessages.aspx");
        }

        protected string buildQuery()
        {
            var str =
                "INSERT INTO Mensajes_Usuario (IDEmisor, IDReceptor, Titulo, Cuerpo, Fecha_envio, Estado) " +
                "values ("
                + "\"" + Session["id"] + "\", "
                + "\"" + id.ToString() + "\", "
                + "\"" + messageTitleInput.Value + "\", "
                + "\"" + messageBodyInput.Value + "\", "
                + "\"" + DateTime.Today.ToString("yyyy-MM-dd") + "\", "
                + "\"Enviado\"" + ")";
            return str;
        }
    }
}