using ControleDeBar.Dominio.Compartilhado;

namespace ControleDeBar.Dominio.ModuloProduto
{
    public class Produto : EntidadeBase<Produto>
    {
        public string Nome { get; set; }
        public decimal Preco { get; set; }

        public Produto(string nome, decimal preco)
        {
            Nome = nome;
            Preco = preco;
        }

        public override void AtualizarRegistro(Produto registroAtualizado)
        {
            Nome = registroAtualizado.Nome;
            Preco = registroAtualizado.Preco;
        }

        public override string Validar()
        {
            string erros = string.Empty;

            if (Nome.Length < 2 || Nome.Length > 100)
            {
                erros += "O atributo \"Nome\" deve conter entre 2 e 100 caracteres!";
            }

            if (Preco == 0.0m)
            {
                erros += "O atributo \"Preco\" deve conter um número positivo.";
            }

            return erros;
        }
    }
}
