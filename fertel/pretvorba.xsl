<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
  <xsl:output method="xml" indent="yes" doctype-system="http://www.w3.org/TR/xhtml1/DTD/xhtml1-strict.dtd" doctype-public="- //W3C//DTD XHTML 1.0 Strict//EN" />

  <xsl:template match="/">
    <html xmlns="http://www.w3.org/1999/xhtml">
      <head>
        <link rel="stylesheet" type="text/css" href="dizajn.css" />
        <link href='http://fonts.googleapis.com/css?family=Voces' rel='stylesheet' type='text/css' />
        <link href='http://fonts.googleapis.com/css?family=Crafty+Girls|Shadows+Into+Light+Two' rel='stylesheet' type='text/css' />
        <link href='http://fonts.googleapis.com/css?family=Gudea' rel='stylesheet' type='text/css' />
        <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
        <title>FERtel - Početna</title>
       </head>
       <body>
        <div id="header1">
          <div id="header2">
            <a href="index.html">
              <img src="Slike/header.jpg" alt="header" />
            </a>
          </div>
        </div>
        <div id="wrapper">
          <div id="bodyleft">
            <ul id="navigacija">
              <li class="prva">
                <a id="but1" href="index.html">Naslovnica</a>
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
          <div id="bodyright2">
            <div id="podnaslov">
              <h1 id="naslov">Dostupni podaci</h1>
            </div>
            <div id="slika2">
              <img src="Slike/search.png" alt="telefon"/>
            </div>
            <div id="sadrzaj1">
              <table id="tablica3">
                <tr height="100">
                  <th width="100">Ime</th>
                  <th width="100">Prezime</th>
                  <th width="300">Adresa</th>
                  <th width="150">Telefon</th>
                  <th width="130">Mail</th>
                </tr>
                <xsl:for-each select="/telefonskiimenik/osoba">
                  <tr height="100">
                    <td>
                      <xsl:value-of select="ime"/>
                    </td>
                    <td>
                      <xsl:value-of select="prezime"/>
                    </td>
                    <td>
                      <xsl:value-of select="adresa/ulica"/> - <xsl:value-of select="adresa/kucnibroj"/>
                      <br />
                      <xsl:value-of select="adresa/mjesto/naziv"/> - <xsl:value-of select="adresa/mjesto/postanskibroj"/>
                      <br />
                      <xsl:value-of select="adresa/drzava"/>
                    </td>
                    <td>
                      <xsl:value-of select="telefon/broj/@pozivnibroj" ></xsl:value-of>/<xsl:value-of select="telefon/broj"/>
                    </td>
                    <td>
                      <xsl:if test="string(mail)">
                        <xsl:value-of select="mail"/>
                      </xsl:if>
                    </td>
                  </tr>
                </xsl:for-each>
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
  </xsl:template>
</xsl:stylesheet>