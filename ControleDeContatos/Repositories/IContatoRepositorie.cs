using ControleDeContatos.Models;

namespace ControleDeContatos.Repositories
{
    public interface IContatoRepositorie
    {
        List<ContatoModel> ListarContatos(int usuarioId);
        ContatoModel ListarPorID(int id);
        ContatoModel Adicionar(ContatoModel contato);
        ContatoModel Atualizar(ContatoModel contato);
        bool Apagar(int id);
    }
}
