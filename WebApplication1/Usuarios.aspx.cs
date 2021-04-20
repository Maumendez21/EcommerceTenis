using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace WebApplication1
{
    public partial class Usuarios : SeguridadFree
    {
        DAL db = new DAL();
        Usuario user1 = null;
        
        protected void Page_Load(object sender, EventArgs e)
        {

            // se obtiene el usuario que ah iniciado sesión
            user1 = (Usuario)Session["userFree"];
            Label1.Text = user1.Nombre;
            Label2.Text = user1.Username;
            username.Text = user1.Nombre;

            // se carga el datagrid y se inicializan las variables en la vista
            cargarProduct();

           

        }

        public void cargarProduct()
        {
            // se llena la tabla de productos
            DataSet DSProd = db.Grids("product");
            GridView1.DataSource = DSProd.Tables[0];
            GridView1.DataBind();

        }
        int cant;
        double total;
        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // pregunta si hay valores en las variabkes 
            if ( Convert.ToInt32(ViewState["cant"]) == 0 && Convert.ToDouble(ViewState["total"]) == 0)
            {
                // si no hay, se inicializan las variables
                cant = 1;
                total +=  Convert.ToDouble(GridView1.SelectedRow.Cells[4].Text);
            }
            else
            {
                // si hay algun valor se incrementa la variable catidad
                cant = Convert.ToInt32(ViewState["cant"]) + 1;
                // si hay algún valor se acumula la variable total
                total = Convert.ToDouble(ViewState["total"]) +  Convert.ToDouble(GridView1.SelectedRow.Cells[4].Text);
            }

            // Se guardan los valores en las Variables ViewState para poder ser usadas en la app
            ViewState["cant"] = cant;
            ViewState["total"] = total;

            // se musestran las variables
            lblCant.Text = cant.ToString();
            lblTotal.Text = total.ToString();

        }

        protected void btnVerCompras_Click(object sender, EventArgs e)
        {
            // Redirecciona a la pagina de compras por usuario
            Response.Redirect("Compras.aspx");
        }

        protected void btnComprar_Click(object sender, EventArgs e)
        {
            int cantidad = Convert.ToInt32(ViewState["cant"]);
            double total = Convert.ToDouble(ViewState["total"]);

            // Se ejecuta la compra
            string resp = db.comprar(user1.id, cantidad, total);

            if (resp == "OK")
            {
                Response.Redirect("Compras.aspx");
            }
            else
            {
                Response.Write("<script>alert('ERROR')</script>");
            }
        }
    }
}