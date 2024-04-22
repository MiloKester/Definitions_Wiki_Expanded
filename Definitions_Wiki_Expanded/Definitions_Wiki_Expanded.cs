using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Text;
using System.Windows.Forms;

// 30063179 Milo Kester
// 2024-04-22
// AT2 Definitions Wiki Expanded Features

namespace Definitions_Wiki_Expanded
{
    public partial class Definitions_Wiki_Expanded : Form
    {
        #region SetUp

        public Definitions_Wiki_Expanded()
        {
            InitializeComponent();
        }

        // 6.2 Create a global List<T> of type Information called Wiki.
        List<Information> Wiki = new List<Information>(); // List<> is known as Wiki

        private void Definitions_Wiki_Expanded_Load(object sender, System.EventArgs e)
        {
            FillComboBox(); // get categories from file

            // on load, open autosave
            if (File.Exists("autosave.dat")) {
                OpenRecord("autosave.dat");
                StatusStripMessage.Text = "Autosave Loaded";
            }
        }

        private void Definitions_Wiki_Expanded_Shown(object sender, System.EventArgs e)
        {
            TextBoxName.Focus(); // needs to run after form has been loaded else it'll focus on the add button
        }

        // 6.4 Create a custom method to populate the ComboBox when the Form Load method is called. The six categories must be read from a simple text file.
        private void FillComboBox()
        {
            var lines = File.ReadLines("Categories.txt");
            foreach (var line in lines)
            {
                ComboBoxCategory.Items.Add(line);
            }
        }

        #endregion

        #region Displaying

        // 6.9 Create a single custom method that will sort and then display the Name and Category from the wiki information in the list.
        private void DisplayAllDefinitions()
        {
            ListViewDisplay.Items.Clear();
            Wiki.Sort();

            foreach (var item in Wiki) // display all items from wiki
            {
                ListViewItem item1 = new ListViewItem(item.GetName()); // create new item with main being name
                item1.SubItems.Add(item.GetCategory()); // add category to that item
                ListViewDisplay.Items.Add(item1); // add whole item to listview
            }
        }

        private void DisplaySpecific(int index) // click an item from listview to display in fields // also runs on file open for first entry
        {
            TextBoxName.Text = Wiki[index].GetName();
            ComboBoxCategory.Text = Wiki[index].GetCategory();

            int radioIndex = GetIndexFromRadio(index);

            if (radioIndex == 0)
            {
                RadioButtonLinear.Checked = true;
            } 
            else if (radioIndex == 1)
            {
                RadioButtonNonLinear.Checked = true;
            }   
            else
            {
                StatusStripMessage.Text = "Invalid Radio Selection";
            }

            TextBoxDefinition.Text = Wiki[index].GetDefinition();
        }

