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
    public partial class Mostrar : Form
    {


        Class_Cliente cliente = new Class_Cliente();

        public Mostrar()
        {
            InitializeComponent();
        }

        private void Mostrar_Load(object sender, EventArgs e)
        {
          
            cliente.Consulta(dataGridView1);
            cliente.llenar_tabla();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
