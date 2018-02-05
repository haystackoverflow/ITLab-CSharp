using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ITLab
{
    public partial class From2 : Form
    {
        public Action<string> PassData { get; set; }

        public int Data { get; set; }

        public string Message { get; set; }

        public From2()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            label1.Text = Data.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Message = textBox1.Text;

            PassData(textBox1.Text);
        }
    }
}
