using HanoiTower.Source.Game;

class Program
{
    static void Main()
    {
        Console.WriteLine("Seleccione la cantidad de discos: ");
        short numberOfDisks = Convert.ToInt16(Console.ReadLine());
        Game game = new Game(numberOfDisks);
        game.Start();
    }
}