using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Livraria.TCE.Context.Entidades
{
    [Table("livro")]
    public class Livro
    {
        [Key]
        public int Id { get; set; }
        [Index(IsUnique = true)]
        public long ISBN { get; set; }
        public string Autor { get; set; }
        public string Nome { get; set; }
        public double Preco { get; set; }
        public DateTime DataPublicacao { get; set; }
        [Column("ImagemCapa", TypeName = "varbinary(max)")]
        public byte[] ImagemCapa { get; set; }
    }
}