module AdventOfCode2021.Test

open NUnit.Framework

[<Test>]
let Day1P1_Answer_Correct () =
    Assert.That(Day1.P1.run(), Is.EqualTo(1451), "Day1P1 - answer matches site answer")
    
[<Test>]
let Day1P2_Answer_Correct () =
    Assert.That(Day1.P2.run(), Is.EqualTo(0))
    