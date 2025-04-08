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
    public partial class Personas : Form
    {
        public Personas()
        {
            InitializeComponent();
        }

        private void Personas_Load(object sender, EventArgs e)
        {
            GetData();
        }


        private void gvPersonas_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int selectedrowindex = gvPersonas.SelectedCells[0].RowIndex;
            DataGridViewRow selectedRow = gvPersonas.Rows[selectedrowindex];
            string idPersona = selectedRow.Cells["id"].Value.ToString();
            string nombre = selectedRow.Cells["nombre"].Value.ToString();
            string ap = selectedRow.Cells["ApellidoP"].Value.ToString();
            string am = selectedRow.Cells["ApellidoM"].Value.ToString();
            string ciudad = selectedRow.Cells["ciudad"].Value.ToString();
            string edad = selectedRow.Cells["edad"].Value.ToString();


            lbID.Text = idPersona;
            tbNombre.Text = nombre;
            tbAP.Text = ap;
            tbAM.Text = am;
            tbCiudad.Text = ciudad;
            tbEdad.Text = edad;
        }

        private void btUpdate_Click(object sender, EventArgs e)
        {
            string id = lbID.Text;
            string nombre = tbNombre.Text;
            string ap = tbAP.Text;
            string am = tbAM.Text;
            string ciudad = tbCiudad.Text;
            string edad = tbEdad.Text;

            MySqlConnection conn = new MySqlConnection("server=127.0.0.1;uid=root;pwd=123456;database=pruebas");
            MySqlCommand comm = new MySqlCommand($"update personas set nombre='{nombre}',apellidoP='{ap}',apellidoM='{am}',ciudad='{ciudad}',edad='{edad}' where id={id};", conn);
            comm.CommandType = CommandType.Text;
            try
            {
                conn.Open();
                comm.ExecuteNonQuery();
                GetData();
                MessageBox.Show("Actualziado correctamente");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conn.Close();
            }
        }
   
        private void GetData()
        {

            MySqlConnection conn = new MySqlConnection("server=127.0.0.1;uid=root;pwd=123456;database=pruebas");
            MySqlCommand comm = new MySqlCommand("select * from personas;", conn);
            comm.CommandType = CommandType.Text;
            try
            {
                DataTable dtPersonas = new DataTable();
                conn.Open();
                MySqlDataAdapter da = new MySqlDataAdapter(comm);
                da.Fill(dtPersonas);
                gvPersonas.DataSource = dtPersonas;
            }
            catch (Exception ex)
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
