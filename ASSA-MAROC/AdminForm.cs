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
    public partial class AdminForm : Form
    {
        public ADO ado;
        public AdminForm()
        {
            InitializeComponent();
        }

        private void membresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Membres m = new Membres();
            m.MdiParent = this;
            m.Show();
        }

        private void matérielsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Materiels m = new Materiels();
            m.MdiParent = this;
            m.Show();
        }

        private void produitsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Produits p = new Produits();
            p.MdiParent = this;
            p.Show();
        }

        private void activitéesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Activites a = new Activites();
            a.MdiParent = this;
            a.Show();
        }

        private void lesMembreNonAccepterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ado.CONNECTER();
            ado.cmd.CommandText = string.Format("delete from Membre where Accepter = '0'");
            if (ado.cmd.ExecuteNonQuery() > 0)
            {
                MessageBox.Show("Bien Supprimer!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            ado.DECONNECTER();
        }

        private void AdminForm_Load(object sender, EventArgs e)
        {
            ado = new ADO();
        }

        private void lesActivitésAnnuléeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ado.CONNECTER();
            ado.cmd.CommandText = string.Format("delete from Activite where Etat = 'Annulée'");
            if (ado.cmd.ExecuteNonQuery() > 0)
            {
                MessageBox.Show("Bien Supprimer!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            ado.DECONNECTER();
        }

        private void lesActivitésEffectuerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ado.CONNECTER();
            ado.cmd.CommandText = string.Format("delete from Activite where Etat = 'Effectué'");
            if (ado.cmd.ExecuteNonQuery() > 0)
            {
                MessageBox.Show("Bien Supprimer!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            ado.DECONNECTER();
        }
    }
}
