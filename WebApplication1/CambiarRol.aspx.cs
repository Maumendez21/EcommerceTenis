using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class CambiarRol : SeguridadAdmin
    {
        DAL db = new DAL();
        Usuario user1 = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            // se obtiene el nombre y id del usuario seleccionado en la pagina administrador
            user.Text = Session["nom"].ToString();;
            int id = Convert.ToInt32(Session["id"]);

            // se obtiene el usuario
            user1 = db.DevolverUser(id);


        }

        protected void Cambiar_Click(object sender, EventArgs e)
        {

            if (rol.Text == "ADMIN" || rol.Text == "USER")
            {
                
                // se hace el cambio de rol 
                string entrada = db.CambiarRol(user1.id.ToString(), rol.Text);
                if (entrada == "si")
                {
                    Response.Redirect("Aministrador.aspx");
                }
                else
                {
                    Response.Write("<script>alert('ERROR')</script>");
                }
            }
            else
            {
                Response.Write("<script>alert('Debe ser ADMIN O USER')</script>");
            }

        }

        protected void regresar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Aministrador.aspx");
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        protected void DropDownList1_SelectedIndexChanged1(object sender, EventArgs e)
        {
            
        }
    }
}