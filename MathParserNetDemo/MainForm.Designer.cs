namespace MathParserNetDemo
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.txtEquation = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSolve = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtAnswer = new System.Windows.Forms.TextBox();
            this.gbEquations = new System.Windows.Forms.GroupBox();
            this.gbVariables = new System.Windows.Forms.GroupBox();
            this.btnRemoveVariable = new System.Windows.Forms.Button();
            this.btnAddVariable = new System.Windows.Forms.Button();
            this.lbVariables = new System.Windows.Forms.ListBox();
            this.txtVariableValue = new System.Windows.Forms.TextBox();
            this.txtVariableName = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.ttVariables = new System.Windows.Forms.ToolTip(this.components);
            this.tmrVarDisable = new System.Windows.Forms.Timer(this.components);
            this.gbFunctions = new System.Windows.Forms.GroupBox();
            this.btnRemoveFunction = new System.Windows.Forms.Button();
            this.btnAddFunction = new System.Windows.Forms.Button();
            this.lbFunctions = new System.Windows.Forms.ListBox();
            this.txtFunctionValue = new System.Windows.Forms.TextBox();
            this.txtFunctionName = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.tmrFuncDisable = new System.Windows.Forms.Timer(this.components);
            this.ttFunctions = new System.Windows.Forms.ToolTip(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgDelegates = new System.Windows.Forms.DataGridView();
            this.label9 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gbEquations.SuspendLayout();
            this.gbVariables.SuspendLayout();
            this.gbFunctions.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgDelegates)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtEquation
            // 
            this.txtEquation.Location = new System.Drawing.Point(204, 17);
            this.txtEquation.Name = "txtEquation";
            this.txtEquation.Size = new System.Drawing.Size(306, 20);
            this.txtEquation.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(197, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Enter a mathematical problem to simplify:";
            // 
            // btnSolve
            // 
            this.btnSolve.Location = new System.Drawing.Point(308, 39);
            this.btnSolve.Name = "btnSolve";
            this.btnSolve.Size = new System.Drawing.Size(75, 23);
            this.btnSolve.TabIndex = 2;
            this.btnSolve.Text = "Solve";
            this.btnSolve.UseVisualStyleBackColor = true;
            this.btnSolve.Click += new System.EventHandler(this.BtnSolveClick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(107, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Answer to problem:";
            // 
            // txtAnswer
            // 
            this.txtAnswer.Location = new System.Drawing.Point(204, 40);
            this.txtAnswer.Name = "txtAnswer";
            this.txtAnswer.Size = new System.Drawing.Size(100, 20);
            this.txtAnswer.TabIndex = 4;
            // 
            // gbEquations
            // 
            this.gbEquations.Controls.Add(this.txtEquation);
            this.gbEquations.Controls.Add(this.txtAnswer);
            this.gbEquations.Controls.Add(this.label1);
            this.gbEquations.Controls.Add(this.label2);
            this.gbEquations.Controls.Add(this.btnSolve);
            this.gbEquations.Location = new System.Drawing.Point(12, 27);
            this.gbEquations.Name = "gbEquations";
            this.gbEquations.Size = new System.Drawing.Size(518, 71);
            this.gbEquations.TabIndex = 5;
            this.gbEquations.TabStop = false;
            this.gbEquations.Text = "Custom &Equations";
            // 
            // gbVariables
            // 
            this.gbVariables.Controls.Add(this.btnRemoveVariable);
            this.gbVariables.Controls.Add(this.btnAddVariable);
            this.gbVariables.Controls.Add(this.lbVariables);
            this.gbVariables.Controls.Add(this.txtVariableValue);
            this.gbVariables.Controls.Add(this.txtVariableName);
            this.gbVariables.Controls.Add(this.label5);
            this.gbVariables.Controls.Add(this.label4);
            this.gbVariables.Controls.Add(this.label3);
            this.gbVariables.Location = new System.Drawing.Point(12, 109);
            this.gbVariables.Name = "gbVariables";
            this.gbVariables.Size = new System.Drawing.Size(518, 124);
            this.gbVariables.TabIndex = 6;
            this.gbVariables.TabStop = false;
            this.gbVariables.Text = "Custom Variables";
            this.gbVariables.Paint += new System.Windows.Forms.PaintEventHandler(this.GbVariablesPaint);
            // 
            // btnRemoveVariable
            // 
            this.btnRemoveVariable.Location = new System.Drawing.Point(337, 92);
            this.btnRemoveVariable.Name = "btnRemoveVariable";
            this.btnRemoveVariable.Size = new System.Drawing.Size(110, 23);
            this.btnRemoveVariable.TabIndex = 7;
            this.btnRemoveVariable.Text = "Remove Variable(s)";
            this.btnRemoveVariable.UseVisualStyleBackColor = true;
            this.btnRemoveVariable.Click += new System.EventHandler(this.BtnRemoveVariableClick);
            // 
            // btnAddVariable
            // 
            this.btnAddVariable.Location = new System.Drawing.Point(87, 92);
            this.btnAddVariable.Name = "btnAddVariable";
            this.btnAddVariable.Size = new System.Drawing.Size(83, 23);
            this.btnAddVariable.TabIndex = 6;
            this.btnAddVariable.Text = "Add Variable";
            this.btnAddVariable.UseVisualStyleBackColor = true;
            this.btnAddVariable.Click += new System.EventHandler(this.BtnAddVariableClick);
            // 
            // lbVariables
            // 
            this.lbVariables.FormattingEnabled = true;
            this.lbVariables.Location = new System.Drawing.Point(288, 19);
            this.lbVariables.Name = "lbVariables";
            this.lbVariables.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lbVariables.Size = new System.Drawing.Size(222, 69);
            this.lbVariables.TabIndex = 5;
            this.lbVariables.MouseHover += new System.EventHandler(this.LbVariablesMouseHover);
            // 
            // txtVariableValue
            // 
            this.txtVariableValue.Location = new System.Drawing.Point(54, 66);
            this.txtVariableValue.Name = "txtVariableValue";
            this.txtVariableValue.Size = new System.Drawing.Size(169, 20);
            this.txtVariableValue.TabIndex = 4;
            // 
            // txtVariableName
            // 
            this.txtVariableName.Location = new System.Drawing.Point(54, 43);
            this.txtVariableName.Name = "txtVariableName";
            this.txtVariableName.Size = new System.Drawing.Size(169, 20);
            this.txtVariableName.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(14, 68);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(37, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "Value:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 46);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "Name:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(260, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "To define a new variable, enter a name and the value";
            // 
            // tmrVarDisable
            // 
            this.tmrVarDisable.Tick += new System.EventHandler(this.TmrVarDisableTick);
            // 
            // gbFunctions
            // 
            this.gbFunctions.Controls.Add(this.btnRemoveFunction);
            this.gbFunctions.Controls.Add(this.btnAddFunction);
            this.gbFunctions.Controls.Add(this.lbFunctions);
            this.gbFunctions.Controls.Add(this.txtFunctionValue);
            this.gbFunctions.Controls.Add(this.txtFunctionName);
            this.gbFunctions.Controls.Add(this.label6);
            this.gbFunctions.Controls.Add(this.label7);
            this.gbFunctions.Controls.Add(this.label8);
            this.gbFunctions.Location = new System.Drawing.Point(12, 249);
            this.gbFunctions.Name = "gbFunctions";
            this.gbFunctions.Size = new System.Drawing.Size(518, 124);
            this.gbFunctions.TabIndex = 8;
            this.gbFunctions.TabStop = false;
            this.gbFunctions.Text = "Custom Functions";
            this.gbFunctions.Paint += new System.Windows.Forms.PaintEventHandler(this.GbFunctionsPaint);
            // 
            // btnRemoveFunction
            // 
            this.btnRemoveFunction.Location = new System.Drawing.Point(337, 92);
            this.btnRemoveFunction.Name = "btnRemoveFunction";
            this.btnRemoveFunction.Size = new System.Drawing.Size(110, 23);
            this.btnRemoveFunction.TabIndex = 7;
            this.btnRemoveFunction.Text = "Remove Function(s)";
            this.btnRemoveFunction.UseVisualStyleBackColor = true;
            this.btnRemoveFunction.Click += new System.EventHandler(this.BtnRemoveFunctionClick);
            // 
            // btnAddFunction
            // 
            this.btnAddFunction.Location = new System.Drawing.Point(87, 92);
            this.btnAddFunction.Name = "btnAddFunction";
            this.btnAddFunction.Size = new System.Drawing.Size(83, 23);
            this.btnAddFunction.TabIndex = 6;
            this.btnAddFunction.Text = "Add Function";
            this.btnAddFunction.UseVisualStyleBackColor = true;
            this.btnAddFunction.Click += new System.EventHandler(this.BtnAddFunctionClick);
            // 
            // lbFunctions
            // 
            this.lbFunctions.FormattingEnabled = true;
            this.lbFunctions.Location = new System.Drawing.Point(288, 19);
            this.lbFunctions.Name = "lbFunctions";
            this.lbFunctions.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lbFunctions.Size = new System.Drawing.Size(222, 69);
            this.lbFunctions.TabIndex = 5;
            this.lbFunctions.MouseHover += new System.EventHandler(this.LbFunctionsMouseHover);
            // 
            // txtFunctionValue
            // 
            this.txtFunctionValue.Location = new System.Drawing.Point(54, 66);
            this.txtFunctionValue.Name = "txtFunctionValue";
            this.txtFunctionValue.Size = new System.Drawing.Size(169, 20);
            this.txtFunctionValue.TabIndex = 4;
            // 
            // txtFunctionName
            // 
            this.txtFunctionName.Location = new System.Drawing.Point(54, 43);
            this.txtFunctionName.Name = "txtFunctionName";
            this.txtFunctionName.Size = new System.Drawing.Size(169, 20);
            this.txtFunctionName.TabIndex = 3;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(14, 67);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(37, 13);
            this.label6.TabIndex = 2;
            this.label6.Text = "Value:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(13, 45);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(38, 13);
            this.label7.TabIndex = 1;
            this.label7.Text = "Name:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(10, 19);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(261, 13);
            this.label8.TabIndex = 0;
            this.label8.Text = "To define a new function, enter a name and the value";
            // 
            // tmrFuncDisable
            // 
            this.tmrFuncDisable.Tick += new System.EventHandler(this.TmrFuncDisableTick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgDelegates);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Location = new System.Drawing.Point(12, 395);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(518, 156);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Delegate Functions";
            // 
            // dgDelegates
            // 
            this.dgDelegates.AllowUserToAddRows = false;
            this.dgDelegates.AllowUserToDeleteRows = false;
            this.dgDelegates.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgDelegates.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgDelegates.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgDelegates.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgDelegates.Location = new System.Drawing.Point(19, 53);
            this.dgDelegates.Name = "dgDelegates";
            this.dgDelegates.ReadOnly = true;
            this.dgDelegates.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgDelegates.Size = new System.Drawing.Size(479, 93);
            this.dgDelegates.TabIndex = 1;
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(10, 17);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(482, 34);
            this.label9.TabIndex = 0;
            this.label9.Text = "Inside the source code for this demo, the following delegate functions have been " +
    "created. Click on Enable or Disable to enable or disable one or more of these de" +
    "legate functions:";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(540, 24);
            this.menuStrip1.TabIndex = 10;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(92, 22);
            this.exitToolStripMenuItem.Text = "E&xit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.ExitToolStripMenuItemClick);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "&Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.aboutToolStripMenuItem.Text = "&About...";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.AboutToolStripMenuItemClick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(540, 569);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.gbFunctions);
            this.Controls.Add(this.gbVariables);
            this.Controls.Add(this.gbEquations);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "MathParserNet Demo Application";
            this.Load += new System.EventHandler(this.MainFormLoad);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.MainFormPaint);
            this.gbEquations.ResumeLayout(false);
            this.gbEquations.PerformLayout();
            this.gbVariables.ResumeLayout(false);
            this.gbVariables.PerformLayout();
            this.gbFunctions.ResumeLayout(false);
            this.gbFunctions.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgDelegates)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtEquation;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSolve;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtAnswer;
        private System.Windows.Forms.GroupBox gbEquations;
        private System.Windows.Forms.GroupBox gbVariables;
        private System.Windows.Forms.TextBox txtVariableValue;
        private System.Windows.Forms.TextBox txtVariableName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListBox lbVariables;
        private System.Windows.Forms.Button btnAddVariable;
        private System.Windows.Forms.ToolTip ttVariables;
        private System.Windows.Forms.Button btnRemoveVariable;
        private System.Windows.Forms.Timer tmrVarDisable;
        private System.Windows.Forms.GroupBox gbFunctions;
        private System.Windows.Forms.Button btnRemoveFunction;
        private System.Windows.Forms.Button btnAddFunction;
        private System.Windows.Forms.ListBox lbFunctions;
        private System.Windows.Forms.TextBox txtFunctionValue;
        private System.Windows.Forms.TextBox txtFunctionName;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Timer tmrFuncDisable;
        private System.Windows.Forms.ToolTip ttFunctions;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DataGridView dgDelegates;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
    }
}

