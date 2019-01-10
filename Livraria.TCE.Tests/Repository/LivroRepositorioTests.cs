using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Moq;
using System.Collections.Generic;
using Livraria.TCE.Context.Entidades;
using System.Linq;

namespace Livraria.TCE.Repository.Tests
{
    [TestClass()]
    public class LivroRepositorioTests
    {
        [TestMethod()]
        public void GetAllTest()
        {
            Mock<LivroRepositorio> repository = GerarDadosBase();
            var moqObject = repository.Object.GetAll();

            Assert.IsTrue(moqObject.Any());

        }       

        private static Mock<LivroRepositorio> GerarDadosBase()
        {
            var listaDeLivros = new List<Livro>();

            listaDeLivros.Add(
                 new Livro
                 {
                     Autor = "Teste1",
                     DataPublicacao = DateTime.Now,
                     ImagemCapa = new byte[12000],
                     ISBN = 12345,
                     Nome = "Livro1",
                     Preco = 45.0
                 }
                );
            listaDeLivros.Add(
                new Livro
                {
                    Autor = "Teste2",
                    DataPublicacao = DateTime.Now,
                    ImagemCapa = new byte[12000],
                    ISBN = 123456,
                    Nome = "Livro2",
                    Preco = 45.0
                }
               );
            var repository = new Mock<LivroRepositorio>();
            repository.Setup(m => m.GetAll()).Returns(listaDeLivros);
            return repository;
        }
    }
}