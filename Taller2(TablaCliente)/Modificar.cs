using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Taller2_TablaCliente_
{
    public partial class Modificar : Form
    {

        Class_Cliente cliente = new Class_Cliente();
        Class_ConectionSQL conexion = new Class_ConectionSQL();

        public Modificar()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Iniciar conexion
            conexion.OpenConnection();

            //Llamar metodo
            cliente.Modificar(conexion.Connection, textBox1.Text, textBox2.Text, textBox3.Text, comboBox1.Text, textBox4.Text,textBox5.Text );

            cliente.llenar_tabla();

            //Limpia consola
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            comboBox1.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";

            if (conexion.Estado)
            {
                DataTable dt = cliente.llenar_tabla();
                dataGridView1.DataSource = dt;
                conexion.CloseConnection();
            }

            //Cerrar Conexion
            conexion.CloseConnection();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
         
        }

        private void Modificar_Load(object sender, EventArgs e)
        {
            cliente.Consulta(dataGridView1);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //Esto hace que de la tabla se reflejen los datos en cada textBox corresponientes
            //Cuando comienza del [0] es por la posicion de la columba de la tabla.
            textBox1.Text = dataGridView1.SelectedCells[0].Value.ToString();
            textBox2.Text = dataGridView1.SelectedCells[1].Value.ToString();
            textBox3.Text = dataGridView1.SelectedCells[2].Value.ToString();
            comboBox1.Text= dataGridView1.SelectedCells[3].Value.ToString();
            textBox4.Text = dataGridView1.SelectedCells[4].Value.ToString();
            textBox5.Text = dataGridView1.SelectedCells[5].Value.ToString();
        }


        //Boton Buscar
        private void button3_Click(object sender, EventArgs e)
        {
            cliente.Buscar(dataGridView1, textBox6.Text);                 
        }

        private void button4_Click(object sender, EventArgs e)
        {


            cliente.Eliminar(textBox1.Text);

            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
        }
    }
}
