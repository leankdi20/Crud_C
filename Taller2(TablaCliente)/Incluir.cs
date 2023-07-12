using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Taller2_TablaCliente_
{
    public partial class Incluir : Form
    {

        Class_Cliente cliente = new Class_Cliente();

        Class_ConectionSQL conexion = new Class_ConectionSQL();
        public Incluir()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            //Iniciar la conexion
            conexion.OpenConnection();


            //LLenar la tabla que se muestra en la pantalla
            cliente.incluir(conexion.Connection, textBox1.Text,textBox2.Text,textBox3.Text,comboBox1.Text,textBox4.Text,textBox5.Text);



            //CERRAR LA CONEXION
            conexion.CloseConnection();

            
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

            conexion.CloseConnection();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //Esto hace que de la tabla se reflejen los datos en cada textBox corresponientes
            //Cuando comienza del [0] es por la posicion de la columba de la tabla.
            textBox1.Text = dataGridView1.SelectedCells[0].Value.ToString();
            textBox2.Text = dataGridView1.SelectedCells[1].Value.ToString();
            textBox3.Text = dataGridView1.SelectedCells[2].Value.ToString();
            textBox4.Text = dataGridView1.SelectedCells[3].Value.ToString();
            textBox5.Text = dataGridView1.SelectedCells[4].Value.ToString();
        }

        private void Incluir_Load(object sender, EventArgs e)
        {
            cliente.Consulta(dataGridView1);
        }
    }
}
