using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BDTest
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 add = new Form1();
            add.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Personas personas = new Personas();
            personas.Show();
        }
    }
}
