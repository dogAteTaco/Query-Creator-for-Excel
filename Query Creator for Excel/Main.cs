using Query_Creator_for_Excel.Properties;
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Windows.Forms;

namespace Query_Creator_for_Excel
{
    public partial class Main : Form
    {
        private FormulaGenerator generator;
        private string query;
        
        private string copyToClipboardError;
        private string noTableError;
		//Formula labels
        public Main()
        {
            InitializeComponent();
			this.generator = new FormulaGenerator();
            //defaults the language for the UI and Excel
            this.SetupLanguage();
            //adds suggestions for the table name
            this.AddSuggestions();
        }

        
        private void SetupLanguage()
        {
            //changes labels based on your OS language (currently only implemented for Spanish or English)
            CultureInfo ci = CultureInfo.InstalledUICulture;
			ResourceManager langMng;
			switch (ci.TwoLetterISOLanguageName)
            {
                case "es":
					langMng = new ResourceManager("Query_Creator_for_Excel.Properties.labels-es", Assembly.GetExecutingAssembly());
					language.SelectedIndex = 0;
					break;
                default:
					langMng = new ResourceManager("Query_Creator_for_Excel.Properties.labels-en", Assembly.GetExecutingAssembly());
					language.SelectedIndex = 1;
					break;
            }
			
			tableLabel.Text = langMng.GetString("Title");
			columnLabel.Text = langMng.GetString("Columns");
			languageLabel.Text = langMng.GetString("Language");
			typeLabel.Text = langMng.GetString("TypeQuery");
			btonFormula.Text = langMng.GetString("FormulaButton");
			btonClipboard.Text = langMng.GetString("ClipboardButton");
			autCopy.Text = langMng.GetString("AutoCopy");
			validateNULL.Text = langMng.GetString("Validate");
			helpToolStripMenuItem.Text = langMng.GetString("Help");
			instructionsToolStripMenuItem.Text = langMng.GetString("Instructions");
			copyToClipboardError = langMng.GetString("ClipboardError");
			noTableError = langMng.GetString("NoTableError");
			this.Text = langMng.GetString("Title");
			typeQuery.SelectedIndex = 0;
			emptyAsNULL.Text = langMng.GetString("EmptyAsNull");
		}

        //Crea la Formula para el Query
        private void btonFormula_Click(object sender, EventArgs e)
        {
            if (tableName.Text == "")
                MessageBox.Show(noTableError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                FormulaGenerator.Language lang;
                switch (language.SelectedIndex)
                {
                    case 0:
                        lang = FormulaGenerator.Language.ES;
                        break;
                    default:
                        lang = FormulaGenerator.Language.ES;
                        break;
                }

				if (typeQuery.SelectedIndex == 1)
					query = generator.CreateInsertQuery(lang, tableName.Text, Convert.ToInt32(columnCount.Text), validateNULL.Checked, emptyAsNULL.Checked);
				else
					query = generator.CreateUpdateQuery(lang, tableName.Text, Convert.ToInt32(columnCount.Text), validateNULL.Checked, emptyAsNULL.Checked);
			}
                

			if (autCopy.Checked&&!query.Equals(""))
				Clipboard.SetDataObject(query, true, 10, 100);
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
