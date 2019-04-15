using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using keepr.Models;
using keepr.Repositories;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Keepr.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class KeepsController : ControllerBase
  {
    private readonly KeepRepository _kr;
    public KeepsController(KeepRepository kr)
    {
      _kr = kr;
    }

    //GETALL
    [HttpGet]
    public ActionResult<IEnumerable<Keep>> Get()
    {
      IEnumerable<Keep> results = _kr.GetALL();
      if (results == null)
      {
        return BadRequest();
      }
      return Ok(results);
    }

    //GETBYID
    [HttpGet("{id}")]
    public ActionResult<Keep> GetById(int id)
    {
      Keep result = _kr.GetById(id);
      if (result == null) { return BadRequest(); }
      return Ok(result);
    }

    //NEW KEEP
    [HttpPost]
    [Authorize]
    public ActionResult<Keep> Create([FromBody] Keep newKeepData)
    {
      newKeepData.UserId = HttpContext.User.Identity.Name;
      Keep newKeep = _kr.Create(newKeepData);
      if (newKeep == null) { return BadRequest("Cannot create keep"); }
      return Ok(newKeep);
    }

    //DELETE KEEP
    [HttpDelete("{id}")]
    public ActionResult<string> Delete(int id)
    {
      bool successful = _kr.Delete(id);
      if (!successful) { return BadRequest(); }
      return Ok();
    }





  }
}
