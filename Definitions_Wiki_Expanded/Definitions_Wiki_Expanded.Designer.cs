using System.Windows.Forms;

namespace Definitions_Wiki_Expanded
{
    partial class Definitions_Wiki_Expanded
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
            this.components = new System.ComponentModel.Container();
            this.ButtonAdd = new System.Windows.Forms.Button();
            this.TextBoxName = new System.Windows.Forms.TextBox();
            this.TextBoxDefinition = new System.Windows.Forms.TextBox();
            this.ComboBoxCategory = new System.Windows.Forms.ComboBox();
            this.RadioButtonLinear = new System.Windows.Forms.RadioButton();
            this.RadioButtonNonLinear = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ListViewDisplay = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ButtonEdit = new System.Windows.Forms.Button();
            this.ButtonDelete = new System.Windows.Forms.Button();
            this.TextBoxSearch = new System.Windows.Forms.TextBox();
            this.ButtonSearch = new System.Windows.Forms.Button();
            this.StatusStrip = new System.Windows.Forms.StatusStrip();
            this.ToolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.StatusStripMessage = new System.Windows.Forms.ToolStripStatusLabel();
            this.mainMenu1 = new System.Windows.Forms.MainMenu(this.components);
            this.MenuItem1 = new System.Windows.Forms.MenuItem();
            this.MenuItemSave = new System.Windows.Forms.MenuItem();
            this.MenuItemOpen = new System.Windows.Forms.MenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.ButtonDeleteAll = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.StatusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // ButtonAdd
            // 
            this.ButtonAdd.Location = new System.Drawing.Point(139, 22);
            this.ButtonAdd.Name = "ButtonAdd";
            this.ButtonAdd.Size = new System.Drawing.Size(75, 23);
            this.ButtonAdd.TabIndex = 0;
            this.ButtonAdd.Text = "Add";
            this.ButtonAdd.UseVisualStyleBackColor = true;
            this.ButtonAdd.Click += new System.EventHandler(this.ButtonAdd_Click);
            // 
            // TextBoxName
            // 
            this.TextBoxName.Location = new System.Drawing.Point(12, 22);
            this.TextBoxName.Name = "TextBoxName";
            this.TextBoxName.Size = new System.Drawing.Size(121, 20);
            this.TextBoxName.TabIndex = 1;
            this.TextBoxName.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.TextBoxName_MouseDoubleClick);
            // 
            // TextBoxDefinition
            // 
            this.TextBoxDefinition.Location = new System.Drawing.Point(13, 174);
            this.TextBoxDefinition.Multiline = true;
            this.TextBoxDefinition.Name = "TextBoxDefinition";
            this.TextBoxDefinition.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.TextBoxDefinition.Size = new System.Drawing.Size(168, 99);
            this.TextBoxDefinition.TabIndex = 4;
            // 
            // ComboBoxCategory
            // 
            this.ComboBoxCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboBoxCategory.FormattingEnabled = true;
            this.ComboBoxCategory.Location = new System.Drawing.Point(12, 61);
            this.ComboBoxCategory.Name = "ComboBoxCategory";
            this.ComboBoxCategory.Size = new System.Drawing.Size(121, 21);
            this.ComboBoxCategory.Sorted = true;
            this.ComboBoxCategory.TabIndex = 5;
            // 
            // RadioButtonLinear
            // 
            this.RadioButtonLinear.AutoSize = true;
            this.RadioButtonLinear.Location = new System.Drawing.Point(6, 19);
            this.RadioButtonLinear.Name = "RadioButtonLinear";
            this.RadioButtonLinear.Size = new System.Drawing.Size(54, 17);
            this.RadioButtonLinear.TabIndex = 6;
            this.RadioButtonLinear.TabStop = true;
            this.RadioButtonLinear.Text = "Linear";
            this.RadioButtonLinear.UseVisualStyleBackColor = true;
            // 
            // RadioButtonNonLinear
            // 
            this.RadioButtonNonLinear.AutoSize = true;
            this.RadioButtonNonLinear.Location = new System.Drawing.Point(6, 42);
            this.RadioButtonNonLinear.Name = "RadioButtonNonLinear";
            this.RadioButtonNonLinear.Size = new System.Drawing.Size(77, 17);
            this.RadioButtonNonLinear.TabIndex = 7;
            this.RadioButtonNonLinear.TabStop = true;
            this.RadioButtonNonLinear.Text = "Non-Linear";
            this.RadioButtonNonLinear.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.RadioButtonLinear);
            this.groupBox1.Controls.Add(this.RadioButtonNonLinear);
            this.groupBox1.Location = new System.Drawing.Point(13, 88);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(121, 67);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Structure";
            // 
            // ListViewDisplay
            // 
            this.ListViewDisplay.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.ListViewDisplay.HideSelection = false;
            this.ListViewDisplay.Location = new System.Drawing.Point(220, 22);
            this.ListViewDisplay.Name = "ListViewDisplay";
            this.ListViewDisplay.Size = new System.Drawing.Size(249, 295);
            this.ListViewDisplay.TabIndex = 9;
            this.ListViewDisplay.UseCompatibleStateImageBehavior = false;
            this.ListViewDisplay.View = System.Windows.Forms.View.Details;
            this.ListViewDisplay.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ListViewDisplay_MouseClick);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Name";
            this.columnHeader1.Width = 150;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Category";
            this.columnHeader2.Width = 95;
            // 
            // ButtonEdit
            // 
            this.ButtonEdit.Location = new System.Drawing.Point(139, 51);
            this.ButtonEdit.Name = "ButtonEdit";
            this.ButtonEdit.Size = new System.Drawing.Size(75, 23);
            this.ButtonEdit.TabIndex = 10;
            this.ButtonEdit.Text = "Edit";
            this.ButtonEdit.UseVisualStyleBackColor = true;
            this.ButtonEdit.Click += new System.EventHandler(this.ButtonEdit_Click);
            // 
            // ButtonDelete
            // 
            this.ButtonDelete.Location = new System.Drawing.Point(139, 80);
            this.ButtonDelete.Name = "ButtonDelete";
            this.ButtonDelete.Size = new System.Drawing.Size(75, 23);
            this.ButtonDelete.TabIndex = 11;
            this.ButtonDelete.Text = "Delete";
            this.ButtonDelete.UseVisualStyleBackColor = true;
            this.ButtonDelete.Click += new System.EventHandler(this.ButtonDelete_Click);
            // 
            // TextBoxSearch
            // 
            this.TextBoxSearch.Location = new System.Drawing.Point(13, 294);
            this.TextBoxSearch.Name = "TextBoxSearch";
            this.TextBoxSearch.Size = new System.Drawing.Size(121, 20);
            this.TextBoxSearch.TabIndex = 12;
            // 
            // ButtonSearch
            // 
            this.ButtonSearch.Location = new System.Drawing.Point(140, 294);
            this.ButtonSearch.Name = "ButtonSearch";
            this.ButtonSearch.Size = new System.Drawing.Size(75, 23);
            this.ButtonSearch.TabIndex = 13;
            this.ButtonSearch.Text = "Search";
            this.ButtonSearch.UseVisualStyleBackColor = true;
            this.ButtonSearch.Click += new System.EventHandler(this.ButtonSearch_Click);
            // 
            // StatusStrip
            // 
            this.StatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripStatusLabel,
            this.StatusStripMessage});
            this.StatusStrip.Location = new System.Drawing.Point(0, 335);
            this.StatusStrip.Name = "StatusStrip";
            this.StatusStrip.Size = new System.Drawing.Size(497, 22);
            this.StatusStrip.TabIndex = 14;
            this.StatusStrip.Text = "statusStrip1";
            // 
            // ToolStripStatusLabel
            // 
            this.ToolStripStatusLabel.Name = "ToolStripStatusLabel";
            this.ToolStripStatusLabel.Size = new System.Drawing.Size(42, 17);
            this.ToolStripStatusLabel.Text = "Status:";
            // 
            // StatusStripMessage
            // 
            this.StatusStripMessage.Name = "StatusStripMessage";
            this.StatusStripMessage.Size = new System.Drawing.Size(0, 17);
            // 
            // mainMenu1
            // 
            this.mainMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.MenuItem1});
            // 
            // MenuItem1
            // 
            this.MenuItem1.Index = 0;
            this.MenuItem1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.MenuItemSave,
            this.MenuItemOpen});
            this.MenuItem1.Text = "File";
            // 
            // MenuItemSave
            // 
            this.MenuItemSave.Index = 0;
            this.MenuItemSave.Text = "Save";
            this.MenuItemSave.Click += new System.EventHandler(this.MenuItemSave_Click);
            // 
            // MenuItemOpen
            // 
            this.MenuItemOpen.Index = 1;
            this.MenuItemOpen.Text = "Open";
            this.MenuItemOpen.Click += new System.EventHandler(this.MenuItemOpen_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 15;
            this.label1.Text = "Name:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 16;
            this.label2.Text = "Category";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(22, 158);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 13);
            this.label3.TabIndex = 17;
            this.label3.Text = "Definition";
            // 
            // ButtonDeleteAll
            // 
            this.ButtonDeleteAll.Location = new System.Drawing.Point(139, 109);
            this.ButtonDeleteAll.Name = "ButtonDeleteAll";
            this.ButtonDeleteAll.Size = new System.Drawing.Size(75, 23);
            this.ButtonDeleteAll.TabIndex = 18;
            this.ButtonDeleteAll.Text = "Delete All";
            this.ButtonDeleteAll.UseVisualStyleBackColor = true;
            this.ButtonDeleteAll.Click += new System.EventHandler(this.ButtonDeleteAll_Click);
            // 
            // Definitions_Wiki_Expanded
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(497, 357);
            this.Controls.Add(this.ButtonDeleteAll);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.StatusStrip);
            this.Controls.Add(this.ButtonSearch);
            this.Controls.Add(this.TextBoxSearch);
            this.Controls.Add(this.ButtonDelete);
            this.Controls.Add(this.ButtonEdit);
            this.Controls.Add(this.ListViewDisplay);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.ComboBoxCategory);
            this.Controls.Add(this.TextBoxDefinition);
            this.Controls.Add(this.TextBoxName);
            this.Controls.Add(this.ButtonAdd);
            this.Menu = this.mainMenu1;
            this.Name = "Definitions_Wiki_Expanded";
            this.Text = "Definitions Wiki";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Definitions_Wiki_Expanded_FormClosed);
            this.Load += new System.EventHandler(this.Definitions_Wiki_Expanded_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.StatusStrip.ResumeLayout(false);
            this.StatusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ButtonAdd;
        private System.Windows.Forms.TextBox TextBoxName;
        private System.Windows.Forms.TextBox TextBoxDefinition;
        private System.Windows.Forms.ComboBox ComboBoxCategory;
        private System.Windows.Forms.RadioButton RadioButtonLinear;
        private System.Windows.Forms.RadioButton RadioButtonNonLinear;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListView ListViewDisplay;
        private System.Windows.Forms.Button ButtonEdit;
        private System.Windows.Forms.Button ButtonDelete;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.TextBox TextBoxSearch;
        private System.Windows.Forms.Button ButtonSearch;
        private System.Windows.Forms.StatusStrip StatusStrip;
        private System.Windows.Forms.ToolStripStatusLabel ToolStripStatusLabel;
        private System.Windows.Forms.ToolStripStatusLabel StatusStripMessage;
        private System.Windows.Forms.MainMenu mainMenu1;
        private System.Windows.Forms.MenuItem MenuItem1;
        private System.Windows.Forms.MenuItem MenuItemSave;
        private System.Windows.Forms.MenuItem MenuItemOpen;
        private Label label1;
        private Label label2;
        private Label label3;
        private Button ButtonDeleteAll;
    }
}

