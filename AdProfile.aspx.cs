using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SQLite;
using System.Data;

namespace Sharefy_MDA
{
    public partial class AdProfile : System.Web.UI.Page
    {
        protected global::System.Web.UI.HtmlControls.HtmlInputGenericControl dateT;
        protected global::System.Web.UI.HtmlControls.HtmlInputGenericControl dateF;
        protected global::System.Web.UI.HtmlControls.HtmlInputGenericControl valoration;



        protected string dateFrom = "";
        protected string dateTo = "";
        protected int price;
        protected DateTime td = DateTime.Today;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["id"] == null) Response.Redirect("/Login.aspx");
            search();
            if (DateTime.Compare(DateTime.ParseExact(dateFrom, "yyyy-MM-dd", null), td) > 0)
            {
                dateF.Attributes.Add("min", dateFrom);
                dateT.Attributes.Add("min", dateFrom);
            }
            else
            {
                dateF.Attributes.Add("min", td.ToString("yyyy-MM-dd"));
                dateT.Attributes.Add("min", td.ToString("yyyy-MM-dd"));
            }

            dateF.Attributes.Add("max", dateTo);
            dateT.Attributes.Add("max", dateTo);
            reportDone.Visible = false;
            needMoreData.Visible = false;
            
            checkFav();
        }

        protected void confirmRent(object sender, EventArgs e)
        {
            if (Session["id"] == null) return;
            var df = dateF.Value;
            var dt = dateT.Value;
            if (dt == "" || dt == "")
            {
                needData();
                return;
            }

            if (DateTime.Compare(DateTime.ParseExact(df, "yyyy-MM-dd", null),
                    DateTime.ParseExact(dt, "yyyy-MM-dd", null)) > 0) return;

            if (searchRents(df, dt)) return;

            Session["rent"] = new[] { Request.QueryString["car_id"], Session["id"].ToString(), df, dt, price.ToString() };
            Response.Redirect("/Rent.aspx");
        }

        protected bool searchRents(string df, string dt)
        {
            return false;
        }

        protected void search()
        {
            var carID = Request.QueryString["car_id"];
            if (carID == null) Response.Redirect("/ListAds.aspx");
            fillData("select * from Coches Where ID ='" + carID + "'");
        }

        protected void fillData(string query)
        {
            var relativeRoute = HttpContext.Current.Server.MapPath(@"\BDcoches.db");
            var connstring = "data source=" + relativeRoute;
            var deck = "";
            using (var db = new SQLiteConnection(connstring))
            {
                db.Open();
                using (var cmd = new SQLiteCommand(query, db))
                {
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        var ownId = "";
                        var img = "";
                        var softTitle = "";
                        var carM = "";
                        var plate = "";
                        var text = "";
                        var model = "";
                        var type = "";
                        var doors = 0;
                        var power = 0;
                        var city = "";
                        for (var i = 0; i < reader.FieldCount; i++)
                            if (!reader.IsDBNull(i))
                            {
                                if (reader.GetName(i).Equals("IDPropietario"))
                                {
                                    ownId = reader.GetInt32(i).ToString();
                                    continue;
                                }
                                if (reader.GetName(i).Equals("ID"))
                                {
                                    img = reader.GetInt32(i) + "";
                                    continue;
                                }

                                if (reader.GetName(i).Equals("Precio"))
                                {
                                    price = reader.GetInt32(i);
                                    continue;
                                }

                                if (reader.GetName(i).Equals("Puertas"))
                                {
                                    doors = reader.GetInt32(i);
                                    continue;
                                }

                                if (reader.GetName(i).Equals("Potencia"))
                                {
                                    power = reader.GetInt32(i);
                                    continue;
                                }

                                var info = reader.GetString(i);
                                switch (reader.GetName(i))
                                {
                                    case "Inicio":
                                        dateFrom = info;
                                        break;
                                    case "Fin":
                                        dateTo = info;
                                        break;
                                    case "Matricula":
                                        plate = info;
                                        break;
                                    case "Disponibilidad":
                                        softTitle = info;
                                        break;
                                    case "Datos":
                                        text = info;
                                        break;
                                    case "Marca":
                                        carM = info;
                                        break;
                                    case "Modelo":
                                        model = info;
                                        break;
                                    case "Tipo":
                                        type = info;
                                        break;
                                    case "Ciudad":
                                        city = info;
                                        break;
                                }
                            }

                        deck += showData(ownId, img, softTitle, text, plate, dateFrom, dateTo, carM, model, power, doors, type,
                            price, city);
                    }
                }

                Car_data.InnerHtml = deck;
                db.Close();
            }
        }

        protected string getUserName(String id)
        {
            var relativeRoute = HttpContext.Current.Server.MapPath(@"\BDcoches.db");
            var connstring = "data source=" + relativeRoute;
            var userName = "";
            //var id = Session["id"].ToString();
            using (var db = new SQLiteConnection(connstring))
            {
                db.Open();
                using (var cmd = new SQLiteCommand("select Cuenta from Usuarios where ID = '" + id + "'", db))
                {
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                        for (var i = 0; i < reader.FieldCount; i++)
                            if (!reader.IsDBNull(i))
                                if (reader.GetName(i).Equals("Cuenta"))
                                    userName = reader.GetString(i);
                }

                db.Close();
                return userName;
            }
        }

        protected void cancelRent(object sender, EventArgs e)
        {
            Response.Redirect("/ListAds.aspx");
        }

        protected string showData(string ownId, string img, string softTitle, string text, string plate, string dateF, string dateT,
            string carM, string model, int power, int doors, string type, int price, string city)
        {
            return "<div class=\"my-2 mx-auto position-relative bg-white\" style=\"width: 100%;\">"
                + "<div style=\"height: 400px; overflow: hidden center-block\">"
                + "<img src=\"" + "imageHandler.ashx?id=" + img + "\" alt=\"Man with backpack\" class=\"img-responsive h-100 center-block\">"
                + "</div>"
                + "<div class=\"px-2 py-2\">"
                + "<p class=\"mb-0 small font-weight-medium text-uppercase mb-1 text-muted lts-2px\">" + softTitle +
                "</p>"
                + "<a class=\"mb-1\" href=VendorProfile?profile_id=" + ownId + ">Perfil propietario</a>" +
                "<p class=\"mb-1\">" + text + "</p>" +
                "</div>" +
                "</div>" +
                "<div>"
                + "<div class=\"row\">" +
                "<div class=\"col-md-auto\">Ciudad: </div>" +
                "<p class=\"col-md-auto\">" + city + "</p>" +
                "</div>"
                + "<div class=\"row\">" +
                "<div class=\"col-md-auto\">Matrícula: </div>" +
                "<p class=\"col-md-auto\">" + plate + "</p>" +
                "</div>"
                + "<div class=\"row\">" +
                "<div class=\"col-md-auto\">Marca: </div>" +
                "<p class=\"col-md-auto\">" + carM + "</p>" +
                "</div>"
                + "<div class=\"row\">" +
                "<div class=\"col-md-auto\">Modelo: </div>" +
                "<p class=\"col-md-auto\">" + model + "</p>" +
                "</div>"
                + "<div class=\"row\">" +
                "<div class=\"col-md-auto\">Potencia:</div>" +
                "<p class=\"col-md-auto\">" + power + "</p>" +
                "</div>"
                + "<div class=\"row\">" +
                "<div class=\"col-md-auto\">Nº de Puertas: </div>" +
                "<p class=\"col-md-auto\">" + doors + "</p>" +
                "</div>"
                + "<div class=\"row\">" +
                "<div class=\"col-md-auto\">Tipo de Coche: </div>" +
                "<p class=\"col-md-auto\">" + type + "</p>" +
                "</div>"
                + "<div class=\"row\">" +
                "<div class=\"col-md-auto\">Disponible Desde: </div>" +
                "<p class=\"col-md-auto\">" + dateF + "</p>" +
                "</div>"
                + "<div class=\"row\">" +
                "<div class=\"col-md-auto\">Hasta: </div>" +
                "<p class=\"col-md-auto\">" + dateT + "</p>" +
                "</div>"
                + "<div class=\"row\">" +
                "<div class=\"col-md-auto\">Precio por dia: </div>" +
                "<p class=\"col-md-auto\">" + price + "€ </p>" +
                "</div>"
                + "</div>";
        }

        protected void needData()
        {
            needMoreData.Visible = true;
        }

        protected void reportAd(object sender, EventArgs e)
        {
            var userId = Session["id"].ToString();
            var carId = Request.QueryString["car_id"];

            var relativeRoute = HttpContext.Current.Server.MapPath(@"\BDcoches.db");
            var connstring = "data source=" + relativeRoute;
            using (var db = new SQLiteConnection(connstring))
            {
                db.Open();

                using (var cmd = new SQLiteCommand("insert into Reportes(IDCoche, IDUsuario) values (@car, @user)", db))
                {
                    try
                    {
                        cmd.Parameters.Add("@car", DbType.Int32).Value = carId;
                        cmd.Parameters.Add("@user", DbType.Int32).Value = userId;
                        cmd.ExecuteNonQuery();
                        reportDone.InnerText = "Se ha reportado este anucio";
                        reportDone.Visible = true;
                    }
                    catch
                    {
                        reportDone.InnerText = "Error al procesar el reporte";
                        reportDone.Visible = true;
                    }
                }
                db.Close();
            }
        }


        public void checkFav()
        {
            
        }

        public void addToFav(object sender, EventArgs e)
        {
            var userId = Session["id"].ToString();
            var carId = Request.QueryString["car_id"];

            var relativeRoute = HttpContext.Current.Server.MapPath(@"\BDcoches.db");
            var connstring = "data source=" + relativeRoute;
            using (var db = new SQLiteConnection(connstring))
            {
                db.Open();

                using (var cmd = new SQLiteCommand("insert into Favoritos(IDUsuario, IDCoche) values (@user, @car)", db))
                {
                    try
                    {
                        cmd.Parameters.Add("@user", DbType.Int32).Value = userId;
                        cmd.Parameters.Add("@car", DbType.Int32).Value = carId;
                        cmd.ExecuteNonQuery();
                    }
                    catch
                    {
                    }
                }
                db.Close();
            }

        }

    }
}