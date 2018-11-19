using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EventAgentDemo
{
    public partial class FormUserAdd : Form
    {
        //TODO:1、Base class defines events
        public class userAddEventArgs : EventArgs
        {
            public User AddedUser;
            public userAddEventArgs(User user)
            {
                this.AddedUser = user;
            }
        }
        //TODO:2、Commissioned by definition and specify parameter types
        public delegate void userAddedEventHandle(object sender, userAddedEventHandle e);

        //TODO:3、Define and specify the events of the delegate type
        public event userAddedEventHandle userHandler;
        public FormUserAdd()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            User user = new User("1","zhai","123");
            userAddEventArgs args = new userAddedEventHandle(user);
        }
    }
}
