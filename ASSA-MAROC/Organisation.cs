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
    public partial class Organisation : Form
    {
        public ADO ado;
        public Regex nums = new Regex("^[0-9 ]+$");
        public Regex cinRex = new Regex("^[a-zA-Z0-9 ]+$");
        DataTable dtOrg = new DataTable();
        public Organisation()
        {
            InitializeComponent();
        }

        private void Organisation_Load(object sender, EventArgs e)
        {
            ado = new ADO();
            RempliDgv();
           
            ado.RemplicComboBox(comboBox2, "Membre", "CIN", "CIN");
            ado.cmd.CommandText = "select * from Activite";
            ado.dap.SelectCommand = ado.cmd;
            ado.dap.Fill(ado.ds, "Activite");
            comboBox3.DataSource = ado.ds.Tables["Activite"];
            comboBox3.DisplayMember = "IdActivite";
            comboBox3.ValueMember = "IdActivite";
            comboBox3.Text = "--choisir--";
        }
        public void RempliDgv()
        {

            dtOrg.Rows.Clear();


            ado.cmd.CommandText = "select * from Organisation";
            ado.dap.SelectCommand = ado.cmd;
            ado.dap.Fill(ado.ds, "Organisation");
            dtOrg = ado.ds.Tables["Organisation"];
            dataGridView1.DataSource = dtOrg;

        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (comboBox2.Text == "--choisir--" || comboBox3.Text == "--choisir--")
            {
                MessageBox.Show("S'il Vous Plait Remplis Tous les champs avec valid information", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
                if(dateTimePicker1.Value < DateTime.Now)
            {
                MessageBox.Show("La date est déja passer", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
                try
                {
                ado.CONNECTER();
                ado.cmd.CommandText = string.Format("insert into Organisation  values('{0}',{1},{2},'{3}','{4}',{5})", comboBox2.Text, comboBox3.Text, numericUpDown1.Text, dateTimePicker1.Value.ToShortDateString(), textBox2.Text, numericUpDown2.Text);
                if (ado.cmd.ExecuteNonQuery() > 0)
                {
                    MessageBox.Show("Bien Ajouter!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    dateTimePicker1.Value = DateTime.Now;
                }
                ado.DECONNECTER();
                RempliDgv();
                   
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

        private void button7_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox4.Text == "")
            {
                MessageBox.Show("S'il Vous Plait Remplis Tous les champs avec valid information", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!nums.IsMatch(textBox1.Text))
            {
                MessageBox.Show("Id Activité Doit Contient just des Numbers", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!cinRex.IsMatch(textBox4.Text))
            {
                MessageBox.Show("CIN Doit Contient des numbers et lettres", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                ado.CONNECTER();
                ado.cmd.CommandText = string.Format("delete from Organisation  where CIN = '{0}' and IdActivite = {1}", textBox4.Text, textBox1.Text);
                if (ado.cmd.ExecuteNonQuery() > 0)
                {
                    MessageBox.Show("Bien Supprimer!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

                  
                }
                ado.DECONNECTER();
                RempliDgv();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        
        private void button5_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox4.Text == "")
            {
                MessageBox.Show("S'il Vous Plait Remplis Tous les champs avec valid information", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!nums.IsMatch(textBox1.Text))
            {
                MessageBox.Show("Id Activité Doit Contient just des Numbers", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!cinRex.IsMatch(textBox4.Text))
            {
                MessageBox.Show("CIN Doit Contient des numbers et lettres", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                ado.CONNECTER();
                ado.cmd.CommandText = string.Format("update Organisation set  DureeActivite = {2} ,DateActivite = '{3}' ,  AdresseActivite = '{4}' , CapaciteHumaine = {5} where CIN = '{0}' and IdActivite = {1}", textBox4.Text,textBox1.Text, numericUpDown1.Text, dateTimePicker1.Value.ToShortDateString(), textBox2.Text, numericUpDown2.Text);
                if (ado.cmd.ExecuteNonQuery() > 0)
                {
                    MessageBox.Show("Bien Modifier!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    dateTimePicker1.Value = DateTime.Now;
                }
                ado.DECONNECTER();
                RempliDgv();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if(textBox1.Text == "" || textBox4.Text == "")
            {
                MessageBox.Show("S'il Vous Plait Remplis Tous les champs avec valid information", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!nums.IsMatch(textBox1.Text))
            {
                MessageBox.Show("Id Activité Doit Contient just des Numbers", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!cinRex.IsMatch(textBox4.Text))
            {
                MessageBox.Show("CIN Doit Contient des numbers et lettres", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
          
            try
            {
                bool found = false;
                ado.CONNECTER();
                ado.cmd.CommandText = string.Format("select * from Organisation where CIN = '{0}' and IdActivite = {1}", textBox4.Text, textBox1.Text);
                ado.dr = ado.cmd.ExecuteReader();
                ado.dr.Read();
                if (ado.dr.HasRows)
                {

                    comboBox2.Text = ado.dr[0].ToString();
                    comboBox3.Text = ado.dr[1].ToString();
                    numericUpDown1.Text = ado.dr[2].ToString();
                    dateTimePicker1.Text = ado.dr[3].ToString();
                    textBox2.Text = ado.dr[4].ToString();
                    numericUpDown2.Text = ado.dr[5].ToString();
                    found = true;

               
                }
                ado.dr.Close();
                ado.DECONNECTER();
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

     
    }
       
    
}
