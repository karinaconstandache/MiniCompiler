//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     ANTLR Version: 4.13.1
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from c:/Users/Radu/Desktop/Facultate/An2/LFC/Tema2/MiniCompiler/MiniLang.g4 by ANTLR 4.13.1

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
public partial class MiniLangLexer : Lexer {
	protected static DFA[] decisionToDFA;
	protected static PredictionContextCache sharedContextCache = new PredictionContextCache();
	public const int
		INT=1, FLOAT=2, DOUBLE=3, STRING=4, VOID=5, IF=6, ELSE=7, FOR=8, WHILE=9, 
		RETURN=10, MAIN=11, INTEGER_VALUE=12, FLOAT_VALUE=13, DOUBLE_VALUE=14, 
		STRING_VALUE=15, VARIABLE_NAME=16, RELATIONAL_OPERATOR=17, LOGICAL_OPERATOR=18, 
		ARITHMETIC_OPERATOR=19, INCREMENT_OPERATOR=20, ASSIGNMENT_OPERATOR=21, 
		SEMICOLON=22, COMMA=23, LPAREN=24, RPAREN=25, LBRACE=26, RBRACE=27, WS=28, 
		COMMENT=29, MULTILINE_COMMENT=30;
	public static string[] channelNames = {
		"DEFAULT_TOKEN_CHANNEL", "HIDDEN"
	};

	public static string[] modeNames = {
		"DEFAULT_MODE"
	};

	public static readonly string[] ruleNames = {
		"INT", "FLOAT", "DOUBLE", "STRING", "VOID", "IF", "ELSE", "FOR", "WHILE", 
		"RETURN", "MAIN", "INTEGER_VALUE", "FLOAT_VALUE", "DOUBLE_VALUE", "STRING_VALUE", 
		"VARIABLE_NAME", "RELATIONAL_OPERATOR", "LOGICAL_OPERATOR", "ARITHMETIC_OPERATOR", 
		"INCREMENT_OPERATOR", "ASSIGNMENT_OPERATOR", "SEMICOLON", "COMMA", "LPAREN", 
		"RPAREN", "LBRACE", "RBRACE", "WS", "COMMENT", "MULTILINE_COMMENT"
	};


	public MiniLangLexer(ICharStream input)
	: this(input, Console.Out, Console.Error) { }

	public MiniLangLexer(ICharStream input, TextWriter output, TextWriter errorOutput)
	: base(input, output, errorOutput)
	{
		Interpreter = new LexerATNSimulator(this, _ATN, decisionToDFA, sharedContextCache);
	}

