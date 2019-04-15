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

    internal bool Delete(int Id)
    {
      int success = _db.Execute("DELETE FROM keeps WHERE id = @Id", new { Id });
      return success > 0;
    }





    public KeepRepository(IDbConnection db)
    {
      _db = db;
    }
  }
}