using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMS_logistics.Model
{
  //用户角色表
  public class Userrole
  {
    public int UserroleId { get; set; }//用户角色表id
    public int Userid { get; set; }//用户表id
    public int Roleid { get; set; }//角色表id



    public int FunctionId { get; set; }//功能表id
    public string FunctionName { get; set; }//功能表名称
    public string FunctionUrl { get; set; }//链接地址
    public int Pid { get; set; }//父级id


    public int RolefunctionId { get; set; }//角色功能表id
    public int RoleIid { get; set; }//角色表id
    public int FunctionIid { get; set; }//功能表id

    public int UserIid { get; set; }//用户id
    public string UserZhang { get; set; }//用户账号
    public string UserMima { get; set; }//用户密码
    public string UserName { get; set; }//用户姓名
  }
}
