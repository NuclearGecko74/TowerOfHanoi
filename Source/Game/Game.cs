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

        private short NUMBER_OF_DISKS = 4;

        private Tower tower1;
        private Tower tower2;
        private Tower tower3;

        private List<(Tower from, Tower to)> moves;

        private double timer;
        private double moveInterval;

        public Game(short ndisks)
        {
            NUMBER_OF_DISKS = ndisks;

            Raylib.InitWindow(WIDTH, HEIGHT, "Torres de Hanoi");
            Raylib.SetTargetFPS(60);

            tower1 = new Tower(NUMBER_OF_DISKS);
            tower2 = new Tower();
            tower3 = new Tower();

            moveInterval = 10 / (Math.Pow(2, NUMBER_OF_DISKS) - 1);

            moves = new List<(Tower from, Tower to)>();

            SolveTower(NUMBER_OF_DISKS, tower1, tower3, tower2);
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

            timer += Raylib.GetFrameTime();

            if (moves.Count > 0 && timer >= moveInterval)
            {
                var nextMove = moves[0];
                nextMove.from.Move(nextMove.to);
                moves.RemoveAt(0);

                timer = 0;
            }
        }

        private void SolveTower(int n, Tower origin, Tower destination, Tower auxiliary)
        {
            if (n == 0) return;

            SolveTower(n - 1, origin, auxiliary, destination);
            moves.Add((origin, destination));
            SolveTower(n - 1, auxiliary, destination, origin);
        }

        static public short GetWidth() { return WIDTH; }
        static public short GetHeight() { return HEIGHT; }
    }
}
