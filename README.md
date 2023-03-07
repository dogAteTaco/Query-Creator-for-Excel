# Query formula creator for Excel

This program enables you to create the formula you need to convert your raw data in your spreadsheet into queries for SQL Server and many other database managers.

## How to use the program

You'll need to input the name of the tablet you're going to UPDATING or INSERT INTO your data, how many columns you're inserting in your query or updating, the type of query your'e doing and on which language your Microsoft Excel program is (Formula syntax changes depending on it) and after you click Create Formula the formula should be in your Clipboard.

### Auto-complete for Table names

The program has a way to auto-complete table names while you're typing in case you're constantly using the same tables (like I do), to add them to the auto-complete just type a table name per line in the file named **suggestions.txt** (if it doesn't exist just create it and put it in the the same folder as the executable).

## Notes

- You should only use this program to create the formula for the first row and then copy that cell so the row number changes depending on the row instead of staying in the first row.
- The validation in the program prevents treating NULL as a string and assigning the actual NULL value to the column.
- For the meantime the program only works on Spanish and English but you can manually change the keywords on the formula to match your language.
- The program only let's you use one column as a where condition for your update queries.
- Microsoft Excel has a limit to how many characters a Formula can have in one cell so the cap if you validate cells for NULL values is around 150 columns or 300 if you don't validate
