using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NLog;
using TMS_logistics.logic;
using TMS_logistics.Model;
using ILogger = Microsoft.Extensions.Logging.ILogger;

namespace TMS_logistics.Ui.Controllers
{
  [Route("BasicsCar")]
  [ApiController]
  public class BasicsCarController : Controller
  {
    /// <summary>
    /// 日志器
    /// </summary>
    private ILogger m_logger;
    /// <summary>
    /// 日志器工厂
    /// </summary>
    private ILoggerFactory m_LoggerFactory;

    public BasicsCar BasicsCar;
    public BasicsCarController(BasicsCar BasicsCary, ILoggerFactory loggerFactory)
    {
      BasicsCar = BasicsCary;
      m_LoggerFactory = loggerFactory;
      // 获取指定名字的日志器
      m_logger = m_LoggerFactory.CreateLogger("AppLogger");
    }
    #region 货主管理
    /// <summary>
    /// 货主管理显示
    /// </summary>
    /// <param name="driverName">货主名称</param>
    /// <param name="driverPhone">货主手机号</param>
    /// <returns></returns>
    [Authorize]
    [Route(nameof(drivershow1))]
    [HttpGet]
    public IActionResult drivershow1(string driverName, string driverPhone)
    {
      //异常处理
      try
      {
        List<Driver> BasicsCara = BasicsCar.Drivershow(driverName, driverPhone);
        return Ok(BasicsCara);

      }
      catch (Exception ex)
      {
        m_logger.LogError(ex, "捕捉到测试异常");
        throw;
      }
    }
    [Route(nameof(drivershow11))]
    [HttpGet]
    public IActionResult drivershow11()
    {
      //异常处理
      try
      {
        List<Driver> BasicsCara = BasicsCar.Drivershow1();
        return Ok(BasicsCara);

      }
      catch (Exception ex)
      {
        m_logger.LogError(ex, "捕捉到测试异常");
        throw;
      }
    }
    /// <summary>
    /// 货主管理删除
    /// </summary>
    /// <param name="driverId">货主管理Id</param>
    /// <returns></returns>
    [Route(nameof(driverdel))]
    [HttpPost]
    public IActionResult driverdel(int driverId)
    {
      //异常处理
      try
      {
        int delete = BasicsCar.Driverdel(driverId);
        if (delete > 0)
        {
          return Ok(new { msg = "删除成功", code = 200 });
        }
        else
        {
          return Ok(new { msg = "删除失败", code = 500 });
        }
      }
      catch (Exception ex)
      {
        m_logger.LogError(ex, "捕捉到测试异常");
        throw;
      }
    }
    /// <summary>
    /// 货主管理添加
    /// </summary>
    /// <param name="car"></param>
    /// <returns></returns>
    [Route(nameof(driveradd))]
    [HttpPost]
    public IActionResult driveradd(Driver car)
    {
      //异常处理
      try
      {
        int add = BasicsCar.Driveradd(car);
        if (add > 0)
        {
          return Ok(new { msg = "添加成功", code = 200 });
        }
        else
        {
          return Ok(new { msg = "添加失败", code = 500 });
        }
      }
      catch (Exception ex)
      {

        m_logger.LogDebug(ex, "记录调试信息");
        m_logger.LogTrace(ex, "详细记录程序的运行");
        m_logger.LogWarning(ex, "警告");
        m_logger.LogError(ex, "捕捉到测试异常");       
        return Ok("添加操作出错");
      }
    }
    /// <summary>
    /// 货主管理回显
    /// </summary>
    /// <param name="driverId">货主管理Id</param>
    /// <returns></returns>
    [Route(nameof(driverfan))]
    [HttpPost]
    public IActionResult driverfan(int driverId)
    {
      //异常处理
      try
      {
        Driver backfill = BasicsCar.Driverfan(driverId);
        return Ok(backfill);
      }
      catch (Exception ex)
      {
        m_logger.LogWarning(ex, "捕捉到测试异常");
        throw;
      }
    }
    /// <summary>
    /// 货主管理编辑
    /// </summary>
    /// <param name="car"></param>
    /// <returns></returns>
    [Route(nameof(driverbian))]
    [HttpPost]
    public IActionResult driverbian(Driver car)
    {
      //异常处理
      try
      {
        int bian = BasicsCar.Driverbian(car);
        if (bian > 0)
        {
          return Ok(new { msg = "编辑成功", code = 200 });
        }
        else
        {
          return Ok(new { msg = "编辑失败", code = 500 });
        }
      }
      catch (Exception)
      {
        throw;
      }
    }
    #endregion
  }
}
