using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InteractionBetweenEvents
{
    // Бджола - клас, має ptoperty Type. 
    // Має подію Visit, яку оголошено з використанням усіх засобів автоматизації.
    // тип делегата - з простору System.ComponentModel.
    public class Bee
    {
        public event PropertyChangedEventHandler Visit;
        string Type { get; set; }

        // Отримує повідомлення про зміну часу дня і вміє обробити його цим методом.
        public void Visiting(object sender, PropertyChangedEventArgs arg)
        {
            Flower flower = sender as Flower;
            OnVisit(flower);
        }

        //Метод ініціації події Visit
        private void OnVisit(Flower flower)
        {
            if(flower.DissolveTime == "День")
            {
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("{0}-Бджола відвідала квітку {1}", Type, flower.Name);
                if (Visit != null)
                {
                    PropertyChangedEventArgs arg = new PropertyChangedEventArgs(flower.DissolveTime);
                    Visit(this, arg);
                }
            }
        }

        public Bee()
        {
            Type = "";
        }

        public Bee(string type)
        {
            Type = type;
        }

        public override string ToString()
        {
            return $"Бджілка{Type}";
        }
    }
}
