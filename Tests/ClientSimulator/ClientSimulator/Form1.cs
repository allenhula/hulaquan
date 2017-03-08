using IdentityModel.Client;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClientSimulator
{
    public partial class Form1 : Form
    {
        private List<Image> images;

        public Form1()
        {
            InitializeComponent();
            images = new List<Image>();
        }

        private void sBtn_Click(object sender, EventArgs e)
        {
            images.Clear();
            iTxt.Clear();

            var fileDialog = new OpenFileDialog();
            fileDialog.Title = "Choose image file";
            fileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
            fileDialog.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png)|*.jpg;*.jpeg;*.jpe;*.jfif;*.png|All files (*.*)|*.*";
            fileDialog.RestoreDirectory = true;
            fileDialog.Multiselect = true;
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                foreach (var file in fileDialog.FileNames)
                {
                    iTxt.AppendText(file);
                    iTxt.AppendText("\n");
                    try
                    {
                        var fileBinary = File.ReadAllBytes(file);
                        images.Add(new Image() {
                            FileName = file.Split('\\').Last(),
                            Base64Data = Convert.ToBase64String(fileBinary)
                        });
                    }
                    catch (Exception ex)
                    {
                        rTxt.Text = $"Something wrong with exception {ex.Message}";
                    }
                }             
            }
        }

        private void pBtn_Click(object sender, EventArgs e)
        {
            rTxt.Clear();
            var tempObj = new
            {
                Publisher = pTxt.Text,
                Content = cTxt.Text,
                Images = images
            };

            var payload = JsonConvert.SerializeObject(tempObj,
                new JsonSerializerSettings
                {
                    ContractResolver = new CamelCasePropertyNamesContractResolver()
                });

            var httpContent = new StringContent(payload, Encoding.UTF8, "application/json");

            try
            {
                var disco = DiscoveryClient.GetAsync("http://localhost:5005").Result;

                var tokenClient = new TokenClient(disco.TokenEndpoint, "test.client", "secret");
                var tokenResponse = tokenClient.RequestClientCredentialsAsync("hulaStatusApi").Result;

                if (tokenResponse.IsError)
                {
                    rTxt.Text = tokenResponse.Error;
                }

                var httpClient = new HttpClient();
                httpClient.SetBearerToken(tokenResponse.AccessToken);

                var response = httpClient.PostAsync("http://localhost:5000/api/hulastatus", httpContent).Result;

                if (response.IsSuccessStatusCode)
                {
                    rTxt.Text = response.Content.ReadAsStringAsync().Result;
                }
                else
                {
                    rTxt.Text = response.StatusCode.ToString();
                }                
            }
            catch (Exception ex)
            {
                rTxt.Text = $"Something wrong when publish with exception {ex.Message}";
            }
        }
    }

    public class Image
    {
        public string FileName { get; set; }

        // Base64 string
        public string Base64Data { get; set; }
    }
}
