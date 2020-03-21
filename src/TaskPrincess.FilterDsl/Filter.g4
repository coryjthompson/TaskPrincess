grammar Filter;

/*
 * Parser Rules
 */

query : expression ;

expression
    :   expression binary_operator? expression    #BinaryExpression
    |   predicate                                 #PredicateExpression
    |   filter_id                                 #FilterIdExpression 
    |   filter_tags                               #FilterTagsExpression
    |   '(' expression ')'                        #ParenthesesExpression
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
   | date         # DateValue
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

date 
    : date_day
    | date_week
    | date_month
    | date_calc
    ;

date_day 
    :   DAY_MONDAY
    |   DAY_TUESDAY
    |   DAY_WEDNESDAY
    |   DAY_THURSDAY
    |   DAY_FRIDAY
    |   DAY_SATURDAY
    |   DAY_SUNDAY
    |   DAY_ORDINAL ;

date_week
    :   WEEK_SOCW
    |   WEEK_EOCW
    |   WEEK_SOW
    |   WEEK_EOW
    |   WEEK_SOWW
    |   WEEK_EOWW
    |   WEEK_SOD
    |   WEEK_EOD
    |   WEEK_YESTERDAY
    |   WEEK_TODAY
    |   WEEK_NOW
    |   WEEK_TOMORROW ;

date_month
    :   MONTH_JANUARY
    |   MONTH_FEBUARY
    |   MONTH_MARCH
    |   MONTH_APRIL
    |   MONTH_MAY
    |   MONTH_JUNE
    |   MONTH_JULY
    |   MONTH_AUGUST
    |   MONTH_SEPTEMBER
    |   MONTH_OCTOBER
    |   MONTH_NOVEMBER
    |   MONTH_DECEMBER
    ;

date_calc
    : DATE_CALC_LATER ;

property : WORD ;

 /*
  * Lexer Rules
  */
fragment HEX: [a-fA-F0-9] ;
fragment A : [aA]; // match either an 'a' or 'A'
fragment B : [bB];
fragment C : [cC];
fragment D : [dD];
fragment E : [eE];
fragment F : [fF];
fragment G : [gG];
fragment H : [hH];
fragment I : [iI];
fragment J : [jJ];
fragment K : [kK];
fragment L : [lL];
fragment M : [mM];
fragment N : [nN];
fragment O : [oO];
fragment P : [pP];
fragment Q : [qQ];
fragment R : [rR];
fragment S : [sS];
fragment T : [tT];
fragment U : [uU];
fragment V : [vV];
fragment W : [wW];
fragment X : [xX];
fragment Y : [yY];
fragment Z : [zZ];

DOT      : '.' ;
STRING   : '"' ( '\\"' | . )*? '"' 
         | '\'' ( '\\\'' | . )*? '\''
         ;

INT      : '-'? [0-9]+ ;
DOUBLE   : '-'? [0-9]+'.'[0-9]+ ;
UUID     : HEX HEX HEX HEX  HEX HEX HEX HEX '-' HEX HEX HEX HEX '-' HEX HEX HEX HEX '-' HEX HEX HEX HEX '-' HEX HEX HEX HEX HEX HEX HEX HEX  HEX HEX HEX HEX;

AND      : ',' | A N D ;
OR       : O R ;
XOR      : X O R ;

COLON        : ':' ;
NOT          : N O T;
BEFORE       : B E F O R E | B E L O W ;
AFTER        : A F T E R | A B O V E ;
NONE         : N O N E ;
ANY          : A N Y ;
MEQUALS      : E Q U A L S | I S ;
ISNT         : I S N T ;
HAS          : H A S | C O N T A I N S ;
HASNT        : H A S N T ;
STARTS_WITH  : S T A R T S W I T H | L E F T ;
ENDS_WITH    : E N D S W I T H | R I G H T ;
MWORD        : W O R D ;
NO_WORD      : N O W O R D ;

LESS_THAN_OR_EQUAL_TO    : '<=' ;
GREATER_THAN_OR_EQUAL_TO : '>=' ;
LESS_THAN                : '<' ;
GREATER_THAN             : '>' ;
NOT_EQUAL                : '!=' '=' ? ;
EQUALS                   : '=' '=' ? ;

TAG      : '+' WORD
         | '-' WORD
         ;
/* Dates */
DAY_MONDAY     : M O N D A Y | M O N ;
DAY_TUESDAY    : T U E S D A Y | T U E ;
DAY_WEDNESDAY  : W E D N E D A Y | W E D ;
DAY_THURSDAY   : T H U R S D A Y | T H U ;
DAY_FRIDAY     : F R I D A Y | F R I ;
DAY_SATURDAY   : S A T U R D A Y | S A T ;
DAY_SUNDAY     : S U N D A Y | S U N ;

DAY_ORDINAL    : [0-9][0-9]? S T | [0-9][0-9]? N D | [0-9][0-9]? R D | [0-9][0-9] T H ;

WEEK_SOCW        : S O C W ;
WEEK_EOCW        : E O C W ;
WEEK_SOW         : S O W ;
WEEK_EOW         : E O W ;
WEEK_SOWW        : S O W W ;
WEEK_EOWW        : E O W W ;
WEEK_SOD         : S O D ;
WEEK_EOD         : E O D ;
WEEK_YESTERDAY   : Y E S T E R D A Y ;
WEEK_TODAY       : T O D A Y ;
WEEK_NOW         : N O W ;
WEEK_TOMORROW    : T O M O R R O W ;

MONTH_JANUARY    : J A N U A R Y | J A N ;
MONTH_FEBUARY    : F E B U A R Y | F E B ;
MONTH_MARCH      : M A R C H | M A R ;
MONTH_APRIL      : A P R I L | A P R ;
MONTH_MAY        : M A Y ;
MONTH_JUNE       : J U N E | J U N ;
MONTH_JULY       : J U L Y | J U L ;
MONTH_AUGUST     : A U G U S T | A U G ;
MONTH_SEPTEMBER  : S E P T E M B E R | S E P T | S E P ;
MONTH_OCTOBER    : O C T O B E R | O C T ;
MONTH_NOVEMBER   : N O V E M B E R | N O V ;
MONTH_DECEMBER   : D E C E M B E R | D E C ;

DATE_CALC_LATER  : L A T E R | S O M E D A Y ;

REGEX    : '/' (.)*? '/' ;

WORD            : [a-zA-Z_][a-zA-Z_0-9]* ;
WHITESPACE      : [ \t\r\n]+ -> skip ;
