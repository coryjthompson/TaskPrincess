grammar Filter;

/*
 * Parser Rules
 */

query : expression ;

expression
    :   expression binary_operator? expression
    |   predicate
    |   filter_id
    |   filter_tags
    |   '(' expression ')'
    ;

filter_id
    : UUID
    | INT
    ;

filter_tags
    : TAG
    ;

predicate
    : property (DOT property_modifier)? COLON constant?
    | property relational_operator constant
    ;

binary_operator
    : AND
    | OR
    | XOR
    ;

relational_operator
    : LESS_THAN_OR_EQUAL_TO
    | GREATER_THAN_OR_EQUAL_TO
    | LESS_THAN
    | GREATER_THAN 
    | NOT_EQUAL
    | EQUALS
    ;

constant
    : value
    ;

value
   : INT          # IntegerValue
   | DOUBLE       # DoubleValue
   | STRING       # LiteralStringValue
   | REGEX        # RegexValue
   | UUID         # UuidValue
   | WORD         # StringValue
   ;

property_modifier
    :  NOT
    |  BEFORE
    |  AFTER
    |  NONE
    |  ANY
    |  MEQUALS
    |  ISNT
    |  HAS
    |  HASNT
    |  STARTS_WITH
    |  ENDS_WITH
    |  MWORD
    |  NO_WORD
    ;

property : WORD ;

 /*
  * Lexer Rules
  */
fragment HEX: [a-fA-F0-9];

DOT      : '.' ;
STRING   : '"' ( '\\"' | . )*? '"' 
         | '\'' ( '\\\'' | . )*? '\''
         ;

INT      : '-'? [0-9]+ ;
DOUBLE   : '-'? [0-9]+'.'[0-9]+ ;
UUID     : HEX HEX HEX HEX  HEX HEX HEX HEX '-' HEX HEX HEX HEX '-' HEX HEX HEX HEX '-' HEX HEX HEX HEX '-' HEX HEX HEX HEX HEX HEX HEX HEX  HEX HEX HEX HEX;

AND      : ',' | 'and' | 'AND' ;
OR       : 'or' | 'OR' ;
XOR      : 'xor' | 'XOR' ;

COLON    : ':' ;
NOT        : 'NOT' | 'not';
BEFORE     : 'BEFORE' | 'before' | 'BELOW' | 'below' ;
AFTER      : 'AFTER' | 'after' | 'ABOVE' | 'above' ;
NONE       : 'NONE' | 'none' ;
ANY        : 'ANY' | 'any' ;
MEQUALS    : 'EQUALS' | 'equals' | 'IS' | 'is' ;
ISNT       : 'ISNT' | 'isnt' ;
HAS        : 'HAS' | 'has' | 'CONTAINS' | 'contains' ;
HASNT      : 'HASNT' | 'hasnt' ;
STARTS_WITH : 'STARTS_WITH' | 'startswith' | 'LEFT' | 'left' ;
ENDS_WITH   : 'ENDS_WITH' | 'endswith' | 'RIGHT' | 'right' ;
MWORD      : 'WORD' | 'word' ;
NO_WORD     : 'NO_WORD' | 'noword' ;

LESS_THAN_OR_EQUAL_TO    : '<=' ;
GREATER_THAN_OR_EQUAL_TO : '>=' ;
LESS_THAN             : '<' ;
GREATER_THAN          : '>' ;
NOT_EQUAL             : '!=' '=' ? ;
EQUALS               : '=' '=' ? ;


TAG      : '+' WORD
         | '-' WORD
         ;

REGEX    : '/' (.)*? '/' ;

WORD            : [a-zA-Z_][a-zA-Z_0-9]* ;
WHITESPACE      : [ \t\r\n]+ -> skip ;
