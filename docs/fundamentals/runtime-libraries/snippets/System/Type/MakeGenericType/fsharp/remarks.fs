module remarks
// <Snippet1>
type Base<'T, 'U>() = class end
type Derived<'V>() = inherit Base<int, 'V>()
// </Snippet1>
