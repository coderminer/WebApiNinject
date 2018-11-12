### ASP.NET Web Api使用Ninject实现依赖注入

在`ASP.NET Web Api`项目中使用`Ninject`,新建一个 `ASP.NET Web Api` 项目

#### 使用 `Nuget` 安装第三方包

使用`nuget`安装 `Ninject.Web.WebApi` ，安装之后，会在项目中引入

```
Ninject
Ninject.Web.Common
Ninject.Web.WebApi
```

还需要安装 `Ninject.Web.Common.WebHost`,安装成功之后，会在`App_Start`文件夹中会自动生成一个 `Ninject.Web.Common.cs` 文件
这个文件是`Ninject`初始化相关的内容

#### 编辑 `Ninject.Web.Common.cs`

在`Ninject.Web.Common.cs`中遗漏一个重要的特性，在项目中的`controller`的构造函数中使用依赖注入，不会生效，需要在 `CreateKernel()`中
添加下面的内容  

```
RegisterServices(kernel);
GlobalConfiguration.Configuration.DependencyResolver = new NinjectDependencyResolver(kernel);
return kernel;
```

需要引入

```
using System.Web.Http;
using Ninject.Web.WebApi;
```

#### 注册相关的服务

如项目中添加了一个服务

`IUserService.cs`

```
public interface IUserService
{
    string GetName();
}
```

`UserService.cs`

```
public class UserService : IUserService
{
    public string GetName()
    {
        return "Test";
    }
}
```

在`NinjectWebCommon.cs`中的 `RegisterServices(...)`方法中注册对应的服务  

```
private static void RegisterServices(IKernel kernel)
{
    kernel.Bind<IUserService>().To<UserService>();
}
```

#### 在 `Controller`中使用  

```
public class UserController : ApiController
{
    private IUserService _userService;
    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    public string Get()
    {
        return _userService.GetName();
    }
}
```

#### 在过滤器中使用依赖注入

```
public class ParamsFilterAttribute : ActionFilterAttribute
{
    [Inject]
    public IUserService userService { get; set; }
    public override void OnActionExecuting(HttpActionContext actionContext)
    {
        base.OnActionExecuting(actionContext);

        userService.GetName();
    }
}
```

在 `Controller`中添加过滤器

```
[ParamsFilter]
public string Get()
{
    return _userService.GetName();
}
```

[更多精彩内容](http://coderminer.com)  
