using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Domain
{
    public class Livro
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string ISBN { get; set; }
        public int Ano { get; set; }

        [JsonIgnore]
        public virtual Autor Autor { get; set; }
        public int AutorId { get; set; }
    }
}
