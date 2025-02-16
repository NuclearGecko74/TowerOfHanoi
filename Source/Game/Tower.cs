using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Raylib_cs;
using HanoiTower.Source.DataStructures;
using System.Numerics;

namespace HanoiTower.Source.Game
{
    class Tower
    {
        private Pila disks;

        public Tower(int n)
        {
            disks = new Pila();
            for (int i = n; i > 0; i--)
            {
                disks.Push(i);
            }
        }

        public Tower()
        {
            disks = new Pila();
        }

        public bool Move(Tower tower)
        {
            if (disks.IsEmpty()) { return false; }

            //if (!tower.GetDisks().IsEmpty())
            //{
            //    if (disks.Peek().data > tower.disks.Peek().data)
            //    {
            //        return false;
            //    }
            //}
            tower.GetDisks().Push(disks.Pop().data);
            return true;
        }

        public void DrawTower(Vector2 pos)
        {
            Raylib.DrawRectangle((int)pos.X, (int)pos.Y, 200, 10, Color.Black);
            Raylib.DrawRectangle((int)pos.X + 100, (int)pos.Y - 300, 5, 300, Color.Black);
            if (!disks.IsEmpty())
            {
                for(int i)
            }
        }

        public void PrintTower()
        {
            disks.PrintStack();
        }

        public Pila GetDisks() { return disks; }
    }
}
