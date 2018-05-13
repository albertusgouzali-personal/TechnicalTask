using System;
using FileHelpers;

namespace ErmPowerTask.Model
{
    [DelimitedRecord(",")]
    [IgnoreFirst]
    public class TOUFile : BaseFile
    {
        [FieldConverter(ConverterKind.Decimal, ".")]
        [FieldOrder(60)]
        public decimal? Energy;
        [FieldOrder(70)]
        public string MaximumDemand;
        [FieldOrder(80)]
        public string TimeOfMaxDemand;
        [FieldOrder(110)]
        public string Period;
        [FieldOrder(120)]
        public string DLSActive;
        [FieldOrder(130)]
        public string BillingResetCount;
        [FieldConverter(ConverterKind.Date, "dd/MM/yyyy HH:mm:ss")]
        [FieldOrder(140)]
        public DateTime BillingResetDateTime;
        [FieldOrder(150)]
        public string Rate;
    }
}
