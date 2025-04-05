let input = System.IO.File.ReadAllText "../inputs/2015-01.txt"

input
|> Seq.sumBy (fun c -> if c = '(' then 1 else -1)
|> printfn "2015-01/1: %i"

input
|> Seq.scan (fun floor c -> if c = '(' then floor + 1 else floor - 1) 0
|> Seq.takeWhile ((<=) 0)
|> Seq.length
|> printfn "2015-01/2: %i"
