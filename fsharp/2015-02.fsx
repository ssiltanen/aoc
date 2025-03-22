let input =
    System.IO.File.ReadAllLines "../inputs/2015-02.txt"
    |> Array.map ((fun row -> row.Split "x") >> Array.map int)

input
|> Array.sumBy (fun [| l; h; w |] ->
    let side = [ l; h; w ] |> List.sort |> List.take 2 |> List.reduce (*)
    2 * l * w + 2 * w * h + 2 * h * l + side)
|> printfn "2015-02/1: %i"

input
|> Array.sumBy (fun [| l; h; w |] ->
    let wrap = [ l; h; w ] |> List.sort |> List.take 2 |> List.sumBy ((*) 2)
    wrap + l * h * w)
|> printfn "2015-02/2: %i"
