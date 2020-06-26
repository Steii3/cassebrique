using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace CasseBriques
{
    class Mur
    {
        
        
        const int nbrcol = 3; // 10
        const int nbrligne = 1; //20
        int nbBriques = nbrcol * nbrligne;
        int pourcentBriqueSpeciale = 25;//probabité que la brique soit spéciale (ici 25%)
        
        public Mur(int unPourcentBriqueSpeciale)
        {
            pourcentBriqueSpeciale = unPourcentBriqueSpeciale;
            

        }

        Brique[,] mur = new Brique[nbrcol, nbrligne];



        //mur = new Brique[10, 20];


        //Brique[,] mur = new Brique[unNbrcol, nbrligne];






        public void construit()
        {


            // Affectaion aléatoire de briques au mur
            Random R = new Random();
            Random RandomSpecial = new Random();
            for (int l = 0; l < nbrcol; l++)
            {
                for (int c = 0; c < nbrligne; c++)
                {
                    if (RandomSpecial.Next(100) >= pourcentBriqueSpeciale) 
                    {
                        mur[l, c] = new Brique();
                    }
                    else
                    { //si la brique est spéciale, choisit aléatoirement laquel
                        switch (R.Next(4)) //a changer suivant le nombre de brique
                        {

                            case 0:
                                mur[l, c] = new BriqueRetourNorme();
                                break;
                            case 1:
                                mur[l, c] = new BriqueBouleRapide();
                                break;
                            case 2:
                                mur[l, c] = new BriqueBarreRetrecire();
                                break;
                            case 3:
                                mur[l, c] = new Brique3coup();
                                break;
                            

                        }
                    }
                    //switch (R.Next(difficulty))
                    //{

                    //    case 1:
                    //        mur[l, c] = new BriqueRetourNorme();
                    //        break;
                    //    case 2:
                    //        mur[l, c] = new BriqueBouleRapide();
                    //        break;
                    //    case 3:
                    //        mur[l, c] = new BriqueBarreRetrecire();
                    //        break;
                    //    case 4:
                    //        mur[l, c] = new Brique3coup();
                    //        break;
                    //    default:
                    //        mur[l, c] = new Brique();
                    //        break;
                    //}
                    mur[l, c].positionne(c * (mur[l, c].getLargeur() + 1), l * (mur[l, c].getHauteur() + 1));
                }
                
            }
            
        }

        public bool percute(int l, int c)
        {

            // Coordonnées hors du mur ?
            if (l < 0 || l > nbrcol-1 || c < 0 || c > nbrligne-1)
            {
                // Le mur n'a pas été percuté
                return false;
            }
            else
                // Si la brique à ces cordonnées était déjà détruite ...
                if (mur[l, c].isDetruite())
            {
                // Le mur n'a pas été percuté
                return false;
            }
            else
            {
                // Le mur est percuté
                return true;
            }
        }

        public int casse(int l, int c)
        {
            int consequence = 0;
            // Si les coordonnées sont dans le mur (pas de coordonnées hors tableau)
            if (l >= 0 && l < nbrcol && c >= 0 && c < nbrligne)
            {
                // Si la brique à ces coordonnées n'était pas détruite ...
                if (!mur[l, c].isDetruite())
                {
                    // La brique reçoit un choc (qui peut avoir une conséquence)
                    consequence = mur[l, c].choc();
                    // Si le choc a détruit la brique ...
                    if (mur[l, c].isDetruite())
                    {
                        // Une brique en moins, une !
                        nbBriques--;
                    }
                }
            }
            return consequence;
        }

        public int getNbBriques()
        {
            return nbBriques;
        }

        public int getLargeurBrique()
        {
            return mur[0, 0].getLargeur();
        }

        public int getHauteurBrique()
        {
            return mur[0, 0].getHauteur();
        }

        public void dessine(Graphics support)
        {
            // Dessin du mur de brique
            for (int l = 0; l < nbrcol; l++)
            {
                for (int c = 0; c < nbrligne; c++)
                {
                    // Si la brique n'est pas détruite ...
                    if (!mur[l, c].isDetruite())
                        // On la dessine
                        mur[l, c].dessine(support);
                }
            }
        }
    }
}
