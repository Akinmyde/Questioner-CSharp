using Microsoft.AspNetCore.Mvc; 
using System.Collections.Generic; 
using System.Linq; 
using Questioner_CSharp.Models; 

namespace Questioner_CSharp.Controllers {     
[Route("api/[controller]")]     
[ApiController]     
public class UsersController : ControllerBase     
{        
private readonly QuestionerContext _context;          
public UsersController(QuestionerContext context)         
{             _context = context;              
if (_context.Users.Count() == 0)             
{                 
_context.Users.Add(new Users { Name = "User1" });
_context.SaveChanges();             
}         
}
[HttpGet] 
public ActionResult<List<Users>> GetAll() {
  return _context.Users.ToList();
}

[HttpGet("{id}", Name = "GetItem")]
public ActionResult<Users> GetById(long id) {
  var item = _context.Users.Find(id);
  if (item == null) {
    return NotFound();
  }
  return item;
}          
} 
}