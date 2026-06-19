using System.Collections.Concurrent;
using ManateeBackend.Application.Common.Interfaces;
using ManateeBackend.Domain.Entities;

namespace ManateeBackend.Data.Repositories;

/// <summary>
/// In-memory implementation of <see cref="IAccountRepository"/>.
/// </summary>
public class AccountRepository : IAccountRepository
{
    private readonly ConcurrentDictionary<Guid, Account> _accounts = new();

    public void Add(Account account)
    {
        _accounts[account.Account_Id] = account;
    }
}
