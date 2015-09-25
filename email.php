<?php

sleep(1);

$message = $_GET['msg'];
$email = $_GET['email'];
$name = $_GET['name'];

mail( 'filipmamic@hotmail.com', 'Website email from ' . $name, 'From: ' . $email . "\n\n" . "Poruka\n----------\n" . $message);

?>