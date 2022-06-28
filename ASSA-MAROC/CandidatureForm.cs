using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ASSA_MAROC
{
    public partial class CandidatureForm : Form
    {
        public ADO ado;
        public CandidatureForm()
        {
            InitializeComponent();
        }



        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.TextLength == 0 || textBox2.TextLength == 0 || textBox3.TextLength == 0 || textBox4.TextLength == 0 ||
               textBox5.TextLength == 0 || textBox6.TextLength == 0 || textBox7.TextLength == 0 || maskedTextBox1.TextLength == 0 || comboBox1.SelectedValue.ToString() == "0")
            {
                MessageBox.Show("S'il Vous Plait Remplis Tous les champs avec valid information", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Regex cinRex = new Regex("^[a-zA-Z0-9 ]+$");
            if (!cinRex.IsMatch(textBox1.Text))
            {
                MessageBox.Show("CIN Doit Contient des numbers et lettres", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Regex letters = new Regex("^[a-zA-Z ]+$");
            if (!letters.IsMatch(textBox2.Text) || !letters.IsMatch(textBox3.Text) || !letters.IsMatch(textBox6.Text))
            {
                MessageBox.Show("Nom, Prénom, Profession Doit Contient just des lettres", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Regex regex = new Regex("^\\S+@\\S+\\.\\S+$");
            if (!regex.IsMatch(textBox4.Text))
            {
                MessageBox.Show("Email Adress Format Invalid", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Regex nums = new Regex("^[0-9 ]+$");
            if (!nums.IsMatch(textBox5.Text))
            {
                MessageBox.Show("Télephone Doit Contient just des Numbers", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            int years = dateTimePicker1.Value.Year;

          
             if (DateTime.Now.Year - years < 18)
            {
                MessageBox.Show("L'âge doit être de 18 ans ou plus", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
           
         
            
            try
            {
                ado.CONNECTER();
                ado.cmd.CommandText = string.Format("insert into Membre ([CIN],[NomMembre],[PrenomMembre],[EmailMembre],[TelMembre] ,[DateNaissanceMembre],[Profession],[AdresseMembre],[MotPass],[IdDepartemant]) values('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}',{9})", textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text, textBox5.Text,dateTimePicker1.Value.ToShortDateString(),textBox6.Text,textBox7.Text,maskedTextBox1.Text,comboBox1.SelectedValue.ToString());
                if (ado.cmd.ExecuteNonQuery() > 0)
                {
                    MessageBox.Show("Condidature Envoyer Effectuer , Attender 3 jour pour la Réponse!","Information",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    foreach (Control s in groupBox1.Controls)
                    {
                        if (s is TextBox)
                        {
                            s.Text = "";
                        }
                    }
                    comboBox1.SelectedIndex = 0;
                    maskedTextBox1.Text = "";
                    dateTimePicker1.Value = DateTime.Now;
                }
                ado.DECONNECTER();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void CandidatureForm_Load(object sender, EventArgs e)
        {
            ado = new ADO();
            ado.RemplicComboBox(comboBox1, "Departement", "IdDepartemant", "NomDepartement");
        }
    }
}
