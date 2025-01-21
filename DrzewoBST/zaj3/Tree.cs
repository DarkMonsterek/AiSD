using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace zaj3
{
    internal class Tree
    {
        public NodeT root;

        public Tree()
        {
            root = null;
        }

        public void AddToTree(int data)
        {
            root = AddToTree(root, data, null);
        }

        public NodeT AddToTree(NodeT nodeT, int data, NodeT parent)
        {
            if (nodeT == null)
            {
                NodeT nT = new NodeT(data);
                nT.parent = parent;
                return nT;
            }

            if (data <= nodeT.data)
            {
                nodeT.left = AddToTree(nodeT.left, data, nodeT);
            }

            else if (data > nodeT.data)
            {
                nodeT.right = AddToTree(nodeT.right, data, nodeT);
            }

            return nodeT;
        }

        public void InOrder(NodeT node)
        {
            if (node == null)
            {
                return;
            }
            else
            {
                InOrder(node.left);
                MessageBox.Show(node.data + " ");
                InOrder(node.right);
            }
        }

        public void InOrder()
        {
            InOrder(root);
        }
    }

}
