using System;
using HanoiTower.Source.DataStructures;
using HanoiTower.Source.Renderer;
using Raylib_cs;

class Program
{
    static void Main()
    {
        //Raylib.InitWindow(800, 600, "Torres de Hanoi");
        //Raylib.SetTargetFPS(60);

        //while (!Raylib.WindowShouldClose())
        //{
        //    Raylib.BeginDrawing();
        //    Raylib.ClearBackground(Color.Black);
        //    Raylib.DrawText("Hola causas pes", 200, 250, 20, Color.White);
        //    Raylib.EndDrawing();
        //}
        //Raylib.CloseWindow();
        Game game = new Game();
        game.Start();

        Pila stack = new Pila(2);
        stack.Push(1);
        stack.Push(0);

        stack.PrintStack();
    }
}