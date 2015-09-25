Datoteke ad.txt , obeveze.txt i prijave.txt su datoteke kojima se NE SMIJE mjenjati ime . 

Datoteku ad.txt ne moramo mijenjati njezinim otvaranjem , nego pokrenemo program i idemo
na REGISTER i tamo možemo onda dodavati asistente i demose . Korisnik ne mora brinuti o 
rasporedu , razmaku i koji se znakovi smiju i ne smiju koristiti . 

Datoteka obeveze.txt sadrže obaveze i u nju moramo upisivati ruèno , tj. ne možemo preko 
programa . Oblik obaveze mora biti sljedeæi : 

NAZIVobaveze;IDobaveze;ROKobaveze;IDtermina1;trajanjetermina1;brojAsistenata;brojDemosa;BrojZajedno;PoèetakTermina;KrajTermina;IDtermina2;...

UPOZORENJE ! 
Obaveze ne smiju sadržavati znak ";" u imenu ili bilo gdje drugo osim izmeðu razlièitih podataka npr naziv;IDobaveze;..
NAZIVobaveze smije sadržavati sva slova i znakove osim ";"
IDobaveze može sadržavati sva slova i obaveze osim ";"
ROKobaveze mora biti u sljedeæem formatu i ISKLJUÈIVO tako napisan , nikako drugaèije : DD.MM.GGGG.-HH:mm npr. 04.01.2012.-05:00
mora imati crticu izmeðu , ne smije biti praznina , i mora imati 2 znamenke , znaèi ne smije biti 4.1.2012. nego MORA biti 04.01.2012
isto tako i za sate ne smije biti 5:00 nego 05:00 , i mora se obavezno napisati :00 . Program se ruši ako se ne pridžava napisanog.
IDtermina može sadržavati sva slova i obaveze osim ";"
trajanje može biti bilo koje , ali treba biti smisleno , ne stavljati 1000 ili 2000 minuta , program ce raditi ali nema smisla :)

POGLEDATI NAPOMENU ISPOD ZA SLJEDEÆA TRI
BrojAsistenata mora takoðer biti smislen i u skladu sa ostalim brojevima asistenata i demosa . 
BrojDemosa isto kao gore
BrojZajedno takoðer
NAPOMENA ! ! ! ! ! ! ! ---> Za BrojAsistenta BrojDemosa BrojZajedno ako se želi staviti NULA onda ide znak "-" minusa u protivnom program NEÆE raditi

Poèetaktermina i kraj termina mora biti u formatu HH:mm znaèi èetiri znamenke i izmeðu dvotoèje !
Za ove brojeve takoðer VRIJEDI NAPOMENA kao za brojAsistenta ..

JOŠ JEDNA VAŽNA NAPOMENA ! 
NA KRAJU SVAKE DATOTEKE NE SMIJE BITI OSTAVLJEN PRAZAN RED , ZNAÈI NAKON ZADNJEG REDKA , TJ STRINGA ÈIJA JE DULJINA VECA OD NULA
NE SMIJE BITI \n tj DA OVAJ BLINKA NA PRAZNOM REDKU ISPOD !

Ako želimo testirati Automatsku dodjelu termina promjenimo ROK obaveze na prije današnjeg dana :
Znaèi za datum npr. 15.02.2012.-08:00 promjenimo u 15.02.2011.-08:00 i ponovno pokrenemo program !


