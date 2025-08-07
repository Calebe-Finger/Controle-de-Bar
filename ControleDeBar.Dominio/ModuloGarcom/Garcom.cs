using ControleDeBar.Dominio.Compartilhado;

namespace ControleDeBar.Dominio.ModuloGarcom
{
    public class Garcom : EntidadeBase<Garcom>
    {
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public bool EstaOcupado { get; set; }

        public Garcom(string nome, string cpf)
        {
            Nome = nome;
            Cpf = cpf;
            EstaOcupado = false;
        }

        public void VincularPedido()
        {
            EstaOcupado = true;
        }

        public void TerminarPedido()
        {
            EstaOcupado = false;
        }

        public override void AtualizarRegistro(Garcom registroAtualizado)
        {
            Nome = registroAtualizado.Nome;
            Cpf = registroAtualizado.Cpf;
        }

        public override string Validar()
        {
            string erros = string.Empty;

            if (Nome.Length < 3 || Nome.Length > 100)
            {
                erros += "O atributo \"Nome\" deve conter entre 3 e 100 caracteres!";
            }

            if (Cpf == null)
            {
                erros += "O atributo \"CPF\" deve se adequar ao formato validado: XXX.XXX.XXX-XX";
            }

            return erros;
        }
    }
}
