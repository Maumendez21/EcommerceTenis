using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1
{
    public class SeguridadAdmin : System.Web.UI.Page
    {
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);

            // se valida que exista el usuario administrador
            if (Session["userAdmin"] == null)
                Response.Redirect("Login.aspx");
        }
    }
}