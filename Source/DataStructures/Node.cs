using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HanoiTower.Source.DataStructures
{
    class Node
    {
        public int data;
        public Node next;

        public Node(int data)
        {
            this.data = data;
            next = null;
        }

        public Node(int data, Node next)
        {
            this.data = data;
            this.next = next;
        }
    }
}
