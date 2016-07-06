using System;
using System.Configuration;

using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Busqueda_Final.Clases;
using Busqueda_Final.Modelos;

using System.Text.RegularExpressions;
using System.Data.SqlClient;

using System.IO;
using System.Threading;


namespace Busqueda_Final.Clases
{
    class Gen_Bus_Run_final_2
    {
        public static nClas tes = new nClas();
        public SqlDataReader reader1;
        public SqlCommand command1;
        public ProgressBar pb;

        public bool t22()
        {
            pb.Value = 0;
            int frac = 100;
            var tot = tes.MGen_Quer.Count() / frac;

            Thread[] ts = new Thread[frac];
            Thread.Sleep(0);

            for (int i = 0; i < frac; i++)
            {
                int ski = tot * i;
                ts[i] = new Thread(() => t3(tes.MGen_Quer.Skip(ski).Take(tot).ToList()));
                ts[i].Start();
                ts[i].Join();
                pb.Increment(frac/100);
            }
            return true;
        }

        public bool t223()
        {
            pb.Value = 0;
            int frac = 10;
            var tot = tes.MGen_Quer.Count() / frac;

            Thread[] ts = new Thread[frac];
            Thread.Sleep(0);

            int van = 0;
            ts.ToList().ForEach(x =>
            {
                int ski = tot * van;
                ts[van] = new Thread(() => t3(tes.MGen_Quer.Skip(ski).Take(tot).ToList()));
                //ts[van].Start();
                ts[van].Start();
                ts[van].Join();
                pb.Increment(frac / 100);
                van++;
            }
            );
            return true;
        }

        public void pruebas1()
        {
            tes.Gen_Schem.Clear();tes.MGen_Quer.Clear();tes.pruebas33.Clear();nClas.T_Final.Clear();nClas.T_error.Clear();
            
            //Busqueda_Final.Clases.tcon2 newt = new tcon2();
            Busqueda_Final.Clases.tcon3 newt = new tcon3();
            SqlConnection conn = newt.conn2();
            
            string srtQry = "SELECT TABLE_NAME, COLUMN_NAME, DATA_TYPE, ORDINAL_POSITION FROM " + tcon2.DB2 + ".INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME LIKE 'T%' ORDER BY TABLE_NAME, ORDINAL_POSITION";
            conn.Open();
            SqlCommand command = new SqlCommand(srtQry, conn);
            SqlDataReader reader = (command.ExecuteReader());
            string[] lista66 = new string[] { "image", "datetime", "uniqueidentifier" };
            while (reader.Read())
            {
                if (!lista66.Contains(reader.GetString(2)))
                {
                    tes.Gen_Schem.Add(new M_Gen_Schem
                    {
                        TABLE_NAME = reader.GetString(0),
                        COLUMN_NAME = reader.GetString(1),
                        DATA_TYPE = reader.GetString(2),
                        ORDINAL_POSITION = reader.GetInt16(3).ToString(),
                    });
                }
            }
            conn.Close();
        }

        public void pruebas2(string val_busqueda)
        {
            string[] num = new string[] { "bigint", "binary", "bit", "decimal", "float", "int", "numeric", "smallint", "tinyint" };
            tes.Gen_Schem.Select(x => x.TABLE_NAME).Distinct().ToList().ForEach(item =>
            {
                string srtQry2 = " WHERE ";
                tes.Gen_Schem.Where(x => x.TABLE_NAME == item.ToString()).ToList().Select(x => x.COLUMN_NAME).ToList().//=>
                    ForEach(x => srtQry2 += "CAST(" + x.ToString() + " as nvarchar) = CAST('" + val_busqueda + "' as nvarchar) OR ");
                tes.MGen_Quer.Add(new Gen_Quer
                {
                    tabla = item.ToString(),
                    consulta = srtQry2.Remove(srtQry2.Length - 4),
                });
            });
        }

        public void t3(List<Gen_Quer> campos)
        {
            Busqueda_Final.Clases.tcon3 newt = new tcon3();
            SqlConnection conn2 = newt.conn2();

            var pruebas33 = new List<Gen_Quer3>();
            campos.ForEach(x => pruebas33.Add(new Gen_Quer3
            {
                consulta = "SELECT COUNT(*) FROM " + x.tabla.ToString() + x.consulta.ToString(),
                consulta2 = "SELECT '" + x.tabla.ToString() + "' AS 'T', * FROM " + x.tabla.ToString() + x.consulta.ToString(),
                tabla = x.tabla,
            }));

            pruebas33.ForEach(x =>
            {
                try
                {
                    command1 = new SqlCommand(x.consulta, conn2);
                    if (conn2.State.ToString() != "Open")
                    {
                        try{
                            conn2.Open(); reader1 = command1.ExecuteReader();
                            reader1.Read();
                            nClas.T_Final.Add(new Gen_Quer { Id = reader1.GetInt32(0), tabla = x.tabla, consulta = x.consulta2 });
                            reader1.Close();
                            conn2.Close();
                            }
                        catch (Exception ex){
                            nClas.T_error.Add(new Terror { error = ex.ToString(), tabla = x.tabla.ToString(), consulta = x.consulta.ToString(), });
                        }}
                }
                catch (Exception ex)
                {
                    nClas.T_error.Add(new Terror
                    {
                        error = ex.ToString(),
                        tabla = x.tabla.ToString(),
                        consulta = x.consulta.ToString(),
                    });
                }
            });
            conn2.Close();
            nClas.T_Final = nClas.T_Final.Where(x => x.Id > 0).ToList();
        }
    }
}