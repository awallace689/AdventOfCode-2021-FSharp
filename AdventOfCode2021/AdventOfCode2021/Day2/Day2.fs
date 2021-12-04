module AdventOfCode2021.Day2

module P1 =
    type internal Pos = {
        x: int
        ;y: int
    }
    
    type internal CommandText = string * string
    
    type internal Command =
        Forward of int
        | Up of int
        | Down of int
    
    let internal parseCommand (pair:CommandText): Command =
        match pair with
        | (cmdStr, nStr) ->
            let n = int nStr
            match cmdStr with
            | "forward" -> Forward(n)
            | "up" -> Up(n)
            | "down" -> Down(n)
            | _ -> failwith $"Bad input line: {pair}"
            
    // learn about Active Patterns
    let internal parseLine (cmdParser:CommandText -> Command) (line:string): Command =
        let splitLine: string list = line.Split ' ' |> Array.toList
        match splitLine with
        | cmd::[n] -> parseCommand (cmd, n)
        | _ -> failwith $"Bad input line: {line}"
        
    let internal applyCommand (pos:Pos) (cmd:Command): Pos =
        match cmd with
        | Forward(n) -> {pos with x = pos.x + n}
        | Up(n) -> {pos with y = pos.y - n}
        | Down(n) -> {pos with y = pos.y + n}
        
    let internal reducePos (pos:Pos): int = pos.x * pos.y
        
    let run () = 
        FileUtils.loadInputFile "Day2P1.txt" (Some FileUtils.filePath)
        |> Seq.map (parseLine parseCommand)
        |> Seq.toList
        |> List.fold applyCommand {x = 0; y = 0}
        |> reducePos
        
        
module P2 =
    type internal Pos2 = {
        x    : int
        ;y   : int
        ;aim : int
    }
    
    let internal applyCommand2 (pos:Pos2) (cmd:P1.Command): Pos2 =
        match cmd with
        | P1.Forward(n) -> {pos with
                                x = pos.x + n
                                ;y = pos.y + (n * pos.aim)}
        | P1.Up(n) -> {pos with aim = pos.aim - n}
        | P1.Down(n) -> {pos with aim = pos.aim + n}
    
    let run () =
        FileUtils.loadInputFile "Day2P1.txt" (Some FileUtils.filePath)
        |> Seq.map (P1.parseLine P1.parseCommand)
        |> Seq.toList
        |> List.fold applyCommand2 {x = 0; y = 0 ; aim = 0}
        |> fun pos2 -> {x = pos2.x; y = pos2.y} : P1.Pos
        |> P1.reducePos
        