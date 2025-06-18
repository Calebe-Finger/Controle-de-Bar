namespace ControleDeBar.ConsoleApp.Compartilhado
{
    public abstract class EntidadeBase<Tipo>
    {
        public int Id { get; set; }

        public abstract void AtualizarRegistro(Tipo registroAtualizado);
        public abstract string Validar();
    }
}
