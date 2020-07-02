using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;


namespace CasseBriques
{
    public class Jeu : Panel
    {
        
        // Delai entre 2 déplacements
        private const int COOL = 2;
        private const int SPEED = 3;

        // Constantes rattachées aux phases de jeu
        private const int ATTEND = 1;
        private const int ROULE = 2;
        private const int SORT = 3;
        private const int GAGNE = 4;

        // Constantes rattachées aux types de briques
        private const int SIMPLE = 0;
        private const int NORME = 1;
        private const int RAPIDE = 2;
        private const int BARRE_COURTE = 3;
        private const int DOUBLE_BOULE = 4;
        // Champs d'instance
        private Timer action;
        private int delai;
        private int phase;
        private Barre barre;
        private Boule boule1;
        private Mur mur;
        private int vie_max = 3;
        private int vie;
        private Timer Reset_Etat_Timer;
        private int niveau = 1;
        private int difficulté = 20;
        bool fini;

        List<Boule> listeBoule = new List<Boule>();
       
        public Jeu()
        {

            // Création de la barre
            barre = new Barre();
            // Création de la boule
            boule1 = new Boule();
            listeBoule.Add(boule1);
        }

        public void initialiseNiveau()
        {
            
            //reinitialise vie et etat negatif a la creation d'une nouvelle partie
            vie = vie_max;
            modifJeu(NORME);
            fini = false;

            //detruit le timer de la partie d'avant avant de le re-créer par precaution
            if (Reset_Etat_Timer != null)
            {
                Reset_Etat_Timer.Dispose();
            }

            // Création du mur de brique
            if (difficulté != 100)
            { for (int i = 1; i < niveau; i++)
                {
                    difficulté += 10;
                }
            }

            mur = new Mur(difficulté);
            mur.construit();
            
            // Délai entre 2 déplacements
            delai = COOL;

            // Première phase du jeu
            phase = ATTEND;

            // Lancement (si besoin) de l'exécution du jeu dans un thread
            if (action == null)
            {
                action = new Timer();
                action.Tick += new EventHandler(CaRoule);
            }

            int nbrBoules = listeBoule.Count;
            
            action.Interval =  20 ; //20
            
            action.Start();

            // Lancement(si besoin) du timer de reinitialisation d'etat negatif
            if (Reset_Etat_Timer == null)
            {
                Reset_Etat_Timer = new Timer();
                Reset_Etat_Timer.Tick += new EventHandler(Reset_Etat_Timer_Tick);
            }
            Reset_Etat_Timer.Interval = 30000;



            void Reset_Etat_Timer_Tick(object sender, EventArgs e)
            {
                //Debug.WriteLine("wow ça marche !!!!");
                modifJeu(NORME);
                Debug.WriteLine("etat negatif supprimé");
            }



        }

