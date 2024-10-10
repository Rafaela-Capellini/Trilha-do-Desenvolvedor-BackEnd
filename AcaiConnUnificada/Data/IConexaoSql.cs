using System.Data.SqlClient;

namespace AcaiConnUnificada.Data
{
	public interface IConexaoSql
	{
		SqlConnection getConexao();
	}
}
