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
        Gen_Bus_Run_final_2 cla_gen_2 = new Gen_Bus_Run_final_2();
        nClas cla_gen2 = new nClas();

        public Form1()
        {
            
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button2.Enabled = false;
            button3.Enabled = false;
            if (Application.OpenForms["MDIParent1"] != null)
            {
                cla_gen.pruebas1();
                cla_gen.pruebas2(textBox1.Text.ToUpper().Trim());
                if (cla_gen.t22())
                {
                    dataGridView1.DataSource = "";
                    dataGridView1.DataSource = nClas.T_Final.ToList().OrderBy(x => x.Id).ToList();
                    button2.Enabled = true;
                    button3.Enabled = true;
                }
            }
            else
            {
                cla_gen_2.pruebas1();
                cla_gen_2.pruebas2(textBox1.Text.ToUpper().Trim());
                if (cla_gen_2.t22())
                {
                    dataGridView1.DataSource = "";
                    dataGridView1.DataSource = nClas.T_Final.ToList().OrderBy(x => x.Id).ToList();
                    button2.Enabled = true;
                    button3.Enabled = true;
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = "";
            var testing0 = nClas.T_Final.Select(y => y.tabla).Distinct().ToList();
            var testing = nClas.T_Final.Where(x => testing0.Contains(x.tabla)).ToList();

            var testing2 = nClas.T_Final.Where(x => (nClas.T_Final.Select(y => y.tabla).Distinct().ToList()).Contains(x.tabla)).ToList();
            dataGridView1.DataSource = testing.OrderBy(x=>x.Id).ToList().OrderBy(x=>x.tabla).ToList();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = "";
            var res = nClas.T_error.ToList().OrderBy(x => x.consulta).ToList();
            dataGridView1.DataSource = res;
        }

        public void Form1_FormClosed()
        {
            this.Close();
        }
        
        private void Form1_Load(object sender, EventArgs e)
        {
            label1.Visible = false;
            if (Application.OpenForms["MDIParent1"] != null)
            {
                cla_gen.pb = progressBar1;
                Busqueda_Final.Clases.tcon2 newt = new tcon2();
                label1.Text = newt.connf.ToString();
            }
            else
            {
                cla_gen_2.pb = progressBar1;
            }
        }
    }
}
