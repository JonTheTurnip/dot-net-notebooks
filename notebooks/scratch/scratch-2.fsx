let isSquareDiv d n = 
    let dSqr = d * d
    match dSqr with
    | _ when n = dSqr -> true
    | _ -> false

let isSquareDiv 5 25