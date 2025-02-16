using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Raylib_cs;

namespace HanoiTower.Source.Game
{
    class Game
    {
        private const short WIDTH = 1080;
        private const short HEIGHT = 720;

        private const short NUMBER_OF_DISKS = 4;

        private Tower tower1;
        private Tower tower2;
        private Tower tower3;

        public Game()
        {
            tower1 = new Tower(NUMBER_OF_DISKS);
            tower2 = new Tower();
            tower3 = new Tower();

            Raylib.InitWindow(WIDTH, HEIGHT, "Torres de Hanoi");
            Raylib.SetTargetFPS(60);
        }

        public void Start()
        {
            while (!Raylib.WindowShouldClose())
            {
                Raylib.BeginDrawing();
                Update();
                Raylib.EndDrawing();
            }
            Raylib.CloseWindow();
        }

        private void Update()
        {
            Raylib.ClearBackground(Color.SkyBlue);
            
            tower1.DrawTower(new Vector2(100, 620));
            tower2.DrawTower(new Vector2(410, 620));
            tower3.DrawTower(new Vector2(720, 620));
            //while (tower3.GetDisks().GetHeight() < NUMBER_OF_DISKS)
            //{
            //    SolveTower(NUMBER_OF_DISKS, tower1, tower3, tower2);
            //}
            //Console.WriteLine("\nTORRE RESUELTA!");
        }

        private void SolveTower(int n, Tower t1, Tower t3, Tower t2)
        {
            if (n == 0) return;

            SolveTower(n - 1, t1, t2, t3);
            t1.Move(t3);
            SolveTower(n - 1, t2, t3, t1);
        }

        static public short GetWidth() { return WIDTH; }
        static public short GetHeight() { return HEIGHT; }
    }
}
