using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace Busqueda_Final.Clases
{
    class tcon
    {
        new public SqlConnection conn = new SqlConnection(@"Data Source=192.168.1.9;Initial Catalog=T3;User ID=devn;Password=sistemat300**;");
    }
}
