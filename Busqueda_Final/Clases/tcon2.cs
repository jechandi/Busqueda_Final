using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using Busqueda_Final;


namespace Busqueda_Final.Clases
{
    class tcon2
    {
        public static string DB2 = "T3";
        //public string SV2 = "192.168." + MDIParent1.SV22.ToString() + ".9";
        //public string SE2 = "User ID=devn;Password=" + MDIParent1.SE22.ToString();
        public string connf = @"Data Source=192.168." + MDIParent1.SV22.ToString() + ";Initial Catalog=" + DB2 + ";User ID=devn;Password=" + MDIParent1.SE22.ToString();
        new public SqlConnection conn = new SqlConnection(@"Data Source=192.168." + MDIParent1.SV22.ToString() + ";Initial Catalog=" + DB2 + ";User ID=devn;Password=" + MDIParent1.SE22.ToString());
        //new public SqlConnection conn = new SqlConnection(@"Data Source=192.168.1.9;Initial Catalog=T3;User ID=devn;Password=sistemat300**;");
    }
}
