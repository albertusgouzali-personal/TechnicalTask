using System;

namespace ErmPowerTask.Model
{
    public class Records
    {
        public DateTime Datetime { get; }

        public decimal Value { get; }

        public Records(decimal value, DateTime datetime)
        {
            Value = value;
            Datetime = datetime;
        }
    }
}
