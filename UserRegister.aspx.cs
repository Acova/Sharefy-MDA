﻿using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Sharefy_MDA
{
    public partial class UserRegister : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            failText.Visible = false;
        }

        protected void create(object sender, EventArgs e)
        {
            if (checkRequirements())
            {
                createUser(buildQuery());
                loginUser(buildLoginSQL());
            }
        }

        protected bool checkRequirements()
        {
            var userName = userNameInput.Value;
            var pass = passwordInput.Value;

            if(userName.Equals("") || pass.Equals(""))
            {
                failText.InnerText = "No se han facilitado los campos obligatorios";
                failText.Visible = true;
                return false;
            }

            return true;
        }

        protected string buildQuery()
        {
            return buildBase() + buildArgs();
        }

        protected string buildBase()
        {
            return "insert into Usuarios (Cuenta, Clave, NombreCompleto, DNI, Tel, Email, Rol) values (";
        }

        protected string buildArgs()
        {
            var userName = userNameInput.Value;
            var pass = passwordInput.Value;
            var name = realNameInput.Value;
            var dni = dniInput.Value;
            var tel = phoneNumberInput.Value;
            var mail = mailInput.Value;
            return
                "\"" +
                userName + "\",\"" +
                pass + "\",\"" +
                name + "\",\"" +
                dni + "\",\"" +
                tel + "\",\"" +
                mail + "\",\"" +
                "usuario" + "\")";
        }

        protected void createUser(string sqlSentence)
        {
            var dbRoute = HttpContext.Current.Server.MapPath(@"\BDcoches.db");
            var conString = "data source=" + dbRoute;

            using(var db = new SQLiteConnection(conString))
            {
                db.Open();
                using (var cmd = new SQLiteCommand(sqlSentence, db))
                {
                    try
                    {
                        cmd.ExecuteNonQuery();
                    }
                    catch
                    {
                        failText.InnerText = "Error añadiendo a la base de datos";
                        failText.Visible = true;
                    }
                }
                db.Close();
            }
        }

        protected string buildLoginSQL()
        {
            return buildLoginBase() + buildLoginArgs();
        }

        protected string buildLoginBase()
        {
            return "select ID, Rol from Usuarios ";
        }

        protected string buildLoginArgs()
        {
            var user = userNameInput.Value;
            var pass = passwordInput.Value;
            return "WHERE " +
                "Cuenta=\"" + user + "\"" +
                "and Clave=\"" + pass + "\"";
        }

        protected void loginUser(string sqlCommand)
        {
            var id = 0;
            var rol = "";
            var route = HttpContext.Current.Server.MapPath(@"\BDcoches.db");
            var conString = "data source=" + route;
            using (var db = new SQLiteConnection(conString))
            {
                db.Open();
                using (var cmd = new SQLiteCommand(sqlCommand, db))
                {
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        for (var i = 0; i < reader.FieldCount; i++)
                        {
                            if (!reader.IsDBNull(i))
                            {
                                if (reader.GetName(i).Equals("ID"))
                                {
                                    id = reader.GetInt32(i);
                                }
                                if (reader.GetName(i).Equals("Rol"))
                                {
                                    rol = reader.GetString(i);
                                }
                            }
                        }
                    }
                    if (id == 0)
                    {
                        failText.InnerText = "Error en el inicio de sesión";
                        failText.Visible = true;
                    }
                    else
                    {
                        Session["id"] = id;
                        Session["rol"] = rol;
                        System.Diagnostics.Debug.WriteLine("ID de usuario: " + Session["id"]);
                        System.Diagnostics.Debug.WriteLine("Rol: " + Session["rol"]);
                        Response.Redirect("~/Default.aspx");
                    }
                }
                db.Close();
            }
        }
    }
}