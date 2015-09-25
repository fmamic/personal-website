<?php

	function generirajUpit()
	{
		$polje[] = atributPostoji("oib");
		$polje[] = atributiPostoje("kategorija");
		$polje[] = elementPostoji("ime");
		$polje[] = elementPostoji("prezime");
		$polje[] = elementPostoji("drzavljanstvo");
		$polje[] = elementPostoji("interes");
		$polje[] = elementPostoji("stupanjobrazovanja");
		$polje[] = elementPostoji("zanimanje");
		$polje[] = elementiPostoje("mail");
		$polje[] = podelementi("adresa","mjesto");
		$polje[] = podelementi("adresa","ulica");
		$polje[] = podelementi("adresa","drzava");
		$polje[] = podelementi("adresa","kucnibroj");
		$polje[] = podatributi("telefon","tip");
		$polje[] = podpodatribut("telefon", "broj", "pozivnibroj");
		$polje[] = podpodelementi("adresa","mjesto","naziv");
		$polje[] = podpodelementi("adresa","mjesto","postanskibroj");
		
		$polje = izbaciPrazno($polje);
		$upit = spojiUpit($polje);
		return $upit;
	}
	function elementiPostoje($imelementa)
	{
		if(!empty($_REQUEST[$imelementa]))
		{
			foreach($_REQUEST[$imelementa] as $element)
			{
				$napraviupit[] = $imelementa ."='". $element ."'";
			}
			$string = napraviOR($napraviupit);
			return $string;
		}
	}
	
	function podpodelementi($prvi, $drugi, $treci)
	{
		if(!empty($_REQUEST[$treci]))
		{
			$napraviupit = $prvi ."/". $drugi . "[contains(" . $treci . ", '" . $_REQUEST[$treci] . "')]";
			return $napraviupit;
		}
	}
	
	function podatributi($roditelj, $imeatributa)
	{
		if(!empty($_REQUEST[$imeatributa]))
		{
			$string = $roditelj . "[contains(@" . $imeatributa . ",'" . $_REQUEST[$imeatributa] . "')]";
      		return $string;
		}
	}
	
	function podpodatribut($roditelj, $dijete, $imeatributa)
	{
		if(!empty($_REQUEST[$imeatributa]))
		{
			$string = $roditelj . "/" . $dijete . "[contains(@" . $imeatributa . ",'" . $_REQUEST[$imeatributa] . "')]";
      		return $string;
		}
	}
	
	function podelementi($roditelj, $dijete)
	{
		$imeforme = $dijete;
		if(!empty($_REQUEST[$imeforme]))
		{
			$string = $roditelj . "[contains(" . $dijete . ", '" . $_REQUEST[$imeforme] . "')]";
			return $string;
		}
	}
	
	function spojiUpit($polje)
	{
		$upit = implode(" and ", $polje);
		
		if (empty($upit))
    	  return "/telefonskiimenik/osoba";

    	$upit = "/telefonskiimenik/osoba[" . $upit . "]";
    	return $upit;
	}
	
	function atributiPostoje($imeatributa)
	{
		if (!empty($_REQUEST[$imeatributa]))
    	{
      		foreach ($_REQUEST[$imeatributa] as $atribut)
      		{
        		$napraviupit[] = "@" . $imeatributa . "='" . $atribut . "'";
      		}
			$string = napraviOR($napraviupit);
      		return $string;
    	}
      	return "";
	}
	
	function izbaciPrazno($polje)
	{
		$npolje = array();
		$string = "";
		$nula = 0;
		
    	while(list($kljuc, $vrijednost) = each($polje))
    	{
      	if (is_array($vrijednost))
      	{
        	$vrijednost = izbaciPrazno($vrijednost);
        	if (count($vrijednost)!= $nula)
        	{
          	$npolje[$kljuc] = $vrijednost;
        	}
      	}
      	else
      	{
        	if (trim($vrijednost) != $string)
        	{
          	$npolje[$kljuc] = $vrijednost;
        	}
      	}
    	}
    	unset($polje);
    	return $npolje;
	}
	
	function atributPostoji($imeatributa)
	{
		$nista = "";
		if(!empty($_REQUEST[$imeatributa]))
		{
			$string = "contains(@" . $imeatributa . ",'" . $_REQUEST[$imeatributa] . "')";
      		return $string;
		}
    	return $nista;
	}
	
	function elementPostoji($imeelementa)
	{
		$nista = "";
		if(!empty($_REQUEST[$imeelementa]))
		{
			$string = "contains(" . $imeelementa . ",'" . $_REQUEST[$imeelementa] . "')";
      		return $string;
		}
    	return $nista;
	}
	
	function dohvatiVrijednostElementa($cvor, $imeElementa)
  	{
		$string = $cvor->getElementsByTagName($imeElementa)->item(0);
   	 	return $string;
  	}
	
	function atributJednak($imeAtributa)
	{
		$nista = "";
		if(!empty($_REQUEST[$imeAtributa]))
		{
			$string = "@" . $imeAtributa . "='" . $_REQUEST[$imeAtributa] . "'";
      		return $string;
		}
    	return $nista;
	}
	
	function napraviOR($string)
	{
		return "(". implode(" or ", $string) .")";
	}