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
      throw new NotImplementedException();
    }

    internal Keep GetById(int id)
    {
      throw new NotImplementedException();
    }

    internal Keep Create(Keep newKeepData)
    {
      throw new NotImplementedException();
    }

    internal bool Delete(int id)
    {
      throw new NotImplementedException();
    }





    public KeepRepository(IDbConnection db)
    {
      _db = db;
    }
  }
}