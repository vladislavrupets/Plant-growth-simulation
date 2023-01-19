using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Observer
{
    internal class Corn : Plant, IObserver, IDisplayElement
    {
        Random random = new Random();
        private double temperature;
        private double humidity;
        private double illumination;
        private double wind;
        private double height;
        private bool alive = true;

        private ISubject weatherData;

        public Corn(ISubject weatherData)
        {
            this.weatherData = weatherData;
            weatherData.registerObserver(this);
            
        }

        public void update(double temperature, double humidity, double illumination, double wind)
        {
            this.temperature = temperature;
            this.humidity = humidity;
            this.illumination = illumination;
            this.wind = wind;
            Display();
        }

        public override double Growth()
        {
            double increaseHeight = GrowthСoefficient();
            if (height < 4 && alive)
                height += increaseHeight;
            else if(increaseHeight == -1 || !alive)
                Console.WriteLine("###Кукуруза погибла от холода!###");
            else           
                Console.WriteLine("###Кукуруза выросла!###");           
            return height;
        }

        public override double GrowthСoefficient()
        {
            double growthСoefficient = 0.5;
            double decrease = 0;

            if (temperature >= 10 && temperature <= 25)
                growthСoefficient += random.NextDouble() * 0.6;
            else if (temperature < 0)
            {
                alive = false;
                return -1;
            }
            else
                decrease += 0.005;

            if (humidity >= 40 && humidity <= 60)
                growthСoefficient += random.NextDouble() * 0.45;
            else
                decrease += 0.05;
            if (illumination >= 12000 && illumination <= 17000)
                growthСoefficient += random.NextDouble() * 0.25;
            else
                decrease += 0.1;
            if (wind >= 0 && wind <= 12)
                growthСoefficient += random.NextDouble() * 0.2;
            else
                decrease += 0.005;
            return growthСoefficient * decrease;
        }

        public void Display()
        {
            Console.WriteLine("Высота кукурузы: " + Math.Round(Growth(), 2));
        }
    }
}

