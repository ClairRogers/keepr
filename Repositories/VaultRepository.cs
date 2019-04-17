using System;
using System.Data;
using System.Linq;
using BCrypt.Net;
using keepr.Models;
using Dapper;
using System.Collections.Generic;

namespace keepr.Repositories
{
  public class VaultRepository
  {

    IDbConnection _db;


    internal IEnumerable<Vault> Get(string UserId)
    {
      return _db.Query<Vault>("SELECT * FROM vaults WHERE userId = @UserId", new { UserId });
    }

    internal Vault GetById(int Id)
    {
      return _db.QueryFirstOrDefault<Vault>("SELECT * FROM vaults WHERE id = @Id", new { Id });
    }

    internal Vault Create(Vault newVaultData)
    {
      try
      {
        int id = _db.ExecuteScalar<int>(@"
                INSERT INTO vaults (name, description, userId)
                    VALUES (@Name, @Description, @UserId);
                    SELECT LAST_INSERT_ID();
                ", newVaultData);
        newVaultData.Id = id;
        return newVaultData;
      }
      catch (Exception e)
      {
        Console.WriteLine(e);
        return null;
      }
    }

    internal bool Delete(int Id, string UserId)
    {
      int success = _db.Execute("DELETE FROM vaults WHERE id = @Id AND userId = @UserId", new { Id, UserId });
      return success > 0;
    }

    public VaultKeep CreateVaultKeep(VaultKeep vaultKeepToCreate)
    {
      try
      {
        int id = _db.ExecuteScalar<int>(@"
                INSERT INTO vaultKeeps (vaultId, keepId, userId)
                    VALUES (@VaultId, @KeepId, @UserId);
                    SELECT LAST_INSERT_ID();
                ", vaultKeepToCreate);
        vaultKeepToCreate.Id = id;
        return vaultKeepToCreate;
      }
      catch (Exception e)
      {
        Console.WriteLine(e);
        return null;
      }
    }
    internal IEnumerable<Keep> GetVaultKeep(int vaultId, string userId)
    {
      return _db.Query<Keep>(@"SELECT * FROM vaultkeeps vk
                  INNER JOIN keeps k ON k.id = vk.keepId 
                  WHERE (vaultId = @vaultId AND vk.userId = @userId)", new { vaultId, userId });
    }




    public VaultRepository(IDbConnection db)
    {
      _db = db;
    }

  }
}