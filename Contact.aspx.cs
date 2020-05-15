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
    public partial class Contact : Page
    {
        String name = "";
        String text = "";
        String getSentece = "SELECT CUENTA FROM Usuarios WHERE CUENTA =";
        String InsertSentece = "insert into Mensajes(Cuenta,Mensaje,Atendido) values(@account,@text,@attended)";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["id"] == null) Response.Redirect("/Login.aspx");
            success.Visible = false;
            fail.Visible = false;
        }

        public void send(object sender, EventArgs e)
        {
            collectData();
            if (allInputsAreFilled() && accountExist())
            {
                AddMessageToDataBase();
                noticeUserSuccess();
            }
            else
            {
                noticeUserFail();
            }
            cleanData();
            
        }

        public Boolean accountExist()
        {
            bool res = false;
            var relativeRoute = HttpContext.Current.Server.MapPath(@"\BDcoches.db");
            var connstring = "data source=" + relativeRoute;
            using (var db = new SQLiteConnection(connstring))
            {
                db.Open();
                String selectSentence = getSentece + "'" + name + "';";
                using (var cmd = new SQLiteCommand(selectSentence, db))
                {
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        if (reader.GetString(reader.FieldCount - 1).CompareTo(name) == 0)
                        {
                            res = true;
                        }
                    }
                }
                db.Close();
            }
            return res;
        }

        public Boolean allInputsAreFilled() {
            if (name == "") {
                return false;
            }
            if (text == "")
            {
                return false;
            }
            return true;
        }

        public void collectData()
        {
            name = accountInput.Value;
            text = textArea.Value;
        }

        public void cleanData() {
            accountInput.Value = "";
            textArea.Value = "";

        }

        public void noticeUserFail()
        {
            fail.InnerText = "La cuenta que ha indicado no existe";
            fail.Visible = true;
            success.Visible = false;
        }

        public void noticeUserSuccess()
        {
            success.InnerText = "Su mensaje se ha enviado";
            success.Visible = true;
            fail.Visible = false;
        }

        private void AddMessageToDataBase()
        {
            var relativeRoute = HttpContext.Current.Server.MapPath(@"\BDcoches.db");
            var connstring = "data source=" + relativeRoute;

            using (var db = new SQLiteConnection(connstring))
            {
                db.Open();

                using (var cmd = new SQLiteCommand(InsertSentece, db))
                {
                    try
                    {
                        cmd.Parameters.Add("@account", DbType.String).Value = name;
                        cmd.Parameters.Add("@text", DbType.String).Value = text;
                        cmd.Parameters.Add("@attended", DbType.Int32).Value = 0;
                        cmd.ExecuteNonQuery();
                    }
                    catch
                    { }
                }
                
                db.Close();
            }
        }
    }
}