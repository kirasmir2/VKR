namespace VKR_Sklad
{
    partial class Barcode_creator
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
            this.pictureBox_barcode = new System.Windows.Forms.PictureBox();
            this.textBox_name = new System.Windows.Forms.TextBox();
            this.comboBox_name = new System.Windows.Forms.ComboBox();
            this.but_save = new System.Windows.Forms.Button();
            this.but_decipher = new System.Windows.Forms.Button();
            this.but_download = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_barcode)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox_barcode
            // 
            this.pictureBox_barcode.Location = new System.Drawing.Point(11, 59);
            this.pictureBox_barcode.Name = "pictureBox_barcode";
            this.pictureBox_barcode.Size = new System.Drawing.Size(140, 136);
            this.pictureBox_barcode.TabIndex = 0;
            this.pictureBox_barcode.TabStop = false;
            // 
            // textBox_name
            // 
            this.textBox_name.Location = new System.Drawing.Point(8, 33);
            this.textBox_name.Multiline = true;
            this.textBox_name.Name = "textBox_name";
            this.textBox_name.Size = new System.Drawing.Size(270, 20);
            this.textBox_name.TabIndex = 1;
            this.textBox_name.TextChanged += new System.EventHandler(this.textBox_name_TextChanged);
            // 
            // comboBox_name
            // 
            this.comboBox_name.FormattingEnabled = true;
            this.comboBox_name.Items.AddRange(new object[] {
            "CODEBAR",
            "CODE_39",
            "CODE_93",
            "CODE_128",
            "QR_CODE",
            "MSI",
            "DATA_MATRIX"});
            this.comboBox_name.Location = new System.Drawing.Point(157, 59);
            this.comboBox_name.Name = "comboBox_name";
            this.comboBox_name.Size = new System.Drawing.Size(121, 21);
            this.comboBox_name.TabIndex = 2;
            this.comboBox_name.Text = "CODEBAR";
            // 
            // but_save
            // 
            this.but_save.BackColor = System.Drawing.Color.Transparent;
            this.but_save.ForeColor = System.Drawing.Color.Black;
            this.but_save.Location = new System.Drawing.Point(157, 86);
            this.but_save.Name = "but_save";
            this.but_save.Size = new System.Drawing.Size(98, 23);
            this.but_save.TabIndex = 3;
            this.but_save.Text = "Сохранить";
            this.but_save.UseVisualStyleBackColor = false;
            this.but_save.Click += new System.EventHandler(this.but_save_Click);
            // 
            // but_decipher
            // 
            this.but_decipher.Location = new System.Drawing.Point(156, 115);
            this.but_decipher.Name = "but_decipher";
            this.but_decipher.Size = new System.Drawing.Size(99, 23);
            this.but_decipher.TabIndex = 4;
            this.but_decipher.Text = "Расшифровать";
            this.but_decipher.UseVisualStyleBackColor = true;
            this.but_decipher.Click += new System.EventHandler(this.but_decipher_Click);
            // 
            // but_download
            // 
            this.but_download.Location = new System.Drawing.Point(156, 144);
            this.but_download.Name = "but_download";
            this.but_download.Size = new System.Drawing.Size(99, 23);
            this.but_download.TabIndex = 5;
            this.but_download.Text = "Загрузить";
            this.but_download.UseVisualStyleBackColor = true;
            this.but_download.Click += new System.EventHandler(this.but_download_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 8.25F);
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(13, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 14);
            this.label1.TabIndex = 6;
            this.label1.Text = "Введите данные:";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(157, 173);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(98, 23);
            this.button1.TabIndex = 7;
            this.button1.Text = "Выход";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Barcode_creator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(290, 203);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.but_download);
            this.Controls.Add(this.but_decipher);
            this.Controls.Add(this.but_save);
            this.Controls.Add(this.comboBox_name);
            this.Controls.Add(this.textBox_name);
            this.Controls.Add(this.pictureBox_barcode);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Barcode_creator";
            this.Text = "Генератор штрихкодов";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_barcode)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox_barcode;
        private System.Windows.Forms.TextBox textBox_name;
        private System.Windows.Forms.ComboBox comboBox_name;
        private System.Windows.Forms.Button but_save;
        private System.Windows.Forms.Button but_decipher;
        private System.Windows.Forms.Button but_download;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
    }
}