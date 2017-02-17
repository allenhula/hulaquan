using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Image2String
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void browserBtn_Click(object sender, EventArgs e)
        {
            var fileDialog = new OpenFileDialog();
            fileDialog.Title = "Choose image file";
            fileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
            fileDialog.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png)|*.jpg;*.jpeg;*.jpe;*.jfif;*.png|All files (*.*)|*.*";
            fileDialog.RestoreDirectory = true;
            fileDialog.Multiselect = false;
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                var file = fileDialog.FileName;
                imgPathTxt.Text = file;

                try
                {
                    var fileBinary = File.ReadAllBytes(file);
                    imgStrTxt.Text = Convert.ToBase64String(fileBinary);
                }
                catch (Exception ex)
                {
                    imgStrTxt.Text = $"Something wrong with exception {ex.Message}";
                }
            }
        }
    }
}
