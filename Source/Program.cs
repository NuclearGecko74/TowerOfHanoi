using System;
using HanoiTower.Source.DataStructures;
using HanoiTower.Source.Renderer;

class Program
{
    static void Main()
    {
        Game game = new Game();
        game.Start();

        Pila stack = new Pila(2);
        stack.Push(1);
        stack.Push(0);

        stack.PrintStack();
    }
}