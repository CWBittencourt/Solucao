using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gimba.Model;
using System.Data.SqlClient;

namespace Gimba.Business
{
    public class TelefoneBusiness
    {

        public List<TelefoneModel> GetTelefonePorIdCliente(long id)
        {
            try
            {
                using (var contexto = new GimbaContexto())
                {
                    var retorno = contexto.Database.SqlQuery<TelefoneModel>("exec sp_TelefoneLerPorId @IdCliente",
                         new SqlParameter("IdCliente", id)
                         ).ToList();

                    return retorno.ToList<TelefoneModel>();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void CriarTelefone(TelefoneModel model)
        {
            try
            {
                using (var contexto = new GimbaContexto())
                {
                   contexto.Database.SqlQuery<TelefoneModel>("exec sp_TelefoneCriar @IdTipoTelefone, @DDD, @Numero, @IdCliente",
                            new SqlParameter("IdTipoTelefone", model.IdTipoTelefone),
                            new SqlParameter("DDD", model.DDD),
                            new SqlParameter("Numero", model.Numero),
                            new SqlParameter("IdCliente", model.IdCliente)
                         ).ToList();

                  
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void AtualizarTelefone(TelefoneModel model)
        {
            try
            {
                using (var contexto = new GimbaContexto())
                {
                    var id = contexto.Database.SqlQuery<TelefoneModel>("exec sp_TelefoneAlterar @IdTelefone, @IdTipoTelefone, @DDD, @Numero",
                            new SqlParameter("IdTelefone", model.IdTelefone),
                            new SqlParameter("IdTipoTelefone", model.IdTipoTelefone),
                            new SqlParameter("DDD", model.DDD),
                            new SqlParameter("Numero", model.Numero)
                         ).ToList();

                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ExcluirTelefone(long idTelefone)
        {

        }
    }
}
