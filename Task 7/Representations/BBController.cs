﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Data.Candles;
using Data.Interfaces;
using LiveCharts;
using LiveCharts.Defaults;
using LiveCharts.Wpf;


namespace Representations
{
    public class BBController : RepresentController//TODO: find what needs changes
    {
        public BBController(int maxCount) : base(maxCount)
        {
            SeriesCollection = new SeriesCollection{
                new LineSeries
                {
                    AreaLimit = -10,
                    Values = new ChartValues<ObservableValue>(),
                }
            };
        }

        public override void AddValueToLine(ICandle candle, Func<ICandle, decimal> func)
        {
            var curValue = func.Invoke(candle);
            var lineValues = SeriesCollection[0].Values;
            /*
             TODO:

             3 series collections

             a way to calc sigma from 20 previous values; maybe less??


             a way to calc average from 2 prev values
             starting values are 0 0, then 0 first candle, then first_c, second_c etc
             */
            double value = LastCandle == null ? 0 : (double)(curValue / func.Invoke(LastCandle) - 1) * 100;
            lineValues.Add(new ObservableValue(value));
            while (lineValues.Count > MaxPointsCount)
            {
                lineValues.RemoveAt(0);
            }
            LastCandle = candle;
        }

    }
}
