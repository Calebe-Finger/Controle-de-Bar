namespace ControleDeBar.ConsoleApp.Compartilhado
{
    public abstract class RepositorioBase<Tipo> where Tipo : EntidadeBase<Tipo>
    {
        protected Tipo[] registros = new Tipo[100];
        protected int contadorRegistros = 0;
        protected int contadorIds = 0;

        public void CadastrarRegistro(Tipo novoRegistro)
        {
            novoRegistro.Id = ++contadorIds;

            registros[contadorRegistros++] = novoRegistro;
        }

        public bool EditarRegistro(int idSelecionado, Tipo registroAtualizado)
        {
            Tipo registroSelecionado = SelecionarRegistroPorId(idSelecionado);

            if (registroSelecionado == null)
                return false;

            registroSelecionado.AtualizarRegistro(registroAtualizado);

            return true;
        }

        public virtual bool ExcluirRegistro(int idSelecionado)
        {
            for (int i = 0; i < registros.Length; i++)
            {
                if (registros[i] == null)
                    continue;

                else if (registros[i].Id == idSelecionado)
                {
                    registros[i] = null;

                    return true;
                }
            }

            return false;
        }

        public Tipo[] SelecionarRegistros()
        {
            return registros;
        }

        public Tipo SelecionarRegistroPorId(int idSelecionado)
        {
            for (int i = 0; i < registros.Length; i++)
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
