
let compose4curried =
    fun op1 ->
        fun op2 ->
            fun n -> op1 (op2 n)