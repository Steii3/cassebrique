using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace CasseBriques {
	class Brique {
		private const int SIMPLE=0;
		private int x, y, largeur, hauteur;
		protected Color couleur;
		protected bool detruite;

		public Brique() {
			largeur=17;
			hauteur=14;
            couleur = Color.FromArgb(0, 250, 0);
			detruite=false;
		}

		public virtual int choc() {
			// Si la brique n'est pas déjà détruite
			if (!detruite) {
				detruite=true;
			}
			return SIMPLE;
		}

		public bool isDetruite() {
			return detruite;
		}

		public void positionne(int newX, int newY) {
			x=newX;
			y=newY;
		}

		public int getHauteur() {
			return hauteur;
		}

		public int getLargeur() {
			return largeur;
		}

		public void dessine(Graphics motif){
			// Dessin de la brique
			motif.FillRectangle(new SolidBrush(couleur),x,y,largeur,hauteur);
		}
	}

	class BriqueRetourNorme : Brique {
  private const int NORME=1;

    public BriqueRetourNorme() : base() {

      couleur=Color.Pink;
    }

    public override int choc() {
      base.choc();
      return NORME;
    }

  }

    class BriqueBouleRapide : Brique
    {
        private const int RAPIDE = 2;

        public BriqueBouleRapide() : base()
        {
            couleur = Color.Yellow;
        }

        public override int choc()
        {
            base.choc();
            return RAPIDE;
        }
    }

}
