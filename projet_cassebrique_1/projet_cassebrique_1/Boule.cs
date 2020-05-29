using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace CasseBriques {
	class Boule {
		// x et y désignent les coordonnées du centre de la boule
		private int x, y, depX, depY, rayon, vitesse;
		private Color couleur;

		public Boule() {
			rayon = 4;
			x = 175;
			y = 310 - rayon;
			couleur = Color.Red;
			vitesse = 5;
		}

		private double rad(double angle) {
			// Retourne la valeur en radians de l'angle en degrés passé en paramètre.
			return angle * Math.PI / 180;
		}

		private int deg(double angle) {
			// Retourne la valeur en degrés de l'angle en radians passé en paramètre.
			return (int)(angle *  180 / Math.PI);
		}
		
		public void angleDep(int angle) {
			// L'angle doit être compris entre 20 et 160 degrés (c'est mieux !)
			if (angle < 20) {
				angle = 20;
			}
			else {
				if (angle > 160) {
					angle = 160;
				}
			}
			// Calcul des déplacements en x et en y selon l'angle
			//Les fonctions de la classe Math travaillent en radians ( d'où conversion).
			depX = (int)(Math.Cos(rad(angle)) * vitesse);
			depY = (int)(-Math.Sin(rad(angle)) * vitesse);
		}

		public void modifAngle(int arc) {
			// Il faut faire l'arc-cosinus du déplacement en x pour retrouver l'angle
			// du déplacement et pouvoir lui ajouter arc degrés. Les fonctions
			// de la classe Math travaillent en radians ( d'où conversion).
			angleDep(deg(Math.Acos(depX / vitesse)) + arc);
		}

		public void chocH() {
			depX = -depX;
		}

		public void chocV() {
			depY = -depY;
		}

		public void place(int newX, int newY) {
			x = newX;
			y = newY;
		}

		public void deplace() {
			x = x + depX;
			y = y + depY;
		}

		public int getRayon() {
			return rayon;
		}

		public int getX() {
			return x;
		}

		public int getY() {
			return y;
		}

		public Color getCouleur() {
			return couleur;
		}

		public void dessine(Graphics motif) {
			motif.FillEllipse(new SolidBrush(couleur),x - rayon, y - rayon, rayon * 2, rayon * 2);
		}
	}
}
