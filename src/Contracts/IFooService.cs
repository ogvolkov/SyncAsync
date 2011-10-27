namespace Contracts
{
    /// <summary>
    /// This is the common interface shared between async client and sync server
    /// You can freely use refactoring and compile-time interface checking!
    /// </summary>
    public interface IFooService
    {
        FutureResult<Foo> GetOne(int id);
    }
}
