using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text.RegularExpressions;

namespace CRUD1.Source.Pages
{
    public partial class Perfil : System.Web.UI.Page
    {
        readonly SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString);
        public static int id;
        protected void Page_Load(object sender, EventArgs e)
        {
            id = int.Parse(Session["usuariologueado"].ToString());
            if(Session["usuariologueado"]==null)
            {
                Response.Redirect("/Sources/Pages/Login.aspx");
            }
            else
            {
                using (con)
                {
                    using(SqlCommand cmd= new SqlCommand("Perfil",con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@Id", SqlDbType.Int).Value = id;
                        con.Open();
                        SqlDataReader dr = cmd.ExecuteReader();
                        if(dr.Read())
                        {
                            image.ImageUrl = "/Sources/Pages/Imagen.aspx?id=" + id;
                            this.tbNombres.Text = dr["Nombres"].ToString();
                            this.tbApellidos.Text = dr["Apellidos"].ToString();
                            this.tbFecha.Text = dr["Fecha"].ToString();
                            //tbFecha.Text = DateTime.Now.ToString("dd-mm-yyyy");
                            this.tbUsuario.Text = dr["Usuario"].ToString();
                            dr.Close();
                        }
                        con.Close();
                    }
                }
            }
        }
        void MetodoOcultar()
        {
            if(contrasenia.Visible == false)
            {
                contrasenia.Visible = true;
                BtnGuardar.Visible = true;
                BtnCambiar.Text = "Cancelar";
                lblErrorClave.Text = "";
            }
            else
            {
                contrasenia.Visible = false;
                BtnGuardar.Visible = false;
                BtnCambiar.Text = "Cambiar contraseña";
                lblErrorClave.Text = "";
            }
        }

        protected void BtnAplicar_Click(object sender, EventArgs e)
        {
            int tamanioarchivo;
            byte[] imagen = FUImage.FileBytes;
            tamanioarchivo = int.Parse(FUImage.FileContent.Length.ToString());
            if(tamanioarchivo >=2097151000)
            {
                lblError.Text = "el tamaño de la iamgen debe ser menor a 10 MB";
            }
            else if(FUImage.HasFile)
            {
                using (con)
                {
                    using (SqlCommand cmd = new SqlCommand("CambiarImagen",con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@imagen", SqlDbType.Image).Value = imagen;
                        cmd.Parameters.Add("@Id", SqlDbType.Int).Value = id;
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                        lblError.Text = "";
                    }
                }
            }
            else
            {
                lblError.Text = "No se a cargado una imagen nueva";
            }
        }

        protected void BtnCambiar_Click(object sender, EventArgs e)
        {
            MetodoOcultar();
        }

        protected void Eliminar(object sender, EventArgs e)
        {
            using (con)
            {
                using (SqlCommand cmd=new SqlCommand("Eliminar",con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@Id", SqlDbType.Int).Value = id;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    Session.Remove("usuariologueado");
                    Response.Redirect("/Sources/Pages/Login.aspx");
                }
            }
        }

        protected void BtnGuardar_Click(object sender, EventArgs e)
        {
            string contrasenasinverificar = tbClave.Text;
            Regex letras = new Regex(@"[a-zA-Z]");
            Regex numeros = new Regex(@"[0-9]");
            Regex especiales = new Regex("[!\"#\\$%&'()*+,-./:;=?@\\[\\]{|}~]");

            if (tbClave.Text ==""|| tbClave2.Text=="")
            {
                lblError.Text = "los campos estan vacios";
            }
            else if (tbClave.Text != tbClave2.Text )
            {
                lblError.Text = "contraseña no coincide";
            }
            else if (!letras.IsMatch(contrasenasinverificar))
            {
                lblError.Text = "La contraseña debe tener letras";
            }
           else
            {
                try
                {
                    using (con)
                    {
                        using (SqlCommand cmd = new SqlCommand("CambiarContrasenia", con))
                        {
                            string patron = "InfoToolsSV";
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
                            cmd.Parameters.Add("@Clave", SqlDbType.VarChar).Value = tbClave.Text;
                            cmd.Parameters.Add("Patron", SqlDbType.VarChar).Value = patron;
                            con.Open();
                            cmd.ExecuteNonQuery();
                            con.Close();
                            MetodoOcultar();
                            lblErrorClave.Text = "";
                        }
                    }

                }
                catch
                {

                }
            }
        }
    }
}