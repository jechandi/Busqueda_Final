using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Busqueda_Final.Clases;


namespace Busqueda_Final
{
    public partial class Form1 : Form
    {
        Gen_Bus_Run_final cla_gen = new Gen_Bus_Run_final();
        nClas cla_gen2 = new nClas();
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            cla_gen.pruebas1();
            var a = cla_gen2.Gen_Schem.ToList();
            cla_gen.pruebas2(textBox1.Text.ToUpper().Trim());
            var b = cla_gen2.MGen_Quer.ToList();
            if (cla_gen.t2())
            {
                MessageBox.Show("ready");
            }
            dataGridView1.DataSource = "";
            dataGridView1.DataSource = nClas.T_Final.ToList().OrderBy(x => x.Id).ToList();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var res = nClas.T_Final.OrderBy(x => x.Id).ToList();
            dataGridView1.DataSource = res;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            dataGridView1.ClearSelection();
            var res = nClas.T_error.ToList().OrderBy(x => x.consulta).ToList();
            dataGridView1.DataSource = res;
        }

        public void Form1_FormClosed()
        {
            this.Close();
        }

        
    }
}
