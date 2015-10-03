using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace VRMS
{
    public partial class Form1 : Master
    {
        public Form1()
        {
            InitializeComponent();
            
        }
        public void test1()
        {
            rtCapNhat.Visible = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           // test1();
        }
    }
}
