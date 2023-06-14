using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Windows.Forms;

namespace Query_Creator_for_Excel
{
	public class FormulaGenerator
	{
		//Crea Abecedario para nombre de Columnas
		private List<string> columns;

		public FormulaGenerator() { 
			columns = new List<string>();
			this.InsertColumnHeaders();
		}
		private void InsertColumnHeaders()
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
		public string CreateInsertQuery(int langIndex,string tableName, int columnCount,bool validateNULL,bool emptyAsNULL)
		{
			bool first = true;
			string query;
			ResourceManager langMng;
			//creates the columns part of the query
			switch (langIndex)
			{
				case 0:
					langMng = new ResourceManager("Query_Creator_for_Excel.Properties.labels-es", Assembly.GetExecutingAssembly());
					break;
				default:
					langMng = new ResourceManager("Query_Creator_for_Excel.Properties.labels-en", Assembly.GetExecutingAssembly());
					break;
			}
			query = $"={langMng.GetString("Concatenate")}(";
			query += "\"insert into " + tableName + "(";

			//adds the columns names in the formula based on the first row of the excel document
			try
			{
				for (int i = 0; i < columnCount; i++)
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
				return "";
			}
			//starts adding the values
			query += ") values(\",";
			first = true;

			for (int i = 0; i <columnCount; i++)
			{
				//code to add values to insert for the first row
				if (first)
				{
					//Checks for NULL to prevent issues of treating it as as String
					if (validateNULL)
					{
						if (!emptyAsNULL)
							query += $"{langMng.GetString("If")}({langMng.GetString("Exact")}({columns[i]}2,\"NULL\"),\"NULL\"," +
								$"{langMng.GetString("Concatenate")}(\"'\",{columns[i]}2,\"'\")),";
						else
							query += $"{langMng.GetString("If")}({langMng.GetString("Or")}({langMng.GetString("Exact")}({columns[i]}2,\"NULL\")," +
								$"{langMng.GetString("IsBlank")}({columns[i]}2)),\"NULL\"," +
								$"{langMng.GetString("Concatenate")}(\"'\",{columns[i]}2,\"'\")),";
					}
					else
					{
						if (!emptyAsNULL)
							query += $"\"'\",{columns[i]}2,\"'\"";
						else
							query += $"\",{columns[i]}2,\"'";
					}
				}
				//adds the rest of the rows 
				else
				{
					//Checks for NULL to prevent issues of treating it as as String
					if (validateNULL)
					{
						if (!emptyAsNULL)
							query += $",\",\",{langMng.GetString("If")}({langMng.GetString("Exact")}({columns[i]}2,\"NULL\"),\"NULL\"," +
								$"{langMng.GetString("Concatenate")}(\"'\",{columns[i]}2,\"'\")),";
						else
							query += $",\",\",{langMng.GetString("If")}({langMng.GetString("Or")}({langMng.GetString("Exact")}({columns[i]}2,\"NULL\")," +
								$"{langMng.GetString("IsBlank")}({columns[i]}2)),\"NULL\",{langMng.GetString("Concatenate")}(\"'\",{columns[i]}2,\"'\")),";
					}
					else
					{
						if (!emptyAsNULL)
							query += $",\",'\",{columns[i]}2,\"'\"";

						else
							query += $",\",'\",{columns[i]}2,\"'\"";
					}
				}
				first = false;
			}
			query += ",\");\")";
			//This condition is to check if the formula is too long for Excel (Excel has a limit of 8192 characters)
			if (query.Length > 8192)
			{
				MessageBox.Show(langMng.GetString("CharacterLimitError"), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return "";
			}
			else
			{
				return query;
			}
			
		}

		//Creates formula for the Update
		public string CreateUpdateQuery(int langIndex, string tableName, int columnCount, bool validateNULL, bool emptyAsNULL)
		{
			bool first = true;
			string query = "";
			ResourceManager langMng;
			//creates the columns part of the query
			switch (langIndex)
			{
				case 0:
					langMng = new ResourceManager("Query_Creator_for_Excel.Properties.labels-es", Assembly.GetExecutingAssembly());
					break;
				default:
					langMng = new ResourceManager("Query_Creator_for_Excel.Properties.labels-en", Assembly.GetExecutingAssembly());
					break;
			}

			if (langIndex==0)
				query = "=CONCATENAR(";
			else
				query = "=CONCATENATE(";
			query += "\"update " + tableName + " ";

			try
			{
				for (int i = 0; i < columnCount; i++)
				{
					if (i == 0)
						i++;

					if (first)
					{
						//Checks for NULL to prevent issues of treating it as as String
						if (validateNULL)
							query += $"set \",${columns[i]}$1,\"=\",SI(IGUAL({columns[i]}2,\"NULL\"),\"NULL\",CONCATENAR(\"'\",{columns[i]}2,\"'\")),";
						else
							query += "set \",$" + columns[i] + "$1,\"='\"," + columns[i] + "2,\"'";
					}
					else
					{
						//Checks for NULL to prevent issues of treating it as as String
						if (validateNULL)
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
			query += "\" where \",$A$1,\"='\",A2,\"';";
			query += "\")";

			//This condition is to check if the formula is too long for Excel (Excel has a limit of 8192 characters)
			if (query.Length > 8192)
			{
				MessageBox.Show(langMng.GetString("CharacterLimitError"), "Error");
				return "";
			}	
			else
			{
				return query;
			}
		}
	}
}
