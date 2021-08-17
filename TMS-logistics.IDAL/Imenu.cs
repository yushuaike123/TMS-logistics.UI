using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS_logistics.Model;

namespace TMS_logistics.IDAL
{
  public interface Imenu<T> where T : class, new()
  {
    //查询
    List<T> GetT_Dapper(string sql, object obj = null, object parm1 = null);
    //登录
    List<T> GetT_Dapper1(string sql, object obj = null, string userMima = null);
    //增删改
    int Add_Dapper(string sql, object obj = null);
  }
}
