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

namespace proveedoresCliente
{
    public partial class Cliente : Form
    {
        //Instancias
        //Conexion objeto del tipo SqlConnection para conectarnos fisicamente a la base de datos
        SqlConnection Conexion = new SqlConnection();
        //Comando objeto del tipo SqlCommand para representar instrucciones SQL
        SqlCommand Comando;
        //Adaptador objeto del tipo SqlDataAdapter para para intercambiar datos entre una
        // fuente de datos (en este caso Sql Server) y un almacen de datos (DataSet, DataTable,DataReader)
        SqlDataAdapter Adaptador = null;
        //Tabla objeto del tipo DataTable representa una colección de registros en memeria del cliente
        DataTable Tabla = new DataTable();
        //Variables
        string Sql = " "; //Variable de tipo String para almacenar instrucciones SQL
        //Variable de tipo String para almacenar el nombre de la Instancia SQLServer nombre del servidor
        string Servidor = @"ELITEBOOK8470P\ASAS";
        //Variable de tipo String para almacenar el nombre de la base de datos
        string Base_Datos = "proveedorCliente";
        int indice = 0;

        //Metodo Conectar *********************************************************************
        void Conectar()
        {
            try
            {
                //Para establecer la conexion con el servidor debemos usar el objeto Conexion
                //especificando a traves de su propiedad ConnectionString el nombre del servidor, la bases de datos
                //y el tiempo de seguridad
                Conexion.ConnectionString = "Data Source=" + Servidor + ";" +
                "Initial Catalog=" + Base_Datos + ";" +
                "Integrated security=true";
                try
                //Bloque try catch para captura de exepciones en ejecución
                {
                    Conexion.Open(); //Abrimos la conexión
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("ClientesBDError al tratar de establecer la conexión " + ex.Message);
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error en la conexión: " + ex.Message);
            }
        }

        //Este método recibe como parámetro un índice correspondiente al registro a cargar
        /*void CargarDatos(int indice)
        {
            if (Tabla.Rows.Count > 0) //Si el objeto Tabla posee registros procedemos a realizar la asignación
            {
                DataRow fila = Tabla.Rows[indice]; //Creamos una fila del Objeto Tabla
                //Asignamos los valores correspondientes a cada registro
                nombre.Text = fila["nombre"].ToString();
                telefono.Text = fila["telefono"].ToString();
                direccion.Text = fila["direccion"].ToString();
            }
            else
            {
                MessageBox.Show("No hay registros para mostrar");
            }
        }
        */
        //Metodo para refrescar el DataTable despues de insertar,modificar o eliminar registros
        void RefrescarDatos()
        {
            //seleccionamos todos los datos de la tabla personal
            Sql = "select * from cliente";
            //SqlDataAdapter 
            Adaptador = new SqlDataAdapter(Sql, Conexion); //pasamos los parametros al adaptador
            Tabla.Clear(); //limpiamos antes de llenar el objeto oTabla
            Adaptador.Fill(Tabla); //llenamos la tabla
        }

        public Cliente() //Constructor de la clase
        {
            InitializeComponent();
        }

        private void Cliente_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'proveedorClienteDataSet.cliente' table. You can move, or remove it, as needed.
            this.clienteTableAdapter.Fill(this.proveedorClienteDataSet.cliente);
            Conectar();
            //Cargamos el objeto tabla con todos los registros de la tabla estudiantes
            Sql = "select * from cliente";
            Adaptador = new SqlDataAdapter(Sql, Conexion);
            Adaptador.Fill(Tabla);
            //Llamamos el metodo CargarDatos para tan pronto se lance el formulario asigne
            //a las cajas de texto los valores correspondientes al primer registro de la tabla
            //CargarDatos(indice);
        }

        void recargarGrid()
        {
            this.clienteTableAdapter.Fill(this.proveedorClienteDataSet.cliente);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Instrucción SQL
            Sql = "insert into cliente(nombre,telefono,direccion)values(@nombre,@telefono,@direccion)";
            //Pasamos al objeto comando la instrucción SQL a ejecutar y el objeto Conexion
            Comando = new SqlCommand(Sql, Conexion);
            Comando.Parameters.AddWithValue("@nombre", nombre.Text);
            Comando.Parameters.AddWithValue("@telefono", telefono.Text);
            Comando.Parameters.AddWithValue("@direccion", direccion.Text);
            try //Bloque try catch para captura de exepciones en ejecución
            {
                Comando.ExecuteNonQuery(); //Ejecutamos la instrucción SQL
                MessageBox.Show("Registro insertado");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            nombre.Text = "";
            telefono.Text = "";
            direccion.Text = "";
            recargarGrid();
        }

        private void id_TextChanged(object sender, EventArgs e)
        {

        }

        private void nombre_TextChanged(object sender, EventArgs e)
        {

        }

        private void telefono_TextChanged(object sender, EventArgs e)
        {

        }

        private void direccion_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
