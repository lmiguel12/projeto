using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NobelApi.Models
{
    public class FiliacaoDTO
    {
        public int FiliacaoId { get; set; }
        public string Nome { get; set; }
        public CidadeDTO Cidade{ get; set; }
    }
}