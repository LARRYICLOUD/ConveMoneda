using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace ConveMoneda
{
    /// <summary>
    /// Descripción breve de Moneda
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class Moneda : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hola a todos";
        }
        [WebMethod]

        public double convertir(double dolares, double peso)

        {
            dolares = 4750;
            double resultado = dolares * peso;
            return resultado;
        }
        [WebMethod]

        public double conver(double dolares, double peso)

        {
            dolares = 4750;
            double resultado = peso / dolares;
            return dolares;
        }
        [WebMethod]

        public double conve(double euros, double peso)

        {
            euros = 5.098;
            double resultado = euros * peso;
            return euros;
        }
        [WebMethod]

        public double conveuros(double euros, double peso)

        {
            euros = 5.098;
            double resultado = peso / euros;
            return euros;
        }


        [WebMethod]
        public DataSet Consultarempleadoss()

        {
            string cadenaConexion = "Data Source=localhost;Initial Catalog=Empleadoss;Integrated Security=True";

            using (SqlConnection cn = new SqlConnection(cadenaConexion))
            {
                SqlDataAdapter da = new SqlDataAdapter("select * from usuarios", cn);
                DataSet ds = new DataSet();
                da.Fill(ds);
                return ds;
            }
        }


        [WebMethod]
        public Empleados Consultarid_usuario(string id)

        {
            string cadenaConexion = "Data Source=localhost;Initial Catalog=Empleadoss;Integrated Security=True";

            using (SqlConnection cn = new SqlConnection(cadenaConexion))
            {
                SqlDataAdapter da = new SqlDataAdapter("select id_usuario,nombre,usuario,contrasena,tipo_usuario,edad,sexo from usuarios where usuarios =" + id + "", cn);
                DataSet ds = new DataSet();
                
                Empleados empleados = new Empleados();
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    empleados.id_usuario = int.Parse(dr["id_usuario"].ToString());
                    empleados.nombre = dr["nombre"].ToString();
                    empleados.usuario = dr["usuario"].ToString();
                    empleados.contrasena = dr["contrasena"].ToString();
                    empleados.tipo_usuario = dr["tipo_usuario"].ToString();
                    empleados.edad = int.Parse(dr["edad"].ToString());
                    empleados.sexo = dr["sexo"].ToString();
                }
                return empleados;
            }
        }
        
        



    }
}

    

    



