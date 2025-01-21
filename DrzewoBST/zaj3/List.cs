﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace zaj3
{
    internal class List
    {
        public Node head;
        public Node tail;
        public int count;

        public void AddFirst(int num)
        {
            Node n = new Node(num);
            if (tail == null)
            {
                head = n;
                tail = n;
            }
            else
            {
                head.prev = n;
                n.next = head;
                head = n;
            }
            count++;
        }

        public void AddLast(int num)
        {
            Node n = new Node(num);
            if (tail == null)
            {
                head = n;
                tail = n;
            }
            else
            {
                tail.next = n;
                n.prev = tail;
                tail = n;
            }
            count++;
        }
        public void RemoveFirst()
        {
            if (head == tail)
            {
                head = null;
                tail = null;
            }
            else
            {
                head = head.next;
                head.prev = null;
            }
            count--;
        }

        public void RemoveLast()
        {
            if (head == tail)
            {
                head = null;
                tail = null;
            }
            else
            {
                tail = tail.prev;
                tail.next = null;
            }
            count--;
        }

        public void PrintAllElements()
        {
            Node current = head;
            string lista = null;
            while (current != null)
            {
                lista += current.data.ToString();
                lista += ", ";
                current = current.next;
            }
            MessageBox.Show(lista);
        }
    }

}

