using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using TMS_logistics.logic;
using TMS_logistics.Model;
using TMS_logistics.Ui;

namespace TMS_logistics.UI.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class LoginController : Controller
  {
    private JwtConfig jwtconfig;
    public Loginlogic Loginlogic;
    public LoginController(Loginlogic _Loginlogic, IOptions<JwtConfig> option)
    {
      Loginlogic = _Loginlogic;
      jwtconfig = option.Value;
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
        var claim = new Claim[]{
            new Claim("UserName", "lb")
        };
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtconfig.SigningKey));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
        var token = new JwtSecurityToken(
            issuer: jwtconfig.Issuer,
            audience: jwtconfig.Audience,
            claims: claim,
            notBefore: DateTime.Now,
            expires: DateTime.Now.AddSeconds(30),
            signingCredentials: creds);
        return Json(new { Loginlogica, token = new JwtSecurityTokenHandler().WriteToken(token)});
      }
      catch (Exception)
      {
        throw;
      }
    }
    [Authorize]
    [HttpGet]
    [Route("xu")]
    public ActionResult xu()
    {
      return Ok("徐家汇");
    }
    #endregion

  }
}
