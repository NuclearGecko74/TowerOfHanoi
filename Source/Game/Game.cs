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

        // Lista donde se guardan los movimientos a realizar para resolver la torre
        private List<(Tower from, Tower to)> moves;

        private double timer;
        private double moveInterval;

        private UInt128 movesCount = 0;
        private bool bSolve = false;

        public Game()
        {
            // Pedir la cantidad de discos
            Console.WriteLine("Seleccione la cantidad de discos: ");
            NUMBER_OF_DISKS = Convert.ToInt16(Console.ReadLine());

            Raylib.InitWindow(WIDTH, HEIGHT, "Torres de Hanoi");
            Raylib.SetTargetFPS(60);

            // Crear Torres
            tower1 = new Tower(NUMBER_OF_DISKS);
            tower2 = new Tower();
            tower3 = new Tower();

            // Calcular el tiempo entre cada movimiento dependiendo del número de discos
            moveInterval = 10 / (Math.Pow(2, NUMBER_OF_DISKS) - 1);
            moves = new List<(Tower from, Tower to)>();

            GenerateMoves(NUMBER_OF_DISKS, tower1, tower3, tower2);
        }

        public void Run()
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

            DrawTowers();
            DrawUI();
            SolveTower();
        }

        // Generamos los movimiento usando recursividad y los guardamos en una lista.
        private void GenerateMoves(int n, Tower origin, Tower destination, Tower auxiliary)
        {
            if (n == 0) return;

            GenerateMoves(n - 1, origin, auxiliary, destination);
            moves.Add((origin, destination));
            GenerateMoves(n - 1, auxiliary, destination, origin);
        }

        private void SolveTower()
        {
            // Sumar el tiempo en segundos entre cada frame
            timer += Raylib.GetFrameTime();

            /* Si superamos cierto tiempo se hace el siguiente movimiento para resolver la torre de tal manera
            que se puedan ver todos los movimientos realizados
            */
            if (moves.Count > 0 && timer >= moveInterval && bSolve)
            {
                var nextMove = moves[0];
                nextMove.from.Move(nextMove.to);
                moves.RemoveAt(0);
                movesCount++;
                timer = 0;
            }
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

        private void DrawRestartButton()
        {
            Button button = new Button(970, 10, 100, 50, "Restart", Color.Red, Color.Brown, Color.White, 20);
            button.Draw();
            if (button.IsClicked())
            {
                tower1 = new Tower(NUMBER_OF_DISKS);
                tower2 = new Tower();
                tower3 = new Tower();
                moves = new List<(Tower from, Tower to)>();
                GenerateMoves(NUMBER_OF_DISKS, tower1, tower3, tower2);
                movesCount = 0;
                timer = 0;
                bSolve = false;
            }
        }

        private void DrawTowers()
        {
            tower1.DrawTower(new Vector2(100, 620));
            tower2.DrawTower(new Vector2(410, 620));
            tower3.DrawTower(new Vector2(720, 620));
        }

        private void DrawUI()
        {
            DrawMoves();
            if (!bSolve)
            {
                DrawSolveButton();
            }

            if (tower3.GetDisks().GetHeight() == NUMBER_OF_DISKS)
            {
                Raylib.DrawText("¡TORRE RESUELTA!", 400, 10, 20, Color.Black);
                DrawRestartButton();
            }
        }
    }
}
