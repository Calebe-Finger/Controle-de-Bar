using ControleDeBar.Dominio.ModuloMesa;
using ControleDeBar.Infraestrutura.Arquivos.Compartilhado;

namespace ControleDeBar.Infraestrutura.Arquivos.ModuloMesa
{
    public class RepositorioMesaEmArquivo : RepositorioBaseEmArquivo<Mesa>
    {
        public RepositorioMesaEmArquivo(ContextoDados contextoDados) : base(contextoDados)
        {
        }

        protected override List<Mesa> ObterRegistros()
        {
            return contextoDados.Mesas;
        }
    }
}
