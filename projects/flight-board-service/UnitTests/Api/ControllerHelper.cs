using System.Reflection;
using Microsoft.AspNetCore.Mvc.Filters;

namespace UnitTests.Api;

public class ControllerHelper
{
    public static bool CheckMarkedWith<TController, TAttribute>()
        where TAttribute : Attribute
    {
        var filter = typeof(TController).GetCustomAttribute<TAttribute>();

        return filter != null;
    }

    public static TAttribute GetAttribute<TController, TAttribute>()
        where TAttribute : Attribute
    {
        var attribute = typeof(TController).GetCustomAttribute<TAttribute>();

        return attribute!;
    }
}