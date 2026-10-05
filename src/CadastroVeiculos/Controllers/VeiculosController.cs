using CadastroVeiculos.Models;
using CadastroVeiculos.Services;
using Microsoft.AspNetCore.Mvc;

namespace CadastroVeiculos.Controllers;

public class VeiculosController : Controller
{
    private readonly VeiculoService _service = new VeiculoService();

    // Veiculos ou /Veiculos?termo=abc
    public IActionResult Index(string? termo)
    {
        ViewBag.Termo = termo;
        var veiculos = _service.Pesquisar(termo);
        return View(veiculos);
    }

    //Veiculos/Cadastrar
    public IActionResult Cadastrar()
    {
        return View("Form", new Veiculo());
    }

    //Veiculos/Editar/5
    public IActionResult Editar(int id)
    {
        var veiculo = _service.BuscarPorId(id);
        if (veiculo == null)
        {
            TempData["Erro"] = "Veículo não encontrado.";
            return RedirectToAction("Index");
        }
        return View("Form", veiculo);
    }

    //Veiculos/Salvar (cadastro e edição)
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Salvar(Veiculo veiculo)
    {
        if (!ModelState.IsValid)
        {
            return View("Form", veiculo);
        }

        var erros = _service.Salvar(veiculo);
        if (erros.Count > 0)
        {
            foreach (var erro in erros)
            {
                ModelState.AddModelError(erro.Key, erro.Value);
            }
            return View("Form", veiculo);
        }

        TempData["Sucesso"] = "Veículo salvo com sucesso!";
        return RedirectToAction("Index");
    }

    //Veiculos/Excluir/5
    public IActionResult Excluir(int id)
    {
        var veiculo = _service.BuscarPorId(id);
        if (veiculo == null)
        {
            TempData["Erro"] = "Veículo não encontrado.";
            return RedirectToAction("Index");
        }
        return View(veiculo);
    }

    //Veiculos/Excluir/5
    [HttpPost, ActionName("Excluir")]
    [ValidateAntiForgeryToken]
    public IActionResult ConfirmarExclusao(int id)
    {
        _service.Excluir(id);
        TempData["Sucesso"] = "Veículo excluído com sucesso!";
        return RedirectToAction("Index");
    }
}