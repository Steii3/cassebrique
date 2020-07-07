using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Diagnostics;

namespace CasseBriques {
	[Serializable]
	public class Brique {
		protected const int SIMPLE=0;
		protected int x, y, largeur, hauteur;
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
	[Serializable]
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
	[Serializable]
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
	[Serializable]
	class BriqueBarreRetrecire : Brique
	{
		private const int BARRE_COURTE = 3;

		public BriqueBarreRetrecire() : base()
		{
			couleur = Color.Blue;
		}

		public override int choc()
		{
			base.choc();
			return BARRE_COURTE;
		}
	}
	[Serializable]
	class Brique3coup : Brique
	{
		private int vie_brique = 4;
		

		public Brique3coup() : base()
		{
			
			couleur = Color.Black;
		}

		public override int choc()
		{

			//Debug.WriteLine("x={0},y={1}, v={2}",x,y,vie_brique); //a ignorer sert au debug
			vie_brique--;
			if (vie_brique == 0)
			{
				base.choc();
			}
			else if (vie_brique == 2) 
			{

				couleur = Color.Gray;
			}
			else if (vie_brique == 1)
			{

				couleur = Color.LightGray;
			}

			
			return SIMPLE;

		}
	}
	[Serializable]
	class Brique2boules : Brique
	{

		private const int DOUBLE_BOULE = 4;

		public Brique2boules() : base()
		{

			couleur = Color.Green;
			
		}

		public override int choc()
		{
			base.choc();
			return DOUBLE_BOULE;
			//Debug.WriteLine("x={0},y={1}, v={2}",x,y,vie_brique); //a ignorer sert au debug

		}
	}




}
