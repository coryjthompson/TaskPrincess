using System;
using System.Linq.Expressions;
using System.Collections;
using TaskPrincess.DomainLanguage.Antlr;
using static TaskPrincess.DomainLanguage.Antlr.FilterParser;

namespace TaskPrincess.DomainLanguage
{
    public class FilterVisitor<T> : FilterBaseVisitor<Expression>
    {
        private readonly ParameterExpression _parameter;

        public FilterVisitor()
        {
            _parameter = Expression.Parameter(typeof(T));
        }

        public Expression<Func<T, bool>> Visit(QueryContext context)
        {
            return Expression.Lambda<Func<T, bool>>(VisitQuery(context), _parameter);
        }

        public override Expression VisitFilter_id(Filter_idContext context)
        {
            if (context.UUID() != null)
            {
                var uuidProperty = Expression.Property(_parameter, "uuid");
                var uuidValue = Expression.Constant(Guid.Parse(context.UUID().GetText()), typeof(Guid));
                return Expression.Equal(uuidProperty, uuidValue);
            }

            if (context.INT() != null)
            {
                var idProperty = Expression.Property(_parameter, "id");
                var idValue = Expression.Constant(int.Parse(context.INT().GetText()), typeof(int));
                return Expression.Equal(idProperty, idValue);
            }

            throw new Exception();
        }

        public override Expression VisitBinaryExpression(BinaryExpressionContext context)
        {
            var binaryOperator = context.binary_operator();
            var left = Visit(context.expression(0));
            var right = Visit(context.expression(1));

            if (binaryOperator == null || binaryOperator.AND() != null)
            {
                return Expression.And(left, right);
            }

            if (binaryOperator.OR() != null)
            {
                return Expression.Or(left, right);
            }
            else if (binaryOperator.XOR() != null)
            {
                return Expression.ExclusiveOr(left, right);
            }

            return Expression.And(left, right);
        }

        public override Expression VisitParenthesesExpression(ParenthesesExpressionContext context)
        {
            return Visit(context.expression());
        }

        public override Expression VisitPredicate(PredicateContext context)
        {
            var property = VisitProperty(context.property());
            var constant = VisitConstant(context.constant());

            if (context.relational_operator() != null)
            {
                return HandleRelationalOperatorPredicate(context.@relational_operator(), property, constant);
            }

            if (context.COLON() != null)
            {
                return HandlePropertyModifierPredicate(context.property_modifier(), property, constant);
            }

            return null;
        }

        public override Expression VisitProperty(PropertyContext context)
        {
            var propertyName = context.GetText();
            return Expression.Property(_parameter, propertyName);
        }

        public override Expression VisitIntegerValue(IntegerValueContext context)
        {
            var value = int.Parse(context.GetText());
            return Expression.Constant(value, typeof(int));
        }

        public override Expression VisitDoubleValue(DoubleValueContext context)
        {
            var value = double.Parse(context.GetText());
            return Expression.Constant(value, typeof(double));
        }

        public override Expression VisitLiteralStringValue(LiteralStringValueContext context)
        {
            var value = context.GetText().Trim(new char[] { '\'', '"' });
            return Expression.Constant(value, typeof(string));
        }

        public override Expression VisitStringValue(StringValueContext context)
        {
            var value = context.GetText();
            return Expression.Constant(value, typeof(string));
        }

        /*
         * TODO: Figure out a way to implement regex expression
        public Expression VisitRegexValue(RegexValueContext context)
        {
            return "";
        }*/

        public override Expression VisitUuidValue(UuidValueContext context)
        {
            var value = Guid.Parse(context.GetText());
            return Expression.Constant(value, typeof(Guid));
        }

        private Expression HandleRelationalOperatorPredicate(Relational_operatorContext context, Expression property, Expression constant)
        {
            if (context.EQUALS() != null)
            {
                return Expression.Equal(property, constant);
            }
            else if (context.NOT_EQUAL() != null)
            {
                return Expression.NotEqual(property, constant);
            }
            else if (context.LESS_THAN_OR_EQUAL_TO() != null)
            {
                return Expression.LessThanOrEqual(property, constant);
            }
            else if (context.LESS_THAN() != null)
            {
                return Expression.LessThan(property, constant);
            }
            else if (context.GREATER_THAN_OR_EQUAL_TO() != null)
            {
                return Expression.GreaterThanOrEqual(property, constant);
            }
            else if (context.GREATER_THAN() != null)
            {
                return Expression.GreaterThan(property, constant);
            }

            throw new NotImplementedException("Not implement filter operator: " + context.GetText());
        }

        private Expression HandlePropertyModifierPredicate(Property_modifierContext context, Expression property, Expression constant)
        {
            if (context == null)
            {
                return Expression.Equal(property, constant);
            }
            else if (context.NOT() != null)
            {
                return Expression.NotEqual(property, constant);
            }
            else if (context.BEFORE() != null)
            {
                return Expression.LessThan(property, constant);
            }
            else if (context.AFTER() != null)
            {
                return Expression.GreaterThan(property, constant);
            }
            else if (context.NONE() != null)
            {
                return Expression.Or(
                        Expression.Equal(property, Expression.Constant("")),
                        Expression.Equal(property, Expression.Constant(null)));
            }
            else if (context.ANY() != null)
            {
                return Expression.And(
                        Expression.NotEqual(property, Expression.Constant("")),
                        Expression.NotEqual(property, Expression.Constant(null)));
            }
            else if (context.MEQUALS() != null)
            {
                return Expression.Equal(property, constant);
            }
            else if (context.ISNT() != null)
            {
                return Expression.NotEqual(property, constant);
            }
            else if (context.HAS() != null)
            {
                return Contains(property, constant);
            }
            else if (context.HASNT() != null)
            {
                return Expression.Not(Contains(property, constant));
            }
            else if (context.STARTS_WITH() != null)
            {
                return StartsWith(property, constant);
            }
            else if (context.ENDS_WITH() != null)
            {
                return EndsWith(property, constant);
            }
            else if (context.MWORD() != null)
            {
                throw new NotImplementedException();
            }
            else if (context.NO_WORD() != null)
            {
                throw new NotImplementedException();
            }

            throw new NotImplementedException("Not implemented modifier predicate: " + context.GetText());
        }

        private static Expression In(Expression field, Expression value)
        {
            var containsMethod = typeof(ICollection).GetMethod("contains");
            return Expression.Call(field, containsMethod, value);
        }

        private static Expression Contains(Expression field, Expression value)
        {
            var containsMethod = typeof(string).GetMethod("contains");
            return Expression.Call(field, containsMethod, value);
        }

        private static Expression StartsWith(Expression field, Expression value)
        {
            var startsWithMethod = typeof(string).GetMethod("startsWith");
            return Expression.Call(field, startsWithMethod, value);
        }

        private static Expression EndsWith(Expression field, Expression value)
        {
            var endsWithMethod = typeof(string).GetMethod("endsWith");
            return Expression.Call(field, endsWithMethod, value);
        }
    }
}