        void changeTickRate()
        {
            int valeurInterval = (20 / listeBoule.Count);
            //int rounded = Convert.ToInt32(Math.Round(nbr, 0)); // round the number and convert it to a int
  
            action.Interval = valeurInterval; //20
        }
        // Traitement central exécuté avec une périodicité précise
        void CaRoule(Object sender, EventArgs e)
        {
            changeTickRate();
            fini = false;

            int cpt = 0;
            while (cpt < delai && fini == false)
            {

                foreach (Boule boule in listeBoule.ToArray())
                {
                    
                    // Selon la phase du jeu ...
                    switch (phase)
                    {

                        // Attente de lancement de la boule
                        case ATTEND:

                            //stop le timer de reinitilisation d'etat si le jeu est en attente
                            Reset_Etat_Timer.Stop();

                            // Placement de la boule au milieu de la barre
                            boule.place(barre.getX(), barre.getY() - boule.getRayon());
                            break;

                        // La boule roule
                        case ROULE:

                            //reactive le timer de reinitilisation d'etat
                            Reset_Etat_Timer.Start();

                            // Déplacement de la boule

                            boule.deplace();
                            // Rebond sur le bord gauche ?
                            if (boule.getX() < boule.getRayon())
                            {
                                boule.chocH();
                                boule.place(boule.getRayon(), boule.getY());
                            }
                            else
                            {
                                // Rebond sur le bord droit ?
                                if (boule.getX() > this.Width - boule.getRayon())
                                {
                                    boule.chocH();
                                    boule.place(this.Width - boule.getRayon(), boule.getY());
                                }
                            }
                            // Rebond sur le haut ?
                            if (boule.getY() < boule.getRayon())
                            {
                                boule.chocV();
                                boule.place(boule.getX(), boule.getRayon());
                            }
                            else
                            {
                                // Rebond (ou non) sur la barre ?
                                if (boule.getY() > 310 - boule.getRayon())
                                {
                                    if ((boule.getX() - boule.getRayon() < barre.getX() + barre.getMiLargeur())
                                        &&
                                            (boule.getX() + boule.getRayon() > barre.getX() - barre.getMiLargeur()))
                                    {
                                        // Rebond sur la barre
                                        // Le rebond dépend de la zone de la barre touchée
                                        rebondSurBarre(boule.getX() - barre.getX(), boule);

                                        boule.place(boule.getX(), 310 - boule.getRayon());
                                    }
                                    else
                                    {
                                        // Si la boule touche le fond ...
                                        if (boule.getY() > 310 + barre.getHauteur() - boule.getRayon())
                                        {
                                            // Loupé !!
                                            if (listeBoule.Count > 1)
                                            {
                                                listeBoule.RemoveAt(listeBoule.IndexOf(boule));
                                                // Loupé !!
                                            }
                                            else
                                            {
                                                vie--;
                                                if (vie == 0)
                                                //si le joueur n'as plus de vie, termine le jeux
                                                {
                                                    phase = SORT;
                                                }
                                                else
                                                {

                                                    // si le joueur a encore de la vie, place la boule sur la 
                                                    // barre et met en mode attend
                                                    boule.place(barre.getX(), barre.getY() - boule.getRayon());
                                                    phase = ATTEND;
                                                    modifJeu(NORME); //reset état negatif quand pert une vie
                                                }
                                            }
                                                

                                        }

                                    }
                                }
                            }
                            // Gestion du choc avec une brique
                            // Récupération de la hauteur d'une brique
                            int hauteur = mur.getHauteurBrique();
                            // Récupération de la largeur d'une brique
                            int largeur = mur.getLargeurBrique();
                            // Si la boule se trouve dans la zone du mur de briques ...
                            if (boule.getY() - boule.getRayon() < 10 * (hauteur + 1))
                            {
                                // l1, c1 sont les coordonnées du coin supérieur gauche de la boule
                                // l2, c2 sont les coordonnées du coin inférieur droit de la boule
                                int l1, l2, c1, c2;
                                l1 = (int)((boule.getY() - boule.getRayon()) / (hauteur + 1));
                                l2 = (int)((boule.getY() + boule.getRayon()) / (hauteur + 1));
                                c1 = (int)((boule.getX() - boule.getRayon()) / (largeur + 1));
                                c2 = (int)((boule.getX() + boule.getRayon()) / (largeur + 1));

                                // Le rebond dépend des coins (1 ou 2) en contact avec une brique
                                // Coin supérieur gauche ...
                                if (mur.percute(l1, c1))
                                {
                                    // et coin supérieur droit
                                    if (mur.percute(l1, c2))
                                    {
                                        // Choc vertical
                                        boule.chocV();
                                    }
                                    else
                                    {
                                        // et coin inférieur gauche
                                        if (mur.percute(l2, c1))
                                        {
                                            // Choc horizontal
                                            boule.chocH();
                                        }
                                        else
                                        {
                                            // Double choc
                                            boule.chocV();
                                            boule.chocH();
                                        }
                                    }
                                }
                                else
                                {
                                    // Coin supérieur droit ...
                                    if (mur.percute(l1, c2))
                                    {
                                        // et coin inférieur droit
                                        if (mur.percute(l2, c2))
                                        {
                                            // Choc horizontal
                                            boule.chocH();
                                        }
                                        else
                                        {
                                            // Double choc
                                            boule.chocV();
                                            boule.chocH();
                                        }
                                    }
                                    else
                                    {
                                        // Coin inférieur gauche ...
                                        if (mur.percute(l2, c1))
                                        {
                                            // et coin inférieur droit
                                            if (mur.percute(l2, c2))
                                            {
                                                // Choc vertical
                                                boule.chocV();
                                            }
                                            else
                                            {
                                                // Double choc
                                                boule.chocV();
                                                boule.chocH();
                                            }
                                        }
                                        else
                                        {
                                            // Coin inférieur droit
                                            if (mur.percute(l2, c2))
                                            {
                                                // Double choc
                                                boule.chocV();
                                                boule.chocH();
                                            }
                                        }
                                    }
                                }
                                // Casse effective des brique du mur
                                //(et mise en place des conséquences)
                                modifJeu(mur.casse(l1, c1));
                                modifJeu(mur.casse(l1, c2));
                                modifJeu(mur.casse(l2, c1));
                                modifJeu(mur.casse(l2, c2));

                                // Si toutes les briques sont cassées ...
                                if (mur.getNbBriques() == 0)
                                {
                                    // Le joueur à gagné
                                    phase = GAGNE;
                                }
                            }
                            break;

                        case SORT:
                            action.Stop();
                            MessageBox.Show(this, "C'est perdu ! vous avez tenu " + niveau + " niveau !", "Casse briques", MessageBoxButtons.OK);
                            fini = true;
                            break;

                        case GAGNE:
                            action.Stop();
                            MessageBox.Show(this, "Bravo, vous fini le niveau " + niveau + " !\nLa difficulté augmente !", "Casse briques", MessageBoxButtons.OK);
                            niveau++;
                            initialiseNiveau();
                            fini = true;
                            break;
                    }

                    // on redessine l'espace de jeu
                    Dessiner();

                    cpt++;
                }
                
            }
        }

