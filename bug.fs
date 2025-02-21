let mutable x = 0
let inc x = x <- x + 1
inc x
printf "%d" x //This will print 1 as expected

let mutable y = {a = 0; b = 0}
let inc_struct y = y.a <- y.a + 1
inc_struct y
printf "%A" y //This will print {a = 1; b = 0}. This seems correct.

let mutable z = [0]
let add_to_list z = z <- 1::z
add_to_list z
printf "%A" z //This will print [1; 0] as expected.

let rec changeList list = 
    match list with
    | [] -> []
    | head::tail -> (head + 1) :: (changeList tail)

let mutable myList = [1; 2; 3]
myList <- changeList myList //myList is changed to [2;3;4]
printf "%A" myList  //prints [2;3;4]

//However, the following code does not work as expected. 
let changeListInPlace list = 
    let rec changeListHelper list = 
        match list with
        | [] -> []
        | head::tail -> (head + 1):: (changeListHelper tail)
    list <- changeListHelper list //ERROR: This line causes an error. 

let mutable myList2 = [1; 2; 3]
changeListInPlace myList2
printf "%A" myList2 //This line will cause an error.