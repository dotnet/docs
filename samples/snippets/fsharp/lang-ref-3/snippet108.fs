//let emptyset = Set.empty
// Adding a type parameter and type annotation lets you write a generic value.
let emptyset<'a when 'a : comparison> : Set<'a> = Set.empty