using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Observer
{
    internal class Cactus : Plant, IObserver, IDisplayElement
    {
        Random random = new Random();
        private double temperature;
        private double humidity;
        private double illumination;
        private double wind;
        private double height;
        private bool alive = true;

        private ISubject weatherData;

        public Cactus(ISubject weatherData)
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
            if (height < 10 && alive)
                height += increaseHeight;
            else if (increaseHeight == -1 || !alive)
                Console.WriteLine("###Кактус погиб от холода!###");
            else
                Console.WriteLine("###Кактус вырос!###");
            return height;
        }

        public override double GrowthСoefficient()
        {
            double growthСoefficient = 0.5;
            double decrease = 0;

            if (temperature >= 10 && temperature <= 40)
                growthСoefficient += random.NextDouble() * 0.6;
            else if (temperature < 0)
            {
                alive = false;
                return -1;
            }
            else
                decrease += 0.005;

            if (humidity >= 20 && humidity <= 40)
                growthСoefficient += random.NextDouble() * 0.45;
            else
                decrease += 0.05;
            if (illumination >= 20000 && illumination <= 30000)
                growthСoefficient += random.NextDouble() * 0.25;
            else
                decrease += 0.1;
            if (wind >= 0 && wind <= 15)
                growthСoefficient += random.NextDouble() * 0.2;
            else
                decrease += 0.1;
            return growthСoefficient * decrease;
        }

        public void Display()
        {
            Console.WriteLine("Высота кактуса: " + Math.Round(Growth(), 2));
        }
    }
}

