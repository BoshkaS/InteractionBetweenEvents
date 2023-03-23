using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InteractionBetweenEvents
{
    // Нічний метелик - клас, має ptoperty Type. 
    // Має подію VisitFly, яку оголошено з використанням усіх засобів автоматизації.
    // тип делегата - з простору System.ComponentModel.
    public class NightFly
    {
        public event PropertyChangedEventHandler VisitFly;
        string Type { get; set; }

        // Отримує повідомлення про зміну часу дня і вміє обробити його цим методом.
        public void Visiting(object sender, PropertyChangedEventArgs arg)
        {
            Flower flower = sender as Flower;
            OnVisit(flower);
        }

        //Метод ініціації події VisitFly
        private void OnVisit(Flower flower)
        {
            if (flower.DissolveTime == "Ніч")
            {
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("{0}-Нічний метелик відвідав квітку {1}", Type, flower.Name);
                if (VisitFly != null)
                {
                    PropertyChangedEventArgs arg = new PropertyChangedEventArgs(flower.DissolveTime);
                    VisitFly(this, arg);
                }
            }
        }

        public NightFly()
        {
            Type = "";
        }

        public NightFly(string type)
        {
            Type = type;
        }

        public override string ToString()
        {
            return $"Нічний метелик{Type}";
        }
    }
}
