﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Observer
{
    internal interface IObserver
    {
        public void update(double temperature, double humidity, double illumination, double wind);
    }
}
