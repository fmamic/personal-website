Datoteke ad.txt , obeveze.txt i prijave.txt su datoteke kojima se NE SMIJE mjenjati ime . 

Datoteku ad.txt ne moramo mijenjati njezinim otvaranjem , nego pokrenemo program i idemo
na REGISTER i tamo mo�emo onda dodavati asistente i demose . Korisnik ne mora brinuti o 
rasporedu , razmaku i koji se znakovi smiju i ne smiju koristiti . 

Datoteka obeveze.txt sadr�e obaveze i u nju moramo upisivati ru�no , tj. ne mo�emo preko 
programa . Oblik obaveze mora biti sljede�i : 

NAZIVobaveze;IDobaveze;ROKobaveze;IDtermina1;trajanjetermina1;brojAsistenata;brojDemosa;BrojZajedno;Po�etakTermina;KrajTermina;IDtermina2;...

UPOZORENJE ! 
Obaveze ne smiju sadr�avati znak ";" u imenu ili bilo gdje drugo osim izme�u razli�itih podataka npr naziv;IDobaveze;..
NAZIVobaveze smije sadr�avati sva slova i znakove osim ";"
IDobaveze mo�e sadr�avati sva slova i obaveze osim ";"
ROKobaveze mora biti u sljede�em formatu i ISKLJU�IVO tako napisan , nikako druga�ije : DD.MM.GGGG.-HH:mm npr. 04.01.2012.-05:00
mora imati crticu izme�u , ne smije biti praznina , i mora imati 2 znamenke , zna�i ne smije biti 4.1.2012. nego MORA biti 04.01.2012
isto tako i za sate ne smije biti 5:00 nego 05:00 , i mora se obavezno napisati :00 . Program se ru�i ako se ne prid�ava napisanog.
IDtermina mo�e sadr�avati sva slova i obaveze osim ";"
trajanje mo�e biti bilo koje , ali treba biti smisleno , ne stavljati 1000 ili 2000 minuta , program ce raditi ali nema smisla :)

POGLEDATI NAPOMENU ISPOD ZA SLJEDE�A TRI
BrojAsistenata mora tako�er biti smislen i u skladu sa ostalim brojevima asistenata i demosa . 
BrojDemosa isto kao gore
BrojZajedno tako�er
NAPOMENA ! ! ! ! ! ! ! ---> Za BrojAsistenta BrojDemosa BrojZajedno ako se �eli staviti NULA onda ide znak "-" minusa u protivnom program NE�E raditi

Po�etaktermina i kraj termina mora biti u formatu HH:mm zna�i �etiri znamenke i izme�u dvoto�je !
Za ove brojeve tako�er VRIJEDI NAPOMENA kao za brojAsistenta ..

JO� JEDNA VA�NA NAPOMENA ! 
NA KRAJU SVAKE DATOTEKE NE SMIJE BITI OSTAVLJEN PRAZAN RED , ZNA�I NAKON ZADNJEG REDKA , TJ STRINGA �IJA JE DULJINA VECA OD NULA
NE SMIJE BITI \n tj DA OVAJ BLINKA NA PRAZNOM REDKU ISPOD !

Ako �elimo testirati Automatsku dodjelu termina promjenimo ROK obaveze na prije dana�njeg dana :
Zna�i za datum npr. 15.02.2012.-08:00 promjenimo u 15.02.2011.-08:00 i ponovno pokrenemo program !


