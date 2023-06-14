namespace Query_Creator_for_Excel
{
    partial class Main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
			this.language = new System.Windows.Forms.ComboBox();
			this.tableLabel = new System.Windows.Forms.Label();
			this.languageLabel = new System.Windows.Forms.Label();
			this.tableName = new System.Windows.Forms.TextBox();
			this.btonFormula = new System.Windows.Forms.Button();
			this.btonClipboard = new System.Windows.Forms.Button();
			this.Query = new System.Windows.Forms.TextBox();
			this.autCopy = new System.Windows.Forms.CheckBox();
			this.typeQuery = new System.Windows.Forms.ComboBox();
			this.typeLabel = new System.Windows.Forms.Label();
			this.columnCount = new System.Windows.Forms.TextBox();
			this.columnLabel = new System.Windows.Forms.Label();
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.instructionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.statusStrip1 = new System.Windows.Forms.StatusStrip();
			this.validateNULL = new System.Windows.Forms.CheckBox();
			this.emptyAsNULL = new System.Windows.Forms.CheckBox();
			this.menuStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// language
			// 
			this.language.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.language.FormattingEnabled = true;
			this.language.Items.AddRange(new object[] {
            "ESP",
            "ENG"});
			this.language.Location = new System.Drawing.Point(78, 102);
			this.language.Name = "language";
			this.language.Size = new System.Drawing.Size(133, 23);
			this.language.TabIndex = 2;
			// 
			// tableLabel
			// 
			this.tableLabel.AutoSize = true;
			this.tableLabel.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.tableLabel.Location = new System.Drawing.Point(38, 47);
			this.tableLabel.Name = "tableLabel";
			this.tableLabel.Size = new System.Drawing.Size(34, 15);
			this.tableLabel.TabIndex = 2;
			this.tableLabel.Text = "Tabla";
			// 
			// languageLabel
			// 
			this.languageLabel.AutoSize = true;
			this.languageLabel.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.languageLabel.Location = new System.Drawing.Point(20, 105);
			this.languageLabel.Name = "languageLabel";
			this.languageLabel.Size = new System.Drawing.Size(56, 15);
			this.languageLabel.TabIndex = 3;
			this.languageLabel.Text = "Lenguaje";
			// 
			// tableName
			// 
			this.tableName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
			this.tableName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
			this.tableName.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.tableName.Location = new System.Drawing.Point(78, 44);
			this.tableName.Name = "tableName";
			this.tableName.Size = new System.Drawing.Size(133, 23);
			this.tableName.TabIndex = 0;
			// 
			// btonFormula
			// 
			this.btonFormula.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btonFormula.Location = new System.Drawing.Point(250, 71);
			this.btonFormula.Name = "btonFormula";
			this.btonFormula.Size = new System.Drawing.Size(265, 23);
			this.btonFormula.TabIndex = 4;
			this.btonFormula.Text = "Crear Query";
			this.btonFormula.UseVisualStyleBackColor = true;
			this.btonFormula.Click += new System.EventHandler(this.btonFormula_Click);
			// 
			// btonClipboard
			// 
			this.btonClipboard.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btonClipboard.Location = new System.Drawing.Point(250, 101);
			this.btonClipboard.Name = "btonClipboard";
			this.btonClipboard.Size = new System.Drawing.Size(265, 23);
			this.btonClipboard.TabIndex = 5;
			this.btonClipboard.Text = "Copiar Query a Clipboard";
			this.btonClipboard.UseVisualStyleBackColor = true;
			this.btonClipboard.Click += new System.EventHandler(this.CopyToClipboard);
			// 
			// Query
			// 
			this.Query.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Query.Location = new System.Drawing.Point(250, 131);
			this.Query.Multiline = true;
			this.Query.Name = "Query";
			this.Query.Size = new System.Drawing.Size(265, 103);
			this.Query.TabIndex = 6;
			// 
			// autCopy
			// 
			this.autCopy.AutoSize = true;
			this.autCopy.Checked = true;
			this.autCopy.CheckState = System.Windows.Forms.CheckState.Checked;
			this.autCopy.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.autCopy.Location = new System.Drawing.Point(250, 240);
			this.autCopy.Name = "autCopy";
			this.autCopy.Size = new System.Drawing.Size(161, 19);
			this.autCopy.TabIndex = 7;
			this.autCopy.Text = "Copiar Automaticamente";
			this.autCopy.UseVisualStyleBackColor = true;
			// 
			// typeQuery
			// 
			this.typeQuery.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.typeQuery.FormattingEnabled = true;
			this.typeQuery.Items.AddRange(new object[] {
            "UPDATE",
            "INSERT INTO"});
			this.typeQuery.Location = new System.Drawing.Point(336, 41);
			this.typeQuery.Name = "typeQuery";
			this.typeQuery.Size = new System.Drawing.Size(179, 23);
			this.typeQuery.TabIndex = 3;
			// 
			// typeLabel
			// 
			this.typeLabel.AutoSize = true;
			this.typeLabel.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.typeLabel.Location = new System.Drawing.Point(247, 44);
			this.typeLabel.Name = "typeLabel";
			this.typeLabel.Size = new System.Drawing.Size(84, 15);
			this.typeLabel.TabIndex = 17;
			this.typeLabel.Text = "Tipo de Query";
			// 
			// columnCount
			// 
			this.columnCount.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.columnCount.Location = new System.Drawing.Point(78, 73);
			this.columnCount.Name = "columnCount";
			this.columnCount.Size = new System.Drawing.Size(42, 23);
			this.columnCount.TabIndex = 1;
			this.columnCount.Text = "2";
			// 
			// columnLabel
			// 
			this.columnLabel.AutoSize = true;
			this.columnLabel.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.columnLabel.Location = new System.Drawing.Point(14, 76);
			this.columnLabel.Name = "columnLabel";
			this.columnLabel.Size = new System.Drawing.Size(60, 15);
			this.columnLabel.TabIndex = 21;
			this.columnLabel.Text = "Columnas";
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.helpToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(548, 24);
			this.menuStrip1.TabIndex = 22;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// helpToolStripMenuItem
			// 
			this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.instructionsToolStripMenuItem});
			this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
			this.helpToolStripMenuItem.Size = new System.Drawing.Size(53, 20);
			this.helpToolStripMenuItem.Text = "Ayuda";
			// 
			// instructionsToolStripMenuItem
			// 
			this.instructionsToolStripMenuItem.Name = "instructionsToolStripMenuItem";
			this.instructionsToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
			this.instructionsToolStripMenuItem.Text = "Instrucciones";
			this.instructionsToolStripMenuItem.Click += new System.EventHandler(this.OpenInstructions);
			// 
			// statusStrip1
			// 
			this.statusStrip1.Location = new System.Drawing.Point(0, 324);
			this.statusStrip1.Name = "statusStrip1";
			this.statusStrip1.Size = new System.Drawing.Size(548, 22);
			this.statusStrip1.TabIndex = 23;
			this.statusStrip1.Text = "statusStrip1";
			// 
			// validateNULL
			// 
			this.validateNULL.AutoSize = true;
			this.validateNULL.Checked = true;
			this.validateNULL.CheckState = System.Windows.Forms.CheckState.Checked;
			this.validateNULL.Location = new System.Drawing.Point(250, 266);
			this.validateNULL.Name = "validateNULL";
			this.validateNULL.Size = new System.Drawing.Size(89, 17);
			this.validateNULL.TabIndex = 24;
			this.validateNULL.Text = "Validar NULL";
			this.validateNULL.UseVisualStyleBackColor = true;
			// 
			// emptyAsNULL
			// 
			this.emptyAsNULL.AutoSize = true;
			this.emptyAsNULL.Checked = true;
			this.emptyAsNULL.CheckState = System.Windows.Forms.CheckState.Checked;
			this.emptyAsNULL.Location = new System.Drawing.Point(250, 289);
			this.emptyAsNULL.Name = "emptyAsNULL";
			this.emptyAsNULL.Size = new System.Drawing.Size(163, 17);
			this.emptyAsNULL.TabIndex = 25;
			this.emptyAsNULL.Text = "Espacios vacios como NULL";
			this.emptyAsNULL.UseVisualStyleBackColor = true;
			// 
			// Main
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(548, 346);
			this.Controls.Add(this.emptyAsNULL);
			this.Controls.Add(this.validateNULL);
			this.Controls.Add(this.statusStrip1);
			this.Controls.Add(this.columnLabel);
			this.Controls.Add(this.columnCount);
			this.Controls.Add(this.typeLabel);
			this.Controls.Add(this.typeQuery);
			this.Controls.Add(this.autCopy);
			this.Controls.Add(this.Query);
			this.Controls.Add(this.btonClipboard);
			this.Controls.Add(this.btonFormula);
			this.Controls.Add(this.tableName);
			this.Controls.Add(this.languageLabel);
			this.Controls.Add(this.tableLabel);
			this.Controls.Add(this.language);
			this.Controls.Add(this.menuStrip1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MainMenuStrip = this.menuStrip1;
			this.MaximumSize = new System.Drawing.Size(564, 385);
			this.MinimumSize = new System.Drawing.Size(564, 355);
			this.Name = "Main";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Creador de Formula Excel para Queries SQL";
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox language;
        private System.Windows.Forms.Label tableLabel;
        private System.Windows.Forms.Label languageLabel;
        private System.Windows.Forms.TextBox tableName;
        private System.Windows.Forms.Button btonFormula;
        private System.Windows.Forms.Button btonClipboard;
        private System.Windows.Forms.TextBox Query;
        private System.Windows.Forms.CheckBox autCopy;
        private System.Windows.Forms.ComboBox typeQuery;
        private System.Windows.Forms.Label typeLabel;
        private System.Windows.Forms.TextBox columnCount;
        private System.Windows.Forms.Label columnLabel;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem instructionsToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.CheckBox validateNULL;
        private System.Windows.Forms.CheckBox emptyAsNULL;
    }
}