let input = System.IO.File.ReadAllLines "../inputs/2015-06.txt"

let lights1 = Array2D.create 1000 1000 false
let lights2 = Array2D.create 1000 1000 0

let getCoords (row: string) =
    let numbers =
        row.Split(
            [| "turn"; "on"; "off"; "toggle"; "through"; " "; "," |],
            System.StringSplitOptions.RemoveEmptyEntries
        )
        |> Array.map int

    [ numbers[0] .. numbers[2] ]
    |> List.collect (fun x -> [ numbers[1] .. numbers[3] ] |> List.map (fun y -> x, y))

input
|> Array.iter (fun row ->
    let coords = getCoords row

    if row.StartsWith "toggle" then
        coords
        |> List.iter (fun (x, y) -> Array2D.get lights1 x y |> not |> Array2D.set lights1 x y)
    else
        let onOrOff = if row.StartsWith "turn on" then true else false
        coords |> List.iter (fun (x, y) -> Array2D.set lights1 x y onOrOff))

seq {
    for light in lights1 do
        yield unbox light
}
|> Seq.filter id
|> Seq.length
|> printfn "2015-06/1: %i"

input
|> Array.iter (fun row ->
    let adjustment =
        if row.StartsWith "turn on" then 1
        elif row.StartsWith "turn off" then -1
        else 2

    getCoords row
    |> List.iter (fun (x, y) ->
        System.Math.Max(0, Array2D.get lights2 x y + adjustment)
        |> Array2D.set lights2 x y))

seq {
    for light in lights2 do
        yield unbox light
}
|> Seq.sum
|> printfn "2015-06/2: %i"
