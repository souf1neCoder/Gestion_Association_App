using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
namespace ASSA_MAROC
{
    public partial class Activites : Form
    {
        public ADO ado;
        public DataTable dtAct = new DataTable();
        public Regex nums = new Regex("^[0-9 ]+$");
        public Activites()
        {
            InitializeComponent();
        }

       

        private void button1_Click(object sender, EventArgs e)
        {
            if (checkFields())
            {
                try
                {
                    DataRow dr = ado.ds.Tables["Activite"].NewRow();
                    dr[1] = detBox.Text;
                    dr[2] = comboBox1.Text;
                    ado.ds.Tables["Activite"].Rows.Add(dr);
                    ado.Save("Activite");
                    RempliDgv();
                    MessageBox.Show("Bien Ajouter!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("S'il Vous Plait Remplis Tous les champs avec valid information", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public bool checkFields()
        {
            if (detBox.TextLength == 0 ||
              comboBox1.Text == "")
            {

                return false;
            }
            return true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (idBox.Text == "")
            {
                MessageBox.Show("S'il Vous Plait Remplis Tous les champs avec valid information", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!nums.IsMatch(idBox.Text))
            {
                MessageBox.Show("Id Activité Doit Contient just des Numbers", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                bool found = false;
                foreach (DataRow item in ado.ds.Tables["Activite"].Rows)
                {
                    if (item[0].ToString() == this.idBox.Text)
                    {

                        detBox.Text = item[1].ToString();
                        comboBox1.Text = item[2].ToString();
                        found = true;
                        break;
                    }

                }
                if (!found)
                {
                    MessageBox.Show("Introuvable!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (idBox.Text == "")
            {
                MessageBox.Show("S'il Vous Plait Remplis Tous les champs avec valid information", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!nums.IsMatch(idBox.Text))
            {
                MessageBox.Show("Id Activité Doit Contient just des Numbers", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                foreach (DataRow item in ado.ds.Tables["Activite"].Rows)
                {
                    if (item[0].ToString() == this.idBox.Text)
                    {
                        item.Delete();
                        MessageBox.Show("Bien Supprimer!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ado.Save("Activite");
                        RempliDgv();
                        
                        break;
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (idBox.Text == "")
            {
                MessageBox.Show("S'il Vous Plait Remplis Tous les champs avec valid information", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!nums.IsMatch(idBox.Text))
            {
                MessageBox.Show("Id Activité Doit Contient just des Numbers", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                foreach (DataRow item in ado.ds.Tables["Activite"].Rows)
                {
                    if (item[0].ToString() == this.idBox.Text)
                    {
                        if (checkFields())
                        {
                            item[1] = detBox.Text;
                            item[2] = comboBox1.Text;
                           

                            MessageBox.Show("Bien Modifier!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            ado.Save("Activite");
                            RempliDgv();
                            
                        }
                        else
                        {
                            MessageBox.Show("S'il Vous Plait Remplis Tous les champs avec valid information", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        }
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

       
        public void RempliDgv()
        {

            dtAct.Rows.Clear();


            ado.cmd.CommandText = "select * from Activite";
            ado.dap.SelectCommand = ado.cmd;
            ado.dap.Fill(ado.ds, "Activite");
            dtAct = ado.ds.Tables["Activite"];
            dataGridView1.DataSource = dtAct;

        }

        private void Activites_Load(object sender, EventArgs e)
        {
            ado = new ADO();


            comboBox1.Items.Add("En cours");
            comboBox1.Items.Add("Effectué");
            comboBox1.Items.Add("Annulée");

            comboBox1.Text = "--choisir--";


            RempliDgv();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Organisation org = new Organisation();
            org.ShowDialog();
        }
    }
}
