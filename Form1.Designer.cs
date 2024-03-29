﻿namespace EmailAddressExtracter
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.chooseFileButton = new System.Windows.Forms.Button();
            this.fileSelectionBox = new System.Windows.Forms.TextBox();
            this.extractEmailButton = new System.Windows.Forms.Button();
            this.emailListView = new System.Windows.Forms.ListView();
            this.downloadEmailAddressButton = new System.Windows.Forms.Button();
            this.emailCountLabel = new System.Windows.Forms.Label();
            this.badEmailsButton = new System.Windows.Forms.Button();
            this.badEmailsSelection = new System.Windows.Forms.TextBox();
            this.badEmailListView = new System.Windows.Forms.ListView();
            this.SuspendLayout();
            // 
            // chooseFileButton
            // 
            this.chooseFileButton.Location = new System.Drawing.Point(98, 12);
            this.chooseFileButton.Name = "chooseFileButton";
            this.chooseFileButton.Size = new System.Drawing.Size(162, 31);
            this.chooseFileButton.TabIndex = 0;
            this.chooseFileButton.Text = "Choose File";
            this.chooseFileButton.UseVisualStyleBackColor = true;
            this.chooseFileButton.Click += new System.EventHandler(this.ChooseFileButton_Click);
            // 
            // fileSelectionBox
            // 
            this.fileSelectionBox.Location = new System.Drawing.Point(294, 12);
            this.fileSelectionBox.Multiline = true;
            this.fileSelectionBox.Name = "fileSelectionBox";
            this.fileSelectionBox.Size = new System.Drawing.Size(270, 103);
            this.fileSelectionBox.TabIndex = 1;
            // 
            // extractEmailButton
            // 
            this.extractEmailButton.Enabled = false;
            this.extractEmailButton.Location = new System.Drawing.Point(98, 77);
            this.extractEmailButton.Name = "extractEmailButton";
            this.extractEmailButton.Size = new System.Drawing.Size(162, 38);
            this.extractEmailButton.TabIndex = 2;
            this.extractEmailButton.Text = "Extract Emails";
            this.extractEmailButton.UseVisualStyleBackColor = true;
            this.extractEmailButton.Click += new System.EventHandler(this.ExtractEmailAddressButton_Click);
            // 
            // emailListView
            // 
            this.emailListView.HideSelection = false;
            this.emailListView.Location = new System.Drawing.Point(98, 256);
            this.emailListView.Name = "emailListView";
            this.emailListView.Size = new System.Drawing.Size(466, 335);
            this.emailListView.TabIndex = 3;
            this.emailListView.UseCompatibleStateImageBehavior = false;
            // 
            // downloadEmailAddressButton
            // 
            this.downloadEmailAddressButton.Enabled = false;
            this.downloadEmailAddressButton.Location = new System.Drawing.Point(312, 161);
            this.downloadEmailAddressButton.Name = "downloadEmailAddressButton";
            this.downloadEmailAddressButton.Size = new System.Drawing.Size(252, 56);
            this.downloadEmailAddressButton.TabIndex = 4;
            this.downloadEmailAddressButton.Text = "Download Email Addresses";
            this.downloadEmailAddressButton.UseVisualStyleBackColor = true;
            this.downloadEmailAddressButton.Click += new System.EventHandler(this.DownloadEmailAddressButton_Click);
            // 
            // emailCountLabel
            // 
            this.emailCountLabel.AutoSize = true;
            this.emailCountLabel.Location = new System.Drawing.Point(98, 179);
            this.emailCountLabel.Name = "emailCountLabel";
            this.emailCountLabel.Size = new System.Drawing.Size(150, 20);
            this.emailCountLabel.TabIndex = 5;
            this.emailCountLabel.Text = "Unique Email Count";
            // 
            // badEmailsButton
            // 
            this.badEmailsButton.Location = new System.Drawing.Point(921, 132);
            this.badEmailsButton.Name = "badEmailsButton";
            this.badEmailsButton.Size = new System.Drawing.Size(140, 40);
            this.badEmailsButton.TabIndex = 6;
            this.badEmailsButton.Text = "Bad Emails";
            this.badEmailsButton.UseVisualStyleBackColor = true;
            this.badEmailsButton.Click += new System.EventHandler(this.BadEmailsButton_Click);
            // 
            // badEmailsSelection
            // 
            this.badEmailsSelection.Location = new System.Drawing.Point(857, 14);
            this.badEmailsSelection.Multiline = true;
            this.badEmailsSelection.Name = "badEmailsSelection";
            this.badEmailsSelection.Size = new System.Drawing.Size(304, 101);
            this.badEmailsSelection.TabIndex = 7;
            // 
            // badEmailListView
            // 
            this.badEmailListView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.badEmailListView.HideSelection = false;
            this.badEmailListView.Location = new System.Drawing.Point(817, 256);
            this.badEmailListView.Name = "badEmailListView";
            this.badEmailListView.Size = new System.Drawing.Size(344, 335);
            this.badEmailListView.TabIndex = 8;
            this.badEmailListView.UseCompatibleStateImageBehavior = false;
            this.badEmailListView.View = System.Windows.Forms.View.List;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1198, 744);
            this.Controls.Add(this.badEmailListView);
            this.Controls.Add(this.badEmailsSelection);
            this.Controls.Add(this.badEmailsButton);
            this.Controls.Add(this.emailCountLabel);
            this.Controls.Add(this.downloadEmailAddressButton);
            this.Controls.Add(this.emailListView);
            this.Controls.Add(this.extractEmailButton);
            this.Controls.Add(this.fileSelectionBox);
            this.Controls.Add(this.chooseFileButton);
            this.Name = "Form1";
            this.Text = "Email Address Extracter";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button chooseFileButton;
        private System.Windows.Forms.TextBox fileSelectionBox;
        private System.Windows.Forms.Button extractEmailButton;
        private System.Windows.Forms.ListView emailListView;
        private System.Windows.Forms.Button downloadEmailAddressButton;
        private System.Windows.Forms.Label emailCountLabel;
        private System.Windows.Forms.Button badEmailsButton;
        private System.Windows.Forms.TextBox badEmailsSelection;
        private System.Windows.Forms.ListView badEmailListView;
    }
}

