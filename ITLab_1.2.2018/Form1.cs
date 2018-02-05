using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using RestSharp;
using Newtonsoft.Json;

namespace ITLab
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            button1.Click += button1_Click;
            //button1.Click += button1_Click1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    //throw new Exception("Strasna greska");
            //}
            //catch (Exception ee)
            //{
            //    MessageBox.Show($"Desila se greska: {ee.Message}");
            //}
            //finally
            //{
            //    MessageBox.Show("Ja sam uvijek tu!");
            //}
            //Cursor = Cursors.WaitCursor;
            //Thread.Sleep(4000);
            //Cursor = Cursors.Default;

            string apiKey = "Prostor za vas API kljuc";
            RestClient restClient = new RestClient($"http://www.omdbapi.com/?apikey={apiKey}&");

            RestRequest restRequest = new RestRequest(Method.GET);
            restRequest.AddQueryParameter("t", "Batman");
            
            var result = restClient.Execute(restRequest);

            string data = result.Content;

            Movie movie = JsonConvert.DeserializeObject<Movie>(data);
            File.WriteAllText(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\tmpFile.txt", data);

            MessageBox.Show(data);
        }
        
        private void button1_Click1(object sender, EventArgs e)
        {
            int broj = 1;
            
            using (From2 form2 = new From2())
            {
                form2.PassData = HandleMessage;
                form2.Data = broj;
                form2.ShowDialog(this);
                MessageBox.Show(form2.Message);
            }
        }

        public void HandleMessage(string message)
        {
            MessageBox.Show($"Form 1: {message}");
        }
    }
}
