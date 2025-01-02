grammar MiniLang;

// Define types
type: 'int' | 'float' | 'double' | 'string' | 'void';

// Parser rules
program: globalVariable* function* mainFunction EOF;

globalVariable:
	type VARIABLE_NAME ASSIGNMENT_OPERATOR expression SEMICOLON;

function: type VARIABLE_NAME LPAREN parameterList? RPAREN block;

mainFunction: 'int' 'main' LPAREN RPAREN block;

parameterList: parameter (COMMA parameter)*;
parameter: type VARIABLE_NAME;

block: LBRACE statement* RBRACE;

statement:
	declaration
	| assignment
	| ifStatement
	| forLoop
	| functionCall SEMICOLON
	| returnStatement
	| expression SEMICOLON;

declaration:
	type VARIABLE_NAME (ASSIGNMENT_OPERATOR expression)? SEMICOLON;
assignment:
	VARIABLE_NAME ASSIGNMENT_OPERATOR expression SEMICOLON;

ifStatement: 'if' LPAREN condition RPAREN block ( 'else' block)?;

forLoop:
	'for' LPAREN forInit condition SEMICOLON forUpdate RPAREN block;

forInit: declaration | assignment;
forUpdate: assignment | expression;

functionCall: VARIABLE_NAME LPAREN argumentList? RPAREN;
argumentList: expression (COMMA expression)*;

returnStatement: 'return' (expression)? SEMICOLON;

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
	| VARIABLE_NAME
	| functionCall;

// Lexer rules
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
MULTILINE_COMMENT: '/*' .*? '*/' -> skip;