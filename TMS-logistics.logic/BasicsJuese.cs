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
  public class BasicsJuese:role
  {
    public Irole Irole;

    public BasicsJuese(Irole Irole1)
    {
      Irole = Irole1;
    }
    /// <summary>
    /// 查询一级菜单
    /// </summary>
    /// <param name="UserId">角色id</param>
    /// <returns></returns>
    public List<Userrole> roleshow(int UserId)
    {
      //异常处理
      try
      {
        string sql = $"SELECT C.functIonId,C.FunctionName,C.functionUrl,C.pid FROM userrole A JOIN  rolefunction B ON A.RoleId=B.RoleId JOIN `function` C ON C.functionId = B.Functionid JOIN user D on A.UserId = D.UserId WHERE C.Pid=0 AND A.UserId={UserId}";

        return Irole.GetT_Dapper(sql, UserId).ToList();
      }
      catch (Exception)
      {
        throw;
      }
    }
    
  }
}
