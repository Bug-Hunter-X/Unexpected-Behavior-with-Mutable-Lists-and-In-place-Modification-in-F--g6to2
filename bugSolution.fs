let rec changeListHelper list acc = 
    match list with
    | [] -> List.rev acc
    | head::tail -> changeListHelper tail ((head + 1)::acc)

let changeListInPlace list = 
    list <- changeListHelper list []

let mutable myList2 = [1; 2; 3]
changeListInPlace myList2
printf "%A" myList2 // This will correctly print [2; 3; 4]

//Alternative solution using List.map
let changeListInPlace2 list = 
    list <- List.map (fun x -> x + 1) list

let mutable myList3 = [1;2;3]
changeListInPlace2 myList3
printf "%A" myList3 // This will correctly print [2; 3; 4] 