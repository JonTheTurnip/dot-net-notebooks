let isSquareDiv d n = 
    let dSqr = d * d
    match dSqr with
    | _ when n = dSqr -> true
    | _ -> false

let isSquareDiv 5 25


// Note on recursion 

// Generating a factorial number is a great example of a "naive" algorithm that's mathematically pure but inefficient in practice.
// For a more computaionally efficient approach we can refactor to use tail recursion

let x = 1

// 1 (naive)

let rec factorialNaive n = 
    match n with
    | 0 | 1 -> 1
    | _ -> n * factorialNaive (n - 1)


// 2 tail recursive (will be compiled into a loop)

// The reason why this is tail-recursive is because the recursive call does not need to save any values on the call stack. 
// All intermediate values being calculated are accumulated via inputs to the inner function. 
// This also allows the F# compiler to optimize the code to be just as fast as if you had written something like a while loop.
// It's common to write F# code that recursively processes something with an inner and outer function, 
// as the previous example shows. The inner function uses tail recursion, while the outer function has a better interface for callers.

let factorialTail n =
    let rec loop i acc =
        match i with    
        | 0 | 1 -> acc
        | _ -> loop (i - 1)  (acc * i)
    loop n 1

// 3 Or better still just use the higher order funcs f# gives you?  Would be interesting to benchmark although won't take long to hit max int

let factorialFold n =
    [1..n] |> List.fold (*) 1

factorialFold 5
