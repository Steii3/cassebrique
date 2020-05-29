using System;
using System.Windows.Forms;

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

		
	}
}