	private static readonly string[] _LiteralNames = {
		null, "'int'", "'float'", "'double'", "'string'", "'void'", "'if'", "'else'", 
		"'for'", "'while'", "'return'", "'main'", null, null, null, null, null, 
		null, null, null, null, null, "';'", "','", "'('", "')'", "'{'", "'}'"
	};
	private static readonly string[] _SymbolicNames = {
		null, "INT", "FLOAT", "DOUBLE", "STRING", "VOID", "IF", "ELSE", "FOR", 
		"WHILE", "RETURN", "MAIN", "INTEGER_VALUE", "FLOAT_VALUE", "DOUBLE_VALUE", 
		"STRING_VALUE", "VARIABLE_NAME", "RELATIONAL_OPERATOR", "LOGICAL_OPERATOR", 
		"ARITHMETIC_OPERATOR", "INCREMENT_OPERATOR", "ASSIGNMENT_OPERATOR", "SEMICOLON", 
		"COMMA", "LPAREN", "RPAREN", "LBRACE", "RBRACE", "WS", "COMMENT", "MULTILINE_COMMENT"
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

	static MiniLangLexer() {
		decisionToDFA = new DFA[_ATN.NumberOfDecisions];
		for (int i = 0; i < _ATN.NumberOfDecisions; i++) {
			decisionToDFA[i] = new DFA(_ATN.GetDecisionState(i), i);
		}
	}
	private static int[] _serializedATN = {
		4,0,30,251,6,-1,2,0,7,0,2,1,7,1,2,2,7,2,2,3,7,3,2,4,7,4,2,5,7,5,2,6,7,
		6,2,7,7,7,2,8,7,8,2,9,7,9,2,10,7,10,2,11,7,11,2,12,7,12,2,13,7,13,2,14,
		7,14,2,15,7,15,2,16,7,16,2,17,7,17,2,18,7,18,2,19,7,19,2,20,7,20,2,21,
		7,21,2,22,7,22,2,23,7,23,2,24,7,24,2,25,7,25,2,26,7,26,2,27,7,27,2,28,
		7,28,2,29,7,29,1,0,1,0,1,0,1,0,1,1,1,1,1,1,1,1,1,1,1,1,1,2,1,2,1,2,1,2,
		1,2,1,2,1,2,1,3,1,3,1,3,1,3,1,3,1,3,1,3,1,4,1,4,1,4,1,4,1,4,1,5,1,5,1,
		5,1,6,1,6,1,6,1,6,1,6,1,7,1,7,1,7,1,7,1,8,1,8,1,8,1,8,1,8,1,8,1,9,1,9,
		1,9,1,9,1,9,1,9,1,9,1,10,1,10,1,10,1,10,1,10,1,11,4,11,122,8,11,11,11,
		12,11,123,1,12,4,12,127,8,12,11,12,12,12,128,1,12,1,12,4,12,133,8,12,11,
		12,12,12,134,1,13,4,13,138,8,13,11,13,12,13,139,1,13,1,13,4,13,144,8,13,
		11,13,12,13,145,1,13,1,13,3,13,150,8,13,1,13,4,13,153,8,13,11,13,12,13,
		154,3,13,157,8,13,1,14,1,14,5,14,161,8,14,10,14,12,14,164,9,14,1,14,1,
		14,1,15,1,15,5,15,170,8,15,10,15,12,15,173,9,15,1,16,1,16,1,16,1,16,1,
		16,1,16,1,16,1,16,1,16,3,16,184,8,16,1,17,1,17,1,17,1,17,3,17,190,8,17,
		1,18,1,18,1,19,1,19,1,19,1,19,3,19,198,8,19,1,20,1,20,1,20,1,20,1,20,1,
		20,1,20,1,20,1,20,1,20,1,20,3,20,211,8,20,1,21,1,21,1,22,1,22,1,23,1,23,
		1,24,1,24,1,25,1,25,1,26,1,26,1,27,4,27,226,8,27,11,27,12,27,227,1,27,
		1,27,1,28,1,28,1,28,1,28,5,28,236,8,28,10,28,12,28,239,9,28,1,28,1,28,
		1,29,1,29,3,29,245,8,29,1,29,1,29,1,29,1,29,1,29,1,162,0,30,1,1,3,2,5,
		3,7,4,9,5,11,6,13,7,15,8,17,9,19,10,21,11,23,12,25,13,27,14,29,15,31,16,
		33,17,35,18,37,19,39,20,41,21,43,22,45,23,47,24,49,25,51,26,53,27,55,28,
		57,29,59,30,1,0,8,1,0,48,57,2,0,43,43,45,45,3,0,65,90,95,95,97,122,4,0,
		48,57,65,90,95,95,97,122,2,0,60,60,62,62,4,0,37,37,42,43,45,45,47,47,3,
		0,9,10,13,13,32,32,2,0,10,10,13,13,274,0,1,1,0,0,0,0,3,1,0,0,0,0,5,1,0,
		0,0,0,7,1,0,0,0,0,9,1,0,0,0,0,11,1,0,0,0,0,13,1,0,0,0,0,15,1,0,0,0,0,17,
		1,0,0,0,0,19,1,0,0,0,0,21,1,0,0,0,0,23,1,0,0,0,0,25,1,0,0,0,0,27,1,0,0,
		0,0,29,1,0,0,0,0,31,1,0,0,0,0,33,1,0,0,0,0,35,1,0,0,0,0,37,1,0,0,0,0,39,
		1,0,0,0,0,41,1,0,0,0,0,43,1,0,0,0,0,45,1,0,0,0,0,47,1,0,0,0,0,49,1,0,0,
		0,0,51,1,0,0,0,0,53,1,0,0,0,0,55,1,0,0,0,0,57,1,0,0,0,0,59,1,0,0,0,1,61,
		1,0,0,0,3,65,1,0,0,0,5,71,1,0,0,0,7,78,1,0,0,0,9,85,1,0,0,0,11,90,1,0,
		0,0,13,93,1,0,0,0,15,98,1,0,0,0,17,102,1,0,0,0,19,108,1,0,0,0,21,115,1,
		0,0,0,23,121,1,0,0,0,25,126,1,0,0,0,27,137,1,0,0,0,29,158,1,0,0,0,31,167,
		1,0,0,0,33,183,1,0,0,0,35,189,1,0,0,0,37,191,1,0,0,0,39,197,1,0,0,0,41,
		210,1,0,0,0,43,212,1,0,0,0,45,214,1,0,0,0,47,216,1,0,0,0,49,218,1,0,0,
		0,51,220,1,0,0,0,53,222,1,0,0,0,55,225,1,0,0,0,57,231,1,0,0,0,59,242,1,
		0,0,0,61,62,5,105,0,0,62,63,5,110,0,0,63,64,5,116,0,0,64,2,1,0,0,0,65,
		66,5,102,0,0,66,67,5,108,0,0,67,68,5,111,0,0,68,69,5,97,0,0,69,70,5,116,
		0,0,70,4,1,0,0,0,71,72,5,100,0,0,72,73,5,111,0,0,73,74,5,117,0,0,74,75,
		5,98,0,0,75,76,5,108,0,0,76,77,5,101,0,0,77,6,1,0,0,0,78,79,5,115,0,0,
		79,80,5,116,0,0,80,81,5,114,0,0,81,82,5,105,0,0,82,83,5,110,0,0,83,84,
		5,103,0,0,84,8,1,0,0,0,85,86,5,118,0,0,86,87,5,111,0,0,87,88,5,105,0,0,
		88,89,5,100,0,0,89,10,1,0,0,0,90,91,5,105,0,0,91,92,5,102,0,0,92,12,1,
		0,0,0,93,94,5,101,0,0,94,95,5,108,0,0,95,96,5,115,0,0,96,97,5,101,0,0,
		97,14,1,0,0,0,98,99,5,102,0,0,99,100,5,111,0,0,100,101,5,114,0,0,101,16,
		1,0,0,0,102,103,5,119,0,0,103,104,5,104,0,0,104,105,5,105,0,0,105,106,
		5,108,0,0,106,107,5,101,0,0,107,18,1,0,0,0,108,109,5,114,0,0,109,110,5,
		101,0,0,110,111,5,116,0,0,111,112,5,117,0,0,112,113,5,114,0,0,113,114,
		5,110,0,0,114,20,1,0,0,0,115,116,5,109,0,0,116,117,5,97,0,0,117,118,5,
		105,0,0,118,119,5,110,0,0,119,22,1,0,0,0,120,122,7,0,0,0,121,120,1,0,0,
		0,122,123,1,0,0,0,123,121,1,0,0,0,123,124,1,0,0,0,124,24,1,0,0,0,125,127,
		7,0,0,0,126,125,1,0,0,0,127,128,1,0,0,0,128,126,1,0,0,0,128,129,1,0,0,
		0,129,130,1,0,0,0,130,132,5,46,0,0,131,133,7,0,0,0,132,131,1,0,0,0,133,
		134,1,0,0,0,134,132,1,0,0,0,134,135,1,0,0,0,135,26,1,0,0,0,136,138,7,0,
		0,0,137,136,1,0,0,0,138,139,1,0,0,0,139,137,1,0,0,0,139,140,1,0,0,0,140,
		141,1,0,0,0,141,143,5,46,0,0,142,144,7,0,0,0,143,142,1,0,0,0,144,145,1,
		0,0,0,145,143,1,0,0,0,145,146,1,0,0,0,146,156,1,0,0,0,147,149,5,101,0,
		0,148,150,7,1,0,0,149,148,1,0,0,0,149,150,1,0,0,0,150,152,1,0,0,0,151,
		153,7,0,0,0,152,151,1,0,0,0,153,154,1,0,0,0,154,152,1,0,0,0,154,155,1,
		0,0,0,155,157,1,0,0,0,156,147,1,0,0,0,156,157,1,0,0,0,157,28,1,0,0,0,158,
		162,5,34,0,0,159,161,9,0,0,0,160,159,1,0,0,0,161,164,1,0,0,0,162,163,1,
		0,0,0,162,160,1,0,0,0,163,165,1,0,0,0,164,162,1,0,0,0,165,166,5,34,0,0,
		166,30,1,0,0,0,167,171,7,2,0,0,168,170,7,3,0,0,169,168,1,0,0,0,170,173,
		1,0,0,0,171,169,1,0,0,0,171,172,1,0,0,0,172,32,1,0,0,0,173,171,1,0,0,0,
		174,184,7,4,0,0,175,176,5,60,0,0,176,184,5,61,0,0,177,178,5,62,0,0,178,
		184,5,61,0,0,179,180,5,61,0,0,180,184,5,61,0,0,181,182,5,33,0,0,182,184,
		5,61,0,0,183,174,1,0,0,0,183,175,1,0,0,0,183,177,1,0,0,0,183,179,1,0,0,
		0,183,181,1,0,0,0,184,34,1,0,0,0,185,186,5,38,0,0,186,190,5,38,0,0,187,
		188,5,124,0,0,188,190,5,124,0,0,189,185,1,0,0,0,189,187,1,0,0,0,190,36,
		1,0,0,0,191,192,7,5,0,0,192,38,1,0,0,0,193,194,5,43,0,0,194,198,5,43,0,
		0,195,196,5,45,0,0,196,198,5,45,0,0,197,193,1,0,0,0,197,195,1,0,0,0,198,
		40,1,0,0,0,199,211,5,61,0,0,200,201,5,43,0,0,201,211,5,61,0,0,202,203,
		5,45,0,0,203,211,5,61,0,0,204,205,5,42,0,0,205,211,5,61,0,0,206,207,5,
		47,0,0,207,211,5,61,0,0,208,209,5,37,0,0,209,211,5,61,0,0,210,199,1,0,
		0,0,210,200,1,0,0,0,210,202,1,0,0,0,210,204,1,0,0,0,210,206,1,0,0,0,210,
		208,1,0,0,0,211,42,1,0,0,0,212,213,5,59,0,0,213,44,1,0,0,0,214,215,5,44,
		0,0,215,46,1,0,0,0,216,217,5,40,0,0,217,48,1,0,0,0,218,219,5,41,0,0,219,
		50,1,0,0,0,220,221,5,123,0,0,221,52,1,0,0,0,222,223,5,125,0,0,223,54,1,
		0,0,0,224,226,7,6,0,0,225,224,1,0,0,0,226,227,1,0,0,0,227,225,1,0,0,0,
		227,228,1,0,0,0,228,229,1,0,0,0,229,230,6,27,0,0,230,56,1,0,0,0,231,232,
		5,47,0,0,232,233,5,47,0,0,233,237,1,0,0,0,234,236,8,7,0,0,235,234,1,0,
		0,0,236,239,1,0,0,0,237,235,1,0,0,0,237,238,1,0,0,0,238,240,1,0,0,0,239,
		237,1,0,0,0,240,241,6,28,0,0,241,58,1,0,0,0,242,244,5,47,0,0,243,245,9,
		0,0,0,244,243,1,0,0,0,244,245,1,0,0,0,245,246,1,0,0,0,246,247,5,42,0,0,
		247,248,5,47,0,0,248,249,1,0,0,0,249,250,6,29,0,0,250,60,1,0,0,0,18,0,
		123,128,134,139,145,149,154,156,162,171,183,189,197,210,227,237,244,1,
		6,0,0
	};

	public static readonly ATN _ATN =
		new ATNDeserializer().Deserialize(_serializedATN);


}
