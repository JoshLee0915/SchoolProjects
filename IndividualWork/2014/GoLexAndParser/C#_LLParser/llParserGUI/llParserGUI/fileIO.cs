using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Xml;

namespace LLParser
{
    // A class that handles file IO for the lexinal anls
    public class LexFileIO
    {
        // Stores the last exception thrown
        public Exception lastExcption { get; private set; }
        // Stores the hash table for lex anls
        public List<Hashtable> lexTableList { get; private set; }
        // Stores the keyword hash table
        public Hashtable keyWords { get; private set; }
        // Stores the productions for the predict sets
        public List<List<int>> predictSets { get; private set; }
        // Stores the parse table 
        public List<List<int>> parseTable { get; private set; }
        // Stores the sync set for err recovery
        public List<List<int>> syncSets { get; private set; }

        // Default Constructor
        public LexFileIO()
        { }

        // Method for reading a file in the form of text for analyis
        // Takes a file path as an argument and returns the contents of the file
        // returns null if an error ocurred
        public string readTxt(string file)
        {
            string assmbledFile = "";
            string[] brokenFile;

            try
            {
                // reads all lines from the file to a string array
                brokenFile = File.ReadAllLines(file);

                // converts each string to lower case and adds the removed \n then 
                // appends it to the string
                foreach (string line in brokenFile)
                    assmbledFile += line.ToLower() + "\n";

                // return the string representing the file
                return assmbledFile;
            }
            // if there is an exception store it and return a null array
            catch (Exception e)
            {
                lastExcption = e;
                return null;
            }
        }

        // Loads a table from a specified xml file
        public bool loadTable(string file)
        {
            XmlDocument tableXml = new XmlDocument();   // The raw xml document
            XmlNode lexTable = null;                    // The table for the lex anlyzer
            XmlNode keyTable = null;                    // The keyword table

            //Check if the file is an xml
            if (Path.GetExtension(file).ToLower() != ".xml")
            {
                lastExcption = new Exception("[ERR] Given file is not an xml");
                return false;
            }

            //Check if the file exists
            if (!File.Exists(file))
            {
                lastExcption = new Exception("[ERR] Given file can not be found or does not exist");
                return false;
            }

            try
            {
                // load the xml file
                tableXml.Load(file);

                foreach (XmlNode node in tableXml.DocumentElement)
                {
                    // check if the element is a worksheet
                    if (node.Name == "Worksheet")
                    {
                        // Check if it is a table or keywords
                        if (node.Attributes[0].Value == "Table")
                            lexTable = node["Table"];
                        else if (node.Attributes[0].Value == "Keywords")
                            keyTable = node["Table"];
                    }
                }

                // create a hash table for the for the keywords
                keyWords = createKeyHashTable(keyTable);
                // create a list of hashtables for the lex table
                lexTableList = createLexHashTable(lexTable);
            }
            catch (Exception e)
            {
                lastExcption = e;
                return false;
            }

            return true;
        }

        // Loads a table from a specified xml file
        public bool loadParseTable(string file)
        {
            XmlDocument tableXml = new XmlDocument();   // The raw xml document
            XmlNode setTableNode = null;                // The predict sets table
            XmlNode parseTableNode = null;              // The parse table
            XmlNode syncSetTableNode = null;            // The sync set table

            //Check if the file is an xml
            if (Path.GetExtension(file).ToLower() != ".xml")
            {
                lastExcption = new Exception("[ERR] Given file is not an xml");
                return false;
            }

            //Check if the file exists
            if (!File.Exists(file))
            {
                lastExcption = new Exception("[ERR] Given file can not be found or does not exist");
                return false;
            }

            try
            {
                // load the xml file
                tableXml.Load(file);

                foreach (XmlNode node in tableXml.DocumentElement)
                {
                    // check if the element is a worksheet
                    if (node.Name == "Worksheet")
                    {
                        // Check if it is a table or keywords
                        if (node.Attributes[0].Value == "ParserPredictSets")
                            setTableNode = node["Table"];
                        else if (node.Attributes[0].Value == "ParsingTable")
                            parseTableNode = node["Table"];
                        else if (node.Attributes[0].Value == "SyncSet")
                            syncSetTableNode = node["Table"];
                    }
                }
            }
            catch (Exception e)
            {
                lastExcption = e;
                return false;
            }
            predictSets = createPredictSets(setTableNode);
            parseTable = createParseTable(parseTableNode);
            syncSets = createSyncSets(syncSetTableNode);

            // check that both tables where loaded
            if (predictSets == null || parseTable == null || syncSets == null)
                return false;

            return true;
        }

        // Display the loaded lex table
        public string displayLexTable()
        {
            string lexTbl = "";

            foreach (string key in lexTableList[0].Keys)
                lexTbl += key + "\t";

            foreach (Hashtable row in lexTableList)
            {
                foreach (string key in row.Keys)
                    lexTbl += row[key] + "\t";
                lexTbl += "\n";
            }

            return lexTbl;
        }

        // Display the keyword table
        public string displayKeywordTable()
        {
            string lexTbl = "";

            foreach (string key in keyWords.Keys)
                lexTbl += key + "\t" + keyWords[key] + "\n";

            return lexTbl;
        }

