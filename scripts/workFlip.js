// JavaScript Document

function changeText1(){
	var p2 = document.getElementById("paragraf2");
	var p3 = document.getElementById("paragraf3");
	p2.innerHTML = "My first website was FERtel for Open Computing course. It's a dynamic webpage that combines technology both on client and server side.";
	p3.innerHTML = "FERtel is a phonebook whit phone number, adress, name, surname, place of work as data. Data is stored in XML. It has search of data by name or anything. That was implented with PHP. When you get your list of data, you can click on detail and details about that person will be shown. That was implemented with AJAX. Java was used for tranforming basic file into XML.";
	$('#down').html('<a href="fertel/index.html" class="link"><br />Link to page</a>');
	$(".slider-wrapper").html('<img src="slike/loader.gif" />');
	$(".slider-wrapper").html('<div id="slider" class="nivoSlider">\
                    <a href="slike/fertel1.jpg" rel="gallery" class="pirobox_gall" title="fertel">\
    					<img id="slika1" class="slika" src="slike/fertel1.jpg"  />\
					</a>\
        			<a href="slike/fertel2.jpg" rel="gallery" class="pirobox_gall" title="fertel">\
    					<img id="slika2" class="slika" src="slike/fertel2.jpg"  />\
					</a>\
        			<a href="slike/fertel3.jpg" rel="gallery" class="pirobox_gall" title="fertel">\
    					<img id="slika3" class="slika" src="slike/fertel3.jpg"  />\
					</a>\
                   	<a href="slike/fertel4.jpg" rel="gallery" class="pirobox_gall" title="fertel">\
    					<img id="slika4" class="slika" src="slike/fertel4.jpg"  />\
					</a>\
   	 			</div>');
	$('#slider').nivoSlider();
	$().piroBox_ext({
        	piro_speed : 900,
        	bg_alpha : 0.1,
        	piro_scroll : true
	});
	$('#tteh').html('<img src="slike/loader.gif" />');
	$('#tteh').html('<tr>\
                    	<td><img src="slike/ajax.jpg" /></td>\
                    	<td><img src="slike/java.jpg" /></td>\
                    	<td><img src="slike/js.jpg" /></td>\
                        <td><img src="slike/php.jpg" /></td>\
                        <td><img src="slike/ps.jpg" /></td>\
                        <td><img src="slike/xml.jpg" /></td>\
                        <td><img src="slike/xpath.jpg" /></td>\
                    </tr>');
}

function changeText2(){
	var p = document.getElementById("paragrafi");
	p.innerHTML = 'img src="loader.gif" />';
	p.innerHTML = '<p id="paragraf2">My personal website. This is reference page or portfolio whit my latest work and project. Everything from graphic design on website was build in Adobe Photoshop CS5.</p><p id="paragraf3">jQuery was used for image slider and image gallery when you click on image in slider. I build with jQuery slider for my tech skills and programs that i using. Javascript and jQuery was used for text changing. It also contains PHP script for sending mails, and a lot of CSS.<br />Ajax was used for sending emails in Get in touch section so there is no need for refreshing page.</p>';
	$('#down').html('');
	$(".slider-wrapper").html('<img src="slike/loader.gif" />');
$(".slider-wrapper").html('<div id="slider" class="nivoSlider">\
                    <a href="slike/home1.jpg" rel="gallery" class="pirobox_gall" title="home">\
    					<img id="slika1" class="slika" src="slike/home1.jpg"  />\
					</a>\
        			<a href="slike/home2.jpg" rel="gallery" class="pirobox_gall" title="home">\
    					<img id="slika2" class="slika" src="slike/home2.jpg"  />\
					</a>\
        			<a href="slike/home3.jpg" rel="gallery" class="pirobox_gall" title="home">\
    					<img id="slika3" class="slika" src="slike/home3.jpg"  />\
					</a>\
                   	<a href="slike/home4.jpg" rel="gallery" class="pirobox_gall" title="home">\
    					<img id="slika4" class="slika" src="slike/home4.jpg"  />\
					</a>\
   	 			</div>');
	$('#slider').nivoSlider();
	$().piroBox_ext({
        	piro_speed : 900,
        	bg_alpha : 0.1,
        	piro_scroll : true
	});
	$('#tteh').html('<img src="slike/loader.gif" />');
	$('#tteh').html('<tr>\
						<td><img src="slike/php.jpg" /></td>\
						<td><img src="slike/css.jpg" /></td>\
                        <td><img src="slike/ps.jpg" /></td>\
						<td><img src="slike/html.jpg" /></td>\
						<td><img src="slike/jquery.jpg" /></td>\
                    	<td><img src="slike/js.jpg" /></td>\
						<td><img src="slike/ajax.jpg" /></td>\
                    </tr>');
}

