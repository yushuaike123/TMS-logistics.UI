using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TMS_logistics.logic;
using TMS_logistics.Model;

namespace TMS_logistics.UI.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class LoginController : Controller
  {
    public Loginlogic Loginlogic;
    public LoginController(Loginlogic _Loginlogic)
    {
      Loginlogic = _Loginlogic;

    }

    #region 登录
    /// <summary>
    /// 登录
    /// </summary>
    /// <param name="UserName">用户名称</param>
    /// <param name="UserMima">用户密码</param>
    /// <returns></returns>
    [Route("Loginshow")]
    [HttpGet]
    public JsonResult Loginshow(string UserName, string UserMima)
    {
      //异常处理
      try
      {
        User Loginlogica = Loginlogic.Loginshow(UserName, UserMima);
        if (Loginlogica!=null)
        {
          HttpContext.Session.SetString("name", Loginlogica.UserName);
        }
        return Json(Loginlogica);

      }
      catch (Exception)
      {
        throw;
      }
    }
    #endregion

  }
}
