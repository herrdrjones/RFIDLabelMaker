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
using System.Drawing.Printing;
using LinqToExcel;
using System.Collections;
using System.Configuration;
using System.Reflection;
using System.Xml;


namespace RFIDLabelMaker
{
    public partial class Form1 : Form
    {
        string RFIDLabel = "";
        private string line1;
        private string line2;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            txtLine1.Text = "www.ohioraceday.com";
            txtLine2.Text = "DO NOT BEND OR REMOVE";
            using (XmlReader reader = XmlReader.Create("Settings.xml"))
            {
                while (reader.Read())
                {
                    switch (reader.Name)
                    {
                        case "line1":
                            reader.Read();
                            line1 = reader.Value;
                            break;
                        
                    }
                }
            }
            //line1 = ConfigurationManager.AppSettings["line1"];
            //line2 = ConfigurationManager.AppSettings["line2"];
            ////txtLine1.Text = line1;
            ////txtLine2.Text = line2;
            //int LabelNumber = 100;
            //RFIDLabel += "${\n^XA^\n^RS8\n^FO25,25^A0N,65^FD";
            //RFIDLabel += LabelNumber - 1 + "^FS\n^RRF,H^FD";
            //string RFIDNumber = LabelNumber.ToString();
            //RFIDLabel += RFIDNumber.PadLeft(20, '0') +"^FS\n^XZ\n}$";

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!chkSpecificRace.Checked)
                printLabels();
            else
                printSpecificRace2();
        }

      
        private void printLabels()
        {
            int start;
            int end;
            bool blnStart = int.TryParse(txtStart.Text, out start);
            bool blnEnd = int.TryParse(txtEnd.Text, out end);
            int fileNumber = 1;
            ArrayList Files = new ArrayList();
            if (blnStart && blnEnd)
            {
                txtStart.BackColor = Color.White;
                txtEnd.BackColor = Color.White;
                RFIDLabel = string.Empty;
                RFIDLabel += "${";
                for (int LabelNumber = start; LabelNumber <= end + 1; LabelNumber++)
                {
                    RFIDLabel += "\n^XA\n^RS8\n^FO25,135^A0N,65^FD";
                    if (LabelNumber != start)
                    {
                        //RFIDLabel += LabelNumber - 1 + "^FS\n^RFW,H^FD";
                        RFIDLabel += LabelNumber - 1 + "^FS\n";
                        // RFIDLabel += "^FO600,25^A0N,50^FD" + lastName[0] + ",^FS\n";
                        // RFIDLabel += "^FO600,75^A0N,50^FD" + firstName[0] + "^FS\n";
                        RFIDLabel += "^FO90,25^A0N,65^FD" + txtLine1.Text + "^FS\n";
                        RFIDLabel += "^FO120,100^A0N,50^FD" + txtLine2.Text + "^FS\n";
                        RFIDLabel += "^RFW,H^FD";
                    }
                    else
                        RFIDLabel += "^FS\n^RFW,H^FD";
                    string RFIDNumber = LabelNumber.ToString();
                    RFIDLabel += RFIDNumber.PadLeft(24, '0') + "^FS\n^XZ\n}$\n${";
                    //if (LabelNumber % 100 == 0)
                    //{
                    //    RFIDLabel += "}$";
                    //    string fileName = "output" + fileNumber + ".txt";
                    //    File.WriteAllText(fileName, RFIDLabel);
                    //    Files.Add(fileName);
                    //    RFIDLabel = "${";
                    //    fileNumber++;
                    //}
                }
                RFIDLabel += "\n^XA\n^RS8\n^FO25,25^A0N,65^FD";
                RFIDLabel += end + "^FS\n^RFW,H^FD000000000000000000000000^FS\n^XY\n";
                RFIDLabel += "}$";
            }
            else
            {
                if (!blnStart)
                    txtStart.BackColor = Color.Yellow;
                if (!blnEnd)
                    txtEnd.BackColor = Color.Yellow;
            }
            string FileName = "output" + fileNumber + ".txt";
            File.WriteAllText(FileName, RFIDLabel);
            Files.Add(FileName);
            PrintDialog pd = new PrintDialog();
            pd.PrinterSettings = new PrinterSettings();
            if (DialogResult.OK == pd.ShowDialog(this))
            {
                foreach (string file in Files)
                {
                    PrinterHelper.SendFileToPrinter(pd.PrinterSettings.PrinterName, file);
                    System.Threading.Thread.Sleep(500);
                }
            }

        }  
        private void printSpecificRace()
        {
            int start;
            int end;
            int raceno;
            bool blnStart = int.TryParse(txtStart.Text, out start);
            bool blnEnd = int.TryParse(txtEnd.Text, out end);
            bool blnRaceNo = int.TryParse(txtRaceNumber.Text, out raceno);
            if (blnStart && blnEnd && blnRaceNo)
            {
                txtStart.BackColor = Color.White;
                txtEnd.BackColor = Color.White;
                txtRaceNumber.BackColor = Color.White;
                RFIDLabel = string.Empty;
                RFIDLabel += "${";
                for (int LabelNumber = start; LabelNumber <= end; LabelNumber++)
                {
                    RFIDLabel += "\n^XA\n^RS8\n^FO25,135^A0N,65^FD";
                    if (LabelNumber != start)
                    {
                        RFIDLabel += LabelNumber - 1 + "^FS\n";
                        RFIDLabel += "^FO190,25^A0N,65^FDohioraceday.com^FS\n";
                        RFIDLabel += "^FO215,140^A0N,50^FDDO NOT BEND/REMOVE^FS\n";
                        RFIDLabel += "^RFW,H^FD";
                    }
                    else
                        RFIDLabel += "^FS\n^RFW,H^FD";
                    string RFIDNumber = LabelNumber.ToString();
                    RFIDNumber = RFIDNumber.PadLeft(24 - raceno.ToString().Length, '0');
                    RFIDNumber = raceno + RFIDNumber;
                    RFIDLabel += RFIDNumber + "^FS\n^XZ\n";
                }
                RFIDLabel += "\n^XA\n^RS8\n^FO25,25^A0N,65^FD";
                RFIDLabel += end + "^FS\n^RFW,H^FD000000000000000000000000^FS\n^XY\n";
                RFIDLabel += "}$";
            }
            else
            {
                if (!blnStart)
                    txtStart.BackColor = Color.Yellow;
                if (!blnEnd)
                    txtEnd.BackColor = Color.Yellow;
                if (!blnRaceNo)
                    txtRaceNumber.BackColor = Color.Yellow;
                return;
            }
            string output = "";
            File.WriteAllText("output.txt", RFIDLabel);
            PrintDialog pd = new PrintDialog();
            pd.PrinterSettings = new PrinterSettings();
            if (DialogResult.OK == pd.ShowDialog(this))
            {
                PrinterHelper.SendFileToPrinter(pd.PrinterSettings.PrinterName, "output.txt");
            }
            //PrinterSettings ps = new PrinterSettings();
            //PrinterHelper.SendFileToPrinter(ps.PrinterName, "output.txt");
        }
        private void printSpecificRace2()
        {
            int start;
            int end;
            int raceno;
            bool blnStart = int.TryParse(txtStart.Text, out start);
            bool blnEnd = int.TryParse(txtEnd.Text, out end);
            int fileNumber = 1;
            ArrayList Files = new ArrayList();
            bool blnRaceNo = int.TryParse(txtRaceNumber.Text, out raceno);
            if (blnStart && blnEnd && blnRaceNo)
            {
                txtStart.BackColor = Color.White;
                txtEnd.BackColor = Color.White;
                RFIDLabel = string.Empty;
                RFIDLabel += "${";
                for (int LabelNumber = start; LabelNumber <= end + 1; LabelNumber++)
                {
                    RFIDLabel += "\n^XA\n^RS8\n^FO25,135^A0N,65^FD";
                    if (LabelNumber != start)
                    {
                        //RFIDLabel += LabelNumber - 1 + "^FS\n^RFW,H^FD";
                        RFIDLabel += LabelNumber - 1 + "^FS\n";
                        // RFIDLabel += "^FO600,25^A0N,50^FD" + lastName[0] + ",^FS\n";
                        // RFIDLabel += "^FO600,75^A0N,50^FD" + firstName[0] + "^FS\n";
                        RFIDLabel += "^FO90,25^A0N,65^FD" + txtLine1.Text + "^FS\n";
                        RFIDLabel += "^FO120,100^A0N,50^FD" + txtLine2.Text + "^FS\n";
                        RFIDLabel += "^RFW,H^FD";
                    }
                    else
                        RFIDLabel += "^FS\n^RFW,H^FD";
                    string RFIDNumber = LabelNumber.ToString();
                    RFIDNumber = RFIDNumber.PadLeft(24 - raceno.ToString().Length, '0');
                    RFIDNumber = raceno + RFIDNumber;
                    RFIDLabel += RFIDNumber + "^FS\n^XZ\n";

                }
                RFIDLabel += "\n^XA\n^RS8\n^FO25,25^A0N,65^FD";
                RFIDLabel += end + "^FS\n^RFW,H^FD000000000000000000000000^FS\n^XY\n";
                RFIDLabel += "}$";
            }
            else
            {
                if (!blnStart)
                    txtStart.BackColor = Color.Yellow;
                if (!blnEnd)
                    txtEnd.BackColor = Color.Yellow;
            }
            string FileName = "output" + fileNumber + ".txt";
            File.WriteAllText(FileName, RFIDLabel);
            Files.Add(FileName);
            PrintDialog pd = new PrintDialog();
            pd.PrinterSettings = new PrinterSettings();
            if (DialogResult.OK == pd.ShowDialog(this))
            {
                foreach (string file in Files)
                {
                    PrinterHelper.SendFileToPrinter(pd.PrinterSettings.PrinterName, file);
                    System.Threading.Thread.Sleep(500);
                }
            }
        }
        private void btnUpload_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                string path = dialog.FileName;
                string workbookname = System.IO.Path.GetFileNameWithoutExtension(path);
                //string workbookname = "checkeredflag";
                DataTable roster = new DataTable();
                roster = getFromExcel(path, workbookname);
                var max_bib = (from b in roster.AsEnumerable()
                               select b.Field<string>("Bib_#")).Max();

                int max = int.Parse(max_bib);
                var min_bib = (from b in roster.AsEnumerable()
                               select b.Field<string>("Bib_#")).Min();
                int min = int.Parse(min_bib);
                createLabel(min, max, roster);
            }
        }
   
        private void createLabel(int start, int end, DataTable roster)
        {
                RFIDLabel = string.Empty;
                RFIDLabel += "${";
                for (int LabelNumber = start; LabelNumber <= end; LabelNumber++)
                {
                    string[] firstName;
                    string[] lastName;
                    var lastq = from l in roster.AsEnumerable()
                                 where l.Field<string>("Bib_#") == (LabelNumber-1).ToString()
                                 select l.Field<string>("Last_Name");

                    lastName = lastq.ToArray();
                    var firstq = from f in roster.AsEnumerable()
                                 where f.Field<string>("Bib_#") == (LabelNumber-1).ToString()
                                 select f.Field<string>("First_Name");
                    firstName = firstq.ToArray();
                    RFIDLabel += "\n^XA\n^RS8\n";
                    RFIDLabel += "^FO25,145^A0N,65^FD";
                    if (LabelNumber != start)
                    {
                        RFIDLabel += LabelNumber - 1 + "^FS\n";
                        RFIDLabel += "^FO600,25^A0N,50^FD" + lastName[0] + ",^FS\n";
                        RFIDLabel += "^FO600,75^A0N,50^FD" + firstName[0] + "^FS\n";
                        RFIDLabel += "^FO25,25^A0N,65^FDohioraceday.com^FS\n";
                        RFIDLabel += "^FO145,155^A0N,50^FDDO NOT BEND/REMOVE^FS\n";
                        RFIDLabel += "^RFW,H^FD";
                    }
                    else
                        RFIDLabel += "^FS\n^RFW,H^FD";
                    string RFIDNumber = LabelNumber.ToString();
                    RFIDLabel += RFIDNumber.PadLeft(24, '0') + "^FS\n^XZ\n";
                }
                RFIDLabel += "\n^XA\n^RS8\n^FO25,25^A0N,65^FD";
                RFIDLabel += end + "^FS\n^RFW,H^FD000000000000000000000000^FS\n^XY\n";
                RFIDLabel += "}$";

            string output = "";
            File.WriteAllText("output.txt", RFIDLabel);
            PrintDialog pd = new PrintDialog();
            pd.PrinterSettings = new PrinterSettings();
            if (DialogResult.OK == pd.ShowDialog(this))
            {
                PrinterHelper.SendFileToPrinter(pd.PrinterSettings.PrinterName, "output.txt");
            }

                    //^XA
                    //^RS8
                    //^FO600,25^A0N,65^FDKline,^FS
                    //^FO600,75^A0N,65^FDBradley^FS
                    //^FO25,25^A0N,65^FDohioraceday.com^FS
                    //^FO25,145^A0N,65^FD1^FS
                    //^FO600,145^A0N,65^FDM-39^FS
                    //^FO145,155^A0N,50^FDDO NOT BEND/REMOVE^FS
                    //^RFW,H^FD000000000000000000000001^FS
                    //^XZ

            //PrinterSettings ps = new PrinterSettings();
            //PrinterHelper.SendFileToPrinter(ps.PrinterName, "output.txt");
        } 
        
        public static DataTable getFromExcel(string fileName, string workbookName)
        {
            DataTable dt = new DataTable();
            var excel = new ExcelQueryFactory(fileName);
            var query = from c in excel.Worksheet(workbookName)
                        select c;

            var names = excel.GetColumnNames(workbookName);
            string line = string.Empty;
            string[] columns = new string[names.Count()];
            string[] orig_columns = new string[names.Count()];
            int i = 0;
            foreach (string s in names)
            {
                orig_columns[i] = s;
                columns[i] = s.Replace(' ', '_');
                i++;
            }
            foreach (string s in columns)
            {
                dt.Columns.Add(s, typeof(string));
            }
            foreach (Row r in query)
            {
                DataRow row = dt.NewRow();
                i = 0;
                for (i = 0; i < names.Count(); i++)
                {
                    row[columns[i]] = r[orig_columns[i]].ToString();
                }
                dt.Rows.Add(row);
            }
            return dt;
        }

        private void btnPreview_Click(object sender, EventArgs e)
        {

        }

        private void chkSpecificRace_CheckedChanged(object sender, EventArgs e)
        {
            if (chkSpecificRace.Checked)
            {
                lblSpecific.Visible = true;
                txtRaceNumber.Visible = true;
            }
            else
            {
                lblSpecific.Visible = false;
                txtRaceNumber.Visible = false;
            }
        }

        private void OnFormClosing(object sender, FormClosingEventArgs e)
        {
            /*if (txtLine1.Text != line1 || txtLine2.Text != line2)
            {
                DialogResult dialogResult = MessageBox.Show("You have made changes, would you like to save?", "Save Changes?", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    UpdateSetting("line1", txtLine1.Text);
                    UpdateSetting("line2", txtLine2.Text);
                }
            }*/
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;

            XmlWriter writer = XmlWriter.Create("Settings.xml", settings);
            writer.WriteStartDocument();
            writer.WriteComment("This file is generated by the program.");
            writer.WriteStartElement("TagText");
            writer.WriteElementString("line1", txtLine1.Text);
            writer.WriteElementString("line2", txtLine2.Text);
            writer.WriteEndElement();
            writer.WriteEndDocument();

            writer.Flush();
            writer.Close();
        }
        private static void UpdateSetting(string key, string value)
        {
            Configuration configuration = ConfigurationManager.
                OpenExeConfiguration(Assembly.GetExecutingAssembly().Location);
            configuration.AppSettings.Settings[key].Value = value;
            configuration.Save(ConfigurationSaveMode.Full, true);

            ConfigurationManager.RefreshSection("appSettings");
        }
    }
}