function changeText3(){
	var p = document.getElementById("paragrafi");
	p.innerHTML = 'img src="loader.gif" />';
	p.innerHTML = '<p id="paragraf2">First big project in C#. Idea of this application is multiple people can login and chose their schedule, if they dont chose their schedule than auto algoritham chose for them.</p><p id="paragraf3">It has 3500 lines of code. Windows forms was used for graphic interface and Photoshop for making background images. This project was for Software Design course. It has also algoritham for auto schedule , optimized for better performance.</p>';
	$('#down').html('<a href="download/SetupRASAD.rar" class="link"><br />Download SetupRASAD</a>');
	$(".slider-wrapper").html('<img src="slike/loader.gif" />');
$(".slider-wrapper").html('<div id="slider" class="nivoSlider">\
                    <a href="slike/rasad1.jpg" rel="gallery" class="pirobox_gall" title="home">\
    					<img id="slika1" class="slika" src="slike/rasad1.jpg"  />\
					</a>\
        			<a href="slike/rasad2.jpg" rel="gallery" class="pirobox_gall" title="home">\
    					<img id="slika2" class="slika" src="slike/rasad2.jpg"  />\
					</a>\
        			<a href="slike/rasad3.jpg" rel="gallery" class="pirobox_gall" title="home">\
    					<img id="slika3" class="slika" src="slike/rasad3.jpg"  />\
					</a>\
                   	<a href="slike/rasad4.jpg" rel="gallery" class="pirobox_gall" title="home">\
    					<img id="slika4" class="slika" src="slike/rasad4.jpg"  />\
					</a>\
   	 			</div>');
	$('#slider').nivoSlider();
	$().piroBox_ext({
        	piro_speed : 900,
        	bg_alpha : 0.1,
        	piro_scroll : true
	});
	$('#tteh').html('<img src="slike/loader.gif" />');
	$('#tteh').html('<tr>\
						<td><img src="slike/csharp.jpg" /></td>\
						<td><img src="slike/oo.jpg" /></td>\
                        <td><img src="slike/wform.jpg" /></td>\
						<td><img src="slike/linq.jpg" /></td>\
						<td><img src="slike/ps.jpg" /></td>\
                    </tr>');
}

function changeText4(){
		var p = document.getElementById("paragrafi");
	p.innerHTML = 'img src="loader.gif" />';
	p.innerHTML = '<p id="paragraf2">Project for Programming Paradigms and Languages course that combine multiple social networks like Facebook and Twitter and private FER network PpijBoard. It can sand messages, read info about your friends or followers, search friends and read status or tweets or messages that your friend send.</p><p id="paragraf3">Heavy use of Object oriented paradigm and advance C# functions. Parallel LINQ was used also. Graphic interface was build entirely in WPF xaml with data binding.</p>';
	$('#down').html('<a href="download/SocialApp.rar" class="link"><br />Download entire project</a>');
	$(".slider-wrapper").html('<img src="slike/loader.gif" />');
$(".slider-wrapper").html('<div id="slider" class="nivoSlider">\
                    <a href="slike/ppij1.jpg" rel="gallery" class="pirobox_gall" title="home">\
    					<img id="slika1" class="slika" src="slike/ppij1.jpg"  />\
					</a>\
        			<a href="slike/ppij2.jpg" rel="gallery" class="pirobox_gall" title="home">\
    					<img id="slika2" class="slika" src="slike/ppij2.jpg"  />\
					</a>\
        			<a href="slike/ppij3.jpg" rel="gallery" class="pirobox_gall" title="home">\
    					<img id="slika3" class="slika" src="slike/ppij3.jpg"  />\
					</a>\
                   	<a href="slike/ppij4.jpg" rel="gallery" class="pirobox_gall" title="home">\
    					<img id="slika4" class="slika" src="slike/ppij4.jpg"  />\
					</a>\
   	 			</div>');
	$('#slider').nivoSlider();
	$().piroBox_ext({
        	piro_speed : 900,
        	bg_alpha : 0.1,
        	piro_scroll : true
	});
	$('#tteh').html('<img src="slike/loader.gif" />');
	$('#tteh').html('<tr>\
						<td><img src="slike/csharp.jpg" /></td>\
						<td><img src="slike/oo.jpg" /></td>\
                        <td><img src="slike/wpf.jpg" /></td>\
						<td><img src="slike/linq.jpg" /></td>\
						<td><img src="slike/plinq.jpg" /></td>\
						<td><img src="slike/ps.jpg" /></td>\
						<td><img src="slike/parallel.jpg" /></td>\
						<td><img src="slike/json.jpg" /></td>\
                    </tr>');
}

