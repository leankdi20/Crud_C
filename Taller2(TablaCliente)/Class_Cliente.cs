using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using System.Windows.Forms;
using System.Data;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Taller2_TablaCliente_
{
    internal class Class_Cliente
    {
        
        public Class_Cliente()
        { 
            
        }


        Class_ConectionSQL conexion = new Class_ConectionSQL();

        public DataTable llenar_tabla()
        {
            DataTable dt = new DataTable();
            try
            {
                conexion.OpenConnection();

                if (conexion.Estado)
                {
                    String consulta = "Select * from Clientes";
                    SqlDataAdapter adaptador = new SqlDataAdapter(consulta, conexion.Connection);

                    adaptador.Fill(dt);

                   conexion.CloseConnection();
                }
                else
                {
                    MessageBox.Show("Atención: No se pudo establecer conexion con la BD");
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error closing connection: " + ex.Message);
                MessageBox.Show("Atención: " + ex.Message);
                //throw; // Vuelve a lanzar la excepción para manejarla en el nivel superior
            }
            return dt;
        }

        public void incluir(SqlConnection conexion, String codigo,String nombre,String direccion, String provincia, String telefono,
                            String correoElectronico)
        {
            try
            {

                // LEANDRO acá deberías abrir la conexión

                String cadena = "insert into Clientes (Codigo, Nombre, Direccion, provincia, Telefono, CorreoElectronico)"
                + " values ( '" + int.Parse(codigo) + "' , '" + nombre + "' , '" + direccion + "' , '"+ provincia+ "' , '" + int.Parse(telefono) + "' , '" + correoElectronico + "' )";

                //Define el comando de ejecusion
                SqlCommand comando = new SqlCommand(cadena, conexion);

                //Ejecutar comando
                int rowsAffected = comando.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    MessageBox.Show("La consulta se ejecutó exitosamente. Filas afectadas: " + rowsAffected);
                }
                else
                {
                    MessageBox.Show("La consulta no afectó ninguna fila en la base de datos.");
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error closing connection: " + ex.Message);
                MessageBox.Show("Atención: " + ex.Message);
                //throw; // Vuelve a lanzar la excepción para manejarla en el nivel superior
            }
        }

         

        public void Modificar(SqlConnection conexion, String codigo, String nombre, String direccion, String provincia, String telefono, String correoElectronico) 
        {

            
            try
            {
                string cadena = "UPDATE Clientes set Nombre='" + nombre + "', Direccion='" + direccion + "', Provincia='" +
                                provincia + "',Telefono='" + telefono + "', CorreoElectronico='" + correoElectronico + "' WHERE Codigo='" + codigo + "'";

            SqlCommand comando = new SqlCommand(cadena, conexion);

            int cantidad_modificados = comando.ExecuteNonQuery();
            if (cantidad_modificados == 1)
            {
                MessageBox.Show("Se modificaron los datos");
            }
            else
                MessageBox.Show("No existe un nombre con ese referente");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error closing connection: " + ex.Message);
                MessageBox.Show("Atención: " + ex.Message);
                //throw; // Vuelve a lanzar la excepción para manejarla en el nivel superior
            }

            

        }


        public void Eliminar(String eliminar) 
        {
            conexion.OpenConnection();

            String cadena = "Delete from Clientes where Codigo ='" + eliminar + "'";
            SqlCommand comando = new SqlCommand(cadena, conexion.Connection);
            //Esta variable permite detectar cuantos registros fueron borrados

            int cantidad_borrados = comando.ExecuteNonQuery();
            if (cantidad_borrados == 1)
            {

                MessageBox.Show("El registro fue borrado");

            }
            else
                MessageBox.Show("La identificacion no existe");
          

            llenar_tabla();

            conexion.CloseConnection();

        }

        public void Buscar(DataGridView dataGridView1, String buscar) 
        {
            try
            {
                conexion.OpenConnection();
                
                string consulta = "SELECT * FROM Clientes WHERE UPPER(Codigo) LIKE '%" + buscar + "%' OR UPPER(Nombre) LIKE '%" + buscar + "%' OR UPPER(Provincia) LIKE '%" + buscar + "%'";

                SqlDataAdapter adaptador = new SqlDataAdapter(consulta, conexion.Connection);

                // Creo una tabla virtual de consulta
                DataTable dataTable = new DataTable();

                //Ahora hay que llenar el dataTable con lo que tiene el adaptador

                adaptador.Fill(dataTable);
                //ahora se va a reglejar en el siguiente tablero del diseño
                dataGridView1.DataSource = dataTable;

                SqlCommand comando = new SqlCommand(consulta, conexion.Connection);

                //Permite leer los datos en el DataTable y extraerlos.
                SqlDataReader lector;
                lector = comando.ExecuteReader();
            }


            catch (Exception ex)
            {
                MessageBox.Show("Error: No se encontro usuario" + ex.Message);
            }
            finally
            {
                conexion.CloseConnection();
            }

        }

        public void Mostrar() 
        {
        
        
        }

        public void llenar_tabla(DataGridView dataGridView1, String conexion)
        {
            String consulta = "Select * from Clientes";
            SqlDataAdapter adaptador = new SqlDataAdapter(consulta, conexion);
            DataTable dt = new DataTable();
            adaptador.Fill(dt);
            dataGridView1.DataSource = dt;

        }

        public void Consulta(DataGridView dataGridView1)
        {
            string consulta = "select * from Clientes";
            SqlDataAdapter adaptador = new SqlDataAdapter(consulta, conexion.Connection);
            DataTable dt = new DataTable();
            adaptador.Fill(dt);
            dataGridView1.DataSource = dt;


        }
    }
}
