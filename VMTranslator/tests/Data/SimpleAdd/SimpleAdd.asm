//push constant 7
@7
D=A
@0
A=M
M=D
@0
M=M+1
//push constant 8
@8
D=A
@0
A=M
M=D
@0
M=M+1
//add
@SP
M=M-1
A=M
D=M
@SP
A=M-1
M=D+M
