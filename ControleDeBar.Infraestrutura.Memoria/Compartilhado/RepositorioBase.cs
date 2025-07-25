namespace ControleDeBar.Infraestrutura.Memoria.Compartilhado
{
    public abstract class RepositorioBase<Tipo> where Tipo : EntidadeBase<Tipo>
    {
        protected List<Tipo> registros = new List<Tipo>();
        protected int contadorIds = 0;

        public void CadastrarRegistro(Tipo novoRegistro)
        {
            novoRegistro.Id = ++contadorIds;

            registros.Add(novoRegistro);
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
            for (int i = 0; i < registros.Count; i++)
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
