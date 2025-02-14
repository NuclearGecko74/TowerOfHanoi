using System;
using HanoiTower;
using Raylib_cs;

class Program
{
    static void Main()
    {
        //Raylib.InitWindow(800, 600, "Raylib en C#");
        //Raylib.SetTargetFPS(60);

        //while (!Raylib.WindowShouldClose())
        //{
        //    Raylib.BeginDrawing();
        //    Raylib.ClearBackground(Color.Black);
        //    Raylib.DrawText("¡Hola, Raylib en C#!", 200, 250, 20, Color.White);
        //    Raylib.EndDrawing();
        //}
        //Raylib.CloseWindow();
        Pila stack = new Pila(2);
        stack.Push(1);
        stack.Push(0);

        stack.Pop();

        Console.WriteLine(stack.Peek());
    }
}