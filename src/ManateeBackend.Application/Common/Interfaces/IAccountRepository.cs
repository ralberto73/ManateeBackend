using ManateeBackend.Domain.Entities;

namespace ManateeBackend.Application.Common.Interfaces;

/// <summary>
/// Persists and retrieves <see cref="Account"/> entities.
/// </summary>
public interface IAccountRepository
{
    void Add(Account account);
}
