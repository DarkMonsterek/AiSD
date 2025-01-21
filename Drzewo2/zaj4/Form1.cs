using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace zaj4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        
private void button1_Click(object sender, EventArgs e)
        {
            NodeT drzewo = new NodeT(1);
            drzewo.Add(2);
            drzewo.Add(10);
            drzewo.Add(12);
            drzewo.Add(14);
            drzewo.Add(8);
            drzewo.Add(6);
            drzewo.DisplayTree(drzewo.root);
            Console.WriteLine("po usunięciu:");
            drzewo.Remove(8);
            drzewo.DisplayTree(drzewo.root);
        }
    }
}
