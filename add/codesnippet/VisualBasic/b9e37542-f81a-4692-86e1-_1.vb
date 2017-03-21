        ' The following example requires that Option Infer be set to On.

        ' Define the message you want to see inside the message box.
        Dim msg = "Do you want to continue?"

        ' Display a simple message box.
        MsgBox(msg)

        ' Define a title for the message box.
        Dim title = "MsgBox Demonstration"

        ' Add the title to the display.
        MsgBox(msg, , title)

        ' Now define a style for the message box. In this example, the
        ' message box will have Yes and No buttons, the default will be
        ' the No button, and a Critical Message icon will be present.
        Dim style = MsgBoxStyle.YesNo Or MsgBoxStyle.DefaultButton2 Or
                    MsgBoxStyle.Critical

        ' Display the message box and save the response, Yes or No.
        Dim response = MsgBox(msg, style, title)

        ' Take some action based on the response.
        If response = MsgBoxResult.Yes Then
            MsgBox("YES, continue!!", , title)
        Else
            MsgBox("NO, stop!!", , title)
        End If