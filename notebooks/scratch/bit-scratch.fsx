
//open System
open type System.Convert

let bitPrinter (n: int) (binary: int)  = printfn "%s" (Convert.ToString(binary,2).PadLeft(n,'0'))
let printer = bitPrinter 4

let x = 0b0000
let y = 0b1000

printer x
printer y

printer (x ||| y)
printer (x &&& y)

// Oring with 1 set all bits to one
printer ( 0b0000 ||| 0b1111)
printer ( 0b0101 ||| 0b1111)
printer ( 0b1111 ||| 0b1111)

// Oring with 0 does nothing
printer ( 0b0000 ||| 0b0000)
printer ( 0b0101 ||| 0b0000)
printer ( 0b1111 ||| 0b0000)

// Anding with 1 does nothing
printer ( 0b0000 &&& 0b1111)
printer ( 0b0101 &&& 0b1111)
printer ( 0b1111 &&& 0b1111)

// Anding with 0 sets all bits to zero
printer ( 0b0000 &&& 0b0000)
printer ( 0b0101 &&& 0b0000)
printer ( 0b1111 &&& 0b0000)

// different lengths (zeros added to fill the gap)
ToString(( 0b1111 &&& 0b0), 2)
ToString(( 0b1011 ||| 0b0), 2)