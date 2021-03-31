namespace WindowsFormsApp5
{
    partial class Form1
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.grid = new System.Windows.Forms.DataGridView();
            this.port = new System.IO.Ports.SerialPort(this.components);
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.btStart = new System.Windows.Forms.Button();
            this.btStop = new System.Windows.Forms.Button();
            this.btLeave = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btConversing = new System.Windows.Forms.Button();
            this.nUDMin = new System.Windows.Forms.NumericUpDown();
            this.nUDMax = new System.Windows.Forms.NumericUpDown();
            this.nUDId = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUDMin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUDMax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUDId)).BeginInit();
            this.SuspendLayout();
            // 
            // grid
            // 
            this.grid.AllowUserToAddRows = false;
            this.grid.AllowUserToDeleteRows = false;
            this.grid.AllowUserToResizeColumns = false;
            this.grid.AllowUserToResizeRows = false;
            this.grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grid.Location = new System.Drawing.Point(12, 48);
            this.grid.Name = "grid";
            this.grid.RowHeadersVisible = false;
            this.grid.Size = new System.Drawing.Size(519, 294);
            this.grid.TabIndex = 1;
            // 
            // port
            // 
            this.port.PortName = "COM2";
            this.port.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.port_DataReceived);
            // 
            // timer
            // 
            this.timer.Interval = 1000;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // btStart
            // 
            this.btStart.Location = new System.Drawing.Point(580, 48);
            this.btStart.Name = "btStart";
            this.btStart.Size = new System.Drawing.Size(64, 42);
            this.btStart.TabIndex = 1;
            this.btStart.Text = "Start";
            this.btStart.UseVisualStyleBackColor = true;
            this.btStart.Click += new System.EventHandler(this.btStart_Click);
            // 
            // btStop
            // 
            this.btStop.Location = new System.Drawing.Point(669, 48);
            this.btStop.Name = "btStop";
            this.btStop.Size = new System.Drawing.Size(64, 42);
            this.btStop.TabIndex = 2;
            this.btStop.Text = "Stop";
            this.btStop.UseVisualStyleBackColor = true;
            this.btStop.Click += new System.EventHandler(this.btStop_Click);
            // 
            // btLeave
            // 
            this.btLeave.Location = new System.Drawing.Point(669, 373);
            this.btLeave.Name = "btLeave";
            this.btLeave.Size = new System.Drawing.Size(119, 65);
            this.btLeave.TabIndex = 3;
            this.btLeave.Text = "Leave";
            this.btLeave.UseVisualStyleBackColor = true;
            this.btLeave.Click += new System.EventHandler(this.btLeave_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(617, 117);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(24, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Min";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(617, 150);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(27, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Max";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(617, 176);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(16, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Id";
            // 
            // btConversing
            // 
            this.btConversing.Location = new System.Drawing.Point(620, 225);
            this.btConversing.Name = "btConversing";
            this.btConversing.Size = new System.Drawing.Size(113, 37);
            this.btConversing.TabIndex = 10;
            this.btConversing.Text = "conversing";
            this.btConversing.UseVisualStyleBackColor = true;
            this.btConversing.Click += new System.EventHandler(this.btConversing_Click);
            // 
            // nUDMin
            // 
            this.nUDMin.Location = new System.Drawing.Point(669, 115);
            this.nUDMin.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nUDMin.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
            this.nUDMin.Name = "nUDMin";
            this.nUDMin.Size = new System.Drawing.Size(64, 20);
            this.nUDMin.TabIndex = 11;
            // 
            // nUDMax
            // 
            this.nUDMax.Location = new System.Drawing.Point(669, 143);
            this.nUDMax.Name = "nUDMax";
            this.nUDMax.Size = new System.Drawing.Size(64, 20);
            this.nUDMax.TabIndex = 12;
            // 
            // nUDId
            // 
            this.nUDId.Location = new System.Drawing.Point(669, 169);
            this.nUDId.Name = "nUDId";
            this.nUDId.Size = new System.Drawing.Size(64, 20);
            this.nUDId.TabIndex = 13;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.nUDId);
            this.Controls.Add(this.nUDMax);
            this.Controls.Add(this.nUDMin);
            this.Controls.Add(this.btConversing);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btLeave);
            this.Controls.Add(this.btStop);
            this.Controls.Add(this.btStart);
            this.Controls.Add(this.grid);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUDMin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUDMax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUDId)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView grid;
        private System.IO.Ports.SerialPort port;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.Button btStart;
        private System.Windows.Forms.Button btStop;
        private System.Windows.Forms.Button btLeave;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btConversing;
        private System.Windows.Forms.NumericUpDown nUDMin;
        private System.Windows.Forms.NumericUpDown nUDMax;
        private System.Windows.Forms.NumericUpDown nUDId;
    }
}

