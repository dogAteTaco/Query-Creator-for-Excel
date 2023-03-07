using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Globalization;
using System.IO;
using System.Windows.Forms;

namespace Query_Creator_for_Excel
{
    public partial class Main : Form
    {
        private string query;
        private List<string> columns;
        private string limitCharacterError;
        private string copyToClipboardError;
        private string noTableError;

        public Main()
        {
            InitializeComponent();
            //initializes the column header list
            columns = new List<string>();
            this.insertColumnHeaders();
            //defaults the language for the UI and Excel
            this.SetupLanguage();
            //adds suggestions for the table name
            this.AddSuggestions();
        }

        private void SetupLanguage()
        {
            //changes labels based on your OS language (currently only implemented for Spanish or English)
            CultureInfo ci = CultureInfo.InstalledUICulture;
            if (ci.TwoLetterISOLanguageName == "es")
            {
                tableLabel.Text = "Tabla";
                columnLabel.Text = "Columnas";
                languageLabel.Text = "Lenguaje";
                typeQuery.Text = "Tipo de Query";
                btonFormula.Text = "Crear Formula";
                btonClipboard.Text = "Copiar formula a Clipboard";
                autCopy.Text = "Copiar Automaticamente";
                validateNULL.Text = "Validar NULL";
                helpToolStripMenuItem.Text = "Ayuda";
                instructionsToolStripMenuItem.Text = "Instrucciones";
                language.SelectedIndex = 0;
                limitCharacterError = "La formula excede el limite de 8192 caractéres de Microsoft Excel.";
                copyToClipboardError = "No se pudo copiar al Clipboard.";
                noTableError = "No se ha capturado el nombre de la Tabla.";
                this.Text = "Creador de Fórmulas de Query para Excel";
                typeQuery.SelectedIndex = 0;
            }
            else
            {
                tableLabel.Text = "Table";
                columnLabel.Text = "Columns";
                languageLabel.Text = "Language";
                typeLabel.Text = "Type of Query";
                btonFormula.Text = "Create Formula";
                btonClipboard.Text = "Copy Formula to Clipboard";
                autCopy.Text = "Copy Automatically";
                validateNULL.Text = "Validate NULL";
                helpToolStripMenuItem.Text = "Help";
                instructionsToolStripMenuItem.Text = "Instructions";
                language.SelectedIndex = 1;
                limitCharacterError = "The formula exceeds the 8192 character limit of Microsoft Excel.";
                copyToClipboardError = "Couldn't copy formula to Clipboard.";
                noTableError = "No table name has been given.";
                this.Text = "Query formula creator for Excel";
                typeQuery.SelectedIndex = 1;
            }
        }
        //Creates the formula for the Insert Query 
        private void CreateInsertQuery()
        {
            bool first = true;
            //creates the columns part of the query
            if (language.SelectedIndex == 0)
                query = "=CONCATENAR(";
            else
                query = "=CONCATENATE(";
            query += "\"insert into " + tableName.Text + "(";
            //var set = new HashSet<string>();
            //foreach (var list in columns)
            //{
            //    foreach (var item in list)
            //    {
            //        set.Add(item.ToString());
            //    }
            //}
            //adds the columns names in the formula based on the first row of the excel document
            try
            {
                for (int i = 0; i < Int32.Parse(columnCount.Text); i++)
                {
                    if (first)
                        query += "\",$" + columns[i] + "$1,\"";
                    else
                        query += ",\",$" + columns[i] + "$1,\"";
                    first = false;
                }
            }
            catch (Exception e)
            {
                //this error should only occur when you surpass the limit of 3 characters for the column name. Example: TBD.
                MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            //starts adding the values
            query += ") values(\",";
            first = true;

            for (int i = 0; i < Int32.Parse(columnCount.Text); i++)
            {
                //code to add values to insert for the first row
                if (first)
                {
                    //Checks for NULL to prevent issues of treating it as as String
                    if (validateNULL.Checked)
                    {
                        if(!emptyAsNULL.Checked)
                            if (language.SelectedIndex == 0)
                                query += $"SI(IGUAL({columns[i]}2,\"NULL\"),\"NULL\",CONCATENAR(\"'\",{columns[i]}2,\"'\")),";
                            else
                                query += $"IF(EXACT({columns[i]}2,\"NULL\"),\"NULL\",CONCATENATE(\"'\",{columns[i]}2,\"'\")),";
                        else
                            if (language.SelectedIndex == 0)
                            query += $"SI(O(IGUAL({columns[i]}2,\"NULL\"),ESBLANCO({columns[i]}2)),\"NULL\",CONCATENAR(\"'\",{columns[i]}2,\"'\")),";
                        else
                            query += $"IF(OR(EXACT({columns[i]}2,\"NULL\"),ISBLANK({columns[i]}2)),\"NULL\",CONCATENATE(\"'\",{columns[i]}2,\"'\")),";
                    }
                    else
                    {
                        if(!emptyAsNULL.Checked)
                            query += "'\"," + columns[i] + "2,\"'";
                        else
                            query += "'\"," + columns[i] + "2,\"'";
                    }
                }
                //adds the rest of the rows 
                else
                {
                    //Checks for NULL to prevent issues of treating it as as String
                    if (validateNULL.Checked)
                    {
                        if (!emptyAsNULL.Checked)
                            if (language.SelectedIndex == 0)
                                query += $",\",\",SI(IGUAL({columns[i]}2,\"NULL\"),\"NULL\",CONCATENAR(\"'\",{columns[i]}2,\"'\")),";
                            else
                                query += $",\",\",IF(EXACT({columns[i]}2,\"NULL\"),\"NULL\",CONCATENATE(\"'\",{columns[i]}2,\"'\")),";
                        else
                            if (language.SelectedIndex == 0)
                                query += $",\",\",SI(O(IGUAL({columns[i]}2,\"NULL\"),ESBLANCO({columns[i]}2)),\"NULL\",CONCATENAR(\"'\",{columns[i]}2,\"'\")),";
                        else
                                query += $",\",\",IF(OR(EXACT({columns[i]}2,\"NULL\"),ISBLANK({columns[i]}2)),\"NULL\",CONCATENATE(\"'\",{columns[i]}2,\"'\")),";
                    }
                    else
                    {
                        if(!emptyAsNULL.Checked)
                            query += ",\",$" + columns[i] + "$1,\"='\"," + columns[i] + "2,\"'";
                        else
                            query += ",\",$" + columns[i] + "$1,\"='\"," + columns[i] + "2,\"'";
                    }
                }
                first = false;
            }
            query += "\")\")";
            //This condition is to check if the formula is too long for Excel (Excel has a limit of 8192 characters)
            if (query.Length > 8192)
            {
                MessageBox.Show(limitCharacterError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                Query.Text = query;

                if (autCopy.Checked)
                    Clipboard.SetDataObject(query, true, 10, 100);
            }
        }

        //Creates formula for the Update
        private void CreateUpdateQuery()
        {
            bool first = true;
            if (language.SelectedIndex == 0)
                query = "=CONCATENAR(";
            else
                query = "=CONCATENATE(";
            query += "\"update " + tableName.Text + " ";

            try
            {
                for (int i = 0; i < Int32.Parse(columnCount.Text); i++)
                {
                    if (i == 0)
                        i++;

                    if (first)
                    {
                        //Checks for NULL to prevent issues of treating it as as String
                        if (validateNULL.Checked)
                            if (language.SelectedIndex == 0)
                                query += $"set \",${columns[i]}$1,\"=\",SI(IGUAL({columns[i]}2,\"NULL\"),\"NULL\",CONCATENAR(\"'\",{columns[i]}2,\"'\")),";
                            else
                                query += $"set \",${columns[i]}$1,\"=\",IF(EXACT({columns[i]}2,\"NULL\"),\"NULL\",CONCATENATE(\"'\",{columns[i]}2,\"'\")),";
                        else
                            query += "set \",$" + columns[i] + "$1,\"='\"," + columns[i] + "2,\"'";
                    }
                    else
                    {
                        //Checks for NULL to prevent issues of treating it as as String
                        if (validateNULL.Checked)
                            if (language.SelectedIndex == 0)
                                query += $"\",\",${columns[i]}$1,\"=\",SI(IGUAL({columns[i]}2,\"NULL\"),\"NULL\",CONCATENAR(\"'\",{columns[i]}2,\"'\")),";
                            else
                                query += $"\",\",${columns[i]}$1,\"=\",IF(EXACT({columns[i]}2,\"NULL\"),\"NULL\",CONCATENATE(\"'\",{columns[i]}2,\"'\")),";
                        else
                            query += ",\",$" + columns[i] + "$1,\"='\"," + columns[i] + "2,\"'";
                    }
                    first = false;
                }
            }
            catch (Exception e)
            {
                //this error should only occur when you surpass the limit of 3 characters for the column name. Example: TBD.
                MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
            //Adds the where condition based on the first column
            query += "\" where \",$A$1,\"='\",A2,\"'";
            query += "\")";

            //This condition is to check if the formula is too long for Excel (Excel has a limit of 8192 characters)
            if (query.Length > 8192)
                MessageBox.Show(limitCharacterError, "Error");
            else
            {
                Query.Text = query;

                if (autCopy.Checked)
                    try
                    {
                        Clipboard.SetText(query);
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show(copyToClipboardError);
                    }
            }
        }

        //Crea la Formula para el Query
        private void btonFormula_Click(object sender, EventArgs e)
        {
            if (tableName.Text == "")
                MessageBox.Show(noTableError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
                if (typeQuery.SelectedIndex == 1)
                CreateInsertQuery();
            else
                CreateUpdateQuery();
        }

        //Copies Query Text to the Clipboard
        private void CopyToClipboard(object sender, EventArgs e)
        {
            try
            {
                Clipboard.SetText(query);
            }
            catch (Exception exc)
            {
                MessageBox.Show(copyToClipboardError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Crea Abecedario para nombre de Columnas
        private void insertColumnHeaders()
        {
            //Adds the column header of the first 26 (A to Z)
            for (char c = 'A'; c <= 'Z'; c++)
                columns.Add(c.ToString());
            //Makes a copy of the Alphabet
            List<string> temp = new List<string>(columns);
            //Adds the column headers from AA to ZZ
            foreach (string letter in temp)
                for (char c = 'A'; c <= 'Z'; c++)
                    columns.Add(letter + c.ToString());
            //Adds the column headers from AAA to ZZZ
            foreach (string letter in temp)
                foreach (string letter1 in temp)
                    for (char c = 'A'; c <= 'Z'; c++)
                        columns.Add(letter + letter1 + c.ToString());
        }

        private void OpenInstructions(object sender, EventArgs e)
        {
            new Help().ShowDialog();
        }

        private void AddSuggestions()
        {
            var source = new AutoCompleteStringCollection();
            //adds suggestions based on a text file you can create
            if(File.Exists("suggestions.txt"))
            foreach (string suggestion in File.ReadAllLines("suggestions.txt"))
                source.Add(suggestion);

            tableName.AutoCompleteCustomSource = source;
        }
    }
}
