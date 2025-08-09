using ControleDeBar.Dominio.ModuloMesa;

namespace ControleDeBar.WebApp.Models
{
    public class VisualizarMesasViewModel
    {
        public List<DetalhesMesaViewModel> Registros { get; set; } = new List<DetalhesMesaViewModel>();

        public VisualizarMesasViewModel(List<Mesa> mesas)
        {
            foreach (Mesa m in mesas)
            {
                DetalhesMesaViewModel detalherVM = new DetalhesMesaViewModel(m.Id, m.Numero, m.Capacidade);

                Registros.Add(detalherVM);
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
