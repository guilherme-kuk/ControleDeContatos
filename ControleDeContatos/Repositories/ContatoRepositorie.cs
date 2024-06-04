using ControleDeContatos.Data;
using ControleDeContatos.Models;

namespace ControleDeContatos.Repositories
{
    public class ContatoRepositorie : IContatoRepositorie
    {
        private readonly BancoContext _bancoContext;
        public ContatoRepositorie(BancoContext bancoContext)
        {
            this._bancoContext = bancoContext;
        }
        public ContatoModel ListarPorID(int id)
        {
            return _bancoContext.Contatos.FirstOrDefault(x => x.Id == id);
        }
        public List<ContatoModel> ListarContatos(int usuarioId)
        {

            return _bancoContext.Contatos.Where(x => x.UsuarioID == usuarioId).ToList();
        }

        public ContatoModel Adicionar(ContatoModel contato)
        {
            //gravar na base
            _bancoContext.Contatos.Add(contato);
            _bancoContext.SaveChanges();

            return contato;
        }

        public ContatoModel Atualizar(ContatoModel contato)
        {
            ContatoModel contatoDB = ListarPorID(contato.Id);

            if (contatoDB == null) throw new Exception("Houve um erro na atualização do contato!");
            contatoDB.Nome = contato.Nome;
            contatoDB.Email = contato.Email;
            contatoDB.Celular = contato.Celular;

            //Atualizar na base
            _bancoContext.Contatos.Update(contatoDB);
            _bancoContext.SaveChanges();

            return contatoDB;
        }

        public bool Apagar(int id)
        {
            ContatoModel contatoDB = ListarPorID(id);
            if (contatoDB == null) throw new Exception("Houve um erro ao deletar o contato!");

            //Deletar da base
            _bancoContext.Contatos.Remove(contatoDB);
            _bancoContext.SaveChanges();

            return true;
        }
    }
}
