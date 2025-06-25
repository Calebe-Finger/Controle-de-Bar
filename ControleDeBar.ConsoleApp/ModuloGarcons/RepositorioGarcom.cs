using ControleDeBar.ConsoleApp.Compartilhado;

namespace ControleDeBar.ConsoleApp.ModuloGarcons
{
    public class RepositorioGarcom : RepositorioBase<Garcom>
    {
        private Garcom[] garcom;

        public override bool ExcluirRegistro(int idSelecionado)
        {
            if (garcom[idSelecionado].EstaOcupado)
                return false;

            else
                return base.ExcluirRegistro(idSelecionado);
        }
    }
}
