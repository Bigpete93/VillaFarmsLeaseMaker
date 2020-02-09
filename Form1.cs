using Newtonsoft.Json;
using System;
using System.IO;
using System.Windows.Forms;
using Xceed.Document.NET;
using Xceed.Words.NET;
//using Novacode;
//using SautinSoft.Document;
using System.Linq;
using Utilities;

namespace Villa_Farms
{

    /******************************************************88
     Form one is incharge of remaking the Lease.
     */
    public partial class Form1 : Form
    {
        public FormStrings loader;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            loader = new FormStrings();
            residentText.Text = loader.residentName;
            DateTime dt = new DateTime();
            dt = DateTime.Now;
            string jsonFromFile;

            //Based off the user's system. Has a formatted .docx file.
            using (var reader = new StreamReader(
                Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + 
                @"\VillaFarms,LeaseMaker\BaseFolder\lease.json"
                ))
            {
                jsonFromFile = reader.ReadToEnd();
            };

            //A Json file has the default values for the form. Changes when updated.
            loader = JsonConvert.DeserializeObject<FormStrings>(jsonFromFile);
            residentText.Text = loader.residentName;
            //Resident 2 is an optional thing that might not exist.
            if (loader.resident2Name != "") resident2Text.Text = loader.resident2Name;
            lotText.Text = loader.lotNum;
            lotText.Text = loader.lotNum;
            leaseLengthText.Text = loader.monthLength;
            initialCostText.Text = loader.payExecution;
            rentText.Text = loader.payRent;
            amountPaidText.Text = loader.amountPaid;
            balanceDueText.Text = loader.balanceDue;
            preparerText.Text = loader.preparer;
            
            dt = dt.AddMonths(1);
            dt = dt.AddDays(-1 * dt.Day + 1);
            leasePicker.Value = dt;
            dt = dt.AddMonths(Int32.Parse(loader.monthLength));
            dt = dt.AddDays(-1); 
            endPicker.Value = dt;
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void residentText_TextChanged(object sender, EventArgs e)
        {

        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            //Upon saving, the project saves the values as defaults for next time.
            loader.residentName = residentText.Text;
            loader.resident2Name = resident2Text.Text;
            loader.lotNum = lotText.Text;
            loader.monthLength = leaseLengthText.Text;
            loader.payExecution = initialCostText.Text;
            loader.payRent = rentText.Text;
            loader.amountPaid = amountPaidText.Text;
            loader.balanceDue = balanceDueText.Text;
            loader.signDay = signPicker.Value.Day.ToString();
            loader.signMonth = signPicker.Value.Month.ToString();
            loader.signYear = signPicker.Value.Year.ToString();
            loader.endDay = endPicker.Value.Day.ToString();
            loader.endMonth = endPicker.Value.Month.ToString();
            loader.endYear = endPicker.Value.Year.ToString();
            loader.leaseDay = leasePicker.Value.Day.ToString();
            loader.leaseMonth = leasePicker.Value.Month.ToString();
            loader.leaseYear = leasePicker.Value.Year.ToString();
            loader.preparer = preparerText.Text;

            WordChangerLease change = new WordChangerLease();

            var jsonToFile = JsonConvert.SerializeObject(loader);
            using (var writer = new StreamWriter(
                Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) +
                @"\VillaFarms,LeaseMaker\BaseFolder\lease.json"
                ))
            {
                writer.Write(jsonToFile);
            };
            change.run(loader);

        }

        private void leaseLengthText_TextChanged(object sender, EventArgs e)
        {
            //some atomatic dating changes added. When the lease length is changed, the end of lease should too
            DateTime dt = new DateTime();
            dt = leasePicker.Value;
            
            try
            {
               dt = dt.AddMonths(Int32.Parse(leaseLengthText.Text.ToString()));
                //MessageBox.Show(dt.Date.ToString());
                endPicker.Value = dt;

            }
            catch (Exception)
            { }
        }

