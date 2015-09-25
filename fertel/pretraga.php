<?php
	include("funkcije.php");

	error_reporting (E_ALL);
	
	$a= file_get_contents ("http://localhost:8080/Lab5OR/servlet");
	$dom = new DOMDocument();	
	$dom->loadXML($a);
	
	$xp = new DOMXPath($dom);
	
	$upit = generirajUpit();
	$rezultat = $xp->query($upit);
	
?>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html>
      <head>
        <link rel="stylesheet" type="text/css" href="dizajn.css" />
     	<link href='http://fonts.googleapis.com/css?family=Voces&amp;subset=latin,latin-ext' rel='stylesheet' type='text/css'>
		<link href='http://fonts.googleapis.com/css?family=Crafty+Girls|Shadows+Into+Light+Two&amp;subset=latin,latin-ext' rel='stylesheet' type='text/css'>
		<link href='http://fonts.googleapis.com/css?family=Gudea&amp;subset=latin,latin-ext' rel='stylesheet' type='text/css'>
        <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
        <script>
    		function loadDetails($oib)
    		{
      			var xhr;
      			if (window.XMLHttpRequest)     // Standard object
      			{
        			xhr = new XMLHttpRequest();     // Firefox, Safari, ...
      			}
      			else if (window.ActiveXObject)   // Internet Explorer 
      			{
        			xhr = new ActiveXObject("Microsoft.XMLHTTP");
      			}
      
      
      			var url = "http://localhost/Lab6/detalji.php?oib=" + $oib;
      			xhr.open("GET", url, true);
      			xhr.send(null);
      			document.getElementById("bodyleft2").innerHTML = '<img id="more" src="spinner.gif" alt="Pričekajte..." />';
      
      			xhr.onreadystatechange = function()
      			{
        			if (xhr.readyState == 4)
        			{
          				if (xhr.status == 200)
          				{
            				document.getElementById("bodyleft2").innerHTML = xhr.responseText;
          				}
        			}
      			};
    		}
    </script>
        <title>FERtel - Početna</title>
       </head>
       <body>
       <script type="text/javascript" src="wz_tooltip.js"></script>
        <div id="header1">
          <div id="header2">
            <a href="index.html">
              <img src="Slike/header.jpg" alt="header" />
            </a>
          </div>
        </div>
        <div id="wrapper">
        <div id="wrapper2">
          <div id="bodyleft">
            <ul id="navigacija">
              <li class="prva">
                <a id="but1" href="index.html" >Naslovnica</a>
              </li>
              <li class="prva">
                <a id="but2" href="podaci.xml">Podaci</a>
              </li>
              <li class="prva">
                <a id="but3" href="obrazac.html">Pretraživanje</a>
              </li>
              <li class="prva">
                <a id="but4" href="http://www.rasip.fer.hr">RASIP</a>
              </li>
              <li class="prva">
                <a id="but5" href="http://www.fer.unizg.hr" target="_blank">FER</a>
              </li>
              <li class="prva">
                <a id="but12" href="mailto:filip.mamic@fer.hr">Autor</a>
              </li>
            </ul>
          </div>
          <div id="bodyleft2">
          </div>
         </div> 
          <div id="bodyright2">
            <div id="podnaslov">
              <h1 id="naslov">Pretraživanje - Rezultati</h1>
            </div>
            <div id="slika2">
              <img src="Slike/search.png" alt="telefon"/>
            </div>
            <div id="sadrzaj1">
              <table id="tablica3" onmouseover="tool">
                <tr height="100">
                  <th width="100">Ime</th>
                  <th width="100">Prezime</th>
                  <th class="th3" width="300">Mjesto</th>
                  <th width="150">Telefon</th>
                  <th width="130">Detalji</th>
                </tr>
                <?php 
					foreach($rezultat as $element)
					{
					?>
                  <tr height="100" onmouseover="Tip('<b>Ime:</b>  <br />  <?php echo dohvatiVrijednostElementa($element, 'ime')->nodeValue; ?> <br /> <br /> <b>Prezime:</b> <br /> <?php echo dohvatiVrijednostElementa($element, 'prezime')->nodeValue; ?> ', SHADOW, true, BGCOLOR, 'silver', FONTSIZE, '11pt', FONTFACE, 'Arial, Helvetica, sans-serif')" onmouseout="UnTip()">
                    <td width="200">
                      <?php 
					  	echo dohvatiVrijednostElementa($element, 'ime')->nodeValue;
						?>
                    </td>
                    <td>
                      <?php
					  	echo dohvatiVrijednostElementa($element, 'prezime')->nodeValue;
						?>
                    </td>
                    <td align="center">
                      <?php 
					  	foreach($element->getElementsByTagName('adresa') as $adresa)
						{
							//echo dohvatiVrijednostElementa($adresa, 'ulica')->nodeValue;
							//echo " ";
							//echo dohvatiVrijednostElementa($adresa, 'kucnibroj')->nodeValue;
							//echo "<br />";
							foreach($adresa->getElementsByTagName('mjesto') as $mjesto)
							{
								echo dohvatiVrijednostElementa($mjesto, 'naziv')->nodeValue;
								//echo " ";
								//echo dohvatiVrijednostElementa($mjesto, 'postanskibroj')->nodeValue;
							}
							//echo "<br />";
							//echo dohvatiVrijednostElementa($adresa, 'drzava')->nodeValue;
						}
						?>
                    </td>
                    <td width="300">
                      <?php
					  	foreach($element->getElementsByTagName('telefon') as $telefon)
						{
							//echo $telefon->getAttribute('tip');
							echo "<br />";
							$string = $telefon->getElementsByTagName('broj')->item(0);
							echo $string->getAttribute('pozivnibroj');
							echo "/";
							echo dohvatiVrijednostElementa($telefon, 'broj')->nodeValue;
						}
						?>
                    </td>
                    <td>
						<?php
							foreach($element->getElementsByTagName('mail') as $mail)
							{
								if(!empty($mail))
								{
									//echo dohvatiVrijednostElementa($element, 'mail')->nodeValue;
								}
							}
						?>
                        <a href="#"  onclick="loadDetails('<?php echo $element->getAttribute('oib'); ?>'); return false"><img src="Slike/more.png" /></a>
                    </td>
                  </tr>
                  <?php
					}
					?>
              </table>
            </div>

          </div>
          <div id="footer">
            <div id="footer1">
              <p id="plinkovi">
                Linkovi
              </p>
              <p id="listalinkovi">
                <ul>
                  <li class="lista2">
                    <a id="but6" href="http://www.google.com">Google </a>
                  </li>
                  <li class="lista2">
                    <a id="but7" href="http://www.bing.com"> Bing </a>
                  </li>
                  <li class="lista2">
                    <a id="but8" href="http://www.fer2.net"> Fer2.net </a>
                  </li>
                </ul>
              </p>
            </div>
            <div id="footer2">
              <p id="autor">
                Autor
              </p>
              <p id="ime">
                Filip Mamić
              </p>
            </div>
            <div id="footer3">
              <p id="fbtekst">
                Facebook Twitter Linkedin
              </p>
              <p id="face">
                <a id="facebook" href="http://www.facebook.com"></a>
              </p>
              <p id="tvit">
                <a id="twitter" href="http://www.twitter.com"></a>
              </p>
              <p id="link">
                <a id="linkedin" href="http://www.linkedin.com"></a>
              </p>
            </div>
          </div>
        </div>
      </body>
</html>