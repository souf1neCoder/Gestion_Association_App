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
    public partial class Membres : Form
    {
        public ADO ado;
        DataTable dt = new DataTable();
        
        public Membres()
        {
            InitializeComponent();
        }

        private void Membres_Load(object sender, EventArgs e)
        {
            ado = new ADO();
            ado.RemplicComboBox(comboBox1, "Departement", "IdDepartemant", "NomDepartement");
            RempliDRMembres();

        }
        public void RempliDRMembres()
        {
            comboBox2.DataSource = null;
            comboBox2.Items.Clear();
            comboBox2.Text = "";
            dt.Rows.Clear();
            ado.CONNECTER();
            ado.cmd.CommandText = "select * from Membre where Accepter = '1'";
            ado.dap.SelectCommand = ado.cmd;
            ado.dap.Fill(ado.ds, "Mems");
            dt = ado.ds.Tables["Mems"];
            dataGridView1.DataSource = dt;
            ado.dr = ado.cmd.ExecuteReader();

            while (ado.dr.Read())
            {
                comboBox2.Items.Add(ado.dr[0].ToString() + "--" + ado.dr[1].ToString() + " " + ado.dr[2].ToString());
                
            }
          
            ado.dr.Close();
            ado.DECONNECTER();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int end = comboBox2.Text.LastIndexOf("--");
            string cin = comboBox2.Text.Substring(0, end);
           
            ado.CONNECTER();
            ado.cmd.CommandText = string.Format("select * from Membre where CIN = '{0}'",cin);
            ado.dr = ado.cmd.ExecuteReader();

            ado.dr.Read();
            textBox1.Text = ado.dr[3].ToString();
            textBox5.Text = ado.dr[4].ToString();
            dateTimePicker1.Text = ado.dr[5].ToString();
            textBox6.Text = ado.dr[6].ToString();
            textBox7.Text = ado.dr[7].ToString();
            comboBox1.SelectedIndex = int.Parse(ado.dr[11].ToString());
            ado.dr.Close();
            ado.DECONNECTER();
          
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int end = comboBox2.Text.LastIndexOf("--");
            string cin = comboBox2.Text.Substring(0, end);
           
            ado.CONNECTER();
            ado.cmd.CommandText = string.Format("delete from Membre where CIN = '{0}'", cin);
            if (ado.cmd.ExecuteNonQuery() > 0)
            {
                MessageBox.Show("Bien Supprimer!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                foreach (Control s in groupBox1.Controls)
                {
                    if (s is TextBox)
                    {
                        s.Text = "";
                    }
                }
             
            }
           
            ado.DECONNECTER();
       
            RempliDRMembres();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int end = comboBox2.Text.LastIndexOf("--");
            string cin = comboBox2.Text.Substring(0, end);

            ado.CONNECTER();
            ado.cmd.CommandText = string.Format("update Membre set AdminAssa = '1' where CIN = '{0}'", cin);
            if (ado.cmd.ExecuteNonQuery() > 0)
            {
                MessageBox.Show("Opération Effectuer", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
               
            }
          
            ado.DECONNECTER();
            RempliDRMembres();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ListCands ls = new ListCands();
            ls.ShowDialog();
        }
    }
}
