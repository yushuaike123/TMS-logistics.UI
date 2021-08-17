using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using TMS_logistics.Common;
using TMS_logistics.DAL;
using TMS_logistics.IDAL;
using TMS_logistics.logic;
using TMS_logistics.Model;
namespace TMS_logistics.Ui
{
  public class Startup
  {

    public Startup(IConfiguration configuration)
    {
      Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {
      #region 数据库链接
      Lianjie.Lianjiestring = Configuration.GetConnectionString("default");
      #endregion
      #region 注入
      services.AddTransient<Loginlogic>();
      services.AddTransient<BasicsCar>();
      services.AddTransient<BasicsJuese>();
      #endregion
      #region 跨域
      services.AddControllers();
      services.AddCors(options => options.AddPolicy("cor",
             builder =>
             {
               builder.AllowAnyMethod()
                .AllowAnyHeader()
                .SetIsOriginAllowed(_ => true) // =AllowAnyOrigin()
                .AllowCredentials();
             }));
      #endregion
      #region Swagger验证及配置
      services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_3_0);
      services.AddSwaggerGen(c =>
      {
        services.AddSwaggerGen(c =>
        {
          c.SwaggerDoc("v1", new OpenApiInfo { Title = "TMS-logistics.Ui", Version = "v1", Description = "TMS-logistics.Ui" });
        });

        // 为 Swagger 设置xml文档注释路径
        var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
        var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
        // 添加控制器层注释，true表示显示控制器注释
        c.IncludeXmlComments(xmlPath, true);

      });
      #endregion
      //划分日志模块  加入ILogger注入
      services.AddScoped<ILogger>(sp => {
        return sp.GetService<ILogger<Program>>();
      });
      //使用session
      services.AddSession();
      services.AddControllersWithViews();
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
      //使用配置会话
      app.UseSession();
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
        app.UseSwagger();
        app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "TMS_logistics.Ui v1"));
      }

      app.UseHttpsRedirection();
      //路由
      app.UseRouting();
      //配置Cors跨域
      app.UseCors("cor");
      app.UseAuthorization();

      app.UseEndpoints(endpoints =>
      {
        endpoints.MapControllers();
      });
    }
    public void ConfigureContainer(ContainerBuilder build)
    {

      var bllFilePath1 = System.IO.Path.Combine(AppContext.BaseDirectory, "TMS-logistics.DAL.dll"); //DDal.dll是依赖注入的层
      //var bllFilePath = System.IO.Path.Combine(AppContext.BaseDirectory, "TMS-logistics.logic.dll"); //DDal.dll是依赖注入的层

      //build.RegisterAssemblyTypes(Assembly.Load(bllFilePath)).AsImplementedInterfaces().InstancePerLifetimeScope();
      build.RegisterAssemblyTypes(Assembly.LoadFile(bllFilePath1)).AsImplementedInterfaces();
      //build.RegisterModule<ConfigureAutofac>();

    }

    //public class ConfigureAutofac : Autofac.Module
    //{
    //  protected override void Load(ContainerBuilder containerBuilder)
    //  {
    //    //直接注册某一个类和接口
    //    //左边的是实现类，右边的As是接口
    //    //containerBuilder.RegisterType<TestServiceE>().As<ITestServiceE>().SingleInstance();


    //    #region 方法1   Load 适用于无接口注入
    //    var assemblysServices = Assembly.Load("TMS_logistics.logic.dll");

    //    containerBuilder.RegisterAssemblyTypes(assemblysServices)
    //              .AsImplementedInterfaces()
    //              .InstancePerLifetimeScope();

    //    #endregion

    //  }
    //}

  }
    
  }
