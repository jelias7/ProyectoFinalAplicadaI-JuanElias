namespace ProyectoFinalAplicadaI_JuanElias.SupermarketSoftware.Registros
{
    partial class rVentas
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
            this.IDnumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.ProductocomboBox = new System.Windows.Forms.ComboBox();
            this.Productobutton = new System.Windows.Forms.Button();
            this.ModocheckedListBox = new System.Windows.Forms.CheckedListBox();
            this.PreciotextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.DisponiblestextBox = new System.Windows.Forms.TextBox();
            this.CantidadnumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.FechadateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.DetalledataGridView = new System.Windows.Forms.DataGridView();
            this.Buscarbutton = new System.Windows.Forms.Button();
            this.Nuevobutton = new System.Windows.Forms.Button();
            this.Eliminarbutton = new System.Windows.Forms.Button();
            this.Guardarbutton = new System.Windows.Forms.Button();
            this.Removerbutton = new System.Windows.Forms.Button();
            this.Addbutton = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.ITBIStextBox = new System.Windows.Forms.TextBox();
            this.SubtotaltextBox = new System.Windows.Forms.TextBox();
            this.TotaltextBox = new System.Windows.Forms.TextBox();
            this.Clientebutton = new System.Windows.Forms.Button();
            this.ClientecomboBox = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.MyErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.IDnumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CantidadnumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DetalledataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MyErrorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // IDnumericUpDown
            // 
            this.IDnumericUpDown.Location = new System.Drawing.Point(101, 18);
            this.IDnumericUpDown.Name = "IDnumericUpDown";
            this.IDnumericUpDown.Size = new System.Drawing.Size(84, 20);
            this.IDnumericUpDown.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(18, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "ID";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 99);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Producto";
            // 
            // ProductocomboBox
            // 
            this.ProductocomboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ProductocomboBox.FormattingEnabled = true;
            this.ProductocomboBox.Location = new System.Drawing.Point(101, 99);
            this.ProductocomboBox.Name = "ProductocomboBox";
            this.ProductocomboBox.Size = new System.Drawing.Size(121, 21);
            this.ProductocomboBox.TabIndex = 3;
            // 
            // Productobutton
            // 
            this.Productobutton.BackColor = System.Drawing.Color.Teal;
            this.Productobutton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.Productobutton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Productobutton.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Productobutton.Location = new System.Drawing.Point(240, 99);
            this.Productobutton.Name = "Productobutton";
            this.Productobutton.Size = new System.Drawing.Size(62, 23);
            this.Productobutton.TabIndex = 4;
            this.Productobutton.Text = "+";
            this.Productobutton.UseVisualStyleBackColor = false;
            this.Productobutton.Click += new System.EventHandler(this.Productobutton_Click);
            // 
            // ModocheckedListBox
            // 
            this.ModocheckedListBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ModocheckedListBox.FormattingEnabled = true;
            this.ModocheckedListBox.Items.AddRange(new object[] {
            "Credito",
            "Contado"});
            this.ModocheckedListBox.Location = new System.Drawing.Point(242, 12);
            this.ModocheckedListBox.Name = "ModocheckedListBox";
            this.ModocheckedListBox.Size = new System.Drawing.Size(75, 30);
            this.ModocheckedListBox.TabIndex = 5;
            // 
            // PreciotextBox
            // 
            this.PreciotextBox.Location = new System.Drawing.Point(101, 138);
            this.PreciotextBox.Name = "PreciotextBox";
            this.PreciotextBox.ReadOnly = true;
            this.PreciotextBox.Size = new System.Drawing.Size(121, 20);
            this.PreciotextBox.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(25, 138);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Precio";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(25, 175);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Cantidad";
            // 
            // DisponiblestextBox
            // 
            this.DisponiblestextBox.Location = new System.Drawing.Point(240, 175);
            this.DisponiblestextBox.Name = "DisponiblestextBox";
            this.DisponiblestextBox.ReadOnly = true;
            this.DisponiblestextBox.Size = new System.Drawing.Size(62, 20);
            this.DisponiblestextBox.TabIndex = 11;
            // 
            // CantidadnumericUpDown
            // 
            this.CantidadnumericUpDown.Location = new System.Drawing.Point(101, 174);
            this.CantidadnumericUpDown.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.CantidadnumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.CantidadnumericUpDown.Name = "CantidadnumericUpDown";
            this.CantidadnumericUpDown.Size = new System.Drawing.Size(120, 20);
            this.CantidadnumericUpDown.TabIndex = 13;
            this.CantidadnumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // FechadateTimePicker
            // 
            this.FechadateTimePicker.CustomFormat = "dd/MM/yyyy";
            this.FechadateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.FechadateTimePicker.Location = new System.Drawing.Point(374, 14);
            this.FechadateTimePicker.Name = "FechadateTimePicker";
            this.FechadateTimePicker.Size = new System.Drawing.Size(96, 20);
            this.FechadateTimePicker.TabIndex = 14;
            // 
            // DetalledataGridView
            // 
            this.DetalledataGridView.AllowUserToAddRows = false;
            this.DetalledataGridView.AllowUserToDeleteRows = false;
            this.DetalledataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DetalledataGridView.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.DetalledataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DetalledataGridView.Location = new System.Drawing.Point(28, 213);
            this.DetalledataGridView.Name = "DetalledataGridView";
            this.DetalledataGridView.ReadOnly = true;
            this.DetalledataGridView.Size = new System.Drawing.Size(442, 205);
            this.DetalledataGridView.TabIndex = 15;
            // 
            // Buscarbutton
            // 
            this.Buscarbutton.Image = global::ProyectoFinalAplicadaI_JuanElias.Properties.Resources.loupe_78347;
            this.Buscarbutton.Location = new System.Drawing.Point(191, 8);
            this.Buscarbutton.Name = "Buscarbutton";
            this.Buscarbutton.Size = new System.Drawing.Size(45, 40);
            this.Buscarbutton.TabIndex = 21;
            this.Buscarbutton.UseVisualStyleBackColor = true;
            this.Buscarbutton.Click += new System.EventHandler(this.Buscarbutton_Click);
            // 
            // Nuevobutton
            // 
            this.Nuevobutton.Image = global::ProyectoFinalAplicadaI_JuanElias.Properties.Resources.controller_78338;
            this.Nuevobutton.Location = new System.Drawing.Point(28, 517);
            this.Nuevobutton.Name = "Nuevobutton";
            this.Nuevobutton.Size = new System.Drawing.Size(61, 65);
            this.Nuevobutton.TabIndex = 24;
            this.Nuevobutton.UseVisualStyleBackColor = true;
            this.Nuevobutton.Click += new System.EventHandler(this.Nuevobutton_Click);
            // 
            // Eliminarbutton
            // 
            this.Eliminarbutton.Image = global::ProyectoFinalAplicadaI_JuanElias.Properties.Resources.garbage_78344;
            this.Eliminarbutton.Location = new System.Drawing.Point(409, 517);
            this.Eliminarbutton.Name = "Eliminarbutton";
            this.Eliminarbutton.Size = new System.Drawing.Size(61, 65);
            this.Eliminarbutton.TabIndex = 23;
            this.Eliminarbutton.UseVisualStyleBackColor = true;
            this.Eliminarbutton.Click += new System.EventHandler(this.Eliminarbutton_Click);
            // 
            // Guardarbutton
            // 
            this.Guardarbutton.Image = global::ProyectoFinalAplicadaI_JuanElias.Properties.Resources.save_78348;
            this.Guardarbutton.Location = new System.Drawing.Point(217, 517);
            this.Guardarbutton.Name = "Guardarbutton";
            this.Guardarbutton.Size = new System.Drawing.Size(61, 65);
            this.Guardarbutton.TabIndex = 22;
            this.Guardarbutton.UseVisualStyleBackColor = true;
            this.Guardarbutton.Click += new System.EventHandler(this.Guardarbutton_Click);
            // 
            // Removerbutton
            // 
            this.Removerbutton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.Removerbutton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Removerbutton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Removerbutton.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.Removerbutton.Location = new System.Drawing.Point(28, 424);
            this.Removerbutton.Name = "Removerbutton";
            this.Removerbutton.Size = new System.Drawing.Size(132, 32);
            this.Removerbutton.TabIndex = 25;
            this.Removerbutton.Text = "- REMOVER FILA";
            this.Removerbutton.UseVisualStyleBackColor = false;
            // 
            // Addbutton
            // 
            this.Addbutton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.Addbutton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Addbutton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Addbutton.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.Addbutton.Location = new System.Drawing.Point(338, 175);
            this.Addbutton.Name = "Addbutton";
            this.Addbutton.Size = new System.Drawing.Size(132, 32);
            this.Addbutton.TabIndex = 26;
            this.Addbutton.Text = "+ AGREGAR";
            this.Addbutton.UseVisualStyleBackColor = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(299, 424);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(34, 13);
            this.label6.TabIndex = 27;
            this.label6.Text = "ITBIS";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(299, 453);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(64, 13);
            this.label7.TabIndex = 28;
            this.label7.Text = "SUBTOTAL";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(299, 482);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(42, 13);
            this.label8.TabIndex = 29;
            this.label8.Text = "TOTAL";
            // 
            // ITBIStextBox
            // 
            this.ITBIStextBox.Location = new System.Drawing.Point(374, 425);
            this.ITBIStextBox.Name = "ITBIStextBox";
            this.ITBIStextBox.ReadOnly = true;
            this.ITBIStextBox.Size = new System.Drawing.Size(96, 20);
            this.ITBIStextBox.TabIndex = 30;
            // 
            // SubtotaltextBox
            // 
            this.SubtotaltextBox.Location = new System.Drawing.Point(374, 453);
            this.SubtotaltextBox.Name = "SubtotaltextBox";
            this.SubtotaltextBox.ReadOnly = true;
            this.SubtotaltextBox.Size = new System.Drawing.Size(96, 20);
            this.SubtotaltextBox.TabIndex = 31;
            // 
            // TotaltextBox
            // 
            this.TotaltextBox.Location = new System.Drawing.Point(374, 482);
            this.TotaltextBox.Name = "TotaltextBox";
            this.TotaltextBox.ReadOnly = true;
            this.TotaltextBox.Size = new System.Drawing.Size(96, 20);
            this.TotaltextBox.TabIndex = 32;
            // 
            // Clientebutton
            // 
            this.Clientebutton.BackColor = System.Drawing.Color.Teal;
            this.Clientebutton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.Clientebutton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Clientebutton.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Clientebutton.Location = new System.Drawing.Point(240, 60);
            this.Clientebutton.Name = "Clientebutton";
            this.Clientebutton.Size = new System.Drawing.Size(62, 23);
            this.Clientebutton.TabIndex = 35;
            this.Clientebutton.Text = "+";
            this.Clientebutton.UseVisualStyleBackColor = false;
            this.Clientebutton.Click += new System.EventHandler(this.Clientebutton_Click);
            // 
            // ClientecomboBox
            // 
            this.ClientecomboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ClientecomboBox.FormattingEnabled = true;
            this.ClientecomboBox.Location = new System.Drawing.Point(101, 60);
            this.ClientecomboBox.Name = "ClientecomboBox";
            this.ClientecomboBox.Size = new System.Drawing.Size(121, 21);
            this.ClientecomboBox.TabIndex = 34;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(25, 60);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 13);
            this.label3.TabIndex = 33;
            this.label3.Text = "Cliente";
            // 
            // MyErrorProvider
            // 
            this.MyErrorProvider.ContainerControl = this;
            // 
            // rVentas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(497, 592);
            this.Controls.Add(this.Clientebutton);
            this.Controls.Add(this.ClientecomboBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.TotaltextBox);
            this.Controls.Add(this.SubtotaltextBox);
            this.Controls.Add(this.ITBIStextBox);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.Addbutton);
            this.Controls.Add(this.Removerbutton);
            this.Controls.Add(this.Nuevobutton);
            this.Controls.Add(this.Eliminarbutton);
            this.Controls.Add(this.Guardarbutton);
            this.Controls.Add(this.Buscarbutton);
            this.Controls.Add(this.DetalledataGridView);
            this.Controls.Add(this.FechadateTimePicker);
            this.Controls.Add(this.CantidadnumericUpDown);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.DisponiblestextBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.PreciotextBox);
            this.Controls.Add(this.ModocheckedListBox);
            this.Controls.Add(this.Productobutton);
            this.Controls.Add(this.ProductocomboBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.IDnumericUpDown);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "rVentas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Venta de Producto";
            ((System.ComponentModel.ISupportInitialize)(this.IDnumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CantidadnumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DetalledataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MyErrorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown IDnumericUpDown;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox ProductocomboBox;
        private System.Windows.Forms.Button Productobutton;
        private System.Windows.Forms.CheckedListBox ModocheckedListBox;
        private System.Windows.Forms.TextBox PreciotextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox DisponiblestextBox;
        private System.Windows.Forms.NumericUpDown CantidadnumericUpDown;
        private System.Windows.Forms.DateTimePicker FechadateTimePicker;
        private System.Windows.Forms.DataGridView DetalledataGridView;
        private System.Windows.Forms.Button Buscarbutton;
        private System.Windows.Forms.Button Nuevobutton;
        private System.Windows.Forms.Button Eliminarbutton;
        private System.Windows.Forms.Button Guardarbutton;
        private System.Windows.Forms.Button Removerbutton;
        private System.Windows.Forms.Button Addbutton;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox ITBIStextBox;
        private System.Windows.Forms.TextBox SubtotaltextBox;
        private System.Windows.Forms.TextBox TotaltextBox;
        private System.Windows.Forms.Button Clientebutton;
        private System.Windows.Forms.ComboBox ClientecomboBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ErrorProvider MyErrorProvider;
    }
}