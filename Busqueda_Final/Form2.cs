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
    public partial class Form2 : Form
    {
        public Form2()
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

        private void Form2_Load(object sender, EventArgs e)
        {
            List<Nit> items2 = new List<Nit>();
            items2.Add(new Nit { value = 0, text = "Seleccione una conexion" });
            items2.Add(new Nit { value = 1, text = "desarrollo" });
            items2.Add(new Nit { value = 2, text = "mcy-Villa de Cura" });
            items2.Add(new Nit { value = 3, text = "mcbo-Maracaibo" });
            items2.Add(new Nit { value = 4, text = "scb-San Cristobal" });
            items2.Add(new Nit { value = 5, text = "pzo-Puerto Ordaz" });
            items2.Add(new Nit { value = 6, text = "xxx-Barcelona" });
            items2.Add(new Nit { value = 8, text = "bqto-Barquisimeto" });
            items2.Add(new Nit { value = 9, text = "ccs-Guarenas, ccs" });
            items2.Add(new Nit { value = 10, text = "bna-Barinas" });
            items2.Add(new Nit { value = 11, text = "cup-Carupano" });
            items2.Add(new Nit { value = 12, text = "cla-Calabozo" });

            List<Nit> items3 = new List<Nit>();

            comboBox2.DataSource = items2;
            comboBox2.DisplayMember = "text";
            comboBox2.ValueMember = "value";
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            _Frm.Form1_FormClosed();
            string msg = "Seleccione una sucursal"; 
            if (comboBox2.SelectedIndex == 0)
            {
                button2.Enabled = false;
                SV22 = msg;
            }
            else
            {
                button2.Enabled = true;
                SV22 = comboBox2.SelectedValue.ToString() + ".5";
                SE22 = "cronssat300**;";
                if (comboBox2.SelectedIndex == 1)
                {
                    SV22 = comboBox2.SelectedValue.ToString() + ".9";
                    SE22 = "sistemat300**;";
                }
                 msg = "192.168." + SV22 + " -- " + SE22.Remove(SE22.Length - 1);
            }
            label1.Text = msg;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            _Frm = new Form1();
            _Frm.MdiParent = this; _Frm.Dock = DockStyle.Fill; _Frm.Show();
        }
    }
}
