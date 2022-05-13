using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;//agregar esta instruccion para la conexion
using System.Data.OleDb;


namespace proveedoresCliente
{
    public partial class Proveedor : Form
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
        string Servidor = @"LAPTOP-407DBCNR";
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

        /*void CargarDatos(int indice)
        {
            if (Tabla.Rows.Count > 0) //Si el objeto Tabla posee registros procedemos a realizar la asignación
            {
                DataRow fila = Tabla.Rows[indice]; //Creamos una fila del Objeto Tabla
                                                   //Asignamos los valores correspondientes a cada registro
              
                nombreProveedor.Text = fila["nombreProveedor"].ToString();
                telefono.Text = fila["telefono"].ToString();
                direccion.Text = fila["direccion"].ToString();
              
            }
            else
            {
                MessageBox.Show("No hay registros para mostrar");
            }
        }*/

        void RefrescarDatos()
        {
            //seleccionamos todos los datos de la tabla personal
            Sql = "select * from proveedor";
            //SqlDataAdapter 
            Adaptador = new SqlDataAdapter(Sql, Conexion); //pasamos los parametros al adaptador
            Tabla.Clear(); //limpiamos antes de llenar el objeto oTabla
            Adaptador.Fill(Tabla); //llenamos la tabla
        }

        public Proveedor()
        {
            InitializeComponent();
        }

       

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Instrucción SQL
            Sql = "insert into proveedor(nombreProveedor,telefono,direccion)" +
                "values(@nombreProveedor,@telefono,@direccion)";
            //Pasamos al objeto comando la instrucción SQL a ejecutar y el objeto Conexion
            Comando = new SqlCommand(Sql, Conexion);
            Comando.Parameters.AddWithValue("@nombreProveedor", nombreProveedor.Text);
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
            nombreProveedor.Text = "" ;
            telefono.Text = "";
            direccion.Text = "";
        }

        private void Proveedor_Load_1(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'proveedorClienteDataSet.proveedor' Puede moverla o quitarla según sea necesario.
            this.proveedorTableAdapter.Fill(this.proveedorClienteDataSet.proveedor);
            Conectar();
            //Cargamos el objeto tabla con todos los registros de la tabla estudiantes
            Sql = "select * from proveedor";
            Adaptador = new SqlDataAdapter(Sql, Conexion);
            Adaptador.Fill(Tabla);
            //Llamamos el metodo CargarDatos para tan pronto se lance el formulario asigne
            //a las cajas de texto los valores correspondientes al primer registro de la tabla
            //CargarDatos(indice);

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void nombreProveedor_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
