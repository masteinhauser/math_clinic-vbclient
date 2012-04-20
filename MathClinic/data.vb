Public Class data
    Public Class QuestionsList
        Public Property err As String
        Public Property questions As Question()
    End Class

    Public Class Question
        Public Property equation As String
        Public Property level As String
        Public Property type As String
        Public Property _id As String
    End Class

    Public Class QuestionsGenerated
        Public Property message As String
        Public Property total As String
        Public Property count As String
        Public Property questions As String()
    End Class
End Class
