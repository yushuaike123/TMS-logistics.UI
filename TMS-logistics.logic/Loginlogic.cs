using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS_logistics.DAL;
using TMS_logistics.IDAL;
using TMS_logistics.Model;

namespace TMS_logistics.logic
{
  public class Loginlogic:Login
  {
    public ILogin ILogin;

    public Loginlogic(ILogin ILoginmouth)
    {
      ILogin = ILoginmouth;
    }
    public User Loginshow(string UserName, string UserMima)
    {
      //异常处理
      try
      {
        string sql = $"select* from user join role on user.UserId = role.RoleId where user.UserName = '{UserName}' and user.UserMima = '{UserMima}'";
        
        return ILogin.GetT_Dapper1(sql, UserName, UserMima).FirstOrDefault();
      }
      catch (Exception)
      {
        throw;
      }
    }
  }
}
