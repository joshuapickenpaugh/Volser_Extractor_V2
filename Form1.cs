using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//Via NuGet:
//...(this is the 2nd iteration of this program; the first wasn't working for some reason and 
//not loading the below "iTextSharp" libraries. This is a carbon-copy of the first, 
//I've no idea why this second now works. Keeping an eye on these "iTextSharp" libraries, they 
//may be a problem). 
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

        //"BROWSE FOR .PDF FILE" button:
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
                    MessageBox.Show("NOT CORRECT FILE TYPE, PLEASE SELECT YOUR OUTBOUND REQ .PDF FILE");
                }
            }
        }

        //"CREATE FILE" button:
        private void BtnExtract_Click(object sender, EventArgs e)
        {
            //Extract all text from the .pdf:
            string strText = GetTextFromPDF();

            //...for test poiposes:
            Console.WriteLine(strText);

            //Function to put strText through a REGEX and return extracted VOLSERS:
            //GetExtractedVolsers(strText);

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
            //FOR TEST PURPOSES:
            //Console.WriteLine(text);

            return text.ToString();
        }
        //public string GetExtractedVolsers(strText)
        //{
        //    string strVolsers = "";

        //    return strVolsers;
        //}
    }
}
