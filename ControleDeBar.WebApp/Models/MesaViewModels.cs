using ControleDeBar.Dominio.ModuloMesa;
using System.ComponentModel.DataAnnotations;

namespace ControleDeBar.WebApp.Models
{

    public class CadastrarMesaViewModel
    {
        [Range(1, 1000, ErrorMessage = "O campo \"Número\" deve conter um valor entre 1 e 1000.")]
        public int Numero {  get; set; }

        [Range(1, 1000, ErrorMessage = "O campo \"Capacidade de Lugares\" deve conter um valor entre 1 e 1000.")]
        public int Capacidade { get; set; }

        public CadastrarMesaViewModel() { }
    }

    public class VisualizarMesasViewModel
    {
        public List<DetalhesMesaViewModel> Registros { get; set; } = new List<DetalhesMesaViewModel>();

        public VisualizarMesasViewModel(List<Mesa> mesas)
        {
            foreach (Mesa m in mesas)
            {
                DetalhesMesaViewModel detalhesVM = new DetalhesMesaViewModel(m.Id, m.Numero, m.Capacidade);

                Registros.Add(detalhesVM);
            }
        }
    }

    public class DetalhesMesaViewModel
    {
        public int Id { get; set; }
        public int Numero { get; set; }
        public int Capacidade { get; set; }

        public DetalhesMesaViewModel(int id, int numero, int capacidade)
        {
            Id = id;
            Numero = numero;
            Capacidade = capacidade;
        }
    }
}
