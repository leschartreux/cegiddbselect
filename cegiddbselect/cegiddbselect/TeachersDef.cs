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
    public partial class frmDbSelect
    {
        //Définition des professeurs par un dictionnaire indice/valeur.
        private Dictionary<int, String> dTeachers = new Dictionary<int, string>{
                                                    {1,"PROF 1"},
                                                    {2,"PROF 2"},
                                                    {3,"PROF 3"},
                                                    {4,"PROF 4"},
                                                    {5,"PROF 5"},
                                                    {6,"PROF 6"},
                                                    {99,"AUTRES"}
                                                };

    }
}
