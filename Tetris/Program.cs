using System;
using System.Threading.Tasks;


namespace Tetris
{
    class Program
    {
        
        const int WIDTH = 24;
        const int HEIGHT = 24;

        static Element MainElement;
        static GameFieldBoard GameField;

        static int Timer = 0;
        static void Main(string[] args)
        {


            GameField = new GameFieldBoard(WIDTH, HEIGHT);
            MainElement = new Element(WIDTH, HEIGHT, GameField);
            MainElement.GenerateNewElement();

            Update();
            Controller();
            Console.ReadLine();
        }
        static async void Controller()
        {
            while (true)
            {
                var Key = Console.ReadKey(true);
                if(Key.Key == ConsoleKey.LeftArrow)
                {
                    MainElement.ChangePosElement(-1, 0);
                }
                else if(Key.Key == ConsoleKey.RightArrow)
                {
                    MainElement.ChangePosElement(1, 0);
                }
                else if(Key.Key == ConsoleKey.DownArrow)
                {
                    MainElement.ChangePosElement(0, 1);
                }
                else if(Key.Key == ConsoleKey.UpArrow)
                {
                    MainElement.Rotate();
                }
            }
        }
      
        static async void Update()
        {
            while (true)
            {
                GameField.DrawLevel();
                Timer++;
                if (Timer == 20)
                {
                    MainElement.ChangePosElement(0, 1);

                    Timer = 0;
                }
                await Task.Delay(10);
            }
        }
     
    }
 
}
