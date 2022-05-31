﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZXing;
using ZXing.Common;
using ZXing.QrCode;
using ZXing.Rendering;

namespace VKR_Sklad
{
    public partial class Barcode_creator : Form
    {
        public Barcode_creator(object id)
        {
            InitializeComponent();
            comboBox_name.DropDownStyle = ComboBoxStyle.DropDown;
        }

        public static Image CreateCode(string text, int w, int h, BarcodeFormat format)
        {

            try
            {

                BarcodeWriter writer = new BarcodeWriter
                {
                    Format = format,
                    Options = new QrCodeEncodingOptions
                    {
                        Width = w,
                        Height = h,
                        CharacterSet = "UTF-8"
                    },
                    Renderer = new BitmapRenderer()
                };
                return writer.Write(text);
            }
            catch (Exception ex) { }

            return null;
        }
        public static string[] CodeScan(Bitmap bmp)
        {           

            try
            {
                BarcodeReader reader = new BarcodeReader
                {
                    AutoRotate = true,
                    TryInverted = true,
                    Options = new DecodingOptions
                    {
                        TryHarder = true
                    }
                };

                Result[] results = reader.DecodeMultiple(bmp);

                if (results != null)
                    return results.Where(x => x != null && !string.IsNullOrEmpty(x.Text)).Select(x => x.Text).ToArray();
            }
            catch (Exception) { }

            return null;
        }
        public static string DecodeImage(Image img)
        {

            string outString = "";

            string[] results = CodeScan((Bitmap)img);

            if (results != null)
                outString = string.Join(Environment.NewLine + Environment.NewLine, results);

            return outString;
        }
        private BarcodeFormat GetFormat()
        {

            switch (comboBox_name.Text)
            {
                case "CODEBAR": return BarcodeFormat.CODABAR;
                case "CODE_39": return BarcodeFormat.CODE_39;
                case "CODE_93": return BarcodeFormat.CODE_93;
                case "CODE_128": return BarcodeFormat.CODE_128;
                case "QR_CODE": return BarcodeFormat.QR_CODE;
                case "MSI": return BarcodeFormat.MSI;
                case "DATA_MATRIX": return BarcodeFormat.DATA_MATRIX;
                default: return BarcodeFormat.CODABAR;
            }
        }

        private void but_download_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dialog = openFileDialog1.ShowDialog();

                if (dialog == DialogResult.OK)
                    pictureBox_barcode.Image = Image.FromFile(openFileDialog1.FileName);
            }
            catch (Exception ex) { }
        }

        private void but_decipher_Click(object sender, EventArgs e)
        {
            try
            {
                MessageBox.Show(DecodeImage(pictureBox_barcode.Image));
            }
            catch (Exception ex) { }
        }

        private void but_save_Click(object sender, EventArgs e)
        {
            try
            {
                saveFileDialog1.FileName = "img.png";

                DialogResult dialog = saveFileDialog1.ShowDialog();

                if (dialog == DialogResult.OK)
                    pictureBox_barcode.Image.Save(saveFileDialog1.FileName);
            }
            catch (Exception ex) { }
        }

        private void textBox_name_TextChanged(object sender, EventArgs e)
        {
            pictureBox_barcode.Image = CreateCode(textBox_name.Text, pictureBox_barcode.Width, pictureBox_barcode.Height, GetFormat());
        }
    }
}
