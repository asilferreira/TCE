using Livraria.TCE.Context.Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Livraria.TCE.Context
{
    public class EntityContext : DbContext
    {
        public EntityContext()
        {
            this.Database.CreateIfNotExists();   
        }
        public DbSet<Livro> Livros { get; set; }
    }
}