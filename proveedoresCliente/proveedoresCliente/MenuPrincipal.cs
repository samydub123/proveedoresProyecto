using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace proveedoresCliente
{
    public partial class MenuPrincipal : Form
    {
        public MenuPrincipal()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void MenuPrincipal_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Animales animales = new Animales();
            animales.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Ecosistemas eco = new Ecosistemas();
            eco.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Eventos eventos = new Eventos();
            eventos.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Empleados emp = new Empleados();
            emp.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Instituciones inst = new Instituciones();
            inst.Show();
        }

        private void empleadosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Empleados emp = new Empleados();
            emp.Show();
        }

        private void animalesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Animales animales = new Animales();
            animales.Show();
        }

        private void eventosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Eventos eventos = new Eventos();
            eventos.Show();
        }

        private void institucionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Instituciones inst = new Instituciones();
            inst.Show();
        }

        private void ecosistemasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Ecosistemas eco = new Ecosistemas();
            eco.Show();
        }
    }
}
