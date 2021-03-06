﻿using Data.Candles;
using Data.Interfaces;
using LiveCharts;
using LiveCharts.Defaults;
using LiveCharts.Wpf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Representations
{
    public abstract class RepresentController
    {
        public SeriesCollection SeriesCollection { get; set; } = new SeriesCollection();

        public ICandle LastCandle { get; protected set; }
        public int MaxPointsCount { get; set; }

        public RepresentController(int maxCount) { MaxPointsCount = maxCount; }

        public abstract void AddValueToLine(ICandle candle, Func<ICandle, decimal> func);
    }
}
