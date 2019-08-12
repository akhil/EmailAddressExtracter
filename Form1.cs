using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using static System.Windows.Forms.ListView;

namespace EmailAddressExtracter
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        OpenFileDialog ofd = new OpenFileDialog();

        private void ChooseFileButton_Click(object sender, EventArgs e)
        {

            if(ofd.ShowDialog() == DialogResult.OK)
            {
                fileSelectionBox.Text = ofd.FileName;
                extractEmailButton.Enabled = true;
                downloadEmailAddressButton.Enabled = false;
            }
        }

        private ProcessStartInfo grepStartInfo(string fileName)
        {
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.FileName = "grep.exe";
            startInfo.RedirectStandardOutput = true;
            startInfo.UseShellExecute = false;
            startInfo.CreateNoWindow = true;
            startInfo.Arguments = "-a -o -P \"(?<name>[\\w.]+)\\@(?<domain>\\w+\\.\\w+)(\\.\\w+)?\" "
                                    + '"' + fileName + '"';
            return startInfo;
        }
        private string[] getTextfromProcess(ProcessStartInfo startInfo)
        {
            string[] text = null;
            using (Process process = Process.Start(startInfo))
            {
                using (StreamReader reader = process.StandardOutput)
                {
                    text = reader.ReadToEnd().Split('\n').Where(x => x.Trim().Length > 0).ToArray();
                }
            }
            return text;
        }
        private void populateEmailView(ListView listView, string[] emails)
        {
            listView.Clear();
            listView.View = View.Details;
            listView.GridLines = true;
            listView.Columns.Add("Email", -2, HorizontalAlignment.Left);

            foreach (string x in emails)
            {
                listView.Items.Add(x);
            }
        }
        private void ExtractEmailAddressButton_Click(object sender, EventArgs e)
        {
            if (!ofd.CheckFileExists)
            {
                MessageBox.Show("Invalid file: " + ofd.FileName);
                return;
            }
            ProcessStartInfo startInfo = grepStartInfo(ofd.FileName);
            Console.WriteLine("Grep arguments: " + startInfo.Arguments);
            var emails = new HashSet<string>(getTextfromProcess(startInfo)).ToList();
            emails.Sort();
            Console.WriteLine("extract email Count" + emails.Count);

            populateEmailView(emailListView, emails.ToArray());

            if (emails.Count > 0)
            {
                emailCountLabel.Text = "Unique Email Count: " + emails.Count;
                downloadEmailAddressButton.Enabled = true;
            }
            else
            {
                emailCountLabel.Text = "No Emails found";
            }
        }

        SaveFileDialog sfd = new SaveFileDialog();
        private List<string> cleanEmails(ListView emailListView, ListView badEmailListView)
        {
            List<ListViewItem> lv = emailListView.Items.Cast<ListViewItem>().ToList();
            var emails = from email in emailListView.Items.Cast<ListViewItem>()
                         select email.Text.Trim();
            var badEmails = from email in badEmailListView.Items.Cast<ListViewItem>()
                         select email.Text.Trim();
            return emails.Except(badEmails).ToList();
        }
        private void DownloadEmailAddressButton_Click(object sender, EventArgs e)
        {
            sfd.Title = "Save Emails";
            sfd.Filter = "CSV|*.csv";
            if(sfd.ShowDialog() == DialogResult.OK)
            {
                using (Stream myStream = sfd.OpenFile())
                {
                    using (StreamWriter sw = new StreamWriter(myStream))
                    {
                        List<string> emails = cleanEmails(emailListView, badEmailListView);
                        emails.ForEach(x => sw.WriteLine(x));
                        Console.WriteLine("Downloading emails: " + emails.Count);
                    }
                    MessageBox.Show("Download Complete");
                }
            }
        }

        OpenFileDialog badEmailsOpenFileDialog = new OpenFileDialog();
        private void BadEmailsButton_Click(object sender, EventArgs e)
        {
            if (badEmailsOpenFileDialog.ShowDialog() != DialogResult.OK)
            {
                return;
            }
            badEmailsSelection.Text = ofd.FileName;

            if (!badEmailsOpenFileDialog.CheckFileExists)
            {
                MessageBox.Show("Invalid file: " + badEmailsOpenFileDialog.FileName);
                return;
            }

            ProcessStartInfo startInfo = grepStartInfo(badEmailsOpenFileDialog.FileName);
            Console.WriteLine("Bad Emails Grep arguments: " + startInfo.Arguments);
            string[] badEmails = getTextfromProcess(startInfo);
            populateEmailView(badEmailListView, badEmails);
        }
    }
}
