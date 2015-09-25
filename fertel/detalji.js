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