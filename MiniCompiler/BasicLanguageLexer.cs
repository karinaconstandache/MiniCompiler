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
using Antlr4.Runtime;
using Antlr4.Runtime.Atn;
using Antlr4.Runtime.Misc;
using DFA = Antlr4.Runtime.Dfa.DFA;

[System.CodeDom.Compiler.GeneratedCode("ANTLR", "4.13.1")]
[System.CLSCompliant(false)]
public partial class BasicLanguageLexer : Lexer {
	protected static DFA[] decisionToDFA;
	protected static PredictionContextCache sharedContextCache = new PredictionContextCache();
	public const int
		INTEGER_TYPE=1, FLOAT_TYPE=2, STRING_TYPE=3, EQUALS=4, SEMICOLON=5, INTEGER_VALUE=6, 
		FLOAT_VALUE=7, STRING_VALUE=8, VARIABLE_NAME=9, WS=10;
	public static string[] channelNames = {
		"DEFAULT_TOKEN_CHANNEL", "HIDDEN"
	};

	public static string[] modeNames = {
		"DEFAULT_MODE"
	};

	public static readonly string[] ruleNames = {
		"INTEGER_TYPE", "FLOAT_TYPE", "STRING_TYPE", "EQUALS", "SEMICOLON", "INTEGER_VALUE", 
		"FLOAT_VALUE", "STRING_VALUE", "VARIABLE_NAME", "WS"
	};


	public BasicLanguageLexer(ICharStream input)
	: this(input, Console.Out, Console.Error) { }

	public BasicLanguageLexer(ICharStream input, TextWriter output, TextWriter errorOutput)
	: base(input, output, errorOutput)
	{
		Interpreter = new LexerATNSimulator(this, _ATN, decisionToDFA, sharedContextCache);
	}

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

	public override string[] ChannelNames { get { return channelNames; } }

	public override string[] ModeNames { get { return modeNames; } }

	public override int[] SerializedAtn { get { return _serializedATN; } }

	static BasicLanguageLexer() {
		decisionToDFA = new DFA[_ATN.NumberOfDecisions];
		for (int i = 0; i < _ATN.NumberOfDecisions; i++) {
			decisionToDFA[i] = new DFA(_ATN.GetDecisionState(i), i);
		}
	}
	private static int[] _serializedATN = {
		4,0,10,80,6,-1,2,0,7,0,2,1,7,1,2,2,7,2,2,3,7,3,2,4,7,4,2,5,7,5,2,6,7,6,
		2,7,7,7,2,8,7,8,2,9,7,9,1,0,1,0,1,0,1,0,1,1,1,1,1,1,1,1,1,1,1,1,1,2,1,
		2,1,2,1,2,1,2,1,2,1,2,1,3,1,3,1,4,1,4,1,5,4,5,44,8,5,11,5,12,5,45,1,6,
		4,6,49,8,6,11,6,12,6,50,1,6,1,6,4,6,55,8,6,11,6,12,6,56,1,7,1,7,4,7,61,
		8,7,11,7,12,7,62,1,7,1,7,1,8,1,8,5,8,69,8,8,10,8,12,8,72,9,8,1,9,4,9,75,
		8,9,11,9,12,9,76,1,9,1,9,1,62,0,10,1,1,3,2,5,3,7,4,9,5,11,6,13,7,15,8,
		17,9,19,10,1,0,4,1,0,48,57,2,0,65,90,97,122,3,0,48,57,65,90,97,122,3,0,
		9,10,13,13,32,32,85,0,1,1,0,0,0,0,3,1,0,0,0,0,5,1,0,0,0,0,7,1,0,0,0,0,
		9,1,0,0,0,0,11,1,0,0,0,0,13,1,0,0,0,0,15,1,0,0,0,0,17,1,0,0,0,0,19,1,0,
		0,0,1,21,1,0,0,0,3,25,1,0,0,0,5,31,1,0,0,0,7,38,1,0,0,0,9,40,1,0,0,0,11,
		43,1,0,0,0,13,48,1,0,0,0,15,58,1,0,0,0,17,66,1,0,0,0,19,74,1,0,0,0,21,
		22,5,105,0,0,22,23,5,110,0,0,23,24,5,116,0,0,24,2,1,0,0,0,25,26,5,102,
		0,0,26,27,5,108,0,0,27,28,5,111,0,0,28,29,5,97,0,0,29,30,5,116,0,0,30,
		4,1,0,0,0,31,32,5,115,0,0,32,33,5,116,0,0,33,34,5,114,0,0,34,35,5,105,
		0,0,35,36,5,110,0,0,36,37,5,103,0,0,37,6,1,0,0,0,38,39,5,61,0,0,39,8,1,
		0,0,0,40,41,5,59,0,0,41,10,1,0,0,0,42,44,7,0,0,0,43,42,1,0,0,0,44,45,1,
		0,0,0,45,43,1,0,0,0,45,46,1,0,0,0,46,12,1,0,0,0,47,49,7,0,0,0,48,47,1,
		0,0,0,49,50,1,0,0,0,50,48,1,0,0,0,50,51,1,0,0,0,51,52,1,0,0,0,52,54,5,
		46,0,0,53,55,7,0,0,0,54,53,1,0,0,0,55,56,1,0,0,0,56,54,1,0,0,0,56,57,1,
		0,0,0,57,14,1,0,0,0,58,60,5,34,0,0,59,61,9,0,0,0,60,59,1,0,0,0,61,62,1,
		0,0,0,62,63,1,0,0,0,62,60,1,0,0,0,63,64,1,0,0,0,64,65,5,34,0,0,65,16,1,
		0,0,0,66,70,7,1,0,0,67,69,7,2,0,0,68,67,1,0,0,0,69,72,1,0,0,0,70,68,1,
		0,0,0,70,71,1,0,0,0,71,18,1,0,0,0,72,70,1,0,0,0,73,75,7,3,0,0,74,73,1,
		0,0,0,75,76,1,0,0,0,76,74,1,0,0,0,76,77,1,0,0,0,77,78,1,0,0,0,78,79,6,
		9,0,0,79,20,1,0,0,0,7,0,45,50,56,62,70,76,1,6,0,0
	};

	public static readonly ATN _ATN =
		new ATNDeserializer().Deserialize(_serializedATN);


}
