using System.Linq.Expressions;
using System.Reflection;

namespace UnitTests.Api;

public static class ExpressionExtensions
{
    public static MethodInfo GetMethodInfo<TResult>(this Expression<Func<TResult>> expression)
    {
        if (expression.Body is not MethodCallExpression methodCallExpression)
        {
            throw new InvalidOperationException("Expression does not contain a method call");
        }

        return methodCallExpression.Method;
    }
}