let input = System.IO.File.ReadAllText "../inputs/2015-04.txt"

let md5 = System.Security.Cryptography.MD5.Create()

let f (prefix: string) key =
    Seq.initInfinite ((+) 1)
    |> Seq.takeWhile (fun i ->
        let hash =
            System.Text.Encoding.UTF8.GetBytes $"{key}{i}"
            |> md5.ComputeHash
            |> System.Convert.ToHexString

        hash.StartsWith prefix |> not)
    |> Seq.length
    |> (+) 1

input |> f "00000" |> printfn "2015-04/1: %i"
input |> f "000000" |> printfn "2015-04/2: %i"