        void rebondSurBarre(int impact, Boule boule)
        {
            // Rebond sur la barre
            boule.chocV();
            // La barre est divisée en 5 parties. Chaque partie provoque un rebond différent
            // Partie extrème gauche : Augmentation de l'angle de 30 degrés
            if (impact < -(barre.getMiLargeur() * 0.6))
                boule.modifAngle(30);
            else
                // Partie suivante : Augmentation de l'angle de 15 degrés
                if (impact < -(barre.getMiLargeur() * 0.2))
                boule.modifAngle(15);

            // Partie extrème droite : Diminution de l'angle de 30 degrés
            if (impact > (barre.getMiLargeur() * 0.6))
                boule.modifAngle(-30);
            else
                // Partie précédante : Diminution de l'angle de 15 degrés
                if (impact > (barre.getMiLargeur() * 0.2))
                boule.modifAngle(-15);

            // La partie centrale de la barre provoque un rebond normal

        }

        void modifJeu(int modif)
        {
            switch (modif)
            {
                case NORME:

                    // Retour aux valeurs de base
                    delai = COOL;
                    barre.setMiLargeur(Barre.TAILLE);
                    break;

                case RAPIDE:
                    // Accélération du traitement
                    delai = SPEED;
                    break;
                case BARRE_COURTE:
                    int currentL = barre.getMiLargeur();
                    //retrecie la barre que si la barre est superieur ou égale a la taille originale
                    if (currentL >= Barre.TAILLE)
                    {
                        barre.setMiLargeur(currentL - 10);
                    }

                    break;
                case DOUBLE_BOULE:
                    listeBoule.Add(new Boule( listeBoule[0].getX() , listeBoule[0].getY() ));
                    break;

            }
        }



        void lanceBoule(int angle, Boule boule)
        {
            if (phase == ATTEND)
            {
                phase = ROULE;
                boule.angleDep(angle);
            }
        }

        void Dessiner()
        {
            BufferedGraphics B = BufferedGraphicsManager.Current.Allocate(this.CreateGraphics(), new Rectangle(0, 0, this.Width, this.Height));
            Graphics ZoneJeu = B.Graphics;
            // Effacement de l'espace de jeu
            ZoneJeu.FillRectangle(new SolidBrush(this.BackColor), 0, 0, this.Width, this.Height);
            // Dessin de la barre
            barre.dessine(ZoneJeu);
            // Dessin de la boule
            foreach (Boule boule in listeBoule.ToArray())
            {
                boule.dessine(ZoneJeu);
            }
            
            // Dessin du mur de brique
            // Au tout départ le mur n'existe pas
            if (mur != null)
                mur.dessine(ZoneJeu);
            B.Render();
            ZoneJeu.Dispose();
            B.Dispose();
        }

        public void EspaceJeu_MouseMove(object sender, MouseEventArgs evt)
        {
            // Si le pointeur est trop à gauche ...
            if (evt.X < barre.getMiLargeur())
                // barre contre le bord gauche
                barre.setX(barre.getMiLargeur());
            else
                // Si de pointeur est trop à droite ...
                if (evt.X > this.Width - barre.getMiLargeur())
                // barre contre le bord droit
                barre.setX(this.Width - barre.getMiLargeur());
            else
                // barre centrée sur le pointeur
                barre.setX(evt.X);
        }

        public void EspaceJeu_MouseClick(object sender, MouseEventArgs e)
        {
            lanceBoule(new Random().Next(120) + 30, listeBoule[0]);
        }

    }
}
