using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1
{
    public class SeguridadFree : System.Web.UI.Page
    {
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            // Se valida que exista el usuario normal
            if (Session["userFree"] == null)
                Response.Redirect("Login.aspx");
        }
    }
}