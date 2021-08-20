using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS_logistics.IDAL;
using TMS_logistics.DAL;
using TMS_logistics.Model;
using Dapper;

namespace TMS_logistics.logic
{
  //货主管理
  public class BasicsCar:driverl
  {
    public Idriver Idriver;

    public BasicsCar(Idriver Idrivercar)
    {
      Idriver = Idrivercar;
    }
    //存储过程  模糊查询
    public List<Driver> Drivershow(object parm, object parm1)
    {
      //异常处理
      try
      {
        string sql = $"call ccgc12 ('%{parm}%','%{parm1}%');";
        return Idriver.GetT_Dapper(sql, parm, parm1).ToList();
      }
      catch (Exception)
      {
        throw;
      }
    }
    //存储过程
    public List<Driver> Drivershow1()
    {
      //异常处理
      try
      {
        string sql = $"select * from driver";
        return Idriver.GetT_Dapper(sql).ToList();
      }
      catch (Exception)
      {
        throw;
      }
    }
    //删除
    public int Driverdel(int driverId)
    {
      //异常处理
      try
      {
        //参数化
        DynamicParameters parameters = new DynamicParameters();
        parameters.Add("driverId", driverId);
        string sql = $"delete from driver where driverId = @driverId";
        return Idriver.Add_Dapper(sql, parameters);
      }
      catch (Exception)
      {
        throw;
      }
    }
    //添加
    public int Driveradd(Driver car)
    {
      //异常处理
      try
      {
        car.driverTime = DateTime.Now;
        string sql = $"insert into driver(driverPhone,driverDanwei,driverDizhi,driverJSZriqi,driverImg,driverBeizhu,driverTime) values(@driverName,@driverPhone,@driverDanwei,@driverDizhi,@driverJSZriqi,@driverImg,@driverBeizhu,@driverTime)";
        return Idriver.Add_Dapper(sql,car);
      }
      catch (Exception)
      {
        throw;
      }
    }
    //查看
    public Driver Driverfan(int driverId)
    {
      try
      {
        //参数化
        DynamicParameters parameters = new DynamicParameters();
        parameters.Add("driverId", driverId);
        string sql = $"select * from driver where driverId=@driverId";
        return Idriver.GetT_Dapper(sql, parameters).FirstOrDefault();
      }
      catch (Exception)
      {

        throw;
      }
    }
    //编辑
    public int Driverbian(Driver car)
    {
      //异常处理
      try
      {
        car.driverTime = DateTime.Now;
        string sql = $"update driver set driverName=@driverName,driverPhone=@driverPhone,driverDanwei=@driverDanwei,driverDizhi=@driverDizhi,driverJSZriqi=@driverJSZriqi,driverImg=@driverImg,driverBeizhu=@driverImg,driverTime=@driverTime where driverId=@driverId";
        return Idriver.Add_Dapper(sql, car);
      }
      catch (Exception)
      {
        throw;
      }
    }
  }
}
