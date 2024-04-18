using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.IO;



namespace Project
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            printDocument1.DefaultPageSettings.Landscape = true;
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try 
                {
                    if (pictureBox1.BackColor == Color.BlueViolet)
                        pictureBox1.Image = Image.FromFile(openFileDialog1.FileName);
                    else if (pictureBox2.BackColor == Color.BlueViolet)
                        pictureBox2.Image = Image.FromFile(openFileDialog1.FileName);
                    else if (pictureBox3.BackColor == Color.BlueViolet)
                        pictureBox3.Image = Image.FromFile(openFileDialog1.FileName);
                    else if (pictureBox4.BackColor == Color.BlueViolet)
                        pictureBox4.Image = Image.FromFile(openFileDialog1.FileName);


                }
                catch(Exception ex)
                {
                   MessageBox.Show(ex.Message);
                }
            }
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            pictureBox4.BackColor = Color.BlueViolet;
            pictureBox2.BackColor = Color.WhiteSmoke;
            pictureBox3.BackColor = Color.WhiteSmoke;
            pictureBox1.BackColor = Color.WhiteSmoke;
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            pictureBox3.BackColor = Color.BlueViolet;
            pictureBox2.BackColor = Color.WhiteSmoke;
            pictureBox1.BackColor = Color.WhiteSmoke;
            pictureBox4.BackColor = Color.WhiteSmoke;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            pictureBox2.BackColor = Color.BlueViolet;
            pictureBox1.BackColor = Color.WhiteSmoke;
            pictureBox3.BackColor = Color.WhiteSmoke;
            pictureBox4.BackColor = Color.WhiteSmoke;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            pictureBox1.BackColor = Color.BlueViolet;
            pictureBox2.BackColor = Color.WhiteSmoke;
            pictureBox3.BackColor = Color.WhiteSmoke;
            pictureBox4.BackColor = Color.WhiteSmoke;

        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (printDialog1.ShowDialog() == DialogResult.OK)
                try
                {
                    printDocument1.Print();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
               

        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            using (Bitmap imgToPrint = new Bitmap(tableLayoutPanel1.Width, tableLayoutPanel1.Height))
            {
                tableLayoutPanel1.DrawToBitmap(imgToPrint, 
                    new Rectangle(0, 0, imgToPrint.Width,
                    imgToPrint.Height));
                e.Graphics.DrawImage(imgToPrint, 10, 10);

            }
        }

        private void btnPrintPreview_Click(object sender, EventArgs e)
        {
            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.ShowDialog();
        }

        private void btnDownload_Click(object sender, EventArgs e)
        {
            if (Uri.TryCreate(txtURL.Text, UriKind.Absolute, out Uri URI))
            {
                string ext = Path.GetExtension(txtURL.Text).ToLower();
                if (ext == ".jpg" || ext == ".jpeg" || ext == ".png" || ext == ".tiff")
                {
                    if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                    {
                        using (WebClient client = new WebClient())
                        {
                            try
                            {
                                client.DownloadFile(URI, saveFileDialog1.FileName);
                                MessageBox.Show("File downloaded successfully.");
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("Error downloading file: " + ex.Message);
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Unsupported file type. Please provide a URL to an image file with extensions .jpg, .jpeg, .png, or .tiff.");
                }
            }
            else
            {
                MessageBox.Show("Invalid URL Address");
            }
        }
    }
}
