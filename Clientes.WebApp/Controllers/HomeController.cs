using Clientes.Shared.InputModels;
using Clientes.Shared.ValueObject;
using Clientes.WebApp.Models;
using Clientes.WebApp.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Clientes.WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        protected readonly IClienteServices _clienteServices;
        protected readonly ICidadeServices _cidadeServices;

        public HomeController(ILogger<HomeController> logger, IClienteServices clienteServices, ICidadeServices cidadeServices)
        {
            _logger = logger;
            _clienteServices = clienteServices;
            _cidadeServices = cidadeServices;
        }

        public async Task<IActionResult> Index()
        {
            var viewModel = new IndexViewModel();
            viewModel.Clientes = await _clienteServices.GetList(viewModel.Filtro);
            viewModel.Estados = _cidadeServices.GetEstados();
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index([Bind] IndexViewModel viewModel)
        {
            viewModel.Clientes = await _clienteServices.GetList(viewModel.Filtro);
            viewModel.Estados = _cidadeServices.GetEstados();
            if (viewModel.Filtro.Estado.HasValue)
                viewModel.Cidades = await _cidadeServices.GetCidades(viewModel.Filtro.Estado.Value);

            return View(viewModel);
        }

        public async Task<IActionResult> Adicionar()
        {
            await CarregarEstados();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Adicionar([Bind] CreateClienteInput input)
        {
            var response = await _clienteServices.Create(input);
            if (response.Ok)
                return RedirectToAction("Index");

            await CarregarEstados();
            return View(input);
        }

        public async Task<IActionResult> Editar(int id)
        {
            var cliente = await _clienteServices.GetById(id);
            await CarregarEstados();
            await CarregarCidades(cliente.Estado);
            return View(new UpdateClienteInput(cliente.Id, cliente.Nome, cliente.Cpf, cliente.DataNascimento, cliente.Sexo, cliente.Endereco, cliente.CodigoCidade, cliente.Estado));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Editar([Bind] UpdateClienteInput input)
        {
            var response = await _clienteServices.Update(input);
            if (response.Ok)
                return RedirectToAction("Index");
            await CarregarEstados();
            await CarregarCidades(input.Estado);
            return View(input);
        }

        public async Task<IActionResult> Excluir(int id)
        {
            var cliente = await _clienteServices.GetById(id);
            return View(cliente);
        }

        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ComfirmarExcluir(int id)
        {
            var response = await _clienteServices.Delete(id);
            if (response.Ok)
                return RedirectToAction("Index");

            var cliente = await _clienteServices.GetById(id);
            return View(cliente);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public async Task<IActionResult> Cidades(EstadoEnum estado)
        {
            var cidades = await _cidadeServices.GetCidades(estado);
            return Json(cidades);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        private async Task CarregarEstados()
        {
            ViewData["estados"] = _cidadeServices.GetEstados();
        }

        private async Task CarregarCidades(EstadoEnum estado)
        {
            ViewData["cidades"] = await _cidadeServices.GetCidades(estado);
        }
    }
}