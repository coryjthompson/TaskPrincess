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
using System;
using System.IO;
using System.Text;
using System.Diagnostics;
using System.Collections.Generic;
using Antlr4.Runtime;
using Antlr4.Runtime.Atn;
using Antlr4.Runtime.Misc;
using Antlr4.Runtime.Tree;
using DFA = Antlr4.Runtime.Dfa.DFA;

[System.CodeDom.Compiler.GeneratedCode("ANTLR", "4.7.1")]
[System.CLSCompliant(false)]
public partial class FilterParser : Parser {
	protected static DFA[] decisionToDFA;
	protected static PredictionContextCache sharedContextCache = new PredictionContextCache();
	public const int
		T__0=1, T__1=2, DOT=3, STRING=4, INT=5, DOUBLE=6, UUID=7, AND=8, OR=9, 
		XOR=10, COLON=11, NOT=12, BEFORE=13, AFTER=14, NONE=15, ANY=16, MEQUALS=17, 
		ISNT=18, HAS=19, HASNT=20, STARTS_WITH=21, ENDS_WITH=22, MWORD=23, NO_WORD=24, 
		LESS_THAN_OR_EQUAL_TO=25, GREATER_THAN_OR_EQUAL_TO=26, LESS_THAN=27, GREATER_THAN=28, 
		NOT_EQUAL=29, EQUALS=30, TAG=31, REGEX=32, WORD=33, WHITESPACE=34;
	public const int
		RULE_query = 0, RULE_expression = 1, RULE_filter_id = 2, RULE_filter_tags = 3, 
		RULE_predicate = 4, RULE_binary_operator = 5, RULE_relational_operator = 6, 
		RULE_constant = 7, RULE_value = 8, RULE_property_modifier = 9, RULE_property = 10;
	public static readonly string[] ruleNames = {
		"query", "expression", "filter_id", "filter_tags", "predicate", "binary_operator", 
		"relational_operator", "constant", "value", "property_modifier", "property"
	};

	private static readonly string[] _LiteralNames = {
		null, "'('", "')'", "'.'", null, null, null, null, null, null, null, "':'", 
		null, null, null, null, null, null, null, null, null, null, null, null, 
		null, "'<='", "'>='", "'<'", "'>'"
	};
	private static readonly string[] _SymbolicNames = {
		null, null, null, "DOT", "STRING", "INT", "DOUBLE", "UUID", "AND", "OR", 
		"XOR", "COLON", "NOT", "BEFORE", "AFTER", "NONE", "ANY", "MEQUALS", "ISNT", 
		"HAS", "HASNT", "STARTS_WITH", "ENDS_WITH", "MWORD", "NO_WORD", "LESS_THAN_OR_EQUAL_TO", 
		"GREATER_THAN_OR_EQUAL_TO", "LESS_THAN", "GREATER_THAN", "NOT_EQUAL", 
		"EQUALS", "TAG", "REGEX", "WORD", "WHITESPACE"
	};
	public static readonly IVocabulary DefaultVocabulary = new Vocabulary(_LiteralNames, _SymbolicNames);

	[NotNull]
	public override IVocabulary Vocabulary
	{
		get
		{
			return DefaultVocabulary;
		}
	}

	public override string GrammarFileName { get { return "Filter.g4"; } }

	public override string[] RuleNames { get { return ruleNames; } }

	public override string SerializedAtn { get { return new string(_serializedATN); } }

	static FilterParser() {
		decisionToDFA = new DFA[_ATN.NumberOfDecisions];
		for (int i = 0; i < _ATN.NumberOfDecisions; i++) {
			decisionToDFA[i] = new DFA(_ATN.GetDecisionState(i), i);
		}
	}

		public FilterParser(ITokenStream input) : this(input, Console.Out, Console.Error) { }

