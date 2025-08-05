using ControleDeBar.Dominio.Compartilhado;

namespace ControleDeBar.Infraestrutura.Arquivos.Compartilhado
{
    public abstract class RepositorioBaseEmArquivo<Tipo> where Tipo : EntidadeBase<Tipo>
    {
        protected ContextoDados contextoDados;
        protected List<Tipo> registros = new List<Tipo>();
        protected int contadorIds = 0;

        protected RepositorioBaseEmArquivo(ContextoDados contextoDados)
        {
            this.contextoDados = contextoDados;
        }

        public void CadastrarRegistro(Tipo novoRegistro)
        {
            novoRegistro.Id = ++contadorIds;

            registros.Add(novoRegistro);

            contextoDados.Salvar();
        }

        public bool EditarRegistro(int idSelecionado, Tipo registroAtualizado)
        {
            Tipo registroSelecionado = SelecionarRegistroPorId(idSelecionado);

            if (registroSelecionado == null)
                return false;

            registroSelecionado.AtualizarRegistro(registroAtualizado);

            contextoDados.Salvar();

            return true;
        }

        public virtual bool ExcluirRegistro(int idSelecionado)
        {
            for (int i = 0; i < registros.Count; i++)
            {
                if (registros[i] == null)
                    continue;

                else if (registros[i].Id == idSelecionado)
                {
                    registros[i] = null;

                    contextoDados.Salvar();

                    return true;
                }
            }

            return false;
        }

        public List<Tipo> SelecionarRegistros()
        {
            return registros;
        }

        public Tipo SelecionarRegistroPorId(int idSelecionado)
        {
            for (int i = 0; i < registros.Count; i++)
            {
                Tipo registro = registros[i];

                if (registro == null)
                    continue;

                if (registro.Id == idSelecionado)
                    return registro;
            }

            return null;
        }
    }
}


