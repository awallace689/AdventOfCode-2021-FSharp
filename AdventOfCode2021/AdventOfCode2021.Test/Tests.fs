module AdventOfCode2021.Test

open NUnit.Framework

[<Test>]
let Day1P1_Answer_Correct () =
    Assert.That(
        Day1.P1.run (),
        Is.EqualTo(1451),
        "Day1P1 - correct number of adjacent numbers found in list where fst < snd"
    )

[<Test>]
let Day1P2_Answer_Correct () =
    Assert.That(
        Day1.P2.run (),
        Is.EqualTo(1395),
        "Day1P2 - correct number of increasing, adjacent sums of 3-number slices in list found"
    )
