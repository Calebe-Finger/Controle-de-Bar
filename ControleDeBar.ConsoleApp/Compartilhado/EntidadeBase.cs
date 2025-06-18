namespace ControleDeBar.ConsoleApp.Compartilhado
{
    public abstract class EntidadeBase
    {
        public int Id { get; set; }

        public abstract void AtualizarRegistro(EntidadeBase registroAtualizado);
        public abstract string Validar();
    }
}