        // 6.11 Create a ListView event so a user can select a Data Structure Name from the list of Names and the associated information will be displayed in the related text boxes, combo box, and radio button.
        private void ListViewDisplay_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                int currentIndex = ListViewDisplay.FocusedItem.Index;
                if (currentIndex > -1)
                {
                    DisplaySpecific(currentIndex);
                    StatusStripMessage.Text = "Displayed";
                }
            }
            catch
            {
                StatusStripMessage.Text = "Error";
            }
        }

        #endregion

        #region Clearing

        private void ClearAndDisplay()
        {
            DisplayAllDefinitions();
            ClearFields();
            TextBoxName.Focus();
            StatusStripMessage.Text = "";
        }

        // 6.12 Create a custom method that will clear and reset the TextBoxes, ComboBox and Radio button
        private void ClearFields()
        {
            TextBoxName.Clear();
            ComboBoxCategory.SelectedIndex = -1;
            RadioButtonLinear.Checked = false;
            RadioButtonNonLinear.Checked = false;
            TextBoxDefinition.Clear();
            TextBoxSearch.Clear();
        }

        // 6.13 Create a double click event on the Name TextBox to clear the TextBoxes, ComboBox and Radio button.
        private void TextBoxName_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ClearAndDisplay();
        }

        #endregion

        #region Buttons

        // 6.3 Create a button method to ADD a new item to the list. Use a TextBox for the Name input, ComboBox for the Category, Radio group for the Structure and Multiline TextBox for the Definition.
        private void ButtonAdd_Click(object sender, EventArgs e)
        {
            // if all fields are filled
            if (!string.IsNullOrEmpty(TextBoxName.Text) && ComboBoxCategory.SelectedIndex != -1 && (RadioButtonLinear.Checked || RadioButtonNonLinear.Checked) && !string.IsNullOrEmpty(TextBoxDefinition.Text))
            {

                if (ValidName(TextBoxName.Text)) // if name returns valid (true)
                {
                    Information newInformation = new Information();

                    newInformation.SetName(TextBoxName.Text);
                    newInformation.SetCategory(ComboBoxCategory.Text);
                    newInformation.SetStructure(GetStringFromRadio());
                    newInformation.SetDefinition(TextBoxDefinition.Text);

                    Wiki.Add(newInformation); // add values to wiki
                    DisplayAllDefinitions();
                    StatusStripMessage.Text = "Added";
                    ClearFields();
                    TextBoxName.Focus();
                }
                else // ValidName() returned false
                {
                    StatusStripMessage.Text = "Not Added. Name Is A Duplicate";
                }
            }
            else
            {
                StatusStripMessage.Text = "Please Fill In All Fields";
            }
        }

        // 6.7 Create a button method that will delete the currently selected record in the ListView.
        private void ButtonDelete_Click(object sender, EventArgs e)
        {
            Stream file = File.Create("Trace_6.7.txt");
            TextWriterTraceListener myTextListener = new TextWriterTraceListener(file);
            Trace.Listeners.Add(myTextListener);
            try
            {
                Trace.WriteLine("Delete Entry:");

                int currentIndex = ListViewDisplay.FocusedItem.Index;

                Trace.WriteLine("Current Index: " + currentIndex);

                if (currentIndex > -1)
                {
                    string message = "Are You Sure You Want To Delete This Entry?\nThis Action Is Permanent.";
                    string title = "Delete Definition";
                    MessageBoxButtons buttons = MessageBoxButtons.OKCancel;
                    DialogResult result;
                    result = MessageBox.Show(message, title, buttons, MessageBoxIcon.Warning);

                    Trace.WriteLine("Choice: " + result);
                    if (result == DialogResult.OK)
                    {
                        Wiki.RemoveAt(currentIndex);
                        ClearAndDisplay();
                        StatusStripMessage.Text = "Deleted";

                        Trace.WriteLine("Deleted");
                        Trace.Flush();
                        Trace.Close();
                    }
                    else
                    {
                        StatusStripMessage.Text = "Not Deleted";

                        Trace.WriteLine("Not Deleted");
                        Trace.Flush();
                        Trace.Close();
                    }
                }
            }
            catch
            {
                StatusStripMessage.Text = "Invalid Selection";

                Trace.WriteLine("Invalid Selection");
                Trace.Flush();
                Trace.Close();
            }
        }

        // bonus delete method to quickly delete everything
        private void ButtonDeleteAll_Click(object sender, EventArgs e)
        {
            string message = "Are You Sure You Want To Delete Everything?\nThis Action Is Permanent.";
            string title = "Delete All";
            MessageBoxButtons buttons = MessageBoxButtons.OKCancel;
            DialogResult result;
            result = MessageBox.Show(message, title, buttons, MessageBoxIcon.Warning);

            if (result == DialogResult.OK)
            {
                Wiki.Clear();
                ClearAndDisplay();
                StatusStripMessage.Text = "Deleted";
            }
            else
            {
                StatusStripMessage.Text = "Not Deleted";
            }
        }

        // 6.8 Create a button method that will save the edited record of the currently selected item in the ListView. All the changes in the input controls will be written back to the list. Display an updated version of the sorted list at the end of this process.
        private void ButtonEdit_Click(object sender, EventArgs e)
        {
            Stream file = File.Create("Trace_6.8.txt");
            TextWriterTraceListener myTextListener = new TextWriterTraceListener(file);
            Trace.Listeners.Add(myTextListener);

            Trace.WriteLine("Editing Entry:");
            try
            {
                int currentIndex = ListViewDisplay.FocusedItem.Index;
                Trace.WriteLine("Index: " + currentIndex);
                if (currentIndex > -1)
                {
                    Wiki[currentIndex].SetName(TextBoxName.Text);
                    Wiki[currentIndex].SetCategory(ComboBoxCategory.Text);
                    Wiki[currentIndex].SetStructure(GetStringFromRadio());
                    Wiki[currentIndex].SetDefinition(TextBoxDefinition.Text);
                    Wiki.Sort();
                    DisplayAllDefinitions();
                    StatusStripMessage.Text = "Edit Successful";

                    Trace.WriteLine("New Name: " + TextBoxName.Text);
                    Trace.WriteLine("New Category: " + ComboBoxCategory.Text);
                    Trace.WriteLine("New Structure: " + GetStringFromRadio());
                    Trace.WriteLine("New Definition: " + TextBoxDefinition.Text);
                    Trace.Flush();
                    Trace.Close();
                }
            }
            catch
            {
                StatusStripMessage.Text = "Edit Unsuccessful. Index Likely Invalid";

                Trace.WriteLine("Edit Unsuccessful. Index Likely Invalid");
                Trace.Flush();
                Trace.Close();
            }
        }

        // 6.10 Create a button method that will use the builtin binary search to find a Data Structure name. If the record is found the associated details will populate the appropriate input controls and highlight the name in the ListView. At the end of the search process the search input TextBox must be cleared.
        private void ButtonSearch_Click(object sender, EventArgs e)
        {
            Information searchName = new Information();
            searchName.SetName(TextBoxSearch.Text); // set name to have consistent capitalisation
            int index = Wiki.BinarySearch(searchName);

            if (index > -1) // if valid index
            {
                StatusStripMessage.Text = "Found";
                DisplaySpecific(index);
                ListViewDisplay.SelectedItems.Clear();
                ListViewDisplay.Items[index].Selected = true;
                TextBoxSearch.Clear();
            }
            else
            {
                StatusStripMessage.Text = "Not Found";
                TextBoxSearch.Clear();
                TextBoxSearch.Focus();
            }
        }

        #endregion

        #region Save-Open

        // 6.14 Create two buttons for the manual open and save option; this must use a dialog box to select a file or rename a saved file. All Wiki data is stored/retrieved using a binary reader/writer file format.

        private void MenuItemSave_Click(object sender, EventArgs e)
        {
            // save dialog settings
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "dat files (*.dat) | *.dat";
            saveFileDialog.Title = "Save Dictionary";
            saveFileDialog.InitialDirectory = Application.StartupPath;
            saveFileDialog.DefaultExt = "dat";
            saveFileDialog.ShowDialog();
            string fileName = saveFileDialog.FileName;

            if (saveFileDialog.FileName != "") // if file name not empty
            {
                // save
                SaveRecord(fileName);
                StatusStripMessage.Text = "File Saved";
            }
            else
            {
                StatusStripMessage.Text = "File Not Saved";
            }
        }

        private void SaveRecord(string saveFileName)
        {
            try
            {
                using (var stream = File.Open(saveFileName, FileMode.Create))
                {
                    using (var writer = new BinaryWriter(stream, Encoding.UTF8, false))
                    {
                        for (int i = 0; i < Wiki.Count; i++)
                        {
                            string name = Wiki[i].GetName();
                            string category = Wiki[i].GetCategory();
                            string structure = Wiki[i].GetStructure();
                            string definition = Wiki[i].GetDefinition();

                            writer.Write(name);
                            writer.Write(category);
                            writer.Write(structure);
                            writer.Write(definition);
                        }
                    }
                }
            }
            catch
            {
                StatusStripMessage.Text = "Error While Saving";
            }
        }

        private void MenuItemOpen_Click(object sender, EventArgs e)
        {
            // open file dialog settings
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Application.StartupPath;
            openFileDialog.Filter = "dat files (*.dat)| *.dat";
            openFileDialog.Title = "Open File";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                Wiki.Clear(); // clear for new file
                OpenRecord(openFileDialog.FileName);
                StatusStripMessage.Text = "File Opened";

                DisplaySpecific(0);
                TextBoxName.Focus();
            }
            // else do nothing
        }

        private void OpenRecord(string openFileName)
        {
            if (File.Exists(openFileName))
            {
                using (var stream = File.Open(openFileName, FileMode.Open))
                {
                    using (var reader = new BinaryReader(stream, Encoding.UTF8, false))
                    {

                        while (stream.Position < stream.Length)
                        {
                            Information newInformation = new Information(); // need to create new instance for every iteration

                            string name = reader.ReadString();
                            string category = reader.ReadString();
                            string structure = reader.ReadString();
                            string definition = reader.ReadString();

                            newInformation.SetName(name);
                            newInformation.SetCategory(category);
                            newInformation.SetStructure(structure);
                            newInformation.SetDefinition(definition);

                            Wiki.Add(newInformation);
                        }
                    }
                }
            }
            DisplayAllDefinitions();
        }

        // 6.15 The Wiki application will save data when the form closes.
        private void Definitions_Wiki_Expanded_FormClosed(object sender, FormClosedEventArgs e)
        {
            SaveRecord("autosave.dat");
        }

        #endregion

        #region Misc-Methods

        // 6.6 Create two methods to highlight and return the values from the Radio button GroupBox. The first method must return a string value from the selected radio button (Linear or Non-Linear).
        private string GetStringFromRadio() // used for saving
        {
            string radioText = "";
            if (RadioButtonLinear.Checked) // if linear button is checked
                radioText = RadioButtonLinear.Text; // save radioText as the value of that button
            else if (RadioButtonNonLinear.Checked)
                radioText = RadioButtonNonLinear.Text;
            return radioText; // will return blank if nothing is selected
        }

        // The second method must send an integer index which will highlight an appropriate radio button.
        private int GetIndexFromRadio(int index) // used for opening
        {
            string radioSelection = Wiki[index].GetStructure(); // get string at provided index 

            if (radioSelection == "Linear")
                return 0; // selects 1st radio
            else if (radioSelection == "Non-Linear")
                return 1; // selects 2nd radio
            else
                return -1; // selects nothing
        }

        // 6.5 Create a custom ValidName method which will take a parameter string value from the Textbox Name and returns a Boolean after checking for duplicates.
        private bool ValidName(string name)
        {
            Stream file = File.Create("Trace_6.5.txt");
            TextWriterTraceListener myTextListener = new TextWriterTraceListener(file);
            Trace.Listeners.Add(myTextListener);

            Trace.WriteLine("Validating Name:");
            Trace.WriteLine("Input: " + name);

            TextInfo myTI = new CultureInfo("en-AU", false).TextInfo;
            string capitalName = myTI.ToTitleCase(name); // capitalises before checking

            Trace.WriteLine("Input Capitalised: " + capitalName);

            if (Wiki.Exists(dup => dup.GetName() == capitalName)) // does it exist already?
            {
                Trace.WriteLine("Duplicate Found. Returns False");
                Trace.Flush();
                Trace.Close();
                return false; // yes it exists already. return false for invalid
            }
            else
            {
                Trace.WriteLine("Duplicate Not Found. Returns True");
                Trace.Flush();
                Trace.Close();
                return true; // no it doesnt exist already. return true for valid
            }    
        }

        #endregion
    }
}