using ApiClassificador.Models;

namespace ApiClassificador.Services
{
    public interface IClassificadorService
    {
        void CarregarModelo(string caminhoModelo);
        float ClassificarTexto(string texto);
    }
}
