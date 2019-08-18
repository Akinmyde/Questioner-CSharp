using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Questioner_CSharp.Models;

namespace Questioner_CSharp {
  public class UserSecurity {
    private readonly QuestionerContext _context;
    public bool Login(string username, string password){
      return _context.Users.Any(user => user.UserName.Equals(username, StringComparison.OrdinalIgnoreCase) && user.FirstName == password);
    }
  }
}