function changeText5(){
			var p = document.getElementById("paragrafi");
	p.innerHTML = 'img src="loader.gif" />';
	p.innerHTML = '<p id="paragraf2">My first project after this website will be android app. It will be about films but its not yet specified. Second project is web page with wordpress. Theme isnt yet decided.</p><p id="paragraf3">For my third project i have in plan F# bookstore or something. And for fourth project i will build web store with php and mysql as a database.</p>';
	$('#down').html('');
	$(".slider-wrapper").html('<img src="slike/loader.gif" />');
$(".slider-wrapper").html('<div id="slider" class="nivoSlider">\
                    <a href="slike/android.jpg" rel="gallery" class="pirobox_gall" title="home">\
    					<img id="slika1" class="slika" src="slike/android.jpg"  />\
					</a>\
        			<a href="slike/fsharp.jpg" rel="gallery" class="pirobox_gall" title="home">\
    					<img id="slika2" class="slika" src="slike/fsharp.jpg"  />\
					</a>\
        			<a href="slike/word.jpg" rel="gallery" class="pirobox_gall" title="home">\
    					<img id="slika3" class="slika" src="slike/word.jpg"  />\
					</a>\
                   	<a href="slike/php2.jpg" rel="gallery" class="pirobox_gall" title="home">\
    					<img id="slika4" class="slika" src="slike/php2.jpg"  />\
					</a>\
   	 			</div>');
	$('#slider').nivoSlider();
	$().piroBox_ext({
        	piro_speed : 900,
        	bg_alpha : 0.1,
        	piro_scroll : true
	});
	$('#tteh').html('<img src="slike/loader.gif" />');
	$('#tteh').html('<tr>\
						<td><img src="slike/php.jpg" /></td>\
						<td><img src="slike/ps.jpg" /></td>\
                        <td><img src="slike/oo.jpg" /></td>\
						<td><img src="slike/ajax.jpg" /></td>\
						<td><img src="slike/java.jpg" /></td>\
						<td><img src="slike/fsh.jpg" /></td>\
                    </tr>');
}

