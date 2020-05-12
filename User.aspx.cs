using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace Sharefy_MDA
{
    public partial class User : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Session["id"] == null)
            {
                Response.Redirect("~/Default.aspx");
            }
            fetchUserData();
        }

        protected void fetchUserData()
        {
            var route = HttpContext.Current.Server.MapPath(@"\BDCoches.db");
            var connnectionString = "data source=" + route;
            var deck = "";
            var lines = "";

            using (var db = new SQLiteConnection(connnectionString))
            {
                db.Open();
                var cmd = new SQLiteCommand("SELECT * FROM Usuarios WHERE ID=" + Session["id"], db);
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    for(var i = 0; i < reader.FieldCount; i++)
                    {
                        if (!reader.IsDBNull(i))
                        {
                            if (reader.GetName(i).Equals("Cuenta"))
                            {
                                nameInput.Value = reader.GetString(i);
                            }
                            if (reader.GetName(i).Equals("NombreCompleto"))
                            {
                                realNameInput.Value = reader.GetString(i);
                            }
                            if (reader.GetName(i).Equals("DNI"))
                            {
                                dniInput.Value = reader.GetString(i);
                            }
                            if (reader.GetName(i).Equals("Tel"))
                            {
                                telInput.Value = reader.GetInt32(i).ToString();
                            }
                            if (reader.GetName(i).Equals("Email"))
                            {
                                emailInput.Value = reader.GetString(i);
                            }
                        }
                    }
                }
                cmd = new SQLiteCommand("SELECT * FROM Coches", db);
                reader = cmd.ExecuteReader();
                var carIDNameMap = new Dictionary<String, String>();
                while (reader.Read())
                {
                    var cardHtml = "";
                    var matricula = "";
                    var datos = "";
                    var inicio = "";
                    var fin = "";
                    var imagen = "";
                    var ciudad = "";
                    var marca = "";
                    var modelo = "";
                    var potencia = "";
                    var puertas = "";
                    var tipo = "";
                    var precio = "";
                    var enlace = "";
                    var idUsuario = "";
                    for(var i = 0; i < reader.FieldCount; i++)
                    {
                        if (!reader.IsDBNull(i))
                        {
                            switch (reader.GetName(i))
                            {
                                case "ID":
                                    imagen = reader.GetInt32(i).ToString();
                                    break;
                                case "Inicio":
                                    inicio = reader.GetString(i);
                                    break;
                                case "Fin":
                                    fin = reader.GetString(i);
                                    break;
                                case "Ciudad":
                                    ciudad = reader.GetString(i);
                                    break;
                                case "Marca":
                                    marca = reader.GetString(i);
                                    break;
                                case "Datos":
                                    datos = reader.GetString(i);
                                    break;
                                case "IDPropietario":
                                    idUsuario = reader.GetInt32(i).ToString();
                                    break;
                            }
                        }
                    }
                    if (idUsuario.Equals(Session["id"]))
                    {
                        enlace = "/AdProfile.aspx?car_id=" + imagen;
                        cardHtml = generateCard(datos, inicio, fin, imagen, marca, enlace);
                        deck += cardHtml;
                    }
                    carIDNameMap.Add(imagen, marca);
                }
                anuncios.InnerHtml = deck;
                cmd = new SQLiteCommand("SELECT * FROM Alquiler WHERE IDUsuario=" + Session["id"], db);
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var inicio = "";
                    var fin = "";
                    var carid = "";
                    for(var i = 0; i < reader.FieldCount; i++)
                    {
                        if (!reader.IsDBNull(i))
                        {
                            switch (reader.GetName(i))
                            {
                                case "IDCoche":
                                    carid = reader.GetInt32(i).ToString();
                                    break;
                                case "Inicio":
                                    inicio = reader.GetString(i);
                                    break;
                                case "Fin":
                                    fin = reader.GetString(i);
                                    break;
                            }
                        }
                    }
                    var marca = "";
                    if (carIDNameMap.TryGetValue(carid, out marca))
                    {
                        lines += generateRentLine(marca, inicio, fin);
                    }
                }
                if (!lines.Equals(""))
                {
                    bodyAlquileres.InnerHtml = lines;
                    System.Diagnostics.Debug.WriteLine(lines);
                }
                else
                {
                    alquileres.Visible = false;
                }
                db.Close();
            }
        }

        protected void editUser(object sender, EventArgs e)
        {
            Response.Redirect("~/UserConf.aspx");
        }

        protected string generateCard(
            string datos,
            string inicio,
            string fin,
            string imagen,
            string marca,
            string enlace)
        {
            var str =
                "<div class=\"col-4 my-2 mx-auto position-relative bg-white\">" +
                    "<div style=\"height: 100%; width: 100%; box-shadow: 0px 0px 8px 4px rgba(0,0,0,0.41); border-radius: 2px;\">" +
                        "<div style=\"height: 300px; overflow: hidden\">" +
                            "<img src=\"" + "imageHandler.ashx?id=" + imagen + "\" alt=\"Man with backpack\" class=\"img-responsive w-100\">" +
                        "</div>" +
                        "<div class=\"px-2 py-2\">" +
                            "<p class=\"mb-0 small font-weight-medium text-uppercase mb-1 text-muted lts-2px\">" +
                                inicio + "/" + fin +
                            "</p>" +
                            "<h1 class=\"ff-serif font-weight-normal text-black card-heading mt-0 mb-1\" style=\"line-height: 1.25;\">" +
                                marca +
                            "</h1>" +
                            "<p class=\"mb-1\">" + datos + "</p>" +
                        "</div>" +
                        "<a href=\"" + enlace + "\" class=\"text-uppercase d-inline-block font-weight-medium lts-2px ml-2 mb-2 text-center styled-link\">Ver</a>" +
                    "</div>" +
                "</div>";
            return str;
        }

        protected string generateRentLine(string marca, string inicio, string fin)
        {
            var str =
                "<tr>" + 
                    "<td>" + marca + "</td>" +
                    "<td>" + inicio + "</td>" +
                    "<td>" + fin + "</td>" +
                "</tr>";
            return str;
        }
    }
}