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
using Antlr4.Runtime.Misc;
using IParseTreeListener = Antlr4.Runtime.Tree.IParseTreeListener;
using IToken = Antlr4.Runtime.IToken;

/// <summary>
/// This interface defines a complete listener for a parse tree produced by
/// <see cref="Gramatica_CalculadoraParser"/>.
/// </summary>
[System.CodeDom.Compiler.GeneratedCode("ANTLR", "4.6.6")]
[System.CLSCompliant(false)]
public interface IGramatica_CalculadoraListener : IParseTreeListener {
	/// <summary>
	/// Enter a parse tree produced by <see cref="Gramatica_CalculadoraParser.programa"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterPrograma([NotNull] Gramatica_CalculadoraParser.ProgramaContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="Gramatica_CalculadoraParser.programa"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitPrograma([NotNull] Gramatica_CalculadoraParser.ProgramaContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="Gramatica_CalculadoraParser.inicio"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterInicio([NotNull] Gramatica_CalculadoraParser.InicioContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="Gramatica_CalculadoraParser.inicio"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitInicio([NotNull] Gramatica_CalculadoraParser.InicioContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="Gramatica_CalculadoraParser.fin"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterFin([NotNull] Gramatica_CalculadoraParser.FinContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="Gramatica_CalculadoraParser.fin"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitFin([NotNull] Gramatica_CalculadoraParser.FinContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="Gramatica_CalculadoraParser.entrada"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterEntrada([NotNull] Gramatica_CalculadoraParser.EntradaContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="Gramatica_CalculadoraParser.entrada"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitEntrada([NotNull] Gramatica_CalculadoraParser.EntradaContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="Gramatica_CalculadoraParser.proposiciones"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterProposiciones([NotNull] Gramatica_CalculadoraParser.ProposicionesContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="Gramatica_CalculadoraParser.proposiciones"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitProposiciones([NotNull] Gramatica_CalculadoraParser.ProposicionesContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="Gramatica_CalculadoraParser.proposicion"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterProposicion([NotNull] Gramatica_CalculadoraParser.ProposicionContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="Gramatica_CalculadoraParser.proposicion"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitProposicion([NotNull] Gramatica_CalculadoraParser.ProposicionContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="Gramatica_CalculadoraParser.instruccion"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterInstruccion([NotNull] Gramatica_CalculadoraParser.InstruccionContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="Gramatica_CalculadoraParser.instruccion"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitInstruccion([NotNull] Gramatica_CalculadoraParser.InstruccionContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="Gramatica_CalculadoraParser.directiva"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterDirectiva([NotNull] Gramatica_CalculadoraParser.DirectivaContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="Gramatica_CalculadoraParser.directiva"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitDirectiva([NotNull] Gramatica_CalculadoraParser.DirectivaContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="Gramatica_CalculadoraParser.direqu"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterDirequ([NotNull] Gramatica_CalculadoraParser.DirequContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="Gramatica_CalculadoraParser.direqu"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitDirequ([NotNull] Gramatica_CalculadoraParser.DirequContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="Gramatica_CalculadoraParser.tipodirectiva"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterTipodirectiva([NotNull] Gramatica_CalculadoraParser.TipodirectivaContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="Gramatica_CalculadoraParser.tipodirectiva"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitTipodirectiva([NotNull] Gramatica_CalculadoraParser.TipodirectivaContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="Gramatica_CalculadoraParser.etiqueta"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterEtiqueta([NotNull] Gramatica_CalculadoraParser.EtiquetaContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="Gramatica_CalculadoraParser.etiqueta"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitEtiqueta([NotNull] Gramatica_CalculadoraParser.EtiquetaContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="Gramatica_CalculadoraParser.opinstruccion"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterOpinstruccion([NotNull] Gramatica_CalculadoraParser.OpinstruccionContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="Gramatica_CalculadoraParser.opinstruccion"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitOpinstruccion([NotNull] Gramatica_CalculadoraParser.OpinstruccionContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="Gramatica_CalculadoraParser.formato"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterFormato([NotNull] Gramatica_CalculadoraParser.FormatoContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="Gramatica_CalculadoraParser.formato"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitFormato([NotNull] Gramatica_CalculadoraParser.FormatoContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="Gramatica_CalculadoraParser.f1"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterF1([NotNull] Gramatica_CalculadoraParser.F1Context context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="Gramatica_CalculadoraParser.f1"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitF1([NotNull] Gramatica_CalculadoraParser.F1Context context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="Gramatica_CalculadoraParser.f2"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterF2([NotNull] Gramatica_CalculadoraParser.F2Context context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="Gramatica_CalculadoraParser.f2"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitF2([NotNull] Gramatica_CalculadoraParser.F2Context context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="Gramatica_CalculadoraParser.f3"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterF3([NotNull] Gramatica_CalculadoraParser.F3Context context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="Gramatica_CalculadoraParser.f3"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitF3([NotNull] Gramatica_CalculadoraParser.F3Context context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="Gramatica_CalculadoraParser.f4"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterF4([NotNull] Gramatica_CalculadoraParser.F4Context context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="Gramatica_CalculadoraParser.f4"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitF4([NotNull] Gramatica_CalculadoraParser.F4Context context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="Gramatica_CalculadoraParser.simple3"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterSimple3([NotNull] Gramatica_CalculadoraParser.Simple3Context context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="Gramatica_CalculadoraParser.simple3"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitSimple3([NotNull] Gramatica_CalculadoraParser.Simple3Context context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="Gramatica_CalculadoraParser.indirecto3"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterIndirecto3([NotNull] Gramatica_CalculadoraParser.Indirecto3Context context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="Gramatica_CalculadoraParser.indirecto3"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitIndirecto3([NotNull] Gramatica_CalculadoraParser.Indirecto3Context context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="Gramatica_CalculadoraParser.inmediato3"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterInmediato3([NotNull] Gramatica_CalculadoraParser.Inmediato3Context context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="Gramatica_CalculadoraParser.inmediato3"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitInmediato3([NotNull] Gramatica_CalculadoraParser.Inmediato3Context context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="Gramatica_CalculadoraParser.opdirectiva"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterOpdirectiva([NotNull] Gramatica_CalculadoraParser.OpdirectivaContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="Gramatica_CalculadoraParser.opdirectiva"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitOpdirectiva([NotNull] Gramatica_CalculadoraParser.OpdirectivaContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="Gramatica_CalculadoraParser.expresion"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterExpresion([NotNull] Gramatica_CalculadoraParser.ExpresionContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="Gramatica_CalculadoraParser.expresion"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitExpresion([NotNull] Gramatica_CalculadoraParser.ExpresionContext context);

	/// <summary>
	/// Enter a parse tree produced by <see cref="Gramatica_CalculadoraParser.expresion2"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterExpresion2([NotNull] Gramatica_CalculadoraParser.Expresion2Context context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="Gramatica_CalculadoraParser.expresion2"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitExpresion2([NotNull] Gramatica_CalculadoraParser.Expresion2Context context);
}
} // namespace Calculadora
