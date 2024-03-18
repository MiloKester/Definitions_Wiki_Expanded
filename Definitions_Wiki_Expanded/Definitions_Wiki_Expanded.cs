using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;

namespace Definitions_Wiki_Expanded
{
    public partial class Definitions_Wiki_Expanded : Form
    {
        public Definitions_Wiki_Expanded()
        {
            InitializeComponent();
        }

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

        // 6.2 Create a global List<T> of type Information called Wiki.
        List<Information> Wiki = new List<Information>(); // List<> is known as Wiki

        // 6.3 Create a button method to ADD a new item to the list.
        // Use a TextBox for the Name input
        // ComboBox for the Category
        // Radio group for the Structure
        // Multiline TextBox for the Definition
        private void buttonAdd_Click(object sender, EventArgs e)
        {
            Information newInformation = new Information();
            if (ValidName(textBoxName.Text)) // if name returns valid
            {
                newInformation.setName(textBoxName.Text);
                newInformation.setCategory(comboBoxCategory.Text);
                newInformation.setStructure(groupBox1.Text);
                newInformation.setDefinition(textBoxDefinition.Text);

                Wiki.Add(newInformation); // add values to wiki
                DisplayAllDefinitions();
            }
            else
            {
                statusStrip1.Text = "testing error";
            }
        }

        private void DisplayAllDefinitions()
        {
            listViewDisplay.Items.Clear();

            foreach (var item in Wiki) // display all items from wiki
            {
                // only wants to do the first column for some fuckign reason
                listViewDisplay.Items.Add(item.getName(), item.getCategory());
            }
        }

        // 6.12 Create a custom method that will clear and reset the TextBoxes, ComboBox and Radio button
        private void ClearAll()
        {
            textBoxName.Clear();
            // comboBoxCategory.
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            textBoxDefinition.Clear();
        }

        // 6.13 Create a double click event on the Name TextBox to clear the TextBboxes, ComboBox and Radio button.
        private void textBoxName_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ClearAll();
        }

        // idk what im doing here im gonna be real with you
        // does not work
        private bool ValidName(string name)
        {
            // needs to loop through all of them????

            // loop through all of wiki with foreach
            // if it returns that a match was found mark valid as false
            // if it returns with no matches, mark valid as true

            bool dupFound = false;

            foreach (var item in Wiki)
            {

            }

            if (dupFound)
                return false;
            else
                return true; // value to add


            bool check = Wiki.Exists(e => e.Equals(name));
            foreach (var item in Wiki)
            {
                check = Wiki.Exists(e => e.Equals(name));
            }

            if (check)
                return true;
            else
                return false;
        }

    }
}
