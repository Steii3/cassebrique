using projet_cassebrique_1;
using System;
using System.Windows.Forms;
using System.Reflection;

namespace CasseBriques {
	public partial class CB : Form {
		

		public CB() {
			InitializeComponent();
		}

		private void nouveauToolStripMenuItem_Click(object sender, EventArgs e) {
			EspaceJeu.setloadedLevel(false);
			EspaceJeu.initialiseNiveau();
		}

		private void quitterToolStripMenuItem_Click(object sender, EventArgs e) {
			Application.Exit();
		}

        private void CB_Load(object sender, EventArgs e)
        {
			
		}

        private void EspaceJeu_MouseMove(object sender, MouseEventArgs e)
        {
            EspaceJeu.EspaceJeu_MouseMove(sender, e);
        }

        private void EspaceJeu_MouseClick(object sender, MouseEventArgs e)
        {
            EspaceJeu.EspaceJeu_MouseClick(sender, e);
        }
		
		private void CreateLVToolStripMenuItem_Click(object sender, EventArgs e)
		{
			créer_niveau créer_niveau_Form = new créer_niveau();
			//Application.Run(new créer_niveau());
			créer_niveau_Form.Show();
			
		}

		private void LoadLVToolStripMenuItem_Click(object sender, EventArgs e)
		{
			OpenFileDialog loader = new OpenFileDialog();
			loader.Title = "lancer niveau";
			loader.InitialDirectory = Assembly.GetExecutingAssembly().Location;
			loader.Filter = "binary file (*.bin) | *.bin";
			loader.FilterIndex = 2;
			loader.RestoreDirectory = true;

			if (loader.ShowDialog() == DialogResult.OK)
			{
				//Get the path of specified file
				string FilePath = loader.FileName;
				
				EspaceJeu.setMur(Mur.BinarySerialization.ReadFromBinaryFile<Mur>(FilePath));
				EspaceJeu.setloadedLevel(true);
				EspaceJeu.initialiseNiveau();
			}
		}

		private void EspaceJeu_Paint(object sender, PaintEventArgs e)
		{

		}
	}
}
