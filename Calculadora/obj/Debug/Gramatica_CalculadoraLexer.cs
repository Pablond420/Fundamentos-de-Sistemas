//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     ANTLR Version: 4.6.6
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from C:\Users\Usuario\Google Drive\UASLP\Semestre X\Fundamentos de Software de Sistemas\Laboratorio\Fundamentos-de-Sistemas\Calculadora\Gramatica_Calculadora.g4 by ANTLR 4.6.6

// Unreachable code detected
#pragma warning disable 0162
// The variable '...' is assigned but its value is never used
#pragma warning disable 0219
// Missing XML comment for publicly visible type or member '...'
#pragma warning disable 1591
// Ambiguous reference in cref attribute
#pragma warning disable 419

namespace Calculadora {
using Antlr4.Runtime;
using Antlr4.Runtime.Atn;
using Antlr4.Runtime.Misc;
using DFA = Antlr4.Runtime.Dfa.DFA;

[System.CodeDom.Compiler.GeneratedCode("ANTLR", "4.6.6")]
[System.CLSCompliant(false)]
public partial class Gramatica_CalculadoraLexer : Lexer {
	public const int
		CONSTHEX=1, CONSTCAD=2, RSUB=3, COD_OP_F1=4, COD_OP_F2=5, COD_OP_F3=6, 
		REG=7, WORD=8, RESB=9, START=10, RESW=11, END=12, BYTE=13, BASE=14, ARROBA=15, 
		HASHTAG=16, FORMATO4=17, COMA=18, COMILLA=19, NUM=20, MEM_DIR=21, FINL=22, 
		WS=23;
	public static string[] modeNames = {
		"DEFAULT_MODE"
	};

	public static readonly string[] ruleNames = {
		"CONSTHEX", "CONSTCAD", "RSUB", "COD_OP_F1", "COD_OP_F2", "COD_OP_F3", 
		"REG", "WORD", "RESB", "START", "RESW", "END", "BYTE", "BASE", "ARROBA", 
		"HASHTAG", "FORMATO4", "COMA", "COMILLA", "NUM", "MEM_DIR", "FINL", "WS"
	};


	public Gramatica_CalculadoraLexer(ICharStream input)
		: base(input)
	{
		_interp = new LexerATNSimulator(this,_ATN);
	}

	private static readonly string[] _LiteralNames = {
		null, null, null, null, null, null, null, null, null, null, null, null, 
		null, null, null, "'@'", "'#'", "'+'", null, "'\"'", null, null, "'\n'"
	};
	private static readonly string[] _SymbolicNames = {
		null, "CONSTHEX", "CONSTCAD", "RSUB", "COD_OP_F1", "COD_OP_F2", "COD_OP_F3", 
		"REG", "WORD", "RESB", "START", "RESW", "END", "BYTE", "BASE", "ARROBA", 
		"HASHTAG", "FORMATO4", "COMA", "COMILLA", "NUM", "MEM_DIR", "FINL", "WS"
	};
	public static readonly IVocabulary DefaultVocabulary = new Vocabulary(_LiteralNames, _SymbolicNames);

	[System.Obsolete("Use Vocabulary instead.")]
	public static readonly string[] tokenNames = GenerateTokenNames(DefaultVocabulary, _SymbolicNames.Length);

	private static string[] GenerateTokenNames(IVocabulary vocabulary, int length) {
		string[] tokenNames = new string[length];
		for (int i = 0; i < tokenNames.Length; i++) {
			tokenNames[i] = vocabulary.GetLiteralName(i);
			if (tokenNames[i] == null) {
				tokenNames[i] = vocabulary.GetSymbolicName(i);
			}

			if (tokenNames[i] == null) {
				tokenNames[i] = "<INVALID>";
			}
		}

		return tokenNames;
	}

	[System.Obsolete("Use IRecognizer.Vocabulary instead.")]
	public override string[] TokenNames
	{
		get
		{
			return tokenNames;
		}
	}

	[NotNull]
	public override IVocabulary Vocabulary
	{
		get
		{
			return DefaultVocabulary;
		}
	}

	public override string GrammarFileName { get { return "Gramatica_Calculadora.g4"; } }

	public override string[] RuleNames { get { return ruleNames; } }

	public override string[] ModeNames { get { return modeNames; } }

	public override string SerializedAtn { get { return _serializedATN; } }

	public override void Action(RuleContext _localctx, int ruleIndex, int actionIndex) {
		switch (ruleIndex) {
		case 22 : WS_action(_localctx, actionIndex); break;
		}
	}
	private void WS_action(RuleContext _localctx, int actionIndex) {
		switch (actionIndex) {
		case 0: Skip(); break;
		}
	}

