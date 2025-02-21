using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using HanoiTower.Source.Renderer;
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

        private UInt128 movesCount = 0;
        private bool bSolve = false;

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

            if (moves.Count > 0 && timer >= moveInterval && bSolve)
            {
                var nextMove = moves[0];
                nextMove.from.Move(nextMove.to);
                moves.RemoveAt(0);
                movesCount++;
                timer = 0;
            }

            DrawMoves();
            if (!bSolve)
            {
                DrawSolveButton();
            }
        }

        private void SolveTower(int n, Tower origin, Tower destination, Tower auxiliary)
        {
            if (n == 0) return;

            SolveTower(n - 1, origin, auxiliary, destination);
            moves.Add((origin, destination));
            SolveTower(n - 1, auxiliary, destination, origin);
        }

        private void DrawMoves()
        {
            Raylib.DrawText("Movimientos: " + movesCount, 10, 10, 20, Color.Black);
        }

        private void DrawSolveButton()
        {
            Button button = new Button(970, 10, 100, 50, "Solve", Color.Green, Color.DarkGreen, Color.White, 20);
            button.Draw();
            if (button.IsClicked())
            {
                bSolve = true;
            }
        }

        /*static public short GetWidth() { return WIDTH; }
        static public short GetHeight() { return HEIGHT; }*/
    }
}
