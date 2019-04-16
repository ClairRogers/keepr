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


    internal IEnumerable<Vault> GetALL()
    {
      return _db.Query<Vault>("SELECT * FROM vaults");
    }

    internal Keep GetById(int Id)
    {
      return _db.QueryFirstOrDefault<Keep>("SELECT * FROM keeps WHERE id = @Id", new { Id });
    }

    internal Keep Create(Keep newKeepData)
    {
      try
      {
        int id = _db.ExecuteScalar<int>(@"
                INSERT INTO keeps (name, description, userId, img)
                    VALUES (@Name, @Description, @UserId, @Img);
                    SELECT LAST_INSERT_ID();
                ", newKeepData);
        newKeepData.Id = id;
        return newKeepData;
      }
      catch (Exception e)
      {
        Console.WriteLine(e);
        return null;
      }
    }

    internal bool Delete(int Id, string UserId)
    {
      int success = _db.Execute("DELETE FROM keeps WHERE id = @Id AND userId = @UserId", new { Id, UserId });
      return success > 0;
    }





    public VaultRepository(IDbConnection db)
    {
      _db = db;
    }
  }
}