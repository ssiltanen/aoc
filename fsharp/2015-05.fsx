let input = System.IO.File.ReadAllLines "../inputs/2015-05.txt"

input
|> Array.where (fun str ->
    let vowelCount = str |> Seq.where "aeiou".Contains |> Seq.length
    let double = str |> Seq.pairwise |> Seq.exists (fun (a, b) -> a = b)
    let noForbidden = [ "ab"; "cd"; "pq"; "xy" ] |> List.exists str.Contains |> not
    vowelCount >= 3 && double && noForbidden)
|> Array.length
|> printfn "2015-05/1: %i"

input
|> Array.where (fun str ->
    let pairTwice =
        str
        |> Seq.pairwise
        |> Seq.exists (fun (a, b) -> $"{a}{b}" |> str.Split |> Array.length >= 3)

    let repeating =
        str[0 .. str.Length - 3]
        |> Seq.indexed
        |> Seq.exists (fun (i, c) -> c = str[i + 2])

    pairTwice && repeating)
|> Array.length
|> printfn "2015-05/2: %i"
