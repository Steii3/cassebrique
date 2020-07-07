using CasseBriques;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;
using System.Diagnostics;
using System.IO;

namespace projet_cassebrique_1
{
    public partial class créer_niveau : Form
    {
        public créer_niveau()
        {
            
            InitializeComponent();
            //Application.Run(new créer_niveau());
            
        }

        int x;
        int y;
        int Brique = 1;
        int pourcentageBriqueSpeciale = 25;
       
        Mur mur;
        
        private void créer_niveau_Load(object sender, EventArgs e)
        {

        }
        #region panel1
        private void panel_Mouseclick(object sender, MouseEventArgs e)
        {
            if (mur != null) 
            {
                x = e.X / 18;
                y = e.Y / 15;
                //Debug.WriteLine("x=" + x + " y=" + y);
                if (x <= 19 && y <= 9 && x >= 0 && y >= 0)
                {
                    mur.ChangeBrique(y, x, Brique);
                    panel1.Invalidate();
                }
            }
            
            
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (mur != null)
            {
                if (e.Button == MouseButtons.Left)
                {
                    x = e.X / 18;
                    y = e.Y / 15;
                    //Debug.WriteLine("x=" + x + " y=" + y);
                    if (x <= 19 && y <= 9 && x >= 0 && y >= 0)
                    {
                        mur.ChangeBrique(y, x, Brique);
                        panel1.Invalidate();
                    }
                }
            }
            
            
        }   

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            Graphics ZoneJeu = panel1.CreateGraphics();
            //ZoneJeu.FillRectangle(new SolidBrush(Color.Red), 0, 0, this.Width, this.Height);
            // Dessin du mur de brique
            // Au tout départ le mur n'existe pas
            if (mur != null)
            { mur.dessine(ZoneJeu); }

            ZoneJeu.Dispose();    
        }
        #endregion
        private void btn_random_Click(object sender, EventArgs e)
        {
            mur = new Mur(pourcentageBriqueSpeciale);
            mur.construit_random();
            panel1.Invalidate();
        }

        private void btn_load_Click(object sender, EventArgs e)
        {
            

            OpenFileDialog loader = new OpenFileDialog();
            loader.Title = "lancer niveau";
            loader.InitialDirectory = Assembly.GetExecutingAssembly().Location;
            loader.Filter = "binary file (*.bin) | *.bin";
            loader.FilterIndex = 2;
            loader.RestoreDirectory = true;
            
            if (loader.ShowDialog() == DialogResult.OK)
            {
                //Get the path of specified file
                string FilePath = loader.FileName;
                mur = Mur.BinarySerialization.ReadFromBinaryFile<Mur>(FilePath);
                panel1.Invalidate();
            }
            
        }

        private void btn_createEmpty_Click(object sender, EventArgs e)
        {
            mur = new Mur();
            mur.construit_empty();
            panel1.Invalidate();
        }


       

        private void btn_Save_Click(object sender, EventArgs e)
        {
            var folderBrowserDialog1 = new FolderBrowserDialog();
            mur.calculate_nbBrique();
            // Show the FolderBrowserDialog.
            DialogResult result = folderBrowserDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                string folderName = folderBrowserDialog1.SelectedPath;
                Mur.BinarySerialization.WriteToBinaryFile<Mur>(folderName + "/savedLV.bin", mur);
                //Mur.XmlSerialization.WriteToXmlFile<Mur>(folderName + "/savedLV.xml", mur);
            }
            
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem.ToString() == "Supprimer Boule")
            {
                Brique = 99;
            }
            else
            {
                Brique = listBox1.SelectedIndex;
            }
           
            

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            
            pourcentageBriqueSpeciale = Convert.ToInt32(numericUpDown1.Value);
        }
    }
}
