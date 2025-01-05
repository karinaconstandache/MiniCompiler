grammar MiniLang;

// Define types
type: INT | FLOAT | DOUBLE | STRING | VOID;

// Parser rules
program: (globalVariable | function | mainFunction)* EOF;

globalVariable:
	type VARIABLE_NAME ASSIGNMENT_OPERATOR expression SEMICOLON
	| type VARIABLE_NAME SEMICOLON;

function: type VARIABLE_NAME LPAREN parameterList? RPAREN block;

mainFunction: INT MAIN LPAREN RPAREN block;

parameterList: parameter (COMMA parameter)*;
parameter: type VARIABLE_NAME;

block: LBRACE statement* RBRACE;

statement:
	declaration
	| assignment
	| ifStatement
	| forLoop
	| whileStatement
	| functionCall SEMICOLON
	| returnStatement
	| expression SEMICOLON
	| VARIABLE_NAME LPAREN argumentList? RPAREN SEMICOLON; // Fix pentru apelurile de funcții

declaration:
	type VARIABLE_NAME (ASSIGNMENT_OPERATOR expression)? SEMICOLON;

assignment:
	VARIABLE_NAME ASSIGNMENT_OPERATOR expression SEMICOLON;

ifStatement: IF LPAREN condition RPAREN block ( ELSE block)?;

forLoop:
	FOR LPAREN forInit condition SEMICOLON forUpdate RPAREN block;

whileStatement: WHILE LPAREN condition RPAREN block;

forInit: declaration | assignment;
forUpdate: assignment | expression;

functionCall: VARIABLE_NAME LPAREN argumentList? RPAREN;
argumentList: expression (COMMA expression)*;

returnStatement: RETURN (expression)? SEMICOLON;

condition:
	expression (RELATIONAL_OPERATOR expression)?
	| LPAREN condition RPAREN
	| condition LOGICAL_OPERATOR condition;

expression:
	value
	| expression ARITHMETIC_OPERATOR expression
	| LPAREN expression RPAREN
	| functionCall
	| VARIABLE_NAME INCREMENT_OPERATOR
	| INCREMENT_OPERATOR VARIABLE_NAME;

value:
	INTEGER_VALUE
	| FLOAT_VALUE
	| DOUBLE_VALUE
	| STRING_VALUE
	| VARIABLE_NAME;

// Lexer rules
INT: 'int';
FLOAT: 'float';
DOUBLE: 'double';
STRING: 'string';
VOID: 'void';
IF: 'if';
ELSE: 'else';
FOR: 'for';
WHILE: 'while';
RETURN: 'return';
MAIN: 'main';

INTEGER_VALUE: [0-9]+;
FLOAT_VALUE: [0-9]+ '.' [0-9]+;
DOUBLE_VALUE: [0-9]+ '.' [0-9]+ ('e' [+-]? [0-9]+)?;
STRING_VALUE: '"' .*? '"';
VARIABLE_NAME: [a-zA-Z_][a-zA-Z0-9_]*;

RELATIONAL_OPERATOR: '<' | '>' | '<=' | '>=' | '==' | '!=';
LOGICAL_OPERATOR: '&&' | '||';
ARITHMETIC_OPERATOR: '+' | '-' | '*' | '/' | '%';
INCREMENT_OPERATOR: '++' | '--';
ASSIGNMENT_OPERATOR: '=' | '+=' | '-=' | '*=' | '/=' | '%=';

SEMICOLON: ';';
COMMA: ',';
LPAREN: '(';
RPAREN: ')';
LBRACE: '{';
RBRACE: '}';

// Skip whitespace and comments
WS: [ \t\r\n]+ -> skip;
COMMENT: '//' ~[\r\n]* -> skip;
MULTILINE_COMMENT: '/' .? '*/' -> skip;