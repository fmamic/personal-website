<?php
 date_default_timezone_set("America/Los_Angeles");
  include ('funkcije.php');
  
  error_reporting (E_ALL);

  $a = file_get_contents("http://localhost:8080/Lab5OR/servlet");
  $dom = new DOMDocument();
  $dom->loadXML($a);

  $xp = new DOMXPath($dom);

  $upit = generirajUpit();
  $rezultat = $xp->query($upit);
  
  foreach ($rezultat as $element)
  {
	  sleep(2);
    echo '<br />';
	echo '<br />';
    foreach($element->getElementsByTagName('adresa') as $adresa)
						{
							echo dohvatiVrijednostElementa($adresa, 'ulica')->nodeValue. ' ';
							echo dohvatiVrijednostElementa($adresa, 'kucnibroj')->nodeValue . '</br>';
							echo '<br />';
							foreach($adresa->getElementsByTagName('mjesto') as $mjesto)
							{
								echo dohvatiVrijednostElementa($mjesto, 'naziv')->nodeValue . ' ';
								echo dohvatiVrijednostElementa($mjesto, 'postanskibroj')->nodeValue;
							}
							echo '<br />';
							echo '<br />';
							echo dohvatiVrijednostElementa($adresa, 'drzava')->nodeValue . '</br>';
							echo '<br />';
						}
	foreach($element->getElementsByTagName('mail') as $mail)
	{
		if(!empty($mail))
		{
			echo dohvatiVrijednostElementa($element, 'mail')->nodeValue . '</br>';
		}
	}
	echo '<br />';
    echo dohvatiVrijednostElementa($element, 'drzavljanstvo')->nodeValue . '</br>';
	echo '<br />';
    echo dohvatiVrijednostElementa($element, 'zanimanje')->nodeValue;
  }
?>
