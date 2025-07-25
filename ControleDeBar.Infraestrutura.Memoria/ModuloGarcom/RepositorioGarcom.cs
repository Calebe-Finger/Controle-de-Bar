using ControleDeBar.ConsoleApp.Compartilhado;
using ControleDeBar.Dominio.ModuloGarcom;

namespace ControleDeBar.Infraestrutura.Memoria.ModuloGarcom
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
