select
PersonMoves.ΚωδΣυναλ  ,
PersonMoves.Συναλασσομενος  ,
PersonMoves.Παραστατικο  ,
PersonMoves.Τυπος  ,
PersonMoves.Ημνια  ,
PersonMoves.ΣυνΑξια  ,
PersonMoves.Χρεωση  ,
PersonMoves.Πιστωση  ,
PersonMoves.ΠρΥπολ ,
Person.PersonType Τύπος_Συναλασσομενου,
Person.Name Επωνυμία,
Person.AFM ΑΦΜ,
Person.doy ΔΟΥ,
Person.email Email,
Person.Speaker Συνομιλητής,
Person.Cmpt Τυπος_Εταιρίας,
Person.Eaddress ΔιευθυνσηΕδρας,
Person.ECity Πόλη_Εδρας,
Person.EFAX Φαξ_Εδρας,
Person.EPhone Τηλ_Εδρας,
Person.EPhone2 Τηλ2_Εδρας,
Person.Paytype Τυπος_πληρομης,
PersonMoves.aa ΑΑΚΙΝ,
'' Απο_Ημνια,
'' Εώς_Ημνια
from  PersonMoves
inner join Person on Person.Code = PersonMoves.ΚωδΣυναλ

order by PersonMoves.ΚωδΣυναλ,PersonMoves.Ημνια,PersonMoves.Χρεωση
