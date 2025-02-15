using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Raylib_cs;

namespace HanoiTower.Source.Renderer
{
    class Game
    {
        private const short WIDTH = 800;
        private const short HEIGHT = 600;

        public Game()
        {
            Raylib.InitWindow(WIDTH, HEIGHT, "Torres de Hanoi");
            Raylib.SetTargetFPS(60);
        }

        public void Start()
        {
            while (!Raylib.WindowShouldClose())
            {
                Raylib.BeginDrawing();
                Raylib.ClearBackground(Color.Black);
                Raylib.DrawText("Hello World!", 200, 250, 20, Color.White);
                Raylib.EndDrawing();
            }
            Raylib.CloseWindow();
        }
    }
}
