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
		RSUB=1, COD_OP_F1=2, COD_OP_F2=3, COD_OP_F3=4, REG=5, WORD=6, RESB=7, 
		START=8, RESW=9, END=10, BYTE=11, BASE=12, ARROBA=13, HASHTAG=14, FORMATO4=15, 
		COMA=16, COMILLA=17, NUM=18, MEM_DIR=19, CONSTHEX=20, CONSTCAD=21, FINL=22, 
		WS=23;
	public static string[] modeNames = {
		"DEFAULT_MODE"
	};

	public static readonly string[] ruleNames = {
		"RSUB", "COD_OP_F1", "COD_OP_F2", "COD_OP_F3", "REG", "WORD", "RESB", 
		"START", "RESW", "END", "BYTE", "BASE", "ARROBA", "HASHTAG", "FORMATO4", 
		"COMA", "COMILLA", "NUM", "MEM_DIR", "CONSTHEX", "CONSTCAD", "FINL", "WS"
	};


	public Gramatica_CalculadoraLexer(ICharStream input)
		: base(input)
	{
		_interp = new LexerATNSimulator(this,_ATN);
	}

	private static readonly string[] _LiteralNames = {
		null, null, null, null, null, null, null, null, null, null, null, null, 
		null, "'@'", "'#'", "'+'", null, "'\"'", null, null, null, null, "'\n'"
	};
	private static readonly string[] _SymbolicNames = {
		null, "RSUB", "COD_OP_F1", "COD_OP_F2", "COD_OP_F3", "REG", "WORD", "RESB", 
		"START", "RESW", "END", "BYTE", "BASE", "ARROBA", "HASHTAG", "FORMATO4", 
		"COMA", "COMILLA", "NUM", "MEM_DIR", "CONSTHEX", "CONSTCAD", "FINL", "WS"
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
		"\x3\x2\x3\x2\x3\x2\x3\x2\x3\x2\x5\x2;\n\x2\x3\x3\x3\x3\x3\x3\x3\x3\x3"+
		"\x3\x3\x3\x3\x3\x3\x3\x3\x3\x3\x3\x3\x3\x3\x3\x3\x3\x3\x3\x3\x3\x3\x3"+
		"\x3\x3\x3\x3\x3\x3\x3\x3\x3\x3\x3\x3\x3\x3\x3\x3\x3\x3\x3\x3\x3\x3\x3"+
		"\x3\x3\x3\x3\x3\x3\x3\x3\x3\x3\x3\x3\x3\x3\x3\x3\x3\x3\x3\x3\x3\x3\x3"+
		"\x3\x3\x3\x3\x3\x3\x3\x3\x3\x3\x3\x3\x3\x3\x3\x3\x3\x3\x5\x3m\n\x3\x3"+
		"\x4\x3\x4\x3\x4\x3\x4\x3\x4\x3\x4\x3\x4\x3\x4\x3\x4\x3\x4\x3\x4\x3\x4"+
		"\x3\x4\x3\x4\x3\x4\x3\x4\x3\x4\x3\x4\x3\x4\x3\x4\x3\x4\x3\x4\x3\x4\x3"+
		"\x4\x3\x4\x3\x4\x3\x4\x3\x4\x3\x4\x3\x4\x3\x4\x3\x4\x3\x4\x3\x4\x3\x4"+
		"\x3\x4\x3\x4\x3\x4\x3\x4\x3\x4\x3\x4\x3\x4\x3\x4\x3\x4\x3\x4\x3\x4\x3"+
		"\x4\x3\x4\x3\x4\x3\x4\x3\x4\x3\x4\x3\x4\x3\x4\x3\x4\x3\x4\x3\x4\x3\x4"+
		"\x3\x4\x3\x4\x3\x4\x3\x4\x3\x4\x3\x4\x3\x4\x3\x4\x3\x4\x3\x4\x3\x4\x3"+
		"\x4\x3\x4\x3\x4\x3\x4\x3\x4\x3\x4\x3\x4\x3\x4\x3\x4\x3\x4\x3\x4\x3\x4"+
		"\x3\x4\x3\x4\x3\x4\x3\x4\x3\x4\x3\x4\x3\x4\x3\x4\x3\x4\x3\x4\x3\x4\x3"+
		"\x4\x3\x4\x3\x4\x3\x4\x3\x4\x3\x4\x3\x4\x3\x4\x3\x4\x3\x4\x3\x4\x3\x4"+
		"\x3\x4\x3\x4\x3\x4\x5\x4\xDA\n\x4\x3\x5\x3\x5\x3\x5\x3\x5\x3\x5\x3\x5"+
		"\x3\x5\x3\x5\x3\x5\x3\x5\x3\x5\x3\x5\x3\x5\x3\x5\x3\x5\x3\x5\x3\x5\x3"+
		"\x5\x3\x5\x3\x5\x3\x5\x3\x5\x3\x5\x3\x5\x3\x5\x3\x5\x3\x5\x3\x5\x3\x5"+
		"\x3\x5\x3\x5\x3\x5\x3\x5\x3\x5\x3\x5\x3\x5\x3\x5\x3\x5\x3\x5\x3\x5\x3"+
		"\x5\x3\x5\x3\x5\x3\x5\x3\x5\x3\x5\x3\x5\x3\x5\x3\x5\x3\x5\x3\x5\x3\x5"+
		"\x3\x5\x3\x5\x3\x5\x3\x5\x3\x5\x3\x5\x3\x5\x3\x5\x3\x5\x3\x5\x3\x5\x3"+
		"\x5\x3\x5\x3\x5\x3\x5\x3\x5\x3\x5\x3\x5\x3\x5\x3\x5\x3\x5\x3\x5\x3\x5"+
		"\x3\x5\x3\x5\x3\x5\x3\x5\x3\x5\x3\x5\x3\x5\x3\x5\x3\x5\x3\x5\x3\x5\x3"+
		"\x5\x3\x5\x3\x5\x3\x5\x3\x5\x3\x5\x3\x5\x3\x5\x3\x5\x3\x5\x3\x5\x3\x5"+
		"\x3\x5\x3\x5\x3\x5\x3\x5\x3\x5\x3\x5\x3\x5\x3\x5\x3\x5\x3\x5\x3\x5\x3"+
		"\x5\x3\x5\x3\x5\x3\x5\x3\x5\x3\x5\x3\x5\x3\x5\x3\x5\x3\x5\x3\x5\x3\x5"+
		"\x3\x5\x3\x5\x3\x5\x3\x5\x3\x5\x3\x5\x3\x5\x3\x5\x3\x5\x3\x5\x3\x5\x3"+
		"\x5\x3\x5\x3\x5\x3\x5\x3\x5\x3\x5\x3\x5\x3\x5\x3\x5\x3\x5\x3\x5\x3\x5"+
		"\x3\x5\x3\x5\x3\x5\x3\x5\x3\x5\x3\x5\x3\x5\x3\x5\x3\x5\x3\x5\x3\x5\x3"+
		"\x5\x3\x5\x3\x5\x3\x5\x3\x5\x3\x5\x3\x5\x3\x5\x3\x5\x3\x5\x3\x5\x3\x5"+
		"\x3\x5\x3\x5\x5\x5\x185\n\x5\x3\x6\x3\x6\x3\x6\x3\x6\x3\x6\x3\x6\x3\x6"+
		"\x3\x6\x3\x6\x3\x6\x3\x6\x3\x6\x3\x6\x3\x6\x3\x6\x3\x6\x3\x6\x3\x6\x3"+
		"\x6\x3\x6\x3\x6\x3\x6\x3\x6\x3\x6\x3\x6\x3\x6\x3\x6\x3\x6\x3\x6\x3\x6"+
		"\x5\x6\x1A5\n\x6\x3\a\x3\a\x3\a\x3\a\x3\a\x3\a\x3\a\x3\a\x3\a\x5\a\x1B0"+
		"\n\a\x3\b\x3\b\x3\b\x3\b\x3\b\x3\b\x3\b\x3\b\x3\b\x5\b\x1BB\n\b\x3\t\x3"+
		"\t\x3\t\x3\t\x3\t\x3\t\x3\t\x3\t\x3\t\x3\t\x3\t\x5\t\x1C8\n\t\x3\n\x3"+
		"\n\x3\n\x3\n\x3\n\x3\n\x3\n\x3\n\x3\n\x5\n\x1D3\n\n\x3\v\x3\v\x3\v\x3"+
		"\v\x3\v\x3\v\x3\v\x5\v\x1DC\n\v\x3\f\x3\f\x3\f\x3\f\x3\f\x3\f\x3\f\x3"+
		"\f\x3\f\x5\f\x1E7\n\f\x3\r\x3\r\x3\r\x3\r\x3\r\x3\r\x3\r\x3\r\x3\r\x5"+
		"\r\x1F2\n\r\x3\xE\x3\xE\x3\xF\x3\xF\x3\x10\x3\x10\x3\x11\x3\x11\x3\x11"+
		"\x5\x11\x1FD\n\x11\x3\x12\x3\x12\x3\x13\x6\x13\x202\n\x13\r\x13\xE\x13"+
		"\x203\x3\x13\x6\x13\x207\n\x13\r\x13\xE\x13\x208\x3\x13\x3\x13\x6\x13"+
		"\x20D\n\x13\r\x13\xE\x13\x20E\x3\x13\x5\x13\x212\n\x13\x3\x14\x6\x14\x215"+
		"\n\x14\r\x14\xE\x14\x216\x3\x14\x6\x14\x21A\n\x14\r\x14\xE\x14\x21B\x3"+
		"\x14\x5\x14\x21F\n\x14\x3\x15\x3\x15\x3\x15\x3\x15\x6\x15\x225\n\x15\r"+
		"\x15\xE\x15\x226\x3\x15\x3\x15\x3\x16\x3\x16\x3\x16\x3\x16\x6\x16\x22F"+
		"\n\x16\r\x16\xE\x16\x230\x3\x16\x3\x16\x3\x17\x3\x17\x3\x18\x6\x18\x238"+
		"\n\x18\r\x18\xE\x18\x239\x3\x18\x3\x18\x2\x2\x2\x19\x3\x2\x3\x5\x2\x4"+
		"\a\x2\x5\t\x2\x6\v\x2\a\r\x2\b\xF\x2\t\x11\x2\n\x13\x2\v\x15\x2\f\x17"+
		"\x2\r\x19\x2\xE\x1B\x2\xF\x1D\x2\x10\x1F\x2\x11!\x2\x12#\x2\x13%\x2\x14"+
		"\'\x2\x15)\x2\x16+\x2\x17-\x2\x18/\x2\x19\x3\x2\a\a\x2\x43\x44HHNNUVZ"+
		"Z\x5\x2\x32;\x43\\\x63|\x4\x2\x32;\x43H\x4\x2\x43\\\x63|\x5\x2\v\f\xF"+
		"\xF\"\"\x2A5\x2\x3\x3\x2\x2\x2\x2\x5\x3\x2\x2\x2\x2\a\x3\x2\x2\x2\x2\t"+
		"\x3\x2\x2\x2\x2\v\x3\x2\x2\x2\x2\r\x3\x2\x2\x2\x2\xF\x3\x2\x2\x2\x2\x11"+
		"\x3\x2\x2\x2\x2\x13\x3\x2\x2\x2\x2\x15\x3\x2\x2\x2\x2\x17\x3\x2\x2\x2"+
		"\x2\x19\x3\x2\x2\x2\x2\x1B\x3\x2\x2\x2\x2\x1D\x3\x2\x2\x2\x2\x1F\x3\x2"+
		"\x2\x2\x2!\x3\x2\x2\x2\x2#\x3\x2\x2\x2\x2%\x3\x2\x2\x2\x2\'\x3\x2\x2\x2"+
		"\x2)\x3\x2\x2\x2\x2+\x3\x2\x2\x2\x2-\x3\x2\x2\x2\x2/\x3\x2\x2\x2\x3:\x3"+
		"\x2\x2\x2\x5l\x3\x2\x2\x2\a\xD9\x3\x2\x2\x2\t\x184\x3\x2\x2\x2\v\x1A4"+
		"\x3\x2\x2\x2\r\x1AF\x3\x2\x2\x2\xF\x1BA\x3\x2\x2\x2\x11\x1C7\x3\x2\x2"+
		"\x2\x13\x1D2\x3\x2\x2\x2\x15\x1DB\x3\x2\x2\x2\x17\x1E6\x3\x2\x2\x2\x19"+
		"\x1F1\x3\x2\x2\x2\x1B\x1F3\x3\x2\x2\x2\x1D\x1F5\x3\x2\x2\x2\x1F\x1F7\x3"+
		"\x2\x2\x2!\x1FC\x3\x2\x2\x2#\x1FE\x3\x2\x2\x2%\x211\x3\x2\x2\x2\'\x21E"+
		"\x3\x2\x2\x2)\x220\x3\x2\x2\x2+\x22A\x3\x2\x2\x2-\x234\x3\x2\x2\x2/\x237"+
		"\x3\x2\x2\x2\x31\x32\aT\x2\x2\x32\x33\aU\x2\x2\x33\x34\aW\x2\x2\x34;\a"+
		"\x44\x2\x2\x35\x36\aT\x2\x2\x36\x37\aU\x2\x2\x37\x38\aW\x2\x2\x38\x39"+
		"\a\x44\x2\x2\x39;\a\"\x2\x2:\x31\x3\x2\x2\x2:\x35\x3\x2\x2\x2;\x4\x3\x2"+
		"\x2\x2<=\aH\x2\x2=>\aK\x2\x2>?\aZ\x2\x2?m\a\"\x2\x2@\x41\aH\x2\x2\x41"+
		"\x42\aN\x2\x2\x42\x43\aQ\x2\x2\x43\x44\a\x43\x2\x2\x44\x45\aV\x2\x2\x45"+
		"m\a\"\x2\x2\x46G\aJ\x2\x2GH\aK\x2\x2HI\aQ\x2\x2Im\a\"\x2\x2JK\aP\x2\x2"+
		"KL\aQ\x2\x2LM\aT\x2\x2MN\aO\x2\x2Nm\a\"\x2\x2OP\aU\x2\x2PQ\aK\x2\x2QR"+
		"\aQ\x2\x2Rm\a\"\x2\x2ST\aV\x2\x2TU\aK\x2\x2UV\aQ\x2\x2Vm\a\"\x2\x2WX\a"+
		"H\x2\x2XY\aK\x2\x2Ym\aZ\x2\x2Z[\aH\x2\x2[\\\aN\x2\x2\\]\aQ\x2\x2]^\a\x43"+
		"\x2\x2^m\aV\x2\x2_`\aJ\x2\x2`\x61\aK\x2\x2\x61m\aQ\x2\x2\x62\x63\aP\x2"+
		"\x2\x63\x64\aQ\x2\x2\x64\x65\aT\x2\x2\x65m\aO\x2\x2\x66g\aU\x2\x2gh\a"+
		"K\x2\x2hm\aQ\x2\x2ij\aV\x2\x2jk\aK\x2\x2km\aQ\x2\x2l<\x3\x2\x2\x2l@\x3"+
		"\x2\x2\x2l\x46\x3\x2\x2\x2lJ\x3\x2\x2\x2lO\x3\x2\x2\x2lS\x3\x2\x2\x2l"+
		"W\x3\x2\x2\x2lZ\x3\x2\x2\x2l_\x3\x2\x2\x2l\x62\x3\x2\x2\x2l\x66\x3\x2"+
		"\x2\x2li\x3\x2\x2\x2m\x6\x3\x2\x2\x2no\a\x43\x2\x2op\a\x46\x2\x2pq\a\x46"+
		"\x2\x2qr\aT\x2\x2r\xDA\a\"\x2\x2st\a\x45\x2\x2tu\aN\x2\x2uv\aG\x2\x2v"+
		"w\a\x43\x2\x2wx\aT\x2\x2x\xDA\a\"\x2\x2yz\a\x45\x2\x2z{\aQ\x2\x2{|\aO"+
		"\x2\x2|}\aR\x2\x2}~\aT\x2\x2~\xDA\a\"\x2\x2\x7F\x80\a\x46\x2\x2\x80\x81"+
		"\aK\x2\x2\x81\x82\aX\x2\x2\x82\x83\aT\x2\x2\x83\xDA\a\"\x2\x2\x84\x85"+
		"\aO\x2\x2\x85\x86\aW\x2\x2\x86\x87\aN\x2\x2\x87\x88\aT\x2\x2\x88\xDA\a"+
		"\"\x2\x2\x89\x8A\aT\x2\x2\x8A\x8B\aO\x2\x2\x8B\x8C\aQ\x2\x2\x8C\xDA\a"+
		"\"\x2\x2\x8D\x8E\aU\x2\x2\x8E\x8F\aJ\x2\x2\x8F\x90\aK\x2\x2\x90\x91\a"+
		"H\x2\x2\x91\x92\aV\x2\x2\x92\x93\aN\x2\x2\x93\xDA\a\"\x2\x2\x94\x95\a"+
		"U\x2\x2\x95\x96\aJ\x2\x2\x96\x97\aK\x2\x2\x97\x98\aH\x2\x2\x98\x99\aV"+
		"\x2\x2\x99\x9A\aT\x2\x2\x9A\xDA\a\"\x2\x2\x9B\x9C\aU\x2\x2\x9C\x9D\aW"+
		"\x2\x2\x9D\x9E\a\x44\x2\x2\x9E\x9F\aT\x2\x2\x9F\xDA\a\"\x2\x2\xA0\xA1"+
		"\aU\x2\x2\xA1\xA2\aX\x2\x2\xA2\xA3\a\x45\x2\x2\xA3\xDA\a\"\x2\x2\xA4\xA5"+
		"\aV\x2\x2\xA5\xA6\aK\x2\x2\xA6\xA7\aZ\x2\x2\xA7\xA8\aT\x2\x2\xA8\xDA\a"+
		"\"\x2\x2\xA9\xAA\a\x43\x2\x2\xAA\xAB\a\x46\x2\x2\xAB\xAC\a\x46\x2\x2\xAC"+
		"\xDA\aT\x2\x2\xAD\xAE\a\x45\x2\x2\xAE\xAF\aN\x2\x2\xAF\xB0\aG\x2\x2\xB0"+
		"\xB1\a\x43\x2\x2\xB1\xDA\aT\x2\x2\xB2\xB3\a\x45\x2\x2\xB3\xB4\aQ\x2\x2"+
		"\xB4\xB5\aO\x2\x2\xB5\xB6\aR\x2\x2\xB6\xDA\aT\x2\x2\xB7\xB8\a\x46\x2\x2"+
		"\xB8\xB9\aK\x2\x2\xB9\xBA\aX\x2\x2\xBA\xDA\aT\x2\x2\xBB\xBC\aO\x2\x2\xBC"+
		"\xBD\aW\x2\x2\xBD\xBE\aN\x2\x2\xBE\xDA\aT\x2\x2\xBF\xC0\aT\x2\x2\xC0\xC1"+
		"\aO\x2\x2\xC1\xDA\aQ\x2\x2\xC2\xC3\aU\x2\x2\xC3\xC4\aJ\x2\x2\xC4\xC5\a"+
		"K\x2\x2\xC5\xC6\aH\x2\x2\xC6\xC7\aV\x2\x2\xC7\xDA\aN\x2\x2\xC8\xC9\aU"+
		"\x2\x2\xC9\xCA\aJ\x2\x2\xCA\xCB\aK\x2\x2\xCB\xCC\aH\x2\x2\xCC\xCD\aV\x2"+
		"\x2\xCD\xDA\aT\x2\x2\xCE\xCF\aU\x2\x2\xCF\xD0\aW\x2\x2\xD0\xD1\a\x44\x2"+
		"\x2\xD1\xDA\aT\x2\x2\xD2\xD3\aU\x2\x2\xD3\xD4\aX\x2\x2\xD4\xDA\a\x45\x2"+
		"\x2\xD5\xD6\aV\x2\x2\xD6\xD7\aK\x2\x2\xD7\xD8\aZ\x2\x2\xD8\xDA\aT\x2\x2"+
		"\xD9n\x3\x2\x2\x2\xD9s\x3\x2\x2\x2\xD9y\x3\x2\x2\x2\xD9\x7F\x3\x2\x2\x2"+
		"\xD9\x84\x3\x2\x2\x2\xD9\x89\x3\x2\x2\x2\xD9\x8D\x3\x2\x2\x2\xD9\x94\x3"+
		"\x2\x2\x2\xD9\x9B\x3\x2\x2\x2\xD9\xA0\x3\x2\x2\x2\xD9\xA4\x3\x2\x2\x2"+
		"\xD9\xA9\x3\x2\x2\x2\xD9\xAD\x3\x2\x2\x2\xD9\xB2\x3\x2\x2\x2\xD9\xB7\x3"+
		"\x2\x2\x2\xD9\xBB\x3\x2\x2\x2\xD9\xBF\x3\x2\x2\x2\xD9\xC2\x3\x2\x2\x2"+
		"\xD9\xC8\x3\x2\x2\x2\xD9\xCE\x3\x2\x2\x2\xD9\xD2\x3\x2\x2\x2\xD9\xD5\x3"+
		"\x2\x2\x2\xDA\b\x3\x2\x2\x2\xDB\xDC\a\x43\x2\x2\xDC\xDD\a\x46\x2\x2\xDD"+
		"\xDE\a\x46\x2\x2\xDE\x185\a\"\x2\x2\xDF\xE0\a\x43\x2\x2\xE0\xE1\a\x46"+
		"\x2\x2\xE1\xE2\a\x46\x2\x2\xE2\xE3\aH\x2\x2\xE3\x185\a\"\x2\x2\xE4\xE5"+
		"\a\x43\x2\x2\xE5\xE6\aP\x2\x2\xE6\xE7\a\x46\x2\x2\xE7\x185\a\"\x2\x2\xE8"+
		"\xE9\a\x45\x2\x2\xE9\xEA\aQ\x2\x2\xEA\xEB\aO\x2\x2\xEB\xEC\aR\x2\x2\xEC"+
		"\x185\a\"\x2\x2\xED\xEE\a\x45\x2\x2\xEE\xEF\aQ\x2\x2\xEF\xF0\aO\x2\x2"+
		"\xF0\xF1\aR\x2\x2\xF1\xF2\aH\x2\x2\xF2\x185\a\"\x2\x2\xF3\xF4\a\x46\x2"+
		"\x2\xF4\xF5\aK\x2\x2\xF5\xF6\aX\x2\x2\xF6\x185\a\"\x2\x2\xF7\xF8\a\x46"+
		"\x2\x2\xF8\xF9\aK\x2\x2\xF9\xFA\aX\x2\x2\xFA\xFB\aH\x2\x2\xFB\x185\a\""+
		"\x2\x2\xFC\xFD\aL\x2\x2\xFD\x185\a\"\x2\x2\xFE\xFF\aL\x2\x2\xFF\x100\a"+
		"G\x2\x2\x100\x101\aS\x2\x2\x101\x185\a\"\x2\x2\x102\x103\aL\x2\x2\x103"+
		"\x104\aI\x2\x2\x104\x105\aV\x2\x2\x105\x185\a\"\x2\x2\x106\x107\aL\x2"+
		"\x2\x107\x108\aN\x2\x2\x108\x109\aV\x2\x2\x109\x185\a\"\x2\x2\x10A\x10B"+
		"\aL\x2\x2\x10B\x10C\aU\x2\x2\x10C\x10D\aW\x2\x2\x10D\x10E\a\x44\x2\x2"+
		"\x10E\x185\a\"\x2\x2\x10F\x110\aN\x2\x2\x110\x111\a\x46\x2\x2\x111\x112"+
		"\a\x43\x2\x2\x112\x185\a\"\x2\x2\x113\x114\aN\x2\x2\x114\x115\a\x46\x2"+
		"\x2\x115\x116\a\x44\x2\x2\x116\x185\a\"\x2\x2\x117\x118\aN\x2\x2\x118"+
		"\x119\a\x46\x2\x2\x119\x11A\a\x45\x2\x2\x11A\x11B\aJ\x2\x2\x11B\x185\a"+
		"\"\x2\x2\x11C\x11D\aN\x2\x2\x11D\x11E\a\x46\x2\x2\x11E\x11F\aH\x2\x2\x11F"+
		"\x185\a\"\x2\x2\x120\x121\aN\x2\x2\x121\x122\a\x46\x2\x2\x122\x123\aN"+
		"\x2\x2\x123\x185\a\"\x2\x2\x124\x125\aN\x2\x2\x125\x126\a\x46\x2\x2\x126"+
		"\x127\aU\x2\x2\x127\x185\a\"\x2\x2\x128\x129\aN\x2\x2\x129\x12A\a\x46"+
		"\x2\x2\x12A\x12B\aV\x2\x2\x12B\x185\a\"\x2\x2\x12C\x12D\aN\x2\x2\x12D"+
		"\x12E\a\x46\x2\x2\x12E\x12F\aZ\x2\x2\x12F\x185\a\"\x2\x2\x130\x131\aN"+
		"\x2\x2\x131\x132\aR\x2\x2\x132\x133\aU\x2\x2\x133\x185\a\"\x2\x2\x134"+
		"\x135\aO\x2\x2\x135\x136\aW\x2\x2\x136\x137\aN\x2\x2\x137\x185\a\"\x2"+
		"\x2\x138\x139\aO\x2\x2\x139\x13A\aW\x2\x2\x13A\x13B\aN\x2\x2\x13B\x13C"+
		"\aH\x2\x2\x13C\x185\a\"\x2\x2\x13D\x13E\aQ\x2\x2\x13E\x13F\aT\x2\x2\x13F"+
		"\x185\a\"\x2\x2\x140\x141\aT\x2\x2\x141\x142\a\x46\x2\x2\x142\x185\a\""+
		"\x2\x2\x143\x144\aU\x2\x2\x144\x145\aU\x2\x2\x145\x146\aM\x2\x2\x146\x185"+
		"\a\"\x2\x2\x147\x148\aU\x2\x2\x148\x149\aV\x2\x2\x149\x14A\a\x43\x2\x2"+
		"\x14A\x185\a\"\x2\x2\x14B\x14C\aU\x2\x2\x14C\x14D\aV\x2\x2\x14D\x14E\a"+
		"\x44\x2\x2\x14E\x185\a\"\x2\x2\x14F\x150\aU\x2\x2\x150\x151\aV\x2\x2\x151"+
		"\x152\a\x45\x2\x2\x152\x153\aJ\x2\x2\x153\x185\a\"\x2\x2\x154\x155\aU"+
		"\x2\x2\x155\x156\aV\x2\x2\x156\x157\aH\x2\x2\x157\x185\a\"\x2\x2\x158"+
		"\x159\aU\x2\x2\x159\x15A\aV\x2\x2\x15A\x15B\aK\x2\x2\x15B\x185\a\"\x2"+
		"\x2\x15C\x15D\aU\x2\x2\x15D\x15E\aV\x2\x2\x15E\x15F\aN\x2\x2\x15F\x185"+
		"\a\"\x2\x2\x160\x161\aU\x2\x2\x161\x162\aV\x2\x2\x162\x163\aU\x2\x2\x163"+
		"\x185\a\"\x2\x2\x164\x165\aU\x2\x2\x165\x166\aV\x2\x2\x166\x167\aU\x2"+
		"\x2\x167\x168\aY\x2\x2\x168\x185\a\"\x2\x2\x169\x16A\aU\x2\x2\x16A\x16B"+
		"\aV\x2\x2\x16B\x16C\aV\x2\x2\x16C\x185\a\"\x2\x2\x16D\x16E\aU\x2\x2\x16E"+
		"\x16F\aV\x2\x2\x16F\x170\aZ\x2\x2\x170\x185\a\"\x2\x2\x171\x172\aU\x2"+
		"\x2\x172\x173\aW\x2\x2\x173\x174\a\x44\x2\x2\x174\x185\a\"\x2\x2\x175"+
		"\x176\aU\x2\x2\x176\x177\aW\x2\x2\x177\x178\a\x44\x2\x2\x178\x179\aH\x2"+
		"\x2\x179\x185\a\"\x2\x2\x17A\x17B\aV\x2\x2\x17B\x17C\a\x46\x2\x2\x17C"+
		"\x185\a\"\x2\x2\x17D\x17E\aV\x2\x2\x17E\x17F\aK\x2\x2\x17F\x180\aZ\x2"+
		"\x2\x180\x185\a\"\x2\x2\x181\x182\aY\x2\x2\x182\x183\a\x46\x2\x2\x183"+
		"\x185\a\"\x2\x2\x184\xDB\x3\x2\x2\x2\x184\xDF\x3\x2\x2\x2\x184\xE4\x3"+
		"\x2\x2\x2\x184\xE8\x3\x2\x2\x2\x184\xED\x3\x2\x2\x2\x184\xF3\x3\x2\x2"+
		"\x2\x184\xF7\x3\x2\x2\x2\x184\xFC\x3\x2\x2\x2\x184\xFE\x3\x2\x2\x2\x184"+
		"\x102\x3\x2\x2\x2\x184\x106\x3\x2\x2\x2\x184\x10A\x3\x2\x2\x2\x184\x10F"+
		"\x3\x2\x2\x2\x184\x113\x3\x2\x2\x2\x184\x117\x3\x2\x2\x2\x184\x11C\x3"+
		"\x2\x2\x2\x184\x120\x3\x2\x2\x2\x184\x124\x3\x2\x2\x2\x184\x128\x3\x2"+
		"\x2\x2\x184\x12C\x3\x2\x2\x2\x184\x130\x3\x2\x2\x2\x184\x134\x3\x2\x2"+
		"\x2\x184\x138\x3\x2\x2\x2\x184\x13D\x3\x2\x2\x2\x184\x140\x3\x2\x2\x2"+
		"\x184\x143\x3\x2\x2\x2\x184\x147\x3\x2\x2\x2\x184\x14B\x3\x2\x2\x2\x184"+
		"\x14F\x3\x2\x2\x2\x184\x154\x3\x2\x2\x2\x184\x158\x3\x2\x2\x2\x184\x15C"+
		"\x3\x2\x2\x2\x184\x160\x3\x2\x2\x2\x184\x164\x3\x2\x2\x2\x184\x169\x3"+
		"\x2\x2\x2\x184\x16D\x3\x2\x2\x2\x184\x171\x3\x2\x2\x2\x184\x175\x3\x2"+
		"\x2\x2\x184\x17A\x3\x2\x2\x2\x184\x17D\x3\x2\x2\x2\x184\x181\x3\x2\x2"+
		"\x2\x185\n\x3\x2\x2\x2\x186\x187\a\x43\x2\x2\x187\x1A5\a\"\x2\x2\x188"+
		"\x189\aZ\x2\x2\x189\x1A5\a\"\x2\x2\x18A\x18B\aN\x2\x2\x18B\x1A5\a\"\x2"+
		"\x2\x18C\x18D\a\x44\x2\x2\x18D\x1A5\a\"\x2\x2\x18E\x18F\aU\x2\x2\x18F"+
		"\x1A5\a\"\x2\x2\x190\x191\aV\x2\x2\x191\x1A5\a\"\x2\x2\x192\x193\aH\x2"+
		"\x2\x193\x1A5\a\"\x2\x2\x194\x195\a\x45\x2\x2\x195\x196\aR\x2\x2\x196"+
		"\x1A5\a\"\x2\x2\x197\x198\aR\x2\x2\x198\x199\a\x45\x2\x2\x199\x1A5\a\""+
		"\x2\x2\x19A\x19B\aU\x2\x2\x19B\x19C\aY\x2\x2\x19C\x1A5\a\"\x2\x2\x19D"+
		"\x1A5\t\x2\x2\x2\x19E\x19F\a\x45\x2\x2\x19F\x1A5\aR\x2\x2\x1A0\x1A1\a"+
		"R\x2\x2\x1A1\x1A5\a\x45\x2\x2\x1A2\x1A3\aU\x2\x2\x1A3\x1A5\aY\x2\x2\x1A4"+
		"\x186\x3\x2\x2\x2\x1A4\x188\x3\x2\x2\x2\x1A4\x18A\x3\x2\x2\x2\x1A4\x18C"+
		"\x3\x2\x2\x2\x1A4\x18E\x3\x2\x2\x2\x1A4\x190\x3\x2\x2\x2\x1A4\x192\x3"+
		"\x2\x2\x2\x1A4\x194\x3\x2\x2\x2\x1A4\x197\x3\x2\x2\x2\x1A4\x19A\x3\x2"+
		"\x2\x2\x1A4\x19D\x3\x2\x2\x2\x1A4\x19E\x3\x2\x2\x2\x1A4\x1A0\x3\x2\x2"+
		"\x2\x1A4\x1A2\x3\x2\x2\x2\x1A5\f\x3\x2\x2\x2\x1A6\x1A7\aY\x2\x2\x1A7\x1A8"+
		"\aQ\x2\x2\x1A8\x1A9\aT\x2\x2\x1A9\x1AA\a\x46\x2\x2\x1AA\x1B0\a\"\x2\x2"+
		"\x1AB\x1AC\aY\x2\x2\x1AC\x1AD\aQ\x2\x2\x1AD\x1AE\aT\x2\x2\x1AE\x1B0\a"+
		"\x46\x2\x2\x1AF\x1A6\x3\x2\x2\x2\x1AF\x1AB\x3\x2\x2\x2\x1B0\xE\x3\x2\x2"+
		"\x2\x1B1\x1B2\aT\x2\x2\x1B2\x1B3\aG\x2\x2\x1B3\x1B4\aU\x2\x2\x1B4\x1B5"+
		"\a\x44\x2\x2\x1B5\x1BB\a\"\x2\x2\x1B6\x1B7\aT\x2\x2\x1B7\x1B8\aG\x2\x2"+
		"\x1B8\x1B9\aU\x2\x2\x1B9\x1BB\a\x44\x2\x2\x1BA\x1B1\x3\x2\x2\x2\x1BA\x1B6"+
		"\x3\x2\x2\x2\x1BB\x10\x3\x2\x2\x2\x1BC\x1BD\aU\x2\x2\x1BD\x1BE\aV\x2\x2"+
		"\x1BE\x1BF\a\x43\x2\x2\x1BF\x1C0\aT\x2\x2\x1C0\x1C1\aV\x2\x2\x1C1\x1C8"+
		"\a\"\x2\x2\x1C2\x1C3\aU\x2\x2\x1C3\x1C4\aV\x2\x2\x1C4\x1C5\a\x43\x2\x2"+
		"\x1C5\x1C6\aT\x2\x2\x1C6\x1C8\aV\x2\x2\x1C7\x1BC\x3\x2\x2\x2\x1C7\x1C2"+
		"\x3\x2\x2\x2\x1C8\x12\x3\x2\x2\x2\x1C9\x1CA\aT\x2\x2\x1CA\x1CB\aG\x2\x2"+
		"\x1CB\x1CC\aU\x2\x2\x1CC\x1CD\aY\x2\x2\x1CD\x1D3\a\"\x2\x2\x1CE\x1CF\a"+
		"T\x2\x2\x1CF\x1D0\aG\x2\x2\x1D0\x1D1\aU\x2\x2\x1D1\x1D3\aY\x2\x2\x1D2"+
		"\x1C9\x3\x2\x2\x2\x1D2\x1CE\x3\x2\x2\x2\x1D3\x14\x3\x2\x2\x2\x1D4\x1D5"+
		"\aG\x2\x2\x1D5\x1D6\aP\x2\x2\x1D6\x1D7\a\x46\x2\x2\x1D7\x1DC\a\"\x2\x2"+
		"\x1D8\x1D9\aG\x2\x2\x1D9\x1DA\aP\x2\x2\x1DA\x1DC\a\x46\x2\x2\x1DB\x1D4"+
		"\x3\x2\x2\x2\x1DB\x1D8\x3\x2\x2\x2\x1DC\x16\x3\x2\x2\x2\x1DD\x1DE\a\x44"+
		"\x2\x2\x1DE\x1DF\a[\x2\x2\x1DF\x1E0\aV\x2\x2\x1E0\x1E1\aG\x2\x2\x1E1\x1E7"+
		"\a\"\x2\x2\x1E2\x1E3\a\x44\x2\x2\x1E3\x1E4\a[\x2\x2\x1E4\x1E5\aV\x2\x2"+
		"\x1E5\x1E7\aG\x2\x2\x1E6\x1DD\x3\x2\x2\x2\x1E6\x1E2\x3\x2\x2\x2\x1E7\x18"+
		"\x3\x2\x2\x2\x1E8\x1E9\a\x44\x2\x2\x1E9\x1EA\a\x43\x2\x2\x1EA\x1EB\aU"+
		"\x2\x2\x1EB\x1EC\aG\x2\x2\x1EC\x1F2\a\"\x2\x2\x1ED\x1EE\a\x44\x2\x2\x1EE"+
		"\x1EF\a\x43\x2\x2\x1EF\x1F0\aU\x2\x2\x1F0\x1F2\aG\x2\x2\x1F1\x1E8\x3\x2"+
		"\x2\x2\x1F1\x1ED\x3\x2\x2\x2\x1F2\x1A\x3\x2\x2\x2\x1F3\x1F4\a\x42\x2\x2"+
		"\x1F4\x1C\x3\x2\x2\x2\x1F5\x1F6\a%\x2\x2\x1F6\x1E\x3\x2\x2\x2\x1F7\x1F8"+
		"\a-\x2\x2\x1F8 \x3\x2\x2\x2\x1F9\x1FA\a.\x2\x2\x1FA\x1FD\a\"\x2\x2\x1FB"+
		"\x1FD\a.\x2\x2\x1FC\x1F9\x3\x2\x2\x2\x1FC\x1FB\x3\x2\x2\x2\x1FD\"\x3\x2"+
		"\x2\x2\x1FE\x1FF\a$\x2\x2\x1FF$\x3\x2\x2\x2\x200\x202\x4\x32;\x2\x201"+
		"\x200\x3\x2\x2\x2\x202\x203\x3\x2\x2\x2\x203\x201\x3\x2\x2\x2\x203\x204"+
		"\x3\x2\x2\x2\x204\x212\x3\x2\x2\x2\x205\x207\x4\x32;\x2\x206\x205\x3\x2"+
		"\x2\x2\x207\x208\x3\x2\x2\x2\x208\x206\x3\x2\x2\x2\x208\x209\x3\x2\x2"+
		"\x2\x209\x20A\x3\x2\x2\x2\x20A\x212\aJ\x2\x2\x20B\x20D\x4\x32;\x2\x20C"+
		"\x20B\x3\x2\x2\x2\x20D\x20E\x3\x2\x2\x2\x20E\x20C\x3\x2\x2\x2\x20E\x20F"+
		"\x3\x2\x2\x2\x20F\x210\x3\x2\x2\x2\x210\x212\aj\x2\x2\x211\x201\x3\x2"+
		"\x2\x2\x211\x206\x3\x2\x2\x2\x211\x20C\x3\x2\x2\x2\x212&\x3\x2\x2\x2\x213"+
		"\x215\t\x3\x2\x2\x214\x213\x3\x2\x2\x2\x215\x216\x3\x2\x2\x2\x216\x214"+
		"\x3\x2\x2\x2\x216\x217\x3\x2\x2\x2\x217\x21F\x3\x2\x2\x2\x218\x21A\t\x3"+
		"\x2\x2\x219\x218\x3\x2\x2\x2\x21A\x21B\x3\x2\x2\x2\x21B\x219\x3\x2\x2"+
		"\x2\x21B\x21C\x3\x2\x2\x2\x21C\x21D\x3\x2\x2\x2\x21D\x21F\a\"\x2\x2\x21E"+
		"\x214\x3\x2\x2\x2\x21E\x219\x3\x2\x2\x2\x21F(\x3\x2\x2\x2\x220\x221\a"+
		"Z\x2\x2\x221\x222\a$\x2\x2\x222\x224\x3\x2\x2\x2\x223\x225\t\x4\x2\x2"+
		"\x224\x223\x3\x2\x2\x2\x225\x226\x3\x2\x2\x2\x226\x224\x3\x2\x2\x2\x226"+
		"\x227\x3\x2\x2\x2\x227\x228\x3\x2\x2\x2\x228\x229\a$\x2\x2\x229*\x3\x2"+
		"\x2\x2\x22A\x22B\a\x45\x2\x2\x22B\x22C\a$\x2\x2\x22C\x22E\x3\x2\x2\x2"+
		"\x22D\x22F\t\x5\x2\x2\x22E\x22D\x3\x2\x2\x2\x22F\x230\x3\x2\x2\x2\x230"+
		"\x22E\x3\x2\x2\x2\x230\x231\x3\x2\x2\x2\x231\x232\x3\x2\x2\x2\x232\x233"+
		"\a$\x2\x2\x233,\x3\x2\x2\x2\x234\x235\a\f\x2\x2\x235.\x3\x2\x2\x2\x236"+
		"\x238\t\x6\x2\x2\x237\x236\x3\x2\x2\x2\x238\x239\x3\x2\x2\x2\x239\x237"+
		"\x3\x2\x2\x2\x239\x23A\x3\x2\x2\x2\x23A\x23B\x3\x2\x2\x2\x23B\x23C\b\x18"+
		"\x2\x2\x23C\x30\x3\x2\x2\x2\x1A\x2:l\xD9\x184\x1A4\x1AF\x1BA\x1C7\x1D2"+
		"\x1DB\x1E6\x1F1\x1FC\x203\x208\x20E\x211\x216\x21B\x21E\x226\x230\x239"+
		"\x3\x3\x18\x2";
	public static readonly ATN _ATN =
		new ATNDeserializer().Deserialize(_serializedATN.ToCharArray());
}
} // namespace Calculadora