using System;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net;
using System.Web.Http;
using Questioner_CSharp.Models;

namespace Questioner_CSharp.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class UsersController : ControllerBase
  {
    private readonly QuestionerContext _context;
    public UsersController(QuestionerContext context)
    {
      _context = context;
      if (_context.Users.Count() == 0)
      {
        _context.Users.Add(new Users { UserName = "akinmyde", Email = "test@gmail.com", Registered = DateTime.Today.ToString() });
        _context.SaveChanges();
      }
    }
    [HttpGet]
    public ActionResult<List<Users>> GetAll()
    {
      return _context.Users.ToList();
    }
    [HttpGet("{id}", Name = "GetItem")]
    public ActionResult<Users> GetById(long id)
    {
      var user = _context.Users.Find(id);
      if (user == null)
      {
        return NotFound();
      }
      return user;
    }

    [HttpPost]
    public ActionResult<Users> Post([FromBody] Users user)
    {
      try
      {
        user.Registered = DateTime.Now.ToString();
        var isRegistered = _context.Users.FirstOrDefault(x => x.UserName == user.UserName || x.Email == user.Email);
        if (isRegistered != null)
        {
          return BadRequest("User already exist");
        }
        _context.Users.Add(user);
        _context.SaveChanges();
        return Ok(user);
      }
      catch (Exception ex) {
        return BadRequest(ex);
      }
    }
    // public ActionResult<Users> Put([FromBody] Users users, int id) {
    //   _context.Users.Update()
    // }
  }
}
