using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InteractionBetweenEvents
{
    // Дівчина - клас, має ptoperty Name, DissolveTime(визначає чи денна квітка чи нічна), MaxFloweringDay(скільки днів може цвісти), FloweringDay(який день вже цвіте). 
    // Має події FlowerOpen, FlowerClose, Wilting, які оголошено з використанням усіх засобів автоматизації.
    // тип делегата - з простору System.ComponentModel, другого - object i тип аргумента події Wilding.
    public class Flower
    {
        public delegate void ForWilting(object sender, MyEventArgsForWilting e);

        public event PropertyChangedEventHandler FlowerOpen;
        public event PropertyChangedEventHandler FlowerClose;
        public event ForWilting Wilting;

        private int _floweringDay;
        public string Name { get; set; }

        public string DissolveTime { get; set; }

        public int MaxFloweringDay { get; set; }

        // Отримує повідомлення про зміну часу дня і вміє обробити його цим методом.
        public void OnFlower(object sender, PropertyChangedEventArgs eArg)
        {
            Sun sun = sender as Sun;
            if (sun.TimeOfDay == "День")
            {
                if (DissolveTime == "День")
                {
                    OnFlowerOpen(sun.TimeOfDay);
                }
                else if(DissolveTime == "Ніч")
                {
                    OnFlowerClose(sun.TimeOfDay);
                }
            }
            else if (sun.TimeOfDay == "Ніч")
            {
                if (DissolveTime == "День")
                {
                    OnFlowerClose(sun.TimeOfDay);
                }
                else if (DissolveTime == "Ніч")
                {
                    OnFlowerOpen(sun.TimeOfDay);
                }
            }
        }

        //Метод ініціації події FlowerOpen
        private void OnFlowerOpen(string time)
        {
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Квітка {0} розпустилась!", Name);
            if (FlowerOpen != null)
            {
                PropertyChangedEventArgs arg = new PropertyChangedEventArgs(time);
                FlowerOpen(this, arg);
            }
        }

        //Метод ініціації події FlowerClose
        private void OnFlowerClose(string time)
        {
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("Квітка {0} Закрилась!", Name);
            if (FlowerClose != null)
            {
                PropertyChangedEventArgs arg = new PropertyChangedEventArgs(time);
                FlowerClose(this, arg);
            }
        }

        //Метод ініціації події Wilding
        private void OnWilding(int age)
        {
            Console.WriteLine("Квітка зів'яла!");
            if (Wilting != null)
            {
                MyEventArgsForWilting arg = new MyEventArgsForWilting(age);
                Wilting(this, arg);
            }
        }

        // property FloweringDay, y setі, у якому ми перевіряємо чи день цвітіння не досяг максимального віку, якщо домяг, то викликаємо метод OnWolding 
        public int FloweringDay {
            get
            {
                return _floweringDay;
            }
            set
            {
                _floweringDay += value;
                if (FloweringDay >= MaxFloweringDay)
                {
                    OnWilding(FloweringDay);
                }
            }
        }

        public Flower()
        {
            Name = "";
            DissolveTime = "";
            MaxFloweringDay = 0;
            FloweringDay = 0;
        }

        public Flower (string name, string dissolveTime, int floweringDay, int maxFloweringDay)
        {
            Name = name;
            DissolveTime = dissolveTime;
            MaxFloweringDay = maxFloweringDay;
            FloweringDay = floweringDay;
        }

        public override string ToString()
        {
            if (DissolveTime == "День")
            {
                return ($"Денна квітка {Name} має {FloweringDay} дні для цвітіння, лишилось ще {MaxFloweringDay - FloweringDay}");
            }
            else if (DissolveTime == "Ніч")
            {
                return ($"Нічна квітка {Name} має {FloweringDay} дні для цвітіння, лишилось ще {MaxFloweringDay - FloweringDay}");
            }
            return "";
            
        }
    }

    // Тип аругумента події Wilting
    public class MyEventArgsForWilting : EventArgs
    {
        public int _days;

        public MyEventArgsForWilting(int days)
        {
            _days = days;
        }
    }

}
