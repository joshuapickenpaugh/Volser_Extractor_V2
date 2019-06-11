using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.IO;

//Defined since "Path" was being used "ambigously":
using Path = System.IO.Path;

namespace Volser_Extractor_V2
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        string strFileContentsAndPathAndName;

        //"BROWSE" button (used to look for ASCII-converted email in TOUT folder):
        private void BtnBrowse_Click(object sender, EventArgs e)
        {
            // Show the Windows dialog box:
            DialogResult diagDialogBoxResult = openFileDialogBox.ShowDialog();

            if (diagDialogBoxResult == DialogResult.OK)
            {
                strFileContentsAndPathAndName = openFileDialogBox.FileName;

                //Tests for correct ".txt" suffix:
                string strFileExtension = Path.GetExtension(strFileContentsAndPathAndName);
                if (strFileExtension == ".txt")
                {
                    //Displays only the filepath and filename in textbox:                    
                    txtDisplay.Text = strFileContentsAndPathAndName;                    
                }
                //If not correct file type, display messagebox:
                else
                {
                    MessageBox.Show("NOT CORRECT FILE TYPE, PLEASE SELECT YOUR BOMTIN.TXT or BOMTOUT.TXT FILE");
                }
            }            
        }

        //"EXTRACT and CREATE FILE" button:
        private void BtnExtract_Click(object sender, EventArgs e)
        {
            string strText = "";

            //Function to put strText through a REGEX and return extracted VOLSERS:
            string strVolsers = GetExtractedVolsers(strText);

            //Function to create file and save to same location as original file:

            //Display message to user:
            MessageBox.Show("Your new VOLSER-extracted file created and placed in " +
                "same folder as your selected REQ file.");

            //Closes the app:
            this.Close();
        }

        //Extract 9840-type tapes (from the ""EXTRACT and CREATE FILE" button):
        public string GetExtractedVolsers(string strText)
        {
            //Reads the filecontents into an array:
            string[] aryFileContents = File.ReadAllLines(strText);

            //Used to apply a REGEX to aryFileContents in the FOREACH:
            StringBuilder sbApplyRegex = new StringBuilder();

            //Reads through the array, extracts the 6-digit numbers:
            foreach (string filecontent in aryFileContents)
            {
                sbApplyRegex.Append(Regex.Match(filecontent, @"(?<!\d)\d{6}(?!\d)").ToString());
                sbApplyRegex.Append(Environment.NewLine);
            }

            string strVolsers = sbApplyRegex.ToString();

            Console.WriteLine(strVolsers);            

            return strVolsers;
        }


    }
}
