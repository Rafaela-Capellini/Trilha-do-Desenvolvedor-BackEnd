using AcaiConnUnificada.Data;
using System.Data.SqlClient;
using System.Runtime.Intrinsics.X86;

namespace AcaiConnUnificada.Models
{
    public class ProdutosDB : IProdutosDB
    {
        private readonly IConexaoSql _conexao;

        public ProdutosDB(IConexaoSql conexao)
        {
            _conexao = conexao;
        }

        public List<Produto> getList()
        {
            List<Produto> aux = new List<Produto>();

            using (SqlConnection conn = _conexao.getConexao())
            {
                // Criando a instrução para executar no banco
                string query = "Select * From Produtos";

                // Criando um objeto command para executar a instrução
                SqlCommand cmd = new SqlCommand(query, conn);

                // Abrindo a conexão com o banco de dados
                conn.Open();

                // Usando objeto DataReader para obter os dados
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    // Enquanto conseguir ler alguma linha da tabela...
                    while (reader.Read())
                    {
                        // Criar um produto novo
                        Produto p = new Produto();
                        p.Id = new Guid(reader["Id"].ToString());
                        p.Nome = reader["Nome"].ToString();
                        p.Descricao = reader["Descricao"].ToString();
                        p.Preco = decimal.Parse(reader["Preco"].ToString());

                        // Adicionando o novo objeto à lista Aux
                        aux.Add(p);
                    }
                }

                // Fechando a conexão com o banco de dados
                conn.Close();
            }
            return aux;
        }

        public Produto getById(string id)
        {
            Produto p = new Produto();

            using (SqlConnection conn = _conexao.getConexao())
            {
                // Criando a instrução para executar no banco
                string query = "Select * From Produtos Where Id=@Id";

                // Criando um objeto command para executar a instrução
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Id", id);

                // Abrindo a conexão com o banco de dados
                conn.Open();

                // Usando objeto DataReader para obter os dados
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    // Enquanto conseguir ler alguma linha da tabela...
                    while (reader.Read())
                    {
                        // Criar um produto novo                        
                        p.Id = new Guid(reader["Id"].ToString());
                        p.Nome = reader["Nome"].ToString();
                        p.Descricao = reader["Descricao"].ToString();
                        p.Preco = decimal.Parse(reader["Preco"].ToString());
                    }
                }

                // Fechando a conexão com o banco de dados
                conn.Close();
            }
            return p;
        }

        public void insert(Produto produto)
        {
            using (SqlConnection conn = _conexao.getConexao())
            {
                // Criando a instrução para executar no banco
                string stmt = "Insert Into Produtos (Id, Nome, Descricao, Preco) " +
                               "Values (@Id, @Nome, @Descricao, @Preco)";

                // Criando um objeto command para executar a instrução
                SqlCommand cmd = new SqlCommand(stmt, conn);
                cmd.Parameters.AddWithValue("@Id", produto.Id);
                cmd.Parameters.AddWithValue("@Nome", produto.Nome);
                cmd.Parameters.AddWithValue("@Descricao", produto.Descricao);
                cmd.Parameters.AddWithValue("@Preco", produto.Preco);

                // Abrindo a conexão com o banco de dados
                conn.Open();

                // Executando a instrução no banco de dados
                cmd.ExecuteNonQuery();

                // Fechando a conexão com o banco de dados
                conn.Close();
            }
        }

        public void update(Produto produto)
        {
            using (SqlConnection conn = _conexao.getConexao())
            {
                // Criando a instrução para executar no banco
                string stmt = "Update Produtos " +
                               "Set  Nome = @Nome, " +
                                    "Descricao = @Descricao, " +
                                    "Preco = @Preco " +
                                "Where Id = @Id";

                // Criando um objeto command para executar a instrução
                SqlCommand cmd = new SqlCommand(stmt, conn);
                cmd.Parameters.AddWithValue("@Id", produto.Id);
                cmd.Parameters.AddWithValue("@Nome", produto.Nome);
                cmd.Parameters.AddWithValue("@Descricao", produto.Descricao);
                cmd.Parameters.AddWithValue("@Preco", produto.Preco);

                // Abrindo a conexão com o banco de dados
                conn.Open();

                // Executando a instrução no banco de dados
                cmd.ExecuteNonQuery();

                // Fechando a conexão com o banco de dados
                conn.Close();
            }
        }

        public void delete(string id)
        {
            using (SqlConnection conn = _conexao.getConexao())
            {
                // Criando a instrução para executar no banco
                string stmt = "Delete from Produtos Where Id = @Id";

                // Criando um objeto command para executar a instrução
                SqlCommand cmd = new SqlCommand(stmt, conn);
                cmd.Parameters.AddWithValue("@Id", id);

                // Abrindo a conexão com o banco de dados
                conn.Open();

                // Executando a instrução no banco de dados
                cmd.ExecuteNonQuery();

                // Fechando a conexão com o banco de dados
                conn.Close();
            }
        }
    }
}
