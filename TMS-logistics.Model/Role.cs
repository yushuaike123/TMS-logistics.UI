using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMS_logistics.Model
{
  //角色表
  public class Role
  {
    public int RoleId { get; set; }//角色id
    public string RoleName { get; set; }//角色名称


    public int FunctionId { get; set; }//功能表id
    public string FunctionName { get; set; }//功能表名称
    public string FunctionUrl { get; set; }//链接地址
    public int Pid { get; set; }//父级id


    public int RolefunctionId { get; set; }//角色功能表id
    public int RoleIid { get; set; }//角色表id
    public int FunctionIid { get; set; }//功能表id

  }
}
