using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SQLite;

namespace Sharefy_MDA
{
    public partial class Rent : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["id"] == null) Response.Redirect("/Login.aspx");

            getTotal();
        }

        private void getTotal()
        {
            var aux = (string[])Session["rent"];
            if (aux == null) Response.Redirect("/ListAds.aspx");
            var EndDate = DateTime.ParseExact(aux[3], "yyyy-MM-dd", null);
            var StartDate = DateTime.ParseExact(aux[2], "yyyy-MM-dd", null);
            var price = int.Parse(aux[4]);

            priceToPay.InnerHtml = "<h2>Total = " + ((EndDate - StartDate).Days + 1) * price + " €</h2>";
        }

        protected void confirmPayment(object sender, EventArgs e)
        {
            rentCar();
            Response.Redirect("/ListAds.aspx");
        }

        private void rentCar()
        {
            var relativeRoute = HttpContext.Current.Server.MapPath(@"\BDcoches.db");
            var connstring = "data source=" + relativeRoute;
            using (var db = new SQLiteConnection(connstring))
            {
                db.Open();
                using (var cmd = new SQLiteCommand(getQuery(), db))
                {
                    try
                    {
                        cmd.ExecuteNonQuery();
                        Console.WriteLine("COCHE ALQUILADO CON ÉXITO");
                    }
                    catch
                    {
                        Console.WriteLine("NO SE PUEDO REALIZAR EL ALQUILER");
                    }
                }

                db.Close();
            }
        }

        protected string getQuery()
        {
            var aux = (string[])Session["rent"];
            var idCar = aux[0];
            var idUser = aux[1];
            var df = aux[2];
            var dt = aux[3];
            var sql = "insert into Alquiler (IDCoche, IDUsuario, Inicio, Fin) values ('" + idCar + "','" + idUser +
                      "',\"" + df + "\",\"" + dt + "\")";
            return sql;
        }

        protected void cancelPayment(object sender, EventArgs e)
        {
            var aux = (string[])Session["rent"];
            Response.Redirect("/AdProfile.aspx?car_id=" + aux[0]);
        }
    }
}