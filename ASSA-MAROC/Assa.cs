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
    public partial class Assa : Form
    {
        public Assa()
        {
            InitializeComponent();
        }

        private void Assa_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            LoginAdmin af = new LoginAdmin();
         
            af.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            CandidatureForm cf = new CandidatureForm();
       
            cf.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            EtatCondidature ec = new EtatCondidature();
            ec.ShowDialog();
        }
    }
}
