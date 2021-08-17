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
  }
}
