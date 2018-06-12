using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gimba.Model
{
    [NotMapped]
    public class ClienteModelDTO
    {
        public ClienteModelDTO()
        {
            this.Socios = new List<SocioModel>();
            this.Endereco = new EnderecoModel();
        }
        public ClienteModel Cliente { get; set; }
        public List<SocioModel> Socios { get; set; }
        public EnderecoModel Endereco { get; set; }
    }
}
