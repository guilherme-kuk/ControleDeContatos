using ControleDeContatos.Models;

namespace ControleDeContatos.Repositories
{
    public interface IUsuarioRepositorie
    {
        UsuarioModel BuscarPorLogin(string login);
        UsuarioModel BuscarPorEmaileLogin(string email, string login);
        UsuarioModel ListarPorID(int id);
        List<UsuarioModel> ListarUsuarios();
        UsuarioModel Adicionar(UsuarioModel usuario);
        UsuarioModel Atualizar(UsuarioModel usuario);
        UsuarioModel AlterarSenha(AlterarSenhaModel alterarSenha);
        bool Apagar(int id);
    }
}
