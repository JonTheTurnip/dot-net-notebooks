
open System.Collections.Generic
open System.Numerics


// 1. 

let mutable state = (1I <<< 127) ||| 1I // 128 bit state register
let mutable outputs = 0I // store all outputs

// a populate our outputs container
for i = 1 to 10_000 do    
    // update register
    let newbit = (state ^^^ (state >>> 1) ^^^ (state >>> 2) ^^^ (state >>> 7)) &&& 1I    
    state <- (state >>> 1) ||| (newbit <<< 127)
    // add register output to our outputs container
    outputs <- ((outputs ||| newbit) <<< 1)

//b generate our coordinates

// not workign yet!!! have a look at this 
// https://stackoverflow.com/questions/3270307/how-do-i-get-the-lower-8-bits-of-an-int

let x = List<BigInteger>()
let y = List<BigInteger>()

for i = 1 to 10 do
    let x' = (outputs ||| 0I) // get left most 32 bits  (doesn't limit  when using biginteger, but can't use operator on a non biginteger)
    outputs <- outputs >>> 32 // right shift 
    let y' = (outputs ||| 0I)
    outputs <- outputs >>> 32
    x.Add(x')
    y.Add(y')

x

//  /////////////////////////////////////////////////////////////// 

//     // for j = 1 to 32 do
//     //     let mutable x' = 0
//     //     let newbit = (state ^^^ (state >>> 1) ^^^ (state >>> 2) ^^^ (state >>> 7)) &&& 1I // use xor on 'taps' 1, 2 and 7 to get new bit        
//     //     state <- (state >>> 1) ||| (newbit <<< 127) // shift state right then set left most bit to the new bit
//     //     x <- (x ||| newbit) 


// let mutable z = 1
// for i = 1 to 10 do
//     printfn "%s" (System.Convert.ToString(z,2))
//     z <- ((z <<< 1) ||| 1)
