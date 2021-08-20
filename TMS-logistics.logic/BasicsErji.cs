using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS_logistics.DAL;
using TMS_logistics.Model;
using TMS_logistics.IDAL;

namespace TMS_logistics.logic
{
  public class BasicsErji:function
  {
    public Ifunction Ifunction;

    public BasicsErji(Ifunction Ifunction1)
    {
      Ifunction = Ifunction1;
    }
    /// <summary>
    /// 查询二级菜单
    /// </summary>
    /// <param name="RoleId">角色id</param>
    /// <param name="Pid">子类id</param>
    /// <returns></returns>
    public List<Function> functionshow(int Pid)
    {
      //异常处理
      try
      {
        string sql = $"select * from function where Pid ={Pid}";

        return Ifunction.GetT_Dapper(sql,Pid).ToList();
      }
      catch (Exception)
      {
        throw;
      }
    }
  }
}
