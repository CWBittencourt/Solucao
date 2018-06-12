using Gimba.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gimba.Business
{
    public class EmailBusiness
    {
    
        public List<EmailModel> GetEmailPorIdCliente(long id)
        {
            try
            {
                using (var contexto = new GimbaContexto())
                {
                    var retorno = contexto.Database.SqlQuery<EmailModel>("exec sp_EmailLerPorId @IdCliente",
                         new SqlParameter("IdCliente", id)
                         ).ToList();

                    return retorno.ToList<EmailModel>();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void CriarEmail(EmailModel model)
        {
            try
            {
                using (var contexto = new GimbaContexto())
                {
                   contexto.Database.SqlQuery<EmailModel>("exec sp_EmailCriar @IdCliente, @Email",
                         new SqlParameter("IdCliente", model.IdCliente),
                         new SqlParameter("Email", model.Email)
                         ).ToList();
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void AtualizarEmail(EmailModel model)
        {
            try
            {
                using (var contexto = new GimbaContexto())
                {
                    var id = contexto.Database.SqlQuery<EmailModel>("exec sp_EmailAlterar @IdEmail, @IdCliente, @Email",
                        new SqlParameter("IdEmail", model.IdEmail),
                         new SqlParameter("IdCliente", model.IdCliente),
                         new SqlParameter("Email", model.Email)
                         );
                 
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ExcluirEmail(long idEmail)
        {

        }
    }
}
