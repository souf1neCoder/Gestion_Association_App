namespace ASSA_MAROC
{
    partial class AdminForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.membresToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.matérielsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.produitsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.activitéesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lesMembreNonAccepterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lesActivitésAnnuléeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lesActivitésEffectuerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.membresToolStripMenuItem,
            this.matérielsToolStripMenuItem,
            this.produitsToolStripMenuItem,
            this.activitéesToolStripMenuItem,
            this.viderToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(883, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // membresToolStripMenuItem
            // 
            this.membresToolStripMenuItem.Name = "membresToolStripMenuItem";
            this.membresToolStripMenuItem.Size = new System.Drawing.Size(83, 24);
            this.membresToolStripMenuItem.Text = "Membres";
            this.membresToolStripMenuItem.Click += new System.EventHandler(this.membresToolStripMenuItem_Click);
            // 
            // matérielsToolStripMenuItem
            // 
            this.matérielsToolStripMenuItem.Name = "matérielsToolStripMenuItem";
            this.matérielsToolStripMenuItem.Size = new System.Drawing.Size(82, 24);
            this.matérielsToolStripMenuItem.Text = "Matériels";
            this.matérielsToolStripMenuItem.Click += new System.EventHandler(this.matérielsToolStripMenuItem_Click);
            // 
            // produitsToolStripMenuItem
            // 
            this.produitsToolStripMenuItem.Name = "produitsToolStripMenuItem";
            this.produitsToolStripMenuItem.Size = new System.Drawing.Size(75, 24);
            this.produitsToolStripMenuItem.Text = "Produits";
            this.produitsToolStripMenuItem.Click += new System.EventHandler(this.produitsToolStripMenuItem_Click);
            // 
            // activitéesToolStripMenuItem
            // 
            this.activitéesToolStripMenuItem.Name = "activitéesToolStripMenuItem";
            this.activitéesToolStripMenuItem.Size = new System.Drawing.Size(77, 24);
            this.activitéesToolStripMenuItem.Text = "Activités";
            this.activitéesToolStripMenuItem.Click += new System.EventHandler(this.activitéesToolStripMenuItem_Click);
            // 
            // viderToolStripMenuItem
            // 
            this.viderToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lesMembreNonAccepterToolStripMenuItem,
            this.lesActivitésAnnuléeToolStripMenuItem,
            this.lesActivitésEffectuerToolStripMenuItem});
            this.viderToolStripMenuItem.Name = "viderToolStripMenuItem";
            this.viderToolStripMenuItem.Size = new System.Drawing.Size(56, 24);
            this.viderToolStripMenuItem.Text = "Vider";
            // 
            // lesMembreNonAccepterToolStripMenuItem
            // 
            this.lesMembreNonAccepterToolStripMenuItem.Name = "lesMembreNonAccepterToolStripMenuItem";
            this.lesMembreNonAccepterToolStripMenuItem.Size = new System.Drawing.Size(254, 24);
            this.lesMembreNonAccepterToolStripMenuItem.Text = "Les Membre Non Accepter";
            this.lesMembreNonAccepterToolStripMenuItem.Click += new System.EventHandler(this.lesMembreNonAccepterToolStripMenuItem_Click);
            // 
            // lesActivitésAnnuléeToolStripMenuItem
            // 
            this.lesActivitésAnnuléeToolStripMenuItem.Name = "lesActivitésAnnuléeToolStripMenuItem";
            this.lesActivitésAnnuléeToolStripMenuItem.Size = new System.Drawing.Size(254, 24);
            this.lesActivitésAnnuléeToolStripMenuItem.Text = "Les Activités Annulée";
            this.lesActivitésAnnuléeToolStripMenuItem.Click += new System.EventHandler(this.lesActivitésAnnuléeToolStripMenuItem_Click);
            // 
            // lesActivitésEffectuerToolStripMenuItem
            // 
            this.lesActivitésEffectuerToolStripMenuItem.Name = "lesActivitésEffectuerToolStripMenuItem";
            this.lesActivitésEffectuerToolStripMenuItem.Size = new System.Drawing.Size(254, 24);
            this.lesActivitésEffectuerToolStripMenuItem.Text = "Les Activités Effectuer";
            this.lesActivitésEffectuerToolStripMenuItem.Click += new System.EventHandler(this.lesActivitésEffectuerToolStripMenuItem_Click);
            // 
            // AdminForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(883, 500);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "AdminForm";
            this.Text = "AdminForm";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.AdminForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem membresToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem matérielsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem produitsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem activitéesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viderToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lesMembreNonAccepterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lesActivitésAnnuléeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lesActivitésEffectuerToolStripMenuItem;
    }
}