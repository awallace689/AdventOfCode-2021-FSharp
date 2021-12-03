module AdventOfCode2021.Day1

module P1 = 
    let internal countIncreases (pairs : (int * int) list) : int =
        let rec countIncreasesInner pairs (acc : int) =
            match pairs with
            | (fst, snd)::xs ->
                if fst < snd
                then countIncreasesInner xs (acc + 1)
                else countIncreasesInner xs acc
            | [] -> acc
            
        countIncreasesInner pairs 0
    
    let run () : int =
        let fileSeq = FileUtils.loadInputFile "Day1P1.txt" (Some FileUtils.filePath)
        Seq.pairwise fileSeq
        |> Seq.map (fun (fst, snd) -> (int fst, int snd))
        |> Seq.toList
        |> countIncreases
    
    
module P2 =
   type internal Window = int * int * int
   
   let rec internal getWindows (lines : string list): Window list=
       match lines with
       | x::y::[z] -> Window(int x, int y, int z)::[]
       | x::y::z::xs -> Window(int x, int y, int z)::getWindows(y::z::xs)
       | _ -> failwith "List must have at least three items"
       
   let run () : int =
       let fileSeq = FileUtils.loadInputFile "Day1P1.txt" (Some FileUtils.filePath)
           
       let solve =
           Seq.toList fileSeq
           |> getWindows
           |> List.map (function | (x, y, z) -> x + y + z)
           |> List.pairwise
           |> P1.countIncreases
           
       solve