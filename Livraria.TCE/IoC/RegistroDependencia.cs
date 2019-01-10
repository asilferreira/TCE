using Livraria.TCE.Context.Entidades;
using Livraria.TCE.Repository;
using Livraria.TCE.Repository.Interfaces;
using ProductStore.IoC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using Unity;
using Unity.Lifetime;

namespace Livraria.TCE.IoC
{
    public class RegistroDependencia
    {
        public static void RegistrarDependencias(UnityContainer container)
        {
            container.RegisterType<ILivroRepositorio, LivroRepositorio>(new HierarchicalLifetimeManager());

        }
    }
}