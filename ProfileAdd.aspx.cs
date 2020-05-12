using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Web;


namespace Sharefy_MDA
{
    public partial class ProfileAdd : System.Web.UI.Page
    {

        private string _dni;
        private int _dniNumer;
        private string _password;
        private string _repeatedPassword;
        private string _name;
        private string _accountName;
        private string _mail;
        private string _telefono;
        private Boolean isAdminRequestChecked;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["id"] == null || !Session["rol"].Equals("administrador"))
            {
                Response.Redirect("~/Default.aspx");
            }
            fail.Visible = false;

        }

        public void create(object sender, EventArgs e)
        {
            _dni = dniInput.Value;
            _password = passwordInput.Value;
            _repeatedPassword = repeatPasswordInput.Value;
            _name = nameInput.Value;
            _accountName = accountNameInput.Value;
            _mail = mailInput.Value;
            _telefono = phoneInput.Value;
            isAdminRequestChecked = adminCheck.Checked;


            if (!CheckRequirements(_dni, _password, _repeatedPassword, _name, _accountName)) return;
            AddUserToDataBase();
        }

        private void AddUserToDataBase()
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
                        cmd.Parameters.Add("@Dni", DbType.Int32).Value = _dniNumer;
                        cmd.Parameters.Add("@Password", DbType.String).Value = _password;
                        cmd.Parameters.Add("@Name", DbType.String).Value = _name;
                        cmd.Parameters.Add("@Account", DbType.String).Value = _accountName;
                        cmd.Parameters.Add("@Mail", DbType.String).Value = _mail;
                        cmd.Parameters.Add("@Phone", DbType.Int32).Value = _telefono;
                        if (isAdminRequestChecked)
                        {
                            cmd.Parameters.Add("Rol", DbType.String).Value = "administrador";
                        }
                        else
                        {
                            cmd.Parameters.Add("@Rol", DbType.String).Value = "usuario";
                        }
                        cmd.ExecuteNonQuery();
                        Response.Redirect("./ListUser.aspx");

                    }
                    catch
                    {
                        fail.InnerText = "Ya existe un usuario con este nombre";
                        fail.Visible = true;
                    }


                    db.Close();
                }
            }
        }


        protected string getQuery()
        {
            String s = GetBase() + GetValues();
            return s;
        }

        private string GetBase()
        {
            return "insert into Usuarios (Cuenta, Clave, NombreCompleto, DNI, Tel, Email, Rol) values (";
        }

        private string GetValues()
        {

            return "@Account" + "," + "@Password" + "," + "@Name" + "," + "@Dni" + "," + "@Phone" + "," + "@Mail" +
                   "," + "@Rol" + ")";
        }



        private bool CheckRequirements(string dni, string password, string repeatedPassword, string name, string account)
        {

            if (name == "" || account == "" || password == "" || repeatedPassword == "")
            {
                if (password != repeatedPassword)
                {
                    fail.InnerText = "Las contraseñas no coinciden";
                    fail.Visible = true;
                    return false;
                }
                fail.InnerText = "Faltan campos por rellenar";
                fail.Visible = true;
                return false;
            }

            if (CheckId(dni)) return true;

            fail.InnerText = "DNI erróneo";
            fail.Visible = true;
            return false;
        }

        private bool CheckId(string id)
        {
            if (id == String.Empty)
                return false;
            try
            {
                var letter = id.Substring(id.Length - 1, 1);
                id = id.Substring(0, id.Length - 1);
                var number = int.Parse(id);
                _dniNumer = number; 
                var rem = number % 23;
                var tmp = getLetter(rem);
                if (tmp.ToLower() != letter.ToLower())
                    return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
            return true;
        }

        private string getLetter(int id)
        {
            Dictionary<int, String> letter = new Dictionary<int, string>
            {
                {0, "T"},
                {1, "R"},
                {2, "W"},
                {3, "A"},
                {4, "G"},
                {5, "M"},
                {6, "Y"},
                {7, "F"},
                {8, "P"},
                {9, "D"},
                {10, "X"},
                {11, "B"},
                {12, "N"},
                {13, "J"},
                {14, "Z"},
                {15, "S"},
                {16, "Q"},
                {17, "V"},
                {18, "H"},
                {19, "L"},
                {20, "C"},
                {21, "K"},
                {22, "E"}
            };
            return letter[id];
        }


        protected void cancel(object sender, EventArgs e)
        {
            Response.Redirect("~/ListUsers.aspx");
        }
    }
}