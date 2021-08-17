using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMS_logistics.Model
{
  //角色功能表
  public class Rolefunction
  {
    public int RolefunctionId { get; set; }//角色功能表id
    public int RoleId { get; set; }//角色表id
    public int FunctionId { get; set; }//功能表id
  }
}
