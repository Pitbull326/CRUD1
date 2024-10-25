using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace CRUD1.Sources.Pages
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        readonly SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString);

        protected void Registrarse(object sender, EventArgs e)
        {
            Response.Redirect("/Sources/Pages/Registro.aspx");
        }

        protected void Iniciar(object sender, EventArgs e)
        {
           if(tbUsuario.Text =="" || tbClave.Text =="")
            {
                lblError.Text = "Los campos no deben quedar vacios";
            }
            else
            {
                string patron = "InfoToolsSV";
                using (con)
                {
                    using (SqlCommand cmd= new SqlCommand("Validar", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@Usuario", SqlDbType.VarChar).Value = tbUsuario.Text;
                        cmd.Parameters.Add("@Clave", SqlDbType.VarChar).Value = tbClave.Text;
                        cmd.Parameters.Add("@Patron", SqlDbType.VarChar).Value = patron;
                        con.Open();
                        SqlDataReader dr = cmd.ExecuteReader();
                        if (dr.Read())
                        {
                            Session["usuariologueado"] = dr["Id"].ToString();
                            Response.Redirect("/Sources/Pages/Index.aspx");
                        }
                        else 
                        {
                            lblError.Text = "Usuario o contraseña son incorrectas";
                        }
                        con.Close();
                    }
                }
            }
        }
    }
}