function great(){
	$("#slider1").html('<img src="slike/loader.gif" />');
	$("#slider1").html('<a class="buttons prev" href="#">left</a>\
				<div class="viewport">\
					<ul class="overview">\
						<li class="okvira">\
                        <div class="para">\
                        	<span class="pokvir">C#<br /><br /></span>\
                            <span class="stext"><br />-----------------------------<br /><br />One of two best programming languages for me.</span>\
                        </div>\
                        </li>\
                     	<li class="okvira">\
                        <div class="para">\
                        	<span class="pokvir">Java<br /><br /></span>\
                            <span class="stext"><br />-----------------------------<br /><br />One of two best programming languages for me :)</span>\
                        </div>\
                        </li>\
						<li class="okvira">\
                        <div class="para">\
                        	<span class="pokvir">C<br /><br /></span>\
                            <span class="stext"><br />-----------------------------<br /><br />C is great ;)</span>\
                        </div>\
                        <li class="okvira">\
                        <div class="para">\
                        	<span class="pokvir">C++<br /><br /></span>\
                            <span class="stext"><br />-----------------------------<br /><br />Little bit messy when it comes to OO paradigm.</span>\
                        </div>\
                        </li>\
                        <li class="okvira">\
                        <div class="para">\
                        	<span class="pokvir">XHTML & CSS<br /><br /></span>\
                            <span class="stext"><br />-----------------------------<br /><br />Fun stuff.</span>\
                        </div>\
                        <li class="okvira">\
                        <div class="para">\
                        	<span class="pokvir">JavaScript & jQuery<br /><br /></span>\
                            <span class="stext"><br />-----------------------------<br /><br />Simple and powerful.</span>\
                        </div>\
                        </li>\
                        <li class="okvira">\
                        <div class="para">\
                        	<span class="pokvir">Python<br /><br /></span>\
                            <span class="stext"><br />-----------------------------<br /><br />Work more quickly and more effectively</span>\
                        </div>\
                        </li>\
                        <li class="okvira">\
                        <div class="para">\
                        	<span class="pokvir">SQL<br /><br /></span>\
                            <span class="stext"><br />-----------------------------<br /><br />Very good in sql and good in database design</span>\
						</div>\
						</li>\
					</ul>\
				</div>\
				<a class="buttons next" href="#">right</a>');
	$('#slider1').tinycarousel();
}

function good(){
	$("#slider1").html('<img src="slike/loader.gif" />');
	$("#slider1").html('<a class="buttons prev" href="#">left</a>\
						<div class="viewport">\
						<ul class="overview">\
						<li class="okvirb">\
                        <div class="para">\
                        	<span class="pokvir">XML & xPath<br /><br /></span>\
                            <span class="stext"><br />-----------------------------<br /><br />Mainly used for processing data.</span>\
                        </div>\
                        </li>\
                        <li class="okvirb">\
                        <div class="para">\
                        	<span class="pokvir">PHP<br /><br /></span>\
                            <span class="stext"><br />-----------------------------<br /><br />Server side scripting</span>\
                        </div>\
                        </li>\
                        <li class="okvirb">\
                        <div class="para">\
                        	<span class="pokvir">Perl<br /><br /></span>\
                            <span class="stext"><br />-----------------------------<br /><br />Feature-rich programming language</span>\
                        </div>\
                        </li>\
                        <li class="okvirb">\
                        <div class="para">\
                        	<span class="pokvir">Bash<br /><br /></span>\
                            <span class="stext"><br />-----------------------------<br /><br />Main thing for every linux user.</span>\
                        </div>\
                        </li>\
                        <li class="okvirb">\
                        <div class="para">\
                        	<span class="pokvir">DTD & XSL <br /><br /></span>\
                            <span class="stext"><br />-----------------------------<br /><br />Definition for html and transforming XML to html</span>\
                        </div>\
                        </li>\
					</ul>\
				</div>\
				<a class="buttons next" href="#">right</a>');
	$('#slider1').tinycarousel();
}

function beginner(){
	$("#slider1").html('<img src="slike/loader.gif" />');
	$("#slider1").html('<a class="buttons prev" href="#">left</a>\
						<div class="viewport">\
						<ul class="overview">\
						<li class="okvirc">\
                        <div class="para">\
                        	<span class="pokvir">F#<br /><br /></span>\
                            <span class="stext"><br />-----------------------------<br /><br />In my plan is one serious project in functional language in near future</span>\
                        </div>\
                        </li>\
                        <li class="okvirc">\
                        <div class="para">\
                        	<span class="pokvir">Haskell<br /><br /></span>\
                            <span class="stext"><br />-----------------------------<br /><br />In my plan is one serious project in functional language in near future</span>\
                        </div>\
                        </li>\
						</ul>\
						</div>\
						<a class="buttons next" href="#">right</a>');
	$('#slider1').tinycarousel();
}

