using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DelegateWinForm
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        public void SetTextValue(object sender, DelegateWinForm.Form1.MyEventArgs e)
        {
            this.textBox1.Text = e.MyValues;
        }
        private void Form2_Load(object sender, EventArgs e)
        {

        }
    }
}
