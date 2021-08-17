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
    /// <param name="RoleId">角色id</param>
    /// <returns></returns>
    public List<Role> roleshow(int RoleId)
    {
      //异常处理
      try
      {
        string sql = $"select role.RoleName,function.FunctionName,function.Pid from role join rolefunction on role.RoleId = rolefunction.RoleId join function on function.FunctionId = rolefunction.FunctionId where role.RoleId = {RoleId} and function.Pid = 0";

        return Irole.GetT_Dapper(sql, RoleId).ToList();
      }
      catch (Exception)
      {
        throw;
      }
    }
    /// <summary>
    /// 查询二级菜单
    /// </summary>
    /// <param name="RoleId">角色id</param>
    /// <param name="Pid">子类id</param>
    /// <returns></returns>
    public List<Role> roleshow1(int RoleId,int Pid)
    {
      //异常处理
      try
      {
        string sql = $"select role.RoleName,function.FunctionName,function.Pid from role join rolefunction on role.RoleId = rolefunction.RoleId join function on function.FunctionId = rolefunction.FunctionId where role.RoleId = {RoleId} and function.Pid = {Pid}";

        return Irole.GetT_Dapper(sql, RoleId, Pid).ToList();
      }
      catch (Exception)
      {
        throw;
      }
    }
  }
}
