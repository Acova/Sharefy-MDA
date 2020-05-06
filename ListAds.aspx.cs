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
                        var filters = "";
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
                                        title = reader.GetString(i);
                                        break;
                                    case "Modelo":
                                        title += " " + reader.GetString(i);
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
                                        filters = " " + reader.GetString(i);
                                        break;
                                }
                            }

                        link = "/Rent.aspx?car_id=" + img;
                        deck += NewCard(img, softTitle, title, text, link, precio, puertas, potencia, filters);
                    }
                }

                cards.InnerHtml = deck;
                db.Close();
            }
        }

        protected string NewCard(string img, string softTitle, string title, string text, string link, string precio,
            string puertas, string potencia, string filters)
        {
            return "<div class=\"col-4 my-2 mx-auto position-relative bg-white \" style=\"overflow: hidden; border-radius: 2px;\">"
                   + "<div style=\"height: 100%; width: 100%; box-shadow: 0px 0px 8px 4px rgba(0,0,0,0.41);\">"
                + "<div style=\"height: 300px; overflow: hidden\">"
                   +"<img src=\"" + "imageHandler.ashx?id=" + img + "\" alt=\"Man with backpack\" class=\"w-100 h-auto\">"
                   + "</div>"
                   + "<div class=\"px-2 py-2\"><p class=\"mb-0 small font-weight-medium text-uppercase mb-1 text-muted lts-2px\">" +
                   softTitle + "</p>"
                   + "<h1 class=\"ff-serif font-weight-normal text-black card-heading mt-0 mb-1\" style=\"line-height: 1.25;\">" +
                   title
                   + "</h1><p class=\"mb-1\">" + text
                   + "</p></div><a href=\"" + link +
                   "\" class=\"text-uppercase d-inline-block font-weight-medium lts-2px ml-2 mb-2 text-center styled-link\">Ver</a>"
                   + "<div class=\"precio\" style=\"display: none;\">" + precio + "</div>"
                   + "<div class=\"puertas\" style=\"display: none;\">" + puertas + "</div>"
                   + "<div class=\"potencia\" style=\"display: none;\">" + potencia + "</div>"
                   + "</div>"
                   + "</div>";
        }
    }
}