using ControleDeBar.Dominio.ModuloGarcom;
using ControleDeBar.Infraestrutura.Arquivos.Compartilhado;

namespace ControleDeBar.Infraestrutura.Arquivos.ModuloCarcom
{
    public class RepositorioGarcomEmArquivo : RepositorioBaseEmArquivo<Garcom>
    {
        public RepositorioGarcomEmArquivo(ContextoDados contextoDados) : base(contextoDados) {}

        protected override List<Garcom> ObterRegistros()
        {
            return contextoDados.Garcons;
        }
    }
}
