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
    public partial class MDIParent1 : Form
    {
        public MDIParent1()
        {
            InitializeComponent();
        }

        public static string SE22;
        public static string SV22;

        public static Form1 _Frm = new Form1();

        public class Nit
        {
            public int value { get; set; }
            public string text { get; set; }
        }

        private void MDIParent1_Load(object sender, EventArgs e)
        {
            List<Nit> items2 = new List<Nit>();
            items2.Add(new Nit { value = 1, text = "desarrollo" });
            items2.Add(new Nit { value = 2, text = "mcy" });
            items2.Add(new Nit { value = 3, text = "mcbo" });
            items2.Add(new Nit { value = 4, text = "scb" });
            items2.Add(new Nit { value = 5, text = "pzo" });
            items2.Add(new Nit { value = 6, text = "xxx" });
            items2.Add(new Nit { value = 8, text = "bqto" });
            items2.Add(new Nit { value = 9, text = "ccs" });
            items2.Add(new Nit { value = 10, text = "bna" });
            items2.Add(new Nit { value = 11, text = "cup" });
            items2.Add(new Nit { value = 12, text = "clz" });

            comboBox1.DataSource = items2;
            comboBox1.DisplayMember = "text";
            comboBox1.ValueMember = "value";

            List<Nit> items3 = new List<Nit>();
            items3.Add(new Nit { value = 1, text = "desarrollo" });
            items3.Add(new Nit { value = 2, text = "Villa de Cura" }); 
            items3.Add(new Nit { value = 3, text = "Maracaibo" }); 
            items3.Add(new Nit { value = 4, text = "San Cristobal" }); 
            items3.Add(new Nit { value = 5, text = "Puerto Ordaz" }); 
            items3.Add(new Nit { value = 6, text = "Barcelona" }); 
            items3.Add(new Nit { value = 8, text = "Barquisimeto" }); 
            items3.Add(new Nit { value = 9, text = "Guarenas, ccs" });
            items3.Add(new Nit { value = 10, text = "Barinas" }); 
            items3.Add(new Nit { value = 11, text = "Carupano" });
            items3.Add(new Nit { value = 12, text = "Calabozo" });

            comboBox2.DataSource = items3;
            comboBox2.DisplayMember = "text";
            comboBox2.ValueMember = "value";
        }
        
        
        
        private void button1_Click_1(object sender, EventArgs e)
        {
            if (Op_Prod.Checked)
            {
                button2.Enabled = true;
                SV22 = comboBox1.SelectedValue.ToString() + ".5";
            }
            else if (Op_Desa.Checked)
            {
                button2.Enabled = true;
                SV22 = comboBox1.SelectedValue.ToString() + ".9";
            }
            else
            {
                button2.Enabled = false;
                SV22 = "";
            }
            _Frm.Form1_FormClosed();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (Op_Prod.Checked)
            {
                button2.Enabled = true;
                SV22 = comboBox2.SelectedValue.ToString() + ".5";
            }
            else if (Op_Desa.Checked)
            {
                button2.Enabled = true;
                SV22 = comboBox2.SelectedValue.ToString() + ".9";
            }
            else
            {
                button2.Enabled = false;
                SV22 = "";
            }
            _Frm.Form1_FormClosed();
        }

        private void Op_Desa_CheckedChanged(object sender, EventArgs e)
        {
            if (Op_Desa.Checked)
            {
                SE22 = "sistemat300**;";
                Op_Prod.Checked = false;
                button2.Enabled = false;
                _Frm.Form1_FormClosed();
            }
        }

        private void Op_Prod_CheckedChanged(object sender, EventArgs e)
        {
            if (Op_Prod.Checked)
            {
                SE22 = "cronssat300**;";
                Op_Desa.Checked = false;
                button2.Enabled = false;
                _Frm.Form1_FormClosed();
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            tcon2 t = new tcon2();
            var a = t.connf.ToString();
            _Frm = new Form1();
            _Frm.MdiParent = this; _Frm.Dock = DockStyle.Fill; _Frm.Show();
        }
    }
}
