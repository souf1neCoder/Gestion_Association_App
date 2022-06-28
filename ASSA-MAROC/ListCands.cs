using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ASSA_MAROC
{
    public partial class ListCands : Form
    {
        public ADO ado;
        DataTable dt = new DataTable();
        public ListCands()
        {
            InitializeComponent();
        }

        private void ListCands_Load(object sender, EventArgs e)
        {
            ado = new ADO();
            RemplrDgv();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.CurrentCell.ColumnIndex.Equals(0) && e.RowIndex != -1)
            {
               
                string cin = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                ado.CONNECTER();
                ado.cmd.CommandText = string.Format("update Membre set Accepter = '1' where CIN = '{0}'", cin);
                if (ado.cmd.ExecuteNonQuery() > 0)
                {
                    MessageBox.Show("Opération Effectuer", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }

                ado.DECONNECTER();
                RemplrDgv();
            }
        }
        public void RemplrDgv()
        {
            dt.Rows.Clear();
            ado.cmd.CommandText = "SELECT [CIN],[NomMembre],[PrenomMembre],[EmailMembre],[TelMembre],[DateNaissanceMembre],[Profession],[AdresseMembre],[IdDepartemant] FROM [dbo].[Membre] where Accepter = '0'";
            ado.dap.SelectCommand = ado.cmd;
            ado.dap.Fill(ado.ds, "Membres");
            dt = ado.ds.Tables["Membres"];
            dataGridView1.DataSource = dt;
        }
    }
}