function all1(){
		$("#slider1").html('<img src="slike/loader.gif" />');
	$("#slider1").html('<a class="buttons prev" href="#">left</a>\
				<div class="viewport">\
					<ul class="overview">\
						<li class="okvira">\
                        <div class="para">\
                        	<span class="pokvir">C#<br /><br /></span>\
                            <span class="stext"><br />-----------------------------<br /><br />One of two best programming languages for me.</span>\
                        </div>\
                        </li>\
                     	<li class="okvira">\
                        <div class="para">\
                        	<span class="pokvir">Java<br /><br /></span>\
                            <span class="stext"><br />-----------------------------<br /><br />One of two best programming languages for me :)</span>\
                        </div>\
                        </li>\
						<li class="okvira">\
                        <div class="para">\
                        	<span class="pokvir">C<br /><br /></span>\
                            <span class="stext"><br />-----------------------------<br /><br />C is great ;)</span>\
                        </div>\
                        <li class="okvira">\
                        <div class="para">\
                        	<span class="pokvir">C++<br /><br /></span>\
                            <span class="stext"><br />-----------------------------<br /><br />Little bit messy when it comes to OO paradigm.</span>\
                        </div>\
                        </li>\
                        <li class="okvira">\
                        <div class="para">\
                        	<span class="pokvir">XHTML & CSS<br /><br /></span>\
                            <span class="stext"><br />-----------------------------<br /><br />Fun stuff.</span>\
                        </div>\
                        <li class="okvira">\
                        <div class="para">\
                        	<span class="pokvir">JavaScript & jQuery<br /><br /></span>\
                            <span class="stext"><br />-----------------------------<br /><br />Simple and powerful.</span>\
                        </div>\
                        </li>\
                        <li class="okvira">\
                        <div class="para">\
                        	<span class="pokvir">Python<br /><br /></span>\
                            <span class="stext"><br />-----------------------------<br /><br />Work more quickly and more effectively</span>\
                        </div>\
                        </li>\
                        <li class="okvira">\
                        <div class="para">\
                        	<span class="pokvir">SQL<br /><br /></span>\
                            <span class="stext"><br />-----------------------------<br /><br />Very good in sql and good in database design</span>\
						</div>\
						</li>\
												<li class="okvirb">\
                        <div class="para">\
                        	<span class="pokvir">XML & xPath<br /><br /></span>\
                            <span class="stext"><br />-----------------------------<br /><br />Mainly used for processing data.</span>\
                        </div>\
                        </li>\
                        <li class="okvirb">\
                        <div class="para">\
                        	<span class="pokvir">PHP<br /><br /></span>\
                            <span class="stext"><br />-----------------------------<br /><br />Server side scripting</span>\
                        </div>\
                        </li>\
                        <li class="okvirb">\
                        <div class="para">\
                        	<span class="pokvir">Perl<br /><br /></span>\
                            <span class="stext"><br />-----------------------------<br /><br />Feature-rich programming language</span>\
                        </div>\
                        </li>\
                        <li class="okvirb">\
                        <div class="para">\
                        	<span class="pokvir">Bash<br /><br /></span>\
                            <span class="stext"><br />-----------------------------<br /><br />Main thing for every linux user.</span>\
                        </div>\
                        </li>\
                        <li class="okvirb">\
                        <div class="para">\
                        	<span class="pokvir">DTD & XSL <br /><br /></span>\
                            <span class="stext"><br />-----------------------------<br /><br />Definition for html and transforming XML to html</span>\
                        </div>\
                        </li>\
												<li class="okvirc">\
                        <div class="para">\
                        	<span class="pokvir">F#<br /><br /></span>\
                            <span class="stext"><br />-----------------------------<br /><br />In my plan is one serious project in functional language in near future</span>\
                        </div>\
                        </li>\
                        <li class="okvirc">\
                        <div class="para">\
                        	<span class="pokvir">Haskell<br /><br /></span>\
                            <span class="stext"><br />-----------------------------<br /><br />In my plan is one serious project in functional language in near future</span>\
                        </div>\
                        </li>\
					</ul>\
				</div>\
				<a class="buttons next" href="#">right</a>');
	$('#slider1').tinycarousel();
}

