using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Villa_Farms
{
    public partial class Form0 : Form
    {
        public Form0()
        {
            InitializeComponent();
        }

        private void leaseCreater_Click(object sender, EventArgs e)
        {
           // Opens up further forms to create a lease from a base doc.
            Form1 f1 = new Form1();
            f1.ShowDialog();
        }

        private void statementButt_Click(object sender, EventArgs e)
        {
            //Literally just prints a doc
            string filePath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
                + @"\VillaFarms,LeaseMaker\BaseFolder\"
                + @"Statement of Understanding.docx";

            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo(filePath) { UseShellExecute = true });


        }

        private void ProspectusButt_Click(object sender, EventArgs e)
        {
            //Opens up further forms to create a prosectus from a base doc.
            Form2 f2 = new Form2();
            f2.ShowDialog();

        }

        private void Form0_Load(object sender, EventArgs e)
        {

        }

        private void exhibitCButt_Click(object sender, EventArgs e)
        {
            //Literally just prints a doc
            string filePath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
               + @"\VillaFarms,LeaseMaker\BaseFolder\"
               + @"ExhibitC.docx";

            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo(filePath) { UseShellExecute = true });
        }
    }
}
