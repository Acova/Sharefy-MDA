using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SQLite;

namespace Sharefy_MDA
{
    public partial class ListAds : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            FillData("select * from Coches");
        }

        protected void FillData(string sql)
        {
            cards.InnerHtml = "";
            var relativeRoute = HttpContext.Current.Server.MapPath(@"\BDcoches.db");
            var connstring = "data source=" + relativeRoute;
            var deck = "";
            using (var db = new SQLiteConnection(connstring))
            {
                db.Open();
                using (var cmd = new SQLiteCommand(sql, db))
                {

                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        var img = "";
                        var softTitle = "";
                        var title = "";
                        var text = "";
                        var link = "";
                        var precio = "";
                        var puertas = "";
                        var potencia = "";
                        var tipo = "";
                        var marca = "";
                        var modelo = "";
                        var ciudad = "";
                        for (var i = 0; i < reader.FieldCount; i++)
                            if (!reader.IsDBNull(i))
                            {
                                if (reader.GetName(i).Equals("ID"))
                                {
                                    img = reader.GetInt32(i) + "";
                                    continue;
                                }

                                switch (reader.GetName(i))
                                {
                                    case "Inicio":
                                        softTitle = reader.GetString(i);
                                        break;
                                    case "Fin":
                                        softTitle += "/" + reader.GetString(i);
                                        break;
                                    case "Marca":
                                        marca = reader.GetString(i);
                                        title = marca;
                                        break;
                                    case "Modelo":
                                        modelo = reader.GetString(i);
                                        title += " " + modelo;
                                        break;
                                    case "Datos":
                                        text = reader.GetString(i);
                                        break;
                                    case "Precio":
                                        precio = reader.GetInt32(i) + "";
                                        break;
                                    case "Puertas":
                                        var amount = reader.GetInt32(i);
                                        puertas = amount + "";
                                        break;
                                    case "Potencia":
                                        potencia = reader.GetInt32(i) + "";
                                        break;
                                    case "Tipo":
                                        tipo = " " + reader.GetString(i);
                                        break;
                                    case "Ciudad":
                                        ciudad = " " + reader.GetString(i);
                                        break;
                                }
                            }

                        link = "/AdProfile.aspx?car_id=" + img;
                        deck += NewCard(img, softTitle, title, text, link, precio, puertas, potencia, tipo, marca, modelo);
                    }
                }

                cards.InnerHtml = deck;
                db.Close();
            }
        }

        protected string NewCard(string img, string softTitle, string title, string text, string link, string precio,
            string puertas, string potencia, string tipo, string marca, string modelo)
        {
            return "<div class=\"col-4 my-2 mx-auto position-relative bg-white filterDiv show " + tipo + " " + marca + " " + puertas + "puertas \">"
                   + "<div style=\"height: 100%; width: 100%; box-shadow: 0px 0px 8px 4px rgba(0,0,0,0.41); border-radius: 2px;\">"
                + "<div style=\"height: 300px; overflow: hidden\">"
                   +"<img src=\"" + "imageHandler.ashx?id=" + img + "\" alt=\"Man with backpack\" class=\"img-responsive w-100\">"
                   + "</div>"
                   + "<div class=\"px-2 py-2\"><p class=\"mb-0 small font-weight-medium text-uppercase mb-1 text-muted lts-2px\">" +
                   softTitle + "</p>"
                   + "<h1 class=\"ff-serif font-weight-normal text-black card-heading mt-0 mb-1\" style=\"line-height: 1.25;\">" +
                   title
                   + "</h1><p class=\"mb-1\">" + text
                   + "</p></div><a href=\"" + link +
                   "\" class=\"text-uppercase d-inline-block font-weight-medium lts-2px ml-2 mb-2 text-center styled-link\">Ver</a>"
                   + "</div>"
                   + "</div>";
        }

        protected void search(object sender, EventArgs e)
        {
            String searchText = searchWord.Value;
            String category = CategorySelectInput.Value;
            FillData("select * from Coches WHERE [" + category + "] LIKE \'%" + searchText + "%\'");
        }

        protected void resetSearch(object sender, EventArgs e)
        {
            FillData("select * from Coches");
        }
    }
}