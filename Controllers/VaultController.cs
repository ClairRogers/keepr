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
  public class VaultsController : ControllerBase
  {
    private readonly VaultRepository _vr;
    public VaultsController(VaultRepository vr)
    {
      _vr = vr;
    }


    //GETBYID
    [HttpGet("{id}")]
    public ActionResult<Vault> GetById(int id)
    {
      Vault result = _vr.GetById(id);
      if (result == null) { return BadRequest(); }
      return Ok(result);
    }

    //GET BY USER
    [HttpGet]
    [Authorize]
    public ActionResult<IEnumerable<Vault>> Get(string UserId)
    {
      UserId = HttpContext.User.Identity.Name;
      IEnumerable<Vault> results = _vr.Get(UserId);
      if (results == null)
      {
        return BadRequest();
      }
      return Ok(results);
    }

    //NEW VAULT
    [HttpPost]
    [Authorize]
    public ActionResult<Vault> Create([FromBody] Vault newVaultData)
    {
      newVaultData.UserId = HttpContext.User.Identity.Name;
      Vault newVault = _vr.Create(newVaultData);
      if (newVault == null) { return BadRequest("Cannot create vault"); }
      return Ok(newVault);
    }

    //DELETE VAULT
    [HttpDelete("{id}")]
    [Authorize]
    public ActionResult<string> Delete(int id)
    {
      string userId = HttpContext.User.Identity.Name;
      bool successful = _vr.Delete(id, userId);
      if (!successful) { return BadRequest(); }
      return Ok();
    }

    //CREATE VAULTKEEP
    [HttpPost("{vaultId}")]
    [Authorize]
    public ActionResult<VaultKeep> Create([FromBody] VaultKeep newVaultKeep)
    {
      newVaultKeep.UserId = HttpContext.User.Identity.Name;
      VaultKeep result = _vr.CreateVaultKeep(newVaultKeep);
      if (result == null)
      {
        return BadRequest();
      }
      return Ok(result);
    }

    [HttpGet("{vaultId}/keeps")]
    [Authorize]
    public ActionResult<IEnumerable<Keep>> GetVaultKeeps(int vaultId)
    {
      string UserId = HttpContext.User.Identity.Name;
      IEnumerable<Keep> result = _vr.GetVaultKeep(vaultId, UserId);
      if (result == null)
      {
        return BadRequest();
      }
      return Ok(result);
    }




  }
}
