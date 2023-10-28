/**
 * Developed by Lamonato29
 * https://github.com/lamonato29
 */
namespace RME_Tileset_Updater
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            groupBox1 = new GroupBox();
            buttonUpdate = new Button();
            buttonSelectCheckedList = new Button();
            checkedListBoxCategories = new CheckedListBox();
            groupBox2 = new GroupBox();
            richTextBox1 = new RichTextBox();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(buttonUpdate);
            groupBox1.Controls.Add(buttonSelectCheckedList);
            groupBox1.Controls.Add(checkedListBoxCategories);
            groupBox1.Dock = DockStyle.Top;
            groupBox1.Location = new Point(0, 0);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(990, 143);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "Update";
            // 
            // buttonUpdate
            // 
            buttonUpdate.Location = new Point(152, 104);
            buttonUpdate.Name = "buttonUpdate";
            buttonUpdate.Size = new Size(140, 23);
            buttonUpdate.TabIndex = 1;
            buttonUpdate.Text = "Update";
            buttonUpdate.UseVisualStyleBackColor = true;
            buttonUpdate.Click += buttonUpdate_Click;
            // 
            // buttonSelectCheckedList
            // 
            buttonSelectCheckedList.Location = new Point(6, 104);
            buttonSelectCheckedList.Name = "buttonSelectCheckedList";
            buttonSelectCheckedList.Size = new Size(140, 23);
            buttonSelectCheckedList.TabIndex = 1;
            buttonSelectCheckedList.Text = "Select All / Unselect All";
            buttonSelectCheckedList.UseVisualStyleBackColor = true;
            buttonSelectCheckedList.Click += buttonSelectCheckedList_Click;
            // 
            // checkedListBoxCategories
            // 
            checkedListBoxCategories.FormattingEnabled = true;
            checkedListBoxCategories.Location = new Point(6, 22);
            checkedListBoxCategories.Name = "checkedListBoxCategories";
            checkedListBoxCategories.Size = new Size(477, 76);
            checkedListBoxCategories.TabIndex = 0;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(richTextBox1);
            groupBox2.Dock = DockStyle.Fill;
            groupBox2.Location = new Point(0, 143);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(990, 502);
            groupBox2.TabIndex = 2;
            groupBox2.TabStop = false;
            // 
            // richTextBox1
            // 
            richTextBox1.Dock = DockStyle.Fill;
            richTextBox1.Location = new Point(3, 19);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.ReadOnly = true;
            richTextBox1.Size = new Size(984, 480);
            richTextBox1.TabIndex = 0;
            richTextBox1.Text = "";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(990, 645);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Name = "Form1";
            Text = "RME Tileset Updater";
            Load += Form1_Load;
            groupBox1.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private GroupBox groupBox1;
        private Button buttonUpdate;
        private Button buttonSelectCheckedList;
        private CheckedListBox checkedListBoxCategories;
        private GroupBox groupBox2;
        private RichTextBox richTextBox1;
    }
}