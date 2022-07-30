using System.Linq.Expressions;
using System.Reflection;
using Castle.Core.Internal;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;

namespace UnitTests.Api;

public static class ActionHelper
{
    public static string GetPath<TResult>(Expression<Func<TResult>> expression)
    {
        return GetPaths(expression).First();
    }

    public static List<string> GetPaths<TResult>(Expression<Func<TResult>> expression)
    {
        var methodInfo = expression.GetMethodInfo();
        var parentType = methodInfo.DeclaringType;
        var basePath = parentType.GetAttribute<RouteAttribute>().Template;
        var actionRoutes = methodInfo.GetCustomAttributes<RouteAttribute>().ToList();
        if (actionRoutes.Any())
        {
            return actionRoutes
                .OrderBy(route => route.Order)
                .Select(route => $"{basePath}/{route.Template}")
                .ToList();
        }

        return new List<string> { basePath };
    }

    public static HttpMethodAttribute GetHttpMethod<TResult>(Expression<Func<TResult>> expression)
    {
        var methodInfo = expression.GetMethodInfo();
        var method = methodInfo.GetCustomAttribute<HttpMethodAttribute>();

        return method!;
    }
}
