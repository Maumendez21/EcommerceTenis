using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace WebApplication1
{
    public partial class Compras : SeguridadFree
    {
        DAL db = new DAL();
        protected void Page_Load(object sender, EventArgs e)
        {
            // se obtienen las compras realizadas por usuario y se muestran en el grid
            Usuario recibe = (Usuario)Session["userFree"];
            DataSet DSProd = db.Grids("compra", recibe.Nombre);
            GridView1.DataSource = DSProd.Tables[0];
            GridView1.DataBind();
        }
    }
}