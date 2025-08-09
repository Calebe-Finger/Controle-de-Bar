using ControleDeBar.Dominio.ModuloMesa;
using ControleDeBar.Infraestrutura.Arquivos.Compartilhado;
using ControleDeBar.Infraestrutura.Arquivos.ModuloMesa;
using ControleDeBar.WebApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace ControleDeBar.WebApp.Controllers
{
    public class MesaController : Controller
    {
        private readonly RepositorioMesaEmArquivo repositorioMesa;

        public MesaController()
        {
            ContextoDados contexto = new ContextoDados(carregarDados: true);

            repositorioMesa = new RepositorioMesaEmArquivo(contexto);
        }

        public IActionResult Index()
        {
            List<Mesa> mesas = repositorioMesa.SelecionarRegistros();

            VisualizarMesasViewModel visualizarVM = new VisualizarMesasViewModel(mesas);

            return View(visualizarVM);
        }
    }
}