function heavy(){
	$("#slider2").html('<img src="slike/loader.gif" />');
	$('#slider2').html('<a class="buttons prev" href="#">left</a>\
				<div class="viewport">\
					<ul class="overview">\
						<li class="okvira">\
                        <div class="para">\
                        	<span class="pokvir">Visual Studio with Postsharp and .NET 4.0<br /></span>\
                            <span class="stext"><br />-----------------------------<br /><br />Main programming tool for me. <br />I use it for C and C++ also.</span>\
                        </div>\
                        </li>\
						<li class="okvira">\
                        <div class="para">\
                        	<span class="pokvir">NetBeans <br />and Eclipse<br /><br /></span>\
                            <span class="stext"><br />-----------------------------<br /><br />I was working with both of them , but i prefer Netbeans.</span>\
                        </div>\
                        </li>\
						<li class="okvira">\
                        <div class="para">\
                        	<span class="pokvir">Dreamweare & Photoshop<br /><br /></span>\
                            <span class="stext"><br />-----------------------------<br /><br />Main programming tool for web. Deadly Adobe combination. </span>\
                        </div>\
                        </li>\
                       	<li class="okvira">\
                        <div class="para">\
                        	<span class="pokvir">BackTrack<br /><br /><br /></span>\
                            <span class="stext"><br />-----------------------------<br /><br />Linux distribution for ethical hacking. Airmon, autopsy, wireshark, metasploit, nmap ..</span>\
                        </div>\
                        <li class="okvira">\
                        <div class="para">\
                        	<span class="pokvir">VMware Worksation<br /><br /><br /></span>\
                            <span class="stext"><br />-----------------------------<br /><br />Great tool for running multiple OS. Very important for ethical hacking.</span>\
                        </div>\
                        <li class="okvira">\
                        <div class="para">\
                        	<span class="pokvir">OllyDBG<br /><br /><br /></span>\
                            <span class="stext"><br />-----------------------------<br /><br />Cracking software.</span>\
                        </div>\
                        <li class="okvira">\
                        <div class="para">\
                        	<span class="pokvir">Xampp<br /><br /><br /></span>\
                            <span class="stext"><br />-----------------------------<br /><br />Open source cross-platform web server.</span>\
                        </div>\
                        </li>\
						</ul>\
						</div>\
						<a class="buttons next" href="#">right</a>');
	$('#slider2').tinycarousel();
}

function moderate(){
	$("#slider2").html('<img src="slike/loader.gif" />');
	$('#slider2').html('<a class="buttons prev" href="#">left</a>\
						<div class="viewport">\
						<ul class="overview">\
						<li class="okvirb">\
                        <div class="para">\
                        	<span class="pokvir">PuTTY and WinSCP<br /><br /><br /></span>\
                            <span class="stext"><br />-----------------------------<br /><br />Client application for connection to servers.</span>\
                        </div>\
                        <li class="okvirb">\
                        <div class="para">\
                        	<span class="pokvir">Imunes<br /><br /><br /></span>\
                            <span class="stext"><br />-----------------------------<br /><br />Network simulator.</span>\
                        </div>\
                        <li class="okvirb">\
                        <div class="para">\
                        	<span class="pokvir">MatLab<br /><br /><br /></span>\
                            <span class="stext"><br />-----------------------------<br /><br />Great for mathematical and tehnical computing.</span>\
                        </div>\
                        <li class="okvirb">\
                        <div class="para">\
                        	<span class="pokvir">Emacs and nano<br /><br /><br /></span>\
                            <span class="stext"><br />-----------------------------<br /><br />Editors for python, perl and bash on linux system.</span>\
                        </div>\
                        <li class="okvirb">\
                        <div class="para">\
                        	<span class="pokvir">Haskell Platform WinGHCi<br /><br /></span>\
                            <span class="stext"><br />-----------------------------<br /><br />IDE for haskell.</span>\
                        </div>\
                        <li class="okvirb">\
                        <div class="para">\
                        	<span class="pokvir">IBM Informix<br /><br /><br /></span>\
                            <span class="stext"><br />-----------------------------<br /><br />For database and sql.</span>\
                        </div>\
                        </li>\
                        <li class="okvirb">\
                        <div class="para">\
                        	<span class="pokvir">Dev C++ and CodeBloks<br /><br /></span>\
                            <span class="stext"><br />-----------------------------<br /><br />IDE for C and C++</span>\
                        </div>\
                        </li>\
						</ul>\
						</div>\
						<a class="buttons next" href="#">right</a>');
	$('#slider2').tinycarousel();
}

