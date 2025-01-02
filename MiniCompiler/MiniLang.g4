grammar MiniLang;

//parser rules

declaration: type VARIABLE_NAME EQUALS value SEMICOLON;
type: INTEGER_TYPE | FLOAT_TYPE | STRING_TYPE;
value: INTEGER_VALUE | FLOAT_VALUE | STRING_VALUE;

//lexer rules

INTEGER_TYPE: 'int';
FLOAT_TYPE: 'float';
STRING_TYPE: 'string';
EQUALS: '=';
SEMICOLON: ';';
INTEGER_VALUE: [0-9]+;
FLOAT_VALUE: [0-9]+ '.' [0-9]+;
STRING_VALUE: '"' .+? '"';
VARIABLE_NAME: [a-zA-Z][a-zA-Z0-9]*;

WS: [ \t\r\n]+ -> skip;