
open System.Numerics

// Let's set up a diffe hellman key exchange, example from wikipedia
let p = 23I // prime modulus
let g = 5I // generator

let a = 4 // alice secret key
let b = 3 // bob secret key

// two ways to calc same thing
let A = (pown g a) % p // 4
let AA = BigInteger.ModPow(g, BigInteger(a), p) // 4

let B = (pown g b) % p

// compute shared key (should be the same!)
// now they have a shared key that no one else knows so they could 
// use aes or something in conjunction with their shared key to encrypt
// and decrypt messages to each other
let shared1 = (pown B a) % p
let shared2 = (pown A b) % p

// let's see if we can brute force crack it!
// I know A, B, g and p

// calculate all possible a's ( 1 <= a < p)

let residues = [1I..(p-1I)] |> List.map(fun x -> (int(x), int(BigInteger.ModPow(g, x, p))))

let (alicesSecret, _) = residues |> List.find(fun (secret, modpow) -> modpow = int(A))
let (bobsSecret, _) = residues |> List.find(fun (secret, modpow) -> modpow = int(B))

// check
a = alicesSecret
b = bobsSecret



