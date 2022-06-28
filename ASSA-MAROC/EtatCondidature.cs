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
    public partial class EtatCondidature : Form
    {
        public ADO ado = new ADO();
        public EtatCondidature()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.TextLength == 0 || maskedTextBox1.TextLength == 0)
            {
                MessageBox.Show("S'il Vous Plait Remplis Tous les champs", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else
            {
                try
                {
                    ado.cmd.CommandText = string.Format("select Accepter from Membre where CIN = '{0}' and MotPass = '{1}'", textBox1.Text, maskedTextBox1.Text);
                    ado.CONNECTER();
                    object result = ado.cmd.ExecuteScalar();
                    if (result != null)
                    {
                        ado.dr = ado.cmd.ExecuteReader();
                        ado.dr.Read();
                        if(ado.dr[0].ToString() == "False")
                        {
                            label4.Text = "Jusqu'à ce moment, tu es rejeté";
                        }
                        else
                        {
                            label4.Text = "Tu es Accepté";
                        }
                        ado.dr.Close();
                    }
                    else
                    {
                        MessageBox.Show("Les information Incorrect", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    ado.DECONNECTER();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
        }
    }
}
