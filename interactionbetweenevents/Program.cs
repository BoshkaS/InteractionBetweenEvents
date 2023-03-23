using System.Text;

namespace InteractionBetweenEvents
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = UTF8Encoding.UTF8;

            Sun sun = new Sun();

            Flower flower_1 = new Flower("Ромашка", "День", 3, 6);
            Flower flower_2 = new Flower("Троянда", "Ніч", 2, 3);
            Flower flower_3 = new Flower("Конвалія", "День", 1, 6);

            Bee bee = new Bee("Працівник");
            NightFly fly = new NightFly("Летун");

            Girl girl = new Girl("Олена", 12, Days.Вівторок);
            

            sun.OnSun("День", bee, fly, girl, flower_1, flower_2, flower_3);
            for (int i = 0; i < 100; i++)
            {
                Console.Write("-");
                Thread.Sleep(100);
            }
            Console.WriteLine();
            sun.OnSun("Ніч", bee, fly, girl, flower_1, flower_2, flower_3);

        }
    }
}