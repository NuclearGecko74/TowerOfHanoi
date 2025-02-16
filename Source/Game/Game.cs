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

        private const short NUMBER_OF_DISKS = 6;

        private Tower tower1;
        private Tower tower2;
        private Tower tower3;

        private List<(Tower from, Tower to)> moves;

        private float timer;
        private float moveInterval = 0.5f;

        public Game()
        {
            tower1 = new Tower(NUMBER_OF_DISKS);
            tower2 = new Tower();
            tower3 = new Tower();

            Raylib.InitWindow(WIDTH, HEIGHT, "Torres de Hanoi");
            Raylib.SetTargetFPS(60);

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

                timer = 0f;
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
