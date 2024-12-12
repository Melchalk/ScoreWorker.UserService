namespace UserService.Data.Provider;

/// <summary>
/// Data provider with provider extra methods.
/// </summary>
public interface IBaseDataProvider
{
    void Save();

    Task SaveAsync(CancellationToken cancellationToken = default);

    object MakeEntityDetached(object obj);

    void EnsureDeleted();

    bool IsInMemory();
}