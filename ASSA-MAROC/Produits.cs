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
    public partial class Produits : Form
    {
        public ADO ado;
        public DataTable dtProd = new DataTable();
        public Regex nums = new Regex("^[0-9 ]+$");
        public Regex floats = new Regex(@"^[0-9]*(?:\.[0-9]*)?$");
        public Regex letters = new Regex("^[a-zA-Z ]+$");
        public Produits()
        {
            InitializeComponent();
        }


        private void Produits_Load(object sender, EventArgs e)
        {
            ado = new ADO();
            ado.RemplicComboBox(comboBox1, "Membre", "CIN", "CIN");
            RempliDgv();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (checkFields())
            {
                try
                {
                    DataRow dr = ado.ds.Tables["Produit"].NewRow();
                    dr[1] = comboBox1.Text;
                    dr[2] = nomBox.Text;
                    dr[3] = desBox.Text;
                    dr[4] =  prixBox.Text;
                    dr[5] =  numericUpDown1.Value.ToString();

                    ado.ds.Tables["Produit"].Rows.Add(dr);
                    ado.Save("Produit");
                    RempliDgv();
                    MessageBox.Show("Bien Ajouter!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    textBox4.Text = "";
                    nomBox.Text = "";
                    prixBox.Text = "";
                    desBox.Text = "";
                    comboBox1.SelectedIndex = 0;
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
        public void RempliDgv()
        {

            dtProd.Rows.Clear();


            ado.cmd.CommandText = "select * from Produit";
            ado.dap.SelectCommand = ado.cmd;
            ado.dap.Fill(ado.ds, "Produit");
            dtProd = ado.ds.Tables["Produit"];
            dataGridView1.DataSource = dtProd;

        }
        public bool checkFields()
        {
            if (prixBox.TextLength == 0 ||
             comboBox1.SelectedValue.ToString() == "0" || desBox.TextLength == 0 || nomBox.TextLength == 0)
            {

                return false;
            }
            else if (!letters.IsMatch(nomBox.Text) || !floats.IsMatch(prixBox.Text))
            {
                return false;
            }
            return true;
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
                foreach (DataRow item in ado.ds.Tables["Produit"].Rows)
                {
                    if (item[0].ToString() == this.idBox.Text)
                    {

                        comboBox1.Text = item[1].ToString();
                        nomBox.Text = item[2].ToString();
                        desBox.Text = item[3].ToString();
                        prixBox.Text = item[4].ToString();
                        numericUpDown1.Text = item[5].ToString();
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
                MessageBox.Show("Id Produit Doit etre number", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                foreach (DataRow item in ado.ds.Tables["Produit"].Rows)
                {
                    if (item[0].ToString() == this.idBox.Text)
                    {
                        if (checkFields())
                        {
                            item[1] = comboBox1.Text;
                            item[2] = nomBox.Text;
                            item[3] = desBox.Text;
                            item[4] = prixBox.Text;
                            item[5] = numericUpDown1.Value.ToString();

                            MessageBox.Show("Bien Modifier!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            ado.Save("Produit");

                            RempliDgv();
                            textBox4.Text = "";
                            nomBox.Text = "";
                            prixBox.Text = "";
                            desBox.Text = "";
                            comboBox1.SelectedIndex = 0;
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

        private void button2_Click(object sender, EventArgs e)
        {
            if (!nums.IsMatch(idBox.Text))
            {
                MessageBox.Show("Id Matériel Doit etre number", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                foreach (DataRow item in ado.ds.Tables["Produit"].Rows)
                {
                    if (item[0].ToString() == this.idBox.Text)
                    {
                        item.Delete();
                        MessageBox.Show("Bien Supprimer!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ado.Save("Produit");

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

      
    }
}
