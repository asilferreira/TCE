using System;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using Livraria.TCE.Context.Entidades;
using Livraria.TCE.Repository.Interfaces;
using Unity.Attributes;

namespace Livraria.TCE.Controllers
{
    [RoutePrefix("api/Livros")]
    public class LivrosController : ApiController
    {
        [Dependency]
        public ILivroRepositorio LivroRepositorio { get; set; }

        // GET: api/Livros
        [HttpGet]
        public IHttpActionResult GetLivros()
        {
            try
            {
                var lista = LivroRepositorio.GetAll();
                if (lista.Any()) return Ok(lista);
                else return NotFound();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: api/Livros/5
        [HttpGet]
        public IHttpActionResult GetLivro(int id)
        {
            try
            {
                Livro livro = LivroRepositorio.Find(id);
                if (livro == null)
                    return NotFound();

                return Ok(livro);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [Route("ByNome")]
        [HttpGet]
        public IHttpActionResult GetLivrosByCriterio(string value)
        {
            try
            {
                var livros = LivroRepositorio.Get(g => value.Equals(g.Nome));
                if (livros.Any()) return Ok(livros);
                else return NotFound();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }

        // PUT: api/Livros/5
        [HttpPut]
        public IHttpActionResult PutLivro(Livro livro)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            LivroRepositorio.Atualizar(livro);
            LivroRepositorio.SalvarTodos();

            return Ok();
        }

        // POST: api/Livros
        [HttpPost]
        public IHttpActionResult PostLivro(Livro livro)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                LivroRepositorio.Adicionar(livro);
                LivroRepositorio.SalvarTodos();

                return Ok(livro);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }


        // DELETE: api/Livros/5
        [HttpDelete]
        public IHttpActionResult DeleteLivro(int id)
        {
            Livro livro = LivroRepositorio.Find(id);
            if (livro == null)
                return NotFound();

            LivroRepositorio.Excluir(e => e.Id.Equals(id));
            LivroRepositorio.SalvarTodos();

            return Ok(livro);
        }
    }
}