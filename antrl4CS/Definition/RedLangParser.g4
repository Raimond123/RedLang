parser grammar RedlangParser;

options { tokenVocab=RedlangLexer; }

// ============================================================================
// REGLAS DEL PARSER (SINTAXIS)
// ============================================================================

program : (use_stmt | clase_decl)* EOF;

// ESTRUCTURA DE CLASES
use_stmt : USE IDENT SEMI_COLON;

clase_decl : OBJECT IDENT O_BRACES classMember* C_BRACES;

classMember : declare_stmt | func_decl | entry_func_decl;

// FUNCIONES
func_decl : FUNC IDENT O_PAREN param_list? C_PAREN COLON data_type block;

entry_func_decl : ENTRY func_decl;

param_list : param (COMMA param)*;

param : IDENT COLON data_type;

// BLOQUES Y STATEMENTS
block : O_BRACES statement* C_BRACES;

statement
    : declare_stmt
    | set_stmt
    | return_stmt
    | stmt_control
    | func_call SEMI_COLON
    | member_access SEMI_COLON
    ;

// DECLARACIONES Y ASIGNACIONES
declare_stmt : DECLARE IDENT COLON (data_type | IDENT?) (EQUAL expression)? SEMI_COLON;

set_stmt : SET assign_target EQUAL expression SEMI_COLON;

assign_target : IDENT | array_access | member_access;

return_stmt : GIVES expression? SEMI_COLON;

// ESTRUCTURAS DE CONTROL (check, loop, repeat)
stmt_control : check_stmt | loop_stmt | repeat_stmt;

check_stmt : CHECK O_PAREN expression C_PAREN block otherwiseOpcional?;

otherwiseOpcional : OTHERWISE block;

loop_stmt : LOOP O_PAREN loopInit SEMI_COLON expression SEMI_COLON accionLoop C_PAREN block;

loopInit : decl_head (EQUAL expression)? | accionLoop;

accionLoop : SET assign_target EQUAL expression;

repeat_stmt : REPEAT O_PAREN expression C_PAREN block;

decl_head : DECLARE IDENT COLON (data_type | IDENT?);

// TIPOS DE DATOS
data_type : type_base array_specifier? QUESTION?;

type_base : TYPE_I | TYPE_F | TYPE_B | TYPE_S | IDENT ;

array_specifier : O_BRACKETS expression? C_BRACKETS;

// EXPRESIONES
expression
    : expression OR expression
    | expression AND expression
    | NOT expression
    | expression comparator expression
    | expression (PLUS | MINUS) expression
    | expression (MULTIPLY | DIVIDE | MODULO) expression
    | MINUS expression
    | factor
    ;

comparator : EQ | NEQ | GTE | LTE | GTHAN | LTHAN;

factor
    : IDENT
    | literal
    | array_access
    | member_access
    | func_call
    | O_PAREN expression C_PAREN
    ;

// LITERALES Y ARREGLOS
literal : BOOL | FLOAT | INT | STRING | NULL | array_literal;

array_literal : O_BRACKETS (arg_list)? C_BRACKETS;

// ACCESOS Y LLAMADAS A FUNCIÓN
array_access : IDENT O_BRACKETS expression C_BRACKETS;

member_access : IDENT DOT IDENT | IDENT DOT func_call;

func_call
    : (ASK | SHOW | LEN | FILE_OP | CONVERT_OP) O_PAREN arg_list? C_PAREN
    | IDENT O_PAREN arg_list? C_PAREN
    ;

arg_list : expression (COMMA expression)*;
