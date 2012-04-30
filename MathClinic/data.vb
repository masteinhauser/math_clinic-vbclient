Public Class data
    Public Property QuestionDictionary As Dictionary(Of Question, String()) = New Dictionary(Of Question, String())
    Public Property AnswerDictionary As Dictionary(Of Question, Answer()) = New Dictionary(Of Question, Answer())

    Public Class QuestionsList
        Public Property err As String
        Public Property questions As Question()
    End Class

    Public Class Question
        Public Property equation As String
        Public Property level As String
        Public Property type As String
        Public Property _id As String

        Public Sub New()
            Me.equation = String.Empty
            Me.level = String.Empty
            Me.type = String.Empty
            Me._id = String.Empty
        End Sub

        Public Sub New(equation As String, level As String, type As String, _id As String)
            Me.equation = equation
            Me.level = level
            Me.type = type
            Me._id = _id
        End Sub
    End Class

    Public Class QuestionsGenerated
        Public Property message As String
        Public Property total As String
        Public Property count As String
        Public Property questions As String()
    End Class

    Public Class Answer
        Public Property question As String
        Public Property answer As String
        Public Property latency As Integer
        Public Property correct As Boolean
        Public Property submitted As Boolean
    End Class

    Public Class CreateQuestionResponse
        Public Property success As Boolean
        Public Property err As String
        Public Property question As Question
    End Class
End Class
