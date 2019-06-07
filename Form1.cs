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

//Via NuGet:
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;

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

        //"BROWSE" button:
        private void BtnBrowse_Click(object sender, EventArgs e)
        {
            // Show the Windows dialog box:
            DialogResult diagDialogBoxResult = openFileDialogBox.ShowDialog();

            if (diagDialogBoxResult == DialogResult.OK)
            {
                strFileContentsAndPathAndName = openFileDialogBox.FileName;

                //Tests for correct ".pdf" suffix:
                string strFileExtension = Path.GetExtension(strFileContentsAndPathAndName);
                if (strFileExtension == ".pdf")
                {
                    //Displays the filepath and filename in textbox:                    
                    txtDisplay.Text = strFileContentsAndPathAndName;
                }
                //If not correct file type, display messagebox:
                else
                {
                    MessageBox.Show("NOT CORRECT FILE TYPE, PLEASE SELECT YOUR REQ .PDF FILE");
                }
            }
        }

        //"EXTRACT and CREATE FILE" button:
        private void BtnExtract_Click(object sender, EventArgs e)
        {
            //Extract all text from the .pdf:
            string strText = GetTextFromPDF();           

            //Function to put strText through a REGEX and return extracted VOLSERS:
            string strVolsers = GetExtractedVolsers(strText);

            //Function to create file and save to same location as original file:

            //Display message to user:
            MessageBox.Show("Your new VOLSER-extracted file created and placed in " +
                "same folder as your selected REQ file.");

            //Closes the app:
            this.Close();
        }

        //Below code from https://www.c-sharpcorner.com/blogs/reading-contents-from-pdf-word-text-files-in-c-sharp1
        private string GetTextFromPDF()
        {
            StringBuilder text = new StringBuilder();
            using (PdfReader reader = new PdfReader(strFileContentsAndPathAndName))
            {
                for (int i = 1; i <= reader.NumberOfPages; i++)
                {
                    text.Append(PdfTextExtractor.GetTextFromPage(reader, i));
                }
            }

            return text.ToString();
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