	public static readonly string _serializedATN =
		"\x3\xAF6F\x8320\x479D\xB75C\x4880\x1605\x191C\xAB37\x2\x19\x23D\b\x1\x4"+
		"\x2\t\x2\x4\x3\t\x3\x4\x4\t\x4\x4\x5\t\x5\x4\x6\t\x6\x4\a\t\a\x4\b\t\b"+
		"\x4\t\t\t\x4\n\t\n\x4\v\t\v\x4\f\t\f\x4\r\t\r\x4\xE\t\xE\x4\xF\t\xF\x4"+
		"\x10\t\x10\x4\x11\t\x11\x4\x12\t\x12\x4\x13\t\x13\x4\x14\t\x14\x4\x15"+
		"\t\x15\x4\x16\t\x16\x4\x17\t\x17\x4\x18\t\x18\x3\x2\x3\x2\x3\x2\x3\x2"+
		"\x6\x2\x36\n\x2\r\x2\xE\x2\x37\x3\x2\x3\x2\x3\x3\x3\x3\x3\x3\x3\x3\x6"+
		"\x3@\n\x3\r\x3\xE\x3\x41\x3\x3\x3\x3\x3\x4\x3\x4\x3\x4\x3\x4\x3\x4\x3"+
		"\x4\x3\x4\x3\x4\x3\x4\x5\x4O\n\x4\x3\x5\x3\x5\x3\x5\x3\x5\x3\x5\x3\x5"+
		"\x3\x5\x3\x5\x3\x5\x3\x5\x3\x5\x3\x5\x3\x5\x3\x5\x3\x5\x3\x5\x3\x5\x3"+
		"\x5\x3\x5\x3\x5\x3\x5\x3\x5\x3\x5\x3\x5\x3\x5\x3\x5\x3\x5\x3\x5\x3\x5"+
		"\x3\x5\x3\x5\x3\x5\x3\x5\x3\x5\x3\x5\x3\x5\x3\x5\x3\x5\x3\x5\x3\x5\x3"+
		"\x5\x3\x5\x3\x5\x3\x5\x3\x5\x3\x5\x3\x5\x3\x5\x5\x5\x81\n\x5\x3\x6\x3"+
		"\x6\x3\x6\x3\x6\x3\x6\x3\x6\x3\x6\x3\x6\x3\x6\x3\x6\x3\x6\x3\x6\x3\x6"+
		"\x3\x6\x3\x6\x3\x6\x3\x6\x3\x6\x3\x6\x3\x6\x3\x6\x3\x6\x3\x6\x3\x6\x3"+
		"\x6\x3\x6\x3\x6\x3\x6\x3\x6\x3\x6\x3\x6\x3\x6\x3\x6\x3\x6\x3\x6\x3\x6"+
		"\x3\x6\x3\x6\x3\x6\x3\x6\x3\x6\x3\x6\x3\x6\x3\x6\x3\x6\x3\x6\x3\x6\x3"+
		"\x6\x3\x6\x3\x6\x3\x6\x3\x6\x3\x6\x3\x6\x3\x6\x3\x6\x3\x6\x3\x6\x3\x6"+
		"\x3\x6\x3\x6\x3\x6\x3\x6\x3\x6\x3\x6\x3\x6\x3\x6\x3\x6\x3\x6\x3\x6\x3"+
		"\x6\x3\x6\x3\x6\x3\x6\x3\x6\x3\x6\x3\x6\x3\x6\x3\x6\x3\x6\x3\x6\x3\x6"+
		"\x3\x6\x3\x6\x3\x6\x3\x6\x3\x6\x3\x6\x3\x6\x3\x6\x3\x6\x3\x6\x3\x6\x3"+
		"\x6\x3\x6\x3\x6\x3\x6\x3\x6\x3\x6\x3\x6\x3\x6\x3\x6\x3\x6\x3\x6\x3\x6"+
		"\x3\x6\x3\x6\x5\x6\xEE\n\x6\x3\a\x3\a\x3\a\x3\a\x3\a\x3\a\x3\a\x3\a\x3"+
		"\a\x3\a\x3\a\x3\a\x3\a\x3\a\x3\a\x3\a\x3\a\x3\a\x3\a\x3\a\x3\a\x3\a\x3"+
		"\a\x3\a\x3\a\x3\a\x3\a\x3\a\x3\a\x3\a\x3\a\x3\a\x3\a\x3\a\x3\a\x3\a\x3"+
		"\a\x3\a\x3\a\x3\a\x3\a\x3\a\x3\a\x3\a\x3\a\x3\a\x3\a\x3\a\x3\a\x3\a\x3"+
		"\a\x3\a\x3\a\x3\a\x3\a\x3\a\x3\a\x3\a\x3\a\x3\a\x3\a\x3\a\x3\a\x3\a\x3"+
		"\a\x3\a\x3\a\x3\a\x3\a\x3\a\x3\a\x3\a\x3\a\x3\a\x3\a\x3\a\x3\a\x3\a\x3"+
		"\a\x3\a\x3\a\x3\a\x3\a\x3\a\x3\a\x3\a\x3\a\x3\a\x3\a\x3\a\x3\a\x3\a\x3"+
		"\a\x3\a\x3\a\x3\a\x3\a\x3\a\x3\a\x3\a\x3\a\x3\a\x3\a\x3\a\x3\a\x3\a\x3"+
		"\a\x3\a\x3\a\x3\a\x3\a\x3\a\x3\a\x3\a\x3\a\x3\a\x3\a\x3\a\x3\a\x3\a\x3"+
		"\a\x3\a\x3\a\x3\a\x3\a\x3\a\x3\a\x3\a\x3\a\x3\a\x3\a\x3\a\x3\a\x3\a\x3"+
		"\a\x3\a\x3\a\x3\a\x3\a\x3\a\x3\a\x3\a\x3\a\x3\a\x3\a\x3\a\x3\a\x3\a\x3"+
		"\a\x3\a\x3\a\x3\a\x3\a\x3\a\x3\a\x3\a\x3\a\x3\a\x3\a\x3\a\x3\a\x3\a\x3"+
		"\a\x3\a\x3\a\x3\a\x3\a\x3\a\x3\a\x5\a\x199\n\a\x3\b\x3\b\x3\b\x3\b\x3"+
		"\b\x3\b\x3\b\x3\b\x3\b\x3\b\x3\b\x3\b\x3\b\x3\b\x3\b\x3\b\x3\b\x3\b\x3"+
		"\b\x3\b\x3\b\x3\b\x3\b\x3\b\x3\b\x3\b\x3\b\x3\b\x3\b\x3\b\x5\b\x1B9\n"+
		"\b\x3\t\x3\t\x3\t\x3\t\x3\t\x3\t\x3\t\x3\t\x3\t\x5\t\x1C4\n\t\x3\n\x3"+
		"\n\x3\n\x3\n\x3\n\x3\n\x3\n\x3\n\x3\n\x5\n\x1CF\n\n\x3\v\x3\v\x3\v\x3"+
		"\v\x3\v\x3\v\x3\v\x3\v\x3\v\x3\v\x3\v\x5\v\x1DC\n\v\x3\f\x3\f\x3\f\x3"+
		"\f\x3\f\x3\f\x3\f\x3\f\x3\f\x5\f\x1E7\n\f\x3\r\x3\r\x3\r\x3\r\x3\r\x3"+
		"\r\x3\r\x5\r\x1F0\n\r\x3\xE\x3\xE\x3\xE\x3\xE\x3\xE\x3\xE\x3\xE\x3\xE"+
		"\x3\xE\x5\xE\x1FB\n\xE\x3\xF\x3\xF\x3\xF\x3\xF\x3\xF\x3\xF\x3\xF\x3\xF"+
		"\x3\xF\x5\xF\x206\n\xF\x3\x10\x3\x10\x3\x11\x3\x11\x3\x12\x3\x12\x3\x13"+
		"\x3\x13\x3\x13\x5\x13\x211\n\x13\x3\x14\x3\x14\x3\x15\x6\x15\x216\n\x15"+
		"\r\x15\xE\x15\x217\x3\x15\x6\x15\x21B\n\x15\r\x15\xE\x15\x21C\x3\x15\x3"+
		"\x15\x6\x15\x221\n\x15\r\x15\xE\x15\x222\x3\x15\x5\x15\x226\n\x15\x3\x16"+
		"\x6\x16\x229\n\x16\r\x16\xE\x16\x22A\x3\x16\x6\x16\x22E\n\x16\r\x16\xE"+
		"\x16\x22F\x3\x16\x5\x16\x233\n\x16\x3\x17\x3\x17\x3\x18\x6\x18\x238\n"+
		"\x18\r\x18\xE\x18\x239\x3\x18\x3\x18\x2\x2\x2\x19\x3\x2\x3\x5\x2\x4\a"+
		"\x2\x5\t\x2\x6\v\x2\a\r\x2\b\xF\x2\t\x11\x2\n\x13\x2\v\x15\x2\f\x17\x2"+
		"\r\x19\x2\xE\x1B\x2\xF\x1D\x2\x10\x1F\x2\x11!\x2\x12#\x2\x13%\x2\x14\'"+
		"\x2\x15)\x2\x16+\x2\x17-\x2\x18/\x2\x19\x3\x2\x6\x4\x2\x32;\x43H\x5\x2"+
		"\x32;\x43\\\x63|\a\x2\x43\x44HHNNUVZZ\x5\x2\v\f\xF\xF\"\"\x2A5\x2\x3\x3"+
		"\x2\x2\x2\x2\x5\x3\x2\x2\x2\x2\a\x3\x2\x2\x2\x2\t\x3\x2\x2\x2\x2\v\x3"+
		"\x2\x2\x2\x2\r\x3\x2\x2\x2\x2\xF\x3\x2\x2\x2\x2\x11\x3\x2\x2\x2\x2\x13"+
		"\x3\x2\x2\x2\x2\x15\x3\x2\x2\x2\x2\x17\x3\x2\x2\x2\x2\x19\x3\x2\x2\x2"+
		"\x2\x1B\x3\x2\x2\x2\x2\x1D\x3\x2\x2\x2\x2\x1F\x3\x2\x2\x2\x2!\x3\x2\x2"+
		"\x2\x2#\x3\x2\x2\x2\x2%\x3\x2\x2\x2\x2\'\x3\x2\x2\x2\x2)\x3\x2\x2\x2\x2"+
		"+\x3\x2\x2\x2\x2-\x3\x2\x2\x2\x2/\x3\x2\x2\x2\x3\x31\x3\x2\x2\x2\x5;\x3"+
		"\x2\x2\x2\aN\x3\x2\x2\x2\t\x80\x3\x2\x2\x2\v\xED\x3\x2\x2\x2\r\x198\x3"+
		"\x2\x2\x2\xF\x1B8\x3\x2\x2\x2\x11\x1C3\x3\x2\x2\x2\x13\x1CE\x3\x2\x2\x2"+
		"\x15\x1DB\x3\x2\x2\x2\x17\x1E6\x3\x2\x2\x2\x19\x1EF\x3\x2\x2\x2\x1B\x1FA"+
		"\x3\x2\x2\x2\x1D\x205\x3\x2\x2\x2\x1F\x207\x3\x2\x2\x2!\x209\x3\x2\x2"+
		"\x2#\x20B\x3\x2\x2\x2%\x210\x3\x2\x2\x2\'\x212\x3\x2\x2\x2)\x225\x3\x2"+
		"\x2\x2+\x232\x3\x2\x2\x2-\x234\x3\x2\x2\x2/\x237\x3\x2\x2\x2\x31\x32\a"+
		"Z\x2\x2\x32\x33\a$\x2\x2\x33\x35\x3\x2\x2\x2\x34\x36\t\x2\x2\x2\x35\x34"+
		"\x3\x2\x2\x2\x36\x37\x3\x2\x2\x2\x37\x35\x3\x2\x2\x2\x37\x38\x3\x2\x2"+
		"\x2\x38\x39\x3\x2\x2\x2\x39:\a$\x2\x2:\x4\x3\x2\x2\x2;<\a\x45\x2\x2<="+
		"\a$\x2\x2=?\x3\x2\x2\x2>@\t\x3\x2\x2?>\x3\x2\x2\x2@\x41\x3\x2\x2\x2\x41"+
		"?\x3\x2\x2\x2\x41\x42\x3\x2\x2\x2\x42\x43\x3\x2\x2\x2\x43\x44\a$\x2\x2"+
		"\x44\x6\x3\x2\x2\x2\x45\x46\aT\x2\x2\x46G\aU\x2\x2GH\aW\x2\x2HO\a\x44"+
		"\x2\x2IJ\aT\x2\x2JK\aU\x2\x2KL\aW\x2\x2LM\a\x44\x2\x2MO\a\"\x2\x2N\x45"+
		"\x3\x2\x2\x2NI\x3\x2\x2\x2O\b\x3\x2\x2\x2PQ\aH\x2\x2QR\aK\x2\x2RS\aZ\x2"+
		"\x2S\x81\a\"\x2\x2TU\aH\x2\x2UV\aN\x2\x2VW\aQ\x2\x2WX\a\x43\x2\x2XY\a"+
		"V\x2\x2Y\x81\a\"\x2\x2Z[\aJ\x2\x2[\\\aK\x2\x2\\]\aQ\x2\x2]\x81\a\"\x2"+
		"\x2^_\aP\x2\x2_`\aQ\x2\x2`\x61\aT\x2\x2\x61\x62\aO\x2\x2\x62\x81\a\"\x2"+
		"\x2\x63\x64\aU\x2\x2\x64\x65\aK\x2\x2\x65\x66\aQ\x2\x2\x66\x81\a\"\x2"+
		"\x2gh\aV\x2\x2hi\aK\x2\x2ij\aQ\x2\x2j\x81\a\"\x2\x2kl\aH\x2\x2lm\aK\x2"+
		"\x2m\x81\aZ\x2\x2no\aH\x2\x2op\aN\x2\x2pq\aQ\x2\x2qr\a\x43\x2\x2r\x81"+
		"\aV\x2\x2st\aJ\x2\x2tu\aK\x2\x2u\x81\aQ\x2\x2vw\aP\x2\x2wx\aQ\x2\x2xy"+
		"\aT\x2\x2y\x81\aO\x2\x2z{\aU\x2\x2{|\aK\x2\x2|\x81\aQ\x2\x2}~\aV\x2\x2"+
		"~\x7F\aK\x2\x2\x7F\x81\aQ\x2\x2\x80P\x3\x2\x2\x2\x80T\x3\x2\x2\x2\x80"+
		"Z\x3\x2\x2\x2\x80^\x3\x2\x2\x2\x80\x63\x3\x2\x2\x2\x80g\x3\x2\x2\x2\x80"+
		"k\x3\x2\x2\x2\x80n\x3\x2\x2\x2\x80s\x3\x2\x2\x2\x80v\x3\x2\x2\x2\x80z"+
		"\x3\x2\x2\x2\x80}\x3\x2\x2\x2\x81\n\x3\x2\x2\x2\x82\x83\a\x43\x2\x2\x83"+
		"\x84\a\x46\x2\x2\x84\x85\a\x46\x2\x2\x85\x86\aT\x2\x2\x86\xEE\a\"\x2\x2"+
		"\x87\x88\a\x45\x2\x2\x88\x89\aN\x2\x2\x89\x8A\aG\x2\x2\x8A\x8B\a\x43\x2"+
		"\x2\x8B\x8C\aT\x2\x2\x8C\xEE\a\"\x2\x2\x8D\x8E\a\x45\x2\x2\x8E\x8F\aQ"+
		"\x2\x2\x8F\x90\aO\x2\x2\x90\x91\aR\x2\x2\x91\x92\aT\x2\x2\x92\xEE\a\""+
		"\x2\x2\x93\x94\a\x46\x2\x2\x94\x95\aK\x2\x2\x95\x96\aX\x2\x2\x96\x97\a"+
		"T\x2\x2\x97\xEE\a\"\x2\x2\x98\x99\aO\x2\x2\x99\x9A\aW\x2\x2\x9A\x9B\a"+
		"N\x2\x2\x9B\x9C\aT\x2\x2\x9C\xEE\a\"\x2\x2\x9D\x9E\aT\x2\x2\x9E\x9F\a"+
		"O\x2\x2\x9F\xA0\aQ\x2\x2\xA0\xEE\a\"\x2\x2\xA1\xA2\aU\x2\x2\xA2\xA3\a"+
		"J\x2\x2\xA3\xA4\aK\x2\x2\xA4\xA5\aH\x2\x2\xA5\xA6\aV\x2\x2\xA6\xA7\aN"+
		"\x2\x2\xA7\xEE\a\"\x2\x2\xA8\xA9\aU\x2\x2\xA9\xAA\aJ\x2\x2\xAA\xAB\aK"+
		"\x2\x2\xAB\xAC\aH\x2\x2\xAC\xAD\aV\x2\x2\xAD\xAE\aT\x2\x2\xAE\xEE\a\""+
		"\x2\x2\xAF\xB0\aU\x2\x2\xB0\xB1\aW\x2\x2\xB1\xB2\a\x44\x2\x2\xB2\xB3\a"+
		"T\x2\x2\xB3\xEE\a\"\x2\x2\xB4\xB5\aU\x2\x2\xB5\xB6\aX\x2\x2\xB6\xB7\a"+
		"\x45\x2\x2\xB7\xEE\a\"\x2\x2\xB8\xB9\aV\x2\x2\xB9\xBA\aK\x2\x2\xBA\xBB"+
		"\aZ\x2\x2\xBB\xBC\aT\x2\x2\xBC\xEE\a\"\x2\x2\xBD\xBE\a\x43\x2\x2\xBE\xBF"+
		"\a\x46\x2\x2\xBF\xC0\a\x46\x2\x2\xC0\xEE\aT\x2\x2\xC1\xC2\a\x45\x2\x2"+
		"\xC2\xC3\aN\x2\x2\xC3\xC4\aG\x2\x2\xC4\xC5\a\x43\x2\x2\xC5\xEE\aT\x2\x2"+
		"\xC6\xC7\a\x45\x2\x2\xC7\xC8\aQ\x2\x2\xC8\xC9\aO\x2\x2\xC9\xCA\aR\x2\x2"+
		"\xCA\xEE\aT\x2\x2\xCB\xCC\a\x46\x2\x2\xCC\xCD\aK\x2\x2\xCD\xCE\aX\x2\x2"+
		"\xCE\xEE\aT\x2\x2\xCF\xD0\aO\x2\x2\xD0\xD1\aW\x2\x2\xD1\xD2\aN\x2\x2\xD2"+
		"\xEE\aT\x2\x2\xD3\xD4\aT\x2\x2\xD4\xD5\aO\x2\x2\xD5\xEE\aQ\x2\x2\xD6\xD7"+
		"\aU\x2\x2\xD7\xD8\aJ\x2\x2\xD8\xD9\aK\x2\x2\xD9\xDA\aH\x2\x2\xDA\xDB\a"+
		"V\x2\x2\xDB\xEE\aN\x2\x2\xDC\xDD\aU\x2\x2\xDD\xDE\aJ\x2\x2\xDE\xDF\aK"+
		"\x2\x2\xDF\xE0\aH\x2\x2\xE0\xE1\aV\x2\x2\xE1\xEE\aT\x2\x2\xE2\xE3\aU\x2"+
		"\x2\xE3\xE4\aW\x2\x2\xE4\xE5\a\x44\x2\x2\xE5\xEE\aT\x2\x2\xE6\xE7\aU\x2"+
		"\x2\xE7\xE8\aX\x2\x2\xE8\xEE\a\x45\x2\x2\xE9\xEA\aV\x2\x2\xEA\xEB\aK\x2"+
		"\x2\xEB\xEC\aZ\x2\x2\xEC\xEE\aT\x2\x2\xED\x82\x3\x2\x2\x2\xED\x87\x3\x2"+
		"\x2\x2\xED\x8D\x3\x2\x2\x2\xED\x93\x3\x2\x2\x2\xED\x98\x3\x2\x2\x2\xED"+
		"\x9D\x3\x2\x2\x2\xED\xA1\x3\x2\x2\x2\xED\xA8\x3\x2\x2\x2\xED\xAF\x3\x2"+
		"\x2\x2\xED\xB4\x3\x2\x2\x2\xED\xB8\x3\x2\x2\x2\xED\xBD\x3\x2\x2\x2\xED"+
		"\xC1\x3\x2\x2\x2\xED\xC6\x3\x2\x2\x2\xED\xCB\x3\x2\x2\x2\xED\xCF\x3\x2"+
		"\x2\x2\xED\xD3\x3\x2\x2\x2\xED\xD6\x3\x2\x2\x2\xED\xDC\x3\x2\x2\x2\xED"+
		"\xE2\x3\x2\x2\x2\xED\xE6\x3\x2\x2\x2\xED\xE9\x3\x2\x2\x2\xEE\f\x3\x2\x2"+
		"\x2\xEF\xF0\a\x43\x2\x2\xF0\xF1\a\x46\x2\x2\xF1\xF2\a\x46\x2\x2\xF2\x199"+
		"\a\"\x2\x2\xF3\xF4\a\x43\x2\x2\xF4\xF5\a\x46\x2\x2\xF5\xF6\a\x46\x2\x2"+
		"\xF6\xF7\aH\x2\x2\xF7\x199\a\"\x2\x2\xF8\xF9\a\x43\x2\x2\xF9\xFA\aP\x2"+
		"\x2\xFA\xFB\a\x46\x2\x2\xFB\x199\a\"\x2\x2\xFC\xFD\a\x45\x2\x2\xFD\xFE"+
		"\aQ\x2\x2\xFE\xFF\aO\x2\x2\xFF\x100\aR\x2\x2\x100\x199\a\"\x2\x2\x101"+
		"\x102\a\x45\x2\x2\x102\x103\aQ\x2\x2\x103\x104\aO\x2\x2\x104\x105\aR\x2"+
		"\x2\x105\x106\aH\x2\x2\x106\x199\a\"\x2\x2\x107\x108\a\x46\x2\x2\x108"+
		"\x109\aK\x2\x2\x109\x10A\aX\x2\x2\x10A\x199\a\"\x2\x2\x10B\x10C\a\x46"+
		"\x2\x2\x10C\x10D\aK\x2\x2\x10D\x10E\aX\x2\x2\x10E\x10F\aH\x2\x2\x10F\x199"+
		"\a\"\x2\x2\x110\x111\aL\x2\x2\x111\x199\a\"\x2\x2\x112\x113\aL\x2\x2\x113"+
		"\x114\aG\x2\x2\x114\x115\aS\x2\x2\x115\x199\a\"\x2\x2\x116\x117\aL\x2"+
		"\x2\x117\x118\aI\x2\x2\x118\x119\aV\x2\x2\x119\x199\a\"\x2\x2\x11A\x11B"+
		"\aL\x2\x2\x11B\x11C\aN\x2\x2\x11C\x11D\aV\x2\x2\x11D\x199\a\"\x2\x2\x11E"+
		"\x11F\aL\x2\x2\x11F\x120\aU\x2\x2\x120\x121\aW\x2\x2\x121\x122\a\x44\x2"+
		"\x2\x122\x199\a\"\x2\x2\x123\x124\aN\x2\x2\x124\x125\a\x46\x2\x2\x125"+
		"\x126\a\x43\x2\x2\x126\x199\a\"\x2\x2\x127\x128\aN\x2\x2\x128\x129\a\x46"+
		"\x2\x2\x129\x12A\a\x44\x2\x2\x12A\x199\a\"\x2\x2\x12B\x12C\aN\x2\x2\x12C"+
		"\x12D\a\x46\x2\x2\x12D\x12E\a\x45\x2\x2\x12E\x12F\aJ\x2\x2\x12F\x199\a"+
		"\"\x2\x2\x130\x131\aN\x2\x2\x131\x132\a\x46\x2\x2\x132\x133\aH\x2\x2\x133"+
		"\x199\a\"\x2\x2\x134\x135\aN\x2\x2\x135\x136\a\x46\x2\x2\x136\x137\aN"+
		"\x2\x2\x137\x199\a\"\x2\x2\x138\x139\aN\x2\x2\x139\x13A\a\x46\x2\x2\x13A"+
		"\x13B\aU\x2\x2\x13B\x199\a\"\x2\x2\x13C\x13D\aN\x2\x2\x13D\x13E\a\x46"+
		"\x2\x2\x13E\x13F\aV\x2\x2\x13F\x199\a\"\x2\x2\x140\x141\aN\x2\x2\x141"+
		"\x142\a\x46\x2\x2\x142\x143\aZ\x2\x2\x143\x199\a\"\x2\x2\x144\x145\aN"+
		"\x2\x2\x145\x146\aR\x2\x2\x146\x147\aU\x2\x2\x147\x199\a\"\x2\x2\x148"+
		"\x149\aO\x2\x2\x149\x14A\aW\x2\x2\x14A\x14B\aN\x2\x2\x14B\x199\a\"\x2"+
		"\x2\x14C\x14D\aO\x2\x2\x14D\x14E\aW\x2\x2\x14E\x14F\aN\x2\x2\x14F\x150"+
		"\aH\x2\x2\x150\x199\a\"\x2\x2\x151\x152\aQ\x2\x2\x152\x153\aT\x2\x2\x153"+
		"\x199\a\"\x2\x2\x154\x155\aT\x2\x2\x155\x156\a\x46\x2\x2\x156\x199\a\""+
		"\x2\x2\x157\x158\aU\x2\x2\x158\x159\aU\x2\x2\x159\x15A\aM\x2\x2\x15A\x199"+
		"\a\"\x2\x2\x15B\x15C\aU\x2\x2\x15C\x15D\aV\x2\x2\x15D\x15E\a\x43\x2\x2"+
		"\x15E\x199\a\"\x2\x2\x15F\x160\aU\x2\x2\x160\x161\aV\x2\x2\x161\x162\a"+
		"\x44\x2\x2\x162\x199\a\"\x2\x2\x163\x164\aU\x2\x2\x164\x165\aV\x2\x2\x165"+
		"\x166\a\x45\x2\x2\x166\x167\aJ\x2\x2\x167\x199\a\"\x2\x2\x168\x169\aU"+
		"\x2\x2\x169\x16A\aV\x2\x2\x16A\x16B\aH\x2\x2\x16B\x199\a\"\x2\x2\x16C"+
		"\x16D\aU\x2\x2\x16D\x16E\aV\x2\x2\x16E\x16F\aK\x2\x2\x16F\x199\a\"\x2"+
		"\x2\x170\x171\aU\x2\x2\x171\x172\aV\x2\x2\x172\x173\aN\x2\x2\x173\x199"+
		"\a\"\x2\x2\x174\x175\aU\x2\x2\x175\x176\aV\x2\x2\x176\x177\aU\x2\x2\x177"+
		"\x199\a\"\x2\x2\x178\x179\aU\x2\x2\x179\x17A\aV\x2\x2\x17A\x17B\aU\x2"+
		"\x2\x17B\x17C\aY\x2\x2\x17C\x199\a\"\x2\x2\x17D\x17E\aU\x2\x2\x17E\x17F"+
		"\aV\x2\x2\x17F\x180\aV\x2\x2\x180\x199\a\"\x2\x2\x181\x182\aU\x2\x2\x182"+
		"\x183\aV\x2\x2\x183\x184\aZ\x2\x2\x184\x199\a\"\x2\x2\x185\x186\aU\x2"+
		"\x2\x186\x187\aW\x2\x2\x187\x188\a\x44\x2\x2\x188\x199\a\"\x2\x2\x189"+
		"\x18A\aU\x2\x2\x18A\x18B\aW\x2\x2\x18B\x18C\a\x44\x2\x2\x18C\x18D\aH\x2"+
		"\x2\x18D\x199\a\"\x2\x2\x18E\x18F\aV\x2\x2\x18F\x190\a\x46\x2\x2\x190"+
		"\x199\a\"\x2\x2\x191\x192\aV\x2\x2\x192\x193\aK\x2\x2\x193\x194\aZ\x2"+
		"\x2\x194\x199\a\"\x2\x2\x195\x196\aY\x2\x2\x196\x197\a\x46\x2\x2\x197"+
		"\x199\a\"\x2\x2\x198\xEF\x3\x2\x2\x2\x198\xF3\x3\x2\x2\x2\x198\xF8\x3"+
		"\x2\x2\x2\x198\xFC\x3\x2\x2\x2\x198\x101\x3\x2\x2\x2\x198\x107\x3\x2\x2"+
		"\x2\x198\x10B\x3\x2\x2\x2\x198\x110\x3\x2\x2\x2\x198\x112\x3\x2\x2\x2"+
		"\x198\x116\x3\x2\x2\x2\x198\x11A\x3\x2\x2\x2\x198\x11E\x3\x2\x2\x2\x198"+
		"\x123\x3\x2\x2\x2\x198\x127\x3\x2\x2\x2\x198\x12B\x3\x2\x2\x2\x198\x130"+
		"\x3\x2\x2\x2\x198\x134\x3\x2\x2\x2\x198\x138\x3\x2\x2\x2\x198\x13C\x3"+
		"\x2\x2\x2\x198\x140\x3\x2\x2\x2\x198\x144\x3\x2\x2\x2\x198\x148\x3\x2"+
		"\x2\x2\x198\x14C\x3\x2\x2\x2\x198\x151\x3\x2\x2\x2\x198\x154\x3\x2\x2"+
		"\x2\x198\x157\x3\x2\x2\x2\x198\x15B\x3\x2\x2\x2\x198\x15F\x3\x2\x2\x2"+
		"\x198\x163\x3\x2\x2\x2\x198\x168\x3\x2\x2\x2\x198\x16C\x3\x2\x2\x2\x198"+
		"\x170\x3\x2\x2\x2\x198\x174\x3\x2\x2\x2\x198\x178\x3\x2\x2\x2\x198\x17D"+
		"\x3\x2\x2\x2\x198\x181\x3\x2\x2\x2\x198\x185\x3\x2\x2\x2\x198\x189\x3"+
		"\x2\x2\x2\x198\x18E\x3\x2\x2\x2\x198\x191\x3\x2\x2\x2\x198\x195\x3\x2"+
		"\x2\x2\x199\xE\x3\x2\x2\x2\x19A\x19B\a\x43\x2\x2\x19B\x1B9\a\"\x2\x2\x19C"+
		"\x19D\aZ\x2\x2\x19D\x1B9\a\"\x2\x2\x19E\x19F\aN\x2\x2\x19F\x1B9\a\"\x2"+
		"\x2\x1A0\x1A1\a\x44\x2\x2\x1A1\x1B9\a\"\x2\x2\x1A2\x1A3\aU\x2\x2\x1A3"+
		"\x1B9\a\"\x2\x2\x1A4\x1A5\aV\x2\x2\x1A5\x1B9\a\"\x2\x2\x1A6\x1A7\aH\x2"+
		"\x2\x1A7\x1B9\a\"\x2\x2\x1A8\x1A9\a\x45\x2\x2\x1A9\x1AA\aR\x2\x2\x1AA"+
		"\x1B9\a\"\x2\x2\x1AB\x1AC\aR\x2\x2\x1AC\x1AD\a\x45\x2\x2\x1AD\x1B9\a\""+
		"\x2\x2\x1AE\x1AF\aU\x2\x2\x1AF\x1B0\aY\x2\x2\x1B0\x1B9\a\"\x2\x2\x1B1"+
		"\x1B9\t\x4\x2\x2\x1B2\x1B3\a\x45\x2\x2\x1B3\x1B9\aR\x2\x2\x1B4\x1B5\a"+
		"R\x2\x2\x1B5\x1B9\a\x45\x2\x2\x1B6\x1B7\aU\x2\x2\x1B7\x1B9\aY\x2\x2\x1B8"+
		"\x19A\x3\x2\x2\x2\x1B8\x19C\x3\x2\x2\x2\x1B8\x19E\x3\x2\x2\x2\x1B8\x1A0"+
		"\x3\x2\x2\x2\x1B8\x1A2\x3\x2\x2\x2\x1B8\x1A4\x3\x2\x2\x2\x1B8\x1A6\x3"+
		"\x2\x2\x2\x1B8\x1A8\x3\x2\x2\x2\x1B8\x1AB\x3\x2\x2\x2\x1B8\x1AE\x3\x2"+
		"\x2\x2\x1B8\x1B1\x3\x2\x2\x2\x1B8\x1B2\x3\x2\x2\x2\x1B8\x1B4\x3\x2\x2"+
		"\x2\x1B8\x1B6\x3\x2\x2\x2\x1B9\x10\x3\x2\x2\x2\x1BA\x1BB\aY\x2\x2\x1BB"+
		"\x1BC\aQ\x2\x2\x1BC\x1BD\aT\x2\x2\x1BD\x1BE\a\x46\x2\x2\x1BE\x1C4\a\""+
		"\x2\x2\x1BF\x1C0\aY\x2\x2\x1C0\x1C1\aQ\x2\x2\x1C1\x1C2\aT\x2\x2\x1C2\x1C4"+
		"\a\x46\x2\x2\x1C3\x1BA\x3\x2\x2\x2\x1C3\x1BF\x3\x2\x2\x2\x1C4\x12\x3\x2"+
		"\x2\x2\x1C5\x1C6\aT\x2\x2\x1C6\x1C7\aG\x2\x2\x1C7\x1C8\aU\x2\x2\x1C8\x1C9"+
		"\a\x44\x2\x2\x1C9\x1CF\a\"\x2\x2\x1CA\x1CB\aT\x2\x2\x1CB\x1CC\aG\x2\x2"+
		"\x1CC\x1CD\aU\x2\x2\x1CD\x1CF\a\x44\x2\x2\x1CE\x1C5\x3\x2\x2\x2\x1CE\x1CA"+
		"\x3\x2\x2\x2\x1CF\x14\x3\x2\x2\x2\x1D0\x1D1\aU\x2\x2\x1D1\x1D2\aV\x2\x2"+
		"\x1D2\x1D3\a\x43\x2\x2\x1D3\x1D4\aT\x2\x2\x1D4\x1D5\aV\x2\x2\x1D5\x1DC"+
		"\a\"\x2\x2\x1D6\x1D7\aU\x2\x2\x1D7\x1D8\aV\x2\x2\x1D8\x1D9\a\x43\x2\x2"+
		"\x1D9\x1DA\aT\x2\x2\x1DA\x1DC\aV\x2\x2\x1DB\x1D0\x3\x2\x2\x2\x1DB\x1D6"+
		"\x3\x2\x2\x2\x1DC\x16\x3\x2\x2\x2\x1DD\x1DE\aT\x2\x2\x1DE\x1DF\aG\x2\x2"+
		"\x1DF\x1E0\aU\x2\x2\x1E0\x1E1\aY\x2\x2\x1E1\x1E7\a\"\x2\x2\x1E2\x1E3\a"+
		"T\x2\x2\x1E3\x1E4\aG\x2\x2\x1E4\x1E5\aU\x2\x2\x1E5\x1E7\aY\x2\x2\x1E6"+
		"\x1DD\x3\x2\x2\x2\x1E6\x1E2\x3\x2\x2\x2\x1E7\x18\x3\x2\x2\x2\x1E8\x1E9"+
		"\aG\x2\x2\x1E9\x1EA\aP\x2\x2\x1EA\x1EB\a\x46\x2\x2\x1EB\x1F0\a\"\x2\x2"+
		"\x1EC\x1ED\aG\x2\x2\x1ED\x1EE\aP\x2\x2\x1EE\x1F0\a\x46\x2\x2\x1EF\x1E8"+
		"\x3\x2\x2\x2\x1EF\x1EC\x3\x2\x2\x2\x1F0\x1A\x3\x2\x2\x2\x1F1\x1F2\a\x44"+
		"\x2\x2\x1F2\x1F3\a[\x2\x2\x1F3\x1F4\aV\x2\x2\x1F4\x1F5\aG\x2\x2\x1F5\x1FB"+
		"\a\"\x2\x2\x1F6\x1F7\a\x44\x2\x2\x1F7\x1F8\a[\x2\x2\x1F8\x1F9\aV\x2\x2"+
		"\x1F9\x1FB\aG\x2\x2\x1FA\x1F1\x3\x2\x2\x2\x1FA\x1F6\x3\x2\x2\x2\x1FB\x1C"+
		"\x3\x2\x2\x2\x1FC\x1FD\a\x44\x2\x2\x1FD\x1FE\a\x43\x2\x2\x1FE\x1FF\aU"+
		"\x2\x2\x1FF\x200\aG\x2\x2\x200\x206\a\"\x2\x2\x201\x202\a\x44\x2\x2\x202"+
		"\x203\a\x43\x2\x2\x203\x204\aU\x2\x2\x204\x206\aG\x2\x2\x205\x1FC\x3\x2"+
		"\x2\x2\x205\x201\x3\x2\x2\x2\x206\x1E\x3\x2\x2\x2\x207\x208\a\x42\x2\x2"+
		"\x208 \x3\x2\x2\x2\x209\x20A\a%\x2\x2\x20A\"\x3\x2\x2\x2\x20B\x20C\a-"+
		"\x2\x2\x20C$\x3\x2\x2\x2\x20D\x20E\a.\x2\x2\x20E\x211\a\"\x2\x2\x20F\x211"+
		"\a.\x2\x2\x210\x20D\x3\x2\x2\x2\x210\x20F\x3\x2\x2\x2\x211&\x3\x2\x2\x2"+
		"\x212\x213\a$\x2\x2\x213(\x3\x2\x2\x2\x214\x216\x4\x32;\x2\x215\x214\x3"+
		"\x2\x2\x2\x216\x217\x3\x2\x2\x2\x217\x215\x3\x2\x2\x2\x217\x218\x3\x2"+
		"\x2\x2\x218\x226\x3\x2\x2\x2\x219\x21B\t\x3\x2\x2\x21A\x219\x3\x2\x2\x2"+
		"\x21B\x21C\x3\x2\x2\x2\x21C\x21A\x3\x2\x2\x2\x21C\x21D\x3\x2\x2\x2\x21D"+
		"\x21E\x3\x2\x2\x2\x21E\x226\aJ\x2\x2\x21F\x221\t\x3\x2\x2\x220\x21F\x3"+
		"\x2\x2\x2\x221\x222\x3\x2\x2\x2\x222\x220\x3\x2\x2\x2\x222\x223\x3\x2"+
		"\x2\x2\x223\x224\x3\x2\x2\x2\x224\x226\aj\x2\x2\x225\x215\x3\x2\x2\x2"+
		"\x225\x21A\x3\x2\x2\x2\x225\x220\x3\x2\x2\x2\x226*\x3\x2\x2\x2\x227\x229"+
		"\t\x3\x2\x2\x228\x227\x3\x2\x2\x2\x229\x22A\x3\x2\x2\x2\x22A\x228\x3\x2"+
		"\x2\x2\x22A\x22B\x3\x2\x2\x2\x22B\x233\x3\x2\x2\x2\x22C\x22E\t\x3\x2\x2"+
		"\x22D\x22C\x3\x2\x2\x2\x22E\x22F\x3\x2\x2\x2\x22F\x22D\x3\x2\x2\x2\x22F"+
		"\x230\x3\x2\x2\x2\x230\x231\x3\x2\x2\x2\x231\x233\a\"\x2\x2\x232\x228"+
		"\x3\x2\x2\x2\x232\x22D\x3\x2\x2\x2\x233,\x3\x2\x2\x2\x234\x235\a\f\x2"+
		"\x2\x235.\x3\x2\x2\x2\x236\x238\t\x5\x2\x2\x237\x236\x3\x2\x2\x2\x238"+
		"\x239\x3\x2\x2\x2\x239\x237\x3\x2\x2\x2\x239\x23A\x3\x2\x2\x2\x23A\x23B"+
		"\x3\x2\x2\x2\x23B\x23C\b\x18\x2\x2\x23C\x30\x3\x2\x2\x2\x1A\x2\x37\x41"+
		"N\x80\xED\x198\x1B8\x1C3\x1CE\x1DB\x1E6\x1EF\x1FA\x205\x210\x217\x21C"+
		"\x222\x225\x22A\x22F\x232\x239\x3\x3\x18\x2";
	public static readonly ATN _ATN =
		new ATNDeserializer().Deserialize(_serializedATN.ToCharArray());
}
} // namespace Calculadora
