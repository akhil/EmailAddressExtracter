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

        ProcessStartInfo startInfo = new ProcessStartInfo();

        private void ExtractEmailAddressButton_Click(object sender, EventArgs e)
        {
            MessageBoxButtons buttons = MessageBoxButtons.OK;
            if (!ofd.CheckFileExists)
            {
                MessageBox.Show("Invalid file", "test", buttons);
                return;
            }
            startInfo.FileName = "grep.exe";
            startInfo.RedirectStandardOutput = true;
            startInfo.UseShellExecute = false;
            startInfo.CreateNoWindow = true;
            startInfo.Arguments = "-a -o -P \"(?<name>[\\w.]+)\\@(?<domain>\\w+\\.\\w+)(\\.\\w+)?\" "
                                    + '"' + ofd.FileName +'"';

            Console.WriteLine("Grep arguments: " + startInfo.Arguments);
            using (Process process = Process.Start(startInfo))
            {
                using (StreamReader reader = process.StandardOutput)
                {
                    string result = reader.ReadToEnd();
                    emailListView.View = View.Details;
                    emailListView.GridLines = true;
                    emailListView.Columns.Add("Email", -2, HorizontalAlignment.Left);
                    string[] emails = result.Split('\n');
                    Console.WriteLine("emails Count" + emails.Length.ToString());
                    foreach(string x in emails)
                    {
                        emailListView.Items.Add(x);
                    }
                    if(emails.Length > 0)
                    {
                        emailCountLabel.Text = "Email Count: " + emails.Length;
                        downloadEmailAddressButton.Enabled = true;
                    }
                }
            }
        }

        SaveFileDialog sfd = new SaveFileDialog();

        private void DownloadEmailAddressButton_Click(object sender, EventArgs e)
        {
            sfd.Title = "Save Emails";
            sfd.Filter = "CSV|*.csv";
            if(sfd.ShowDialog() == DialogResult.OK)
            {
                using (Stream myStream = sfd.OpenFile())
                {
                    using(StreamWriter sw = new StreamWriter(myStream))
                    foreach (ListViewItem item in emailListView.Items)
                    {
                        sw.WriteLine(item.Text.Trim());
                    }
                    MessageBox.Show("Download Complete");
                }
            }
        }
    }
}
