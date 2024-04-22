using System;
using System.Globalization;

namespace Definitions_Wiki_Expanded
{
    internal class Information : IComparable<Information>
    {
        // 6.1 Create a separate class file to hold the four data items of the Data Structure (use the Data Structure Matrix as a guide). Use private properties for the fields which must be of type “string”. The class file must have separate setters and getters, add an appropriate IComparable for the Name attribute. Save the class as “Information.cs”.

        // Attributes
        private string name;
        private string category;
        private string structure;
        private string definition;

        // getter
        public string GetName()
        {
            return name;
        }

        // setter
        public void SetName(string newName)
        {
            TextInfo myTI = new CultureInfo("en-AU", false).TextInfo;
            name = myTI.ToTitleCase(newName);
        }

        // search and sort // used by the Icomparable
        public int CompareTo(Information OtherName)
        {
            return name.CompareTo(OtherName.name);
        }

        public string GetCategory()
        {
            return category;
        }

        public void SetCategory(string newCategory)
        {
            category = newCategory;
        }

        public string GetStructure()
        {
            return structure;
        }

        public void SetStructure(string newStructure)
        {
            structure = newStructure;
        }

        public string GetDefinition()
        {
            return definition;
        }

        public void SetDefinition(string newDefinition)
        {
            definition = newDefinition;
        }
    }
}
