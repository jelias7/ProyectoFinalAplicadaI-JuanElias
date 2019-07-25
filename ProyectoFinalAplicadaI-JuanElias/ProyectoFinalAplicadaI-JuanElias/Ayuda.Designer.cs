namespace ProyectoFinalAplicadaI_JuanElias
{
    partial class Ayuda
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Ayuda));
            this.AyudarichTextBox = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // AyudarichTextBox
            // 
            this.AyudarichTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AyudarichTextBox.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AyudarichTextBox.Location = new System.Drawing.Point(0, 0);
            this.AyudarichTextBox.Name = "AyudarichTextBox";
            this.AyudarichTextBox.ReadOnly = true;
            this.AyudarichTextBox.Size = new System.Drawing.Size(773, 114);
            this.AyudarichTextBox.TabIndex = 0;
            this.AyudarichTextBox.Text = resources.GetString("AyudarichTextBox.Text");
            // 
            // Ayuda
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(773, 114);
            this.Controls.Add(this.AyudarichTextBox);
            this.Cursor = System.Windows.Forms.Cursors.Help;
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Ayuda";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Informacion";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox AyudarichTextBox;
    }
}