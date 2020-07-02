using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.Serialization;
namespace CasseBriques
{
    public class Mur
    {
        
        
        const int nbrcol = 10; // 10
        const int nbrligne = 20; //20
        int nbBriques = nbrcol * nbrligne;
        int pourcentBriqueSpeciale = 25;//probabité que la brique soit spéciale (ici 25%)
        
        public Mur(int unPourcentBriqueSpeciale)
        {
            pourcentBriqueSpeciale = unPourcentBriqueSpeciale;
        }
        public Mur()
        {
            
        }
        Brique[,] mur = new Brique[nbrcol, nbrligne];


        //List<> listeBriques = new List<Brique>() { };
        

        //mur = new Brique[10, 20];


        //Brique[,] mur = new Brique[unNbrcol, nbrligne];



        public void ChangeBrique(int unX, int unY,int Brique)
        {
            switch (Brique) //a changer suivant le nombre de brique
            {
                
                case 0:
                    mur[unX, unY] = new BriqueRetourNorme();
                    break;
                case 1:
                    mur[unX, unY] = new BriqueBouleRapide();
                    break;
                case 2:
                    mur[unX, unY] = new BriqueBarreRetrecire();
                    break;
                case 3:
                    mur[unX, unY] = new Brique3coup();
                    break;
                case 4:
                    mur[unX, unY] = new Brique2boules();
                    break;
                default:
                    mur[unX, unY] = new Brique();
                    break;


            }
            
            mur[unX, unY].positionne(unY * (mur[unX, unY].getLargeur() + 1), unX * (mur[unX, unY].getHauteur() + 1));
        }


        public void construit()
        {


            // Affectaion aléatoire de briques au mur
            Random R = new Random(); //choisit quel brique spéciale choisir
            Random RandomSpecial = new Random(); //choisit si la brique est normale ou spéciale
            Random RandomSpecialNegatif = new Random(); //choisit si la brique spéciale est positive ou negative
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
                        switch (R.Next(5)) //a changer suivant le nombre de brique
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
                            case 4:
                                mur[l, c] = new Brique2boules();
                                break;


                        }
                    }

                    mur[l, c].positionne(c * (mur[l, c].getLargeur() + 1), l * (mur[l, c].getHauteur() + 1));
                }
                
            }
            
        }

        public void Sauvegarder()
        {
            XmlSerializer xsSubmit = new XmlSerializer(typeof(Mur));
            
            var xml = "";

            using (var sww = new StringWriter())
            {
                using (XmlWriter writer = XmlWriter.Create(sww))
                {
                    xsSubmit.Serialize(writer, mur);
                    xml = sww.ToString(); // Your XML
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
