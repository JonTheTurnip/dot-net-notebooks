#r "nuget: Plotly.NET, 2.0.0-preview.8"
open Plotly.NET 
open Plotly.NET.LayoutObjects
open System.Collections.Generic
open System.Numerics
open System

// a populate our outputs container

let mutable state = (1I <<< 127) ||| 1I // 128 bit state register
let mutable outputs = 0I // store all outputs

for i = 1 to 20_000 do    
    // update register
    let newbit = (state ^^^ (state >>> 1) ^^^ (state >>> 2) ^^^ (state >>> 7)) &&& 1I    
    state <- (state >>> 1) ||| (newbit <<< 127)
    // add register output to our outputs container
    outputs <- ((outputs ||| newbit) <<< 1)


// b generate our coordinates
//   Note we're ignoring the first 1000 bits since
//   given our zero heavy seed it's very zero weighted
//   Ideally need a better seed

let x = List<int>()
let y = List<int>()
let bytes = outputs.ToByteArray()

for i = 1_000 to 2_000 do
    x.Add(BitConverter.ToInt32(bytes,i))
    y.Add(BitConverter.ToInt32(bytes,i + 4))


// c Plot it  
//   Looks like there is still some clustering around the axes
//   even after ignoring the first 1_000 bits, might need to 
//   try a new seed with roughly equal numbers of bit states
//   or cycle through the register more times

let invisibleAxis = LinearAxis.init(Visible = false)

Chart.Point(x,y)
|> Chart.withXAxis invisibleAxis
|> Chart.withYAxis invisibleAxis
|> Chart.withSize(1000.0, 1000.0)
|> Chart.show