        // creates a hash table from the xmlNode
        private List<Hashtable> createLexHashTable(XmlNode lexTable)
        {
            List<string> header = new List<string>();       // a list to store the header from the lexList
            List<Hashtable> table = new List<Hashtable>();  // a list to hold the table
            // Convert the xml table to a list of strings
            List<List<string>> lexList = xmlToList(lexTable);

            // remove the first colum of the table if it is larger than lexRow[0]
            for (int index = 1; index < lexList.Count; index++)
                if (lexList[0].Count < lexList[index].Count)
                    lexList[index].RemoveAt(0);

            // get the header to the table and store it into a list
            foreach (string lex in lexList[0])
            {
                // Check for special cases that requrie special symbols
                switch (lex.ToLower())
                {
                    case "space":
                        header.Add(" ");
                        break;
                    case "tab":
                        header.Add("\t");
                        break;
                    case "newline":
                        header.Add("\n");
                        break;
                    default:
                        header.Add(lex);
                        break;
                }
            }

            // remove the header from the list
            lexList.RemoveAt(0);

            // create the hash table
            foreach (List<string> row in lexList)
            {
                Hashtable tableRow = new Hashtable();
                for (int index = 0; index < header.Count; index++)
                {
                    // check if the state is an end state and if so exchange '-' with null
                    if (row[index] == "-")
                        tableRow.Add(header[index], -1);
                    else
                        tableRow.Add(header[index], int.Parse(row[index]));
                }
                table.Add(tableRow);
            }

            return table;
        }

        // Create a key hash table from the xmlNode
        private Hashtable createKeyHashTable(XmlNode lexKeywords)
        {
            Hashtable keyHashTable = new Hashtable();       // hash tabke for the key words
            // Convert the xml table to a list of strings
            List<List<string>> keyList = xmlToList(lexKeywords);

            // remove the header
            keyList.RemoveAt(0);
            //Generate the hash table
            foreach (List<string> row in keyList)
                keyHashTable.Add(row[1], int.Parse(row[0]));

            return keyHashTable;
        }

        // Create the predict sets
        private List<List<int>> createPredictSets(XmlNode predictSetsNode)
        {
            int parsedProduction = 0;
            List<List<string>> strProductions = new List<List<string>>(); // a list to hold the productions in string form
            List<List<int>> productionList = new List<List<int>>(); // the final parsed production lists for the predict sets
            // Convert the xml table to a list of strings
            List<List<string>> predictList = xmlToList(predictSetsNode);

            // remove the header
            predictList.RemoveAt(0);
            // get the productions in string form
            foreach (List<string> row in predictList)
            {
                List<int> tmpList = new List<int>();    // a temp list to hold the parsed productions

                // parse the productions from each cell into ints
                foreach (string production in row[1].Split(' '))
                {
                    if (production == "-")
                        tmpList.Add(-1);
                    else if(int.TryParse(production, out parsedProduction))
                        tmpList.Add(parsedProduction);
                    else
                        return null;    // err in parsing
                }
                // reverse the list so productions may be pushed onto the stack using increasing indexes
                tmpList.Reverse();
                // add the productions list to the list
                productionList.Add(tmpList);
            }
            // generate 
            return productionList;
        }

        // Create the parse table
        private List<List<int>> createParseTable(XmlNode parseTableNode)
        {
            int predictSet = 0;
            List<List<int>> tmpPraseTable = new List<List<int>>();  // temp parse table

            // Convert the xml table to a list of strings
            List<List<string>> parseTableList = xmlToList(parseTableNode);

            // remove the header
            parseTableList.RemoveAt(0);

            foreach (List<string> row in parseTableList)
            {
                List<int> tmpList = new List<int>();    // a temp list to hold the parsed productions

                // remove the first colum
                row.RemoveAt(0);

                // parse the productions from each cell into ints
                foreach (string cell in row)
                {
                    if (cell == "-")
                        tmpList.Add(-1);
                    else if (int.TryParse(cell, out predictSet))
                        tmpList.Add(predictSet);
                    else
                        return null;    // err in parsing
                }
                tmpPraseTable.Add(tmpList);
            }
            return tmpPraseTable;
        }

        private List<List<int>> createSyncSets(XmlNode syncSetNode)
        {
            int parsedProduction = 0;
            List<List<string>> strSyncTokens = new List<List<string>>(); // a list to hold the sync tokens in string form
            List<List<int>> syncList = new List<List<int>>(); // the final sync tokens lists for the sync sets
            // Convert the xml table to a list of strings
            List<List<string>> predictList = xmlToList(syncSetNode);

            // remove the header
            predictList.RemoveAt(0);
            // get the productions in string form
            foreach (List<string> row in predictList)
            {
                List<int> tmpList = new List<int>();    // a temp list to hold the parsed productions

                // parse the productions from each cell into ints
                foreach (string production in row[1].Split(' '))
                {
                    if (production == "-")
                        tmpList.Add(-1);
                    else if (int.TryParse(production, out parsedProduction))
                        tmpList.Add(parsedProduction);
                    else
                        return null;    // err in parsing
                }
                // add the productions list to the list
                syncList.Add(tmpList);
            }
            // generate 
            return syncList;
        }

        // Converts a passed xml node to a list of strings of the indivedual elements
        private List<List<string>> xmlToList(XmlNode node)
        {
            List<List<string>> xmlList = new List<List<string>>();
            foreach (XmlNode row in node)
            {
                bool notEmpty = false;  // used to identify rows with empty cells
                List<string> lexCell = new List<string>();  // A list for each cell

                // read each cell and add it to a list
                foreach (XmlNode cell in row)
                {
                    // check if the cell has a <Data> node within it
                    if (cell.HasChildNodes)
                    {
                        lexCell.Add(cell.InnerText);

                        notEmpty = true;    // There is atleast one cell with a <Data> node
                    }
                }

                // If the row had data in it add the list of cells to the list
                if (notEmpty)
                    xmlList.Add(lexCell);
            }
            return xmlList;
        }
        // Removed becouse unnecessary but kept as comment for later refrence
        /*public byte[] readRaw(string file)
        {
            try
            {
                return File.ReadAllBytes(file);
            }
            // if there is an exception store it and return a null array
            catch (Exception e)
            {
                lastExcption = e;
                return null;
            }
        }*/
    }
}
