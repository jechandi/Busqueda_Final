using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using Busqueda_Final;
using System.Windows.Forms;


namespace Busqueda_Final.Clases
{
    class tcon3
    {
        new public SqlConnection conn2()
        {
            string DB2 = "T3";
            SqlConnection conn2;
            if (Application.OpenForms["MDIParent1"] != null)
            {
                string connf = @"Data Source=192.168." + MDIParent1.SV22.ToString() + ";Initial Catalog=" + DB2 + ";User ID=devn;Password=" + MDIParent1.SE22.ToString();
                conn2 = new SqlConnection(@"Data Source=192.168." + MDIParent1.SV22.ToString() + ";Initial Catalog=" + DB2 + ";User ID=devn;Password=" + MDIParent1.SE22.ToString());
            }
            else
            {
                string connf = @"Data Source=192.168." + Form2.SV22.ToString() + ";Initial Catalog=" + DB2 + ";User ID=devn;Password=" + Form2.SE22.ToString();
                conn2 = new SqlConnection(@"Data Source=192.168." + Form2.SV22.ToString() + ";Initial Catalog=" + DB2 + ";User ID=devn;Password=" + Form2.SE22.ToString());
            }
            return conn2;
        }
    }
}
