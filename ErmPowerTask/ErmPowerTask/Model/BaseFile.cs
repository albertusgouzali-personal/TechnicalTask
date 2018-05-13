using System;
using FileHelpers;

namespace ErmPowerTask.Model
{
    [DelimitedRecord(",")]
    [IgnoreFirst]
    public class BaseFile
    {
        [FieldOrder(10)]
        public string MeterpointCode;
        [FieldOrder(20)]
        public string SerialNumber;
        [FieldOrder(30)]
        public string PlantCode;
        [FieldOrder(40)]
        [FieldConverter(ConverterKind.Date, "dd/MM/yyyy HH:mm:ss")]
        public DateTime DateTime;
        [FieldOrder(50)]
        public string DataType;

        [FieldOrder(90)]
        public string Units;
        [FieldOrder(100)]
        public string Status;
    }
}
