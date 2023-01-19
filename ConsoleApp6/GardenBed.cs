using System;
using System.Collections.Generic;

namespace Observer
{
    internal class GardenBed
    {
        static void Main(string[] args)
        {
            EnvironmentData environmentData = new EnvironmentData();
            CurrentEnvironmentDisplay currentEnvironment = new(environmentData);
            Corn corn = new Corn(environmentData);
            Cactus cactus = new Cactus(environmentData);
            Camellia camellia = new Camellia(environmentData);
            int time = 100;
            for (int i = 0; i < time; i++)
            {
                environmentData.EnvironmentSimulation();
                Thread.Sleep(200);
                if (i != time - 1)
                    Console.Clear();
            }                
        }
    }
}