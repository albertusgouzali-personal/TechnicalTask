using FileHelpers;

namespace ErmPowerTask.Model
{
    [DelimitedRecord(",")]
    [IgnoreFirst]
    public class LPFile : BaseFile
    {
        [FieldConverter(ConverterKind.Decimal, ".")]
        [FieldOrder(60)]
        public decimal? DataValue;
    }
}
