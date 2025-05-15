﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ASC.Utilities
{
    public static class PredicateBuilder
    {
        public static Expression<Func<T, bool>> And<T>(this Expression<Func<T, bool>> expr1, Expression<Func<T, bool>> expr2)
        {
            var parameter = Expression.Parameter(typeof(T));

            var combined = Expression.Lambda<Func<T, bool>>(
                Expression.AndAlso(
                    Expression.Invoke(expr1, parameter),
                    Expression.Invoke(expr2, parameter)
                ),
                parameter
            );

            return combined;
        }

        public static Expression<Func<T, bool>> Or<T>(this Expression<Func<T, bool>> expr1, Expression<Func<T, bool>> expr2)
        {
            var parameter = Expression.Parameter(typeof(T));

            var combined = Expression.Lambda<Func<T, bool>>(
                Expression.OrElse( // Chỗ này có thể là OrElse hoặc Or tùy vào logic mong muốn, ảnh không rõ 100% nhưng OrElse phổ biến hơn
                    Expression.Invoke(expr1, parameter),
                    Expression.Invoke(expr2, parameter)
                ),
                parameter
            );

            return combined;
        }
    }
}
