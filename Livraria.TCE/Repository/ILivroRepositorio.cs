using Livraria.TCE.Context.Entidades;
using System;
using System.Linq;

namespace Livraria.TCE.Repository.Interfaces
{

    public interface ILivroRepositorio
    {
        IQueryable<Livro> GetAll();
        IQueryable<Livro> Get(Func<Livro, bool> predicate);
        Livro Find(params object[] key);
        void Atualizar(Livro obj);
        void SalvarTodos();
        void Adicionar(Livro obj);
        void Excluir(Func<Livro, bool> predicate);
    }

}
