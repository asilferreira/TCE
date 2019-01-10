using Livraria.TCE.Context;
using Livraria.TCE.Context.Entidades;
using Livraria.TCE.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Livraria.TCE.Repository
{
    public class LivroRepositorio : IDisposable,
      ILivroRepositorio
    {
        EntityContext ctx = new EntityContext();

        // Adicionado o modificador "virtual" para a realização do Mock
        public virtual IEnumerable<Livro> GetAll() 
        {
            return ctx.Set<Livro>();
        }

        public  IEnumerable<Livro> Get(Func<Livro, bool> predicate)
        {
            return GetAll().Where(predicate);
        }

        public Livro Find(params object[] key)
        {
            return ctx.Set<Livro>().Find(key);
        }

        public void Atualizar(Livro obj)
        {
            ctx.Entry(obj).State = EntityState.Modified;
        }

        public void SalvarTodos()
        {
            ctx.SaveChanges();
        }

        public void Adicionar(Livro obj)
        {
            ctx.Set<Livro>().Add(obj);
        }

        public void Excluir(Func<Livro, bool> predicate)
        {
            ctx.Set<Livro>()
                .Where(predicate).ToList()
                .ForEach(del => ctx.Set<Livro>().Remove(del));
        }

        public void Dispose()
        {
            ctx.Dispose();
        }
    }
}