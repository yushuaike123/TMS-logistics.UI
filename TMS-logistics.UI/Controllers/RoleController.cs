using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Security.Claims;
using System.Text;
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
  [Route("Role")]
  [ApiController]
  public class RoleController : Controller
  {
    /// <summary>
    /// 日志器
    /// </summary>
    private ILogger m_logger;
    /// <summary>
    /// 日志器工厂
    /// </summary>
    private ILoggerFactory m_LoggerFactory;

    public BasicsJuese BasicsJuese;
    public RoleController(BasicsJuese BasicsJuese1, ILoggerFactory loggerFactory)
    {
      BasicsJuese = BasicsJuese1;

      m_LoggerFactory = loggerFactory;
      //// 获取指定名字的日志器
      m_logger = m_LoggerFactory.CreateLogger("AppLogger");
    }
    /// <summary>
    /// 一级菜单
    /// </summary>
    /// <param name="UserId">角色id</param>
    /// <returns></returns>
    [Route(nameof(roleshow))]
    [HttpGet]
    public IActionResult roleshow(int UserId)
    {
      //异常处理
      try
      {
        List<Userrole> BasicsJuesea = BasicsJuese.roleshow(UserId);
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
