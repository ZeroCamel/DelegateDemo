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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        //TODO:委托->>事件->>传值
        public delegate void MyDelegate(object sender, MyEventArgs e);

        //TODO:将委托定义为事件
        public event MyDelegate MyEvent;
        private void button1_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            //赋值和订阅不分先后

            //事件赋值
            MyEventArgs me = new MyEventArgs();  //TODO:自定义包含事件数据类的基类
            me.MyValues = this.textBox1.Text;

            //事件订阅
            this.MyEvent += new MyDelegate(f2.SetTextValue); //TODO:事件订阅对应委托并传参(事件方法名称)

            MyEvent(this, me); //执行事件

            f2.Show(); //显示窗体
        }
        public class MyEventArgs : EventArgs
        {
            public string MyValues = "";
        }
    }
}
