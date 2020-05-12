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
        String email = "";
        String text = "";
        String sqlSentece = "insert into Mensages(Name,Email,Message,Attended) values(@name,@email,@text,@attended)";
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void send(object sender, EventArgs e)
        {
            collectData();
            if (allInputsAreFilled()) {
                AddMessageToDataBase();
            }
            cleanData();
        }

        public Boolean allInputsAreFilled() {
            if (name == "") {
                return false;
            }
            if (email == "")
            {
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
            name = nameInput.Value;
            email = mailInput.Value;
            text = textArea.Value;
        }

        public void cleanData() { }

        private void AddMessageToDataBase()
        {
            var relativeRoute = HttpContext.Current.Server.MapPath(@"\BDcoches.db");
            var connstring = "data source=" + relativeRoute;

            using (var db = new SQLiteConnection(connstring))
            {
                db.Open();
                using (var cmd = new SQLiteCommand(sqlSentece, db))
                {
                    try
                    {
                        cmd.Parameters.Add("@name", DbType.String).Value = name;
                        cmd.Parameters.Add("@email", DbType.String).Value = email;
                        cmd.Parameters.Add("@text", DbType.String).Value = text;
                        cmd.Parameters.Add("@attended", DbType.Int32).Value = 0;

 
                        cmd.ExecuteNonQuery();


                    }
                    catch
                    {
                    }


                    db.Close();
                }
            }
        }
    }
}