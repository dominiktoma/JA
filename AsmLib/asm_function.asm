.code

; Eksport nazwy procedury dla konsolidatora (Linkera)
public AddAsm

AddAsm proc
    ; W konwencji x64 ABI dla typów 'double':
    ; XMM0 = pierwszy argument (a)
    ; XMM1 = drugi argument (b)
    
    addsd xmm0, xmm1    ; Dodaj skalarne double: XMM0 = XMM0 + XMM1
    
    ret                 ; Wynik typu double wraca w XMM0
AddAsm endp

end