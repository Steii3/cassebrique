using System;
using System.Drawing;
using System.Drawing.Drawing2D;


namespace CasseBriques {
	class Barre {
		public const int TAILLE = 25;
		// x es la coordonnée horizontale du centre de la barre
		// et y du haut de la barre
		private int x, y, miLargeur, hauteur;
		private Color couleur;

		public Barre() {
			x=175;
			y=310;
			miLargeur=TAILLE;
			hauteur=9;
			couleur = Color.Blue;
		}

		public int getX() {
				return x;
		}

		public void setX(int newVal) {
				 x=newVal;
		}

		public int getY() {
				return y;
		}

		public int getMiLargeur() {
				return miLargeur;
		}

		public void setMiLargeur(int newVal) {
				 miLargeur=newVal;
		}


		public int getHauteur() {
				return hauteur;
		}

		public Color getCouleur() {
				return couleur;
		}


        public void dessine(Graphics motif) {
			motif.FillRectangle(new SolidBrush(couleur),x-miLargeur,y,miLargeur*2,hauteur);
		}
	}
}
