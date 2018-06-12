using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gimba.Model;
using System.Data;
using System.Data.SqlClient;

namespace Gimba.Business
{
    public class EnderecoBusiness
    {

        public void CriarEndereco(EnderecoModel model)
        {
            try
            {
                using (var contexto = new GimbaContexto())
                {
                    contexto.Database.SqlQuery<EnderecoModel>("exec sp_EnderecoCriar @IdCliente, @UF, @Cidade, @Bairro, @TipoLogradouro, @Logradouro, @Numero, @Complemento, @CEP",
                        new SqlParameter("IdCliente", model.IdCliente),
                        new SqlParameter("UF", string.IsNullOrEmpty(model.UF) ? (object)DBNull.Value :model.UF),
                        new SqlParameter("Cidade", model.Cidade),
                        new SqlParameter("Bairro", model.Bairro),
                        new SqlParameter("TipoLogradouro", model.TipoLogradouro),
                        new SqlParameter("Logradouro", model.Logradouro),
                        new SqlParameter("Numero", model.Numero),
                        new SqlParameter("Complemento", string.IsNullOrEmpty(model.Complemento) ? (object)DBNull.Value : model.Complemento),
                        new SqlParameter("CEP", model.CEP)
                        ).ToList();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
          
        }

        public void AlterarEndereco(EnderecoModel model)
        {
            try
            {
                using (var contexto = new GimbaContexto())
                {
                    contexto.Database.SqlQuery<EnderecoModel>("exec sp_EnderecoAlterar @IdCliente, @UF, @Cidade, @Bairro, @TipoLogradouro, @Logradouro, @Numero, @Complemento, @CEP",
                        new SqlParameter("IdCliente", model.IdCliente),
                        new SqlParameter("UF", model.UF),
                        new SqlParameter("Cidade", model.Cidade),
                        new SqlParameter("Bairro", model.Bairro),
                        new SqlParameter("TipoLogradouro", model.TipoLogradouro),
                        new SqlParameter("Logradouro", model.Logradouro),
                        new SqlParameter("Numero", model.Numero),
                        new SqlParameter("Complemento", model.Complemento),
                        new SqlParameter("CEP", model.CEP)
                        ).ToList();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public EnderecoModel GetEnderecoPorIdCliente(long idCliente)
        {
            using (var contexto = new GimbaContexto())
            {
                var retorno = contexto.Database.SqlQuery<EnderecoModel>("exec sp_EnderecoLerPorId @IdCliente",
                    new SqlParameter("IdCliente", idCliente)
                    ).ToList();

                return retorno.Single<EnderecoModel>();
            }
        }

        public EnderecoModel GetEnderecoPorCEP(string CEP)
        {
            EnderecoModel endereco = new EnderecoModel();

            string _resultado = "0";

            //Cria um DataSet  baseado no retorno do XML  
            DataSet ds = new DataSet();
            ds.ReadXml("http://cep.republicavirtual.com.br/web_cep.php?cep=" + CEP.Replace("-", "").Trim() + "&formato=xml");
            //ds.ReadXml("https://viacep.com.br/ws/" + CEP + "/xml");

            if (ds != null)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    _resultado = ds.Tables[0].Rows[0]["resultado"].ToString();
                    switch (_resultado)
                    {
                        case "1":
                            endereco.UF = ds.Tables[0].Rows[0]["uf"].ToString().Trim();
                            endereco.Cidade = ds.Tables[0].Rows[0]["cidade"].ToString().Trim();
                            endereco.Bairro = ds.Tables[0].Rows[0]["bairro"].ToString().Trim();
                            endereco.TipoLogradouro = ds.Tables[0].Rows[0]["tipo_logradouro"].ToString().Trim();
                            endereco.Logradouro = ds.Tables[0].Rows[0]["logradouro"].ToString().Trim();
                            endereco.Resultado = "CEP completo";
                            endereco.CEP = CEP;
                            break;
                        case "2":
                            endereco.UF = ds.Tables[0].Rows[0]["uf"].ToString().Trim();
                            endereco.Cidade = ds.Tables[0].Rows[0]["cidade"].ToString().Trim();
                            endereco.Bairro = "";
                            endereco.TipoLogradouro = "";
                            endereco.Logradouro = "";
                            endereco.Resultado = "CEP  único";
                            endereco.CEP = CEP;
                            break;
                        default:
                            endereco.UF = "";
                            endereco.Cidade = "";
                            endereco.Bairro = "";
                            endereco.TipoLogradouro = "";
                            endereco.Logradouro = "";
                            endereco.Resultado = "CEP não  encontrado";
                            endereco.CEP = CEP;
                            break;
                    }
                }
            }

            return endereco;

        }

    }
}
