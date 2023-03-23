using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InteractionBetweenEvents
{
    // Сонце - Клас, який має основну функцію, яка підписує квітку на час дня, бджілку на квітку, метелика на квітку, двічинку на квітки
    // Має property TimeOfDay, причому set ініціює події Sunrise i Sunset. Ці події оголошено з використанням усіх засобів автоматизації.
    // тип делегата - з простору System.ComponentModel. 
    public class Sun
    {
        private string timeOfDay;
        public string TimeOfDay {
            get
            {
                return timeOfDay;
            }
            set
            {
                timeOfDay = value;
                if (TimeOfDay == "День" )
                {
                    OnSunrise("TimeOfDay");
                }
                else if (TimeOfDay == "Ніч")
                {
                    OnSunset("TimeOfDay");
                }
            }
        } 

        public event PropertyChangedEventHandler Sunrise;
        public event PropertyChangedEventHandler Sunset;

        public Sun(string time)
        {
            timeOfDay = time;
        }

        public Sun() {}

        // Метод який приймає час дня, бджілку, нічного метелика, дівчинку і квітки.
        // потім, якщо день перебираються всі квітки і підписуються на всі потрібні події(квітка, бджола, дівчина)
        // потім, якщо ніч перебираються всі квітки і підписуються на всі потрібні події(квітка, нічний метелик, дівчина)
        // також, якщо зараз будній день, то івчина відвідує квітку вночі, а якщо вихідний, то вдень
        public void OnSun(string time, Bee bee, NightFly fly, Girl girl, params Flower[] flowers)
        {
            timeOfDay = time;
            if (TimeOfDay == "День")
            {
                foreach (var flower in flowers)
                {
                    Sunrise += flower.OnFlower;
                    flower.FlowerOpen += bee.Visiting;
                    if ((int)girl.Day >= 5)
                    {
                        flower.FlowerOpen += girl.Snuffing;
                    }
                }
                OnSunrise(TimeOfDay);
            }
            else if (TimeOfDay == "Ніч")
            {
                foreach (var flower in flowers)
                {
                    Sunset += flower.OnFlower;
                    flower.FlowerOpen += fly.Visiting;
                    if ((int)girl.Day < 5)
                    {
                        flower.FlowerOpen += girl.Snuffing;
                    }
                }
                OnSunset(TimeOfDay);
            }
        }

        // Метод ініціації події Sunrise
        protected void OnSunrise(string time)
        {
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Сонце зійшло!");
            if (Sunrise != null)
            {
                PropertyChangedEventArgs arg = new PropertyChangedEventArgs(time);
                Sunrise(this, arg);
            }
        }

        // Метод ініціації події Sunset
        private void OnSunset(string time)
        {
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(" Сонце зaйшло!");
            if (Sunset != null)
            {
                PropertyChangedEventArgs arg = new PropertyChangedEventArgs(time);
                Sunset(this, arg); // генерування події 
            }
        }

        public override string ToString()
        {
            if (TimeOfDay == "День") {
                return "Сонце зійшло!";
            }
            else if(TimeOfDay == "Ніч") 
            {
                return "Сонце зайшло!";
            }
            return "";
        }
    }
}
