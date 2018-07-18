Public Class Person

    Private _aa As String
    Public Property AA() As String
        Get
            Return _aa
        End Get
        Set(ByVal value As String)
            _aa = value
        End Set
    End Property

    Private _personType As String
    Public Property PersonType() As String
        Get
            Return _personType
        End Get
        Set(ByVal value As String)
            _personType = value
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
    Private _name As String
    Public Property Name() As String
        Get
            Return _name
        End Get
        Set(ByVal value As String)
            _name = value
        End Set
    End Property
    Private _afm As String
    Public Property AFM() As String
        Get
            Return _afm
        End Get
        Set(ByVal value As String)
            _afm = value
        End Set
    End Property
    Private _webPass As String
    Public Property WebPPass() As String
        Get
            Return _webPass
        End Get
        Set(ByVal value As String)
            _webPass = value
        End Set
    End Property
    Private _cmpt As String
    Public Property Cmpt() As String
        Get
            Return _cmpt
        End Get
        Set(ByVal value As String)
            _cmpt = value
        End Set
    End Property
    Private _eAddress As String
    Public Property Eaddress() As String
        Get
            Return _eAddress
        End Get
        Set(ByVal value As String)
            _eAddress = value
        End Set
    End Property
    Private _eCity As String
    Public Property Ecity() As String
        Get
            Return _eCity
        End Get
        Set(ByVal value As String)
            _eCity = value
        End Set
    End Property
    Private _email As String
    Public Property Email() As String
        Get
            Return _email
        End Get
        Set(ByVal value As String)
            _email = value
        End Set
    End Property
End Class
