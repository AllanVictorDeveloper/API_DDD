namespace Dominio.Interfaces.Genericas
{
    public interface IGenerico<T> where T : class
    {
        Task Adicionar(T Objeto);

        Task Atualizar(T Objeto);

        Task Deletar(T Objeto);

        Task<IEnumerable<T>> ListarTudo();

        Task<T> ListarPorId(int id);
    }
}