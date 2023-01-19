using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Observer
{
    internal class EnvironmentData : ISubject
    {
        Random random = new Random();
        private List<IObserver> observers;
        private double temperature;
        private double humidity;
        private double illumination;
        private double wind;

        public EnvironmentData()
        {
            observers = new List<IObserver>();
            temperature = random.Next(-20, 40);
            humidity = random.Next(30, 100);
            illumination = random.Next(2, 30000);
            wind = random.Next(1, 20);
        }

        public void registerObserver(IObserver o)
        {
            observers.Add(o);
        }

        public void removeObserver(IObserver o)
        { 
            int i = observers.IndexOf(o);
            if (i >= 0) 
                observers.RemoveAt(i);
        }

        public void notifyObservers()
        {
            foreach (IObserver o in observers)
            {
                o.update(temperature, humidity, illumination, wind);
            }
        }

        public void measurementsChanged()
        {
            notifyObservers();
        }
        public void EnvironmentSimulation()
        {           
                if (temperature > 40)
                    temperature = 40;
                else if (temperature < -20)
                    temperature = -20;
                temperature += random.Next(-2, 3) * 0.5;
                if (humidity > 90)
                    humidity = 90;
                else if (humidity < 30)
                    humidity = 30;
                humidity += random.Next(-2, 3) * 0.5;
                if (illumination > 30000)
                    illumination = 30000;
                else if (illumination < 2)
                    illumination = 2;
                illumination += random.Next(-2, 3) * 0.5;
                if (wind > 20)
                    wind = 20;
                else if (wind < 1)
                    wind = 1;
                wind += random.Next(-2, 3) * 0.5;
                setMeasurements(temperature, humidity, illumination, wind);                             
        }

        public void setMeasurements(double temperature, double humidity, double illumination, double wind)
        {
            this.temperature = temperature;
            this.humidity = humidity;
            this.illumination = illumination;
            this.wind = wind;
            measurementsChanged();
        }
    }
}
