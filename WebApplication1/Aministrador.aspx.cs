using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace WebApplication1
{
    public partial class Aministrador : SeguridadAdmin
    {
        DAL db = new DAL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                // Se obtiene el usuario guardado en el inicio de sesión
                Usuario user1 = (Usuario)Session["userAdmin"];
                Label1.Text = user1.Nombre;
                Label2.Text = user1.Username;
                username.Text = user1.Nombre;
                cargarUser();
                cargarProduct();
            }
            
        }

        // se muestran los productos en el grid
        public void cargarProduct()
        {
            DataSet DSProd = db.Grids("product");
            GridView2.DataSource = DSProd.Tables[0];
            GridView2.DataBind();

        }

        // se muestran los usuarios en el grid
        public void cargarUser()
        {
            DataSet DSUser = db.Grids("user");
            GridView1.DataSource = DSUser.Tables[0];
            GridView1.DataBind();
        }

        public string id;
        public string rol;

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // se crean las variables de session para guardar el nombre y el id del usuario seleccionado
            Session["id"] = GridView1.SelectedRow.Cells[0].Text;
            Session["nom"] = GridView1.SelectedRow.Cells[1].Text;
            Response.Redirect("CambiarRol.aspx");
            id = GridView1.SelectedRow.Cells[0].Text;
            rol = GridView1.SelectedRow.Cells[3].Text;
        }

        

        protected void Cambiar_Click(object sender, EventArgs e)
        {
            
            
        }

        protected void Agregar_Click(object sender, EventArgs e)
        {
            // Se redirige a pagina que agrega productos nuevos
            Response.Redirect("AgregarProducto.aspx");
        }
    }
}