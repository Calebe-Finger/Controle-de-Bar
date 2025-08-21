using ControleDeBar.Dominio.ModuloGarcom;
using System.ComponentModel.DataAnnotations;

namespace ControleDeBar.WebApp.Models
{
    public class CadastrarGarcomViewModel
    {
        [Required(ErrorMessage = "O campo \"Nome\" é obrigatório.")]
        [MinLength(2, ErrorMessage = "O campo \"Nome\" deve conter ao menos dois caracteres.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo \"CPF\" é obrigatório.")]
        [RegularExpression(@"^\d{3}\.\d{3}\.\d{3}-\d{2}$", 
            ErrorMessage = "O campo \"CPF\" deve seguir o formato XXX.XXX.XXX-XX")]
        public string Cpf { get; set; }

        public CadastrarGarcomViewModel() {}
    }

    public class EditarGarcomViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo \"Nome\" é obrigatório.")]
        [MinLength(2, ErrorMessage = "O campo \"Nome\" deve conter ao menos dois caracteres.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo \"CPF\" é obrigatório.")]
        [RegularExpression(@"^\d{3}\.\d{3}\.\d{3}-\d{2}$",
            ErrorMessage = "O campo \"CPF\" deve seguir o formato XXX.XXX.XXX-XX")]
        public string Cpf { get; set; }

        public EditarGarcomViewModel() {}

        public EditarGarcomViewModel(int id, string nome, string cpf)
        {
            Id = id;
            Nome = nome;
            Cpf = cpf;
        }
    }

    public class ExcluirGarcomViewModel
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public ExcluirGarcomViewModel() { }

        public ExcluirGarcomViewModel(int id, string nome)
        {
            Id = id;
            Nome = nome;
        }
    }

    public class VisualizarGarconsViewModel
    {
        public List<DetalhesGarcomViewModel> Registros { get; set; } = new List<DetalhesGarcomViewModel>();

        public VisualizarGarconsViewModel(List<Garcom> garcons)
        {
            foreach (Garcom g in garcons)
            {
                DetalhesGarcomViewModel detalhesVm = new DetalhesGarcomViewModel(g.Id, g.Nome, g.Cpf);

                Registros.Add(detalhesVm);
            }
        }
    }

    public class DetalhesGarcomViewModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }

        public DetalhesGarcomViewModel(int id, string nome, string cpf)
        {
            Id = id;
            Nome = nome;
            Cpf = cpf;
        }
    }
}