using Gimba.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gimba.Business
{
    public class ClienteBusiness
    {
        public List<ClienteModel> GetClientes()
        {
            try
            {
                using (var contexto = new GimbaContexto())
                {
                    var retorno = contexto.Database.SqlQuery<ClienteModel>("exec sp_ClienteLerTodos").ToList<ClienteModel>();

                    return retorno.ToList<ClienteModel>();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ClienteModel GetClientePorId(long id)
        {
            try
            {
                using (var contexto = new GimbaContexto())
                {
                    var retorno = contexto.Database.SqlQuery<ClienteModel>("exec sp_ClienteLerPorId @IdCliente",
                         new SqlParameter("IdCliente", id)
                         ).ToList();

                    return retorno.Single<ClienteModel>();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public long CriarCliente(ClienteModel model)
        {
            try
            {
                using (var contexto = new GimbaContexto())
                {

                    var retorno = contexto.Database.SqlQuery<ClienteModel>("exec sp_ClienteCriar @Nome, @CNPJ, @Ativo",
                         new SqlParameter("Nome", model.Nome),
                         new SqlParameter("CNPJ", model.CNPJ),
                         new SqlParameter("Ativo", model.Ativo)
                         ).ToList();

                    return Convert.ToInt64(retorno.Single().IdCliente);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public void AtualizarCliente(ClienteModel model)
        {
            try
            {
                using (var contexto = new GimbaContexto())
                {

                    contexto.Database.SqlQuery<ClienteModel>("exec sp_ClienteAlterar @IdCliente, @Nome, @CNPJ, @Ativo",
                        new SqlParameter("IdCliente", model.IdCliente),
                        new SqlParameter("Nome", model.Nome),
                        new SqlParameter("CNPJ", model.CNPJ),
                        new SqlParameter("Ativo", model.Ativo)
                        ).ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public void ExcluirCliente(long idCliente)
        {
            try
            {
                using (var contexto = new GimbaContexto())
                {
                    ClienteModel model = GetClientePorId(idCliente);

                    if ((bool)model.Ativo)
                    {
                        contexto.Database.SqlQuery<ClienteModel>("exec sp_ClienteExcluir @IdCliente",
                     new SqlParameter("IdCliente", idCliente)
                     ).ToList();
                    }
                    else
                    {
                        contexto.Database.SqlQuery<ClienteModel>("exec sp_ClienteIncluir @IdCliente",
                     new SqlParameter("IdCliente", idCliente)
                     ).ToList();
                    }

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
