.code

; Export funkcji dla P/Invoke
public AddAsm

AddAsm proc
    ; RCX = a, RDX = b
    mov rax, rcx
    add rax, rdx
    ret
AddAsm endp

end