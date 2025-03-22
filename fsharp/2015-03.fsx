let input = System.IO.File.ReadAllText "../inputs/2015-03.txt"

let move (x, y) arrow =
    if arrow = '>' then x + 1, y
    elif arrow = '<' then x - 1, y
    elif arrow = '^' then x, y + 1
    elif arrow = 'v' then x, y - 1
    else x, y

input |> Seq.scan move (0, 0) |> set |> Set.count |> printfn "2015-03/1: %i"

input
|> Seq.indexed
|> Seq.scan
    (fun (santa, robot) (i, arrow) ->
        if i % 2 = 0 then
            move santa arrow, robot
        else
            santa, move robot arrow)
    ((0, 0), (0, 0))
|> Seq.collect (fun (s, r) -> [ s; r ])
|> set
|> Set.count
|> printfn "2015-03/2: %i"
