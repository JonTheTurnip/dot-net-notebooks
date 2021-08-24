

// mobius

// For any positive integer n, define μ(n) as the sum of the primitive nth roots of unity.
// It has values in {−1, 0, 1} depending on the factorization of n into prime factors:

// μ(n) = 1 if n is a square-free positive integer with an even number of prime factors.
// μ(n) = −1 if n is a square-free positive integer with an odd number of prime factors.
// μ(n) = 0 if n has a squared prime factor.

// For a given number n, want to know all prime factors

// a. Has a square prime factor => 0
// b. Has odd number of prime factors => -1
// c. Has even number of prime factors

// 1. Simple recursive function to test for prime (not fully tested)

let isPrime n =
    match n with
    | 1 -> true
    | _ -> 
        let maxDiv = n / 2
        let rec isPrime' d =
            if d > maxDiv then true
            elif n % d = 0 then false
            else isPrime' (d + 1)
        isPrime' 2

[1..15] |> List.map (fun x -> (x, isPrime x))


// 2. Simple and ineffecient function to get all divisors of a number

let getDivisors n = 
    [1..n] 
    |> List.map (fun d -> (d, n % d)) 
    |> List.filter (fun (d, r) -> r = 0)
    |> List.map (fun (d, r) -> d)

getDivisors 8

// 3. Simple func to test if a divisor is a square

let isSquareDivisor d n = 
    let dSqr = d * d
    match dSqr with
    | _ when n = dSqr -> true // TODO: how to match on the actual value?
    | _ -> false

isSquareDivisor 5 25
isSquareDivisor 3 25

// 4. Is even 
let isEven n = n % 2 = 0

// 5. Now combine all funcs to get our mobius

let mobius n =
    let divisors = getDivisors n
    let primeDivisors = divisors |> List.filter isPrime
    let squareExists = primeDivisors |> List.exists (isSquareDivisor n) 
    if squareExists then 0
    elif isEven primeDivisors.Length then 1
    else -1 
    




////////////////////////////////////////////////////////////////////////////////////


// http://www.fssnip.net/7E/title/Prime-testing
let isPrimeX n =
    match n with
    | _ when n > 3 && (n % 2 = 0 || n % 3 = 0) -> false
    | _ ->
        let maxDiv = int (System.Math.Sqrt(float n)) + 1
        let rec f d i =
            if d > maxDiv then true
            else if n % d = 0 then false
            else f (d + i) (6 - i)
        f 5 2

isPrimeX 1

     

