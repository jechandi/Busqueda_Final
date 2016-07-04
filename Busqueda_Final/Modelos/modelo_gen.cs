using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Busqueda_Final.Modelos
{
    public class Gen_Quer2
    {
        public string consulta { get; set; }
        public string tabla { get; set; }
    }

    public class Gen_Quer3
    {
        public string consulta { get; set; }
        public string consulta2 { get; set; }
        public string tabla { get; set; }
    }

    public class Terror
    {
        public string tabla { get; set; }
        public string consulta { get; set; }
        public string error { get; set; }
    }

    public class Gen_Quer
    {
        public int Id { get; set; }
        public string tabla { get; set; }
        public string consulta { get; set; }
    }

    public class M_Gen_Schem
    {
        public string TABLE_NAME { get; set; }
        public string COLUMN_NAME { get; set; }
        public string DATA_TYPE { get; set; }
        public string ORDINAL_POSITION { get; set; }
    }
}