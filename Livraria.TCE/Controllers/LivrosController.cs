using System;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using Livraria.TCE.Context.Entidades;
using Livraria.TCE.Repository;
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
        public IHttpActionResult GetLivrosByNome(string value)
        {
            try
            {
                var livros = LivroRepositorio
                    .Get(g => value.Equals(g.Nome))
                    .OrderBy(o => o.Nome);

                if (livros.Any()) return Ok(livros);
                else return NotFound();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }

        [Route("ByAutor")]
        [HttpGet]
        public IHttpActionResult GetLivrosByAutor(string value)
        {
            try
            {
                var livros = LivroRepositorio
                    .Get(g => value.Equals(g.Autor))
                    .OrderBy(o => o.Autor);

                if (livros.Any()) return Ok(livros);
                else return NotFound();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }

        [Route("ByISBN")]
        [HttpGet]
        public IHttpActionResult GetLivrosByISBN(string value)
        {
            try
            {
                var livros = LivroRepositorio.Get(g => value.Equals(g.ISBN.ToString()));
                if (livros.Any()) return Ok(livros);
                else return NotFound();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }

        [Route("ByData")]
        [HttpGet]
        public IHttpActionResult GetLivrosByData(string value)
        {
            try
            {
                var livros = LivroRepositorio
                    .Get(g => value.Equals(g.DataPublicacao.ToShortDateString()))
                    .OrderBy(o => o.DataPublicacao);

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