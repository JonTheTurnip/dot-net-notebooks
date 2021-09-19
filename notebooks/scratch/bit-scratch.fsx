
open System

let bitPrinter (binary: int) (n: int) = printfn "%s" (Convert.ToString(binary,2).PadLeft(n,'0'))

let x = 0b0000
let y = 0b1000

bitPrinter x 4
bitPrinter y 4

bitPrinter (x ||| y) 4
bitPrinter (x &&& y) 4