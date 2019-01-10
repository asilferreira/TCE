using Livraria.TCE.Context.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Livraria.TCE.Repository.Interfaces
{

    public interface ILivroRepositorio
    {
        IEnumerable<Livro> GetAll();
        IEnumerable<Livro> Get(Func<Livro, bool> predicate);
        Livro Find(params object[] key);
        void Atualizar(Livro obj);
        void SalvarTodos();
        void Adicionar(Livro obj);
        void Excluir(Func<Livro, bool> predicate);
    }

}
