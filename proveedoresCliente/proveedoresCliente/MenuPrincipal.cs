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
            Cliente  Cli= new Cliente();
            Cli.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Proveedor Pro = new Proveedor();
            Pro.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Factura Facu = new Factura();
            Facu.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Producto Produ = new Producto();
            Produ.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Detalles_Factura DetaFacu= new Detalles_Factura();
            DetaFacu.Show();
        }

        private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cliente Cli = new Cliente();
            Cli.Show();
        }

        private void proveedorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Proveedor Pro = new Proveedor();
            Pro.Show();
        }

        private void facturaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Factura Facu = new Factura();
            Facu.Show();
        }

        private void productoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Producto Produ = new Producto();
            Produ.Show();
        }

        private void detallesFacturaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Detalles_Factura DetaFacu = new Detalles_Factura();
            DetaFacu.Show();
        }
    }
}
