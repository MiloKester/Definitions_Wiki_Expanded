using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolTip;

// 30063179 Milo Kester
// Date Here
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

        // 6.4 Create a custom method to populate the ComboBox when the Form Load method is called.
        // The six categories must be read from a simple text file.
        private void Definitions_Wiki_Expanded_Load(object sender, System.EventArgs e)
        {
            FillComboBox();
        }

        private void FillComboBox()
        {
            var lines = File.ReadLines("Categories.txt");
            foreach (var line in lines)
            {
                comboBoxCategory.Items.Add(line);
            }
        }

        #endregion

        #region Add-Delete-Edit

        // 6.3 Create a button method to ADD a new item to the list.
        private void buttonAdd_Click(object sender, EventArgs e)
        {
            // uses || to see if either radio is checked, not optimal but does the job :thumbs_up:
            if (!string.IsNullOrEmpty(textBoxName.Text) && comboBoxCategory.SelectedIndex != -1 && (radioButtonLinear.Checked || radioButtonNonLinear.Checked) && !string.IsNullOrEmpty(textBoxDefinition.Text)) { // if all fields are filled
                if (ValidName(textBoxName.Text)) // if name returns valid
                {
                    Information newInformation = new Information();

                    newInformation.setName(textBoxName.Text);
                    newInformation.setCategory(comboBoxCategory.Text);
                    newInformation.setStructure(getStringFromRadio());
                    newInformation.setDefinition(textBoxDefinition.Text);

                    Wiki.Add(newInformation); // add values to wiki
                    DisplayAllDefinitions();
                    statusStripMessage.Text = "Added";
                    ClearAll();
                    textBoxName.Focus();
                }
                else
                {
                    statusStripMessage.Text = "Not Added. Name Likely a Duplicate";
                }
            }
            else
            {
                statusStripMessage.Text = "Please Fill In All Fields";
            }
        }

        // 6.7 Create a button method that will delete the currently selected record in the ListView.
        private void buttonDelete_Click(object sender, EventArgs e)
        {
            try
            {
                int currentIndex = listViewDisplay.FocusedItem.Index;
                if (currentIndex > -1)
                {
                    string message = "Are You Sure You Want This Delete This Entry?\nThis Action Is Permanent.";
                    string title = "Delete Definition";
                    MessageBoxButtons buttons = MessageBoxButtons.OKCancel;
                    DialogResult result;
                    result = MessageBox.Show(message, title, buttons, MessageBoxIcon.Warning);

                    if (result == DialogResult.OK)
                    {
                        Wiki.RemoveAt(currentIndex);
                        DisplayAllDefinitions();
                        ClearAll();
                        // this can probs be its on function for clearing and redisplaying if its not already. focus cursor in text as well
                        statusStripMessage.Text = "Deleted";
                    }
                    else
                    {
                        statusStripMessage.Text = "Not Deleted";
                    }
                }
            }
            catch
            {
                statusStripMessage.Text = "Invalid Selection";
            }

        }

        // 6.8 Create a button method that will save the edited record of the currently selected item in the ListView. All the changes in the input controls will be written back to the list. Display an updated version of the sorted list at the end of this process.
        // partly broken
        private void buttonEdit_Click(object sender, EventArgs e)
        {
            try
            {
                int currentIndex = listViewDisplay.FocusedItem.Index;
                if (currentIndex > -1)
                {
                    Wiki[currentIndex].setName(textBoxName.Text);
                    Wiki[currentIndex].setCategory(comboBoxCategory.Text);
                    // radio button
                    Wiki[currentIndex].setDefinition(textBoxDefinition.Text);
                    Wiki.Sort();
                    DisplayAllDefinitions();
                    statusStripMessage.Text = "Edit Successful";
                }
                else
                {
                    statusStripMessage.Text = "Edit Unsuccessful";
                }
            }
            catch
            {
                statusStripMessage.Text = "Please Select A Valid Entry";
            }
        }

        #endregion

        #region Displaying

        // 6.9 Create a single custom method that will sort and then display the Name and Category from the wiki information in the list.
        private void DisplayAllDefinitions()
        {
            listViewDisplay.Items.Clear();
            Wiki.Sort(); // icomparable means you can just use this
            statusStripMessage.Text = ""; // fresh start every display type beat might be better elsewhere

            foreach (var item in Wiki) // display all items from wiki
            {
                // stolen from stackexchange
                listViewDisplay.Items.Add(new ListViewItem(new string[] { item.getName(), item.getCategory() }));
            }
        }

        // 6.11 Create a ListView event so a user can select a Data Structure Name from the list of Names and the associated information will be displayed in the related text boxes combo box and radio button.
        private void listViewDisplay_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                int currentIndex = listViewDisplay.FocusedItem.Index;
                if (currentIndex > -1)
                {
                    displaySpecific(currentIndex);
                }
            }
            catch
            {
                statusStripMessage.Text = "Error";
            }
        }

        private void displaySpecific(int index)
        {
            textBoxName.Text = Wiki[index].getName();
            comboBoxCategory.Text = Wiki[index].getCategory();
            int radioIndx = getIndexFromRadio(index);
            if (radioIndx == 0)
            {
                radioButtonLinear.Checked = true;
            }
            else if (radioIndx == 1)
            {
                radioButtonNonLinear.Checked = true;
            }
            else
                statusStripMessage.Text = "error with radio box";
            textBoxDefinition.Text = Wiki[index].getDefinition();
        }

        #endregion

        #region Clear

        // 6.12 Create a custom method that will clear and reset the TextBoxes, ComboBox and Radio button
        private void ClearAll()
        {
            textBoxName.Clear();
            comboBoxCategory.SelectedIndex = -1;
            radioButtonLinear.Checked = false;
            radioButtonNonLinear.Checked = false;
            textBoxDefinition.Clear();
        }

        // 6.13 Create a double click event on the Name TextBox to clear the TextBoxes, ComboBox and Radio button.
        private void textBoxName_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ClearAll();
            textBoxName.Focus();
        }

        #endregion

        #region Search

        // 6.10 Create a button method that will use the builtin binary search to find a Data Structure name.
        // If the record is found the associated details will populate the appropriate input controls and highlight the name in the ListView.
        // At the end of the search process the search input TextBox must be cleared.
        private void buttonSearch_Click(object sender, EventArgs e)
        {
            Information searchName = new Information();
            searchName.setName(textBoxSearch.Text);
            int index = Wiki.BinarySearch(searchName);

            if (index > -1)
            {
                statusStripMessage.Text = "Found";
                displaySpecific(index);
                listViewDisplay.SelectedItems.Clear();
                listViewDisplay.Items[index].Selected = true;
                textBoxSearch.Clear();
            }
            else
            {
                statusStripMessage.Text = "Not Found";
            }
        }

        #endregion

        #region Save-Open

        // 6.14 Create two buttons for the manual open and save option; this must use a dialog box to select a file or rename a saved file.
        // All Wiki data is stored/retrieved using a binary reader/writer file format.

        // a hot mess
        // these shouldnt break as long as each entry has exactly 4

        private void menuItemSave_Click(object sender, EventArgs e)
        {
            // save dialog settings
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "dat files (*.dat) | *.dat";
            saveFileDialog.Title = "Save Dictionary";
            saveFileDialog.InitialDirectory = System.Windows.Forms.Application.StartupPath;
            saveFileDialog.DefaultExt = "dat";
            saveFileDialog.ShowDialog();
            string fileName = saveFileDialog.FileName;

            if (saveFileDialog.FileName != "") // if file name not empty
            {
                // save
                SaveRecord(fileName);
                statusStripMessage.Text = "File Saved";
            }
            else
            {
                // must have a user entered filename to save and will display status when cancel or x button is hit
                statusStripMessage.Text = "File Not Saved";
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
                            string name = Wiki[i].getName();
                            string category = Wiki[i].getCategory();
                            string structure = Wiki[i].getStructure();
                            string definition = Wiki[i].getDefinition();

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
                statusStripMessage.Text = "Error While Saving";
            }
        }

        private void menuItemOpen_Click(object sender, EventArgs e)
        {
            // open file dialog settings
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = System.Windows.Forms.Application.StartupPath;
            openFileDialog.Filter = "dat files (*.dat)| *.dat";
            openFileDialog.Title = "Open File";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // open file and display
                OpenRecord(openFileDialog.FileName);
            }
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
                            // need to create new instance for every itteration ty person on stack overflow
                            Information newInformation = new Information();

                            string name = reader.ReadString();
                            string category = reader.ReadString();
                            string structure = reader.ReadString();
                            string definition = reader.ReadString();

                            newInformation.setName(name);
                            newInformation.setCategory(category);
                            newInformation.setStructure(structure);
                            newInformation.setDefinition(definition);

                            Wiki.Add(newInformation);
                        }
                    }
                }
            }
            DisplayAllDefinitions();
        }

        #endregion



        // 6.6 Create two methods to highlight and return the values from the Radio button GroupBox.
        // The first method must return a string value from the selected radio button (Linear or Non-Linear).

        // can i just put these in the setters and getters yes or no
        private string getStringFromRadio()
        {
            // first stores the value
            // first will get the string of what is selected and returns as a string to store in other method
            string radioText = "";
            if (radioButtonLinear.Checked)
                radioText = radioButtonLinear.Text;
            else if (radioButtonNonLinear.Checked)
                radioText = radioButtonNonLinear.Text;

            return radioText;
        }

        // The second method must send an integer index which will highlight an appropriate radio button.
        private int getIndexFromRadio(int index)
        {
            // second retrieves and selects the value
            // second will check what value is currently stored using getStructure and then returns the matching index to use in other method

            // check string at provided index 
            string radioSelection = Wiki[index].getStructure();
            //string radioSelection = getRadioIndex.getStructure();

            if (radioSelection == "Linear")
                return 0;
            else if (radioSelection == "Non-Linear")
                return 1;
            else
                return -1;
        }


        // 6.5 Create a custom ValidName method which will take a parameter string value from the Textbox Name and returns a Boolean after checking for duplicates.
        private bool ValidName(string name)
        {
            if (Wiki.Exists(dup => dup.getName() == name))
                return false;
            else
                return true;
        }

        
        // 6.15 The Wiki application will save data when the form closes.
        private void Definitions_Wiki_Expanded_FormClosed(object sender, FormClosedEventArgs e)
        {
            // call save here but gonna have to put that in it own thing since you cant use a click function as a method or something
            // auto save so it saves it as "autosave" and opens autosave on open?
            // autosave can be rewritten over
        }
    }
}