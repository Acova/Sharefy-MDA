using System;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Web;
using System.Web.UI;

namespace Sharefy_MDA
{
    public partial class ListCar : Page
    {
        protected System.Web.UI.HtmlControls.HtmlInputGenericControl InicioInput;
        protected System.Web.UI.HtmlControls.HtmlInputGenericControl FinInput;


        protected void Page_Load(object sender, EventArgs e)
        {
            success.Visible = false;
            fail.Visible = false;
            InicioInput.Value = DateTime.Now.ToString("yyyy-MM-dd");
            InicioInput.Attributes.Add("min", DateTime.Now.ToString("yyyy-MM-dd"));
            FinInput.Attributes.Add("min", DateTime.Now.ToString("yyyy-MM-dd"));
        }

        protected void Create(object sender, EventArgs e)
        {
            if (Session["id"] != null)
            {
                if (CheckRequirements()) CreateCar(GetQuery());
            }
            else
            {
                fail.InnerText = "Tiene que estar registrado para poder listar coches";
                fail.Visible = true;
            }
        }

        protected void Cancel(object sender, EventArgs e)
        {
            Response.Redirect("/Profile?profile_id=" + Session["id"]);
        }

        private string GetQuery()
        {
            return GetBase() + GetValues();
        }

        private static string GetBase()
        {
            return
                "insert into Coches (IDPropietario , Matricula, Datos, Inicio, Fin, Imagen, Ciudad, Marca, Modelo, Potencia, Puertas, Tipo, Precio, Condiciones) values (";
        }

        private static string GetValues()
        {
            return "@userId" + "," + "@plate" + "," + "@data" + "," + "@initDate" + "," + "@endDate" + "," + "@img" +
                   "," + "@city" + "," + "@brand" + "," + "@model" + "," + "@power" + "," + "@doors" + "," + "@type" +
                   "," + "@price" +
                   "," + "@condition" + ")";
        }

        private bool CheckRequirements()
        {
            var plate = matriculaInput.Value;
            var data = datosInput.Value;
            var initDate = InicioInput.Value;
            var endDate = FinInput.Value;
            var city = ciudadInput.Value;
            var brand = marcaInput.Value;
            var model = modeloInput.Value;
            var power = potenciaInput.Value;
            var doors = puertasInput.Value;
            var price = precioInput.Value;


            if (plate.Equals("") || data.Equals("") || initDate.Equals("") || city.Equals("") || brand.Equals("") ||
                model.Equals("") || power.Equals("") || doors.Equals("") || price.Equals(""))
            {
                fail.InnerText = "Rellene los campos obligatorios";
                fail.Visible = true;
                return false;
            }

            if (!endDate.Equals(""))
            {
                var iDate = DateTime.ParseExact(initDate, "yyyy-MM-dd", null);
                var eDate = DateTime.ParseExact(endDate, "yyyy-MM-dd", null);
                if (DateTime.Compare(iDate, eDate) > 0)
                {
                    fail.InnerText = "La fecha de inicio no puede ser posterior a la de final";
                    fail.Visible = true;
                    return false;
                }
            }

            if (!flImage.HasFile)
            {
                fail.InnerText = "Debe incluir una imagen del vehículo";
                fail.Visible = true;
                return false;
            }

            return true;
        }

        private void CreateCar(string sql)
        {
            var userId = Session["id"].ToString();
            var plate = matriculaInput.Value;
            var data = datosInput.Value;
            var initDate = InicioInput.Value;
            var endDate = FinInput.Value;
            var city = ciudadInput.Value;
            var brand = marcaInput.Value;
            var model = modeloInput.Value;
            var type = tipoInput.Value;
            var power = potenciaInput.Value;
            var doors = puertasInput.Value;
            var price = precioInput.Value;
            var imag = Image.FromStream(flImage.PostedFile.InputStream);
            var condition = adicionalesInput.Value;
            

            var relativeRoute = HttpContext.Current.Server.MapPath(@"\BDcoches.db");
            var connstring = "data source=" + relativeRoute;
            using (var db = new SQLiteConnection(connstring))
            {
                db.Open();

                using (var cmd = new SQLiteCommand(sql, db))
                {
                    try
                    {
                        cmd.Parameters.Add("@userId", DbType.Int32).Value = userId;
                        cmd.Parameters.Add("@plate", DbType.String).Value = plate;
                        cmd.Parameters.Add("@data", DbType.String).Value = data;
                        cmd.Parameters.Add("@initDate", DbType.String).Value = initDate;
                        cmd.Parameters.Add("@endDate", DbType.String).Value = endDate;
                        cmd.Parameters.Add("@img", DbType.Binary).Value =
                            ConvertImageToByteArray(imag, ImageFormat.Png);
                        cmd.Parameters.Add("@city", DbType.String).Value = city;
                        cmd.Parameters.Add("@brand", DbType.String).Value = brand;
                        cmd.Parameters.Add("@model", DbType.String).Value = model;
                        cmd.Parameters.Add("@power", DbType.Int32).Value = power;
                        cmd.Parameters.Add("@doors", DbType.Int32).Value = doors;
                        cmd.Parameters.Add("@type", DbType.String).Value = type;
                        cmd.Parameters.Add("@price", DbType.Int32).Value = price;
                        cmd.Parameters.Add("@condition", DbType.String).Value = condition;

                        cmd.ExecuteNonQuery();
                        success.Visible = true;
                    }
                    catch
                    {
                        fail.InnerText = "Ya existe un vehiculo con esta matricula";
                        fail.Visible = true;
                    }

                    Response.Redirect("/Profile?profile_id=" + Session["id"]);
                }

                db.Close();
            }
        }

        private byte[] ConvertImageToByteArray(Image imageToConvert,
            ImageFormat formatOfImage)
        {
            byte[] ret;
            using (var ms = new MemoryStream())
            {
                imageToConvert.Save(ms, formatOfImage);
                ret = ms.ToArray();
            }

            return ret;
        }
    }
}