using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class AgregarProducto : SeguridadAdmin
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }
        // instacia de la base de datos
        DAL db = new DAL();
        Productos prod = null;
        protected void Guardar_Click(object sender, EventArgs e)
        {
            // se crea el nuevo producto tomando la información de los texbox
            prod = new Productos()
            {
                Nombre = nombre.Text,
                Stock = Convert.ToInt32(stock.Text),
                Precio = Convert.ToDouble(precio.Text),
                Descripcion = desc.Text
            };

            // se ejecuta el metodo que guarda el producto
            string entrada = db.GuardarProducto(prod);
            if (entrada == "OK")
            {
                Response.Redirect("Aministrador.aspx");
            }
            else
            {
                Response.Write("<script>alert('ERROR')</script>");
            }
        }
    }
}