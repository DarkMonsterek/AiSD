using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zaj4
{
    public class NodeT
    {
        public NodeT lewe;
        public NodeT prawe;
        public NodeT root;
        public int data;

        public NodeT(int data)
        {
            lewe = null;
            prawe = null;
            root = null;
            this.data = data;
        }

        public NodeT ZnajdzRodzica(NodeT dziecko)
        {
            var tmp = this.root;
            while (tmp != null)
            {
                if (dziecko.data < tmp.data)
                {
                    if (tmp.lewe == null)
                    {
                        return tmp;
                    }
                    else
                    {
                        tmp = tmp.lewe;
                    }
                }
                else
                {
                    if (tmp.prawe == null)
                    {
                        return tmp;
                    }
                    else
                    {
                        tmp = tmp.prawe;
                    }
                }
            }
            return null;
        }

        public NodeT Add(int liczba)
        {
            var dziecko = new NodeT(liczba);
            if(this.root == null)
            {
                this.root = dziecko;
            }
            else
            {
                var rodzic = this.ZnajdzRodzica(dziecko);
                if(dziecko.data < rodzic.data)
                {
                    rodzic.PolaczLewa(dziecko);
                }
                else
                {
                    rodzic.PolaczPrawa(dziecko);
                }
            }
            return dziecko;
        }

        public void PolaczLewa(NodeT dziecko)
        {
            this.lewe = dziecko;
            if(dziecko != null)
            {
                dziecko.root = this;
            }
        }

        public void PolaczPrawa(NodeT dziecko)
        {
            this.prawe = dziecko;
            if (dziecko != null)
            {
                dziecko.root = this;
            }
        }

        public void DisplayTree(NodeT node, string indent = "", bool isLeft = true)
        {
            if (node != null)
            {
                Console.WriteLine(indent + (isLeft ? "├── " : "└── ") + node.data);
                indent += isLeft ? "│   " : "    ";
                DisplayTree(node.lewe, indent, true);
                DisplayTree(node.prawe, indent, false);
            }
        }
        public void Remove(int value)
        {
            NodeT nodeToRemove = FindNode(root, value);
            if (nodeToRemove == null)
            {
                Console.WriteLine("Node not found.");
                return;
            }

            //Brak dzieci
            if (nodeToRemove.lewe == null && nodeToRemove.prawe == null)
            {
                if (nodeToRemove == nodeToRemove.root)
                {
                    nodeToRemove.root = null;
                }
                else
                {
                    if (nodeToRemove == nodeToRemove.root.lewe)
                        nodeToRemove.root.lewe = null;
                    else
                        nodeToRemove.root.prawe = null;
                }
            }
            //1 dziecko
            else if (nodeToRemove.lewe == null || nodeToRemove.prawe == null)
            {
                NodeT child = (nodeToRemove.lewe != null) ? nodeToRemove.lewe : nodeToRemove.prawe;
                if (nodeToRemove == nodeToRemove.root)
                {
                    root = child;
                    child.root = null;
                }
                else
                {
                    if (nodeToRemove == nodeToRemove.root.lewe)
                        nodeToRemove.root.lewe = child;
                    else
                        nodeToRemove.root.prawe = child;
                    child.root = nodeToRemove.root;
                }
            }
            //2 dzieci
            else
            {
                NodeT successor = FindMin(nodeToRemove.prawe);
                int successorData = successor.data;
                Remove(successorData);
                nodeToRemove.data = successorData;
            }
        }

        private NodeT FindMin(NodeT node)
        {
            while (node.lewe != null)
            {
                node = node.lewe;
            }
            return node;
        }

        private NodeT FindNode(NodeT node, int value)
        {
            if (node == null)
                return null;
            if (value == node.data)
                return node;
            if (value < node.data)
                return FindNode(node.lewe, value);
            else
                return FindNode(node.prawe, value);
        }
    }
}
