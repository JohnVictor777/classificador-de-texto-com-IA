using ApiClassificador.Models;
using Microsoft.ML;

namespace ApiClassificador.Services
{
    public class ClassificacaoService
    {
        private readonly MLContext _mlContext;
        private readonly ITransformer _model;
        private readonly PredictionEngine<ModelInput, ModelOutput> _predictionEngine;

        public ClassificacaoService()
        {
            _mlContext = new MLContext();

            // Carrega o modelo treinado
            var modelPath = @"C:\Users\John\Desktop\ClassificadorDeTextoComIA\ApiClassificador\ApiClassificador\SentimentModel.mlnet";
            _model = _mlContext.Model.Load(modelPath, out var modelInputSchema);

            // Cria o PredictionEngine
            _predictionEngine = _mlContext.Model.CreatePredictionEngine<ModelInput, ModelOutput>(_model);
        }

        // Método para fazer a classificação e retornar o resultado completo
        public ClassificacaoResultado Classificar(string texto)
        {
            var input = new ModelInput { Col0 = texto };
            var resultado = _predictionEngine.Predict(input);

            // Garante que a comparação não dependa de maiúsculas ou minúsculas
            string predictedLabel = resultado.PredictedLabel.ToString().Trim().ToLower();

            string classificacao;
            try
            {
                if (predictedLabel == "1" || predictedLabel == "positivo")
                {
                    classificacao = "Positivo";
                }
                else if (predictedLabel == "0" || predictedLabel == "negativo")
                {
                    classificacao = "Negativo";
                }
                else
                {
                    classificacao = "Neutro";
                }

                return new ClassificacaoResultado 
                {
                    TextoOriginal = texto,
                    Classificacao = classificacao
                };
            }

            catch (Exception ex)
            {
                throw new Exception($"Erro ao classificar o texto: {ex.Message}");
            }
        }
    }
}