function light(){
	$("#slider2").html('<img src="slike/loader.gif" />');
	$('#slider2').html('<a class="buttons prev" href="#">left</a>\
						<div class="viewport">\
						<ul class="overview">\
                        <li class="okvirc">\
                        <div class="para">\
                        	<span class="pokvir">ATLAS<br /><br /><br /></span>\
                            <span class="stext"><br />-----------------------------<br /><br />Asembler, low level of programming. ARM and RISC procesors</span>\
                        </div>\
                        </li>\
                        <li class="okvirc">\
                        <div class="para">\
                        	<span class="pokvir">VHDLLab<br /><br /><br /></span>\
                            <span class="stext"><br />-----------------------------<br /><br />Tool for describing digital and mixed signals.</span>\
                        </div>\
                        </li>\
                        <li class="okvirc">\
                        <div class="para">\
                        	<span class="pokvir">Electronic Workbench Multisim<br /><br /></span>\
                            <span class="stext"><br />-----------------------------<br /><br />Tool for describing digital and mixed signals.</span>\
                        </div>\
                        </li>\
					</ul>\
				</div>\
				<a class="buttons next" href="#">right</a>');
	$('#slider2').tinycarousel();
}

function all2(){
		$("#slider2").html('<img src="slike/loader.gif" />');
	$('#slider2').html('<a class="buttons prev" href="#">left</a>\
				<div class="viewport">\
					<ul class="overview">\
						<li class="okvira">\
                        <div class="para">\
                        	<span class="pokvir">Visual Studio with Postsharp and .NET 4.0<br /></span>\
                            <span class="stext"><br />-----------------------------<br /><br />Main programming tool for me. <br />I use it for C and C++ also.</span>\
                        </div>\
                        </li>\
						<li class="okvira">\
                        <div class="para">\
                        	<span class="pokvir">NetBeans <br />and Eclipse<br /><br /></span>\
                            <span class="stext"><br />-----------------------------<br /><br />I was working with both of them , but i prefer Netbeans.</span>\
                        </div>\
                        </li>\
						<li class="okvira">\
                        <div class="para">\
                        	<span class="pokvir">Dreamweare & Photoshop<br /><br /></span>\
                            <span class="stext"><br />-----------------------------<br /><br />Main programming tool for web. Deadly Adobe combination. </span>\
                        </div>\
                        </li>\
                       	<li class="okvira">\
                        <div class="para">\
                        	<span class="pokvir">BackTrack<br /><br /><br /></span>\
                            <span class="stext"><br />-----------------------------<br /><br />Linux distribution for ethical hacking. Airmon, autopsy, wireshark, metasploit, nmap ..</span>\
                        </div>\
                        <li class="okvira">\
                        <div class="para">\
                        	<span class="pokvir">VMware Worksation<br /><br /><br /></span>\
                            <span class="stext"><br />-----------------------------<br /><br />Great tool for running multiple OS. Very important for ethical hacking.</span>\
                        </div>\
                        <li class="okvira">\
                        <div class="para">\
                        	<span class="pokvir">OllyDBG<br /><br /><br /></span>\
                            <span class="stext"><br />-----------------------------<br /><br />Cracking software.</span>\
                        </div>\
                        <li class="okvira">\
                        <div class="para">\
                        	<span class="pokvir">Xampp<br /><br /><br /></span>\
                            <span class="stext"><br />-----------------------------<br /><br />Open source cross-platform web server.</span>\
                        </div>\
                        </li>\
						<li class="okvirb">\
                        <div class="para">\
                        	<span class="pokvir">PuTTY and WinSCP<br /><br /><br /></span>\
                            <span class="stext"><br />-----------------------------<br /><br />Client application for connection to servers.</span>\
                        </div>\
                        <li class="okvirb">\
                        <div class="para">\
                        	<span class="pokvir">Imunes<br /><br /><br /></span>\
                            <span class="stext"><br />-----------------------------<br /><br />Network simulator.</span>\
                        </div>\
                        <li class="okvirb">\
                        <div class="para">\
                        	<span class="pokvir">MatLab<br /><br /><br /></span>\
                            <span class="stext"><br />-----------------------------<br /><br />Great for mathematical and tehnical computing.</span>\
                        </div>\
                        <li class="okvirb">\
                        <div class="para">\
                        	<span class="pokvir">Emacs and nano<br /><br /><br /></span>\
                            <span class="stext"><br />-----------------------------<br /><br />Editors for python, perl and bash on linux system.</span>\
                        </div>\
                        <li class="okvirb">\
                        <div class="para">\
                        	<span class="pokvir">Haskell Platform WinGHCi<br /><br /></span>\
                            <span class="stext"><br />-----------------------------<br /><br />IDE for haskell.</span>\
                        </div>\
                        <li class="okvirb">\
                        <div class="para">\
                        	<span class="pokvir">IBM Informix<br /><br /><br /></span>\
                            <span class="stext"><br />-----------------------------<br /><br />For database and sql.</span>\
                        </div>\
                        </li>\
                        <li class="okvirb">\
                        <div class="para">\
                        	<span class="pokvir">Dev C++ and CodeBloks<br /><br /></span>\
                            <span class="stext"><br />-----------------------------<br /><br />IDE for C and C++</span>\
                        </div>\
                        </li>\
                        <li class="okvirc">\
                        <div class="para">\
                        	<span class="pokvir">ATLAS<br /><br /><br /></span>\
                            <span class="stext"><br />-----------------------------<br /><br />Asembler, low level of programming. ARM and RISC procesors</span>\
                        </div>\
                        </li>\
                        <li class="okvirc">\
                        <div class="para">\
                        	<span class="pokvir">VHDLLab<br /><br /><br /></span>\
                            <span class="stext"><br />-----------------------------<br /><br />Tool for describing digital and mixed signals.</span>\
                        </div>\
                        </li>\
                        <li class="okvirc">\
                        <div class="para">\
                        	<span class="pokvir">Electronic Workbench Multisim<br /><br /></span>\
                            <span class="stext"><br />-----------------------------<br /><br />Tool for describing digital and mixed signals.</span>\
                        </div>\
                        </li>\
					</ul>\
				</div>\
				<a class="buttons next" href="#">right</a>');
	$('#slider2').tinycarousel();
}

