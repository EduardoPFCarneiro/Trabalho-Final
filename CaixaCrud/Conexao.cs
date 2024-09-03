using MySql.Data.MySqlClient;
public static class Conexao
{
    static MySqlConnection conexao; //Objeto responsável por controlar a conexão com a base de dados
    public static MySqlConnection Conectar()
    {
        try
        {
            /*
             Configuração da conexão com o banco de dados:
            - server irá definir o servidor que está o banco de dados
            -uid irá definir o nome do usuário do banco de dados
            -pwd irá definir a senha do usuário no SGBD
            -database irá definir o nome da base de dados
             */
            string strconexao = "server=localhost;port=3306;uid=root;pwd=root;database=caixaControl_bd";
            conexao = new MySqlConnection(strconexao);
            conexao.Open();
        }
        catch (Exception ex)
        {
            throw new Exception("FALHA AO CONECTAR COM O BANCO DE DADOS" + ex.Message);
        }
        return conexao;
    }

    public static void FecharConexao()
    {
        conexao.Close();
    }
}