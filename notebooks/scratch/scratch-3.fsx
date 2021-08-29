
#r "nuget: Plotly.NET, 2.0.0-preview.7"
#r "nuget: Plotly.NET.Interactive, 2.0.0-preview.7"

open Plotly.NET

let x  = [1.; 2.; 3.; 4.; 5.; 6.; 7.; 8.; 9.; 10.; ]
let y = [2.; 1.5; 5.; 1.5; 3.; 2.5; 2.5; 1.5; 3.5; 1.]

let line1 =
    Chart.Line(
        x,y,
        Name="line",
        ShowMarkers=false,
        MarkerSymbol=StyleParam.Symbol.Square)    
    |> Chart.withLineStyle(Width=1.,Dash=StyleParam.DrawingStyle.Solid)

line1 |> Chart.show