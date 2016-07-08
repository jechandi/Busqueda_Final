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
    
    
    class Gen_Bus_Run_final
    {
        public static nClas tes = new nClas();
        public SqlDataReader reader1;
        public SqlCommand command1;
        public ProgressBar pb;

        //threading
        Thread sql0;
        Thread sql1;
        Thread sql2;
        Thread sql3;
        Thread sql4;
        Thread sql5;
        Thread sql6;
        Thread sql7;
        Thread sql8;
        Thread sql9;

        public bool t2()
        {
            var tot = tes.MGen_Quer.Count() / 2;

            Thread.Sleep(0);
            sql0 = new Thread(() => t3(tes.MGen_Quer.Take(tot).ToList()));
            sql0.Start();

            sql1 = new Thread(() => t3(tes.MGen_Quer.Skip(tot).Take(tot).ToList()));
            sql1.Start();
            return true;
        }

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
                pb.Increment(frac / 100);
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
                van++;
                pb.Increment(frac / 100);
            }
            );
            return true;
        }

        public bool t23()
        {
            var tot = tes.MGen_Quer.Count() / 10;
            Thread.Sleep(0);

            for (int i = 0; i < 10; i++)
            {
                int ski = tot * i;
                new Thread(new ThreadStart(() => t3(tes.MGen_Quer.Skip(ski).Take(tot).ToList()))).Start();
            }
            return true;
        }

        public void pruebas1()
        {
            tes.Gen_Schem.Clear();tes.MGen_Quer.Clear();tes.pruebas33.Clear();nClas.T_Final.Clear();nClas.T_error.Clear();
            
            Busqueda_Final.Clases.tcon2 newt = new tcon2();
            
            string srtQry = "SELECT TABLE_NAME, COLUMN_NAME, DATA_TYPE, ORDINAL_POSITION FROM " + tcon2.DB2 + ".INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME LIKE 'T%' ORDER BY TABLE_NAME, ORDINAL_POSITION";
            newt.conn.Open();
            SqlCommand command = new SqlCommand(srtQry, newt.conn);
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
            newt.conn.Close();
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
            Busqueda_Final.Clases.tcon2 newt = new tcon2();
            SqlConnection conn2 = newt.conn;

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