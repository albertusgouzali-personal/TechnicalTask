using System;

namespace ErmPowerTask.Helper
{
    public static class DecimalExtensions
    {
        public static decimal UpperLimit(this decimal median, decimal threshold)
        {
            return median * 0.01m * (100 + threshold);
        }

        public static decimal LowerLimit(this decimal median, decimal threshold)
        {
            return median * 0.01m * (100 - threshold);
        }

        public static decimal Median(this decimal[] values)
        {
            decimal medianValue = 0;
            
            var getLengthItems = values.Length;
            Array.Sort(values);
            switch (getLengthItems % 2)
            {
                case 0:
                    var firstValue = values[values.Length / 2 - 1];
                    var secondValue = values[values.Length / 2];
                    medianValue = (firstValue + secondValue) / 2;
                    break;
                case 1:
                    medianValue = values[values.Length / 2];
                    break;
            }

            return medianValue;
        }
    }
}