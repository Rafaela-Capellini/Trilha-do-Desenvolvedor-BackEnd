namespace AcaiConnUnificada.Models
{
    public interface IProdutosDB
    {
        List<Produto> getList();
        void insert(Produto produto);
        void update(Produto produto);
        void delete(string id);
        Produto getById(string id);
    }
}
