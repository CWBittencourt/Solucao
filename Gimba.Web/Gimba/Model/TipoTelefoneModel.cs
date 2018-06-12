using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gimba.Model
{
    [Table("TipoTelefone")]
    public class TipoTelefoneModel : IValidatableObject
    {
        [Key]
        [Column("IdTipoTelefone")]
        public long IdTipoTelefone { get; set; }


        [Column("Descricao")]
        public String Descricao { get; set; }


        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            throw new NotImplementedException();
        }
    }
}
