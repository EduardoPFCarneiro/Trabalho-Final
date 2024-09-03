using CaixaCrud.Modelo;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaixaCrud.DAO
{
    internal class CaixaDAO
    {
        public void Insert(Caixa caixa)
        {
            try
            {
                Funcionario func = new Funcionario();
                func.Id_fun = 1;
                caixa.funcionario = func;
                string sql = "INSERT INTO Caixa(saldoInicial_cai,totalEntradas_cai,totalSaidas_cai,status_cai,id_fun_fk) VALUES (@saldoInicial,@Entradas,@Saidas,@status,@Funcionario)";
                MySqlCommand comando = new MySqlCommand(sql, Conexao.Conectar());
                comando.Parameters.AddWithValue("@saldoInicial", caixa.SaldoInicial_cai);
                comando.Parameters.AddWithValue("@Entradas", caixa.TotalEntradas_cai);
                comando.Parameters.AddWithValue("@Saidas", caixa.TotalSaidas_cai);
                comando.Parameters.AddWithValue("@status", caixa.Status_cai);
                comando.Parameters.AddWithValue("@Funcionario", caixa.funcionario.Id_fun);
                comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao cadastrar Caixa! {ex.Message}");
            }
            finally
            {
                Conexao.FecharConexao();
            }
        }

        public void Delete(Caixa caixa)
        {
            try
            {
                string sql = "Delete From Caixa where id_cai = @id";
                MySqlCommand comando = new MySqlCommand(sql, Conexao.Conectar());
                comando.Parameters.AddWithValue("@id", caixa.Id_cai);
                comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao deletar Caixa! {ex.Message}");
            }
            finally
            {
                Conexao.FecharConexao();
            }
        }

        public void Update(Caixa caixa)
        {
            try
            {
                string sql = "Update Caixa SET saldoInicial_cai = @saldo, totalEntradas_cai = @entradas, totalSaidas_cai = @saidas, status_cai = @status, id_fun_fk = @funcionario where id_cai = @id";
                MySqlCommand comando = new MySqlCommand(sql, Conexao.Conectar());
                comando.Parameters.AddWithValue("@id", caixa.Id_cai);
                comando.Parameters.AddWithValue("@saldo", caixa.SaldoInicial_cai);
                comando.Parameters.AddWithValue("@entradas", caixa.TotalEntradas_cai);
                comando.Parameters.AddWithValue("@saidas", caixa.TotalSaidas_cai);
                comando.Parameters.AddWithValue("@status", caixa.Status_cai);
                comando.Parameters.AddWithValue("@funcionario", caixa.funcionario.Id_fun);
                comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao atualizar Caixa! {ex.Message}");
            }
            finally
            {
                Conexao.FecharConexao();
            }
        }

        public List<Caixa> List()
        {
            List<Caixa> caixas = new List<Caixa>();

            try
            {
                var sql = "Select * From Caixa as c INNER JOIN Funcionario as f on c.id_fun_fk = f.id_fun";
                MySqlCommand comando = new MySqlCommand(sql, Conexao.Conectar());
                using (MySqlDataReader dr = comando.ExecuteReader())
                {
                    while (dr.Read())
                    {                       
                        Caixa caixa = new Caixa();

                        caixa.Id_cai = dr.GetInt32("id_cai");
                        caixa.SaldoInicial_cai = dr.GetInt32("saldoInicial_cai");
                        caixa.TotalEntradas_cai = dr.GetDouble("totalEntradas_cai");
                        caixa.TotalSaidas_cai = dr.GetDouble("totalSaidas_cai");
                        caixa.Status_cai = dr.GetString("status_cai");
                        caixa.funcionario = new Funcionario {
                            Id_fun = dr.GetInt32("id_fun"),
                            Nome_fun = dr.GetString("nome_fun"),
                            Cpf_fun = dr.GetString("cpf_fun"),
                        };

                        caixas.Add(caixa);
                    }
                }

            }
            catch (Exception ex)
            {
                throw new Exception("Erro na busca " + ex.Message);
            }
            finally
            {
                Conexao.FecharConexao();
            }
            return caixas;
        }

    }
}