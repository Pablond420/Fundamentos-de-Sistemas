grammar Gramatica_Calculadora;								//nombre de la gramatica
/*
*opciones de compilacion de la gramatica
*/
options {							
    language=CSharp2;								//lenguaje objetivo de la gramatica
}
/*
*	Reglas del Parser
*//**
**/
programa:
	inicio proposiciones fin
	;
inicio:
	etiqueta START NUM FINL|proposicion
	;
fin:
	END entrada FINL|END entrada
	;
entrada:
	MEM_DIR?
	;
proposiciones:
	(proposicion) (proposicion)*
	;
proposicion:
	instruccion | directiva
	;
instruccion:
	etiqueta opinstruccion FINL
	;
directiva:
	etiqueta tipodirectiva opdirectiva FINL
	;
tipodirectiva:
	BASE | BYTE | WORD | RESB | RESW
	;
etiqueta:
	MEM_DIR?
	;
opinstruccion:
	formato
	;
formato:
	f1 | f2 | f3 | f4
	;
f1:
	COD_OP_F1
	;
f2:
	COD_OP_F2 REG | COD_OP_F2 REG COMA REG | COD_OP_F2 REG COMA NUM
	;
f3:
	simple3 | indirecto3 | inmediato3 | RSUB
	;
f4:
	FORMATO4+f3
	;
simple3:
	COD_OP_F3 MEM_DIR | COD_OP_F3 NUM | COD_OP_F3 NUM COMA REG | COD_OP_F3 MEM_DIR COMA REG
	;
indirecto3:
	COD_OP_F3 ARROBA NUM | COD_OP_F3 ARROBA MEM_DIR
	;
inmediato3:
	COD_OP_F3 HASHTAG NUM | COD_OP_F3 HASHTAG MEM_DIR
	;
opdirectiva:
	NUM | CONSTHEX | CONSTCAD | MEM_DIR
	;

/*
*	Reglas del Lexer.
*/
RSUB  :  'RSUB'	| 'RSUB ';
COD_OP_F1
	:'FIX '|'FLOAT '|'HIO '|'NORM '|'SIO '|'TIO '|'FIX'|'FLOAT'|'HIO'|'NORM'|'SIO'|'TIO'
	;
COD_OP_F2
	:'ADDR '|'CLEAR '|'COMPR '|'DIVR '|'MULR '|'RMO '|'SHIFTL '|'SHIFTR '|'SUBR '|'SVC '|'TIXR '|'ADDR'|'CLEAR'|'COMPR'|'DIVR'|'MULR'|'RMO'|'SHIFTL'|'SHIFTR'|'SUBR'|'SVC'|'TIXR'
	;
COD_OP_F3
	:'ADD '|'ADDF '|'AND '|'COMP '|'COMPF '|'DIV '|'DIVF '|'J '|'JEQ '|'JGT '|'JLT '|'JSUB '|'LDA '|'LDB '|'LDCH '|'LDF '|'LDL '|'LDS '|'LDT '|'LDX '|'LPS '|'MUL '|'MULF '|'OR '|'RD '|
	'SSK '|'STA '|'STB '|'STCH '|'STF '|'STI '|'STL '|'STS '|'STSW '|'STT '|'STX '|'SUB '|
	'SUBF '|'TD '|'TIX '|'WD '
	;
REG
	:('A '|'X '|'L '|'B '|'S '|'T '|'F '|'CP '|'PC '|'SW ' |'A'|'X'|'L'|'B'|'S'|'T'|'F'|'CP'|'PC'|'SW')
	;
WORD	:	'WORD '|'WORD';
RESB	:	'RESB '|'RESB';
START	:	'START '|'START';
RESW	:	'RESW '|'RESW';
END	:		'END ' | 'END';
BYTE	:	'BYTE '|'BYTE';
BASE	:	'BASE '|'BASE';
ARROBA	:	'@';
HASHTAG	:	'#';
FORMATO4:	'+';
COMA	:	', '|',';
COMILLA	:	'"';
NUM
	:('0'..'9')+|('0'..'9')+'H'|('0'..'9')+'h'
	;
MEM_DIR:	('a'..'z'|'A'..'Z'|'0'..'9')+|('a'..'z'|'A'..'Z'|'0'..'9')+' ';

// Etiquetas para reconocer el campo de la directiva byte 
CONSTHEX:	'X"'('0'..'9'|'A'..'F')+'"' //token valido para reconocer un numero en hexadecimal
    ;
CONSTCAD:	'C"'('a'..'z'|'A'..'Z')+'"' //token valido para reconocer una cadena 
    ;

FINL
	:'\n'
	;
WS
	: (' '|'\r'|'\n'|'\t')+ {Skip();}
	;
