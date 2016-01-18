using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
//using System.Threading.Tasks;
using System.Windows.Forms;

namespace cegiddbselect
{
    public partial class frmDbSelect : Form
    {

       
        //Définition des Chemins et des fichiers ini
        private string strLocalIniPath=@"C:\programdata\cegid\";
        private string strIniFile = "CegidPGI.ini";
        private string strIniFilePath="";
        private string strTeacherFile = "";

        public frmDbSelect()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Chargement du formulaire
        /// Initialisation du combo à partir du Dictionnaire
        /// Masque la partie basse du formulaire
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmDbSelect_Load(object sender, EventArgs e)
        {
            strIniFilePath = strLocalIniPath + strIniFile;

            foreach (KeyValuePair<int, string> Prof in dTeachers)
                cbProf.Items.Add(Prof);

            btnEnd.Visible = false;
            label3.Text = "1- Fichier Chargé\n2- Laissez ce programme ouvert\n3- Lancer l\'loutil d\'administration\n4- Fermez l'outil Cegid\n5- Cliquez sur terminer pour sauvegarder vos modifications";
            label3.Visible = false;


        }

        /// <summary>
        /// Clic sur le bouton OK
        /// Copie le fichier ini correspondant au prof sélectionné
        /// Affiche la fin
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOK_Click(object sender, EventArgs e)
        {
            //Contrôle si un professeur a bien été assigné
            if (cbProf.SelectedItem == null)
            {
                MessageBox.Show ("Sélectionnez d'abord le professeur.");
                cbProf.Focus();
                return;
            }

            //La combo contient des éléments du dictionnaire
            //Conversion de l'élément sélectionné en Objet Clé/valeur
            KeyValuePair<int,string> Selected = (KeyValuePair<int,string>) cbProf.SelectedItem;
            int iTeacherNumber = Selected.Key;

            strTeacherFile = strServerShare + "Cegid_T_" + iTeacherNumber+ ".ini";
            System.IO.File.Copy(strTeacherFile, strIniFilePath, true);

            //version Client (sans bouton terminer) définie via l'option de compilation
            //permet d'avoir 2 exécutables différents avec un même projet
#if (CLIENT)
            MessageBox.Show("Fichier Chargé.\nVous pouvez lancer Cegid");
#else           
            label3.Visible = true;
            btnEnd.Visible = true;
#endif
        }

        /// <summary>
        /// Clic sur le bouton Terminé
        /// Sauvegarde le fichier INI modifié correspondant au professeur
        /// Ferme la fenêtre
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEnd_Click(object sender, EventArgs e)
        {
            System.IO.File.Copy(strIniFilePath, strTeacherFile,true);
            this.Close();
        }

        /// <summary>
        /// Clic sur bouton annuler
        /// Ferme la fenêtre
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        

    }
}
