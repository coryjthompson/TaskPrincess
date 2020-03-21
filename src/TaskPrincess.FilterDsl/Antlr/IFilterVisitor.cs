//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     ANTLR Version: 4.7.1
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from Filter.g4 by ANTLR 4.7.1

// Unreachable code detected
#pragma warning disable 0162
// The variable '...' is assigned but its value is never used
#pragma warning disable 0219
// Missing XML comment for publicly visible type or member '...'
#pragma warning disable 1591
// Ambiguous reference in cref attribute
#pragma warning disable 419

namespace TaskPrincess.FilterDsl.Antlr {
using Antlr4.Runtime.Misc;
using Antlr4.Runtime.Tree;
using IToken = Antlr4.Runtime.IToken;

/// <summary>
/// This interface defines a complete generic visitor for a parse tree produced
/// by <see cref="FilterParser"/>.
/// </summary>
/// <typeparam name="Result">The return type of the visit operation.</typeparam>
[System.CodeDom.Compiler.GeneratedCode("ANTLR", "4.7.1")]
[System.CLSCompliant(false)]
public interface IFilterVisitor<Result> : IParseTreeVisitor<Result> {
	/// <summary>
	/// Visit a parse tree produced by <see cref="FilterParser.query"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitQuery([NotNull] FilterParser.QueryContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>ParenthesesExpression</c>
	/// labeled alternative in <see cref="FilterParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitParenthesesExpression([NotNull] FilterParser.ParenthesesExpressionContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>FilterIdExpression</c>
	/// labeled alternative in <see cref="FilterParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitFilterIdExpression([NotNull] FilterParser.FilterIdExpressionContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>BinaryExpression</c>
	/// labeled alternative in <see cref="FilterParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitBinaryExpression([NotNull] FilterParser.BinaryExpressionContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>PredicateExpression</c>
	/// labeled alternative in <see cref="FilterParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitPredicateExpression([NotNull] FilterParser.PredicateExpressionContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>FilterTagsExpression</c>
	/// labeled alternative in <see cref="FilterParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitFilterTagsExpression([NotNull] FilterParser.FilterTagsExpressionContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="FilterParser.filter_id"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitFilter_id([NotNull] FilterParser.Filter_idContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="FilterParser.filter_tags"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitFilter_tags([NotNull] FilterParser.Filter_tagsContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="FilterParser.predicate"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitPredicate([NotNull] FilterParser.PredicateContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="FilterParser.binary_operator"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitBinary_operator([NotNull] FilterParser.Binary_operatorContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="FilterParser.relational_operator"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitRelational_operator([NotNull] FilterParser.Relational_operatorContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="FilterParser.constant"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitConstant([NotNull] FilterParser.ConstantContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>IntegerValue</c>
	/// labeled alternative in <see cref="FilterParser.value"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitIntegerValue([NotNull] FilterParser.IntegerValueContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>DoubleValue</c>
	/// labeled alternative in <see cref="FilterParser.value"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitDoubleValue([NotNull] FilterParser.DoubleValueContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>LiteralStringValue</c>
	/// labeled alternative in <see cref="FilterParser.value"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitLiteralStringValue([NotNull] FilterParser.LiteralStringValueContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>RegexValue</c>
	/// labeled alternative in <see cref="FilterParser.value"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitRegexValue([NotNull] FilterParser.RegexValueContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>UuidValue</c>
	/// labeled alternative in <see cref="FilterParser.value"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitUuidValue([NotNull] FilterParser.UuidValueContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>StringValue</c>
	/// labeled alternative in <see cref="FilterParser.value"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitStringValue([NotNull] FilterParser.StringValueContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="FilterParser.property_modifier"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitProperty_modifier([NotNull] FilterParser.Property_modifierContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="FilterParser.property"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitProperty([NotNull] FilterParser.PropertyContext context);
}
} // namespace TaskPrincess.FilterDsl.Antlr
