select
PersonMoves.��������  ,
PersonMoves.��������������  ,
PersonMoves.�����������  ,
PersonMoves.�����  ,
PersonMoves.�����  ,
PersonMoves.�������  ,
PersonMoves.������  ,
PersonMoves.�������  ,
PersonMoves.������ ,
Person.PersonType �����_��������������,
Person.Name ��������,
Person.AFM ���,
Person.doy ���,
Person.email Email,
Person.Speaker �����������,
Person.Cmpt �����_��������,
Person.Eaddress ��������������,
Person.ECity ����_�����,
Person.EFAX ���_�����,
Person.EPhone ���_�����,
Person.EPhone2 ���2_�����,
Person.Paytype �����_��������,
PersonMoves.aa �����,
'' ���_�����,
'' ���_�����
from  PersonMoves
inner join Person on Person.Code = PersonMoves.��������

order by PersonMoves.��������,PersonMoves.�����,PersonMoves.������
