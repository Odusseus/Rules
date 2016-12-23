# Rules

Basis for a portable Rules engine, see unitests.

Exemples 

1)
(R1 && R2) => R3
(True && True) => True 

( R3 && R4 ) => R5
R5 = ( True && True ) => True

2)
(R1 && R2) => R3 
(True && False) => False
( R3 && R4 ) => R5
R5 = ( False && True ) => False
