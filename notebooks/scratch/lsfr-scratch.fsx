
// Random Numbers with LFSR (Linear Feedback Shift Register) - Computerphile

// open System.Convert // why does this  not work?

// See the python script of same name, converted the python to f# for fun
// https://www.youtube.com/watch?v=Ks1pw1X22y4

// 0. Binary fundamentals

let printBinaryn (binary: int) (n: int) = printfn "%s" (System.Convert.ToString(binary,2).PadLeft(n,'0'))
printBinaryn 0b1001 4
printBinaryn (0b1001 ||| 1) 4

1 ||| 0
1 ||| 1
0 ||| 1
0 ||| 0

0 &&& 0
0 &&& 1

1 &&& 1
0 &&& 1


// 1. Simple 4 bit register

let printBinary (binary: int) = printfn "%s" (System.Convert.ToString(binary,2).PadLeft(4,'0'))

let mutable state = 0b1001
for i = 1 to 20 do
    //printBinary state
    printf "%i" (state &&& 1)
    let newbit = (state ^^^ (state >>> 1)) &&& 1
    state <- (state >>> 1) ||| (newbit <<< 3) // or ing the left most *zero* bit to set it to the new bit
    

// 2.Now do a 128 bit register 

// This doesn't work like python because in python ints are of arbritary length by default), I've updated the above code to
// use the .net biginteger, which is conveniently accessible using the 'I' postfix

// If we use 'taps' 1,2 and 7 then we get the maxmium number of combinations, i.e 2 ^ 128 - 1, this can be mathematically
// proven, will look into that another time?

let mutable state = (1I <<< 127) ||| 1I // create 128 bits where first bit is one (non zero) and last bit is zero
//while true do
for i = 1 to 1000 do
    printf "%s" ((state &&& 1I).ToString())  
    //printfn "%s"  (state.ToString())
    let newbit = (state ^^^ (state >>> 1) ^^^ (state >>> 2) ^^^ (state >>> 7)) &&& 1I // use xor on 'taps' 1, 2 and 7 to get new bit
    state <- (state >>> 1) ||| (newbit <<< 127) // shift state right then set left most bit to the new bit
    

// 3. Howabout a recursive function for the above for fun?

// a. infinite
let rec lsfr128 state: System.Numerics.BigInteger =
    printf "%s" ((state &&& 1I).ToString())        
    let newbit = (state ^^^ (state >>> 1) ^^^ (state >>> 2) ^^^ (state >>> 7)) &&& 1I
    lsfr128 ((state >>> 1) ||| (newbit <<< 127))

lsfr128 ((1I <<< 127) ||| 1I)

//b. bounded

let transform state: System.Numerics.BigInteger = 
        let newbit = (state ^^^ (state >>> 1) ^^^ (state >>> 2) ^^^ (state >>> 7)) &&& 1I
        ((state >>> 1) ||| (newbit <<< 127))

let lsfrBounded (maxi: int) (initialState: System.Numerics.BigInteger) =    
    let rec lsfrBounded' (state: System.Numerics.BigInteger) (i: int) = 
        printf "%s" ((state &&& 1I).ToString())
        match i with        
        | i when i < maxi -> lsfrBounded' (transform state) (i + 1)
        | _ -> ()
    lsfrBounded' initialState 1


lsfrBounded 10000 ((1I <<< 127) ||| 1I)

        
    