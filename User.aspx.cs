using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Data;
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
                DataTable adDataTable = new DataTable();
                cmd = new SQLiteCommand("SELECT ID, Datos, Inicio, Fin, Marca, Matricula FROM Coches WHERE IDPropietario=" + Session["id"], db);
                cmd.CommandType = CommandType.Text;
                SQLiteDataAdapter adDataAdapter = new SQLiteDataAdapter(cmd);
                adDataAdapter.Fill(adDataTable);
                AdGridViewData.DataSource = adDataTable;
                AdGridViewData.DataBind();

                DataTable rentDataTable = new DataTable();
                cmd = new SQLiteCommand(
                    "SELECT Alquiler.ID, Alquiler.IDCoche, Alquiler.Inicio, Alquiler.Fin, Coches.Marca " +
                    "FROM Alquiler " +
                    "INNER JOIN Coches ON Coches.ID=Alquiler.IDCoche " +
                    "WHERE Alquiler.IDUsuario=" + Session["id"], db);
                cmd.CommandType = CommandType.Text;
                SQLiteDataAdapter rentDataAdapter = new SQLiteDataAdapter(cmd);
                rentDataAdapter.Fill(rentDataTable);
                RentGridViewData.DataSource = rentDataTable;
                RentGridViewData.DataBind();
                
                DataTable favDataTable = new DataTable();
                cmd = new SQLiteCommand("SELECT Coches.ID, Coches.Datos, Coches.Inicio, Coches.Fin, Coches.Marca, Coches.Matricula FROM Coches INNER JOIN Favoritos ON Favoritos.IDCoche=Coches.ID WHERE Favoritos.IDUsuario=" + Session["id"], db);
                cmd.CommandType = CommandType.Text;
                SQLiteDataAdapter favDataAdapter = new SQLiteDataAdapter(cmd);
                favDataAdapter.Fill(favDataTable);
                FavGridViewData.DataSource = favDataTable;
                FavGridViewData.DataBind();
                
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

        protected void RentGridViewData_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if(e.CommandName == "DeleteUser")
            {
                LinkButton button = (LinkButton)e.CommandSource;
                GridViewRow row = (GridViewRow)button.NamingContainer;
                var id = RentGridViewData.DataKeys[row.RowIndex].Value.ToString();
                var startDate = DateTime.ParseExact(row.Cells[3].Text, "yyyy-MM-dd", null);
                if ((startDate - DateTime.Today).Days > 3)
                {
                    var route = HttpContext.Current.Server.MapPath(@"\BDcoches.db");
                    var str = "data source=" + route;
                    using(var db = new SQLiteConnection(str))
                    {
                        db.Open();
                        var cmd = new SQLiteCommand("DELETE FROM Alquiler WHERE ID=" + id, db);
                        cmd.ExecuteReader();
                        db.Close();
                    }
                    fetchUserData();
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('No se puede cancelar este alquiler')", true);
                }
            }
        }

        protected void AdGridViewData_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "DeleteUser")
            {
                LinkButton button = (LinkButton)e.CommandSource;
                GridViewRow row = (GridViewRow)button.NamingContainer;
                var id = AdGridViewData.DataKeys[row.RowIndex].Value.ToString();
                var route = HttpContext.Current.Server.MapPath(@"\BDcoches.db");
                var str = "data source=" + route;
                using (var db = new SQLiteConnection(str))
                {
                    db.Open();
                    var cmd = new SQLiteCommand("DELETE FROM Coches WHERE ID=" + id, db);
                    cmd.ExecuteReader();
                    db.Close();
                }
                fetchUserData();
            }
        }


        protected void FavGridViewData_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "DeleteCar")
            {
                LinkButton button = (LinkButton)e.CommandSource;
                GridViewRow row = (GridViewRow)button.NamingContainer;
                var id = FavGridViewData.DataKeys[row.RowIndex].Value.ToString();
                var route = HttpContext.Current.Server.MapPath(@"\BDcoches.db");
                var str = "data source=" + route;
                using (var db = new SQLiteConnection(str))
                {
                    db.Open();
                    var cmd = new SQLiteCommand("DELETE FROM Favoritos WHERE IDCoche=" + id + " AND IDUsuario="+ Session["id"], db);
                    cmd.ExecuteReader();
                    db.Close();
                }
                fetchUserData();
            }
        }
    }
}