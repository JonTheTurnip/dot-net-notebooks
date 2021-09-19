
// open System.Convert // why does this  not work?

// See the python script of same name, converted the python to f# for fun
// https://www.youtube.com/watch?v=Ks1pw1X22y4

// 1. Simple 4 bit register

let printBinary (binary: int) = printfn "%s" (System.Convert.ToString(binary,2).PadLeft(4,'0'))

let mutable state = 0b1001
for i = 1 to 20 do
    //printBinary state
    printf "%i" (state &&& 1)
    let newbit = (state ^^^ (state >>> 1)) &&& 1
    state <- (state >>> 1) ||| (newbit <<< 3)
    

// 2.Now do a 128 bit register 

// !!!! (this doesn't work like python because in python ints are of arbritary length by default)
// !!!! Need to convert the code below to use the .net *** biginteger ***

// If we use 'taps' 1,2 and 7 then we get the maxmium number of combinations, i.e 2 ^ 128 - 1, this can be mathematically
// proven, will look into that another time?

let mutable state = (1 <<< 127) ||| 1 // create 128 bits where first bit is one (non zero)
//while true do
for i = 1 to 20 do
    printf "%i" (state &&& 1)
    let newbit = (state ^^^ (state >>> 1) ^^^ (state >>> 2) ^^^ (state >>> 7)) &&& 1 // use xor on 'taps' 1, 2 and 7 to get new bit
    state <- (state >>> 1) ||| (newbit <<< 127) // shift state right then set left most bit to the new bit
    



