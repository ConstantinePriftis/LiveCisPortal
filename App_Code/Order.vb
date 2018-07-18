Public Class Order
    Private _itemCode As String
    Public Property ItemCode() As String
        Get
            Return _itemCode
        End Get
        Set(ByVal value As String)
            _itemCode = value
        End Set
    End Property

    Private _quantity As Decimal
    Public Property Quantity() As Decimal
        Get
            Return _quantity
        End Get
        Set(ByVal value As Decimal)
            _quantity = value
        End Set
    End Property

    Private _price As Decimal
    Public Property Price() As Decimal
        Get
            Return _price
        End Get
        Set(ByVal value As Decimal)
            _price = value
        End Set
    End Property

    Private _aa As Int64
    Public Property AA() As Int64
        Get
            Return _aa
        End Get
        Set(ByVal value As Int64)
            _aa = value
        End Set
    End Property

    Private _ept As Int32
    Public Property Ept() As Int32
        Get
            Return _ept
        End Get
        Set(ByVal value As Int32)
            _ept = value
        End Set
    End Property

    Private _lineCom As String
    Public Property LineCom() As String
        Get
            Return _lineCom
        End Get
        Set(ByVal value As String)
            _lineCom = value
        End Set
    End Property

    Private _altQ1 As Decimal
    Public Property AltQ1() As Decimal
        Get
            Return _altQ1
        End Get
        Set(ByVal value As Decimal)
            _altQ1 = value
        End Set
    End Property

    Private _altQ2 As Decimal
    Public Property AltQ2() As Decimal
        Get
            Return _altQ2
        End Get
        Set(ByVal value As Decimal)
            _altQ2 = value
        End Set
    End Property

    Private _poliths As String
    Public Property Poliths() As String
        Get
            Return _poliths
        End Get
        Set(ByVal value As String)
            _poliths = value
        End Set
    End Property

    Private _ergo As String
    Public Property Ergo() As String
        Get
            Return _ergo
        End Get
        Set(ByVal value As String)
            _ergo = value
        End Set
    End Property

    Private _iULNField1 As Decimal
    Public Property IULNField1() As Decimal
        Get
            Return _iULNField1
        End Get
        Set(ByVal value As Decimal)
            _iULNField1 = value
        End Set
    End Property

    Private _iULTFieldl As Decimal
    Public Property IULTFieldl() As Decimal
        Get
            Return _iULTFieldl
        End Get
        Set(ByVal value As Decimal)
            _iULTFieldl = value
        End Set
    End Property

    Private _iULTFieldl2 As String
    Public Property IULTFieldl2() As String
        Get
            Return _iULTFieldl2
        End Get
        Set(ByVal value As String)
            _iULTFieldl2 = value
        End Set
    End Property

    Private _lUID As String
    Public Property LUID() As String
        Get
            Return _lUID
        End Get
        Set(ByVal value As String)
            _lUID = value
        End Set
    End Property

    Private _matEntCat As String
    Public Property MatEntCat() As String
        Get
            Return _matEntCat
        End Get
        Set(ByVal value As String)
            _matEntCat = value
        End Set
    End Property





End Class
