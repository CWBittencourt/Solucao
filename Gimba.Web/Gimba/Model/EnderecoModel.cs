using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gimba.Model
{
    [Table("Endereco")]
    public class EnderecoModel : IValidatableObject
    {
        [Key]
        [Column("IdCliente")]
        public long IdCliente { get; set; }

        [Column("CEP")]
        public String CEP { get; set; }

        [Column("UF")]
        public String UF { get; set; }

        [Column("Cidade")]
        public String Cidade { get; set; }

        [Column("Bairro")]
        public String Bairro { get; set; }

        [Column("TipoLogradouro")]
        public String TipoLogradouro { get; set; }

        [Column("Logradouro")]
        public String Logradouro { get; set; }

        [Column("Numero")]
        public String Numero { get; set; }

        [Column("Complemento")]
        public String Complemento { get; set; }

        [NotMapped]
        public String Resultado { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if(Resultado!=null)
            {
                yield return new ValidationResult("");
            }

            if(string.IsNullOrEmpty(this.Bairro) || string.IsNullOrWhiteSpace(this.Bairro))
            {
                yield return new ValidationResult("Informe o Bairro");
            }

            if (string.IsNullOrEmpty(this.CEP) || string.IsNullOrWhiteSpace(this.CEP))
            {
                yield return new ValidationResult("Informe o CEP");
            }

            if (string.IsNullOrEmpty(this.Cidade) || string.IsNullOrWhiteSpace(this.Cidade))
            {
                yield return new ValidationResult("Informe a Cidade");
            }

            if (string.IsNullOrEmpty(this.Logradouro) || string.IsNullOrWhiteSpace(this.Logradouro))
            {
                yield return new ValidationResult("Informe o Logradouro");
            }

            if (string.IsNullOrEmpty(this.Numero) || string.IsNullOrWhiteSpace(this.Numero))
            {
                yield return new ValidationResult("Informe o Número");
            }

            if (string.IsNullOrEmpty(this.TipoLogradouro) || string.IsNullOrWhiteSpace(this.TipoLogradouro))
            {
                yield return new ValidationResult("Informe o Tipo de Logradouro");
            }
        }
    }
}
