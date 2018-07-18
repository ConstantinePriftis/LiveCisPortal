Namespace LiveCisPortal
    Public Class SideNavClass
        Private _type As String
        Public Property Type() As String
            Get
                Return _type
            End Get
            Set(ByVal value As String)
                _type = value
            End Set
        End Property
        Private _code As String
        Public Property Code() As String
            Get
                Return _code
            End Get
            Set(ByVal value As String)
                _code = value
            End Set
        End Property
        Private _descr As String
        Public Property Descr() As String
            Get
                Return _descr
            End Get
            Set(ByVal value As String)
                _descr = value
            End Set
        End Property
        Private _url As String
        Public Property Url() As String
            Get
                Return _url
            End Get
            Set(ByVal value As String)
                _url = value
            End Set
        End Property
        'Sub New()
        '    Type = ""
        '    Code = ""
        '    Descr = ""
        '    Url = ""
        'End Sub
    End Class


End Namespace
