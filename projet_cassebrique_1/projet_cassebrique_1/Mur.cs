using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace CasseBriques {
	class Mur {
		  private Brique[,] mur=new Brique[10,20];
			private int nbBriques;


			public void construit() {
				// Affectaion aléatoire de briques au mur
				Random R = new Random();
				for(int l=0; l<10; l++) {
					for(int c=0; c<20; c++) {
						switch (R.Next(11)) {
							case 1 :
								mur[l,c]=new BriqueRetourNorme();
								break;
							case 2 :
								mur[l,c]=new BriqueBouleRapide();
								break;
							case 3:
								mur[l, c] = new BriqueBarreRetrecire();
								break;
							default :
								mur[l,c]=new Brique();
								break;
						}
						mur[l,c].positionne(c*(mur[l,c].getLargeur()+1),
																 l*(mur[l,c].getHauteur()+1));
					}
				}
				nbBriques=200;
			}

			public bool percute(int l, int c) {

				// Coordonnées hors du mur ?
				if (l<0 || l > 9 || c<0 || c>19) {
					// Le mur n'a pas été percuté
					return false;
				}
				else
					// Si la brique à ces cordonnées était déjà détruite ...
					if (mur[l,c].isDetruite()) {
						// Le mur n'a pas été percuté
						return false;
					}
					else {
						// Le mur est percuté
						return true;
					}
			}

			public int casse(int l, int c) {
				int consequence=0;
				// Si les coordonnées sont dans le mur (pas de coordonnées hors tableau)
				if (l>=0 && l <10 && c>=0 && c<20) {
					// Si la brique à ces coordonnées n'était pas détruite ...
					if (!mur[l,c].isDetruite()) {
						// La brique reçoit un choc (qui peut avoir une conséquence)
						consequence=mur[l,c].choc();
						// Si le choc a détruit la brique ...
						if (mur[l,c].isDetruite()) {
							// Une brique en moins, une !
							nbBriques--;
						}
					}
				}
				return consequence;
			}

			public int getNbBriques() {
				return nbBriques;
		}

		public int getLargeurBrique() {
			return mur[0,0].getLargeur();
		}

		public int getHauteurBrique() {
			return mur[0,0].getHauteur();
		}

		public void dessine(Graphics support) {
			// Dessin du mur de brique
			for(int l=0;l<10;l++) {
				for (int c=0; c<20; c++) {
					// Si la brique n'est pas détruite ...
					if (!mur[l,c].isDetruite())
						// On la dessine
						mur[l,c].dessine(support);
				}
			}
		}
	}
}
