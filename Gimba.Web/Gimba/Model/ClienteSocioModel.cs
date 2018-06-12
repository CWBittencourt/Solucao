using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gimba.Model
{
    [Table("ClienteSocio")]
    public class ClienteSocioModel : IValidatableObject
    {
        [Key]
        [Column("IdClienteSocio")]
        public long IdClienteSocio { get; set; }

        [Column("IdCliente")]
        public long IdCliente { get; set; }

        [Column("IdSocio")]
        public long IdSocio { get; set; }


        public virtual ClienteModel Cliente { get; set; }

        public virtual SocioModel Socio { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            throw new NotImplementedException();
        }
    }
}
