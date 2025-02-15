using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HanoiTower.Source.DataStructures
{
    class Pila
    {
        private Node top;
        private int height;

        public Pila(int data)
        {
            top = new Node(data);
            height = 1;
        }

        public Pila()
        {
            top = null;
            height = 0;
        }

        public void Push(int data)
        {
            if (IsEmpty())
            {
                top = new Node(data);
            }
            else
            {
                top = new Node(data, top);
            }
            height++;
        }

        public Node Pop()
        {
            if (IsEmpty()) return null;

            Node temp = top;
            top = top.next;
            return temp;
        }

        public int Peek() { return top.data; }

        public void PrintStack()
        {
            Node current = top;
            while(current != null)
            {
                Console.WriteLine(current.data);
                current = current.next;
            }
        }

        bool IsEmpty() { return top == null;  }
    }
}
