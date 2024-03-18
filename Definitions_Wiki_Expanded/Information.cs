using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Definitions_Wiki_Expanded
{
    internal class Information : IComparable<Information>
    {
        // 6.1 Create a separate class file to hold the four data items of the Data Structure (use the Data Structure Matrix as a guide).
        // Use private properties for the fields which must be of type “string”.
        // The class file must have separate setters and getters, add an appropriate IComparable for the Name attribute.
        // Save the class as “Information.cs”.

        // Attributes
        private string name;
        private string category;
        private string structure;
        private string definition;

        // getter
        public string getName()
        {
            return name;
        }

        // setter
        public void setName(string newName)
        {
            name = newName;
        }

        public int CompareTo(Information OtherName)
        {
            return name.CompareTo(OtherName.name);
        }

        public string getCategory()
        {
            return category;
        }

        public void setCategory(string newCategory)
        {
            category = newCategory;
        }

        public string getStructure()
        {
            return structure;
        }

        public void setStructure(string newStructure)
        {
            structure = newStructure;
        }

        public string getDefinition()
        {
            return definition;
        }

        public void setDefinition(string newDefinition)
        {
            definition = newDefinition;
            // example code
            // if (newCost < 0)
                // cost = 0;
            // else
                // cost = newCost;
        }

    }
}
