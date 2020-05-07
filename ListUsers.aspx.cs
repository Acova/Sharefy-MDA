using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Sharefy_MDA
{
    public partial class ListUsers : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["id"] == null || !Session["rol"].Equals("administrador"))
            {
                Response.Redirect("~/Default.aspx");
            }
            if (!IsPostBack)
            {
                fetchData();
            }

        }

        protected void fetchData()
        {
            DataTable dt = new DataTable();
            var relativeRoute = HttpContext.Current.Server.MapPath(@"\BDcoches.db");
            var connstring = "data source=" + relativeRoute;
            using (var db = new SQLiteConnection(connstring))
            {
                db.Open();
                SQLiteCommand cmd = new SQLiteCommand("SELECT[ID], [Cuenta], [Clave], [NombreCompleto], [DNI], [Tel], [Email], [Rol] FROM[Usuarios] ", db);
                cmd.CommandType = CommandType.Text;
                SQLiteDataAdapter da = new SQLiteDataAdapter(cmd);
                da.Fill(dt);
                GridViewData.DataSource = dt;
                GridViewData.DataBind();
            }
        }

        protected void GridViewData_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "EditUser")
            {
                LinkButton button = (LinkButton)e.CommandSource;
                GridViewRow row = (GridViewRow)button.NamingContainer;
                var id = GridViewData.DataKeys[row.RowIndex].Value.ToString();
                string url = "~/ProfileMod.aspx?id=" + id;
                Response.Redirect(url);
            }
            else if (e.CommandName == "DeleteUser")
            {
                LinkButton button = (LinkButton)e.CommandSource;
                GridViewRow row = (GridViewRow)button.NamingContainer;
                var id = GridViewData.DataKeys[row.RowIndex].Value.ToString();
                string sessionId = Session["id"] + "";
                if (sessionId.Equals(id))
                {
                    Response.Write("<script>alert('No se puede eliminar el usuario activo');</script>");
                    return;
                }
                else
                {
                    var relativeRoute = HttpContext.Current.Server.MapPath(@"\BDcoches.db");
                    var connstring = "data source=" + relativeRoute;
                    using (var db = new SQLiteConnection(connstring))
                    {
                        db.Open();
                        SQLiteCommand cmd = new SQLiteCommand("delete from[Usuarios] WHERE ID=" + id, db);
                        cmd.ExecuteReader();
                        db.Close();
                    }
                    fetchData();
                }
            }

        }

        protected void search(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            var relativeRoute = HttpContext.Current.Server.MapPath(@"\BDcoches.db");
            var connstring = "data source=" + relativeRoute;
            using (var db = new SQLiteConnection(connstring))
            {
                var searchText = searchWord.Value;
                var cat = CategorySelectInput.Value;
                db.Open();
                SQLiteCommand cmd = new SQLiteCommand("SELECT[ID], [Cuenta], [Clave], [NombreCompleto], [DNI], [Tel], [Email], [Rol] FROM[Usuarios] WHERE [" + cat + "] LIKE \'%" + searchText + "%\'", db);
                cmd.CommandType = CommandType.Text;
                SQLiteDataAdapter da = new SQLiteDataAdapter(cmd);
                da.Fill(dt);
                GridViewData.DataSource = dt;
                GridViewData.DataBind();
            }
        }
        protected void resetSearch(object sender, EventArgs e)
        {
            fetchData();
        }

        protected void addUser(object sender, EventArgs e)
        {
            Response.Redirect("~/ProfileAdd.aspx");
        }
    }
}