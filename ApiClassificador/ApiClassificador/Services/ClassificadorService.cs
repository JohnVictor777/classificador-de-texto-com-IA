using Microsoft.ML;
using ApiClassificador.Services;
using Microsoft.Extensions.Logging;
using ApiClassificador.Models; 

public class ClassificadorService : IClassificadorService
{
    private readonly ILogger<ClassificadorService> _logger;
    private PredictionEngine<ModelInput, ModelOutput>? _predictionEngine;
    private bool _modeloCarregado = false;

    public ClassificadorService(ILogger<ClassificadorService> logger)
    {
        _logger = logger;
    }

    public void CarregarModelo(string caminhoModelo)
    {
        try
        {
            _logger.LogInformation($"Iniciando carregamento do modelo: {caminhoModelo}");

            if (!File.Exists(caminhoModelo))
            {
                throw new FileNotFoundException($"Arquivo do modelo não encontrado em: {caminhoModelo}");
            }

            var mlContext = new MLContext();

            using (var stream = new FileStream(caminhoModelo, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                ITransformer model = mlContext.Model.Load(stream, out var schema);

                // Verificação do schema - ajuste conforme suas colunas reais
                if (schema.GetColumnOrNull("Texto") == null ||
                    schema.GetColumnOrNull("CategoriaPrevista") == null)
                {
                    throw new InvalidOperationException("O modelo não contém as colunas esperadas");
                }

                _predictionEngine = mlContext.Model.CreatePredictionEngine<ModelInput, ModelOutput>(
                    model,
                    ignoreMissingColumns: false);

                // Teste predição simples para validação
                var testInput = new ModelInput { Col0 = "texto de teste" };
                var testResult = _predictionEngine.Predict(testInput);

                _modeloCarregado = true;
                _logger.LogInformation("Modelo carregado e validado com sucesso");
            }
        }
        catch (Exception ex)
        {
            _modeloCarregado = false;
            _logger.LogError(ex, "Falha crítica ao carregar o modelo");
            throw new InvalidOperationException($"Falha crítica ao carregar o modelo: {ex.Message}", ex);
        }
    }

    public float ClassificarTexto(string texto)
    {
        try
        {
            if (_predictionEngine == null)
            {
                throw new InvalidOperationException("O modelo não foi carregado corretamente.");
            }

            if (string.IsNullOrWhiteSpace(texto))
            {
                throw new ArgumentException("O texto para classificação não pode ser vazio ou nulo.", nameof(texto));
            }

            if (texto.Length > 1000)
            {
                _logger.LogWarning("Texto muito longo recebido ({Length} caracteres). Será truncado para 1000 caracteres.", texto.Length);
                texto = texto.Substring(0, 1000);
            }

            _logger.LogDebug("Classificando texto: \"{Preview}...\"", texto[..Math.Min(50, texto.Length)]);

            var input = new ModelInput { Col0 = texto };
            var result = _predictionEngine.Predict(input);

            float score = result.PredictedLabel;

            if (float.IsNaN(score))
            {
                _logger.LogError("Resultado da classificação é inválido: NaN.");
                throw new InvalidOperationException("Resultado da classificação não é um valor numérico válido.");
            }

            _logger.LogInformation("Classificação concluída com sucesso. Score: {Score}", score);
            return score;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erro ao classificar texto.");
            throw new ClassificationException("Falha ao processar a classificação do texto.", ex);
        }
    }


    public bool ModeloCarregado() => _modeloCarregado;
}

// Exceção personalizada para erros de classificação
public class ClassificationException : Exception
{
    public ClassificationException(string message, Exception innerException)
        : base(message, innerException) { }
}