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
    public partial class Materiels : Form
    {
        public ADO ado;
        public DataTable dtMat = new DataTable();
       public  Regex nums = new Regex("^[0-9 ]+$");
        public Regex floats = new Regex(@"^[0-9]*(?:\.[0-9]*)?$");
        public Materiels()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            if (checkFields())
            {
                try
                {
                    DataRow dr = ado.ds.Tables["Materiel"].NewRow();
                    dr[1] = numBox.Text;
                    dr[2] = dateTimePicker1.Value.ToShortDateString();
                    dr[3] = lblBox.Text;
                    dr[4] =  mdlBox.Text;
                    dr[5] = prixBox.Text;

                    ado.ds.Tables["Materiel"].Rows.Add(dr);
                    ado.Save("Materiel");
                    RempliDgv();
                    MessageBox.Show("Bien Ajouter!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    textBox4.Text = "";
                    mdlBox.Text = "";
                    prixBox.Text = "";
                    lblBox.Text = "";
                    numBox.Text = "";
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("S'il Vous Plait Remplis Tous les champs avec valid information", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Materiels_Load(object sender, EventArgs e)
        {
            ado = new ADO();
            RempliDgv();
        }
        public bool checkFields()
        {


         
            if (prixBox.TextLength == 0 ||
              numBox.TextLength == 0 || lblBox.TextLength == 0 || mdlBox.TextLength == 0 || dateTimePicker1.Value > DateTime.Now)
            {
               
                return false;
            }else if (!nums.IsMatch(numBox.Text) || !floats.IsMatch(prixBox.Text) || !nums.IsMatch(mdlBox.Text))
            {
                return false;
            }
            return true;
        }
        public void RempliDgv()
        {

            dtMat.Rows.Clear();
           

            ado.cmd.CommandText = "select * from Materiel";
            ado.dap.SelectCommand = ado.cmd;
            ado.dap.Fill(ado.ds, "Materiel");
            dtMat = ado.ds.Tables["Materiel"];
            dataGridView1.DataSource = dtMat;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!nums.IsMatch(idBox.Text))
            {
                MessageBox.Show("Id Matériel Doit etre number", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                foreach (DataRow item in ado.ds.Tables["Materiel"].Rows)
                {
                    if (item[0].ToString() == this.idBox.Text)
                    {
                        item.Delete();
                        MessageBox.Show("Bien Supprimer!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ado.Save("Materiel");

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

        private void button3_Click(object sender, EventArgs e)
        {
            if (!nums.IsMatch(idBox.Text))
            {
                MessageBox.Show("Id Matériel Doit etre number", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                bool found = false;
                foreach (DataRow item in ado.ds.Tables["Materiel"].Rows)
                {
                    if (item[0].ToString() == this.idBox.Text)
                    {

                        numBox.Text = item[1].ToString();
                        dateTimePicker1.Text = item[2].ToString();
                        lblBox.Text = item[3].ToString();
                        mdlBox.Text = item[4].ToString();
                        prixBox.Text = item[5].ToString();
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

        private void button4_Click(object sender, EventArgs e)
        {
            if (!nums.IsMatch(idBox.Text))
            {
                MessageBox.Show("Id Matériel Doit etre number", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                foreach (DataRow item in ado.ds.Tables["Materiel"].Rows)
                {
                    if (item[0].ToString() == this.idBox.Text)
                    {
                        if  (checkFields())
                        {
                            item[1] = numBox.Text;
                            item[2] = dateTimePicker1.Value.ToShortDateString();
                            item[3] = lblBox.Text;
                            item[4] = mdlBox.Text;
                            item[5] = prixBox.Text;

                            MessageBox.Show("Bien Modifier!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            ado.Save("Materiel");

                            RempliDgv();
                            textBox4.Text = "";
                            mdlBox.Text = "";
                            prixBox.Text = "";
                            lblBox.Text = "";
                            numBox.Text = "";
                            idBox.Text = "";
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

       
    }
}
