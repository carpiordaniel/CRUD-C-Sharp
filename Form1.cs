using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;

namespace BaseDeDatos
{
    public partial class Form1 : Form
    {
        //bool conectado = true;
        //string user = "sda";
        //string pass = "masterkey";
        //string db = "PREUBA";
        //string server = "1000-1426LA";

        SqlConnection conexion = new SqlConnection(
"Persist Security Info= False; User ID=sa; Password=masterkey; Initial Catalog=PREUBA; Server=1000-1426LA ");

        public Form1()
        {
            InitializeComponent();
        }
        
        private void Button1_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    //SqlConnection conexion = new SqlConnection(
            //    //    "User ID=sa; Password=masterkey;  server=1000-1426LA; database=PREUBA; integrated security = false");

            //    SqlConnection conexion = new SqlConnection(

            //        //"User ID=sa;Password=mastserkey;database=PREUBA;Server=1000-1426LA; integrated security = false"

            //        "Persist Security Info=False;User ID=sa;Password=masterkey;Initial Catalog=PREUBA;Server=1000-1426LA"
            //        );
            //        conexion.Open();
            //        MessageBox.Show("Conexion exitosa");
            //        conexion.Close();
            //        MessageBox.Show("conexion cerrada");

            //}

            //catch (Exception err)
            //{
            //    MessageBox.Show("Ha ocurrido un Error: " + err.Message);
            //}

            //string user = "sa";
            //string pass = "masterkey";
            //string db = "PREUBA";
            //string server = "1000-1426LA";
            //try
            //{
            //    SqlConnection conexion = new SqlConnection(
            //        "Persist Security Info= False; User ID='" + user + "'; Password='" + pass + "'; Initial Catalog='" + db + "' ; Server='" + server + "'"
            //        );

            //    conexion.Open();
            //    MessageBox.Show("Conexion correcta");
            //    conexion.Close();
            //    MessageBox.Show("Conexion cerrada...");
            //}
            //catch (Exception err)
            //{
            //    MessageBox.Show("Ocurrió el siguiente error: " + err.Message);
            //    conectado = false;
            //}






        }

        private void Button2_Click(object sender, EventArgs e)
        {
            //  INSERTAR
            string user = "sa";
            string pass = "masterkey";
            string db = "PREUBA";
            string server = "1000-1426LA";
            try
            {
                SqlConnection conexion = new SqlConnection("Persist Security Info= False; User ID='" + user + "'; Password='" + pass + "'; Initial Catalog='" + db + "' ; Server='" + server + "'");
                conexion.Open();
                string nombre, edad, cargo, correo, consulta;
                nombre= txtnombre.Text;
                edad = txtedad.Text;
                cargo = txtcargo.Text;
                correo = txtcorreo.Text;


                if ((txtnombre.Text != "") && (txtedad.Text != "") && txtcargo.Text != "" && txtcorreo.Text != "")
                {

                consulta = "INSERT INTO EMPLEADOS (NOMBRE,EDAD,CARGO,CORREO) VALUES ('"+nombre+ "','" + edad + "','" + cargo + "','" + correo + "' )";

                SqlCommand ejecucion = new SqlCommand(consulta, conexion);
                ejecucion.ExecuteNonQuery();
                MessageBox.Show("Insertado correctamente");


                 txtnombre.Text ="";
                 txtedad.Text = "";
                 txtcargo.Text = "";
                 txtcorreo.Text = "";

                Button3_Click( sender,  e);

                }
                else
                {
                    MessageBox.Show("Los campos no pueden estar vacios");
                }


                conexion.Close();
                MessageBox.Show("Conexion cerrada...");
            }
            catch (Exception err)
            {
                MessageBox.Show("Ocurrió el siguiente error: " + err.Message);
              
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Button3_Click(object sender, EventArgs e)
        {
            //CONSULTAR
            string user = "sa";
            string pass = "masterkey";
            string db = "PREUBA";
            string server = "1000-1426LA";
            string consulta;

            try
            {
                SqlConnection conexion = new SqlConnection(
                    "Persist Security Info=False; User ID='"+user+"'; Password='"+pass+"'; Initial Catalog= '"+db+"'; Server='"+server+"'");
                conexion.Open();
                MessageBox.Show("Conexion correcta...");

                consulta = "SELECT * FROM EMPLEADOS";

                SqlDataAdapter miAdaptador = new SqlDataAdapter(consulta, conexion);

                using (miAdaptador)
                {
                    DataTable clientes = new DataTable();
                    miAdaptador.Fill(clientes);
                    dataGridView1.DataSource = clientes;
                }


                conexion.Close();
                MessageBox.Show("Conexion cerrada...");

            }
            catch (Exception err)
            {
                MessageBox.Show("Ha ocurrido un error: " + err.Message);
            }
        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Button4_Click(object sender, EventArgs e)
        {
            // BORRAR
            int idborrar;
            string consulta;
            idborrar = int.Parse(txtideliminar.Text);

            try
            {
                //SqlConnection conexion = new SqlConnection(
                //"Persist Security Info= False; User ID=sa; Password=masterkey; Initial Catalog=PREUBA; Server=1000-1426LA ");

                conexion.Open();

                consulta = "DELETE EMPLEADOS WHERE ID= " + idborrar;

                SqlCommand ejecutar = new SqlCommand(consulta, conexion);
                int cant;

                cant = ejecutar.ExecuteNonQuery();

                if (cant == 1)
                {
                    MessageBox.Show("BORRADO CON ÉXITO");
                }
                else
                {
                    MessageBox.Show("No hay registros que borrar");
                }
                conexion.Close();
                MessageBox.Show("CONEXION CERRADA...");
            }

            catch(Exception err)
            {
                MessageBox.Show("Ha ocurrido un error: " + err.Message);
            }

        }

        private void Button5_Click(object sender, EventArgs e)
        {
            //ACTUALIZAR
            int id, edad;
            string nombre, cargo, correo, consulta;
            id = int.Parse(idtxt.Text);
            nombre = nombretxt.Text;

            try
            {
                //SqlConnection conexion = new SqlConnection(
                //"Persist Security Info= False; User ID=sa; Password=masterkey; Initial Catalog=PREUBA; Server=1000-1426LA ");

                conexion.Open();

                consulta = "UPDATE EMPLEADOS SET NOMBRE= '" + nombre + "' WHERE ID='" + id + "' ";

                SqlCommand ejecutar = new SqlCommand(consulta, conexion);
                int cant;
                cant = ejecutar.ExecuteNonQuery();
                if (cant == 1)
                {
                    MessageBox.Show("ACTUALIZADO CORRECTO");
                }
                else
                {
                    MessageBox.Show("No hay registros que ACTUALIZAR");
                }
            }

            catch (Exception err)
            {
                MessageBox.Show("Ha ocurrido un error: " + err.Message);
            }

        }

        private void Edadtxt_TextChanged(object sender, EventArgs e)
        {

        }

        private void Label12_Click(object sender, EventArgs e)
        {

        }
    }
}
