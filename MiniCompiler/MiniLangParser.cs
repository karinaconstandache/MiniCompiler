//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     ANTLR Version: 4.13.1
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from c:/Users/Adina/Desktop/MiniCompiler/MiniCompiler/MiniLang.g4 by ANTLR 4.13.1

// Unreachable code detected
#pragma warning disable 0162
// The variable '...' is assigned but its value is never used
#pragma warning disable 0219
// Missing XML comment for publicly visible type or member '...'
#pragma warning disable 1591
// Ambiguous reference in cref attribute
#pragma warning disable 419

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

[System.CodeDom.Compiler.GeneratedCode("ANTLR", "4.13.1")]
[System.CLSCompliant(false)]
public partial class MiniLangParser : Parser {
	protected static DFA[] decisionToDFA;
	protected static PredictionContextCache sharedContextCache = new PredictionContextCache();
	public const int
		INTEGER_TYPE=1, FLOAT_TYPE=2, STRING_TYPE=3, EQUALS=4, SEMICOLON=5, INTEGER_VALUE=6, 
		FLOAT_VALUE=7, STRING_VALUE=8, VARIABLE_NAME=9, WS=10;
	public const int
		RULE_declaration = 0, RULE_type = 1, RULE_value = 2;
	public static readonly string[] ruleNames = {
		"declaration", "type", "value"
	};

	private static readonly string[] _LiteralNames = {
		null, "'int'", "'float'", "'string'", "'='", "';'"
	};
	private static readonly string[] _SymbolicNames = {
		null, "INTEGER_TYPE", "FLOAT_TYPE", "STRING_TYPE", "EQUALS", "SEMICOLON", 
		"INTEGER_VALUE", "FLOAT_VALUE", "STRING_VALUE", "VARIABLE_NAME", "WS"
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

	public override string GrammarFileName { get { return "MiniLang.g4"; } }

	public override string[] RuleNames { get { return ruleNames; } }

	public override int[] SerializedAtn { get { return _serializedATN; } }

	static MiniLangParser() {
		decisionToDFA = new DFA[_ATN.NumberOfDecisions];
		for (int i = 0; i < _ATN.NumberOfDecisions; i++) {
			decisionToDFA[i] = new DFA(_ATN.GetDecisionState(i), i);
		}
	}

		public MiniLangParser(ITokenStream input) : this(input, Console.Out, Console.Error) { }

		public MiniLangParser(ITokenStream input, TextWriter output, TextWriter errorOutput)
		: base(input, output, errorOutput)
	{
		Interpreter = new ParserATNSimulator(this, _ATN, decisionToDFA, sharedContextCache);
	}

	public partial class DeclarationContext : ParserRuleContext {
		[System.Diagnostics.DebuggerNonUserCode] public TypeContext type() {
			return GetRuleContext<TypeContext>(0);
		}
		[System.Diagnostics.DebuggerNonUserCode] public ITerminalNode VARIABLE_NAME() { return GetToken(MiniLangParser.VARIABLE_NAME, 0); }
		[System.Diagnostics.DebuggerNonUserCode] public ITerminalNode EQUALS() { return GetToken(MiniLangParser.EQUALS, 0); }
		[System.Diagnostics.DebuggerNonUserCode] public ValueContext value() {
			return GetRuleContext<ValueContext>(0);
		}
		[System.Diagnostics.DebuggerNonUserCode] public ITerminalNode SEMICOLON() { return GetToken(MiniLangParser.SEMICOLON, 0); }
		public DeclarationContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_declaration; } }
		[System.Diagnostics.DebuggerNonUserCode]
		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			IMiniLangVisitor<TResult> typedVisitor = visitor as IMiniLangVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitDeclaration(this);
			else return visitor.VisitChildren(this);
		}
	}

	[RuleVersion(0)]
	public DeclarationContext declaration() {
		DeclarationContext _localctx = new DeclarationContext(Context, State);
		EnterRule(_localctx, 0, RULE_declaration);
		try {
			EnterOuterAlt(_localctx, 1);
			{
			State = 6;
			type();
			State = 7;
			Match(VARIABLE_NAME);
			State = 8;
			Match(EQUALS);
			State = 9;
			value();
			State = 10;
			Match(SEMICOLON);
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

	public partial class TypeContext : ParserRuleContext {
		[System.Diagnostics.DebuggerNonUserCode] public ITerminalNode INTEGER_TYPE() { return GetToken(MiniLangParser.INTEGER_TYPE, 0); }
		[System.Diagnostics.DebuggerNonUserCode] public ITerminalNode FLOAT_TYPE() { return GetToken(MiniLangParser.FLOAT_TYPE, 0); }
		[System.Diagnostics.DebuggerNonUserCode] public ITerminalNode STRING_TYPE() { return GetToken(MiniLangParser.STRING_TYPE, 0); }
		public TypeContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_type; } }
		[System.Diagnostics.DebuggerNonUserCode]
		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			IMiniLangVisitor<TResult> typedVisitor = visitor as IMiniLangVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitType(this);
			else return visitor.VisitChildren(this);
		}
	}

	[RuleVersion(0)]
	public TypeContext type() {
		TypeContext _localctx = new TypeContext(Context, State);
		EnterRule(_localctx, 2, RULE_type);
		int _la;
		try {
			EnterOuterAlt(_localctx, 1);
			{
			State = 12;
			_la = TokenStream.LA(1);
			if ( !((((_la) & ~0x3f) == 0 && ((1L << _la) & 14L) != 0)) ) {
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

	public partial class ValueContext : ParserRuleContext {
		[System.Diagnostics.DebuggerNonUserCode] public ITerminalNode INTEGER_VALUE() { return GetToken(MiniLangParser.INTEGER_VALUE, 0); }
		[System.Diagnostics.DebuggerNonUserCode] public ITerminalNode FLOAT_VALUE() { return GetToken(MiniLangParser.FLOAT_VALUE, 0); }
		[System.Diagnostics.DebuggerNonUserCode] public ITerminalNode STRING_VALUE() { return GetToken(MiniLangParser.STRING_VALUE, 0); }
		public ValueContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_value; } }
		[System.Diagnostics.DebuggerNonUserCode]
		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			IMiniLangVisitor<TResult> typedVisitor = visitor as IMiniLangVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitValue(this);
			else return visitor.VisitChildren(this);
		}
	}

	[RuleVersion(0)]
	public ValueContext value() {
		ValueContext _localctx = new ValueContext(Context, State);
		EnterRule(_localctx, 4, RULE_value);
		int _la;
		try {
			EnterOuterAlt(_localctx, 1);
			{
			State = 14;
			_la = TokenStream.LA(1);
			if ( !((((_la) & ~0x3f) == 0 && ((1L << _la) & 448L) != 0)) ) {
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

	private static int[] _serializedATN = {
		4,1,10,17,2,0,7,0,2,1,7,1,2,2,7,2,1,0,1,0,1,0,1,0,1,0,1,0,1,1,1,1,1,2,
		1,2,1,2,0,0,3,0,2,4,0,2,1,0,1,3,1,0,6,8,13,0,6,1,0,0,0,2,12,1,0,0,0,4,
		14,1,0,0,0,6,7,3,2,1,0,7,8,5,9,0,0,8,9,5,4,0,0,9,10,3,4,2,0,10,11,5,5,
		0,0,11,1,1,0,0,0,12,13,7,0,0,0,13,3,1,0,0,0,14,15,7,1,0,0,15,5,1,0,0,0,
		0
	};

	public static readonly ATN _ATN =
		new ATNDeserializer().Deserialize(_serializedATN);


}
