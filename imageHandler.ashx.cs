using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Web;
using System.IO;

namespace Sharefy_MDA
{
    /// <summary>
    /// Descripción breve de imageHandler
    /// </summary>
    public class imageHandler : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            var id = 0;
            if (context.Request.QueryString["id"] != null) id = Convert.ToInt32(context.Request.QueryString["id"]);
            context.Response.ContentType = "image/png";
            var strm = getImage(id);
            var buffer = new byte[4096];
            var byteSeq = strm.Read(buffer, 0, 4096);

            while (byteSeq > 0)
            {
                context.Response.OutputStream.Write(buffer, 0, byteSeq);
                byteSeq = strm.Read(buffer, 0, 4096);
            }
        }

        public Stream getImage(int id)
        {
            var relativeRoute = HttpContext.Current.Server.MapPath(@"\BDcoches.db");
            var connstring = "data source=" + relativeRoute;
            using (var db = new SQLiteConnection(connstring))
            {
                db.Open();
                using (var cmd = new SQLiteCommand("select Imagen from Coches WHERE Id=" + id, db))
                {
                    var img = cmd.ExecuteScalar();
                    try
                    {
                        return new MemoryStream((byte[])img);
                    }
                    catch
                    {
                        return null;
                    }
                    finally
                    {
                        db.Close();
                    }
                }
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}