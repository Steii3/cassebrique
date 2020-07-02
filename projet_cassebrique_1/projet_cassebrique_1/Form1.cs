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
			string localdir = Assembly.GetExecutingAssembly().Location;
			OpenFileDialog loader = new OpenFileDialog();
			loader.Title = "lancer niveau par .json";
			loader.InitialDirectory = localdir;
			loader.Filter = "json file (*.json) | All files (*.*)";
			loader.FilterIndex = 2;
			loader.RestoreDirectory = true;
			loader.ShowDialog();
		}

		private void EspaceJeu_Paint(object sender, PaintEventArgs e)
		{

		}
	}
}
