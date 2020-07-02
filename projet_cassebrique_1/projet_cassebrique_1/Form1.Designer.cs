using System.Diagnostics;
using System.Drawing.Printing;

namespace CasseBriques {

    partial class CB {
        
        

        
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Nettoyage des ressources utilisées.
		/// </summary>
		/// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
		protected override void Dispose(bool disposing) {
			if (disposing && (components != null)) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Code généré par le Concepteur Windows Form
        
		/// <summary>
		/// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
		/// le contenu de cette méthode avec l'éditeur de code.
		/// </summary>
		private void InitializeComponent() {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.jeuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nouveauToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CreateLVToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quitterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.niveauToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.LoadLVToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.EspaceJeu = new CasseBriques.Jeu();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.jeuToolStripMenuItem,
            this.niveauToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(361, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // jeuToolStripMenuItem
            // 
            this.jeuToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nouveauToolStripMenuItem,
            this.quitterToolStripMenuItem});
            this.jeuToolStripMenuItem.Name = "jeuToolStripMenuItem";
            this.jeuToolStripMenuItem.Size = new System.Drawing.Size(36, 20);
            this.jeuToolStripMenuItem.Text = "&Jeu";
            // 
            // nouveauToolStripMenuItem
            // 
            this.nouveauToolStripMenuItem.Name = "nouveauToolStripMenuItem";
            this.nouveauToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.nouveauToolStripMenuItem.Text = "&Nouveau";
            this.nouveauToolStripMenuItem.Click += new System.EventHandler(this.nouveauToolStripMenuItem_Click);
            // 
            // CreateLVToolStripMenuItem
            // 
            this.CreateLVToolStripMenuItem.Name = "CreateLVToolStripMenuItem";
            this.CreateLVToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
            this.CreateLVToolStripMenuItem.Text = "&Créer niveau";
            this.CreateLVToolStripMenuItem.Click += new System.EventHandler(this.CreateLVToolStripMenuItem_Click);
            // 
            // quitterToolStripMenuItem
            // 
            this.quitterToolStripMenuItem.Name = "quitterToolStripMenuItem";
            this.quitterToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.quitterToolStripMenuItem.Text = "&Quitter";
            this.quitterToolStripMenuItem.Click += new System.EventHandler(this.quitterToolStripMenuItem_Click);
            // 
            // niveauToolStripMenuItem
            // 
            this.niveauToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CreateLVToolStripMenuItem,
            this.LoadLVToolStripMenuItem});
            this.niveauToolStripMenuItem.Name = "niveauToolStripMenuItem";
            this.niveauToolStripMenuItem.Size = new System.Drawing.Size(56, 20);
            this.niveauToolStripMenuItem.Text = "&Niveau";
            // 
            // LoadLVToolStripMenuItem
            // 
            this.LoadLVToolStripMenuItem.Name = "LoadLVToolStripMenuItem";
            this.LoadLVToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
            this.LoadLVToolStripMenuItem.Text = "&Lancer niveau";
            this.LoadLVToolStripMenuItem.Click += new System.EventHandler(this.LoadLVToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(134, 22);
            this.toolStripMenuItem2.Text = "---------------";
            // 
            // EspaceJeu
            // 
            this.EspaceJeu.Location = new System.Drawing.Point(1, 26);
            this.EspaceJeu.Name = "EspaceJeu";
            this.EspaceJeu.Size = new System.Drawing.Size(360, 340);
            this.EspaceJeu.TabIndex = 1;
            this.EspaceJeu.MouseClick += new System.Windows.Forms.MouseEventHandler(this.EspaceJeu_MouseClick);
            this.EspaceJeu.MouseMove += new System.Windows.Forms.MouseEventHandler(this.EspaceJeu_MouseMove);
            // 
            // CB
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(361, 367);
            this.Controls.Add(this.EspaceJeu);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "CB";
            this.Text = "Casse briques";
            this.Load += new System.EventHandler(this.CB_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem jeuToolStripMenuItem;
        
        private System.Windows.Forms.ToolStripMenuItem nouveauToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem quitterToolStripMenuItem;

        private System.Windows.Forms.ToolStripMenuItem niveauToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem CreateLVToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem LoadLVToolStripMenuItem;

		private Jeu EspaceJeu;
        

    }
}

