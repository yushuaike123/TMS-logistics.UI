using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMS_logistics.Model
{
  //用户表
  public class User
  {
    public int UserId { get; set; }//用户id
    public string UserZhang { get; set; }//用户账号
    public string UserMima { get; set; }//用户密码
    public string UserName { get; set; }//用户姓名


    public int RoleId { get; set; }//角色id
    public string RoleName { get; set; }//角色名称

  }
}
