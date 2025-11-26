lexer grammar RedlangLexer;

// PALABRAS RESERVADAS
FUNC: 'func';
ENTRY: 'entry';
DECLARE: 'declare';
SET: 'set';
OBJECT: 'object';
USE: 'use';
CHECK: 'check';
OTHERWISE: 'otherwise';
LOOP: 'loop';
REPEAT: 'repeat';
GIVES: 'gives';
AND: 'and';
OR: 'or';
NOT: 'not';
NULL: 'null';

// TIPOS PRIMITIVOS
TYPE_I: 'i';
TYPE_F: 'f';
TYPE_B: 'b';
TYPE_S: 's';

// FUNCIONES BUILT-IN
ASK: 'ask';
SHOW: 'show';
LEN: 'len';
CONVERT_OP: 'convertToInt' | 'convertToFloat' | 'convertToBoolean';
FILE_OP: 'readfile' | 'writefile';

// LITERALES
BOOL: 'true' | 'false';
FLOAT: '-'?[0-9]+ '.' [0-9]+;
INT: '-'?[0-9]+;

STRING: '"' (ESC_SEQ | ~('\\' | '"'))* '"';
fragment ESC_SEQ: '\\' [btn"\\'];

// IDENTIFICADORES
IDENT: ID;
fragment ID: [a-zA-Z_] [a-zA-Z0-9_]*;

// SÍMBOLOS Y OPERADORES
COMMA: ',';
DOT: '.';
COLON: ':';
SEMI_COLON: ';';
EQUAL: '=';
QUESTION: '?';
UNDERSCORE: '_';

O_PAREN: '(';
C_PAREN: ')';
O_BRACKETS: '[';
C_BRACKETS: ']';
O_BRACES: '{';
C_BRACES: '}';

PLUS: '+';
MINUS: '-';
MULTIPLY: '*';
DIVIDE: '/';
MODULO: '%';

LTHAN: '<';
GTHAN: '>';
LTE: '<=';
GTE: '>=';
EQ: '==';
NEQ: '!=';

// ESPACIOS EN BLANCO
WS: [ \t\r\n] -> skip;
