using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS_logistics.Model;
using TMS_logistics.Common;
using TMS_logistics.IDAL;
using System.Data;
using MySql.Data.MySqlClient;
using Dapper;

namespace TMS_logistics.DAL
{
  public class menu<T> : Imenu<T> where T : class, new()
  {
    IDbConnection connection = new MySqlConnection(Lianjie.Lianjiestring);
    //查询
    public List<T> GetT_Dapper(string sql, object obj = null, object parm1 = null)
    {
      return connection.Query<T>(sql, obj).ToList();
    }
    //登录
    public List<T> GetT_Dapper1(string sql, object obj = null, string userMima = null)
    {
      return connection.Query<T>(sql, obj).ToList();
    }
    //增删改

    public int Add_Dapper(string sql, object obj = null)
    {

      return connection.Execute(sql, obj  );
    }
  }
}
