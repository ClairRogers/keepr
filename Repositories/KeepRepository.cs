using System;
using System.Data;
using System.Linq;
using BCrypt.Net;
using keepr.Models;
using Dapper;
using System.Collections.Generic;

namespace keepr.Repositories
{
  public class KeepRepository
  {

    IDbConnection _db;


    internal IEnumerable<Keep> GetALL()
    {
      return _db.Query<Keep>("SELECT * FROM keeps");
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
                INSERT INTO keeps (name, description, userId, img, isPrivate)
                    VALUES (@Name, @Description, @UserId, @Img, @IsPrivate);
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

    internal IEnumerable<Keep> GetByUser(string UserId)
    {
      return _db.Query<Keep>("SELECT * FROM keeps WHERE userId = @UserId", new { UserId });
    }
    internal Keep Update(Keep editedKeep)
    {
      try
      {
        string query = @"
        UPDATE keeps SET
          name = @Name,
          description = @Description,
          userId = @UserId,
          img = @Img,
          views = @Views,
          keeps = @Keeps,
          shares = @Shares,
          isPrivate = @IsPrivate

          WHERE id = @Id;
          SELECT * FROM keeps WHERE id = @Id;";
        return _db.QueryFirstOrDefault<Keep>(query, editedKeep);
      }
      catch (Exception e)
      {
        System.Console.WriteLine(e);
        return null;
      }
    }

    public KeepRepository(IDbConnection db)
    {
      _db = db;
    }

  }
}