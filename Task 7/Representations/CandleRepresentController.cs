using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Interfaces;
using Data.Candles;
using LiveCharts;
using LiveCharts.Defaults;
using LiveCharts.Wpf;

namespace Representations
{
    public class CandleRepresentController : RepresentController
    {
        Candle[] Candles { get; set; } = new Candle[20];


        public CandleRepresentController(int maxCount) : base(maxCount)
        {
            for (int i = 0; i < 20; i++)
                Candles[i] = new Candle(0,0,0,0,0);
            SeriesCollection = new SeriesCollection{
                new CandleSeries()
                {
                    Values = new ChartValues<OhlcPoint>(),
                },

                new LineSeries
                {
                    AreaLimit = -10,
                    Values = new ChartValues<ObservableValue>(),
                },

                new LineSeries
                {
                    AreaLimit = -10,
                    Values = new ChartValues<ObservableValue>(),
                },

                new LineSeries
                {
                    AreaLimit = -10,
                    Values = new ChartValues<ObservableValue>(),
                }
            };
        }

        public override void AddValueToLine(ICandle candle, Func<ICandle, decimal> func = null)
        {

            SeriesCollection[0].Values.Add(new OhlcPoint((double)candle.Open, (double)candle.High, (double)candle.Low, (double)candle.Close));

            double average = CalcAverage(), sigma = CalcSigma(average);
            SeriesCollection[1].Values.Add(new ObservableValue(average + 2 * sigma));
            SeriesCollection[2].Values.Add(new ObservableValue(average));
            SeriesCollection[3].Values.Add(new ObservableValue(average - 2 * sigma));


            while (SeriesCollection[0].Values.Count > MaxPointsCount)
            {
                SeriesCollection[0].Values.RemoveAt(0);
                SeriesCollection[1].Values.RemoveAt(0);
                SeriesCollection[2].Values.RemoveAt(0);
                SeriesCollection[3].Values.RemoveAt(0);
            }

            for (int i = 19; i > 0; i--)
                Candles[i] = Candles[i - 1];
            Candles[0] = (Candle)candle;
        }

        private double CalcSigma(double average)
        {
            int n = 0;
            double sum = 0;
            do
            {
                sum += ((double)Candles[n].Close - average) * ((double)Candles[n].Close - average);
                n++;
            } while (n < 20 && Candles[n].Close != 0);
            return Math.Sqrt(sum / n);
        }

        private double CalcAverage()
        {
            int n = 0;
            double sum = 0;
            do
            {
                sum += (double)Candles[n].Close;
                n++;
            } while (n < 20 && Candles[n].Close != 0);
            return sum / n;
        }
    }
}
