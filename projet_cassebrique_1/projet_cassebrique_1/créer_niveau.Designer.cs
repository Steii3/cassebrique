using CasseBriques;

namespace projet_cassebrique_1
{
    partial class créer_niveau
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
            this.btn_Save = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_random = new System.Windows.Forms.Button();
            this.btn_load = new System.Windows.Forms.Button();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btn_brique = new System.Windows.Forms.Button();
            this.btn_brique_rapide = new System.Windows.Forms.Button();
            this.btn_brique_RetourNorm = new System.Windows.Forms.Button();
            this.btn_brique_Retrecire = new System.Windows.Forms.Button();
            this.btn_brique_3coup = new System.Windows.Forms.Button();
            this.btn_brique_doubleBoules = new System.Windows.Forms.Button();
            this.btn_brique_Empty = new System.Windows.Forms.Button();
            this.btn_createEmpty = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_Save
            // 
            this.btn_Save.Location = new System.Drawing.Point(404, 371);
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.Size = new System.Drawing.Size(98, 43);
            this.btn_Save.TabIndex = 0;
            this.btn_Save.Text = "Sauvegarder niveau";
            this.btn_Save.UseVisualStyleBackColor = true;
            this.btn_Save.Click += new System.EventHandler(this.btn_Save_Click);
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(22, 26);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(360, 340);
            this.panel1.TabIndex = 1;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            this.panel1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.panel_Mouseclick);
            this.panel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseMove);
            // 
            // btn_random
            // 
            this.btn_random.Location = new System.Drawing.Point(404, 12);
            this.btn_random.Name = "btn_random";
            this.btn_random.Size = new System.Drawing.Size(98, 38);
            this.btn_random.TabIndex = 2;
            this.btn_random.Text = "Créer nouveau niveau aléatoire";
            this.btn_random.UseVisualStyleBackColor = true;
            this.btn_random.Click += new System.EventHandler(this.btn_random_Click);
            // 
            // btn_load
            // 
            this.btn_load.Location = new System.Drawing.Point(404, 102);
            this.btn_load.Name = "btn_load";
            this.btn_load.Size = new System.Drawing.Size(98, 23);
            this.btn_load.TabIndex = 3;
            this.btn_load.Text = "Charger Niveau";
            this.btn_load.UseVisualStyleBackColor = true;
            this.btn_load.Click += new System.EventHandler(this.btn_load_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.btn_brique);
            this.flowLayoutPanel1.Controls.Add(this.btn_brique_rapide);
            this.flowLayoutPanel1.Controls.Add(this.btn_brique_RetourNorm);
            this.flowLayoutPanel1.Controls.Add(this.btn_brique_Retrecire);
            this.flowLayoutPanel1.Controls.Add(this.btn_brique_3coup);
            this.flowLayoutPanel1.Controls.Add(this.btn_brique_doubleBoules);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(404, 172);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(1);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(98, 154);
            this.flowLayoutPanel1.TabIndex = 4;
            // 
            // btn_brique
            // 
            this.btn_brique.Location = new System.Drawing.Point(0, 0);
            this.btn_brique.Margin = new System.Windows.Forms.Padding(0, 0, 1, 1);
            this.btn_brique.Name = "btn_brique";
            this.btn_brique.Size = new System.Drawing.Size(98, 23);
            this.btn_brique.TabIndex = 5;
            this.btn_brique.Text = "Simple";
            this.btn_brique.UseVisualStyleBackColor = true;
            this.btn_brique.Click += new System.EventHandler(this.btn_brique_Click);
            this.btn_brique.MouseClick += new System.Windows.Forms.MouseEventHandler(this.panel_Mouseclick);
            // 
            // btn_brique_rapide
            // 
            this.btn_brique_rapide.Location = new System.Drawing.Point(0, 25);
            this.btn_brique_rapide.Margin = new System.Windows.Forms.Padding(0, 1, 1, 1);
            this.btn_brique_rapide.Name = "btn_brique_rapide";
            this.btn_brique_rapide.Size = new System.Drawing.Size(98, 23);
            this.btn_brique_rapide.TabIndex = 10;
            this.btn_brique_rapide.Text = "Rapide";
            this.btn_brique_rapide.UseVisualStyleBackColor = true;
            this.btn_brique_rapide.Click += new System.EventHandler(this.btn_brique_rapide_Click);
            // 
            // btn_brique_RetourNorm
            // 
            this.btn_brique_RetourNorm.Location = new System.Drawing.Point(0, 50);
            this.btn_brique_RetourNorm.Margin = new System.Windows.Forms.Padding(0, 1, 1, 1);
            this.btn_brique_RetourNorm.Name = "btn_brique_RetourNorm";
            this.btn_brique_RetourNorm.Size = new System.Drawing.Size(98, 23);
            this.btn_brique_RetourNorm.TabIndex = 6;
            this.btn_brique_RetourNorm.Text = "Retour Normal";
            this.btn_brique_RetourNorm.UseVisualStyleBackColor = true;
            this.btn_brique_RetourNorm.Click += new System.EventHandler(this.btn_brique_RetourNorm_Click);
            // 
            // btn_brique_Retrecire
            // 
            this.btn_brique_Retrecire.Location = new System.Drawing.Point(0, 75);
            this.btn_brique_Retrecire.Margin = new System.Windows.Forms.Padding(0, 1, 1, 1);
            this.btn_brique_Retrecire.Name = "btn_brique_Retrecire";
            this.btn_brique_Retrecire.Size = new System.Drawing.Size(98, 23);
            this.btn_brique_Retrecire.TabIndex = 7;
            this.btn_brique_Retrecire.Text = "Barre Retrecire";
            this.btn_brique_Retrecire.UseVisualStyleBackColor = true;
            this.btn_brique_Retrecire.Click += new System.EventHandler(this.btn_brique_Retrecire_Click);
            // 
            // btn_brique_3coup
            // 
            this.btn_brique_3coup.Location = new System.Drawing.Point(0, 100);
            this.btn_brique_3coup.Margin = new System.Windows.Forms.Padding(0, 1, 1, 1);
            this.btn_brique_3coup.Name = "btn_brique_3coup";
            this.btn_brique_3coup.Size = new System.Drawing.Size(98, 23);
            this.btn_brique_3coup.TabIndex = 8;
            this.btn_brique_3coup.Text = "3 coup";
            this.btn_brique_3coup.UseVisualStyleBackColor = true;
            this.btn_brique_3coup.Click += new System.EventHandler(this.btn_brique_3coup_Click);
            // 
            // btn_brique_doubleBoules
            // 
            this.btn_brique_doubleBoules.Location = new System.Drawing.Point(0, 125);
            this.btn_brique_doubleBoules.Margin = new System.Windows.Forms.Padding(0, 1, 1, 1);
            this.btn_brique_doubleBoules.Name = "btn_brique_doubleBoules";
            this.btn_brique_doubleBoules.Size = new System.Drawing.Size(98, 23);
            this.btn_brique_doubleBoules.TabIndex = 9;
            this.btn_brique_doubleBoules.Text = "double boule";
            this.btn_brique_doubleBoules.UseVisualStyleBackColor = true;
            this.btn_brique_doubleBoules.Click += new System.EventHandler(this.btn_brique_doubleBoules_Click);
            // 
            // btn_brique_Empty
            // 
            this.btn_brique_Empty.Location = new System.Drawing.Point(404, 327);
            this.btn_brique_Empty.Margin = new System.Windows.Forms.Padding(0, 0, 1, 1);
            this.btn_brique_Empty.Name = "btn_brique_Empty";
            this.btn_brique_Empty.Size = new System.Drawing.Size(98, 23);
            this.btn_brique_Empty.TabIndex = 11;
            this.btn_brique_Empty.Text = "Supprimer Brique";
            this.btn_brique_Empty.UseVisualStyleBackColor = true;
            this.btn_brique_Empty.Click += new System.EventHandler(this.btn_brique_Empty_Click);
            // 
            // btn_createEmpty
            // 
            this.btn_createEmpty.Location = new System.Drawing.Point(404, 56);
            this.btn_createEmpty.Name = "btn_createEmpty";
            this.btn_createEmpty.Size = new System.Drawing.Size(98, 40);
            this.btn_createEmpty.TabIndex = 5;
            this.btn_createEmpty.Text = "Créer nouveau niveau vide";
            this.btn_createEmpty.UseVisualStyleBackColor = true;
            this.btn_createEmpty.Click += new System.EventHandler(this.btn_createEmpty_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(410, 158);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Selection brique";
            // 
            // créer_niveau
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(520, 426);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btn_createEmpty);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.btn_load);
            this.Controls.Add(this.btn_random);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btn_brique_Empty);
            this.Controls.Add(this.btn_Save);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "créer_niveau";
            this.Text = "Casse briques";
            this.Load += new System.EventHandler(this.créer_niveau_Load);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btn_Save;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btn_random;
        private System.Windows.Forms.Button btn_load;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button btn_createEmpty;
        private System.Windows.Forms.Button btn_brique;
        private System.Windows.Forms.Button btn_brique_RetourNorm;
        private System.Windows.Forms.Button btn_brique_Retrecire;
        private System.Windows.Forms.Button btn_brique_3coup;
        private System.Windows.Forms.Button btn_brique_doubleBoules;
        private System.Windows.Forms.Button btn_brique_rapide;
        private System.Windows.Forms.Button btn_brique_Empty;
        private System.Windows.Forms.Label label2;
    }
}