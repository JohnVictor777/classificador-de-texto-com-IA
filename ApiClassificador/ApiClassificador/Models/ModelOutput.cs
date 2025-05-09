using Microsoft.ML.Data;

namespace ApiClassificador.Models
{
    public class ModelOutput
    {

        [ColumnName(@"col0")]
        public float[] Col0 { get; set; }

        [ColumnName(@"col1")]
        public uint Col1 { get; set; }

        [ColumnName(@"Features")]
        public float[] Features { get; set; }

        [ColumnName(@"PredictedLabel")]
        public float PredictedLabel { get; set; }

        [ColumnName(@"Score")]
        public float[] Score { get; set; }
    }
}