        private void leasePicker_ValueChanged(object sender, EventArgs e)
        {
        }

        private void endPicker_ValueChanged(object sender, EventArgs e)
        {

        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }
    }
    //Everything changed in a form.
    public class FormStrings
    {
        public string residentName { get; set; }  

        public string resident2Name { get; set; }
        public string preparer { get; set; }

        public string lotNum { get; set; }
        public string monthLength { get; set; }
        public string payExecution { get; set; }
        public string payRent { get; set; }
        public string amountPaid { get; set; }
        public string balanceDue { get; set; }
        public string signDay { get; set; }
        public string signMonth { get; set; }
        public string signYear { get; set; }

        public string leaseDay { get; set; }

        public string leaseMonth { get; set; }

        public string leaseYear { get; set; }
        public string endDay { get; set; }
        public string endMonth{ get; set; }
        public string endYear { get; set; }

    }

    public class WordChangerLease
    {
        public void run(FormStrings formStrings)
        {
            string filePath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) +
                @"\VillaFarms,LeaseMaker\BaseFolder\lease.docx";
            string fileResult = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) +
                @"\VillaFarms,LeaseMaker\PastPrinting\" +
                @formStrings.residentName + " Lease " + formStrings.signYear + ".docx";

            //Tries to find and edit a doc. Base doc is formated to find keywords and replace them.
            try
            {
                var dc = DocX.Load(filePath);
                dc.ReplaceText("[[residentName]]", formStrings.residentName);
                //Resident 2 might not exist. 
                if (formStrings.resident2Name != "")
                {
                    dc.ReplaceText("[[resident2NameOpening]]", " (and " + formStrings.resident2Name + ") ");
                    dc.ReplaceText("[[resident2Name]]", formStrings.resident2Name +
                        "\n\tX____________________________________________________________________");
                }

                else
                {
                    dc.ReplaceText("[[resident2Name]]", "");
                    dc.ReplaceText("[[resident2NameOpening]]", "");

                }

                dc.ReplaceText("[[lotNum]]", formStrings.lotNum);
                dc.ReplaceText("[[monthLength]]", formStrings.monthLength.ToWrittenWord() +
                    " (" + formStrings.monthLength + ")");
                dc.ReplaceText("[[payExecution]]", "$" + formStrings.payExecution + ".00");
                dc.ReplaceText("[[payRent]]", "$" + formStrings.payRent + ".00");
                dc.ReplaceText("[[amountPaid]]", "$" + formStrings.amountPaid + ".00");
                dc.ReplaceText("[[balanceDue]]", "$" + formStrings.balanceDue + ".00");
                dc.ReplaceText("[[signDay]]", long.Parse(formStrings.signDay).ToOrdinal().ToString());
                dc.ReplaceText("[[leaseDay]]", long.Parse(formStrings.leaseDay).ToOrdinal().ToString());
                dc.ReplaceText("[[endDay]]", long.Parse(formStrings.endDay).ToOrdinal().ToString());
                dc.ReplaceText("[[signMonth]]", Int32.Parse(formStrings.signMonth).MonthDic());
                dc.ReplaceText("[[leaseMonth]]", Int32.Parse(formStrings.signMonth).MonthDic());
                dc.ReplaceText("[[endMonth]]", Int32.Parse(formStrings.signMonth).MonthDic());
                dc.ReplaceText("[[signYear]]", formStrings.signYear);
                dc.ReplaceText("[[leaseYear]]", formStrings.leaseYear);
                dc.ReplaceText("[[endYear]]", formStrings.endYear);
                dc.ReplaceText("[[preparer]]", formStrings.preparer);


                dc.SaveAs(fileResult);
                System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo(fileResult) { UseShellExecute = true });
            }

            //Locks prevent multiple files being open at once.
            catch (Exception)
            {
                MessageBox.Show("Error saving. Are you sure Document isn't already opened? Try closing it.", "ERROR");
            }
        }
    }
}