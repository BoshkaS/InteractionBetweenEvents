using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InteractionBetweenEvents
{
    public enum Days
    {
        Понеділок=0,
        Вівторок=1,
        Середа=2,
        Четвер=3,
        Пятниця=4,
        Субота=5,
        Неділя=6
    }

    // Дівчинка - клас, має ptoperty Name, Age, Days. 
    // Має подію Visit, яку оголошено з використанням усіх засобів автоматизації.
    // тип делегата - з простору System.ComponentModel. Також додала enum Days, для зручності.
    public class Girl
    {
        public event PropertyChangedEventHandler Sniff;

        // Отримує повідомлення про зміну часу дня і вміє обробити його цим методом.
        public void Snuffing(object sender, PropertyChangedEventArgs arg)
        {
            Flower flower = sender as Flower;
            OnSnuffing(flower);
        }

        //Метод ініціації події Sniff
        private void OnSnuffing(Flower flower)
        {
            if (flower.DissolveTime == "День" && (int)Day >= 5)
            {
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine("{0} сфотографувалась з квіткою {1}", Name, flower.Name);
                if (Sniff != null)
                {
                    PropertyChangedEventArgs arg = new PropertyChangedEventArgs(flower.DissolveTime);
                    Sniff(this, arg);
                }
            }
            else if (flower.DissolveTime == "Ніч" && (int)Day < 5)
            {
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine("{0} сфотографувалась з квіткою {1}", Name, flower.Name);
                if (Sniff != null)
                {
                    PropertyChangedEventArgs arg = new PropertyChangedEventArgs(flower.DissolveTime);
                    Sniff(this, arg);
                }
            }
        }
        
        public string Name { get; set;}

        public uint Age { get; set;}

        public Days Day { get; set;}

        public Girl(string name, uint age, Days day)
        {
            Name = name;
            Age = age;
            Day = day;
        }

        public override string ToString()
        {
            return $"Дівчинка {Name}";
        }
    }
}
