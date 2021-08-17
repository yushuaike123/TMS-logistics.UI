using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMS_logistics.Model
{
  //功能表
  public class Function
  {
    public int FunctionId { get; set; }//功能表id
    public string FunctionName { get; set; }//功能表名称
    public string FunctionUrl { get; set; }//链接地址
    public int Pid { get; set; }//父级id
  }
}
