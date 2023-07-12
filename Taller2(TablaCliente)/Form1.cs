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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Class_Cliente cliente = new Class_Cliente();


        private void button1_Click(object sender, EventArgs e)
        {
            Incluir agregar = new Incluir();    
            agregar.Show();
            cliente.llenar_tabla();
            // prueba

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Modificar modificar = new Modificar();  
            modificar.Show();   
        }







        //Cambiar colores de botones1
        private void button1_MouseEnter_1(object sender, EventArgs e)
        {
            button4.BackColor = Color.Aqua;
        }
        private void button1_MouseLeave_1(object sender, EventArgs e)
        {
            button4.BackColor = SystemColors.ActiveCaption;
        }


        //Cambiar color de boton 2
        private void button2_MouseEnter_1(object sender, EventArgs e)
        {
            button4.BackColor = Color.Aqua;
        }

        private void button2_MouseLeave_1(object sender, EventArgs e)
        {
            button4.BackColor = SystemColors.ActiveCaption;
        }

        //Cambiar color de boton 3
        private void button3_MouseEnter_1(object sender, EventArgs e)
        {
            button4.BackColor = Color.Aqua;
        }

        private void button3_MouseLeave_1(object sender, EventArgs e)
        {
            button4.BackColor = SystemColors.ActiveCaption;
        }

        //Cambiar colores de boton 4
        private void button4_MouseEnter(object sender, EventArgs e)
        {
            button4.BackColor = Color.Aqua;
        }

        private void button4_MouseLeave(object sender, EventArgs e)
        {
            button4.BackColor = SystemColors.ActiveCaption;
        }
        //--------------------------------------------------------------------//
        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Mostrar mostrar = new Mostrar();
            mostrar.Show();
        }

       
    }
}
