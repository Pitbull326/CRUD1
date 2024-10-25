﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CRUD1.Sources.Pages
{
    public partial class MP : System.Web.UI.MasterPage
    {

        readonly SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Session["usuariologueado"]!=null)
            {
                int id = int.Parse(Session["usuariologueado"].ToString());
                using (con)
                {
                    using (SqlCommand cmd = new SqlCommand("Perfil", con))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.Add("@Id", System.Data.SqlDbType.Int).Value = id;
                        con.Open();
                        SqlDataReader dr = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
                        dr.Read();
                        this.lblUsuario.Text = dr["Apellidos"].ToString() + "," + dr["Nombres"].ToString();
                        imgPerfil.ImageUrl = "/Sources/Pages/Imagen.aspx?id=" + id;
                        
                    }
                }
            }
            else
            {
                Response.Redirect("/Sources/pages/Login.aspx");
            }
        }

        protected void Perfil(object sender, EventArgs e)
        {
            Response.Redirect("/Sources/Pages/Perfil.aspx");
        }

        protected void Salir(object sender, EventArgs e)
        {
            Session.Remove("usuariologueado");
            Response.Redirect("/Sources/Pages/Login.aspx");
        }
    }
}