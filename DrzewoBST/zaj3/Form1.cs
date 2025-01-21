using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace zaj3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Tree t1 = new Tree();
            t1.AddToTree(2);
            t1.AddToTree(3);
            t1.AddToTree(4);
            t1.AddToTree(2);
            t1.AddToTree(1);

            t1.InOrder();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            List l1 = new List();
            l1.AddFirst(9);
            l1.AddFirst(7);
            l1.AddLast(1);
            l1.AddLast(8);

            l1.RemoveLast();
            l1.RemoveLast();
            l1.RemoveFirst();
            l1.PrintAllElements();
        }
    }
}
