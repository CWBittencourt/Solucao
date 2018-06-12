using Gimba.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gimba.Business
{
    public class SocioBusiness
    {
      
        public SocioModel GetSocioPorId(long id)
        {

            try
            {
                using (var contexto = new GimbaContexto())
                {
                    var retorno = contexto.Database.SqlQuery<SocioModel>("exec sp_SocioLerPorId @IdSocio",
                         new SqlParameter("IdSocio", id)
                         ).ToList();

                    return retorno.Single<SocioModel>();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public long CriarSocio(SocioModel model)
        {
            try
            {
                using (var contexto = new GimbaContexto())
                {
                    var id = contexto.Database.SqlQuery<SocioModel>("exec sp_SocioCriar @Nome, @CPF",
                         new SqlParameter("Nome", model.Nome),
                         new SqlParameter("CPF", model.CPF)
                         ).ToList();

                    return Convert.ToInt64(id.Single().IdSocio);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void AtualizarSocio(SocioModel model)
        {
            try
            {
                using (var contexto = new GimbaContexto())
                {
                    var id = contexto.Database.SqlQuery<SocioModel>("exec sp_SocioAlterar @IdSocio, @Nome, @CPF",
                        new SqlParameter("IdSocio", model.IdSocio),
                         new SqlParameter("Nome", model.Nome),
                         new SqlParameter("CPF", model.CPF)
                         ).ToList();                   
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

               


        public void ExcluirSocio(long idSocio)
        {

        }
    }
}
