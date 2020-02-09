using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Newtonsoft.Json;
using Xceed.Words.NET;

namespace Villa_Farms
{

    /*********
     * Very similiar structure wise to form1
     */
    public partial class Form2 : Form
    {
        public Form2Strings loader2;
        public Form2()
        {
            InitializeComponent();
        }

        //On load takes a JSON file full of defaults
        private void Form2_Load(object sender, EventArgs e)
        {
            loader2 = new Form2Strings();
            string jsonFromFile;

            using (var reader = new StreamReader(
                Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) 
                + @"\VillaFarms,LeaseMaker\BaseFolder\" + "prospectus.Json"))
            {
                jsonFromFile = reader.ReadToEnd();
            };
            loader2 = JsonConvert.DeserializeObject<Form2Strings>(jsonFromFile);
            basicRentText.Text = loader2.basicRent;
            entranceFeeText.Text = loader2.entranceFee;
            vehFeeText.Text = loader2.vehFee;
            petFeeText.Text = loader2.petFee;
            resFeeText.Text = loader2.resFee;
            lateFeeTExt.Text = loader2.lateFee;
            checkFeeText.Text = loader2.checkFee;
            pestFeeText.Text = loader2.pestFee;
            lawnFeeText.Text = loader2.lawnFee;
            washFeeText.Text = loader2.washFee;
            dryerFeeText.Text = loader2.dryerFee;
            subRegFeeText.Text = loader2.subRegFee;
            speServFeeText.Text = loader2.speServFee;
            speServFee2Text.Text = loader2.speServFee2;
            speUseFeeText.Text = loader2.speUseFee;
            speUseFee2Text.Text = loader2.speUseFee2;
            installFeeText.Text = loader2.installFee;
            subAdFeeText.Text = loader2.subAdmFee;

        }

        //Saves to a JSON file for future defaults.
        private void saveButton_Click(object sender, EventArgs e)
        {
            loader2.basicRent = basicRentText.Text;
            loader2.entranceFee = entranceFeeText.Text;
            loader2.vehFee = vehFeeText.Text;
            loader2.petFee = petFeeText.Text;
            loader2.resFee = resFeeText.Text;
            loader2.lateFee = lateFeeTExt.Text;
            loader2.checkFee = checkFeeText.Text;
            loader2.pestFee = pestFeeText.Text;
            loader2.lawnFee = lawnFeeText.Text;
            loader2.washFee = washFeeText.Text;
            loader2.dryerFee = dryerFeeText.Text;
            loader2.subRegFee = subRegFeeText.Text;
            loader2.speServFee = speServFeeText.Text;
            loader2.speServFee2 = speServFee2Text.Text;
            loader2.speUseFee = speUseFeeText.Text;
            loader2.speUseFee2 = speUseFee2Text.Text;
            loader2.installFee = installFeeText.Text;
            loader2.subAdmFee = subAdFeeText.Text;

            WordChangerProspectus change = new WordChangerProspectus();

            var jsonToFile = JsonConvert.SerializeObject(loader2);
            using (var writer = new StreamWriter(
                Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) +
                @"\VillaFarms,LeaseMaker\BaseFolder\"+"prospectus.Json"))
            {
                writer.Write(jsonToFile);
            };
           change.run(loader2);

        }


    }
    public class Form2Strings{
        public string basicRent { get; set; }
        public string entranceFee { get; set; }
        public string vehFee { get; set; }
        public string petFee { get; set; }
        public string resFee { get; set; }
        public string lateFee { get; set; }
        public string checkFee { get; set; }
        public string pestFee { get; set; }
        public string lawnFee { get; set; }
        public string washFee { get; set; }
        public string dryerFee { get; set; }
        public string subRegFee { get; set; }
        public string speServFee { get; set; }
        public string speServFee2 { get; set; }
        public string speUseFee { get; set; }
        public string speUseFee2 { get; set; }
        public string installFee { get; set; }
        public string subAdmFee{ get; set; }


    }
    public class WordChangerProspectus
    {
        public void run(Form2Strings form2Strings)
        {
            bool isNumber;
            long number;
            string filePath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) 
                + @"\VillaFarms,LeaseMaker\BaseFolder\" + "Prospectus.docx";
            string fileResult =Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) 
                 + @"\VillaFarms,LeaseMaker\PastPrinting\" +
                "Propectus of " + DateTime.Now.Month.ToString() + "," + DateTime.Now.Day.ToString() + 
                ", " + DateTime.Now.Year.ToString() + ".docx";
            //Either replaces text with a $0.00 format, or with what the string is.
            try
            {
                var dc = DocX.Load(filePath);
                if (form2Strings.basicRent == "0" || long.TryParse(form2Strings.basicRent, out number)) 
                    dc.ReplaceText("[[basicRent]]", "$" + form2Strings.basicRent + ".00");
                else
                    dc.ReplaceText("[[basicRent]]",  form2Strings.basicRent);
                if (form2Strings.entranceFee == "0" || long.TryParse(form2Strings.entranceFee, out number))
                    dc.ReplaceText("[[entranceFee]]", "$" + form2Strings.entranceFee + ".00");
                else
                    dc.ReplaceText("[[entranceFee]]", form2Strings.entranceFee);
                if (form2Strings.vehFee == "0" || long.TryParse(form2Strings.vehFee, out number))
                    dc.ReplaceText("[[vehFee]]", "$" + form2Strings.vehFee + ".00");
                else
                    dc.ReplaceText("[[vehFee]]", form2Strings.vehFee);
                if (form2Strings.petFee == "0" || long.TryParse(form2Strings.petFee, out number))
                    dc.ReplaceText("[[petFee]]", "$" + form2Strings.petFee + ".00");
                else
                    dc.ReplaceText("[[petFee]]", form2Strings.petFee);
                if (form2Strings.resFee == "0" || long.TryParse(form2Strings.resFee, out number))
                    dc.ReplaceText("[[resFee]]", "$" + form2Strings.resFee + ".00");
                else
                    dc.ReplaceText("[[resFee]]", form2Strings.resFee);
                if (form2Strings.lateFee == "0" || long.TryParse(form2Strings.lateFee, out number))
                    dc.ReplaceText("[[lateFee]]", "$" + form2Strings.lateFee + ".00");
                else
                    dc.ReplaceText("[[lateFee]]", form2Strings.lateFee);
                if (form2Strings.checkFee == "0" || long.TryParse(form2Strings.checkFee, out number))
                    dc.ReplaceText("[[checkFee]]", "$" + form2Strings.checkFee + ".00");
                else
                    dc.ReplaceText("[[checkFee]]", form2Strings.checkFee);
                if (form2Strings.pestFee == "0" || long.TryParse(form2Strings.pestFee, out number))
                    dc.ReplaceText("[[pestFee]]", "$" + form2Strings.pestFee + ".00");
                else
                    dc.ReplaceText("[[pestFee]]", form2Strings.pestFee);
                if (form2Strings.lawnFee == "0" || long.TryParse(form2Strings.lawnFee, out number))
                    dc.ReplaceText("[[lawnFee]]", "$" + form2Strings.lawnFee + ".00");
                else
                    dc.ReplaceText("[[lawnFee]]", form2Strings.lawnFee);
                if (form2Strings.washFee == "0" || long.TryParse(form2Strings.washFee, out number))
                    dc.ReplaceText("[[washFee]]", "$" + form2Strings.washFee + ".00");
                else
                    dc.ReplaceText("[[washFee]]", form2Strings.washFee);
                if (form2Strings.dryerFee == "0" || long.TryParse(form2Strings.dryerFee, out number))
                    dc.ReplaceText("[[dryerFee]]", "$" + form2Strings.dryerFee + ".00");
                else
                    dc.ReplaceText("[[dryerFee]]", form2Strings.dryerFee);
                if (form2Strings.subRegFee == "0" || long.TryParse(form2Strings.subRegFee, out number))
                    dc.ReplaceText("[[subRegFee]]", "$" + form2Strings.subRegFee + ".00");
                else
                    dc.ReplaceText("[[subRegFee]]", form2Strings.subRegFee);
                if (form2Strings.speServFee == "0" || long.TryParse(form2Strings.speServFee, out number))
                    dc.ReplaceText("[[speServFee]]", "$" + form2Strings.speServFee + ".00");
                else
                    dc.ReplaceText("[[speServFee]]", form2Strings.speServFee);
                if (form2Strings.speServFee2 == "0" || long.TryParse(form2Strings.speServFee2, out number))
                    dc.ReplaceText("[[speServFee2]]", "$" + form2Strings.speServFee2 + ".00");
                else
                    dc.ReplaceText("[[speServFee2]]", form2Strings.speServFee2);
                if (form2Strings.speUseFee == "0" || long.TryParse(form2Strings.speUseFee, out number))
                    dc.ReplaceText("[[speUseFee]]", "$" + form2Strings.speUseFee + ".00");
                else
                    dc.ReplaceText("[[speUseFee]]", form2Strings.speUseFee);
                if (form2Strings.speUseFee2 == "0" || long.TryParse(form2Strings.speUseFee2, out number))
                    dc.ReplaceText("[[speUseFee2]]", "$" + form2Strings.speUseFee2 + ".00");
                else
                    dc.ReplaceText("[[speUseFee2]]", form2Strings.speUseFee2);
                if (form2Strings.installFee == "0" || long.TryParse(form2Strings.installFee, out number))
                    dc.ReplaceText("[[installFee]]", "$" + form2Strings.installFee + ".00");
                else
                    dc.ReplaceText("[[installFee]]", form2Strings.installFee);
                if (form2Strings.subAdmFee == "0" || long.TryParse(form2Strings.subAdmFee, out number))
                    dc.ReplaceText("[[subAdmFee]]", "$" + form2Strings.subAdmFee + ".00");
                else
                    dc.ReplaceText("[[subAdmFee]]", form2Strings.subAdmFee);

     
                dc.SaveAs(fileResult);
                System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo(fileResult) { UseShellExecute = true });
            }
            //Again, can't open two docs at once, declares an error.
            catch (Exception)
            {
                MessageBox.Show("Error saving. Are you sure Document isn't already opened? Try closing it.", "ERROR");
            }
        }
    }

}