function intro(){ 
		$('body,html').animate({scrollTop:0},800);
		$("#intro").css('background', 'url(slike/nav2.jpg) no-repeat center');
		$("#work").css('background', 'url(slike/nav1.jpg) no-repeat center');
		$("#skills").css('background', 'url(slike/nav1.jpg) no-repeat center');
		$("#contact").css('background', 'url(slike/nav1.jpg) no-repeat center');
}

function work(){ 
		$('body,html').animate({scrollTop:580},800);
		$("#intro").css('background', 'url(slike/nav1.jpg) no-repeat center');
		$("#work").css('background', 'url(slike/nav2.jpg) no-repeat center');
		$("#skills").css('background', 'url(slike/nav1.jpg) no-repeat center');
		$("#contact").css('background', 'url(slike/nav1.jpg) no-repeat center');
}

function skills(){ 
		$('body,html').animate({scrollTop:1165},800);
		$("#intro").css('background', 'url(slike/nav1.jpg) no-repeat center');
		$("#work").css('background', 'url(slike/nav1.jpg) no-repeat center');
		$("#skills").css('background', 'url(slike/nav2.jpg) no-repeat center');
		$("#contact").css('background', 'url(slike/nav1.jpg) no-repeat center');
}

function contact(){ 
		$('body,html').animate({scrollTop:1810},800);
		$("#intro").css('background', 'url(slike/nav1.jpg) no-repeat center');
		$("#work").css('background', 'url(slike/nav1.jpg) no-repeat center');
		$("#skills").css('background', 'url(slike/nav1.jpg) no-repeat center');
		$("#contact").css('background', 'url(slike/nav2.jpg) no-repeat center');
}








