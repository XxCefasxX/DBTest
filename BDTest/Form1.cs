using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace BDTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btRegistrar_Click(object sender, EventArgs e)
        {
            string nombre = tbNombre.Text;
            string ap = tbAP.Text;
            string am=tbAM.Text;
            string ciudad = tbCiudad.Text;
            string edad=tbEdad.Text;
            
            MySqlConnection conn = new MySqlConnection("server=127.0.0.1;uid=root;pwd=123456;database=pruebas");
            MySqlCommand comm = new MySqlCommand("insert into personas(nombre,apellidoP,apellidoM,ciudad,edad)" +
                $"values ('{nombre}','{ap}','{am}','{ciudad}','{edad}');", conn);
            comm.CommandType = CommandType.Text;
            try
            {
                conn.Open();
                comm.ExecuteNonQuery();
                MessageBox.Show("Guardado correctamente");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conn.Close();
            }
        }
    }
}
