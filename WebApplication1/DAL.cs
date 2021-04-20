using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

namespace WebApplication1
{
    public class DAL
    {
        // variable donde se almacenará la cadena de conexión
        private string CC;

        public DAL()
        {
            // Se obtiene la cadena de conexión configuarada
            CC = System.Configuration.ConfigurationManager.ConnectionStrings["CCEcommerce"].ConnectionString;
        }

        // metodo para probar la conexión
        public string probar()
        {
            SqlConnection cn = new SqlConnection(CC);
            string msg;
            try
            {
                cn.Open();
                msg = "Online";
                cn.Close();
            }
            catch (Exception e)
            {

                msg = "Ofline";
            }
            return msg;
        }


        // Devuelve un usuario por id
        public Usuario DevolverUser(int id)
        {
            Usuario user = null;


            using (SqlConnection cn = new SqlConnection(CC))
            {
                try
                {
                    cn.Open();
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = cn;
                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.CommandText = "Select Id, Nombre, Edad, Username, Pwsd, Rol from dbo.Users where Id=@id;";
                        SqlDataReader lec = cmd.ExecuteReader();
                        while (lec.Read())
                        {
                            user = new Usuario()
                            {

                                id = (int)lec["Id"],
                                Nombre = (string)lec["Nombre"],
                                Edad = (string)lec["Edad"],
                                Username = (string)lec["Username"],
                                Pass = (string)lec["Pwsd"],
                                Rol = (string)lec["Rol"],
                            };
                        }
                    }
                    cn.Close();
                }
                catch (Exception)
                {

                    throw;
                }
                

            }

            return user;
        }

        // Método que verifica que el usuario exista
        public Usuario Verify(string name, string pwsd)
        {
            Usuario user = null;
            using (SqlConnection cn = new SqlConnection(CC))
            {
                // Se abre la conexión a la base de datos
                cn.Open();
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = cn;
                    // Se agregan parametros configurados
                    cmd.Parameters.AddWithValue("@Nombre", name);
                    cmd.Parameters.AddWithValue("@Password", pwsd);
                    // Sentencia que hace la consulta
                    cmd.CommandText = "Select Id, Nombre, Edad, Username, Pwsd, Rol from dbo.Users where Username=@Nombre and Pwsd=@Password;";
                    SqlDataReader lec = cmd.ExecuteReader();

                    // Se obtiene la respuesta y se lee en un while
                    while (lec.Read())
                    {
                        // Se crea el usuario consultado para devolverse
                        user = new Usuario()
                        {

                            id = (int)lec["Id"],
                            Nombre = (string)lec["Nombre"],
                            Edad = (string)lec["Edad"],
                            Username = (string)lec["Username"],
                            Pass = (string)lec["Pwsd"],
                            Rol = (string)lec["Rol"],
                        };
                    }
                }
                cn.Close();
            }
            return user;
        }

        // metodo que hace update al rol de un usuario por id
        public string CambiarRol(string id, string role)
        {
            string sql;
            string salida = "";
            using (SqlConnection cn = new SqlConnection(CC))
            {
                try
                {
                    cn.Open();
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        SqlDataAdapter da = new SqlDataAdapter();
                        sql = "update dbo.Users set Rol='" + role + "' where Id = '" + id + "'";
                        da.UpdateCommand = new SqlCommand(sql, cn);
                        da.UpdateCommand.ExecuteNonQuery();
                        cmd.Dispose();

                        salida = "si";

                    }
                    cn.Close();
                }
                catch (Exception)
                {

                    salida = "no";
                }

                

            }
            return salida;
        }

        // Metodo que guarda un producto nuevo
        public string GuardarProducto(Productos prod)
        {
            string salida = "";
            string sql;
            using (SqlConnection cn = new SqlConnection(CC))
            {
                try
                {
                    cn.Open();
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        SqlDataAdapter ad = new SqlDataAdapter();
                        sql = "insert into dbo.Products (Name, Stock, Price, Description) values('" + prod.Nombre + "', " + prod.Stock + ", " + prod.Precio + ", '" + prod.Descripcion + "')";
                        ad.InsertCommand = new SqlCommand(sql, cn);
                        ad.InsertCommand.ExecuteNonQuery();
                        cmd.Dispose();
                        salida = "OK";
                    }
                    cn.Close();
                }
                catch (Exception)
                {

                    salida = "Error";
                }
                
            }
            return salida;
        }


        // Metodo que registra la compra y la guarda en la base de datos
        public string comprar(int id, int cant, double total)
        {
            string salida = "";
            string sql;
            using (SqlConnection cn = new SqlConnection(CC))
            {
                try
                {
                    cn.Open();
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        SqlDataAdapter ad = new SqlDataAdapter();
                        sql = "insert into dbo.Compra (IdUsuario, CantProductos, Total) values(" + id + ", " + cant + ", " + total + ")";
                        ad.InsertCommand = new SqlCommand(sql, cn);
                        ad.InsertCommand.ExecuteNonQuery();
                        cmd.Dispose();
                        salida = "OK";
                    }
                    cn.Close();
                }
                catch (Exception)
                {

                    salida = "Error";
                }

            }
            return salida;
        }

        // Metodo automatizado para devolver información y mostrarla en grids pidiento el tipo de tabla que se quiere mostrar
        public DataSet Grids(string tipo, string id="")
        {
            DataSet salida = new DataSet();
            string Query = "";
            if (tipo == "user")
            {
                Query = "Select Id, Nombre, Edad, Rol from dbo.Users";
            }
            else if (tipo == "product")
            {
                Query = "Select IdProduct, Name, Stock, Price, Description from dbo.Products";
            }
            else if (tipo == "compra")
            {
                Query = "select Nombre, CantProductos, Total from dbo.Compra INNER JOIN dbo.Users on IdUsuario = Id where  Nombre = '" + id + "'";
            }

            using (SqlConnection cn = new SqlConnection(CC))
            {
                cn.Open();
                using (SqlDataAdapter DA = new SqlDataAdapter(Query, cn))
                {
                    DA.Fill(salida);
                }
                cn.Close();
            }
            return salida;
        }

    }
}