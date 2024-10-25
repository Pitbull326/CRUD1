using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Data;

namespace CRUD1.Source.Pages
{
    public partial class Registro : System.Web.UI.Page
    {
        protected void Cancelar(object sender, EventArgs e)
        {
            Response.Redirect("/Sources/Pages/Login.aspx");
        }
        readonly SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString);

        protected void Registrar(object sender, EventArgs e)
        {
            int tamanioimagen = int.Parse(FUImage.FileContent.Length.ToString());
            string contrasenasinverificar = tbClave.Text;
            Regex letras = new Regex(@"[a-zA-Z]");
            Regex numeros = new Regex(@"[0-9]");
            Regex especiales = new Regex("[!\"#\\$%&'()*+,-./:;=?@\\[\\]{|}~]");
            con.Open();
            SqlCommand usuario = new SqlCommand("ContarUsuario",con)
            {
                CommandType = CommandType.StoredProcedure
            };
            usuario.Parameters.Add("@usuario", SqlDbType.VarChar).Value = tbUsuario.Text;
            int user = Convert.ToInt32(usuario.ExecuteScalar());
            if (tbNombre.Text == "" || tbApellido.Text == "" || tbFecha.Text == "" || tbUsuario.Text == "")
            {
                lblError.Text = "Los campos no pueden quedar vacios";
            }
            else if (user >= 1)
            {
                lblError.Text = "El usuario " + tbUsuario.Text + "ya existe";
            }
            else if (tbClave.Text != tbClave2.Text)
            {
                lblError.Text = "contraseña no coincide!";
            }
            else if (!letras.IsMatch(contrasenasinverificar))
            {
                lblError.Text = "la contraseña debe tener letras!";
            }
            else if (!numeros.IsMatch(contrasenasinverificar))
            {
                lblError.Text = "la contraseña debe tener numeros";
            }
            else if (!especiales.IsMatch(contrasenasinverificar))
            {
                lblError.Text = "la contraseña debe tener caracteres especiales";
            }
            else if (!FUImage.HasFile)
            {
                lblError.Text = "No se ha cargado imagen para su perfil";
            }
            else
            {
                byte[] imagen = FUImage.FileBytes;
                string patron = "InfoToolsSV";
                using (con)
                {
                    using (SqlCommand cmd=new SqlCommand("Registrar", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@Nombres", SqlDbType.VarChar).Value = tbNombre.Text;
                        cmd.Parameters.Add("@Apellidos", SqlDbType.VarChar).Value = tbApellido.Text;
                        cmd.Parameters.Add("@Fecha", SqlDbType.Date).Value = tbFecha.Text;
                        cmd.Parameters.Add("@Usuario", SqlDbType.VarChar).Value = tbUsuario.Text;
                        cmd.Parameters.Add("@Clave", SqlDbType.VarChar).Value = tbClave.Text;
                        cmd.Parameters.Add("@Patron", SqlDbType.VarChar).Value = patron;
                        cmd.Parameters.Add("@Imagen", SqlDbType.Image).Value = imagen;
                        cmd.Parameters.Add("@IdUsuario", SqlDbType.Int).Value = 0;
                        cmd.ExecuteNonQuery();
                    }
                    con.Close();
                    Response.Redirect("/Sources/Pages/Login.aspx");
                }
            }
        }
    }
}