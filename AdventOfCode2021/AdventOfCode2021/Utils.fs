module AdventOfCode2021.FileUtils

open System.IO

let filePath = "../../../../AdventOfCode2021/inputs/"

let internal loadInputFile (fileName : string) (pathPrefix : Option<string>) : seq<string> =
    let readFile path =
        let fileSeq = File.ReadLines path
        Seq.takeWhile (fun line -> line <> null) fileSeq
        
    match (fileName, pathPrefix) with
    | fileName, Some(pathPrefix) -> 
        readFile (pathPrefix + fileName)
    | fileName, None ->
        readFile fileName
