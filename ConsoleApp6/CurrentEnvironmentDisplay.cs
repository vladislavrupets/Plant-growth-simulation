using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Observer
{
    internal class CurrentEnvironmentDisplay : IObserver, IDisplayElement
    {
        private double temperature;
        private double humidity;
        private double illumination;
        private double wind;
        private ISubject environmentData;

        public CurrentEnvironmentDisplay(ISubject environmentData)
        {
            this.environmentData = environmentData;
            environmentData.registerObserver(this);
        }

        public void update(double temperature, double humidity, double illumination, double wind)
        {
            this.temperature = temperature;
            this.humidity = humidity;
            this.illumination = illumination;
            this.wind = wind;
            Display();
        }

        public void Display()
        {
            Console.WriteLine("Показатели окружения: " + "Температура: " +  Math.Round(temperature, 2) + "C; " + "Влажность: " +  Math.Round(humidity, 2) + "%; " +
                "Освещение: " + Math.Round(illumination, 2) + "лк; " + "Скорость ветра: " + Math.Round(wind, 2) + "км/ч"); 
        }
    }
}
