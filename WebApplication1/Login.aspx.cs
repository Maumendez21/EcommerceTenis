using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class Login : System.Web.UI.Page
    {
        
        DAL db = new DAL();
        protected void Page_Load(object sender, EventArgs e)
        {
            Label1.Text = db.probar();
            Session["userAdmin"] = null;
            Session["userFree"] = null;
        }

        protected void entrar_Click(object sender, EventArgs e)
        {
            // Se llama a la función para verificar que exista el usuario 
            Usuario usuario = db.Verify(user.Text, pswd.Text);
            if (usuario != null)
            {
                // Si existe se redirecciona al index y se guarda el usuario
                if (usuario.Rol == "ADMIN")
                {
                     Session["userAdmin"] = usuario;
                     Response.Redirect("Aministrador.aspx");
                }
                else if (usuario.Rol == "USER")
                {
                     Session["userFree"] = usuario;
                     Response.Redirect("Usuarios.aspx");
                }
            }
            else
            {
                Response.Write("<script>alert('Datos incorrectos')</script>");
            }
        }
    }
}