		public FilterParser(ITokenStream input, TextWriter output, TextWriter errorOutput)
		: base(input, output, errorOutput)
	{
		Interpreter = new ParserATNSimulator(this, _ATN, decisionToDFA, sharedContextCache);
	}
	public partial class QueryContext : ParserRuleContext {
		public ExpressionContext expression() {
			return GetRuleContext<ExpressionContext>(0);
		}
		public QueryContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_query; } }
		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			IFilterVisitor<TResult> typedVisitor = visitor as IFilterVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitQuery(this);
			else return visitor.VisitChildren(this);
		}
	}

	[RuleVersion(0)]
	public QueryContext query() {
		QueryContext _localctx = new QueryContext(Context, State);
		EnterRule(_localctx, 0, RULE_query);
		try {
			EnterOuterAlt(_localctx, 1);
			{
			State = 22; expression(0);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			ErrorHandler.ReportError(this, re);
			ErrorHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	public partial class ExpressionContext : ParserRuleContext {
		public ExpressionContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_expression; } }
	 
		public ExpressionContext() { }
		public virtual void CopyFrom(ExpressionContext context) {
			base.CopyFrom(context);
		}
	}
	public partial class ParenthesesExpressionContext : ExpressionContext {
		public ExpressionContext expression() {
			return GetRuleContext<ExpressionContext>(0);
		}
		public ParenthesesExpressionContext(ExpressionContext context) { CopyFrom(context); }
		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			IFilterVisitor<TResult> typedVisitor = visitor as IFilterVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitParenthesesExpression(this);
			else return visitor.VisitChildren(this);
		}
	}
	public partial class FilterIdExpressionContext : ExpressionContext {
		public Filter_idContext filter_id() {
			return GetRuleContext<Filter_idContext>(0);
		}
		public FilterIdExpressionContext(ExpressionContext context) { CopyFrom(context); }
		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			IFilterVisitor<TResult> typedVisitor = visitor as IFilterVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitFilterIdExpression(this);
			else return visitor.VisitChildren(this);
		}
	}
	public partial class BinaryExpressionContext : ExpressionContext {
		public ExpressionContext[] expression() {
			return GetRuleContexts<ExpressionContext>();
		}
		public ExpressionContext expression(int i) {
			return GetRuleContext<ExpressionContext>(i);
		}
		public Binary_operatorContext binary_operator() {
			return GetRuleContext<Binary_operatorContext>(0);
		}
		public BinaryExpressionContext(ExpressionContext context) { CopyFrom(context); }
		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			IFilterVisitor<TResult> typedVisitor = visitor as IFilterVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitBinaryExpression(this);
			else return visitor.VisitChildren(this);
		}
	}
	public partial class PredicateExpressionContext : ExpressionContext {
		public PredicateContext predicate() {
			return GetRuleContext<PredicateContext>(0);
		}
		public PredicateExpressionContext(ExpressionContext context) { CopyFrom(context); }
		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			IFilterVisitor<TResult> typedVisitor = visitor as IFilterVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitPredicateExpression(this);
			else return visitor.VisitChildren(this);
		}
	}
	public partial class FilterTagsExpressionContext : ExpressionContext {
		public Filter_tagsContext filter_tags() {
			return GetRuleContext<Filter_tagsContext>(0);
		}
		public FilterTagsExpressionContext(ExpressionContext context) { CopyFrom(context); }
		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			IFilterVisitor<TResult> typedVisitor = visitor as IFilterVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitFilterTagsExpression(this);
			else return visitor.VisitChildren(this);
		}
	}

	[RuleVersion(0)]
	public ExpressionContext expression() {
		return expression(0);
	}

	private ExpressionContext expression(int _p) {
		ParserRuleContext _parentctx = Context;
		int _parentState = State;
		ExpressionContext _localctx = new ExpressionContext(Context, _parentState);
		ExpressionContext _prevctx = _localctx;
		int _startState = 2;
		EnterRecursionRule(_localctx, 2, RULE_expression, _p);
		int _la;
		try {
			int _alt;
			EnterOuterAlt(_localctx, 1);
			{
			State = 32;
			ErrorHandler.Sync(this);
			switch (TokenStream.LA(1)) {
			case WORD:
				{
				_localctx = new PredicateExpressionContext(_localctx);
				Context = _localctx;
				_prevctx = _localctx;

				State = 25; predicate();
				}
				break;
			case INT:
			case UUID:
				{
				_localctx = new FilterIdExpressionContext(_localctx);
				Context = _localctx;
				_prevctx = _localctx;
				State = 26; filter_id();
				}
				break;
			case TAG:
				{
				_localctx = new FilterTagsExpressionContext(_localctx);
				Context = _localctx;
				_prevctx = _localctx;
				State = 27; filter_tags();
				}
				break;
			case T__0:
				{
				_localctx = new ParenthesesExpressionContext(_localctx);
				Context = _localctx;
				_prevctx = _localctx;
				State = 28; Match(T__0);
				State = 29; expression(0);
				State = 30; Match(T__1);
				}
				break;
			default:
				throw new NoViableAltException(this);
			}
			Context.Stop = TokenStream.LT(-1);
			State = 41;
			ErrorHandler.Sync(this);
			_alt = Interpreter.AdaptivePredict(TokenStream,2,Context);
			while ( _alt!=2 && _alt!=global::Antlr4.Runtime.Atn.ATN.INVALID_ALT_NUMBER ) {
				if ( _alt==1 ) {
					if ( ParseListeners!=null )
						TriggerExitRuleEvent();
					_prevctx = _localctx;
					{
					{
					_localctx = new BinaryExpressionContext(new ExpressionContext(_parentctx, _parentState));
					PushNewRecursionContext(_localctx, _startState, RULE_expression);
					State = 34;
					if (!(Precpred(Context, 5))) throw new FailedPredicateException(this, "Precpred(Context, 5)");
					State = 36;
					ErrorHandler.Sync(this);
					_la = TokenStream.LA(1);
					if ((((_la) & ~0x3f) == 0 && ((1L << _la) & ((1L << AND) | (1L << OR) | (1L << XOR))) != 0)) {
						{
						State = 35; binary_operator();
						}
					}

					State = 38; expression(6);
					}
					} 
				}
				State = 43;
				ErrorHandler.Sync(this);
				_alt = Interpreter.AdaptivePredict(TokenStream,2,Context);
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			ErrorHandler.ReportError(this, re);
			ErrorHandler.Recover(this, re);
		}
		finally {
			UnrollRecursionContexts(_parentctx);
		}
		return _localctx;
	}

	public partial class Filter_idContext : ParserRuleContext {
		public ITerminalNode UUID() { return GetToken(FilterParser.UUID, 0); }
		public ITerminalNode INT() { return GetToken(FilterParser.INT, 0); }
		public Filter_idContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_filter_id; } }
		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			IFilterVisitor<TResult> typedVisitor = visitor as IFilterVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitFilter_id(this);
			else return visitor.VisitChildren(this);
		}
	}

	[RuleVersion(0)]
	public Filter_idContext filter_id() {
		Filter_idContext _localctx = new Filter_idContext(Context, State);
		EnterRule(_localctx, 4, RULE_filter_id);
		int _la;
		try {
			EnterOuterAlt(_localctx, 1);
			{
			State = 44;
			_la = TokenStream.LA(1);
			if ( !(_la==INT || _la==UUID) ) {
			ErrorHandler.RecoverInline(this);
			}
			else {
				ErrorHandler.ReportMatch(this);
			    Consume();
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			ErrorHandler.ReportError(this, re);
			ErrorHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	public partial class Filter_tagsContext : ParserRuleContext {
		public ITerminalNode TAG() { return GetToken(FilterParser.TAG, 0); }
		public Filter_tagsContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_filter_tags; } }
		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			IFilterVisitor<TResult> typedVisitor = visitor as IFilterVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitFilter_tags(this);
			else return visitor.VisitChildren(this);
		}
	}

	[RuleVersion(0)]
	public Filter_tagsContext filter_tags() {
		Filter_tagsContext _localctx = new Filter_tagsContext(Context, State);
		EnterRule(_localctx, 6, RULE_filter_tags);
		try {
			EnterOuterAlt(_localctx, 1);
			{
			State = 46; Match(TAG);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			ErrorHandler.ReportError(this, re);
			ErrorHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	public partial class PredicateContext : ParserRuleContext {
		public PropertyContext property() {
			return GetRuleContext<PropertyContext>(0);
		}
		public ITerminalNode COLON() { return GetToken(FilterParser.COLON, 0); }
		public ITerminalNode DOT() { return GetToken(FilterParser.DOT, 0); }
		public Property_modifierContext property_modifier() {
			return GetRuleContext<Property_modifierContext>(0);
		}
		public ConstantContext constant() {
			return GetRuleContext<ConstantContext>(0);
		}
		public Relational_operatorContext relational_operator() {
			return GetRuleContext<Relational_operatorContext>(0);
		}
		public PredicateContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_predicate; } }
		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			IFilterVisitor<TResult> typedVisitor = visitor as IFilterVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitPredicate(this);
			else return visitor.VisitChildren(this);
		}
	}

	[RuleVersion(0)]
	public PredicateContext predicate() {
		PredicateContext _localctx = new PredicateContext(Context, State);
		EnterRule(_localctx, 8, RULE_predicate);
		int _la;
		try {
			State = 61;
			ErrorHandler.Sync(this);
			switch ( Interpreter.AdaptivePredict(TokenStream,5,Context) ) {
			case 1:
				EnterOuterAlt(_localctx, 1);
				{
				State = 48; property();
				State = 51;
				ErrorHandler.Sync(this);
				_la = TokenStream.LA(1);
				if (_la==DOT) {
					{
					State = 49; Match(DOT);
					State = 50; property_modifier();
					}
				}

				State = 53; Match(COLON);
				State = 55;
				ErrorHandler.Sync(this);
				switch ( Interpreter.AdaptivePredict(TokenStream,4,Context) ) {
				case 1:
					{
					State = 54; constant();
					}
					break;
				}
				}
				break;
			case 2:
				EnterOuterAlt(_localctx, 2);
				{
				State = 57; property();
				State = 58; relational_operator();
				State = 59; constant();
				}
				break;
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			ErrorHandler.ReportError(this, re);
			ErrorHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	public partial class Binary_operatorContext : ParserRuleContext {
		public ITerminalNode AND() { return GetToken(FilterParser.AND, 0); }
		public ITerminalNode OR() { return GetToken(FilterParser.OR, 0); }
		public ITerminalNode XOR() { return GetToken(FilterParser.XOR, 0); }
		public Binary_operatorContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_binary_operator; } }
		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			IFilterVisitor<TResult> typedVisitor = visitor as IFilterVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitBinary_operator(this);
			else return visitor.VisitChildren(this);
		}
	}

	[RuleVersion(0)]
	public Binary_operatorContext binary_operator() {
		Binary_operatorContext _localctx = new Binary_operatorContext(Context, State);
		EnterRule(_localctx, 10, RULE_binary_operator);
		int _la;
		try {
			EnterOuterAlt(_localctx, 1);
			{
			State = 63;
			_la = TokenStream.LA(1);
			if ( !((((_la) & ~0x3f) == 0 && ((1L << _la) & ((1L << AND) | (1L << OR) | (1L << XOR))) != 0)) ) {
			ErrorHandler.RecoverInline(this);
			}
			else {
				ErrorHandler.ReportMatch(this);
			    Consume();
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			ErrorHandler.ReportError(this, re);
			ErrorHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	public partial class Relational_operatorContext : ParserRuleContext {
		public ITerminalNode LESS_THAN_OR_EQUAL_TO() { return GetToken(FilterParser.LESS_THAN_OR_EQUAL_TO, 0); }
		public ITerminalNode GREATER_THAN_OR_EQUAL_TO() { return GetToken(FilterParser.GREATER_THAN_OR_EQUAL_TO, 0); }
		public ITerminalNode LESS_THAN() { return GetToken(FilterParser.LESS_THAN, 0); }
		public ITerminalNode GREATER_THAN() { return GetToken(FilterParser.GREATER_THAN, 0); }
		public ITerminalNode NOT_EQUAL() { return GetToken(FilterParser.NOT_EQUAL, 0); }
		public ITerminalNode EQUALS() { return GetToken(FilterParser.EQUALS, 0); }
		public Relational_operatorContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_relational_operator; } }
		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			IFilterVisitor<TResult> typedVisitor = visitor as IFilterVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitRelational_operator(this);
			else return visitor.VisitChildren(this);
		}
	}

	[RuleVersion(0)]
	public Relational_operatorContext relational_operator() {
		Relational_operatorContext _localctx = new Relational_operatorContext(Context, State);
		EnterRule(_localctx, 12, RULE_relational_operator);
		int _la;
		try {
			EnterOuterAlt(_localctx, 1);
			{
			State = 65;
			_la = TokenStream.LA(1);
			if ( !((((_la) & ~0x3f) == 0 && ((1L << _la) & ((1L << LESS_THAN_OR_EQUAL_TO) | (1L << GREATER_THAN_OR_EQUAL_TO) | (1L << LESS_THAN) | (1L << GREATER_THAN) | (1L << NOT_EQUAL) | (1L << EQUALS))) != 0)) ) {
			ErrorHandler.RecoverInline(this);
			}
			else {
				ErrorHandler.ReportMatch(this);
			    Consume();
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			ErrorHandler.ReportError(this, re);
			ErrorHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	public partial class ConstantContext : ParserRuleContext {
		public ValueContext value() {
			return GetRuleContext<ValueContext>(0);
		}
		public ConstantContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_constant; } }
		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			IFilterVisitor<TResult> typedVisitor = visitor as IFilterVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitConstant(this);
			else return visitor.VisitChildren(this);
		}
	}

	[RuleVersion(0)]
	public ConstantContext constant() {
		ConstantContext _localctx = new ConstantContext(Context, State);
		EnterRule(_localctx, 14, RULE_constant);
		try {
			EnterOuterAlt(_localctx, 1);
			{
			State = 67; value();
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			ErrorHandler.ReportError(this, re);
			ErrorHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	public partial class ValueContext : ParserRuleContext {
		public ValueContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_value; } }
	 
		public ValueContext() { }
		public virtual void CopyFrom(ValueContext context) {
			base.CopyFrom(context);
		}
	}
	public partial class DoubleValueContext : ValueContext {
		public ITerminalNode DOUBLE() { return GetToken(FilterParser.DOUBLE, 0); }
		public DoubleValueContext(ValueContext context) { CopyFrom(context); }
		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			IFilterVisitor<TResult> typedVisitor = visitor as IFilterVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitDoubleValue(this);
			else return visitor.VisitChildren(this);
		}
	}
	public partial class IntegerValueContext : ValueContext {
		public ITerminalNode INT() { return GetToken(FilterParser.INT, 0); }
		public IntegerValueContext(ValueContext context) { CopyFrom(context); }
		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			IFilterVisitor<TResult> typedVisitor = visitor as IFilterVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitIntegerValue(this);
			else return visitor.VisitChildren(this);
		}
	}
	public partial class UuidValueContext : ValueContext {
		public ITerminalNode UUID() { return GetToken(FilterParser.UUID, 0); }
		public UuidValueContext(ValueContext context) { CopyFrom(context); }
		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			IFilterVisitor<TResult> typedVisitor = visitor as IFilterVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitUuidValue(this);
			else return visitor.VisitChildren(this);
		}
	}
	public partial class RegexValueContext : ValueContext {
		public ITerminalNode REGEX() { return GetToken(FilterParser.REGEX, 0); }
		public RegexValueContext(ValueContext context) { CopyFrom(context); }
		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			IFilterVisitor<TResult> typedVisitor = visitor as IFilterVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitRegexValue(this);
			else return visitor.VisitChildren(this);
		}
	}
	public partial class LiteralStringValueContext : ValueContext {
		public ITerminalNode STRING() { return GetToken(FilterParser.STRING, 0); }
		public LiteralStringValueContext(ValueContext context) { CopyFrom(context); }
		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			IFilterVisitor<TResult> typedVisitor = visitor as IFilterVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitLiteralStringValue(this);
			else return visitor.VisitChildren(this);
		}
	}
	public partial class StringValueContext : ValueContext {
		public ITerminalNode WORD() { return GetToken(FilterParser.WORD, 0); }
		public StringValueContext(ValueContext context) { CopyFrom(context); }
		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			IFilterVisitor<TResult> typedVisitor = visitor as IFilterVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitStringValue(this);
			else return visitor.VisitChildren(this);
		}
	}

	[RuleVersion(0)]
	public ValueContext value() {
		ValueContext _localctx = new ValueContext(Context, State);
		EnterRule(_localctx, 16, RULE_value);
		try {
			State = 75;
			ErrorHandler.Sync(this);
			switch (TokenStream.LA(1)) {
			case INT:
				_localctx = new IntegerValueContext(_localctx);
				EnterOuterAlt(_localctx, 1);
				{
				State = 69; Match(INT);
				}
				break;
			case DOUBLE:
				_localctx = new DoubleValueContext(_localctx);
				EnterOuterAlt(_localctx, 2);
				{
				State = 70; Match(DOUBLE);
				}
				break;
			case STRING:
				_localctx = new LiteralStringValueContext(_localctx);
				EnterOuterAlt(_localctx, 3);
				{
				State = 71; Match(STRING);
				}
				break;
			case REGEX:
				_localctx = new RegexValueContext(_localctx);
				EnterOuterAlt(_localctx, 4);
				{
				State = 72; Match(REGEX);
				}
				break;
			case UUID:
				_localctx = new UuidValueContext(_localctx);
				EnterOuterAlt(_localctx, 5);
				{
				State = 73; Match(UUID);
				}
				break;
			case WORD:
				_localctx = new StringValueContext(_localctx);
				EnterOuterAlt(_localctx, 6);
				{
				State = 74; Match(WORD);
				}
				break;
			default:
				throw new NoViableAltException(this);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			ErrorHandler.ReportError(this, re);
			ErrorHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	public partial class Property_modifierContext : ParserRuleContext {
		public ITerminalNode NOT() { return GetToken(FilterParser.NOT, 0); }
		public ITerminalNode BEFORE() { return GetToken(FilterParser.BEFORE, 0); }
		public ITerminalNode AFTER() { return GetToken(FilterParser.AFTER, 0); }
		public ITerminalNode NONE() { return GetToken(FilterParser.NONE, 0); }
		public ITerminalNode ANY() { return GetToken(FilterParser.ANY, 0); }
		public ITerminalNode MEQUALS() { return GetToken(FilterParser.MEQUALS, 0); }
		public ITerminalNode ISNT() { return GetToken(FilterParser.ISNT, 0); }
		public ITerminalNode HAS() { return GetToken(FilterParser.HAS, 0); }
		public ITerminalNode HASNT() { return GetToken(FilterParser.HASNT, 0); }
		public ITerminalNode STARTS_WITH() { return GetToken(FilterParser.STARTS_WITH, 0); }
		public ITerminalNode ENDS_WITH() { return GetToken(FilterParser.ENDS_WITH, 0); }
		public ITerminalNode MWORD() { return GetToken(FilterParser.MWORD, 0); }
		public ITerminalNode NO_WORD() { return GetToken(FilterParser.NO_WORD, 0); }
		public Property_modifierContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_property_modifier; } }
		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			IFilterVisitor<TResult> typedVisitor = visitor as IFilterVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitProperty_modifier(this);
			else return visitor.VisitChildren(this);
		}
	}

	[RuleVersion(0)]
	public Property_modifierContext property_modifier() {
		Property_modifierContext _localctx = new Property_modifierContext(Context, State);
		EnterRule(_localctx, 18, RULE_property_modifier);
		int _la;
		try {
			EnterOuterAlt(_localctx, 1);
			{
			State = 77;
			_la = TokenStream.LA(1);
			if ( !((((_la) & ~0x3f) == 0 && ((1L << _la) & ((1L << NOT) | (1L << BEFORE) | (1L << AFTER) | (1L << NONE) | (1L << ANY) | (1L << MEQUALS) | (1L << ISNT) | (1L << HAS) | (1L << HASNT) | (1L << STARTS_WITH) | (1L << ENDS_WITH) | (1L << MWORD) | (1L << NO_WORD))) != 0)) ) {
			ErrorHandler.RecoverInline(this);
			}
			else {
				ErrorHandler.ReportMatch(this);
			    Consume();
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			ErrorHandler.ReportError(this, re);
			ErrorHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	public partial class PropertyContext : ParserRuleContext {
		public ITerminalNode WORD() { return GetToken(FilterParser.WORD, 0); }
		public PropertyContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_property; } }
		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			IFilterVisitor<TResult> typedVisitor = visitor as IFilterVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitProperty(this);
			else return visitor.VisitChildren(this);
		}
	}

	[RuleVersion(0)]
	public PropertyContext property() {
		PropertyContext _localctx = new PropertyContext(Context, State);
		EnterRule(_localctx, 20, RULE_property);
		try {
			EnterOuterAlt(_localctx, 1);
			{
			State = 79; Match(WORD);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			ErrorHandler.ReportError(this, re);
			ErrorHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	public override bool Sempred(RuleContext _localctx, int ruleIndex, int predIndex) {
		switch (ruleIndex) {
		case 1: return expression_sempred((ExpressionContext)_localctx, predIndex);
		}
		return true;
	}
	private bool expression_sempred(ExpressionContext _localctx, int predIndex) {
		switch (predIndex) {
		case 0: return Precpred(Context, 5);
		}
		return true;
	}

	private static char[] _serializedATN = {
		'\x3', '\x608B', '\xA72A', '\x8133', '\xB9ED', '\x417C', '\x3BE7', '\x7786', 
		'\x5964', '\x3', '$', 'T', '\x4', '\x2', '\t', '\x2', '\x4', '\x3', '\t', 
		'\x3', '\x4', '\x4', '\t', '\x4', '\x4', '\x5', '\t', '\x5', '\x4', '\x6', 
		'\t', '\x6', '\x4', '\a', '\t', '\a', '\x4', '\b', '\t', '\b', '\x4', 
		'\t', '\t', '\t', '\x4', '\n', '\t', '\n', '\x4', '\v', '\t', '\v', '\x4', 
		'\f', '\t', '\f', '\x3', '\x2', '\x3', '\x2', '\x3', '\x3', '\x3', '\x3', 
		'\x3', '\x3', '\x3', '\x3', '\x3', '\x3', '\x3', '\x3', '\x3', '\x3', 
		'\x3', '\x3', '\x5', '\x3', '#', '\n', '\x3', '\x3', '\x3', '\x3', '\x3', 
		'\x5', '\x3', '\'', '\n', '\x3', '\x3', '\x3', '\a', '\x3', '*', '\n', 
		'\x3', '\f', '\x3', '\xE', '\x3', '-', '\v', '\x3', '\x3', '\x4', '\x3', 
		'\x4', '\x3', '\x5', '\x3', '\x5', '\x3', '\x6', '\x3', '\x6', '\x3', 
		'\x6', '\x5', '\x6', '\x36', '\n', '\x6', '\x3', '\x6', '\x3', '\x6', 
		'\x5', '\x6', ':', '\n', '\x6', '\x3', '\x6', '\x3', '\x6', '\x3', '\x6', 
		'\x3', '\x6', '\x5', '\x6', '@', '\n', '\x6', '\x3', '\a', '\x3', '\a', 
		'\x3', '\b', '\x3', '\b', '\x3', '\t', '\x3', '\t', '\x3', '\n', '\x3', 
		'\n', '\x3', '\n', '\x3', '\n', '\x3', '\n', '\x3', '\n', '\x5', '\n', 
		'N', '\n', '\n', '\x3', '\v', '\x3', '\v', '\x3', '\f', '\x3', '\f', '\x3', 
		'\f', '\x2', '\x3', '\x4', '\r', '\x2', '\x4', '\x6', '\b', '\n', '\f', 
		'\xE', '\x10', '\x12', '\x14', '\x16', '\x2', '\x6', '\x4', '\x2', '\a', 
		'\a', '\t', '\t', '\x3', '\x2', '\n', '\f', '\x3', '\x2', '\x1B', ' ', 
		'\x3', '\x2', '\xE', '\x1A', '\x2', 'U', '\x2', '\x18', '\x3', '\x2', 
		'\x2', '\x2', '\x4', '\"', '\x3', '\x2', '\x2', '\x2', '\x6', '.', '\x3', 
		'\x2', '\x2', '\x2', '\b', '\x30', '\x3', '\x2', '\x2', '\x2', '\n', '?', 
		'\x3', '\x2', '\x2', '\x2', '\f', '\x41', '\x3', '\x2', '\x2', '\x2', 
		'\xE', '\x43', '\x3', '\x2', '\x2', '\x2', '\x10', '\x45', '\x3', '\x2', 
		'\x2', '\x2', '\x12', 'M', '\x3', '\x2', '\x2', '\x2', '\x14', 'O', '\x3', 
		'\x2', '\x2', '\x2', '\x16', 'Q', '\x3', '\x2', '\x2', '\x2', '\x18', 
		'\x19', '\x5', '\x4', '\x3', '\x2', '\x19', '\x3', '\x3', '\x2', '\x2', 
		'\x2', '\x1A', '\x1B', '\b', '\x3', '\x1', '\x2', '\x1B', '#', '\x5', 
		'\n', '\x6', '\x2', '\x1C', '#', '\x5', '\x6', '\x4', '\x2', '\x1D', '#', 
		'\x5', '\b', '\x5', '\x2', '\x1E', '\x1F', '\a', '\x3', '\x2', '\x2', 
		'\x1F', ' ', '\x5', '\x4', '\x3', '\x2', ' ', '!', '\a', '\x4', '\x2', 
		'\x2', '!', '#', '\x3', '\x2', '\x2', '\x2', '\"', '\x1A', '\x3', '\x2', 
		'\x2', '\x2', '\"', '\x1C', '\x3', '\x2', '\x2', '\x2', '\"', '\x1D', 
		'\x3', '\x2', '\x2', '\x2', '\"', '\x1E', '\x3', '\x2', '\x2', '\x2', 
		'#', '+', '\x3', '\x2', '\x2', '\x2', '$', '&', '\f', '\a', '\x2', '\x2', 
		'%', '\'', '\x5', '\f', '\a', '\x2', '&', '%', '\x3', '\x2', '\x2', '\x2', 
		'&', '\'', '\x3', '\x2', '\x2', '\x2', '\'', '(', '\x3', '\x2', '\x2', 
		'\x2', '(', '*', '\x5', '\x4', '\x3', '\b', ')', '$', '\x3', '\x2', '\x2', 
		'\x2', '*', '-', '\x3', '\x2', '\x2', '\x2', '+', ')', '\x3', '\x2', '\x2', 
		'\x2', '+', ',', '\x3', '\x2', '\x2', '\x2', ',', '\x5', '\x3', '\x2', 
		'\x2', '\x2', '-', '+', '\x3', '\x2', '\x2', '\x2', '.', '/', '\t', '\x2', 
		'\x2', '\x2', '/', '\a', '\x3', '\x2', '\x2', '\x2', '\x30', '\x31', '\a', 
		'!', '\x2', '\x2', '\x31', '\t', '\x3', '\x2', '\x2', '\x2', '\x32', '\x35', 
		'\x5', '\x16', '\f', '\x2', '\x33', '\x34', '\a', '\x5', '\x2', '\x2', 
		'\x34', '\x36', '\x5', '\x14', '\v', '\x2', '\x35', '\x33', '\x3', '\x2', 
		'\x2', '\x2', '\x35', '\x36', '\x3', '\x2', '\x2', '\x2', '\x36', '\x37', 
		'\x3', '\x2', '\x2', '\x2', '\x37', '\x39', '\a', '\r', '\x2', '\x2', 
		'\x38', ':', '\x5', '\x10', '\t', '\x2', '\x39', '\x38', '\x3', '\x2', 
		'\x2', '\x2', '\x39', ':', '\x3', '\x2', '\x2', '\x2', ':', '@', '\x3', 
		'\x2', '\x2', '\x2', ';', '<', '\x5', '\x16', '\f', '\x2', '<', '=', '\x5', 
		'\xE', '\b', '\x2', '=', '>', '\x5', '\x10', '\t', '\x2', '>', '@', '\x3', 
		'\x2', '\x2', '\x2', '?', '\x32', '\x3', '\x2', '\x2', '\x2', '?', ';', 
		'\x3', '\x2', '\x2', '\x2', '@', '\v', '\x3', '\x2', '\x2', '\x2', '\x41', 
		'\x42', '\t', '\x3', '\x2', '\x2', '\x42', '\r', '\x3', '\x2', '\x2', 
		'\x2', '\x43', '\x44', '\t', '\x4', '\x2', '\x2', '\x44', '\xF', '\x3', 
		'\x2', '\x2', '\x2', '\x45', '\x46', '\x5', '\x12', '\n', '\x2', '\x46', 
		'\x11', '\x3', '\x2', '\x2', '\x2', 'G', 'N', '\a', '\a', '\x2', '\x2', 
		'H', 'N', '\a', '\b', '\x2', '\x2', 'I', 'N', '\a', '\x6', '\x2', '\x2', 
		'J', 'N', '\a', '\"', '\x2', '\x2', 'K', 'N', '\a', '\t', '\x2', '\x2', 
		'L', 'N', '\a', '#', '\x2', '\x2', 'M', 'G', '\x3', '\x2', '\x2', '\x2', 
		'M', 'H', '\x3', '\x2', '\x2', '\x2', 'M', 'I', '\x3', '\x2', '\x2', '\x2', 
		'M', 'J', '\x3', '\x2', '\x2', '\x2', 'M', 'K', '\x3', '\x2', '\x2', '\x2', 
		'M', 'L', '\x3', '\x2', '\x2', '\x2', 'N', '\x13', '\x3', '\x2', '\x2', 
		'\x2', 'O', 'P', '\t', '\x5', '\x2', '\x2', 'P', '\x15', '\x3', '\x2', 
		'\x2', '\x2', 'Q', 'R', '\a', '#', '\x2', '\x2', 'R', '\x17', '\x3', '\x2', 
		'\x2', '\x2', '\t', '\"', '&', '+', '\x35', '\x39', '?', 'M',
	};

	public static readonly ATN _ATN =
		new ATNDeserializer().Deserialize(_serializedATN);


}
} // namespace TaskPrincess.FilterDsl.Antlr