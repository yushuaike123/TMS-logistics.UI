using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NLog;
using TMS_logistics.logic;
using TMS_logistics.Model;
using ILogger = Microsoft.Extensions.Logging.ILogger;

namespace TMS_logistics.Ui.Controllers
{
  [Route("Function")]
  [ApiController]
  public class FunctionController : Controller
  {
    /// <summary>
    /// 日志器
    /// </summary>
    private ILogger m_logger;
    /// <summary>
    /// 日志器工厂
    /// </summary>
    private ILoggerFactory m_LoggerFactory;

    public BasicsErji BasicsErji;
    public FunctionController(BasicsErji BasicsErji1, ILoggerFactory loggerFactory)
    {
      BasicsErji = BasicsErji1;

      m_LoggerFactory = loggerFactory;
      //// 获取指定名字的日志器
      m_logger = m_LoggerFactory.CreateLogger("AppLogger");
    }
    /// <summary>
    /// 二级菜单
    /// </summary>
    /// <param name="Pid">子类id</param>
    /// <returns></returns>
    [Route(nameof(functionshow))]
    [HttpGet]
    public IActionResult functionshow(int Pid)
    {
      //异常处理
      try
      {
        List<Function> BasicsJuesea = BasicsErji.functionshow(Pid);
        if (BasicsJuesea != null)
        {
          return Ok(BasicsJuesea);
        }
        else
        {
          return Ok("数据走丢了");
        }

      }
      catch (Exception ex)
      {
        m_logger.LogError(ex, "捕捉到测试异常");
        throw;
      }
    }
  }
}
