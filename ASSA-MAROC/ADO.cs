using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ASSA_MAROC
{
   public class ADO
    {
        public SqlConnection cnx = new SqlConnection("Data Source=DESKTOP-VKH4DQQ;Initial Catalog=ASSA_MAROC;Integrated Security=True");
        public SqlCommand cmd;
        public SqlDataReader dr;
        public SqlDataAdapter dap;
        public DataSet ds;

        public ADO()
        {
            cmd = new SqlCommand("", cnx);
            dap = new SqlDataAdapter();
            ds = new DataSet();
        }
        public void CONNECTER()
        {
            if (cnx.State == ConnectionState.Closed)
            {
                cnx.Open();
            }
        }
        public void DECONNECTER()
        {
            if (cnx.State == ConnectionState.Open)
            {
                cnx.Close();
            }
        }
        public void RemplicComboBox(ComboBox combo, string tname, string fieldId , string fieldLibelle)
        {
            cmd.CommandText = "select " + fieldId + "," + fieldLibelle + " from " + tname;
            dap.SelectCommand = cmd;
            dap.Fill(ds, tname);
            DataRow row = ds.Tables[tname].NewRow();
            row[fieldId] = 0;
            row[fieldLibelle] = "--choisir--";
            ds.Tables[tname].Rows.InsertAt(row, 0);
            combo.DataSource = ds.Tables[tname];
            combo.DisplayMember = fieldLibelle;
            combo.ValueMember = fieldId;

        }
        public void Save(string tname)
        {
            SqlCommandBuilder cmdb = new SqlCommandBuilder(this.dap);
            this.dap.Update(this.ds, tname);
        }
    }
}
