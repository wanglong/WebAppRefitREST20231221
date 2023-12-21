using Refit;

namespace WebAppRefitREST.Infrastructure
{
    /// <summary>
    /// Using generic interfaces.
    /// </summary>
    /// <typeparam name="T">T.</typeparam>
    /// <typeparam name="TKey">TKey.</typeparam>
    public interface IReallyExcitingCrudApi<T, in TKey> where T : class
    {
        [Post("")]
        Task<T> Create([Body] T payload);

        [Get("")]
        Task<List<T>> ReadAll();

        [Get("/{key}")]
        Task<T> ReadOne(TKey key);

        [Put("/{key}")]
        Task Update(TKey key, [Body] T payload);

        [Delete("/{key}")]
        Task Delete(TKey key);
    }
}
