using ControleDeContatos.Helper;
using ControleDeContatos.Models;
using ControleDeContatos.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace ControleDeContatos.Controllers
{
    public class AlterarSenhaController : Controller
    {
        private readonly IUsuarioRepositorie _usuarioRepositorie;
        private readonly ISessao _sessao;

        public AlterarSenhaController(IUsuarioRepositorie usuarioRepositorie,
                                      ISessao sessao)
        {
            _usuarioRepositorie = usuarioRepositorie;
            _sessao = sessao;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Alterar(AlterarSenhaModel alterarSenha)
        {
            try
            {
                UsuarioModel usuarioLogado = _sessao.BuscarSessaoDoUsuario();
                alterarSenha.Id = usuarioLogado.Id;

                if (ModelState.IsValid)
                {
                    _usuarioRepositorie.AlterarSenha(alterarSenha);
                    TempData["MensagemSucesso"] = "Senha alterada com sucesso!";
                    return View("Index", alterarSenha);
                }

                return View("Index", alterarSenha);
            }
            catch (Exception ex)
            {
                TempData["MensagemErro"] = $"{ex.Message}";
                return View("Index", alterarSenha);
            }
        }
    }
}
