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
            this.nUDAlarmMax = new System.Windows.Forms.NumericUpDown();
            this.nUDAlarmMin = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btSave = new System.Windows.Forms.Button();
            this.btUpload = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.btLogin = new System.Windows.Forms.Button();
            this.txtBPasswordLogin = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtBUsernameLogin = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.btSaveUser = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.nUpDoAccess = new System.Windows.Forms.NumericUpDown();
            this.txtBPassword = new System.Windows.Forms.TextBox();
            this.txtBUsername = new System.Windows.Forms.TextBox();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.btDelete = new System.Windows.Forms.Button();
            this.btRead = new System.Windows.Forms.Button();
            this.gridUser = new System.Windows.Forms.DataGridView();
            this.labUsername = new System.Windows.Forms.Label();
            this.labAccess = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUDMin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUDMax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUDId)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUDAlarmMax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUDAlarmMin)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage5.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nUpDoAccess)).BeginInit();
            this.tabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridUser)).BeginInit();
            this.SuspendLayout();
            // 
            // grid
            // 
            this.grid.AllowUserToAddRows = false;
            this.grid.AllowUserToDeleteRows = false;
            this.grid.AllowUserToResizeColumns = false;
            this.grid.AllowUserToResizeRows = false;
            this.grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grid.Location = new System.Drawing.Point(7, 6);
            this.grid.Name = "grid";
            this.grid.ReadOnly = true;
            this.grid.RowHeadersVisible = false;
            this.grid.Size = new System.Drawing.Size(640, 322);
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
            this.btStart.Location = new System.Drawing.Point(682, 48);
            this.btStart.Name = "btStart";
            this.btStart.Size = new System.Drawing.Size(137, 42);
            this.btStart.TabIndex = 1;
            this.btStart.Text = "Démarrer";
            this.btStart.UseVisualStyleBackColor = true;
            this.btStart.Click += new System.EventHandler(this.btStart_Click);
            // 
            // btStop
            // 
            this.btStop.Location = new System.Drawing.Point(875, 48);
            this.btStop.Name = "btStop";
            this.btStop.Size = new System.Drawing.Size(137, 42);
            this.btStop.TabIndex = 2;
            this.btStop.Text = "Arrêter";
            this.btStop.UseVisualStyleBackColor = true;
            this.btStop.Click += new System.EventHandler(this.btStop_Click);
            // 
            // btLeave
            // 
            this.btLeave.Location = new System.Drawing.Point(682, 310);
            this.btLeave.Name = "btLeave";
            this.btLeave.Size = new System.Drawing.Size(119, 65);
            this.btLeave.TabIndex = 3;
            this.btLeave.Text = "Quitter";
            this.btLeave.UseVisualStyleBackColor = true;
            this.btLeave.Click += new System.EventHandler(this.btLeave_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(679, 107);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Intervalle Min";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(872, 107);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Intervalle Max";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(679, 143);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(16, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Id";
            // 
            // btConversing
            // 
            this.btConversing.Enabled = false;
            this.btConversing.Location = new System.Drawing.Point(682, 225);
            this.btConversing.Name = "btConversing";
            this.btConversing.Size = new System.Drawing.Size(330, 37);
            this.btConversing.TabIndex = 10;
            this.btConversing.Text = "Ajouter les configurations";
            this.btConversing.UseVisualStyleBackColor = true;
            this.btConversing.Click += new System.EventHandler(this.btConversing_Click);
            // 
            // nUDMin
            // 
            this.nUDMin.Location = new System.Drawing.Point(755, 105);
            this.nUDMin.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nUDMin.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            -2147483648});
            this.nUDMin.Name = "nUDMin";
            this.nUDMin.Size = new System.Drawing.Size(64, 20);
            this.nUDMin.TabIndex = 11;
            // 
            // nUDMax
            // 
            this.nUDMax.Location = new System.Drawing.Point(948, 105);
            this.nUDMax.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nUDMax.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            -2147483648});
            this.nUDMax.Name = "nUDMax";
            this.nUDMax.Size = new System.Drawing.Size(64, 20);
            this.nUDMax.TabIndex = 12;
            // 
            // nUDId
            // 
            this.nUDId.Location = new System.Drawing.Point(755, 141);
            this.nUDId.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nUDId.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nUDId.Name = "nUDId";
            this.nUDId.Size = new System.Drawing.Size(64, 20);
            this.nUDId.TabIndex = 13;
            this.nUDId.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // nUDAlarmMax
            // 
            this.nUDAlarmMax.Location = new System.Drawing.Point(948, 177);
            this.nUDAlarmMax.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nUDAlarmMax.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            -2147483648});
            this.nUDAlarmMax.Name = "nUDAlarmMax";
            this.nUDAlarmMax.Size = new System.Drawing.Size(64, 20);
            this.nUDAlarmMax.TabIndex = 17;
            // 
            // nUDAlarmMin
            // 
            this.nUDAlarmMin.Location = new System.Drawing.Point(755, 177);
            this.nUDAlarmMin.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nUDAlarmMin.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            -2147483648});
            this.nUDAlarmMin.Name = "nUDAlarmMin";
            this.nUDAlarmMin.Size = new System.Drawing.Size(64, 20);
            this.nUDAlarmMin.TabIndex = 16;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(872, 179);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 13);
            this.label4.TabIndex = 15;
            this.label4.Text = "Alarme Max";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(679, 179);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 13);
            this.label5.TabIndex = 14;
            this.label5.Text = "Alarme Min";
            // 
            // btSave
            // 
            this.btSave.Location = new System.Drawing.Point(12, 369);
            this.btSave.Name = "btSave";
            this.btSave.Size = new System.Drawing.Size(79, 47);
            this.btSave.TabIndex = 19;
            this.btSave.Text = "Sauvegarder";
            this.btSave.UseVisualStyleBackColor = true;
            this.btSave.Click += new System.EventHandler(this.btSave_Click);
            // 
            // btUpload
            // 
            this.btUpload.Location = new System.Drawing.Point(117, 369);
            this.btUpload.Name = "btUpload";
            this.btUpload.Size = new System.Drawing.Size(79, 47);
            this.btUpload.TabIndex = 20;
            this.btUpload.Text = "Charger";
            this.btUpload.UseVisualStyleBackColor = true;
            this.btUpload.Click += new System.EventHandler(this.btUpload_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(117, 369);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(79, 47);
            this.button2.TabIndex = 20;
            this.button2.Text = "Charger";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 369);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(79, 47);
            this.button1.TabIndex = 19;
            this.button1.Text = "Sauvegarder";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.btSave_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage5);
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Location = new System.Drawing.Point(12, 3);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(661, 360);
            this.tabControl1.TabIndex = 21;
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.btLogin);
            this.tabPage5.Controls.Add(this.txtBPasswordLogin);
            this.tabPage5.Controls.Add(this.label10);
            this.tabPage5.Controls.Add(this.txtBUsernameLogin);
            this.tabPage5.Controls.Add(this.label9);
            this.tabPage5.Location = new System.Drawing.Point(4, 22);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage5.Size = new System.Drawing.Size(653, 334);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "Connexion";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // btLogin
            // 
            this.btLogin.Location = new System.Drawing.Point(195, 141);
            this.btLogin.Name = "btLogin";
            this.btLogin.Size = new System.Drawing.Size(118, 38);
            this.btLogin.TabIndex = 4;
            this.btLogin.Text = "Connexion";
            this.btLogin.UseVisualStyleBackColor = true;
            this.btLogin.Click += new System.EventHandler(this.btLogin_Click);
            // 
            // txtBPasswordLogin
            // 
            this.txtBPasswordLogin.Location = new System.Drawing.Point(255, 99);
            this.txtBPasswordLogin.Name = "txtBPasswordLogin";
            this.txtBPasswordLogin.Size = new System.Drawing.Size(100, 20);
            this.txtBPasswordLogin.TabIndex = 3;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(160, 102);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(74, 13);
            this.label10.TabIndex = 2;
            this.label10.Text = "Mot de passe:";
            // 
            // txtBUsernameLogin
            // 
            this.txtBUsernameLogin.Location = new System.Drawing.Point(255, 49);
            this.txtBUsernameLogin.Name = "txtBUsernameLogin";
            this.txtBUsernameLogin.Size = new System.Drawing.Size(100, 20);
            this.txtBUsernameLogin.TabIndex = 1;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(144, 52);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(87, 13);
            this.label9.TabIndex = 0;
            this.label9.Text = "Nom d\'utilisateur:";
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.grid);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(653, 334);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Donnée";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(653, 334);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Graphique";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.btSaveUser);
            this.tabPage3.Controls.Add(this.label8);
            this.tabPage3.Controls.Add(this.label7);
            this.tabPage3.Controls.Add(this.label6);
            this.tabPage3.Controls.Add(this.nUpDoAccess);
            this.tabPage3.Controls.Add(this.txtBPassword);
            this.tabPage3.Controls.Add(this.txtBUsername);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(653, 334);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Ajouter utilisateur";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // btSaveUser
            // 
            this.btSaveUser.Location = new System.Drawing.Point(284, 207);
            this.btSaveUser.Name = "btSaveUser";
            this.btSaveUser.Size = new System.Drawing.Size(126, 38);
            this.btSaveUser.TabIndex = 22;
            this.btSaveUser.Text = "Ajouter l\'utilisateur";
            this.btSaveUser.UseVisualStyleBackColor = true;
            this.btSaveUser.Click += new System.EventHandler(this.btSaveUser_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(246, 154);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(40, 13);
            this.label8.TabIndex = 21;
            this.label8.Text = "Acces:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(212, 105);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(74, 13);
            this.label7.TabIndex = 20;
            this.label7.Text = "Mot de passe:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(199, 61);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(87, 13);
            this.label6.TabIndex = 19;
            this.label6.Text = "Nom d\'utilisateur:";
            // 
            // nUpDoAccess
            // 
            this.nUpDoAccess.Location = new System.Drawing.Point(346, 152);
            this.nUpDoAccess.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.nUpDoAccess.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nUpDoAccess.Name = "nUpDoAccess";
            this.nUpDoAccess.Size = new System.Drawing.Size(64, 20);
            this.nUpDoAccess.TabIndex = 18;
            this.nUpDoAccess.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // txtBPassword
            // 
            this.txtBPassword.Location = new System.Drawing.Point(310, 105);
            this.txtBPassword.Name = "txtBPassword";
            this.txtBPassword.Size = new System.Drawing.Size(100, 20);
            this.txtBPassword.TabIndex = 1;
            // 
            // txtBUsername
            // 
            this.txtBUsername.Location = new System.Drawing.Point(310, 58);
            this.txtBUsername.Name = "txtBUsername";
            this.txtBUsername.Size = new System.Drawing.Size(100, 20);
            this.txtBUsername.TabIndex = 0;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.btDelete);
            this.tabPage4.Controls.Add(this.btRead);
            this.tabPage4.Controls.Add(this.gridUser);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(653, 334);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Liste utilisateur";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // btDelete
            // 
            this.btDelete.Location = new System.Drawing.Point(423, 89);
            this.btDelete.Name = "btDelete";
            this.btDelete.Size = new System.Drawing.Size(126, 42);
            this.btDelete.TabIndex = 2;
            this.btDelete.Text = "Supprimer";
            this.btDelete.UseVisualStyleBackColor = true;
            this.btDelete.Click += new System.EventHandler(this.btDelete_Click);
            // 
            // btRead
            // 
            this.btRead.Location = new System.Drawing.Point(423, 6);
            this.btRead.Name = "btRead";
            this.btRead.Size = new System.Drawing.Size(126, 42);
            this.btRead.TabIndex = 1;
            this.btRead.Text = "Lire";
            this.btRead.UseVisualStyleBackColor = true;
            this.btRead.Click += new System.EventHandler(this.btRead_Click);
            // 
            // gridUser
            // 
            this.gridUser.AllowUserToAddRows = false;
            this.gridUser.AllowUserToDeleteRows = false;
            this.gridUser.AllowUserToResizeColumns = false;
            this.gridUser.AllowUserToResizeRows = false;
            this.gridUser.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridUser.Location = new System.Drawing.Point(6, 6);
            this.gridUser.MultiSelect = false;
            this.gridUser.Name = "gridUser";
            this.gridUser.ReadOnly = true;
            this.gridUser.RowHeadersVisible = false;
            this.gridUser.Size = new System.Drawing.Size(411, 325);
            this.gridUser.TabIndex = 0;
            // 
            // labUsername
            // 
            this.labUsername.AutoSize = true;
            this.labUsername.Location = new System.Drawing.Point(939, 310);
            this.labUsername.Name = "labUsername";
            this.labUsername.Size = new System.Drawing.Size(73, 13);
            this.labUsername.TabIndex = 22;
            this.labUsername.Text = "Pas connecté";
            // 
            // labAccess
            // 
            this.labAccess.AutoSize = true;
            this.labAccess.Location = new System.Drawing.Point(939, 336);
            this.labAccess.Name = "labAccess";
            this.labAccess.Size = new System.Drawing.Size(96, 13);
            this.labAccess.TabIndex = 23;
            this.labAccess.Text = "Acces de niveau 5";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1084, 439);
            this.Controls.Add(this.labAccess);
            this.Controls.Add(this.labUsername);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.btUpload);
            this.Controls.Add(this.btSave);
            this.Controls.Add(this.nUDAlarmMax);
            this.Controls.Add(this.nUDAlarmMin);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
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
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUDMin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUDMax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUDId)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUDAlarmMax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUDAlarmMin)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage5.ResumeLayout(false);
            this.tabPage5.PerformLayout();
            this.tabPage1.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nUpDoAccess)).EndInit();
            this.tabPage4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridUser)).EndInit();
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
        private System.Windows.Forms.NumericUpDown nUDAlarmMax;
        private System.Windows.Forms.NumericUpDown nUDAlarmMin;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btSave;
        private System.Windows.Forms.Button btUpload;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown nUpDoAccess;
        private System.Windows.Forms.TextBox txtBPassword;
        private System.Windows.Forms.TextBox txtBUsername;
        private System.Windows.Forms.Button btSaveUser;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.DataGridView gridUser;
        private System.Windows.Forms.Button btDelete;
        private System.Windows.Forms.Button btRead;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.TextBox txtBPasswordLogin;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtBUsernameLogin;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btLogin;
        private System.Windows.Forms.Label labUsername;
        private System.Windows.Forms.Label labAccess;
    }
}

